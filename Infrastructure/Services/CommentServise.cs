using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class CommentServise
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CommentServise(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetCommentDto>>> Get()
    {
        try
        {
            var result = await _context.comments.ToListAsync();
            var mapped = _mapper.Map<List<GetCommentDto>>(result);
            return new Response<List<GetCommentDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetCommentDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddCommentDto>> Add(AddCommentDto model)
    {
        try
        {
            var existingStudent =await _context.comments.FirstOrDefaultAsync(x=>x.CommentId != model.CommentId);
            if (existingStudent != null)
            {
                     var mapped = _mapper.Map<Comment>(model);
            await _context.comments.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddCommentDto>(model);
           
            }
        return new Response<AddCommentDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A User with such data already exists" });
        }
        catch (Exception e)
        {
            return  new Response<AddCommentDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<AddCommentDto>> Update(AddCommentDto model)
    {

        try
        {
          
            var update =await _context.comments.Where(x=>x.CommentId == model.CommentId ).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<Comment>(model);
                _context.comments.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddCommentDto>(model);
               
               
            }
            else
            {
                return new Response<AddCommentDto>(HttpStatusCode.BadRequest,new List<string>() { $"CommentID vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddCommentDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetCommentDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.comments.Where(x=>x.CommentId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetCommentDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetCommentDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetCommentDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}



