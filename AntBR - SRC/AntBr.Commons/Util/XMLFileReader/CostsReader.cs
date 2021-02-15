using System;
using System.IO;
using System.Xml;
using System.Collections;
using AntBr.Commons.Entity;

namespace AntBr.Commons.Util.XMLFileReader
{
	/// <summary>
	/// Classe que l� o arquivo XML que cont�m os custos de viagem e esttadia
    /// das cidades-sede dos times do campeonato.
	/// </summary>
	public class CostsReader
	{
        /// <summary>
        /// Obt�m o diret�rio da aplica��o.
        /// </summary>
        private static string DIRECTORY = System.Environment.CurrentDirectory + "\\XML\\";
        /// <summary>
        /// Nome do arquivo xml de configura��o dos times.
        /// </summary>
        private const string FILE_NAME = "CostsTable1";
        /// <summary>
        /// String da tag xml raiz.
        /// </summary>
        private const string ROOT = "costs";
        /// <summary>
        /// String da tag xml que encapsula os fatores de multiplica��o.
        /// </summary>
        private const string FACTORS = "multiplication_factors";
        /// <summary>
        /// String da tag xml que armazena o fator de multiplica��o do pre�o da viagem.
        /// </summary>
        private const string TRIP_FACTOR = "trip_factor";
        /// <summary>
        /// String da tag xml que armazena o fator de multiplica��o do pre�o da estadia.
        /// </summary>
        private const string STAY_FACTOR = "stay_factor";
        /// <summary>
        /// String da tag xml que encapsula os custos relativos a uma determinada cidade.
        /// </summary>
        private const string CITY = "city";
        /// <summary>
        /// String da tag xml que encapsula os custos de viagem relativos a uma determinada cidade.
        /// </summary>
        private const string TRIP_COSTS = "trip_costs";
        /// <summary>
        /// String da tag xml que encapsula os custos de estadia relativos a uma determinada cidade.
        /// </summary>
        private const string STAY_COSTS = "stay_costs";
        /// <summary>
        /// String da tag xml que armazena o custo de viajar de uma determinada cidade a outra.
        /// </summary>
        private const string DESTINATION = "destination";

        
        /// <summary>
        /// L� do xml de configura��o os custos de viagem a sede de um determinado time
        /// e os outros.
        /// </summary>
        /// <param name="city">Cidade-sede de um time.</param>
        /// <returns>Uma tabela hash associado um trecho (origem-destino) ao seu custo.</returns>
		public static Hashtable getTripCosts(string city)
		{
            // Inicializa a stream de leitura de dados do aquivo de configura��o.
			FileStream stream = File.OpenRead(DIRECTORY.Replace("\\bin\\Debug","") + @"\\" + FILE_NAME);
            // Iniciaiza o XMLReader, um reader especializado para documentos xml.
            XmlTextReader reader = new XmlTextReader(stream);
            // Inicializa o hashtable que ir� armazenar os custos de viagem.
            Hashtable tripCosts = new Hashtable();
            
			try
			{
                //Varre os elementos xml em busca das informa��es sobre os custos.
                while (reader.Read())
                {
                    // Verifica se achou a se��o descrita pela tag <city>
                    if (reader.Name.Equals(CITY))
                    {
                        // Move o ponteiro para o atributo nome
                        reader.MoveToFirstAttribute();
                        // verifica se a cidade � a desejada.
                        if (reader.Value.Equals(city))
                        {
                            while (reader.Read())
                            {
                                // Verifica se achou a tag <destination>
                                if (reader.Name.Equals(DESTINATION))
                                {
                                    // Vai para o atributo nome.
                                    reader.MoveToFirstAttribute();
                                    // Atribui o valor a uma vari�vel tempor�ria.
                                    string destinationName = reader.Value;
                                    // Vai para o atributo valor.
                                    reader.MoveToNextAttribute();
                                    double cost = Double.Parse(reader.Value,System.Globalization.NumberStyles.AllowDecimalPoint);
                                    // Adiciona associa��o ao hashtable
                                    tripCosts.Add(city + "-" + destinationName, cost);
                                }
                                // Verifica se achou outr tag <city>.
                                if (reader.Name.Equals(CITY))
                                    // sai caso seja verdadeira a senten�a.
                                    break;
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
            // Retorna os custo.
			return tripCosts;
		}

        /// <summary>
        /// L� do xml de configura��o os custos de estadia da cidade-sede de um determinado time.
        /// </summary>
        /// <param name="city">Cidade-sede de um time.</param>
        /// <returns> Valor do custo de estadia</returns>
        public static double getStayCosts(string city)
        {
            // Inicializa a stream de leitura de dados do aquivo de configura��o.
            FileStream stream = File.OpenRead(DIRECTORY.Replace("\\bin\\Debug", "") + @"\\" + FILE_NAME);
            // Iniciaiza o XMLReader, um reader especializado para documentos xml.
            XmlTextReader reader = new XmlTextReader(stream);
            // Inicializa a vari�vel de retorno.
            Double stayCosts = 0.0;

            try
            {
                //Varre os elementos xml em busca das informa��es sobre os custos.
                while (reader.Read())
                {
                    // Verifica se achou a se��o descrita pela tag <city>
                    if (reader.Name.Equals(CITY))
                    {
                        // Move o ponteiro para o atributo nome
                        reader.MoveToFirstAttribute();
                        // verifica se a cidade � a desejada.
                        if (reader.Value.Equals(city))
                        {
                            while (reader.Read())
                            {
                                // Verifica se achou a tag <stay_costs>
                                if (reader.Name.Equals(STAY_COSTS))
                                {
                                    // Vai para o paramentro valor
                                    reader.MoveToFirstAttribute();
                                    // Atribui o valor a variavel de retorno.
                                    stayCosts = Double.Parse(reader.Value,System.Globalization.NumberStyles.AllowDecimalPoint);
                                    // sai do la�o.
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Fecha o XmlReader e stream.
            reader.Close();
            stream.Close();
            // retorna o custo de estadia.
            return stayCosts;
        }

        /// <summary>
        /// M�tiodo para obter o fator de multiplica��o do pre�o de viagem.
        /// </summary>
        /// <returns>Fator multiplicativo</returns>
        public static int getTripFactor()
        {
            // Inicializa a stream de leitura de dados do aquivo de configura��o.
            FileStream stream = File.OpenRead(DIRECTORY.Replace("\\bin\\Debug", "") + @"\\" + FILE_NAME);
            // Iniciaiza o XMLReader, um reader especializado para documentos xml.
            XmlTextReader reader = new XmlTextReader(stream);
            // Inicializa a vari�vel de retorno.
            int tripFactor = 1;
            
			try
			{
                //Varre os elementos xml em busca das informa��es sobre o fator de multiplica��o.
                while (reader.Read())
                {
                    // Verifica se achou a tag <trip_factor>
                    if (reader.Name.Equals(TRIP_FACTOR))
                    {
                        // Vai para o atributo valor.
                        reader.MoveToFirstAttribute();
                        // Atribui o valor a variavel de retorno.
                        tripFactor = Int32.Parse(reader.Value);
                        // Sai do la�o
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Fecha o XmlReader e stream.
            reader.Close();
            stream.Close();
            // retorna o custo de estadia.
			return tripFactor;
		}

        public static int getStayFactor()
        {
            // Inicializa a stream de leitura de dados do aquivo de configura��o.
            FileStream stream = File.OpenRead(DIRECTORY.Replace("\\bin\\Debug", "") + @"\\" + FILE_NAME);
            // Iniciaiza o XMLReader, um reader especializado para documentos xml.
            XmlTextReader reader = new XmlTextReader(stream);
            // Inicializa a vari�vel de retorno.
            int stayFactor = 1;

            try
            {
                //Varre os elementos xml em busca das informa��es sobre o fator de multiplica��o.
                while (reader.Read())
                {
                    // Verifica se achou a tag <stay_factor>
                    if (reader.Name.Equals(STAY_FACTOR))
                    {
                        // Vai para o atributo valor.
                        reader.MoveToFirstAttribute();
                        // Atribui o valor a variavel de retorno.
                        stayFactor = Int32.Parse(reader.Value);
                        // Sai do la�o
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Fecha o XmlReader e stream.
            reader.Close();
            stream.Close();
            // retorna o custo de estadia.
            return stayFactor;
        }
	}
}
