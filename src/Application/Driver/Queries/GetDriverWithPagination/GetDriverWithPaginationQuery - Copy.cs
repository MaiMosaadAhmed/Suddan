using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Application.Common.Models;

namespace SuddanApplication.Application.Driver.Queries;
public record GetDriverWithPaginationQuery : IRequest<PaginatedList<DriverBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetDriverWithPaginationQueryHandler:IRequestHandler<GetDriverWithPaginationQuery, PaginatedList<DriverBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDriverWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DriverBriefDto>> Handle(GetDriverWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Drivers
            .Where(x => x.Id >= request.ListId)
            .OrderBy(x => x.Name)
            .ProjectTo<DriverBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
