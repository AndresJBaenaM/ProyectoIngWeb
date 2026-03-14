using ApiParchePlanU.DAO;

namespace ApiParchePlanU.Service
{
    public class PlanService
    {
        public readonly ApplicationDbContext _context; 
        public PlanService(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
