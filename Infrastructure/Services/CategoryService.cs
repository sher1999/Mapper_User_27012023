using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class CategoryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CategoryService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetCategoryDto>>> Get()
    {
        try
        {
            var result = await _context.categories.ToListAsync();
            var mapped = _mapper.Map<List<GetCategoryDto>>(result);
            return new Response<List<GetCategoryDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetCategoryDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddCategoryDto>> Add(AddCategoryDto model)
    {
        try
        {
           var existingStudent = _context.categories.Where(x => x.CategoryId == model.CategoryId).FirstOrDefault();
            if (existingStudent != null)
            {
              
            return new Response<AddCategoryDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A User with such data already exists" });
               
            }
                var mapped = _mapper.Map<Category>(model);
            await _context.categories.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddCategoryDto>(model);
           
        }
        catch (Exception e)
        {
            return  new Response<AddCategoryDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<AddCategoryDto>> Update(AddCategoryDto model)
    {

        try
        {
          
            var update =await _context.categories.Where(x=>x.CategoryId == model.CategoryId ).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<Category>(model);
                _context.categories.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddCategoryDto>(model);
               
               
            }
            else
            {
                return new Response<AddCategoryDto>(HttpStatusCode.BadRequest,new List<string>() { $"CategoryId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddCategoryDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetCategoryDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.categories.Where(x=>x.CategoryId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetCategoryDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetCategoryDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetCategoryDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}






