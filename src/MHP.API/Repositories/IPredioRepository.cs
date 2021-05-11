using MHP.API.DTO;
using MHP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHP.API.Repositories
{
    public interface IPredioRepository
    {
        //Task<Predio> Add(Predio entity);
        Task<List<int>> andarMenosUtilizado();

        Task<List<char>> elevadorMaisFrequentado();

        Task<List<PeriodoMaiorFluxoElevadorMaisFrequentado>> periodoMaiorFluxoElevadorMaisFrequentado();
       

        Task<List<char>> elevadorMenosFrequentado();

        Task<List<PeriodoMenorFluxoElevadorMenosFrequentado>> periodoMenorFluxoElevadorMenosFrequentado();

        Task<List<char>> periodoMaiorUtilizacaoConjuntoElevadores();

        Task<float> percentualDeUsoElevadorA();

        Task<float> percentualDeUsoElevadorB();

        Task<float> percentualDeUsoElevadorC();

        Task<float> percentualDeUsoElevadorD();

        Task<float> percentualDeUsoElevadorE();
    }
}
