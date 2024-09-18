using CashFlow3.Communication.Responses;
using CashFlow3.Exception;
using CashFlow3.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow3.Api.Filters;

// Agora toda exceção que acontecer no código(por exemplo um throw) sempre vai ser redirecionado para o método
// OnException, e é dentro dessa função que eu vou escrever o que acontece quando uma exceção acontece

// "ExceptionContext" é uma classe que contém informações sobre a exceção que foi lançada e o contexto em que 
// aconteceu durante o processameno de uma requisição.
//"context" é o nome da variável que você pode usar dentro do método para acessar essas informações.

// O objeto "context" contém a exceção que foi lançada, então você pode acessá-la usando "context.Exception",
// isso permite que você saiba exatamente qual erro aconteceu.
// Ele também inclui detalhes sobre a requisição HTTP que estava sendo processada quando a exceção ocorreu,
// como o controller e a action que estavam sendo executados.
// Você pode usar context para modificar a resposta que será enviada ao cliente, por exemplo,
// retornando uma mensagem de erro personalizada.

// Quando o método OnException é chamado, o ASP.NET Core fornece automaticamente o ExceptionContext, que contém
// tudo o que você precisa para entender e manipular a exceção que ocorreu. Com ele, você pode decidir como a
// exceção será tratada, como registrar um log da exceção ou retornar uma resposta específica para o cliente,
// sem precisar de muitos blocos try-catch no seu código.
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {

        var cashFlowException = context.Exception as CashFlowException;
        var errorResponse = new ResponseErrorJson(cashFlowException!.GetErrors());

        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
