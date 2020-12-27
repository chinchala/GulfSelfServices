using System;
using FluentValidation.Validators;
using SelfServices.Core.Repositories;

namespace SelfServices.Core.Common.BaseValidators
{
    public class TransactionIdValidator : PropertyValidator
    {
        private readonly IValidationRepository _repository;
        public TransactionIdValidator(IValidationRepository repository): base("TransactionId is not valid")
        {
            _repository = repository;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (Int64.TryParse(context.PropertyValue.ToString(), out var fuelId))
                return _repository.ValidateTransactionIdAsync(fuelId).GetAwaiter().GetResult();
            return false;
        }
    }
}