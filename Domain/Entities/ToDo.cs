using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class ToDo
{
    [Key]
  public int ToDoId {get;set;}
  [Required,MaxLength(50)] 
   public string Title { get; set; }
   [Required]
    public string Description { get; set; }
    [Required,MaxLength(50)]
    public string Deadline { get; set; }
    public DateTime CreatDate {get;set;}
    public DateTime  UpdateDate {get;set;}
    public int UserId {get;set;}
    public User User {get;set;}
    public int CategoryId {get;set;}
     public Category Category {get;set;}
     public List<Comment> comments {get;set;}
    

    public ToDo()
    {
        CreatDate = DateTime.UtcNow;
        UpdateDate = DateTime.UtcNow;
    }
    
}
