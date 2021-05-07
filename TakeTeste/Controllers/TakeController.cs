using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            //cria uma lista vasia
            List<ListViewModel> mySelect = new List<ListViewModel>();
            
            //ordena o resultado por data de criaçao de forma ascemding
            var orderingQuery =
                from takeSelect in take
                orderby takeSelect.created_at ascending 
                select takeSelect;

            
            int Id = 1;
            foreach (var items in orderingQuery)
            {

                //inicia cada item da lista vasia com os item da consulta
                var Item = new ListViewModel[]
                {
                  new ListViewModel  {TakeId = Id, name = items.name, id = items.id, full_name = items.full_name, created_at = items.created_at,
                    description = items.description, avatar_url = items.owner.avatar_url},
                };

                //adiciona na lista vasia os item da consulta em orden por data
                foreach (ListViewModel r in Item)
                {
                    mySelect.Add(r);
                }

                Id++;
            }
            
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
