using LeftBornDemoo.Src.Features.Product.Commands.PostProduct;
using LeftBornDemoo.Src.Features.Product.Commands.PutProduct;
using LeftBornDemoo.Src.Features.Product.DeleteProduct;
using LeftBornDemoo.Src.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Src.Helpers;

namespace LeftBornDemoo.Src.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class ProductController:Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;
        private readonly ResponseDTO _response;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDTO();
            _logger = logger;
        }
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetProducts")]
        public async Task<ResponseDTO> GetProducts()
        {
            return await _mediator.Send(new GetAllProductsQueries());
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("PostProduct")]
        public async Task<ResponseDTO> PostProduct([FromBody] PostProductCommand content)
        {
            return await _mediator.Send(content);
        }
        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("PutProduct/{id}")]
        public async Task<ResponseDTO> PutProduct([FromBody] PutProductCommand content,long id)
        {
            content.Id = id;
            return await _mediator.Send(content);
        }
        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("DeleteProduct/{id}")]
        public async Task<ResponseDTO> DeleteProduct([FromBody] DeleteProductCommand content,long id)
        {
            content.Id = id;
            return await _mediator.Send(content);
        }
    }
}