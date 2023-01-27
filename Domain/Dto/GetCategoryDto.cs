using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

public class GetCategoryDto
{

    public int CategoryId {get;set;}
    [Required,MaxLength(30)]
    public string Name {get;set;}
 

}
