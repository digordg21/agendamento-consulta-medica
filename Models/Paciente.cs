using System.ComponentModel.DataAnnotations;

namespace Models;

public class Paciente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres", MinimumLength = 2)]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [Phone(ErrorMessage = "Telefone inválido")]
    public required string Telefone { get; set; }

    // Navegação
    public List<Consulta> Consultas { get; set; } = new();
}