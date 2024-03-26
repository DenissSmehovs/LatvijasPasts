using AutoMapper;
using LatvijasPasts.Core.Models;
using LatvijasPasts.UseCases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.UseCases.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CvRequestModel, PersonalData>()
                .ForMember(cv => cv.Id,
                options => options.Ignore());
        }
    }
}
