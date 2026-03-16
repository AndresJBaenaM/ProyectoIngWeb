using ApiParchePlanU.Models;
using ApiParchePlanU.Models.Enums;

namespace ApiParchePlanU.Interfaces
{
    public interface IPlanService
    {
        Task<List<Plan>> GetPlans(int parcheId); 
        Task<Plan> CreatePlan(Plan plan);
        Task ChangeState(int planId, PlanState newState);
        Task<Plan> GetById(int planId);
    }
}
