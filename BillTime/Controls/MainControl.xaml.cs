using BillTimeLibrary.DataAccess;
using BillTimeLibrary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillTime.Controls
{
    /// <summary>
    /// Lógica de interacción para MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        ObservableCollection<ClientModel> clients = new ObservableCollection<ClientModel>();
        bool isTimerRunning=false;
        DateTime startTime;
     

        public MainControl()
        {
            InitializeComponent();
            InitializeClientList();
            WireUpClientDropDown();
        }

        private void InitializeClientList()
        {
            clients.Clear();
            string sql = "select * from clients order by name";
            var clientsList = SqliteDataAccess.LoadData<ClientModel>(sql, new Dictionary<string, object>());
            clientsList.ForEach(x => clients.Add(x));
        }

        private void WireUpClientDropDown()
        {
            clientDropDown.ItemsSource = clients;
            clientDropDown.DisplayMemberPath = "Name";
            clientDropDown.SelectedValuePath = "Id";
        }

        private void submitForm_Click(object sender, RoutedEventArgs e)
        {
            InsertNewWorkItem();
            ResetForm();
        }

        private void ResetForm()
        {
            hoursStackPanel.Visibility = Visibility.Visible;
            titleStackPanel.Visibility = Visibility.Visible;
            descriptionStackPanel.Visibility = Visibility.Visible;

            ClearFormData();
            InitializeClientList();
        }

        private void ClearFormData()
        {
            hoursTextBox.Text = "";
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private (bool isValid, WorkModel model) ValidateForm()
        {
            bool isValid = true;
            WorkModel model = new WorkModel();
            try
            {
                model.ClientId = (int)clientDropDown.SelectedValue;
                model.Hours = double.Parse(hoursTextBox.Text);
                model.Title = hoursTextBox.Text;
                model.Description = descriptionTextBox.Text;
            }
            catch (System.Exception)
            {
                isValid = false;
            }

            return (isValid, model);
        }

        private void InsertNewWorkItem()
        {
            string sql = "insert into Works (ClientId, Hours, Title, Description) " +
                        "values (@ClientId, @Hours, @Title, @Description)";

            var form = ValidateForm();

            if (form.isValid == false)
            {
                MessageBox.Show("Invalid Form. PLease check your data and try again");
                return;
            }

            form.model.ClientId = (int)clientDropDown.SelectedValue;
            
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientId", form.model.ClientId },
                { "@Hours", form.model.Hours },
                { "@Title", form.model.Title },
                { "@Description", form.model.Description },
            };

            SqliteDataAccess.SaveData(sql, parameters);

            MessageBox.Show("Success");
        }

        private void operateTime_Click(object sender, RoutedEventArgs e)
        {
            if (clientDropDown.SelectedItem == null)
            {
                MessageBox.Show("Please select a client first.");
                return;
            }
            if(isTimerRunning == true)
            {
                //stop the timer and calculate
                double minutes = DateTime.Now.Subtract(startTime).TotalMinutes;
                CalculateHours(minutes);
                isTimerRunning = false;
                operateTime.Background = Brushes.Green;
                operateTime.Content = "Start Timer";
            }
            else
            {
                startTime = DateTime.Now;
                isTimerRunning = true;
                operateTime.Content = "Stop Timer";
                operateTime.Background = Brushes.Red;
            }
        }

        private void CalculateHours(double minutes)
        {
            ClientModel client = (ClientModel)clientDropDown.SelectionBoxItem;
            double total = 0;
            double tempMinutes = minutes;
            double billingMinutes = (client.BillingIncrement * 60);

           while (tempMinutes > minutes)
            {
                total += client.BillingIncrement;
                tempMinutes -= billingMinutes;
            }

           if (tempMinutes >= client.RoundUpAfterXMinutes)
            {
                total += client.BillingIncrement;
            }

           hoursTextBox.Text = total.ToString();

        }
    }
}
