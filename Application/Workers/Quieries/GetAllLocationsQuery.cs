using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigmade.Domain;
using Sigmade.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sigmade.Application.Workers.Quieries
{
    public class GetAllLocationsQuery : IRequest<List<WorkLocation>>
    {
    }

    public sealed class Handler : IRequestHandler<GetAllLocationsQuery, List<WorkLocation>>
    {
        private readonly ApplicationDbContext _db;

        public Handler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<WorkLocation>> Handle(GetAllLocationsQuery requesr, CancellationToken cancellationToken)
        {
            var locations = await _db.WorkLocations.ToListAsync(cancellationToken);

            return locations;
        }
    }
}
