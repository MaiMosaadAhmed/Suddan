using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.Common.Models;
using SuddanApplication.Application.Car.Queries.GetCarWithPagination;
using AutoMapper.QueryableExtensions;
using SuddanApplication.Application.Common.Mappings;

namespace SuddanApplication.Application.Car.Queries.GetCarWithPagination;
public record GetCarsWithPaginationQuery : IRequest<PaginatedList<CarBriefDto>>
{
    
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}


public class GetCarsWithPaginationQueryHandler : IRequestHandler<GetCarsWithPaginationQuery, PaginatedList<CarBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCarsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CarBriefDto>> Handle(GetCarsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cars
            .Where(x => x.Id == request.ListId)
            .OrderBy(x => x.CarPlateNumber)
            .ProjectTo<CarBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
