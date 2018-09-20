using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using template.Models;
using template.Data;
using System.Linq;
using System;
using template.Extensions;

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
            string languageFromHeader = Request.Headers["Accept-Language"];

            Envelope<ModelDto> envelope = new Envelope<ModelDto>(); 

            int startId = 1 + (pageNumber-1) *  pageSize;
            int endId = startId + pageSize -1;
            
            List<Model> pageItems = _db
                .Where( 
                    model   => startId <= model.Id 
                            && model.Id <= endId 
                ).ToList();

            List<ModelDto> dtoList = ListExtensions.ToLightWeight(pageItems, languageFromHeader);
            
            envelope.Items = dtoList;

            envelope.PageNumber = pageNumber;
            envelope.PageSize = pageSize;
            envelope.MaxPages = (int) Math.Ceiling(_db.Count() / (decimal) pageSize);

            return Ok(envelope);
        }

        [HttpGet]
        [Route("{id:int}")] 
        public IActionResult GetModelById( int id)
        {
            string languageFromHeader = Request.Headers["Accept-Language"];
            
            List<Model> detailItems = _db 
                            .Where( model => model.Id == id )
                            .ToList();
            List<ModelsDetailsDTO> dtoList = ListExtensions.ToDetails(detailItems, languageFromHeader);
            ModelsDetailsDTO ret = dtoList[0];

            string selfString = "models/" + ret.Id;
            ret.Links.Append(new KeyValuePair<string, object>("_self", selfString) );

            return Ok(ret);
        } 

    }
}