using DapperTest.Models;
using FluentValidation;

namespace DapperTest.Validators
{
    public class CardParameterValidator : AbstractValidator<CardParameter>
    {
        /// <summary>
        /// 驗證器的建構式: 在這裡註冊我們要驗證的規則
        /// </summary>
        public CardParameterValidator() 
        {
            RuleFor(card => card.Attack).GreaterThanOrEqualTo(0)
                .WithName("攻擊力");

            RuleFor(card => card.Health).GreaterThanOrEqualTo(0);

            RuleFor(card => card.Cost).GreaterThanOrEqualTo(0);

            RuleFor(card => card.Description).NotNull().MaximumLength(30);

            RuleFor(card => card.Name).NotNull().MaximumLength(15);
        }
    }
}
