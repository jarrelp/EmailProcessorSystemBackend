namespace EmailFetchingService.Models.EmailTemplateData;

public class PaymentConfirmationData
{
    public string OrderNumber { get; set; } = "";
    public string CustomerName { get; set; } = "";
    public DateTime PaymentDate { get; set; } = new DateTime();
    public decimal Amount { get; set; } = 0;
    public string PaymentMethod { get; set; } = "";
    public string PaymentStatus { get; set; } = "";
    public string ReferenceNumber { get; set; } = "";
    public string Description { get; set; } = "";
}
