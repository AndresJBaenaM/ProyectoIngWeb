namespace ApiParchePlanU.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PlanId { get; set; }
        public string Status { get; set; }
    }
}
