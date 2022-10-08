using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Application.Common.Models;

namespace SuddanApplication.Application.Nodes.Queries.GetNodesWithPagination;
public record GetNodesWithPaginationQuery : IRequest<PaginatedList<NodesBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetNodesWithPaginationQueryHandler : IRequestHandler<GetNodesWithPaginationQuery, PaginatedList<NodesBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNodesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<NodesBriefDto>> Handle(GetNodesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Nodes
            .Where(x => x.Id == request.ListId)
            .OrderBy(x => x.Name)
            .ProjectTo<NodesBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
