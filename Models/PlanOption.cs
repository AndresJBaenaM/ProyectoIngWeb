namespace ApiParchePlanU.Models
{
    public class PlanOption
    {
        public int Id { get; set; }
        public string Lugar { get; set; }
        public DateTime Time { get; set; }
        public int PlanId { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
