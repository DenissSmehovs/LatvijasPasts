using AutoMapper;
using LatvijasPasts.Core.Models;
using LatvijasPasts.Core.Services;
using LatvijasPasts.UseCases.LatvijasPastsCRUD.GetAllCv;
using LatvijasPasts.UseCases.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.UseCases.LatvijasPastsCRUD.UpdateCV
{
    public class UpdateCvCommandHandler : IRequestHandler<UpdateCvCommand, ServiceResult>
    {
        public readonly ICvService _cvService;
        public readonly IMapper _mapper;
        public readonly IEntityService<Education> _entityServiceEdu;
        public readonly IEntityService<WorkExperience> _entityServiceWork;

        public UpdateCvCommandHandler(ICvService cvService, IMapper mapper, IEntityService<Education> entityServiceEdu, IEntityService<WorkExperience> entityServiceWork)
        {
            _cvService = cvService;
            _mapper = mapper;
            _entityServiceEdu = entityServiceEdu;
            _entityServiceWork = entityServiceWork;
        }



        public Task<ServiceResult> Handle(UpdateCvCommand request, CancellationToken cancellationToken)
        {
            var check = _mapper.Map<PersonalData>(request.RequestModel);
            check.Id = request.Id;

            _cvService.Update(check);
            _entityServiceEdu.Update(check.Educations);
            _entityServiceWork.Update(check.WorkExperiences);

            return Task.FromResult(new ServiceResult());
        }
    }
}
