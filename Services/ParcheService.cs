using ApiParchePlanU.DAO;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiParchePlanU.Services
{
    public class ParcheService : IParcheService
    {
        public readonly ApplicationDbContext _context; 

        public ParcheService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parche>> GetAll()
        {
            return await _context.Parches.ToListAsync(); 
        }

        public async Task<Parche> GetById(int id)
        {
            return await _context.Parches.FindAsync(id); 
        }
        public async Task<Parche> Create(Parche parche)
        {
            _context.Parches.Add(parche); 
            await _context.SaveChangesAsync();
            return parche; 
        }

        public async Task JoinParche(string userId, string inviteCode)
        {
            var parche = await _context.Parches.FirstOrDefaultAsync(p => p.InviteCode == inviteCode);
            var member = new ParcheMember
            {
                Id_Usuario = userId,
                Parche_Id = parche.Id,
                role = "Member"
            }; 
            _context.ParcheMembers.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ParcheMember>> GetMembers(int parcheId)
        {
            return await _context.ParcheMembers.Where(m=> m.Parche_Id == parcheId).ToListAsync();
        }
    }
}
