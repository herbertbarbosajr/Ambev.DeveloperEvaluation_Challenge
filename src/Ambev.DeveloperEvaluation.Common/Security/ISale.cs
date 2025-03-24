using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security;

/// <summary>
/// Define o contrato para representação de um Sale no sistema.
/// </summary>
public interface ISale
{
    /// <summary>
    /// Obtém o identificador único do Sale.
    /// </summary>
    /// <returns>O ID do Sale como uma string.</returns>
    public string Id { get; }


}
