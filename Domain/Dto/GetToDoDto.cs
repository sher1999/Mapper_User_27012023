using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

public class GetToDoDto
{
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

    public int CategoryId {get;set;}
  
    

    public GetToDoDto()
    {
        CreatDate = DateTime.UtcNow;
        UpdateDate = DateTime.UtcNow;
    }
}
