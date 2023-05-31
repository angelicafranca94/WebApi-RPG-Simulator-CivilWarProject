using CivilWar.Web.Dto;
using CivilWar.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CivilWar.Web.Controllers;

[Route("api/battles")]
public class BattleController : ControllerBase
{
    protected ResponseDto _response;
    private readonly IBattleService _battleService;

    public BattleController(IBattleService battleService)
    {
        _battleService = battleService;
        _response = new ResponseDto();
    }

    [HttpGet]
    [Route("{hero1}/{hero2}")]
    public async Task<object> Get(int hero1, int hero2)
    {
        try
        {
            var response = await _battleService.BattleActionAsync(hero1, hero2);

            _response.Result = response;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
            Response.StatusCode = 500;
        }

        return _response;
    }

}
