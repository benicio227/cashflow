﻿using CashFlow3.Communication.Enums;
using System.Reflection;

namespace CashFlow3.Communication.Responses;
public class ResponsesExpenseJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }

    public IList<Tag> Tags { get; set; } = [];

}
