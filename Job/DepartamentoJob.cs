using Quartz;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using WebApi.Model.Entities;
using System.Collections.Generic;
using WebApi.Model;
using System.Linq;
using WebApi.Data.Repository.Interfaces;

namespace WebApi.Job
{
    [DisallowConcurrentExecution]
    public class DepartamentoJob : IJob
    {
        private readonly IRepositorysOfTheUnitOfWork _repositorysOfTheUnitOfWork;

        private const string _urlDepartamento = "";
        public DepartamentoJob(IRepositorysOfTheUnitOfWork repositorysOfTheUnitOfWork)
        {
            _repositorysOfTheUnitOfWork = repositorysOfTheUnitOfWork;
        }
        public Task Execute(IJobExecutionContext context)
        {
            SincronizaDepartamento().Wait();
            return Task.CompletedTask;
        }

        public async Task SincronizaDepartamento()
        {
            try
            {
                var client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(_urlDepartamento);

                if (response.Content == null)
                {
                    return;
                }
                string responseBody = await response.Content.ReadAsStringAsync();

                var departamentoSinc = JsonSerializer.Deserialize<List<DepartamentoSincronizacao>>(responseBody);

                foreach (var item in departamentoSinc)
                {
                    var departamento = _repositorysOfTheUnitOfWork.Departamento.FindAllByCondition(d => d.IdSinc == item.id).First();
                    if (departamento == null)
                    {
                        departamento = new Departamento();
                    }
                    else if (departamento.Nome == item.nome)
                    {
                        continue;
                    }

                    departamento.IdSinc = item.id;
                    departamento.Nome = item.nome;

                    _repositorysOfTheUnitOfWork.Departamento.Create(departamento);
                    _repositorysOfTheUnitOfWork.save();
                }
            }
            catch 
            {

                throw;
            }
        }
    }
}
