using FluentValidation;
using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Validators
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do aluno precisa ser informado");

            RuleFor(x => x.Usuario)
                .NotEmpty()
                .WithMessage("O usuário do aluno precisa ser informado");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("A senha do aluno precisa ser informada");

            RuleFor(x => x)
                .Must((x) => {
                    return x.IsAPasswordStrong();
                })
                .WithMessage("Uma senha forte deve ser informada. A senha deve conter no mínimo 6 caracteres. Letras maiúsculas, letras minúsculas, caracteres especiais e dígitos");
        }
    }
}
