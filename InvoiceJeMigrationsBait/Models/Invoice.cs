namespace InvoiceJe.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string BillTo { get; set; }
        public decimal Amount { get; set; }
    }
}
