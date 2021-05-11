using MHP.API.Data;
using MHP.API.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MHP.API.Repositories
{
    public class PredioRepository : IPredioRepository
    {
        protected ApplicationDbContext _context;
        private IConfiguration _config;
        public PredioRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        //public Task<Predio> Add(Predio entity)
        //{
        //    throw new NotImplementedException();
        //}
        public string GetConnection()
        {
            var connection = _config.GetSection("ConnectionStrings").GetSection("connectionDataBase").Value;
            return connection;
        }


        public async Task<List<int>> andarMenosUtilizado()
        {
            var result = new List<int>();
            StringBuilder query = new();
            query.Append("SELECT TOP 1 WITH TIES Andar, COUNT(*) AS Total    ");
            query.Append("FROM Predio                                        ");
            query.Append("GROUP BY Andar                                     ");
            query.Append("ORDER BY Andar                                     ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0));
                    }
                }
            }
            return result;
        }

        public async Task<List<char>> elevadorMaisFrequentado()
        {
            var result = new List<char>();
            StringBuilder query = new();
            query.Append("SELECT TOP 1 WITH TIES Elevador, COUNT(*) AS Total  ");
            query.Append("FROM Predio                                         ");
            query.Append("GROUP BY Elevador                                   ");
            query.Append("order by Total desc                                 ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                  
                    while (reader.Read())
                    {
                        
                        result.Add(reader.GetString(0)[0]);
                    }
                }
            }
            return result;
        }

        public async Task<List<PeriodoMaiorFluxoElevadorMaisFrequentado>> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var result = new List<PeriodoMaiorFluxoElevadorMaisFrequentado>();
            StringBuilder query = new();
            query.Append("SELECT TOP 1 WITH TIES Turno,Elevador,COUNT(*) AS Total     ");
            query.Append("FROM Predio                                                 ");
            query.Append("GROUP BY Turno,Elevador                                     ");
            query.Append("ORDER BY Total desc                                         ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    var entity = new PeriodoMaiorFluxoElevadorMaisFrequentado();
                    while (reader.Read())
                    {                       
                        entity.Turno = reader.GetString(0)[0];
                        entity.Elevador = reader.GetInt32(1);

                        result.Add(entity);

                    }
                }
            }
            return result;
        }

        public async Task<List<char>> elevadorMenosFrequentado()
        {
            var result = new List<char>();
            StringBuilder query = new();
            query.Append("SELECT TOP 1 WITH TIES Elevador, COUNT(*) AS Total    ");
            query.Append("FROM Predio                                           ");
            query.Append("GROUP BY Elevador                                     ");
            query.Append("ORDER BY Total                                        ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0)[0]);                       
                    }
                }
            }
            return result;
        }

        public async Task<List<PeriodoMenorFluxoElevadorMenosFrequentado>> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var result = new List<PeriodoMenorFluxoElevadorMenosFrequentado>();
            StringBuilder query = new();
            query.Append("SELECT TOP 1 WITH TIES Turno,Elevador,COUNT(*) AS Total     ");
            query.Append("FROM Predio                                                 ");
            query.Append("GROUP BY Turno,Elevador                                     ");
            query.Append("ORDER BY Total                                              ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    var entity = new PeriodoMenorFluxoElevadorMenosFrequentado();
                    while (reader.Read())
                    {

                        entity.Turno = reader.GetString(0)[0];
                        entity.Elevador = reader.GetInt32(1);

                        result.Add(entity);

                    }
                }
            }
            return result;
        }

        public async Task<List<char>> periodoMaiorUtilizacaoConjuntoElevadores()
        {

            var result = new List<char>();
            StringBuilder query = new();
            query.Append("SELECT TOP 1 WITH TIES Turno, COUNT(*) AS Total    ");
            query.Append("FROM Predio                                        ");
            query.Append("GROUP BY Turno                                     ");
            query.Append("ORDER BY Total  desc                               ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0)[0]);
                    }
                }
            }
            return result;
        }

        public async Task<float> percentualDeUsoElevadorA()
        {
            float result = 0;
            StringBuilder query = new();
            query.Append("select                                                                                                     ");
            query.Append("round((cast(count(1) as float) * 100.00) / (select cast(count(1) as float) from Predio),2) as Porcentagem  ");
            query.Append("from                                                                                                       ");
            query.Append("  Predio                                                                                                   ");
            query.Append("where Elevador = 'A'                                                                                       ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    result = (float)reader.GetDouble(0);
                }
            }
            return result;
        }

        public async Task<float> percentualDeUsoElevadorB()
        {
            float result = 0;
            StringBuilder query = new();
            query.Append("select                                                                                                     ");
            query.Append("round((cast(count(1) as float) * 100.00) / (select cast(count(1) as float) from Predio),2) as Porcentagem  ");
            query.Append("from                                                                                                       ");
            query.Append("  Predio                                                                                                   ");
            query.Append("where Elevador = 'B'                                                                                       ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    result = (float)reader.GetDouble(0);
                }
            }
            return result;
        }

        public async Task<float> percentualDeUsoElevadorC()
        {
            float result = 0;
            StringBuilder query = new();
            query.Append("select                                                                                                     ");
            query.Append("round((cast(count(1) as float) * 100.00) / (select cast(count(1) as float) from Predio),2) as Porcentagem  ");
            query.Append("from                                                                                                       ");
            query.Append("  Predio                                                                                                   ");
            query.Append("where Elevador = 'C'                                                                                       ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    result = (float)reader.GetDouble(0);
                }
            }
            return result;
        }

        public async Task<float> percentualDeUsoElevadorD()
        {
            float result = 0;
            StringBuilder query = new();
            query.Append("select                                                                                                     ");
            query.Append("round((cast(count(1) as float) * 100.00) / (select cast(count(1) as float) from Predio),2) as Porcentagem  ");
            query.Append("from                                                                                                       ");
            query.Append("  Predio                                                                                                   ");
            query.Append("where Elevador = 'D'                                                                                       ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    result = (float)reader.GetDouble(0);
                }
            }
            return result;
        }

        public async Task<float> percentualDeUsoElevadorE()
        {
            float result = 0;
            StringBuilder query = new();
            query.Append("select                                                                                                     ");
            query.Append("round((cast(count(1) as float) * 100.00) / (select cast(count(1) as float) from Predio),2) as Porcentagem  ");
            query.Append("from                                                                                                       ");
            query.Append("  Predio                                                                                                   ");
            query.Append("where Elevador = 'E'                                                                                       ");

            using (var connection = new SqlConnection(GetConnection()))
            {
                await connection.OpenAsync();

                using SqlCommand command = new(query.ToString(), connection);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    result = (float)reader.GetDouble(0);
                }
            }
            return result;
        }
    }
}
