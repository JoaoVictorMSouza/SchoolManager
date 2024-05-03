using SchoolManager.Domain.Entities.Base;
using SchoolManager.Domain.Entities.Exception;
using SchoolManager.Domain.Interface.Utils;
using System.Text.RegularExpressions;

namespace SchoolManager.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Inativo { get; set; }

        public void Activate()
        {
            Inativo = false;
        }

        public void Inactivate()
        {
            Inativo = true;
        }

        public void SetPassword(IPasswordHasher passwordHasher)
        {
            Senha = passwordHasher.HashPassword(this.Senha);
        }

        public void CheckPassword(string password, IPasswordHasher passwordHasher)
        {
            if (!passwordHasher.VerifyPassword(Senha, password))
            {
                throw new CustomException("Senha inválida.");
            }
        }

        public void IsPasswordStrong()
        {
            Regex regex = new Regex("\\W");

            if (this.Senha.Length < 6
                || !this.Senha.Any(char.IsUpper)
                || !this.Senha.Any(char.IsLower)
                || !this.Senha.Any(char.IsDigit)
                || !regex.IsMatch(this.Senha))
            {
                throw new CustomException("Por favor, insira uma senha mais forte.");
            }
        }

        public bool IsAPasswordStrong()
        {
            Regex regex = new Regex("\\W");

            if (this.Senha.Length < 6
                || !this.Senha.Any(char.IsUpper)
                || !this.Senha.Any(char.IsLower)
                || !this.Senha.Any(char.IsDigit)
                || !regex.IsMatch(this.Senha))
            {
                return false;
            }

            return true;
        }
    }
}
