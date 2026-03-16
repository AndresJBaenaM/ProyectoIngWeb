namespace ApiParchePlanU.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string Usuario_Id { get; set; }

        public int PlanOptionId { get; set; }

        public int Plan_Id { get; set; }

        public User user { get; set; }

        public PlanOption PlanOption { get; set; }
    }
}