using BRR.Domain.Primitives;

namespace BRR.Application.Core.Errors;

public static class ValidationErrors
{
    internal static class User
    {
        internal static Error UserFieldIsRequired (string name) => new Error("field_required", $"El campo {name} es requerido");
        internal static Error EmailInvalid => new Error("email_invalid", "El email presentado no presenta un formato de correo adecuado");
        internal static Error AgeHasBePositive => new Error("age_has_to_be_positive", "La edad del usuario no puede ser menor o igual a 0");
        internal static Error IdIsRequired => new Error("id_required", "Informacion de usuario no valida");
    }
}
