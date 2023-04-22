using BillTimeLibrary.DataAccess;
using BillTimeLibrary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BillTime.Controls
{
    /// <summary>
    /// Lógica de interacción para PaymentsControl.xaml
    /// </summary>
    public partial class PaymentsControl : UserControl
    {
        ObservableCollection<ClientModel> clients = new ObservableCollection<ClientModel>();
        ObservableCollection<PaymentModel> payments = new ObservableCollection<PaymentModel>();
        bool isNewEntry = true;

        public PaymentsControl()
        {
            InitializeComponent();
            InitializeClientList();
            WireUpDropDowns();
            ToggleFormFieldsDisplay(false);
            selectionStackPanel.Visibility = Visibility.Collapsed;
        }

        private void InitializeClientList()
        {
            clients.Clear();
            string sql = "select * from clients order by name";
            var clientsList = SqliteDataAccess.LoadData<ClientModel>(sql, new Dictionary<string, object>());
            clientsList.ForEach(x => clients.Add(x));
        }

        private void WireUpDropDowns()
        {
            clientDropDown.ItemsSource = clients;
            clientDropDown.DisplayMemberPath = "Name";
            clientDropDown.SelectedValuePath = "Id";

            datetDropDown.ItemsSource = payments;
            datetDropDown.DisplayMemberPath = "DisplayValue"; //DisplayValue
            datetDropDown.SelectedValuePath = "Id";

        }

        private void ToggleFormFieldsDisplay(bool displayFields)
        {
            Visibility visibility = displayFields ? Visibility.Visible : Visibility.Collapsed;

            amountStackPanel.Visibility = visibility;
            hoursStackPanel.Visibility = visibility;
            buttonStackPanel.Visibility = visibility;
        }

        private void submitForm_Click(object sender, RoutedEventArgs e)
        {
            if (isNewEntry == true)
            {
                InsertNewPayment();

            }
            else
            {
                UpdatePayment();
            }
            ResetForm();
        }

        private void UpdatePayment()
        {
            string sql = "Update Payments Set Hours=@Hours, Amount=@Amount where Id=@Id";

            var form = ValidateForm();

            if (form.isValid == false)
            {
                MessageBox.Show("Invalid Form. PLease check your data and try again");
                return;
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Id", datetDropDown.SelectedValue},
                { "@Amount", form.model.Amount },
                { "@Hours", form.model.Hours },
            };

            SqliteDataAccess.SaveData(sql, parameters);


            PaymentModel currentPayment = (PaymentModel)datetDropDown.SelectedItem;
            currentPayment.Amount = form.model.Amount;
            currentPayment.Hours = form.model.Hours;

            MessageBox.Show("Success");
        }

        private void InsertNewPayment()
        {
            string sql = "insert into Payments (ClientId, Hours, Amount) " +
                        "values (@ClientId, @Hours, @Amount)";

            var form = ValidateForm();

            if (form.isValid == false)
            {
                MessageBox.Show("Invalid Form. PLease check your data and try again");
                return;
            }

            form.model.ClientId = (int)clientDropDown.SelectedValue;
            form.model.Date = DateTime.Today.ToString("yyyy-MM-dd");

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientId", form.model.ClientId },
                { "@Amount", form.model.Amount },
                { "@Hours", form.model.Hours },
            };

            SqliteDataAccess.SaveData(sql, parameters);

            payments.Add(form.model);

            MessageBox.Show("Success");
        }

        private (bool isValid, PaymentModel model) ValidateForm()
        {
            bool isValid = true;
            PaymentModel model = new PaymentModel();
            try
            {
                model.Hours = double.Parse(hoursTextBox.Text);
                model.Amount = double.Parse(amountTextBox.Text);
                model.ClientId = (int)clientDropDown.SelectedValue;

            }
            catch (System.Exception)
            {
                isValid = false;
            }

            return (isValid, model);
        }

        private void ResetForm()
        {
            dateStackPanel.Visibility = Visibility.Visible;
            orTextBlock.Visibility = Visibility.Visible;
            newButton.Visibility = Visibility.Visible;

            isNewEntry = true;

            ClearFormData();

            ToggleFormFieldsDisplay(false);

        }

        private void ClearFormData()
        {
            amountTextBox.Text = "";
            hoursTextBox.Text = "";
        }


        private void cancelForm_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void clientDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionStackPanel.Visibility = Visibility.Visible;

            LoadDateDropDown();
        }

        private void LoadDateDropDown()
        {
            string sql = "select * from Payments where ClientId=@ClientId";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@ClientId", clientDropDown.SelectedValue);

            var paymentsRecords = SqliteDataAccess.LoadData<PaymentModel>(sql, parameters);
            payments.Clear();
            paymentsRecords.ForEach(x => payments.Add(x));
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleFormFieldsDisplay(true);
            dateStackPanel.Visibility = Visibility.Collapsed;
            orTextBlock.Visibility = Visibility.Collapsed;
        }

        private void datetDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orTextBlock.Visibility = Visibility.Collapsed;
            newButton.Visibility = Visibility.Collapsed;

            PaymentModel payment = (PaymentModel)datetDropDown.SelectedItem;

            amountTextBox.Text = payment.Amount.ToString();
            hoursTextBox.Text = payment.Hours.ToString();

            isNewEntry = false;

            ToggleFormFieldsDisplay(true);

        }
    }
}
