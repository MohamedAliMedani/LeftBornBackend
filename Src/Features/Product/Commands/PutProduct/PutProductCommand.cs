using MediatR;
using Src.Helpers;

namespace LeftBornDemoo.Src.Features.Product.Commands.PutProduct
{
    public class PutProductCommand:IRequest<ResponseDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
    }
}