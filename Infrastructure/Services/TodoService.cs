using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class TodoService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TodoService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetToDoDto>>> Get()
    {
        try
        {
            var result = await _context.toDos.ToListAsync();
            var mapped = _mapper.Map<List<GetToDoDto>>(result);
            return new Response<List<GetToDoDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetToDoDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddTodoDto>> Add(AddTodoDto model)
    {
        try
        {
            var existingStudent =await _context.toDos.FirstOrDefaultAsync(x=>x.ToDoId != model.ToDoId);
            if (existingStudent != null)
            {
                var mapped = _mapper.Map<ToDo>(model);
            await _context.toDos.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddTodoDto>(model);
           
            }
                 return new Response<AddTodoDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Todo with such data already exists" });
        }
        catch (Exception e)
        {
            return  new Response<AddTodoDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<AddTodoDto>> Update(AddTodoDto model)
    {

        try
        {
          
            var update =await _context.toDos.Where(x=>x.ToDoId != model.ToDoId ).AsNoTracking().FirstOrDefaultAsync();
            if (update ==null)
            {
                var mapped = _mapper.Map<ToDo>(model);
                _context.toDos.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddTodoDto>(model);
               
               
            }
            else
            {
                return new Response<AddTodoDto>(HttpStatusCode.BadRequest,new List<string>() { $"TodoId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddTodoDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetToDoDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.toDos.Where(x=>x.ToDoId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetToDoDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetToDoDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetToDoDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}



