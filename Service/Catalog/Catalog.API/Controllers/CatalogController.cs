using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
   
    public class CatalogController : BaseApiController
    {
        private readonly IMediator mediator;

        public CatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Route("[action]/{id}", Name ="GetProductById")]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        [ProducesResponseType(440)]
        public async Task<IActionResult> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);

            var res = await mediator.Send(query);

            return Ok(res); 

        } 
    }
}
