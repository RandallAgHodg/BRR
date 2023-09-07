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
        internal static Error YouCanNotAddYourselfAsAClient => new Error("you_cant_add_yourself_as_a_client", "No puedes agregarte a ti mismo como un cliente.");
        internal static Error UserWithPropertyAlreadyExists(string name) => new Error("User_with_property_already_exists", $"Ya se encuentra un usuario con un {name} equivalente");
    }

    internal static class Houses
    {
        internal static Error HouseFieldIsRequired (string name) => new Error("field_required", $"El campo {name} es requerido");
        internal static Error FieldHasToBeAPositiveInteger(string fieldName) => new Error("field_has_to_be_positive", $"El campo {fieldName} no puede ser menor o igual a 0");
    }

    internal static class Agents
    {
        internal static Error AgentWithEmailAlreadyExists => new Error("agent_email_exists", "Ya existe un usuario con ese correo.");
    }
    internal static class Clients
    {
        internal static Error AgentWithEmailAlreadyExists => new Error("agent_email_exists", "Ya existe un usuario con ese correo.");
    }
}
