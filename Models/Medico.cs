using System.ComponentModel.DataAnnotations;

namespace Models;

public class Medico
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres", MinimumLength = 2)]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "A especialidade é obrigatória")]
    [StringLength(50, ErrorMessage = "A especialidade deve ter entre 2 e 50 caracteres", MinimumLength = 2)]
    public required string Especialidade { get; set; }

    // Navegação
    public List<Consulta> Consultas { get; set; } = new();
}