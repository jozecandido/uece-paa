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
    public class AntSystemParametersReader
    {
        /// <summary>
        /// Obt�m o diret�rio da aplica��o.
        /// </summary>
        private static string DIRECTORY = System.Environment.CurrentDirectory + "\\XML\\";
        /// <summary>
        /// Nome do arquivo xml de configura��o dos times.
        /// </summary>
        private const string FILE_NAME = "AntSystemParameters.xml";
        /// <summary>
        /// String da tag xml raiz.
        /// </summary>
        private const string ROOT = "ant_system";
        /// <summary>
        /// String da tag xml que encapsula os par�metros do ant_cycle.
        /// </summary>
        private const string ANT_CYCLE = "ant_cycle";
        /// <summary>
        /// String da tag xml que encapsula um determinado par�metro.
        /// </summary>
        private const string PARAMETER = "parameter";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena a quantidade
        /// de rastro que uma formiga pode deixar.
        /// </summary>
        private const string TRAIL_QUANTITY = "trail_quantity";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena a "siginific�ncia"
        /// dada ao rastro da formiga (par�metro alfa da meta-heur�stica).
        /// </summary>
        private const string TRAIL_SIGNIFICANCE = "trail_significance";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena a "siginific�ncia"
        /// dada � visibilidade de uma aresta (par�metro beta da meta-heur�stica).
        /// </summary>
        private const string VISIBILITY_SIGNIFICANCE = "visibility_significance";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena 
        /// o coeficiente de evapora��o do rastro.
        /// </summary>
        private const string EVAPORATION_COEFICIENT = "evaporation_coeficient";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena 
        /// o valor de corte de uma aresta (baseado no valor do rastro).
        /// </summary>
        private const string EDGE_TRAIL_CUT_VALUE = "edge_trail_cut_valeu";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena 
        /// a quantidade de formigas utilizadas.
        /// </summary>
        private const string ANT_NUMBER = "ant_number";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena 
        /// o valor do n�mero m�ximo de ciclos.
        /// </summary>
        private const string MAX_CYCLES_NUMBER = "max_cycles_number";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena 
        /// o valor da quantidade inicial de rastro das arestas.
        /// </summary>
        private const string INITIAL_TRAIL = "initial_trail";
        /// <summary>
        /// String da propriedade da tag xml parameter que armazena 
        /// o valor da quantidade de clicos para considera estagnado.
        /// </summary>
        private const string STAGNATION_CYCLES_NUMBER = "stagnation_cycles_number";

        /// <summary>
        /// L� do xml de configura��o os custos de viagem a sede de um determinado time
        /// e os outros.
        /// </summary>
        /// <param name="city">Cidade-sede de um time.</param>
        /// <returns>Uma tabela hash associado um trecho (origem-destino) ao seu custo.</returns>
        public static Hashtable getAntCycleParameters()
        {
            // Inicializa a stream de leitura de dados do aquivo de configura��o.
            FileStream stream = File.OpenRead(DIRECTORY.Replace("\\bin\\Debug", "") + @"\\" + FILE_NAME);
            // Iniciaiza o XMLReader, um reader especializado para documentos xml.
            XmlTextReader reader = new XmlTextReader(stream);
            // Inicializa o hashtable que ir� armazenar os custos de viagem.
            Hashtable antCycleParameters = new Hashtable();

            try
            {
                //Varre os elementos xml em busca das informa��es sobre os custos.
                while (reader.Read())
                {
                    // Verifica se achou a se��o descrita pela tag <city>
                    if (reader.Name.Equals(ANT_CYCLE))
                    {
                        // Varre atr�s das tags <parameter>.
                        while (reader.Read())
                        {
                            // Verifica se � a tag <parameter>.
                            if (reader.Name.Equals(PARAMETER))
                            {
                                // Move para o atributo name.
                                reader.MoveToFirstAttribute();
                                // Atribui o valor a uma vari�vel tempor�ria.
                                string parameterName = reader.Value;
                                // Move para o atributo value.
                                reader.MoveToNextAttribute();
                                // Atribui o valor a uma vari�vel tempor�ria.
                                double parameterValue = Double.Parse(reader.Value, System.Globalization.NumberStyles.AllowDecimalPoint);
                                // Adiciona associa��o ao hashtable
                                antCycleParameters.Add(parameterName, parameterValue);
                            }
                            // Verifica se achou outra tag <ant_cycle>.
                            if (reader.Name.Equals(ANT_CYCLE))
                            {
                                // sai caso seja verdadeira a senten�a.
                                break;
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
            // Retorna os custo.
            return antCycleParameters;
        }
    }
}
