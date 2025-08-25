
using LocationEquipementApi.ContexteBD;
using LocationEquipementApi.Dtos;
using LocationEquipementApi.Entites;
using LocationEquipementApi.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LocationEquipementApi.Services
{
    public class EquipementService : IEquipementService
    {
        private readonly LocationEquipementContext _context;

        public EquipementService(LocationEquipementContext context)
        {
            _context = context;
        }

        public async Task<List<EquipementDto>> RecupererEquipementsAsync()
        {
            List<Equipement> equipements = await _context.Equipements
                .Include(e => e.Locations)
                .ToListAsync();

            DateOnly aujourdhui = DateOnly.FromDateTime(DateTime.Now);


            List<EquipementDto> resultat = equipements.Select(equipement =>
            {
                var locationActive = equipement.Locations.FirstOrDefault(l => l.Active && l.DateA >= aujourdhui);

                return new EquipementDto
                {
                    EquipementId = equipement.Id,
                    Nom = equipement.Nom,
                    Description = equipement.Description,
                    Actif = locationActive != null,
                    DateDe = locationActive?.DateDe,
                    DateA = locationActive?.DateA
                };
            }).ToList();

            return resultat;
        }

        public async Task<bool> LouerEquipementAsync(int equipementId, int nbJours)
        {
            Equipement? equipement = await _context.Equipements
                .Include(e => e.Locations)
                .SingleOrDefaultAsync(e => e.Id == equipementId);

            DateOnly aujourdhui = DateOnly.FromDateTime(DateTime.Now);

            if (equipement == null)
            {
                return false;
            }

            Location? locationActive = equipement.Locations.FirstOrDefault(l => l.Active  && l.DateA >= aujourdhui);

            if (locationActive != null)
            {
                return false;
            }

            Location nouvelleLocation = new Location
            {
                DateDe = aujourdhui,
                DateA = aujourdhui.AddDays(nbJours),
                Active = true,
                EquipementId = equipementId
            };

            _context.Locations.Add(nouvelleLocation);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> AnnulerLocationAsync(int equipementId)
        {
            DateOnly aujourdhui = DateOnly.FromDateTime(DateTime.Now);
            Location? location = await _context.Locations
                .Where(l => l.EquipementId == equipementId && l.Active && l.DateA >= aujourdhui)
                .FirstOrDefaultAsync();

            if (location == null || !location.Active)
            {
                return false;
            }

            location.Active = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
