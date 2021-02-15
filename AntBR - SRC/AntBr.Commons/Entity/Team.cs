using System;
using System.Collections.Generic;
using System.Text;

namespace AntBr.Commons.Entity
{
    /// <summary>
    /// Classe que representa a entidade time.
    /// </summary>
    public class Team : ITeam
    {
        /// <summary>
        /// Variável privada que armazena o id.
        /// </summary>
        private int id;
        /// <summary>
        /// Variável privada que armazena o nome.
        /// </summary>
        private string name;
        /// <summary>
        /// Variável privada que armazena a cidade.
        /// </summary>
        private string city;
        /// <summary>
        /// Variável privada que armazena o estado.
        /// </summary>
        private string state;
        /// <summary>
        /// Variável privada que armazena o ícone.
        /// </summary>
        private string icon;

        /// <summary>
        /// Construtor da classe time. Inicializa variaveis.
        /// </summary>
        /// <param name="id">Identificador do time no sistema.</param>
        /// <param name="name">Nome do time.</param>
        /// <param name="city">Cidade do time.</param>
        /// <param name="state">Estado do time.</param>
        public Team(int id, string name, string city, string state, string icon)
        {
            // Inicia variáveis privadas 
            this.id = id;
            this.name = name;
            this.city = city;
            this.state = state;
            this.icon = icon;
        }

        #region ITeam Members
        
        /// <summary>
        /// Propriedade que acessa o identificador do time no sistema.
        /// </summary>
        public int ID
        {
            get { return id; }
        }

        /// <summary>
        /// Propriedade que acessa o nome do time.
        /// </summary>
        public string NAME
        {
            get { return name; }
        }

        /// <summary>
        /// Propriedade que acessa a cidade do time.
        /// </summary>
        public string CITY
        {
            get { return city; }
        }

        /// <summary>
        /// Propriedade que acessa o estado do time.
        /// </summary>
        public string STATE
        {
            get { return state; }
        }

        /// <summary>
        /// Propriedade que acessa o ícone do time.
        /// </summary>
        public string ICON
        {
            get { return icon; }
        }

        #endregion
    }
}
