
using Domain.Entities;
using Microsoft.EntityFrameworkCore ;


namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options){

    }

   public DbSet<User> users {get;set;}
   public DbSet<ToDo> toDos {get;set;}
   public DbSet<Comment> comments {get;set;}
   public DbSet<Category> categories {get;set;}


  


}
