using System.Threading.Tasks;
using FluentValidation.Validators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Common.BaseValidators
{
    public class RfIdValidator : PropertyValidator
    {
        private readonly IValidationRepository _repository;
        public RfIdValidator(IValidationRepository repository): base("RfId is not valid")
        {
            _repository = repository;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var rfid = context.PropertyValue as string;
            return _repository.ValidateRfidAsync(rfid).GetAwaiter().GetResult();
        }
    }
}