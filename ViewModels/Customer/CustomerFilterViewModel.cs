namespace TesteSmartHint.Web.ViewModels.Customer
{
    public class CustomerFilterViewModel
    {
        public int Page { get; set; } = 1;
        public string ByName { get; set; }
        public string ByEmail { get; set; }
        public string ByPhone { get; set; }
        public string ByDate { get; set; }
        public bool? ByBlocked { get; set; }
    }
}