using Microsoft.AspNetCore.Mvc;
using PetitionsCommon.Models;

namespace PetitionsBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetitionsController : ControllerBase
    {
        // Simulação de uma lista de petições
        private static readonly Petition[] _petitions = new Petition[]
        {
            new Petition { Id = 1, Title = "Petição 1", Content = "Conteúdo da Petição 1" },
            new Petition { Id = 2, Title = "Petição 2", Content = "Conteúdo da Petição 2" },
            new Petition { Id = 3, Title = "Petição 3", Content = "Conteúdo da Petição 3" }
        };

        // GET: /petitions
        [HttpGet]
        public IActionResult GetPetitions()
        {
            return Ok(_petitions);
        }

        // GET: /petitions/{id}
        [HttpGet("{id}")]
        public IActionResult GetPetitionById(int id)
        {
            var petition = FindPetitionById(id);
            if (petition == null)
            {
                return NotFound();
            }
            return Ok(petition);
        }

        // Método auxiliar para encontrar uma petição pelo ID
        private Petition FindPetitionById(int id)
        {
            foreach (var petition in _petitions)
            {
                if (petition.Id == id)
                {
                    return petition;
                }
            }
            return null;
        }
    }
}
