using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using template.Models;
using template.Data;
using System.Linq;

namespace template.Controllers
{
    [Route("api/models")]  
    //[ApiController]
    public class ModelController : Controller
    {

        private readonly List<Model> _db = DataContext.Models;
        
        [HttpGet] 
        [Route("")]
        public IActionResult  GetAllModels(int pageNumber = 1, int pageSize = 10)
        {
            //check if query parameters are OK

            Envelope<ModelDto> envelope = new Envelope<ModelDto>(); 

            envelope.PageNumber = pageNumber;
            envelope.PageSize = pageSize;

            int startId = 3;
            int endId = 4;
            
            IEnumerable<Model> pageItems = _db
                .Where( 
                    model   => startId <= model.Id 
                            && model.Id <= endId 
                );

            List<ModelDto> dtoList = new List<ModelDto>();
            foreach(Model value in pageItems) 
            {
                /*ModelDto dtoValue = new ModelDto();
                dtoValue.Id = value.Id;
                dtoValue.Name = value.Name;
                dtoValue.Race = value.Race;
                dtoValue.Price = value.Price;*/

                dtoList.Add(new ModelDto() {Id = value.Id, Name = value.Name, Race = value.Race, Price = value.Price });
                //a.Add(dtoValue);
                //Enumerable.Append(a, dtoValue);
                //Enumerable.Append(envelope.Items, dtoValue);
            } 
            envelope.Items = dtoList;

            //return envelope;

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