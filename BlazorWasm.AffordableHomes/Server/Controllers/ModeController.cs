using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWasm.AffordableHomes.Server.Repositories.ModeRepositories;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Reponses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWasm.AffordableHomes.Server.Controllers
{
    [Route("api/[controller]")]
    public class ModeController : Controller
    {
        private readonly IModeRepository modeRepository;

        public ModeController(IModeRepository modeRepository)
        {
            this.modeRepository = modeRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> AddMode(ModeDTO model)
        {
            if (model == null)
                return BadRequest(new Response() { Success = false, Message = "No content specified" });

            var result = await modeRepository.CreateMode(model);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ModeDTO>>> GetAllModes() => Ok(await modeRepository.GetAllModes());
    }
}

