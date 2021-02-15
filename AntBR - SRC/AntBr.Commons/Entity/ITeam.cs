using System;

namespace AntBr.Commons.Entity
{
    /// <summary>
    /// Interface que representa um time.
    /// </summary>
    public interface ITeam
    {
        /// <summary>
        /// Propriedade para obter o identificador do time.
        /// </summary>
        int ID
        {
            get;
        }

        /// <summary>
        /// Propriedade para obter o nome do time.
        /// </summary>
        string NAME
        {
            get;
        }

        /// <summary>
        /// Propriedade para obter a cidade do time.
        /// </summary>
        string CITY
        {
            get;
        }

        /// <summary>
        /// Propriedade para obter o estado do time.
        /// </summary>
        string STATE
        {
            get;
        }
        /// <summary>
        /// Propriedade para obter o ícone do time.
        /// </summary>
        string ICON
        {
            get;
        }
    }
}
