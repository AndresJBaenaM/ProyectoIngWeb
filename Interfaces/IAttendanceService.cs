using ApiParchePlanU.Models;

namespace ApiParchePlanU.Interfaces
{
    public interface IAttendanceService
    {
        Task ConfirmAttendance(string userId, int planId, string status);
        Task<List<Attendance>> GetAttendances(int planId); 
    }
}
