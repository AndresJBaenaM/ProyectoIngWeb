namespace ApiParchePlanU.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartVoting {  get; set; }
        public DateTime EndVoting { get; set; }
        public PlanState State { get; set; }
        public int Parche_Id { get; set; }
        public ICollection<PlanOption> Options { get; set; }
    }
}
