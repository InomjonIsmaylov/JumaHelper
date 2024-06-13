using AutoMapper;
using AutoMapper.QueryableExtensions;
using JumaHelper.Server.Contexts;
using JumaHelper.Server.Models.DbSets;
using JumaHelper.Server.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace JumaHelper.Server.Controllers;

public class DuaTypeController(
    AppDbContext appDbContext,
    ILogger<DuaRequestController> logger,
    IMapper mapper
    ) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<DuaRequestTypeDto>>> ReturnAll(CancellationToken ct)
    {
        var query = appDbContext.DuaRequestTypes
            .AsNoTracking()
            .ProjectTo<DuaRequestTypeDto>(mapper.ConfigurationProvider);

        var queryString = query.ToQueryString();

        logger.LogDebug("logging sql query: {query}", queryString);

        var all = await query
            .ToListAsync(ct);

        return all;
    }

    [HttpPut]
    public async Task<ActionResult<DuaRequestTypeDto>> CreateNewType(
        [FromBody] string name,
        CancellationToken ct)
    {
        if (string.IsNullOrEmpty(name))
            return BadRequest("Dua type can not be empty");

        try
        {
            var newOne = new DuaRequestType
            {
                Name = name
            };

            appDbContext.DuaRequestTypes.Add(newOne);

            await appDbContext.SaveChangesAsync(ct);

            var mapped = mapper.Map<DuaRequestTypeDto>(newOne);

            return mapped;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error occured");

            return BadRequest(e.Message);
        }
    }
}