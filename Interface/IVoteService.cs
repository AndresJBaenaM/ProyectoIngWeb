namespace ApiParchePlanU.Interface
{
    public interface IVoteService
    {
        Task Vote(string userId, int optionId);
        Task ChangeVote(string userId, int optionId); 
    }
}
