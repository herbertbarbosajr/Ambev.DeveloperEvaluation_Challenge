namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um Sale no sistema.
    /// </summary>
    public interface ISaleItem
    {
        /// <summary>
        /// Obtém o identificador único de Sale.
        /// </summary>
        /// <returns>O ID do Sale como uma string.</returns>
        public string Id { get; }

    }
}
