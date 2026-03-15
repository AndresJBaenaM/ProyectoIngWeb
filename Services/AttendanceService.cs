using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;
using ApiParchePlanU.DAO;

namespace ApiParchePlanU.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly ApplicationDbContext _context; 

        public AttendanceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task ConfirmAttendande(string userId, int planId, string status)
        {
            var attendance = new Attendance
            {
                User_Id = userId,
                PlanId = planId,
                Status = status,
            };
            _context.Attendances.Add(attendance); 
            await _context.SaveChangesAsync();
        }
        public async Task<List<Attendance>> GetAttendances(int planId)
        {
            return await _context.Attendances
                .Where(a=> a.PlanId == planId)
                .ToListAsync();
        }
    }
}
