using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{ [Key]
    public int CategoryId {get;set;}
    [Required,MaxLength(30)]
    public string Name {get;set;}
  public List<ToDo> toDos {get;set;}

}
