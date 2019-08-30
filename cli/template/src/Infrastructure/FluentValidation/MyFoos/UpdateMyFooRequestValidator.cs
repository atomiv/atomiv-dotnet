using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Cli.Core.Application.MyFoos.Requests;

namespace Optivem.Cli.Infrastructure.FluentValidation.MyFoos
{
    public class UpdateMyFooRequestValidator : BaseValidator<UpdateMyFooRequest>
    {
        public UpdateMyFooRequestValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}
