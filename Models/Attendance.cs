using ApiParchePlanU.Models.Enums;

namespace ApiParchePlanU.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string User_Id { get; set; }
        public int PlanId { get; set; }
        public AttendanceStatus Status { get; set; }
        public User user { get; set; }
        public Plan plan { get; set; }
    }
}
