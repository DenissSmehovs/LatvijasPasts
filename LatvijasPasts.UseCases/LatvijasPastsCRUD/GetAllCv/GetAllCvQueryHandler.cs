using LatvijasPasts.UseCases.Models;
using MediatR;
using LatvijasPasts.Core.Services;
using System.Net;
using LatvijasPasts.Core.Models;

namespace LatvijasPasts.UseCases.LatvijasPastsCRUD.GetAllCv
{
    public class GetAllCvQueryHandler : IRequestHandler<GetAllCvQuery, ServiceResult>
    {
        private readonly ICvService _cvService;

        public GetAllCvQueryHandler(ICvService cvService)
        {
            _cvService = cvService;
        }

        public async Task<ServiceResult> Handle(GetAllCvQuery request, CancellationToken cancellationToken)
        {
            
            var result = new ServiceResult();
            var listObj = _cvService.GetAllCvData();

            if (listObj != null)
            {
                result.Status = HttpStatusCode.OK;
                result.ResultObject = listObj;

                return result;
            }

            result.Status = HttpStatusCode.NotFound;

            return result;
        }
    }
}
