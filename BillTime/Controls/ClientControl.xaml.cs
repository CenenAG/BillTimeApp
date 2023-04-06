using BillTimeLibrary.DataAccess;
using BillTimeLibrary.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillTime.Controls
{
    /// <summary>
    /// Lógica de interacción para ClientUserControl.xaml
    /// </summary>
    public partial class ClientControl : UserControl
    {
        List<ClientModel> clients;
        bool isNewEntry = true;

        public ClientControl()
        {
            InitializeComponent();

            InitializeClientList();

            WireUpClientDropDown();
        }

        private void WireUpClientDropDown()
        {
            clientDropDown.ItemsSource = clients;
            clientDropDown.DisplayMemberPath = "Name";
            clientDropDown.SelectedValuePath = "Id";
        }

        private void InitializeClientList()
        {
            string sql = "select * from clients";
            clients = SqliteDataAccess.LoadData<ClientModel>(sql, new Dictionary<string, object>());
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            clientStackPanel.Visibility = Visibility.Collapsed;
            editButton.Visibility = Visibility.Collapsed;
            isNewEntry = true;
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            string sql = "SELECT * FROM Defaults";
            DefaultsModel defaultsModel = SqliteDataAccess.LoadData<DefaultsModel>(sql, new Dictionary<string, object>()).FirstOrDefault();
            if (defaultsModel != null)
            {
                nameTextBox.Text = "";
                emailTextBox.Text = "";
                hourlyRateTextBox.Text = defaultsModel.HourlyRate.ToString();
                preBillCheckBox.IsChecked = (defaultsModel.HourlyRate > 0);
                hasCutOffCheckBox.IsChecked = (defaultsModel.HasCutOff > 0);
                cutOffTextBox.Text = defaultsModel.CutOff.ToString();
                minimumHoursTextBox.Text = defaultsModel.MinimumHours.ToString();
                billingIncrementTextBox.Text = defaultsModel.BillingIncrement.ToString();
                roundUpAfterXMinutesTextBox.Text = defaultsModel.RoundUpAfterXMinutes.ToString();
            }
            else
            {
                nameTextBox.Text = "";
                emailTextBox.Text = "";
                hourlyRateTextBox.Text = "0";
                preBillCheckBox.IsChecked = true;
                hasCutOffCheckBox.IsChecked = false;
                cutOffTextBox.Text = "0";
                minimumHoursTextBox.Text = "0.25";
                billingIncrementTextBox.Text = "0.25";
                roundUpAfterXMinutesTextBox.Text = "0";
            }
        }

        private void submitForm_Click(object sender, RoutedEventArgs e)
        {
            if (isNewEntry)
            {
                InsertNewClient();
            }
            else
            {
                UpdateClient();
            }
        }

        private void InsertNewClient()
        {
            string sql = "insert into Clients (Name, HourlyRate, Email, PreBill, HasCutOff, CutOff, MinimumHours, BillingIncrement, RoundUpAfterXMinutes ) " +
                "values (@Name, @HourlyRate, @Email, @PreBill, @HasCutOff, @CutOff, @MinimumHours, @BillingIncrement, @RoundUpAfterXMinutes)";

            var form = ValidateForm();

            if (form.isValid == false)
            {
                MessageBox.Show("Invalid Form. PLease check your data and try again");
                return;
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Name", form.model.Name },
                { "@HourlyRate", form.model.HourlyRate },
                { "@Email", form.model.Email },
                { "@PreBill", form.model.PreBill},
                { "@HasCutOff", form.model.HasCutOff},
                { "@CutOff", form.model.CutOff},
                { "@MinimumHours", form.model.MinimumHours },
                { "@BillingIncrement", form.model.BillingIncrement},
                { "@RoundUpAfterXMinutes", form.model.RoundUpAfterXMinutes }
            };

            SqliteDataAccess.SaveData(sql,parameters);

        }

        private void UpdateClient()
        {

        }

        private void ResetForm()
        {
            clientStackPanel.Visibility = Visibility.Visible;
            editButton.Visibility = Visibility.Visible;
            newButton.Visibility = Visibility.Visible;
            isNewEntry = true;
        }

        private (bool isValid, ClientModel model) ValidateForm()
        {
            bool isValid = true;
            ClientModel model = new ClientModel();
            try
            {
                model.Name = nameTextBox.Text;
                model.Email = emailTextBox.Text;
                model.HasCutOff = (bool)hasCutOffCheckBox.IsChecked ? 1 : 0;
                model.PreBill = (bool)preBillCheckBox.IsChecked ? 1 : 0;
                model.HourlyRate = double.Parse(hourlyRateTextBox.Text);
                model.CutOff = int.Parse(cutOffTextBox.Text);
                model.MinimumHours = double.Parse(minimumHoursTextBox.Text);
                model.BillingIncrement = double.Parse(billingIncrementTextBox.Text);
                model.RoundUpAfterXMinutes = int.Parse(roundUpAfterXMinutesTextBox.Text);
            }
            catch (System.Exception)
            {
                isValid = false;
            }

            return (isValid, model);
        }
    }
}
