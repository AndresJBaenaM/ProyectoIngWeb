using ApiParchePlanU.Models;
using ApiParchePlanU.Models.Enums;

namespace ApiParchePlanU.Interface
{
    public interface IPlanService
    {
        Task<List<Plan>> GetPlans(int parcheId); 
        Task<Plan> CreatePlan(Plan plan);
        Task ChangeStates(int planId, PlanState newState);
        Task<Plan> GetById(int planId);
    }
}
