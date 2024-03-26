using LatvijasPasts.UseCases.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.UseCases.LatvijasPastsCRUD.UpdateCV
{
    public class UpdateCvCommand : IRequest<ServiceResult>
    {
        public CvRequestModel RequestModel { get; set; }
        public int Id { get; set; }
    }
}
