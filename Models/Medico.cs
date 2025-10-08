namespace Models;

public class Medico
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Especialidade { get; set; }

    // Navegação
    public List<Consulta> Consultas { get; set; }
}