using FluentValidation;
using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Validators
{
    public class TurmaValidator : AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso id precisa ser informado");

            RuleFor(x => x.TurmaNome)
                .NotEmpty()
                .WithMessage("O nome da turma precisa ser informado");

            RuleFor(x => x.Ano)
                .NotEmpty()
                .WithMessage("O ano da turma precisa ser informado")
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("O ano não pode ser anterior ao ano atual."); ;
        }
    }
}
