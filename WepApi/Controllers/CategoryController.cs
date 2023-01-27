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

public class CategoryController : ControllerBase
{

    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetCategoryDto>>> Gett()
    {
        return await _categoryService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddCategoryDto>> Addd(AddCategoryDto c)
    {
        if (ModelState.IsValid)
        {
            return await _categoryService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCategoryDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddCategoryDto>> Updatee( AddCategoryDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _categoryService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCategoryDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetCategoryDto>>  Deletee(int id)
    {
       return await _categoryService.Delete(id);
    
}

}


