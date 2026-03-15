namespace ApiParchePlanU.Interface
{
    public interface IRankingServices
    {
        Task<object> GetRanking(int planId); 
    }
}
