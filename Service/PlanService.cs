using ApiParchePlanU.DAO;
using ApiParchePlanU.Models;
using ApiParchePlanU.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ApiParchePlanU.Service
{
    public class PlanService
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
        public async Task ChangeSate(int planId, PlanSate neaPlanSate)
        {
            var plan = await _context.Plans.FindAsync(planId);
            plan.State = newState;
            await _context.SaveChangesAsync();
        }
    }
}
