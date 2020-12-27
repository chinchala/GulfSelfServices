using System;
using FluentValidation.Validators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Common.BaseValidators
{
    public class FuelIdValidator : PropertyValidator
    {
        private readonly IValidationRepository _repository;
        public FuelIdValidator(IValidationRepository repository):base("FuelId is not valid")
        {
            _repository = repository;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (Int32.TryParse(context.PropertyValue.ToString(), out var fuelId))
                return _repository.ValidateFuelIdAsync(fuelId).GetAwaiter().GetResult();
            return false;
        }
    }
}