using CashFlow3.Domain.Enums;

namespace CashFlow3.Domain.Entities;

// Expense é uma classe chamada de Entidade. Ela é um "espelho" da tabela no banco para que você possa trabalhar
// com os dados de forma mais estruturada e segura dentro da sua aplicação.
// Porque criar uma entidade: Frameworks como Entity Framework usam essas entidades para MAPEAR AS TABELAS DO
// BANCO DE DADOS automaticamente. Isso permite criar consultas, inserir, atualizar e deletar registros no
// banco de forma mais intuitiva e com menos código.
// As entidades permitem que você trabalhe com os dados sem se preocupar diretamente com as complexidades de
// SQL e do banco de dados, proporcionando uma abstração que torna o desenvolvimento mais ágil e menos propenso
// a erros.
// obs: A entidade precisa ter o mesmo tipo e nome lá do banco de dados, exatamante igual.
// obs: Com essa entidade Expense a gentte preenche as propriedades para salvar no banco de dados. Quando formos
// recuperar essas informações do banco de dados, o .NET já vai converter e colocar os valores nas propriedades
// corretas.
public class Expense
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }

    public ICollection<Tag> Tags { get; set; } = [];
    public long UserId { get; set; }
    public User User { get; set; } = default!; //Estou dizendo ao .NET que essa classe não vai ser nula
}
