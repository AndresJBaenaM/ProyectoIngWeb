namespace ApiParchePlanU.Models
{
    public class CheckIn
    {
        public int Id { get; set; }
        public string User_Id { get; set; }
        public int PlanId { get; set; }
        public DateTime CheckInTime { get; set; }
        public User user { get; set; }
        public Plan plan { get; set; }
    }
}
