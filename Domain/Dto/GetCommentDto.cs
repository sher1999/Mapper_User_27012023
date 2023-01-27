using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

public class GetCommentDto
{
    
  public int CommentId {get;set;}
 public int UserId {get;set;}
 public int ToDoId {get;set;}
 [Required]
public string Description { get; set; }
}
