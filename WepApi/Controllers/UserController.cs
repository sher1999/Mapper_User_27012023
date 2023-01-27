using Domain.Entities;  
using Domain.Dto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;
namespace WepApi.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{

    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<UserLoginDto>>> Gett()
    {
        return await _userService.Get();
    }
    [HttpGet("Login")]
    public async Task<Response<List<string>>> Login(int Login)
    {
        return await _userService.Login(Login);
    }

    [HttpPost("Add")]
    public async Task<Response<UserRegisterDto>> Addd(UserRegisterDto c)
    {
        if (ModelState.IsValid)
        {
            return await _userService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<UserRegisterDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<UserRegisterDto>> Updatee( UserRegisterDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _userService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<UserRegisterDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<UserLoginDto>>  Deletee(int id)
    {
       return await _userService.Delete(id);
    
}

}

