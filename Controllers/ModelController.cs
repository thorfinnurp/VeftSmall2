using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using template.Models;
using template.Data;
using System.Linq;

namespace template.Controllers
{
    [Route("api/model")]  
    //[ApiController]
    public class ModelController : Controller
    {

        private readonly Model _model;

        private List<Model> _db = DataContext.Models;
        
        [HttpGet] 
        [Route("")]
        public Envelope<ModelDto> /*IActionResult*/  GetAllModels(int pageNumber = 1, int pageSize = 10)
        {
            Envelope<ModelDto> ret = new Envelope<ModelDto>(); 

            ret.PageNumber = pageNumber;
            ret.PageSize = pageSize;

            int startId = 3;
            int endId = 4;
            
            IEnumerable<Model> pageItems = _db
                .Where( 
                    model   => startId <= model.Id 
                            && model.Id <= endId 
                );

            foreach(Model value in pageItems) 
            {
                ModelDto(value);
                //ret.Items.Append(value);
            } 

            return ret;

            //return Ok();
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