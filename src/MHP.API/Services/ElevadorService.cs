using MHP.API.DTO;
using MHP.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHP.API.Services
{
    public class ElevadorService : IElevadorService
    {

        private IPredioRepository _predioRepository;
     
        public ElevadorService(IPredioRepository predioRepository)
        {
            _predioRepository = predioRepository;         
        }

        public async Task<List<int>> andarMenosUtilizado()
        {
            return await _predioRepository.andarMenosUtilizado();
        }

        public async Task<List<char>> elevadorMaisFrequentado()
        {
            return await _predioRepository.elevadorMaisFrequentado();
        }

        public async Task<List<char>> elevadorMenosFrequentado()
        {
            return await _predioRepository.elevadorMenosFrequentado();
        }

        public async Task<float> percentualDeUsoElevadorA()
        {
            return await _predioRepository.percentualDeUsoElevadorA();
        }

        public async Task<float> percentualDeUsoElevadorB()
        {
            return await _predioRepository.percentualDeUsoElevadorB();
        }

        public async Task<float> percentualDeUsoElevadorC()
        {
            return await _predioRepository.percentualDeUsoElevadorC();
        }

        public async Task<float> percentualDeUsoElevadorD()
        {
            return await _predioRepository.percentualDeUsoElevadorD();
        }

        public async Task<float> percentualDeUsoElevadorE()
        {
            return await _predioRepository.percentualDeUsoElevadorE();
        }

        public async Task<List<PeriodoMaiorFluxoElevadorMaisFrequentado>> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            return await _predioRepository.periodoMaiorFluxoElevadorMaisFrequentado();
        }

        public async Task<List<char>> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            return await _predioRepository.periodoMaiorUtilizacaoConjuntoElevadores();
        }

        public async Task<List<PeriodoMenorFluxoElevadorMenosFrequentado>> periodoMenorFluxoElevadorMenosFrequentado()
        {
            return await _predioRepository.periodoMenorFluxoElevadorMenosFrequentado();
        }

        
    }
}
