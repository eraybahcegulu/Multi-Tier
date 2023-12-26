public class AddProductViewModel
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int CategoryID { get; set; }
    public List<CategoryViewModel>? Categories { get; set; }
}