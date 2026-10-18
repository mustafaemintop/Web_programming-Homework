using System.ComponentModel.DataAnnotations;

public class CollectViewModel
{
    [Required(ErrorMessage = "Order ID is nessesary.")]
    public string OrderID { get; set; }
}