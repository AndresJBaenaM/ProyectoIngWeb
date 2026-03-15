using ApiParchePlanU.Interface;
using ApiParchePlanU.Models;
using ApiParchePlanU.DAO;
using ApiParchePlanU.Interfaces;

namespace ApiParchePlanU.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly ApplicationDbContext _context; 

        public AttendanceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task ConfirAttendande(string userId, int planId, string status)
        {
            var attendance = new Attendance
            {
                UserId = userId,
                PlanId = planId,
                Status = status,
            };
            _context.Attendance.Add(attendance); 
            await _context.SaveChangesAsync();
        }
        public async Task<List<Attendance>> GetAttendances(int planId)
        {
            return await _context.Attendance
                .Where(a=> a.PlanId == planId)
                .ToListAsync();
        }
    }
}
