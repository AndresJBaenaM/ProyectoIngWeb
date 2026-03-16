using ApiParchePlanU.DAO;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;
using ApiParchePlanU.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ApiParchePlanU.Services
{
    public class PlanService : IPlanService
    {
        public readonly ApplicationDbContext _context; 
        public PlanService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Plan>> GetPlans(int parcheId)
        {
            return await _context.Plans.Where(p=> p.Parche_Id == parcheId).Include(p=> p.Options).ToListAsync();
        }
        public async Task<Plan> GetById(int planId)
        {
            return await _context.Plans.FindAsync(planId); 
        }
        public async Task<Plan> CreatePlan(Plan plan)
        {
            plan.State = PlanState.Draft; 
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
            return plan; 
        }
        public async Task ChangeState(int planId, PlanState newState)
        {
            var plan = await _context.Plans.FindAsync(planId);
            plan.State = newState;
            await _context.SaveChangesAsync();
        }
    }
}
