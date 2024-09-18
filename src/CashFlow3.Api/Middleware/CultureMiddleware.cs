using System.Globalization; //Importa as funcionalidades relacionadas à cultura, como formatação de datas e idiomas

namespace CashFlow3.Api.Middleware;

public class CultureMiddleware //Essa classe vai conter a lógica do Middleware
{
    private readonly RequestDelegate _next; //Isso permite que, após a lógica deste middleware ser executada,
    // a requisição continue para o próximo middleware

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        
        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();


        var cultureInfo = new CultureInfo("en");

        if(string.IsNullOrWhiteSpace(requestedCulture) == false
            && supportedLanguages.Exists(language => language.Name.Equals(requestedCulture)))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
