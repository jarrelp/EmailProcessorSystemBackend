namespace EmailProcessingService.Models.EmailTemplateData;

public class PaymentConfirmationData
{
    public string? OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public DateTime? PaymentDate { get; set; }
    public decimal? Amount { get; set; }
    public string? PaymentMethod { get; set; }
    public string? PaymentStatus { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? Description { get; set; }
}
