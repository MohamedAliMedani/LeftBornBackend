using MediatR;
using Src.Helpers;

namespace LeftBornDemoo.Src.Features.Product.DeleteProduct
{
    public class DeleteProductCommand:IRequest<ResponseDTO>
    {
        public long Id { get; set; }
    }
}