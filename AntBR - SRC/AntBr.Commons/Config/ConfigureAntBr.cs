using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AntBr.Commons.Util.XMLFileReader;
using AntBr.Commons.Entity;
using AntBr.Algorithms.AntSystem;

namespace AntBr.Commons.Config
{
    /// <summary>
    /// Classe responsável por gerenciar o processo de configuração da aplicação.
    /// Carregar os parâmetros, etc.
    /// </summary>
    public class ConfigureAntBr
    {
        /// <summary>
        /// Método que Carrega os parâmetros da aplicação.
        /// </summary>
        public static void loadApplicationParameters()
        {
            // Carrega a lista de times;
            ApplicationParameters.TeamsList = TeamsReader.getTeams();
            // Carrega o valor do fator multiplicativo do preço de estadia.
            ApplicationParameters.StayFactor = CostsReader.getStayFactor();
            // Carrega o valor do fator multiplicativo do preço de viagem.
            ApplicationParameters.TripFactor = CostsReader.getTripFactor();
            // Inicializa o hashtable que armazenará os valores dos custos de viagem.
            Hashtable tripCosts = new Hashtable();
            // Inicializa o hashtable que armazenará os valores dos custos de estadia.
            Hashtable stayCosts = new Hashtable();
            // Laço para montar os hashtables de custo e estadia.
            foreach (ITeam team in ApplicationParameters.TeamsList)
            {
                // Obtém os custos de traslado apartir de uma determinada cidade.
                Hashtable costs = CostsReader.getTripCosts(team.CITY);
                // Laço para adicionar valores ao hashtable de custos de viagem.
                IDictionaryEnumerator enumerator = costs.GetEnumerator();
                while(enumerator.MoveNext())
                {
                    if (!tripCosts.ContainsKey(enumerator.Key))
                    {
                        tripCosts.Add(enumerator.Key, enumerator.Value);
                    }
                }
                // Adiciona custos de estadia ao hashtable
                if (!stayCosts.ContainsKey(team.CITY))
                    stayCosts.Add(team.CITY, CostsReader.getStayCosts(team.CITY));
            }
            // Carrega valores de estadia.
            ApplicationParameters.StayCosts = stayCosts;
            // Carrega valores de viagem.
            ApplicationParameters.TripCosts = tripCosts;
        }

        /// <summary>
        /// Método que calcula a matriz de custos totais.
        /// </summary>
        public static void caulculateTotalCostMatrix()
        {
            
            // Variável temporária para armazenar o valor do tamnaho do array de times;
            int teamListSize = ApplicationParameters.TeamsList.Count;
            // Variável temporária para armazenar o fator multiplicativo de viagem.
            int tripFactor = ApplicationParameters.TripFactor;
            // Variável temporária para armazenar o fator multiplicativo de estadia.
            int stayFactor = ApplicationParameters.StayFactor;
            // Inicializa a priemeira dimesão da matriz.
            double[][] totalCostMatrix = new double[2 * teamListSize][];
            // laço para inicializar a segunda dimensão da matriz e
            // calcular o valor do custo total.
   
            for (int i = 0; i < teamListSize; i++)
            {
                // inicializa a segunda dimesão da matriz.
                totalCostMatrix[i] = new double[2 * teamListSize];
                totalCostMatrix[i + teamListSize] = new double[2 * teamListSize];
                for (int j = 0; j < teamListSize; j++)
                {
                    // Calcula o valor do custo total.
                    double tripCost = (double)ApplicationParameters.TripCosts[((Team)ApplicationParameters.TeamsList[i]).CITY + "-" + ((Team)ApplicationParameters.TeamsList[j]).CITY];
                    double stayCost = (double)ApplicationParameters.StayCosts[((Team)ApplicationParameters.TeamsList[i]).CITY];
                    // Atribui o valor do custo total.
                    if (((Team)ApplicationParameters.TeamsList[i]).CITY.Equals(((Team)ApplicationParameters.TeamsList[j]).CITY))
                    {
                        totalCostMatrix[i][j] = 0.001;
                        totalCostMatrix[i][j + teamListSize] = 0.001;
                        totalCostMatrix[i + teamListSize][j] = 0.001;
                        totalCostMatrix[i + teamListSize][j + teamListSize] = 0.001;
                    }
                    else
                    {
                        totalCostMatrix[i][j] = tripFactor * tripCost + 2 * stayFactor * stayCost; //0.001;
                        totalCostMatrix[i][j + teamListSize] = tripFactor * tripCost + 2 * stayFactor * stayCost;
                        totalCostMatrix[i + teamListSize][j] = tripFactor * tripCost + 2 * stayFactor * stayCost;
                        totalCostMatrix[i + teamListSize][j + teamListSize] = tripFactor * tripCost + 2 * stayFactor * stayCost;
                    }
                }
            }
            ApplicationParameters.TotalCostMatrix = totalCostMatrix;
        }

        /// <summary>
        /// Inicializa parâmetros de configuração do AntCycle.
        /// </summary>
        public static void loadAntCycleParameters()
        {

            // Obtém os parâmetros do AntCycle.
            Hashtable antCycleParameters = AntSystemParametersReader.getAntCycleParameters();
            // Laço para atribuir os parâmetros no AntCycle.
            IDictionaryEnumerator enumerator = antCycleParameters.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().Equals("trail_quantity"))
                {
                    AntCycle.TrailQuantity = (double)enumerator.Value;
                    continue;
                }
                if (enumerator.Key.ToString().Equals("trail_significance"))
                {
                    AntCycle.TrailSignificance = (double)enumerator.Value;
                    continue;
                }
                if (enumerator.Key.ToString().Equals("visibiblity_significance"))
                {
                    AntCycle.VisibilitySignificance = (double)enumerator.Value;
                    continue;
                }
                if (enumerator.Key.ToString().Equals("evaporation_coeficient"))
                {
                    AntCycle.EvaporationCoeficient = (double)enumerator.Value;
                    continue;
                }
                if (enumerator.Key.ToString().Equals("edge_trail_cut_value"))
                {
                    AntCycle.EdgeTrailCutValue = (double)enumerator.Value;
                    continue;
                }
                if (enumerator.Key.ToString().Equals("ant_number"))
                {
                    AntCycle.AntNumber = Convert.ToInt32(enumerator.Value);
                    continue;
                }
                if (enumerator.Key.ToString().Equals("max_cycles_number"))
                {
                    AntCycle.MaxCyclesNumber = Convert.ToInt32(enumerator.Value);
                    continue;
                }
                if (enumerator.Key.ToString().Equals("initial_trail"))
                {
                    AntCycle.InitialTrail = (double)enumerator.Value;
                    continue;
                }
                if (enumerator.Key.ToString().Equals("stagnation_cycles_number"))
                {
                    AntCycle.StagnationCyclesNumber = Convert.ToInt32(enumerator.Value);
                    continue;
                }
            }
            ApplicationParameters.AntCycleParameters = antCycleParameters;
        }
        public static void setBrazilianTable()
        {
            int[][] brazilianTable = new Int32[40][];
            brazilianTable[0] = new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
            brazilianTable[1] = new int[] {6,7,29,37,35,38,20,21,16,2,39,13,14,31,32,4,28,3,5,10};
            brazilianTable[2] = new int[] {36,33,17,9,12,11,8,18,26,23,15,25,24,1,19,30,0,22,27,34};
            brazilianTable[3] = new int[] {21,0,34,24,3,30,39,17,31,33,5,8,16,9,2,38,32,27,15,6};
            brazilianTable[4] = new int[] {10,25,18,11,28,1,13,36,4,19,20,23,37,26,35,14,7,12,22,29};
            brazilianTable[5] = new int[] {35,9,33,32,6,7,24,25,19,21,18,37,3,2,36,0,14,11,30,28};
            brazilianTable[6] = new int[] {8,31,39,5,30,23,16,13,20,34,4,1,15,27,9,32,26,37,17,2};
            brazilianTable[7] = new int[] {37,19,10,14,33,16,27,6,29,8,22,15,38,4,23,31,25,0,12,21};
            brazilianTable[8] = new int[] {11,35,36,30,7,26,5,24,17,32,3,20,9,34,13,1,2,28,39,18};
            brazilianTable[9] = new int[] {23,4,8,0,21,12,38,19,22,16,37,14,25,15,31,33,26,10,6,27};
            brazilianTable[10] = new int[] {12,36,5,27,34,22,10,4,13,17,26,18,20,28,4,39,1,29,31,15};
            brazilianTable[11] = new int[] {7,37,23,2,16,13,11,20,35,38,14,26,19,25,30,8,24,1,9,32};
            brazilianTable[12] = new int[] {33,14,32,8,38,19,29,15,23,6,31,10,2,0,21,27,37,16,4,25};
            brazilianTable[13] = new int[] {39,30,7,33,9,35,17,22,12,24,1,36,28,3,18,5,11,26,34,0};
            brazilianTable[14] = new int[] {5,26,25,39,31,20,1,28,7,30,9,4,13,32,37,2,38,14,16,3};
            brazilianTable[15] = new int[] {22,18,0,15,17,8,34,12,25,11,36,29,27,19,6,23,10,24,21,33};
            brazilianTable[16] = new int[] {29,12,4,6,22,14,23,10,38,0,27,19,21,16,25,37,33,15,8,31};
            brazilianTable[17] = new int[] {18,28,26,36,5,24,2,34,1,35,13,32,11,30,7,9,3,39,20,17};
            brazilianTable[18] = new int[] {24,22,1,18,0,9,15,11,34,25,12,27,30,17,8,26,19,32,23,36};
            brazilianTable[19] = new int[] {14,3,31,21,39,37,32,29,10,7,28,2,6,38,20,16,35,5,13,4};
            brazilianTable[20] = new int[] {26,27,9,17,15,18,0,1,36,22,19,33,34,11,12,24,8,23,25,30};
            brazilianTable[21] = new int[] {16,13,37,29,32,31,28,38,6,3,35,5,4,21,39,10,20,2,7,14};
            brazilianTable[22] = new int[] {1,20,14,4,23,10,19,37,11,13,25,28,36,29,22,18,12,7,35,26};
            brazilianTable[23] = new int[] {30,5,38,31,8,21,33,16,24,39,0,3,17,6,15,34,27,32,2,9};
            brazilianTable[24] = new int[] {15,29,13,12,26,27,4,5,39,1,38,17,23,22,16,20,34,31,10,8};
            brazilianTable[25] = new int[] {28,11,19,25,10,3,36,33,0,14,24,21,35,7,29,12,6,17,37,22};
            brazilianTable[26] = new int[] {17,39,30,34,13,36,7,26,9,28,2,35,18,24,3,11,5,20,32,1};
            brazilianTable[27] = new int[] {31,15,16,10,27,6,25,4,37,12,23,0,29,14,33,21,22,8,19,38};
            brazilianTable[28] = new int[] {3,24,28,20,1,32,18,39,2,36,17,34,5,35,11,13,6,30,26,7};
            brazilianTable[29] = new int[] {32,16,25,7,14,2,30,24,33,37,6,38,0,8,24,19,21,9,11,35};
            brazilianTable[30] = new int[] {27,17,3,22,36,33,31,0,15,18,34,6,39,5,10,28,4,21,29,12};
            brazilianTable[31] = new int[] {13,34,12,28,18,39,9,35,3,26,11,30,22,20,1,7,17,36,24,5};
            brazilianTable[32] = new int[] {19,10,27,13,29,15,37,2,32,4,21,16,8,23,38,25,31,6,14,20};
            brazilianTable[33] = new int[] {25,6,5,19,11,0,21,8,27,10,29,24,33,12,17,22,18,34,36,23};
            brazilianTable[34] = new int[] {2,38,20,35,37,28,14,32,5,31,16,9,7,39,26,3,30,4,1,13};
            brazilianTable[35] = new int[] {9,32,24,26,2,34,3,30,18,20,7,39,1,36,5,17,13,35,28,11};
            brazilianTable[36] = new int[] {38,8,6,16,25,4,22,14,21,15,33,12,31,10,27,29,23,19,0,37};
            brazilianTable[37] = new int[] {4,2,21,38,20,29,35,31,14,5,32,7,10,37,28,6,39,12,3,16};
            brazilianTable[38] = new int[] {34,23,11,1,19,17,12,9,30,27,8,22,26,18,0,36,15,25,33,24};
            brazilianTable[39] = new int[20];
            
            ApplicationParameters.Table = brazilianTable;
            AntCycle.Table = brazilianTable;
            

        }
    }
}
