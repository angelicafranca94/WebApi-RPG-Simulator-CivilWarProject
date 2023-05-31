using CivilWar.Infra.Model.Dto;
using CivilWar.Infra.Repository.Interface;
using CivilWar.Web.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CivilWar.Web.Controllers;

[Route("api/heros")]
public class HeroController : ControllerBase
{
    protected ResponseDto _response;
    private readonly IHeroRepository _heroRepository;

    public HeroController(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<HeroDto> heroDtos = await _heroRepository.GetHeros();
            _response.Result = heroDtos;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            var heroDto = await _heroRepository.GetHeroById(id);
            _response.Result = heroDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] HeroDto heroDto)
    {
        try
        {
            var model = await _heroRepository.CreateUpdateHero(heroDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] HeroDto heroDto)
    {
        try
        {
            var model = await _heroRepository.CreateUpdateHero(heroDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _heroRepository.DeleteHero(id);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

}

