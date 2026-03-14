namespace ApiParchePlanU.Models
{
    public class Parche
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public string InviteCode { get; set; }
        public List<Plan> Plans { get; set; }
        public List<ParcheMember> Members {  get; set; }
    }
}
