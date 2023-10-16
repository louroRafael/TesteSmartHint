namespace TesteSmartHint.Domain.DTO
{
    public class CustomerFilter
    {
        public int Page { get; set; }
        public string ByName { get; set; }
        public string ByEmail { get; set; }
        public string ByPhone { get; set; }
        public string ByDate { get; set; }
        public bool? ByBlocked { get; set; }
    }
}
