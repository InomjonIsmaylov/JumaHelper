using AutoMapper;
using JumaHelper.Server.Contexts;
using JumaHelper.Server.Models.DbSets;
using JumaHelper.Server.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace JumaHelper.Server.Controllers;

public class DuaRequestController(
    AppDbContext appDbContext,
    ILogger<DuaRequestController> logger,
    IMapper mapper
    ) : BaseController
{

    [HttpPut]
    public async Task<ActionResult<DuaRequestDto>> RequestForDua(DuaRequestDto request, CancellationToken ct)
    {
        if (request is not { Id: > 0 })
            throw new ArgumentException("request id must be not zero", nameof(request));

        try
        {
            var entity = mapper.Map<DuaRequest>(request);

            appDbContext.DuaRequests.Add(entity);

            await appDbContext.SaveChangesAsync(ct);

            request.Id = entity.Id;

            return Ok(request);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error occured");

            return BadRequest(e.Message);
        }
    }
}