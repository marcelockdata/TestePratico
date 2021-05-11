using MHP.API.DTO;
using MHP.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MHP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredioController : ControllerBase
    {
        private  IElevadorService _elevadorService;

        public PredioController(IElevadorService elevadorService)
        {
            _elevadorService = elevadorService;
        }

        [Route("andarMenosUtilizado")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> andarMenosUtilizado()
        {
            try
            {
                var result = await _elevadorService.andarMenosUtilizado();

                return Ok(result);
            }
            catch
            {               
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("elevadorMaisFrequentado")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<char>>> elevadorMaisFrequentado()
        {
            try
            {
                var result = await _elevadorService.elevadorMaisFrequentado();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [Route("periodoMaiorFluxoElevadorMaisFrequentado")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodoMaiorFluxoElevadorMaisFrequentado>>> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            try
            {
                var result = await _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("elevadorMenosFrequentado")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<char>>> elevadorMenosFrequentado()
        {
            try
            {
                var result = await _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [Route("periodoMenorFluxoElevadorMenosFrequentado")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodoMenorFluxoElevadorMenosFrequentado>>> periodoMenorFluxoElevadorMenosFrequentado()
        {
            try
            {
                var result = await _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("periodoMaiorUtilizacaoConjuntoElevadores")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<char>>> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            try
            {
                var result = await _elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [Route("percentualDeUsoElevadorA")]
        [HttpGet]
        public async Task<ActionResult<float>> percentualDeUsoElevadorA()
        {
            try
            {
                var result = await _elevadorService.percentualDeUsoElevadorA();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("percentualDeUsoElevadorB")]
        [HttpGet]
        public async Task<ActionResult<float>> percentualDeUsoElevadorB()
        {
            try
            {
                var result = await _elevadorService.percentualDeUsoElevadorB();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("percentualDeUsoElevadorC")]
        [HttpGet]
        public async Task<ActionResult<float>> percentualDeUsoElevadorC()
        {
            try
            {
                var result = await _elevadorService.percentualDeUsoElevadorC();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("percentualDeUsoElevadorD")]
        [HttpGet]
        public async Task<ActionResult<float>> percentualDeUsoElevadorD()
        {
            try
            {
                var result = await _elevadorService.percentualDeUsoElevadorD();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("percentualDeUsoElevadorE")]
        [HttpGet]
        public async Task<ActionResult<float>> percentualDeUsoElevadorE()
        {
            try
            {
                var result = await _elevadorService.percentualDeUsoElevadorE();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
               // return StatusCode(500, "Internal server error");
            }

        }




    }
}
