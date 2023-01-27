using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class UserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<UserLoginDto>>> Get()
    {
        try
        {
            var result = await _context.users.ToListAsync();
            var mapped = _mapper.Map<List<UserLoginDto>>(result);
            return new Response<List<UserLoginDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<UserLoginDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<List<string>>> Login(int model)
    {
        try
        { var existingStudent =await _context.users.Where(x=>x.Password == model).FirstOrDefaultAsync();
            if (existingStudent!=null)
            {
                   var result = await _context.users.ToListAsync();
            var mapped = _mapper.Map<List<UserLoginDto>>(result);
            return new Response<List<string>>( new List<string>() { $"{model} Password  vujud dorad" });
            }
            else
            {
       return new Response<List<string>>(HttpStatusCode.BadRequest,  new List<string>() { $"{model} Password  vujud Nadora" }); 
  
            }
         
        }
        catch (Exception e)
        {
            return new Response<List<string>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<UserRegisterDto>> Add(UserRegisterDto model)
    {
        try
        {
              var existingStudent = _context.users.Where(x =>x.UserId != model.UserId   && x.Password == model.Password).FirstOrDefault();
            if (existingStudent == null)
            {
                 var mapped = _mapper.Map<User>(model);
            await _context.users.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<UserRegisterDto>(model);
            }
           
            return new Response<UserRegisterDto>(HttpStatusCode.BadRequest,
                    new List<string>());
        }
        catch (Exception e)
        {
            return  new Response<UserRegisterDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<UserRegisterDto>> Update(UserRegisterDto model)
    {

        try
        {
          
            var update =await _context.users.Where(x=>x.UserId == model.UserId && x.Password != model.Password).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<User>(model);
                _context.users.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<UserRegisterDto>(model);
               
               
            }
            else
            {
                return new Response<UserRegisterDto>(HttpStatusCode.BadRequest,new List<string>() { $"UserId ili Password vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<UserRegisterDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<UserLoginDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.users.Where(x=>x.UserId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<UserLoginDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<UserLoginDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<UserLoginDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}


