using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.DTO
{
    public class RegisterUserDTO 
    {
        /// <summary>
        /// Imię użytkownika
        /// </summary>
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko użytkownika
        /// </summary>
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string LastName { get; set; }

        /// <summary>
        /// E-mail użytkownika
        /// </summary>
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Email { get; set; }

        /// <summary>
        /// Hasło użytkownika
        /// </summary>
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Password { get; set; }

        /// <summary>
        /// Powtórzone hasło użytkownika
        /// </summary>
        [Required(ErrorMessage = "To pole jest wymagane")]
        [Compare("Password", ErrorMessage = "Hasła nie pasują do siebie")]
        public string PasswordConfirmation { get; set; }
    }
}
