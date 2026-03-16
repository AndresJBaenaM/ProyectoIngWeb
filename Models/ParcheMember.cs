using ApiParchePlanU.Models.Enums;

namespace ApiParchePlanU.Models
{
    public class ParcheMember
    {
        public int Id { get; set; }
        public string Id_Usuario { get; set; }
        public int Parche_Id { get; set; }
        public ParcheRole Role { get; set; }
        public User user { get; set; }
        public Parche parche { get; set; }
    }
}
