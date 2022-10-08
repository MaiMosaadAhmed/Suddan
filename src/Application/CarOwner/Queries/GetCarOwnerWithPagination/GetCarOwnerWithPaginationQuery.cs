using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SuddanApplication.Application.CarOwner.Queries;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Application.Common.Models;

namespace SuddanApplication.Application.CarOwner.Queries;
public record GetCarOwnerWithPaginationQuery : IRequest<PaginatedList<CarOwnerBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetCarOwnerWithPaginationQuery, PaginatedList<CarOwnerBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CarOwnerBriefDto>> Handle(GetCarOwnerWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.OwnerCars
            .Where(x => x.Id >= request.ListId)
            .OrderBy(x => x.Name)
            .ProjectTo<CarOwnerBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
