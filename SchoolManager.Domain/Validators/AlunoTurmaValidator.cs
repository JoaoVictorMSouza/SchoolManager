

using FluentValidation;
using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Validators
{
    public class AlunoTurmaValidator : AbstractValidator<AlunoTurma>
    {
        public AlunoTurmaValidator()
        {
            RuleFor(x => x.AlunoId)
                .NotEmpty()
                .WithMessage("O id do aluno precisa ser informado");

            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("O id da turma precisa ser informado");
        }
    }
}
