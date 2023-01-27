using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;


public class Comment
{
  [Key]
  public int CommentId {get;set;}
 public int UserId {get;set;}
 public User User {get;set;}
 public int ToDoId {get;set;}
 public ToDo ToDo {get;set;}
 [Required]
    public string Description { get; set; }

  
  
}
