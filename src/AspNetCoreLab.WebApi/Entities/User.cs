using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLab.WebApi.Entities;

public class User
{
    [Required] public int Id { get; init; }

    [Required] public string Name { get; set; } = null!;
}