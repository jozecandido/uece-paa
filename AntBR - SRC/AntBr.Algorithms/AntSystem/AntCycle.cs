using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AntBr.Algorithms.AntSystem
{
    public class AntCycle
    {
        /// <summary>
        /// Quantidade de rastro que uma formiga pode deixar.
        /// </summary>
        private static double trailQuantity;
        /// <summary>
        /// Parâmetro alfa da meta-heurística da Colônia de Formigas.
        /// Dá importância ao rastro ao calcular probabilidade de escolha do próximo nó.
        /// </summary>
        private static double trailSignificance;
        /// <summary>
        /// Parâmetro beta da meta-heurística da Colônia de Formigas.
        /// Dá importância à distância ao calcular probabilidade de escolha do próximo nó.
        /// </summary>
        private static double visibilitySignificance;
        /// <summary>
        /// Coeficiente que determina o nível de evaporação do rastro de feromônio.
        /// </summary>
        private static double evaporationCoeficient;
        /// <summary>
        /// valor do rastro de corte para uma aresta.
        /// </summary>
        private static double edgeTrailCutValue;
        /// <summary>
        /// Número de formigas utilizadas.
        /// </summary>
        private static int antNumber;
        /// <summary>
        /// Número máximo de ciclos executados até achar um resultado.
        /// </summary>
        private static int maxCyclesNumber;
        /// <summary>
        /// Rastro inicial contido nos arcos.
        /// </summary>
        private static double initialTrail;
        /// <summary>
        /// Número de cliclos para se considerar a estagnação do método.
        /// </summary>
        private static int stagnationCyclesNumber;
        /// <summary>
        /// Número de nós do grafo.
        /// </summary>
        private static int nodeCount;
        /// <summary>
        /// Grafo de custos/distâncias.
        /// </summary>
        private static double[][] graph;
        /// <summary>
        /// Visibilidade da arestas (1/d).
        /// </summary>
        private static double[][] edgeVisibility;
        /// <summary>
        /// Quatidade de rastro das arestas.
        /// </summary>
        private static double[][] edgeTrail;
        /// <summary>
        /// Variação de rastro durante um ciclo.
        /// </summary>
        private static double[][] edgeDeltaTrail;
        /// <summary>
        /// ArrayList que armazena os agentes formigas.
        /// </summary>
        private static ArrayList ants;
        /// <summary>
        /// Hashtable para mapear os labels para as matrizes.
        /// </summary>
        private static Hashtable LabelMap;
        /// <summary>
        /// Valor da custo do caminho.
        /// </summary>
        private static double cost = 9999999999999999999.9;
        /// <summary>
        /// Matriz que armazena a tabela de jogos.
        /// </summary>
        private static int[][] matchesTable;
        private static Hashtable results;
        private static ArrayList tabuOponents;
        private static int stagnationCyclesNumberCounter;
        private static int[][] bTable;

        /// <summary>
        /// Propriedade para obter a quantidade de rastro que uma formiga pode deixar.
        /// </summary>
        public static int[][] Table
        {
            get
            {
                return bTable;
            }
            set
            {
                bTable = value;
            }
        }

        /// <summary>
        /// Propriedade para obter a quantidade de rastro que uma formiga pode deixar.
        /// </summary>
        public static double TrailQuantity
        {
            get
            {
                return trailQuantity;
            }
            set
            {
                trailQuantity = value;
            }
        }
        /// <summary>
        /// Propriedade para obter número de formigas utilizadas.
        /// </summary>
        public static int AntNumber
        {
            get
            {
                return antNumber;
            }
            set
            {
                antNumber = value;
            }
        }
        /// <summary>
        /// Propriedade para obter o número máximo de ciclos executados até achar um resultado.
        /// </summary>
        public static int MaxCyclesNumber
        {
            get
            {
                return maxCyclesNumber;
            }
            set
            {
                maxCyclesNumber = value;
            }
        }
        /// <summary>
        /// Propriedade para obter o valor do coeficiente que determina o nível de 
        /// evaporação do rastro de feromônio.
        /// </summary>
        public static double EvaporationCoeficient
        {
            get
            {
                return evaporationCoeficient;
            }
            set
            {
                evaporationCoeficient = value;
            }
        }
        /// <summary>
        /// Propriedade para obter o valor do rastro inicial contido nos arcos.
        /// </summary>
        public static double InitialTrail
        {
            get
            {
                return initialTrail;
            }
            set
            {
                initialTrail = value;
            }
        }
        /// <summary>
        /// Propriedade para obter o número de cliclos para se considerar a estagnação do método.
        /// </summary>
        public static int StagnationCyclesNumber
        {
            get
            {
                return stagnationCyclesNumber;
            }
            set
            {
                stagnationCyclesNumber = value;
            }
        }
        /// <summary>
        /// Propriedade para obter a significância do rastro (parâmetro alfa).
        /// </summary>
        public static double TrailSignificance
        {
            get
            {
                return trailSignificance;
            }
            set
            {
                trailSignificance = value;
            }
        }
        /// <summary>
        /// Propriedade para obter a significância da visibilidade (parâmetro beta).
        /// </summary>
        public static double VisibilitySignificance
        {
            get
            {
                return visibilitySignificance;
            }
            set
            {
                visibilitySignificance = value;
            }
        }
        /// <summary>
        /// Propriedade para alterar ou obter o valor de corte de uma aresta em 
        /// relação a quantidade de rastro.
        /// </summary>
        public static double EdgeTrailCutValue
        {
            get
            {
                return edgeTrailCutValue;
            }
            set
            {
                edgeTrailCutValue = value;
            }
        }
        /// <summary>
        /// Propriedade para obter o número de nós.
        /// </summary>
        public static int NodeCount
        {
            get
            {
                return nodeCount;
            }
            set
            {
                nodeCount = value;
            }
        }
        /// <summary>
        /// Propriedade para obter a matriz de rastro.
        /// </summary>
        public static double[][] EdgeTrail
        {
            get
            {
                return edgeTrail;
            }
        }
        /// <summary>
        /// Propriedade para obter a matriz de visibilidade.
        /// </summary>
        public static double[][] EdgeVisibility
        {
            get
            {
                return edgeVisibility;
            }
        }
        /// <summary>
        /// Propriedade para obter a matriz de visibilidade.
        /// </summary>
        public static double[][] Graph
        {
            get
            {
                return graph;
            }
        }
        /// <summary>
        /// Prorpiedade para obter a tabela de jogos
        /// </summary>
        public static int[][] MatchesTable
        {
            get
            {
                return matchesTable;
            }
        }
        public static Hashtable Results
        {
            get
            {
                return results;
            }
        }
        public static ArrayList TabuOponents
        {
            get
            {
                return tabuOponents;
            }
        }
        public static double Cost
        {
            get
            {
                return cost;
            }
        }

        /// <summary>
        /// Inicializa variáveis de controle e matrizes de visibilidade, rastro etc.
        /// </summary>
        public static void configure(double[][] costMatrix)
        {
            // Atribui o grafo
            graph = costMatrix;
            // Atribui o número de nós do grafo.
            nodeCount = graph.Length;
            // Inicializa as matrizes de visibilidade, rastro e delta-rastro.
            edgeVisibility = new double[nodeCount][];
            edgeTrail = new double[nodeCount][];
            edgeDeltaTrail = new double[nodeCount][];
            matchesTable = new int[nodeCount][];
            for (int i = 0; i < nodeCount; i++)
            {
                matchesTable[i] = new int[antNumber];
                edgeVisibility[i] = new double[nodeCount];
                edgeTrail[i] = new double[nodeCount];
                edgeDeltaTrail[i] = new double[nodeCount];
                for (int j = 0; j < antNumber; j++)
                    matchesTable[i][j] = -1;
            }
            // Inicializa ArrayList das formigas.
            ants = new ArrayList();
            results = new Hashtable();
            tabuOponents = new ArrayList();
        }
        /// <summary>
        /// Método que realiza a fase de inicialização da meta-heurística.
        /// Cria as formigas e as espalha pelo grafo. Além disso atribui os valores
        /// iniciais de rastro e calcula a visibilidade.
        /// </summary>
        private static void initialize()
        {
            // Laço para criar as formigas.
            for (int i = 0; i < antNumber; i++)
            {
                // Cria a formiga
                AntAgent ant = new AntAgent();
                // Adiciona no ArrayList
                ants.Add(ant);
            }
            // Laço para inicializar os valores das matrizes.
            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                    //Calcula o valor da visibilidade.
                    edgeVisibility[i][j] = 1.0 / graph[i][j];
                    // Atribui valor inicial de rastro.
                    edgeTrail[i][j] = initialTrail;
                }
            }
        }

        /// <summary>
        /// Espalha as formigas pelo grafo
        /// </summary>
        private static void spreadAnts()
        {
            // laço para para espalhar as formigas
            for (int i = 0; i < antNumber; i++)
            {
                // coloca nó inicial da formiga.
                ((AntAgent)ants[i]).init(i);
            }
        }

        /// <summary>
        /// Executa uma 'volta' de uma formiga pelo grafo.
        /// </summary>
        public static void  executeTour()
        {
            // laço para fazer as formigas percorrerem todos os nós.
            for (int i = 0; i < nodeCount - 2; i++)
            {
                // laço para fazer cada formigar dar 'um passo'.
                for (int j = 0; j < antNumber; j++)
                {
                    // obtém a formiga do array.
                    AntAgent ant = (AntAgent)ants[j];
                    // move a formiga para um próximo nó.
                    ant.moveTo(i);
                    matchesTable[i][j] = ant.ActualNode;
                }
                
            }
        }

        /// <summary>
        /// Executa o algoritmo até o máximo de ciclos estabelecidos ou até a resposta estagnar.
        /// </summary>
        public static void executeCycle()
        {
            // Inicializa parâmetros e matrizes.
            initialize();
            // laço para executar os ciclos até o número máximo.
            for (int cycleNumber = 0; (cycleNumber < maxCyclesNumber); cycleNumber++)
            {
                // Espalha as formigas pelo grafo.
                spreadAnts();
                // Executa uma 'volta'.
                executeTour();
                // Atualiza rastro.
                updateTrail();
            }
            #region
            if (!results.Contains(cost))
            {
                results.Add(cost, Table);
            }
            #endregion
        }

        private static void updateTrail()
        {
            double totalCost = 0.0;
            #region init
            int[][] table = new int[nodeCount][];
            double cost2 = 0.0;
            table = bTable;
            for (int i = 0; i < bTable[i].Length; i++)
            {
                int iNode = 0;
                int jNode = 0;
                for (int j = 0; j < bTable.Length -1; j++)
                {
                    // Obtêm o valor do nó i.
                    iNode = (bTable[j][i]);
                    // Obtêm o valor do nó j.
                    jNode = (bTable[j + 1][i]);
                    if (!((iNode < antNumber) && (jNode < antNumber)))
                        // Adiciona ao valor da rota o custo de ir do nó i ao j.
                        cost2 += AntCycle.Graph[iNode][jNode];
                }
                // Obtêm o valor do nó i.
                iNode = (bTable[table.Length - 1][i]);
                // Obtêm o valor do nó j.
                jNode = (bTable[0][i]);
                if (!((iNode < antNumber) && (jNode < antNumber)))
                    // Adiciona ao valor da rota o custo de ir do nó i ao j.
                    cost2 += AntCycle.Graph[iNode][jNode];
                // Retorna o valor da rota obtido.
            }
            
            #endregion
            
            
            for (int i = 0; i < antNumber; i++)
            {
                AntAgent ant = (AntAgent)ants[i];
                ant.calculateTourLength();
                for (int j = 0; j < ant.TabuList.Count - 1; j++)
                {
                    
                    int iNode = ((System.Int32)ant.TabuList[j]);
                    int jNode = ((System.Int32)ant.TabuList[j + 1]);
                    edgeDeltaTrail[iNode][jNode] += trailQuantity / ant.TripCosts;
                    table[j][i] = (int)matchesTable[j][i];
                    matchesTable[j][i] = -1;
                }
                int endNode = ((System.Int32)ant.TabuList[ant.TabuList.Count - 1]);
                int beginNode = ((System.Int32)ant.TabuList[0]);
                edgeDeltaTrail[endNode][beginNode] += trailQuantity / ant.TripCosts;
                totalCost += ant.TripCosts;
            }
            if (totalCost < cost)
            {
                cost = cost2;

            }
            else if (totalCost == cost)
                stagnationCyclesNumberCounter++;
            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                        edgeTrail[i][j] = evaporationCoeficient * edgeTrail[i][j] + edgeDeltaTrail[i][j];
                        edgeDeltaTrail[i][j] = 0;
                }
            }
        }
    }
}
