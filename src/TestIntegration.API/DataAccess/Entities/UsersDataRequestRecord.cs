namespace TestIntegration.API.DataAccess.Entities
{
    public class UsersDataRequestRecord
    {
        public long Id { get; set; }
        public string? Login { get; set; }
        public DateTime RequestedOn { get; set; }
    }
}
