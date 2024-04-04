using AutoMapper;
using LatvijasPasts.Core.Models;
using LatvijasPasts.Core.Services;
using LatvijasPasts.UseCases.Models;
using MediatR;

namespace LatvijasPasts.UseCases.LatvijasPastsCRUD.AddCV
{
    public class AddCvCommandHandler : IRequestHandler<AddCvCommand, ServiceResult>
    {
        private readonly IEntityService<PersonalData> entityService;
        private readonly IMapper _mapper;

        public AddCvCommandHandler(IEntityService<PersonalData> entityService, IMapper mapper)
        {
            this.entityService = entityService;
            _mapper = mapper;
        }

        public async Task<ServiceResult> Handle(AddCvCommand request, CancellationToken cancellationToken)
        {
            ServiceResult result = new ServiceResult();

            var personalData = _mapper.Map<PersonalData>(request.RequestModel);

            if (personalData != null)
            {
                entityService.Create(personalData);
                result.Status = System.Net.HttpStatusCode.OK;

                return result;

            }

            result.Status = System.Net.HttpStatusCode.BadRequest;

            return result;
        }
    }
}
