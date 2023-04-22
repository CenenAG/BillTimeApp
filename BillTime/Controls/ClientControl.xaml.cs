using BillTimeLibrary.DataAccess;
using BillTimeLibrary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<ClientModel> clients = new ObservableCollection<ClientModel>();
        bool isNewEntry = true;

        public ClientControl()
        {
            InitializeComponent();
            InitializeClientList();
            WireUpClientDropDown();
            ToggleFormFieldsDisplay(false);
        }

        private void WireUpClientDropDown()
        {
            clientDropDown.ItemsSource = clients;
            clientDropDown.DisplayMemberPath = "Name";
            clientDropDown.SelectedValuePath = "Id";
        }

        private void InitializeClientList()
        {
            clients.Clear();
            string sql = "select * from clients order by name";
            var clientsList = SqliteDataAccess.LoadData<ClientModel>(sql, new Dictionary<string, object>());
            clientsList.ForEach(x => clients.Add(x));
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            clientStackPanel.Visibility = Visibility.Collapsed;
            editButton.Visibility = Visibility.Collapsed;
            isNewEntry = true;
            LoadDefaults();
            ToggleFormFieldsDisplay(true);
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
                RoundUpAfterXMinutesTextBox.Text = defaultsModel.RoundUpAfterXMinutes.ToString();
            }
            else
            {
                ClearFormData();
            }
        }

        private void ClearFormData()
        {
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            hourlyRateTextBox.Text = "0";
            preBillCheckBox.IsChecked = true;
            hasCutOffCheckBox.IsChecked = false;
            cutOffTextBox.Text = "0";
            minimumHoursTextBox.Text = "0.25";
            billingIncrementTextBox.Text = "0.25";
            RoundUpAfterXMinutesTextBox.Text = "0";
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
            ResetForm();
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

            SqliteDataAccess.SaveData(sql, parameters);

            MessageBox.Show("Success");
        }

        private void UpdateClient()
        {
            string sql = "Update Clients " +
                "Set Name=@Name, HourlyRate=@HourlyRate, Email=@Email, PreBill=@PreBill, HasCutOff=@HasCutOff, " +
                " CutOff=@CutOff, MinimumHours=@MinimumHours, BillingIncrement=@BillingIncrement, RoundUpAfterXMinutes=@RoundUpAfterXMinutes" +
                " where id=@Id";

            var form = ValidateForm();

            if (form.isValid == false)
            {
                MessageBox.Show("Invalid Form. PLease check your data and try again");
                return;
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Id", clientDropDown.SelectedValue},
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

            SqliteDataAccess.SaveData(sql, parameters);
            InitializeClientList();
            clientDropDown.SelectedIndex = 0;
            MessageBox.Show("Success");
        }

        private void ResetForm()
        {
            clientStackPanel.Visibility = Visibility.Visible;
            editButton.Visibility = Visibility.Visible;
            newButton.Visibility = Visibility.Visible;

            isNewEntry = true;

            ClearFormData();
            InitializeClientList();
            ToggleFormFieldsDisplay(false);
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
                model.RoundUpAfterXMinutes = int.Parse(RoundUpAfterXMinutesTextBox.Text);
            }
            catch (System.Exception)
            {
                isValid = false;
            }

            return (isValid, model);
        }

        private void ToggleFormFieldsDisplay(bool displayFields)
        {
            Visibility visibility = displayFields ? Visibility.Visible : Visibility.Collapsed;
            nameStackPanel.Visibility = visibility;
            emailStackPanel.Visibility = visibility;
            hourlyRateStackPanel.Visibility = visibility;
            checkBoxesStackPanel.Visibility = visibility;
            cutOffMinimumStackPanel.Visibility = visibility;
            incrementsStackPanel.Visibility = visibility;
            buttonStackPanel.Visibility = visibility;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientDropDown.SelectedItem == null)
            {
                MessageBox.Show("Please select the client first.");
                return;
            }
            clientStackPanel.Visibility = Visibility.Collapsed;
            newButton.Visibility = Visibility.Collapsed;
            isNewEntry = false;

            LoadClient();

            ToggleFormFieldsDisplay(true);
        }

        private void LoadClient()
        {
            ClientModel client = (ClientModel)clientDropDown.SelectedItem;

            nameTextBox.Text = client.Name;
            emailTextBox.Text = client.Email;
            hourlyRateTextBox.Text = client.HourlyRate.ToString();
            preBillCheckBox.IsChecked = (client.HourlyRate > 0);
            hasCutOffCheckBox.IsChecked = (client.HasCutOff > 0);
            cutOffTextBox.Text = client.CutOff.ToString();
            minimumHoursTextBox.Text = client.MinimumHours.ToString();
            billingIncrementTextBox.Text = client.BillingIncrement.ToString();
            RoundUpAfterXMinutesTextBox.Text = client.RoundUpAfterXMinutes.ToString();
        }

        private void cancelForm_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }
    }
}
