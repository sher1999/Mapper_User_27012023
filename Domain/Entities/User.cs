using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;


public class User
{
  [Key]
  public int UserId {get;set;}
  [Required,MaxLength(50)] 
   public string FirstName { get; set; }
    [Required,MaxLength(50)]
    public string LastName { get; set; }
    [Required,MaxLength(50)]
    public string Email { get; set; }
    [Required,MaxLength(15)]
     public string MobileNumber { get; set; }
    
     public int Password {get;set;}
 public List<Comment> comments {get;set;}
 public List<ToDo> toDos {get;set;}
     public User()
     {
        
     }

  }
