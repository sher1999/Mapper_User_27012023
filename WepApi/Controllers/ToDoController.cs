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

public class ToDoController : ControllerBase
{

    private readonly TodoService _todoService;

    public ToDoController(TodoService todoService)
    {
        _todoService = todoService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetToDoDto>>> Gett()
    {
        return await _todoService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddTodoDto>> Addd(AddTodoDto c)
    {
        if (ModelState.IsValid)
        {
            return await _todoService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddTodoDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddTodoDto>> Updatee( AddTodoDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _todoService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddTodoDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetToDoDto>>  Deletee(int id)
    {
       return await _todoService.Delete(id);
    
}

}


