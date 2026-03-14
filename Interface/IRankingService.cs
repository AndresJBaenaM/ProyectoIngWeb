namespace ApiParchePlanU.Interface
{
    public interface IRankingService
    {
        Task<object> GetRanking(int planId); 
    }
}
