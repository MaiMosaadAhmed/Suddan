using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Application.Common.Models;

namespace SuddanApplication.Application.Officers.Queries.GetOfficerWithPagination;
public record GetOfficerWithPaginationQuery : IRequest<PaginatedList<OfficerBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetOfficerWithPaginationQueryHandler:IRequestHandler<GetOfficerWithPaginationQuery, PaginatedList<OfficerBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOfficerWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<OfficerBriefDto>> Handle(GetOfficerWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Officers
            .Where(x => x.Id == request.ListId)
            .OrderBy(x => x.Name)
            .ProjectTo<OfficerBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
