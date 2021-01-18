using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CatalogueApp.Models;

namespace CatalogueApp.Controllers
{
    [Route("/api/Categories")]
    public class CategoryRestControler : Controller
    {
        //proporité
        public CatalogueDbRepository catalogueRepository { get; set; }
        //Constructeur
        public CategoryRestControler(CatalogueDbRepository repository)
        {
            this.catalogueRepository = repository;
        }
        [HttpGet]
        //Consulter une liste de catagegory

        public IEnumerable<Category> listCats()
        {
            return catalogueRepository.Categories;
        }
        //Consulter
        [HttpGet ("{Id}")]
        public Category getCat (int Id)
        {
            return catalogueRepository.Categories.FirstOrDefault(c=> c.CategoryID==Id);
        }



        [HttpPost]
        public Category Save([FromBody] Category category)
        {
            catalogueRepository.Categories.Add(category);
            catalogueRepository.SaveChanges();
            return category;
        }


        //mise à jour
        [HttpPost ("{Id}")]
        public Category Update([FromBody] Category category, int Id)
        {
            category.CategoryID = Id;
            catalogueRepository.Categories.Update(category);
            catalogueRepository.SaveChanges();
            return category;
        }
        //Delete
        [HttpDelete("{Id}")]
        public void Delete( int Id)
        {
       Category category= catalogueRepository.Categories.FirstOrDefault(c => c.CategoryID == Id);
            catalogueRepository.Remove(category);
            catalogueRepository.SaveChanges();    
        }


    }
}
