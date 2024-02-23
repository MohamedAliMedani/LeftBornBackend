using LeftBornDemoo.Src.Enum;
using MediatR;
using Src.GenericRepo;
using Src.Helpers;

namespace LeftBornDemoo.Src.Features.Product.DeleteProduct
{
    public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand, ResponseDTO>
    {
        private readonly ResponseDTO _responseDTO;
        public long _loggedInUserId;
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        private readonly IGRepository<Models.Product>_productRepository;

        public DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger,IGRepository<Models.Product>productRepository)
        {
            _responseDTO = new ResponseDTO();
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<ResponseDTO> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
             
                var product = _productRepository.GetFirst(x => x.Id == command.Id && x.State == State.NotDeleted);

                if (product == null) {
                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.FailedToFindTheObject;
                _responseDTO.Message = "FaildToFindObject"; 
                return _responseDTO;
                }

                product.State = State.Deleted;

                _productRepository.Update(product);
                _productRepository.Save();

                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.Success;
                _responseDTO.Message = "productDeletedSuccessfully";

            }
            catch (Exception ex)
            {
                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.Exception;
                _responseDTO.Message = "anErrorOccurredPleaseContactSystemAdministrator";
                _logger.LogError(ex, ex.Message, (ex != null && ex.InnerException != null ? ex.InnerException.Message : ""));

            }
            return _responseDTO;
        }

    }
}
