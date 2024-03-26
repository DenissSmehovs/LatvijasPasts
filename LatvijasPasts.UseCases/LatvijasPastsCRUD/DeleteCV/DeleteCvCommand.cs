using LatvijasPasts.UseCases.Models;
using MediatR;

namespace LatvijasPasts.UseCases.LatvijasPastsCRUD.DeleteCV
{
    public class DeleteCvCommand(int id) : IRequest<ServiceResult>
    {
        public int Id { get; set; } = id;
    }
}
