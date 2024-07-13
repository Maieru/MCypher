using Encryption.Helper;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace MCypherWeb.Models
{
    public class EncryptionViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "O texto a ser criptografado é obrigatório.")]
        public required string PlainText { get; set; }

        [Required(ErrorMessage = "A chave de criptografia é obrigatória.")]
        public required string Key { get; set; }

        [Required(ErrorMessage = "O tipo de criptografia é obrigatório.")]
        public EnumEncryptionType EncryptionType { get; set; }

        public string? CipherText { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (EncryptionType)
            {
                case EnumEncryptionType.CeaserCipher:
                    if (!int.TryParse(Key, out _))
                        yield return new ValidationResult("Para o tipo de criptografia CeaserCipher, a chave deve ser um número inteiro.", new[] { nameof(Key) });

                    break;

                case EnumEncryptionType.VigenereCipher:
                    if (Key.Any(c => c != ' ' && !char.IsLetter(c)))
                        yield return new ValidationResult("Para o tipo de criptografia VigenereCipher, a chave deve conter apenas letras.", new[] { nameof(Key) });

                    if (PlainText.Any(c => c != ' ' && !char.IsLetter(c)))
                        yield return new ValidationResult("Para o tipo de criptografia VigenereCipher, o texto deve conter apenas letras.", new[] { nameof(PlainText) });

                    break;
            }
        }
    }
}
