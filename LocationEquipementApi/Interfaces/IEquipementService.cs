using LocationEquipementApi.Dtos;

namespace LocationEquipementApi.Interfaces
{
    public interface IEquipementService
    {
        Task<List<EquipementDto>> RecupererEquipementsAsync();
        Task<bool> LouerEquipementAsync(int equipementId, int nbJours);
        Task<bool> AnnulerLocationAsync(int locationId);
    }
}
