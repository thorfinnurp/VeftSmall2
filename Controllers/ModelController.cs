using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using template.Models;
using template.Data;
using System.Linq;
using System;

namespace template.Controllers
{
    [Route("api/models")]  
    public class ModelController : Controller
    {

        private readonly List<Model> _db = DataContext.Models;
        
        [HttpGet] 
        [Route("")]
        public IActionResult GetAllModels([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            Envelope<ModelDto> envelope = new Envelope<ModelDto>(); 

            int startId = 1 + (pageNumber-1) *  pageSize;
            int endId = startId + pageSize -1;
            
            IEnumerable<Model> pageItems = _db
                .Where( 
                    model   => startId <= model.Id 
                            && model.Id <= endId 
                );

            List<ModelDto> dtoList = new List<ModelDto>();
            foreach(Model value in pageItems) 
            {
                dtoList.Add(new ModelDto() {Id = value.Id, Name = value.Name, Race = value.Race, Price = value.Price });
            } 
            envelope.Items = dtoList;

            envelope.PageNumber = pageNumber;
            envelope.PageSize = pageSize;
            envelope.MaxPages = (int) Math.Ceiling(_db.Count() / (decimal) pageSize);

            return Ok(envelope);
        }

        [HttpGet("sas")] 
        public ModelsDetailsDTO GetModelById([FromQuery]int id)
        {
            Model thisModel = _db 
                            .Where( model => model.Id == id )
                            .Single();

            ModelsDetailsDTO ret = thisModel;
                                
            return ret;
        } 

    }
}