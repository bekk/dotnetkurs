using System.Collections.Generic;
using System.Web.Http;
using Bekk.dotnetintro.WebApi.Persons.Models;
using Bekk.dotnetintro.WebApi.Persons.Repositories;

namespace Bekk.dotnetintro.WebApi.Persons.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> Get()
        {
            return _repository.Get();
        }
    }
}
