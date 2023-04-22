using BillTimeLibrary.DataAccess;
using BillTimeLibrary.DataAccess.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillTime.Controls
{
    /// <summary>
    /// Lógica de interacción para WorkControl.xaml
    /// </summary>
    public partial class WorkControl : UserControl
    {
        ObservableCollection<ClientModel> clients = new ObservableCollection<ClientModel>();
        ObservableCollection<WorkModel> works = new ObservableCollection<WorkModel>();
        ObservableCollection<PaymentModel> payments = new ObservableCollection<PaymentModel>();

        public WorkControl()
        {
            InitializeComponent();
            InitializeClientList();
            WireUpDropDowns();
            ToggleFormFieldsDisplay(false);
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

            datetDropDown.ItemsSource = works;
            datetDropDown.DisplayMemberPath = "DisplayValue"; //DisplayValue
            datetDropDown.SelectedValuePath = "Id";

            paymentDropDown.ItemsSource = payments;
            paymentDropDown.DisplayMemberPath = "DisplayValue"; //DisplayValue
            paymentDropDown.SelectedValuePath = "Id";
        }

        private void ToggleFormFieldsDisplay(bool displayFields)
        {
            Visibility visibility = displayFields ? Visibility.Visible : Visibility.Collapsed;
            dateStackPanel.Visibility = visibility;
            hoursStackPanel.Visibility = visibility;
            titleStackPanel.Visibility = visibility;
            descriptionStackPanel.Visibility = visibility;
            paidStackPanel.Visibility = visibility;
            submitForm.Visibility = visibility;
        }

        private void clientDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dateStackPanel.Visibility = Visibility.Visible;
            LoadWorksDropDown();
            LoadPaymentDropDown();
        }

        private void LoadWorksDropDown()
        {
            string sql = "select * from Works where ClientId=@ClientId";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@ClientId", clientDropDown.SelectedValue);

            var worksRecords = SqliteDataAccess.LoadData<WorkModel>(sql, parameters);
            works.Clear();
            worksRecords.ForEach(x => works.Add(x));
        }

        private void datetDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datetDropDown.SelectedItem == null)
            {
                return;
            }

            ToggleFormFieldsDisplay(true);

            WorkModel workEntry = (WorkModel)datetDropDown.SelectedItem;

            hoursTextBox.Text = workEntry.Hours.ToString();
            titleTextBox.Text = workEntry.Title;
            descriptionTextBox.Text = workEntry.Description;
            paidCheckBox.IsChecked = workEntry.Paid > 0;

            if (workEntry.Paid > 0)
            {
                paymentStackPanel.Visibility = Visibility.Visible;
                var selectedPayment = payments.Where(x => x.Id == workEntry.PaymentId).FirstOrDefault();
                if (selectedPayment != null)
                {
                    paymentDropDown.SelectedItem = selectedPayment;
                }

            }
            else
            {
                paymentStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadPaymentDropDown()
        {
            string sql = "select * from Payments where ClientId=@ClientId";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@ClientId", clientDropDown.SelectedValue);

            var paymentsRecords = SqliteDataAccess.LoadData<PaymentModel>(sql, parameters);
            payments.Clear();
            paymentsRecords.ForEach(x => payments.Add(x));
        }

        private void paidCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (paidCheckBox.IsChecked == true)
            {
                paymentStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                paymentStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void submitForm_Click(object sender, RoutedEventArgs e)
        {
            UpdateWork();
            ResetForm();
        }

        private void ResetForm()
        {
            ToggleFormFieldsDisplay(false);
            ClearFormData();
        }

        private void ClearFormData()
        {
            hoursTextBox.Text = "";
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            paidCheckBox.IsChecked = false;
            paymentStackPanel.Visibility = Visibility.Collapsed;
        }

        private void UpdateWork()
        {
            string sql = "Update Works Set Hours=@Hours, Title=@Title, Description=@Description, paid=@paid, PaymentId=@PaymentId "
                + " where Id=@Id";

            var form = ValidateForm();

            if (form.isValid == false)
            {
                MessageBox.Show("Invalid Form. PLease check your data and try again");
                return;
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Id", datetDropDown.SelectedValue},
                { "@Hours", form.model.Hours },
                { "@Title", form.model.Title },
                { "@Description", form.model.Description },
                { "@Paid", form.model.Paid },
                { "@PaymentId", form.model.PaymentId },
            };

            SqliteDataAccess.SaveData(sql, parameters);

            WorkModel currentWork = (WorkModel)datetDropDown.SelectedItem;
            currentWork.Title = form.model.Title;
            currentWork.Hours = form.model.Hours;
            currentWork.Description = form.model.Description;
            currentWork.Paid = form.model.Paid;
            currentWork.PaymentId = form.model.PaymentId;

            MessageBox.Show("Success");
        }

        private (bool isValid, WorkModel model) ValidateForm()
        {
            bool isValid = true;
            WorkModel model = new WorkModel();
            try
            {
                var payment = (PaymentModel)paymentDropDown.SelectedItem;
                int? paymentId;

                if (payment != null && paidCheckBox.IsChecked == true)
                {
                    paymentId = payment.Id;
                }
                else
                {
                    paymentId = null;
                }
                model.Hours = double.Parse(hoursTextBox.Text);
                model.Title = titleTextBox.Text;
                model.Description = descriptionTextBox.Text;
                model.Paid = (bool)paidCheckBox.IsChecked ? 1 : 0;
                model.PaymentId = paymentId;
            }
            catch (System.Exception)
            {
                isValid = false;
            }

            return (isValid, model);
        }
    }
}
