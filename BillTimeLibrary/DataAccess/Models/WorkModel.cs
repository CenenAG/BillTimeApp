namespace BillTimeLibrary.DataAccess.Models
{
    public class WorkModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Hours { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int Paid { get; set; }
        public int? PaymentId { get; set; }
        public string DisplayValue
        {
            get
            {
                return $"{Date} - {Title}";
            }
        }
    }
}
