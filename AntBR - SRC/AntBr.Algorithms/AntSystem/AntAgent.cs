using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AntBr.Algorithms.AntSystem
{
    /// <summary>
    /// Classe que representa o agente formiga do Ant Conlony Optimization
    /// </summary>
    public class AntAgent
    {
        /// <summary>
        /// Lista tabu para armazenar nós já visitados.
        /// </summary>
        private ArrayList tabuList;
        /// <summary>
        /// Lista para armazenar as possíveis escolhar de um agente a cada interação.
        /// </summary>
        private ArrayList[] candidateMatches;
        private ArrayList[] candidatesProbabilities;
        /// <summary>
        /// Armazena o nó atual onde a formiga se encontra
        /// </summary>
        private int actualNode;
        /// <summary>
        /// Armaena o custo total do caminho
        /// </summary>
        private double tripCosts;
        /// <summary>
        /// Contador para controlar o número de partidas fora de casa.
        /// </summary>
        private int awayMatchesCounter;
        /// <summary>
        /// Contador para controlar o número de partidas dentro de casa.
        /// </summary>
        private int homeMatchesCounter;
        private int actualRound;
        private ArrayList turnTabu;

        /// <summary>
        /// Propriedade para obter ou modificar o contador de partidas fora de casa.
        /// </summary>
        public int AwayMatchesCounter
        {
            get { return awayMatchesCounter; }
            set { awayMatchesCounter = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar o contador de partidas dentro de casa.
        /// </summary>
        public int HomeMatchesCounter
        {
            get { return homeMatchesCounter; }
            set { homeMatchesCounter = value; }
        }

        /// <summary>
        /// Propriedade para obter oumodificar a lista tabu.
        /// </summary>
        public ArrayList TabuList
        {
            get { return tabuList; }
            set { tabuList = value; }
        }
        
        /// <summary>
        /// Propriedade para obter ou modificar a lista de confrontos candidatos.
        /// </summary>
        public ArrayList[] CandidateMatches
        {
            get { return candidateMatches; }
            set { candidateMatches = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar o nó atual da formiga.
        /// </summary>
        public int ActualNode
        {
            get { return actualNode; }
            set { actualNode = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar os custos dos jogos.
        /// </summary>
        public double TripCosts
        {
            get { return tripCosts; }
            set { tripCosts = value; }
        }

        /// <summary>
        /// Construtor. Incializa a lista tabu e outros parâmetros.
        /// </summary>
        public AntAgent()
        {
            // Inicializa lista tabu.
            tabuList = new ArrayList();
            candidateMatches = new ArrayList[AntCycle.NodeCount];
            candidatesProbabilities = new ArrayList[AntCycle.NodeCount];
            for (int i = 0; i < candidateMatches.Length; i++)
            {
                candidateMatches[i] = new ArrayList();
                candidatesProbabilities[i] = new ArrayList();
            }
            turnTabu = new ArrayList(19);
        }

        /// <summary>
        /// Método para inicializar o AntAgent. Adiciona o nó inicial na lista tabu.
        /// </summary>
        /// <param name="i">nó inicial da formiga. Adicionado na lista tabu.</param>
        public void init(int i)
        {
            // Limpa a lista tabu (caso estaja preenchida por outra rodada).
            tabuList.Clear();
            // Adiciona o nó inicial da formiga.
            tabuList.Add(i);
            // Adiciona o nó de label negativo que indica o jogo com ele próprio
            // fora de casa.
            tabuList.Add(i+AntCycle.AntNumber);
            // Atribui o valor do nó atual.
            actualNode = i;
        }

        /// <summary>
        /// Método que escolhe o próximo nó para onde a formiga deve ir.
        /// </summary>
        /// <returns>Nó escolhido</returns>
        public void moveTo(int round)
        {
            actualRound = round;
            // Obtêm a linha da matriz de rastro respectiva ao nó atual.
            double[] nextNodesTrail = AntCycle.EdgeTrail[actualNode];
            // Obtêm a linha da matriz de visibilidade respetiva ao nó atual.
            double[] nextNodesVisibility = AntCycle.EdgeVisibility[actualNode];
            // Incializa o valor da probabilidade do próximo nó como sendo zero.
            double probability = 0.0;
            // Atribui um valor para o próximo nó.
            int nextNode = -1;
            // Inicializa valor do termo inferior para o cálculo da probabilidade.
            double downTerm = 0.0;
            // Laço que calcula o valor do termo inferior.
            for (int i = 0; i < AntCycle.NodeCount; i++)
            {
                // Verifica se o nó esta na lista tabu e se o valor do rastro da aresta 
                // entre o próximo nó e o nó atual está acima do valor de corte.
                if (!tabuList.Contains((Int32)i) )//&& (nextNodesTrail[i] > AntCycle.EdgeTrailCutValue))
                {
                    // Adiciona ao valor do termo inferiror o calculo para o determinado nó.
                    downTerm += Math.Pow(nextNodesTrail[i], AntCycle.TrailSignificance) * Math.Pow(nextNodesVisibility[i], AntCycle.VisibilitySignificance);
                }
            }
            // Laço que calcula o valor do termo superior e a probababilidade para cada nó.
            for (int i = 0; i < AntCycle.NodeCount; i++)
            {
                // Verifica se o nó esta na lista tabu e se o valor do rastro da aresta entre o próximo nó e
                // o nó atual está acima do valor de corte.
                if (!tabuList.Contains(i))// && (nextNodesTrail[i] > AntCycle.EdgeTrailCutValue))
                {
                    
                    // calcula o valor do termo superior.
                    double upTerm = Math.Pow(nextNodesTrail[i], AntCycle.TrailSignificance) * Math.Pow(nextNodesVisibility[i], AntCycle.VisibilitySignificance);
                    // calcula a probabilidade atual.
                    double actualProb = upTerm / downTerm;
                    // Verifica se a probabilidade atual é maior que a probabilidade
                    // do melhor próximo nó.
                    if (probability < actualProb)
                    {
                        //Atualiza o valor do melhor próximo nó.
                        nextNode = i;
                        //Atualiza o valor da probalidade do melhor próximo nó.
                        probability = actualProb;
                    }
                }
            }
            // Adiciona o melhor próximo nó na lista tabu.
            tabuList.Add(nextNode);
            // Atualiza o valor do nó atual como sendo o melhor próximo nó.
            actualNode = nextNode;
        }


        /// <summary>
        /// Método que calcula o valor da rota percorrida pela formiga.
        /// </summary>
        /// <returns> o valor da calculado da rota. </returns>
        public void calculateTourLength()
        {
            // Incializa o valor da rota.
            double tourLength = 0.0;
            //
            tabuList.RemoveAt(1);
            // Laço pra calcular o valor da rota.
            for (int i = 0; i < tabuList.Count-1; i++)
            {
                // Obtêm o valor do nó i.
                int iNode = ((Int32)tabuList[i]);
                // Obtêm o valor do nó j.
                int jNode = ((Int32)tabuList[i + 1]);
                if ( !((iNode < AntCycle.AntNumber) && (jNode < AntCycle.AntNumber)))
                    // Adiciona ao valor da rota o custo de ir do nó i ao j.
                    tourLength += AntCycle.Graph[iNode][jNode];
            }
            // Obtêm o valor do último nó da rota.
            int endNode = ((Int32)tabuList[tabuList.Count - 1]);
            // Obtêmo valor do primeiro nó da rota.
            int beginNode = ((Int32)tabuList[0]);
            if ((!(endNode < AntCycle.AntNumber) && (beginNode < AntCycle.AntNumber)))
                // Adiciona ao valor da rota o custo de "volta pra casa".
                tourLength += AntCycle.Graph[endNode][beginNode];
            // Retorna o valor da rota obtido.
            tripCosts = tourLength;
        }
    }
}
