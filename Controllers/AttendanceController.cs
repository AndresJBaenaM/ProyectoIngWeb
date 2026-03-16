using Microsoft.AspNetCore.Mvc;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;

namespace ApiParchePlanU.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // Confirmar asistencia
        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmAttendance(
            [FromQuery] string userId,
            [FromQuery] int planId,
            [FromQuery] string status)
        {
            await _attendanceService.ConfirmAttendance(userId, planId, status);
            return Ok("Attendance confirmed");
        }

        // Obtener lista de asistencias de un plan
        [HttpGet("{planId}")]
        public async Task<ActionResult<List<Attendance>>> GetAttendances(int planId)
        {
            var attendances = await _attendanceService.GetAttendances(planId);
            return Ok(attendances);
        }
    }
}
