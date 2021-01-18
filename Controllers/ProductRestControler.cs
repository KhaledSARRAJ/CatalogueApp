using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CatalogueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogueApp.Controllers
{
    [Route("/api/Products")]
    public class ProductRestControler : Controller
    {
        //proporité
        public CatalogueDbRepository catalogueRepository { get; set; }
        //Constructeur
        public ProductRestControler(CatalogueDbRepository repository)
        {
            this.catalogueRepository = repository;
        }
        [HttpGet]
        //Consulter une liste de catagegory

        public IEnumerable<Product> finAll()
        {
            return catalogueRepository.Products.Include(p => p.Category);
        }
                //Consulter
        [HttpGet("{Id}")]
        public Product getOne (int Id)
        {
            return catalogueRepository.Products.Include(p => p.Category).FirstOrDefault(p=> p.ProductID==Id);
        }



        [HttpPost]
        public Product Save([FromBody] Product p)
        {
            catalogueRepository.Products.Add(p);
            catalogueRepository.SaveChanges();
            return p;
        }


        //mise à jour
        [HttpPost ("{Id}")]
        public Product Update([FromBody] Product p, int Id)
        {
            p.ProductID = Id;
            catalogueRepository.Products.Update(p);
            catalogueRepository.SaveChanges();
            return p;
        }
        //Delete
        [HttpDelete("{Id}")]
        public void Delete( int Id)
        {
            Product p = catalogueRepository.Products.FirstOrDefault(p => p.ProductID == Id);
            catalogueRepository.Remove(p);
            catalogueRepository.SaveChanges();    
        }


    }
}
