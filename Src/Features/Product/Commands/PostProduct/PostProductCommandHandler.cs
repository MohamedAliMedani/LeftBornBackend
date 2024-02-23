using LeftBornDemoo.Src.Enum;
using MediatR;
using Src.GenericRepo;
using Src.Helpers;

namespace LeftBornDemoo.Src.Features.Product.Commands.PostProduct
{
    public class PostProductCommandHandler: IRequestHandler<PostProductCommand, ResponseDTO>
    {
        private readonly ResponseDTO _responseDTO;
        public long _loggedInUserId;
        private readonly ILogger<PostProductCommandHandler> _logger;
        private readonly IGRepository<Models.Product>_productRepository;

        public PostProductCommandHandler(ILogger<PostProductCommandHandler> logger,IGRepository<Models.Product>productRepository)
        {
            _responseDTO = new ResponseDTO();
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<ResponseDTO> Handle(PostProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
             
                Models.Product product = new Models.Product();

                product.Name = command.Name;
                product.Description = command.Description;
                product.CreatedOn = DateTime.Now;
                product.State = State.NotDeleted;
            
                _productRepository.Add(product);
                _productRepository.Save();

                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.SavedSuccessfully;
                _responseDTO.Message = "productAddedSuccessfully";

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
