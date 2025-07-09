using System.ComponentModel;
using System.Reflection;

namespace FreelancerMatch.Domain.Erros
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            // Pega o campo do enum (ex: ErroEntidade.HABILIDADE_INVALIDA)
            FieldInfo? field = value.GetType().GetField(value.ToString());

            if (field == null)
            {
                return value.ToString();
            }

            // Busca pelo atributo [Description] nesse campo
            DescriptionAttribute? attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            // Se encontrou o atributo, retorna sua descrição. Senão, retorna o nome do próprio enum.
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}