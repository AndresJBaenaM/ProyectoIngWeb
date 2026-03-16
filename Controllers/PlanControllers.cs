using Microsoft.AspNetCore.Mvc;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;
using ApiParchePlanU.Models.Enums;

namespace ApiParchePlanU.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        // Obtener planes de un parche
        [HttpGet("parche/{parcheId}")]
        public async Task<ActionResult<List<Plan>>> GetPlans(int parcheId)
        {
            var plans = await _planService.GetPlans(parcheId);
            return Ok(plans);
        }

        // Obtener plan por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetById(int id)
        {
            var plan = await _planService.GetById(id);

            if (plan == null)
                return NotFound("Plan no encontrado");

            return Ok(plan);
        }

        // Crear plan
        [HttpPost]
        public async Task<ActionResult<Plan>> CreatePlan([FromBody] Plan plan)
        {
            var newPlan = await _planService.CreatePlan(plan);
            return Ok(newPlan);
        }

        // Cambiar estado del plan
        [HttpPut("{planId}/state")]
        public async Task<IActionResult> ChangeState(int planId, [FromQuery] PlanState newState)
        {
            await _planService.ChangeState(planId, newState);
            return Ok("Estado del plan actualizado");
        }
    }
}
