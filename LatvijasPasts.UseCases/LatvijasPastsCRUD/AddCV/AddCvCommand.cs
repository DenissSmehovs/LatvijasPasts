using LatvijasPasts.Core.Models;
using LatvijasPasts.UseCases.Models;
using MediatR;

namespace LatvijasPasts.UseCases.LatvijasPastsCRUD.AddCV
{
    public class AddCvCommand : IRequest<ServiceResult>
    {
        public CvRequestModel RequestModel { get; set; }
    }
}
