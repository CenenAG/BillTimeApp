namespace BillTimeLibrary.DataAccess.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Hours { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public string DisplayValue
        {
            get
            {
                return $"{ Date } - ${ Amount }";
            }
        }
    }
}
