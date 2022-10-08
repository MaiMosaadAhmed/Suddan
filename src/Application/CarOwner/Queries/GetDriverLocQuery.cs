using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Application.Common.Models;

namespace SuddanApplication.Application.CarOwner.Queries;
public record GetDriverLocQuery : IRequest<PaginatedList<DriverPosResults>>
{
    public string UserId { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class DriverPosResults
{ 
    public int DriverId { get; set; }
    public string? Name { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public DateTime Created { get; set; }
}

public class GetDriverLocQueryHandler : IRequestHandler<GetDriverLocQuery, PaginatedList<DriverPosResults>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDriverLocQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DriverPosResults>> Handle(GetDriverLocQuery request, CancellationToken cancellationToken)
    {
        var objs = await _context.OwnerCars
                    .Where(x => x.UserId == request.UserId)
                    .SelectMany(s => s.Cars).SelectMany(s1 => s1.Drivers).SelectMany(s2 => s2.DriverPos).Select(s3 => new
                    {
                        s3.Driver,
                        s3.CreatedMob,
                        s3.X,
                        s3.Y
                    }
                    )
                    .ToListAsync();

        var obj2 =  objs.AsQueryable().GroupBy(g => g.Driver)
                    .Select(s => new DriverPosResults
                    {
                        DriverId = s.Key.Id,
                        Name = s.Key.Name,
                        X = s.Where(m => m.CreatedMob == s.Max(m1 => m1.CreatedMob)).FirstOrDefault().X,
                        Y = s.Where(m => m.CreatedMob == s.Max(m1 => m1.CreatedMob)).FirstOrDefault().Y,
                        Created = s.Max(m => m.CreatedMob),
                    }
                    ).ToList();
        var obj3 = obj2.AsQueryable()//.ProjectTo<DriverPosResults>(_mapper.ConfigurationProvider)
                    .PaginatedListsync(request.PageNumber, request.PageSize);
        //return await obj3
        //            .PaginatedListAsync(request.PageNumber, request.PageSize)
        //         ;
        return obj3;
        //return await _context.Drivers
        //    .Where(x => x.Id == request.OwnerId)
        //    .Select(s=>s.DriverPos)
        //    //.OrderBy(x => x.Name)
        //    .ProjectTo<DriverPos>(_mapper.ConfigurationProvider)
        //    .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
