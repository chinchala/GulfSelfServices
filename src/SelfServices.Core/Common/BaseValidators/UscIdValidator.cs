using FluentValidation.Validators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Common.BaseValidators
{
    public class UscIdValidator : PropertyValidator
    {
        private readonly IValidationRepository _repository;
        public UscIdValidator(IValidationRepository repository): base("UscId is not valid")
        {
            _repository = repository;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var rfid = context.PropertyValue as string;
            return _repository.ValidateUscIdAsync(rfid).GetAwaiter().GetResult();
        }
    }
}