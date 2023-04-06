using BillTimeLibrary.DataAccess;
using BillTimeLibrary.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillTime.Controls
{
    /// <summary>
    /// Lógica de interacción para DefaultsControl.xaml
    /// </summary>
    public partial class DefaultsControl : UserControl
    {
        public DefaultsControl()
        {
            InitializeComponent();
            LoadDefaultsFromDb();
        }

        private void LoadDefaultsFromDb()
        {
            string sql = "SELECT * FROM Defaults";
            DefaultsModel defaultsModel = SqliteDataAccess.LoadData<DefaultsModel>(sql, new Dictionary<string, object>()).FirstOrDefault();
            if (defaultsModel != null)
            {
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
                hourlyRateTextBox.Text = "0";
                preBillCheckBox.IsChecked = true;
                hasCutOffCheckBox.IsChecked = false;
                cutOffTextBox.Text = "0";
                minimumHoursTextBox.Text = "0.25";
                billingIncrementTextBox.Text = "0.25";
                roundUpAfterXMinutesTextBox.Text = "0";
            }
        }

        private (bool isValid, DefaultsModel model) ValidateForm()
        {
            bool isValid = true;
            DefaultsModel model = new DefaultsModel();
            try
            {
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

        private void SaveToDb(DefaultsModel model)
        {
            string sql = "delete from Defaults";
            SqliteDataAccess.SaveData(sql, new Dictionary<string, object>());

            sql = "Insert into Defaults (HourlyRate, PreBill, HasCutOff, CutOff, MinimumHours, BillingIncrement, RoundUpAfterXMinutes) " +
                " values (@HourlyRate, @PreBill, @HasCutOff, @CutOff, @MinimumHours, @BillingIncrement, @RoundUpAfterXMinutes)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@HourlyRate", model.HourlyRate },
                { "@PreBill", model.PreBill },
                { "@HasCutOff", model.HasCutOff },
                { "@CutOff",model.CutOff },
                { "@MinimumHours",model.MinimumHours },
                { "@BillingIncrement", model.BillingIncrement },
                { "@RoundUpAfterXMinutes", model.RoundUpAfterXMinutes }
            };

            SqliteDataAccess.SaveData(sql, parameters);
        }

        private void submitForm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //validate
            var form = ValidateForm();
            if (form.isValid == true)
            {
                SaveToDb(form.model);
                MessageBox.Show("Success!!!");
            }
            else
            {
                MessageBox.Show("The form is not valid. Please check your entries and try again.");
                return;
            }

        }
    }
}
