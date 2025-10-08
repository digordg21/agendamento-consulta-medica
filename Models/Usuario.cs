using Microsoft.AspNetCore.Identity;

namespace Models;

public class Usuario : IdentityUser
{
    // Propriedade personalizada para armazenar o nome completo do usuário
    public string FullName { get; set; } = string.Empty;

}