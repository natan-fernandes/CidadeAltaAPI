using System.ComponentModel;

// ReSharper disable UnusedMember.Global
namespace CidadeAlta.Domain.Enums;

public enum Status
{
    [Description("Obsoleto")]
    Obsolete = 1,

    [Description("Desaprovado")]
    Unapproved = 2,

    [Description("Aguardando aprovação")]
    WaitingForApproval = 3,

    [Description("Em vigor")]
    InForce = 4
}