
using MediatR;
using Src.Helpers;

namespace LeftBornDemoo.Src.Features.Product.Commands.PostProduct
{
    public class PostProductCommand:IRequest<ResponseDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}