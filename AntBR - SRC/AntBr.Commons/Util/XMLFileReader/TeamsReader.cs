using System;
using System.IO;
using System.Xml;
using System.Collections;
using AntBr.Commons.Entity;

namespace AntBr.Commons.Util.XMLFileReader
{
	/// <summary>
	/// Classe que l� o arquivo XML que cont�m as descri��es dos times do campeonato.
	/// </summary>
	public class TeamsReader
	{
        /// <summary>
        /// Obt�m o diret�rio da aplica��o.
        /// </summary>
        private static string DIRECTORY = System.Environment.CurrentDirectory + "\\XML\\";
        /// <summary>
        /// Nome do arquivo xml de configura��o dos times.
        /// </summary>
        private const string FILE_NAME = "TeamsConfig.xml";
        /// <summary>
        /// String da tag xml que encapsula os times.
        /// </summary>
        private const string TEAMS = "teams";
        /// <summary>
        /// String da tag xml que encapsula um time.
        /// </summary>
		private const string TEAM = "team";
        /// <summary>
        /// String da tag xml raiz.
        /// </summary>
        private const string ROOT = "championship";
        /// <summary>
        /// String do atributo tag team que armazena o nome do time.
        /// </summary>
        private const string NAME = "name";
        /// <summary>
        /// String do atributo tag team que armazena a cidade do time.
        /// </summary>
        private const string CITY = "city";
        /// <summary>
        /// String do atributo tag team que armazena o estado do time.
        /// </summary>
        private const string STATE = "state";
		

		/// <summary>
		/// L� o xml de configura��o que cont�m os times do campeonato.
		/// </summary>
		/// <returns>ArrayList contendo todos os Times lidos do xml</returns>
		public static ArrayList getTeams()
		{
            // Inicializa a stream de leitura de dados do aquivo de configura��o.
			FileStream stream = File.OpenRead(DIRECTORY.Replace("\\bin\\Debug","") + @"\\" + FILE_NAME);
            // Iniciaiza o XMLReader, um reader especializado para documentos xml.
            XmlTextReader reader = new XmlTextReader(stream);
            // Inicializa o ArrayList que ir� armazenar os times contidos no xml.
            ArrayList teams = new ArrayList();
            
			try
			{
                //Varre os elementos xml em busca das informa��es sobre os times.
                while (reader.Read())
                {
                    // Verifica se achou a se��o descrita pela tag <teams>
                    if (reader.Name.Equals(TEAMS))
                    {
                        // Vari�vel utilizada para atribuir um identificador para o time no sistema.
                        int id = 0;
                        while (reader.Read())
                        {
                            // Verifica se achou a tag <team>
                            if (reader.Name.Equals(TEAM))
                            {
                                // Vai para o atributo nome.
                                reader.MoveToFirstAttribute();
                                // Atribui o valor a uma vari�vel tempor�ria.
                                string name = reader.Value;
                                // Vai para o atributo cidade.
                                reader.MoveToNextAttribute();
                                string city = reader.Value;
                                // Vai para o atributo estado.
                                reader.MoveToNextAttribute();
                                string state = reader.Value;
                                // Vai para o atributo icone.
                                reader.MoveToNextAttribute();
                                string icon = reader.Value;

                                // Cria um novo objeto do tipo Team, que respresenta a entidade time.
                                Team team = new Team(id++, name, city, state, icon);
                                // Adiciona o novo time ao array de times.
                                teams.Add(team);
                            }
                        }
                    }
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}

            // Fecha o XmlReader e stream.
			reader.Close();            
			stream.Close();

            // Retorna o arraylist com os times.
			return teams;
		}
	}
}
