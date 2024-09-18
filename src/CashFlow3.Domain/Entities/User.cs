using CashFlow3.Domain.Enums;

namespace CashFlow3.Domain.Entities;
public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid UserIdentifier { get; set; }
    //Toda vez que uma pessoa se registrar ou logar na nossa api, essa api vai gerar um token e devolver para a pessoa
    //que fez a chamada. E nas próximas requisições sempre vai estar enviando para gente esse token. Dentro desse token,
    //a gente precisa de uma informação muito importante, que é uma forma de identificar o usuário/usuária que é dona
    //do token. Assim a nossa api consegue saber, "AH, quem está criando essa despesa é o Welisson, o Willian etc"
    //Então precisamos colocar no token uma forma de identificar quem é o dono/dona do token.
    //Cuidado! Muitas apis colocam para identificar a pessoa por email, então o token é gerado com o email lá dentro,
    //e aí a api extrai esse email do token quando chega uma requisição e consegue identificar a pessoa. Mas isso pode
    //gerar um problema. Imagine que o usuário faça um login na aplicação e a gente pega esse token. Na próxima requisi
    //são que o aplicativo vai fazer na api, vai ser uma requisição para alterar o perfil de cadastro desse usuário, e
    //aí o usuário altera o Nome e o email, nesse caso o token vai permanecer o mesmo e daí, na próxima requisição
    //que vai por exemplo criar uma despesa, a api vao falar "Não, esse email não existe aqui não" e dará erro. Por isso
    //precisamo de um identificador único para o usuário/usuária, e independentemente do usuário/usuária trocar as info
    //rmações essa propriedade nunca será alterada. É esse identificador que vamos colocar dentro do JWT.
    public string Role { get; set; } = Roles.TEAM_MEMBER;
    //Nesse módulo vamos estar trabalhando com regras do tipo: "Olha, esse endpoint só pode ser chamado por pessoas"
    //que tenha função de Administrador ou esse endpoint qualquer pessoa pode chamar.
}
