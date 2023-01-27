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

public class CommentController : ControllerBase
{

    private readonly CommentServise _commentServise;

    public CommentController(CommentServise commentServise)
    {
        _commentServise = commentServise;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetCommentDto>>> Gett()
    {
        return await _commentServise.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddCommentDto>> Addd(AddCommentDto c)
    {
        if (ModelState.IsValid)
        {
            return await _commentServise.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCommentDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddCommentDto>> Updatee(AddCommentDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _commentServise.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCommentDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetCommentDto>>  Deletee(int id)
    {
       return await _commentServise.Delete(id);
    
}

}




