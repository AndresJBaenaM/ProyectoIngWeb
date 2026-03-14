namespace ApiParchePlanU.Models
{
    public class PlanOption
    {
        public int Id { get; set; }
        public string Lugar { get; set; }
        public DateTime Time { get; set; }
        public int Plan_Id { get; set; }
        public Plan plan { get; set; }
    }
}
