using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using template.Models;
using template.Data;
using System.Linq;

namespace template.Controllers
{
    public class ModelController : Controller
    {

        private readonly Model _model;

        private List<Model> _db = DataContext.Models;
        public ModelController(Model model)
        {
            _model = model;
        }
        public Envelope<ModelDto> GetAllModels(int pageNumber = 1, int pageSize = 10)
        {
            Envelope<ModelDto> ret = new Envelope<ModelDto>(); 

            ret.PageNumber = pageNumber;
            ret.PageSize = pageSize;

            int startId = pageNumber * pageSize;
            int endId = startId + pageSize;
            
            IEnumerable<Model> pageItems = _db
                .Where( 
                    model   => startId <= model.Id 
                            && model.Id <= endId 
                );

            foreach(ModelDto value in pageItems) 
            {
                ret.Items.Append(value);
            } 

            return ret;
        }
        public ModelsDetailsDTO GetModelById([FromQuery]int id)
        {
            Model thisModel = _db 
                            .Where( model => model.Id == id )
                            .Single();

            ModelsDetailsDTO ret = new ModelsDetailsDTO(thisModel);
                                
            return ret;
        } 

    }
}