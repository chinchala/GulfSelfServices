using System.Threading.Tasks;
using FluentValidation.Validators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Common.BaseValidators
{
    public class RfIdValidator : PropertyValidator
    {
        private readonly IValidationRepository _repository;
        private readonly int _type;
        public RfIdValidator(IValidationRepository repository,int type): base("RfId is not valid")
        {
            _repository = repository;
            _type = type;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var rfid = context.PropertyValue as string;
            return _repository.ValidateRfidAsync(rfid,_type).GetAwaiter().GetResult();
        }
    }
}