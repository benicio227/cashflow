using CashFlow3.Communication.Requests;
using CashFlow3.Exception;
using FluentValidation;

namespace CashFlow3.Application.UseCases.Expenses;
public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    //Por que Passar o Tipo?: Quando você passa RequestRegisterExpenseJson, você está dizendo que o validador
    //(RegisterExpenseValidator) vai ser responsável por validar instâncias dessa classe específica.
    //Isso permite que você defina regras de validação (como RuleFor(expense => expense.Title).NotEmpty()) que
    //sejam aplicáveis aos campos/propriedades de RequestRegisterExpenseJson.

    //Ao passar o RequestRegisterExpenseJson para dentro do AbstractValidator, estamos informando ao Fluent
    //Validation qual é o tipo de objeto que será validado por essa classe "RegisterExpenseValidator".

    //Acesso às Propriedades: Ao informar o tipo RequestRegisterExpenseJson, o FluentValidation sabe que pode
    //esperar propriedades como Title, Description, Date, etc. Isso permite que você escreva regras que validam
    //esses campos de maneira fácil e intuitiva.

    //expense: É um parâmetro que representa uma instância do tipo RequestRegisterExpenseJson.
    //Em outras palavras, é um nome temporário que você usa para referir-se ao objeto que está sendo validado

    //expense.Title: Refere-se à propriedade Title do objeto expense.
    //Isso significa que a regra de validação será aplicada ao campo Title desse objeto.

    //expense => expense.Title: Essa parte inteira é uma expressão lambda,
    //que basicamente diz: "para um objeto expense, pegue a propriedade Title."

    public ExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_FOR_BE_FUTURE);
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
        RuleFor(expense => expense.Tags).ForEach(rule =>
        {
            rule.IsInEnum().WithMessage(ResourceErrorMessages.TAG_TYPE_NOT_SUPPORTED);
        });
    }
}

