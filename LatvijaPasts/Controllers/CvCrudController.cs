using LatvijaPasts.Extensions;
using LatvijasPasts.UseCases.LatvijasPastsCRUD.AddCV;
using LatvijasPasts.UseCases.LatvijasPastsCRUD.DeleteCV;
using LatvijasPasts.UseCases.LatvijasPastsCRUD.GetAllCv;
using LatvijasPasts.UseCases.LatvijasPastsCRUD.UpdateCV;
using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijaPasts.Controllers
{
    [ApiController]
    public class CrudController : Controller
    {
        private readonly IMediator _mediator;

        public CrudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("cv")]
        public async Task<IActionResult> GetAllCv()
        {
            return (await _mediator.Send(new GetAllCvQuery())).ToActionResult();
        }

        [HttpPost]
        [Route("cv")]
        public async Task<IActionResult> AddCv(CvRequestModel requestModel)
        {
            return (await _mediator.Send(new AddCvCommand { RequestModel = requestModel })).ToActionResult();
        }

        [HttpDelete]
        [Route("cv/{id}")]
        public async Task<IActionResult> DeleteCv(int id)
        {
            return (await _mediator.Send(new DeleteCvCommand(id))).ToActionResult();
        }

        [HttpPut]
        [Route("cv/{id}")]
        public async Task<IActionResult> UpdateCv(int id, [FromBody] CvRequestModel requestModel)
        {
            return (await _mediator.Send(new UpdateCvCommand { RequestModel = requestModel, Id = id })).ToActionResult();
        }
    }
}
