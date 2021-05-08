using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TakeTeste.Models;
using TakeTeste.Service;

namespace TakeTeste.Controllers
{
    public class TakeController : Controller
    {

        private readonly ServiceRepository _repository;

        public TakeController(ServiceRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/take")]
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public List<ListViewModel> GetAll()
        {
            //buscar na api do github
            List<Take> take = _repository.GetAll();

           var mySelect =  MySelect.myselect(take);
           return mySelect;
        }
        
        [Route("v1/take/{id}")]
        [HttpGet]
        public ListViewModel GetById(int id)
        {
            var result = GetAll();

            return result
                .Where(x => x.TakeId == id).FirstOrDefault();

        }

    }
}
