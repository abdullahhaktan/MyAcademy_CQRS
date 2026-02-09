namespace MyAcademyCQRS.Entities
{
    public class CustomerLog
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Action { get; set; }
        public string IpAddress { get; set; }
        public string LogType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
