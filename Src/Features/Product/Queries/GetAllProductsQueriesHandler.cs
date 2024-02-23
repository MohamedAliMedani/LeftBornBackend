using LeftBornDemoo.Src.Enum;
using MediatR;
using Src.GenericRepo;
using Src.Helpers;

namespace LeftBornDemoo.Src.Features.Product.Queries
{
    public class GetAllProductsQueriesHanlder: IRequestHandler<GetAllProductsQueries, ResponseDTO>
    {
        private readonly ResponseDTO _responseDTO;
        public long _loggedInUserId;
        private readonly ILogger<GetAllProductsQueriesHanlder> _logger;
        private readonly IGRepository<Models.Product>_productRepository;

        public GetAllProductsQueriesHanlder(ILogger<GetAllProductsQueriesHanlder> logger,IGRepository<Models.Product>productRepository)
        {
            _responseDTO = new ResponseDTO();
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<ResponseDTO> Handle(GetAllProductsQueries queries, CancellationToken cancellationToken)
        {
            try
            {
                var products = _productRepository.GetAll(x => x.State == State.NotDeleted)
                                .Select(x => new { 
                                    Id = x.Id,
                                    Name = x.Name,
                                    Description = x.Description  
                                }).ToList();

                _responseDTO.Result = products;
                _responseDTO.StatusEnum = StatusEnum.Success;
                _responseDTO.Message = "productsRetrivedSuccessfully";

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
