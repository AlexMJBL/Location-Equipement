using LocationEquipementApi.Dtos;
using LocationEquipementApi.Entites;
using LocationEquipementApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocationEquipementApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EquipementController : ControllerBase
    {
        private readonly IEquipementService _equipementService;

        public EquipementController(IEquipementService equipementService)
        {
            _equipementService = equipementService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Equipement>>> Get()
        {
            return Ok(await _equipementService.RecupererEquipementsAsync());
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult> LouerEquipement(int id, [FromBody] DemandeLocationDTO location)
        {
            bool resultat = await _equipementService.LouerEquipementAsync(id, location.NbJours);
            if (!resultat) return BadRequest(new { message = "Equipement non disponible" });

            return Ok(new { message = "Location effectuée!" });
        }

        [HttpPut("[action]/{locationId}")]
        public async Task<ActionResult> AnnulerLocation(int locationId)
        {

            bool resultat = await _equipementService.AnnulerLocationAsync(locationId);
            if (!resultat) return NotFound(new { message = "Location non trouvée" });

            return Ok(new { message = "Annulation effectuée" });
        }
    }
    }

