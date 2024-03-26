using LatvijasPasts.Core.Services;
using LatvijasPasts.UseCases.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.UseCases.LatvijasPastsCRUD.DeleteCV
{
    public class DeleteCvCommandHandler : IRequestHandler<DeleteCvCommand, ServiceResult>
    {
        public readonly ICvService _cvService;

        public DeleteCvCommandHandler(ICvService cvService)
        {
            _cvService = cvService;
        }

        public Task<ServiceResult> Handle(DeleteCvCommand request, CancellationToken cancellationToken)
        {
            var personalData = _cvService.GetCompleteCvData(request.Id);
            _cvService.Delete(personalData);

            return Task.FromResult(new ServiceResult());
        }
    }
}
