using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AntBr.Commons.Entity;

namespace AntBr.Commons.Config
{
    /// <summary>
    /// Classe que armazenará os parâmetros de configuração da aplicação.
    /// </summary>
    public class ApplicationParameters
    {
        /// <summary>
        /// ArrayList para armazenar os times.
        /// </summary>
        private static ArrayList teams;
        /// <summary>
        /// Valor do fator de multiplicação para o preço
        /// do traslado entre duas cidades.
        /// </summary>
        private static int tripFactor;
        /// <summary>
        /// Valor do fator de multiplicação para o preço
        /// da estadia em uma cidade.
        /// </summary>
        private static int stayFactor;
        /// <summary>
        /// Hashtable que armazena os custos de viagem entre duas cidades.
        /// </summary>
        private static Hashtable tripCosts;
        /// <summary>
        /// Hashtable que armazena os custos de estadia em uma cidade.
        /// </summary>
        private static Hashtable stayCosts;
        /// <summary>
        /// Hashtable que armazena os parâmetros do AntCycle.
        /// </summary>
        private static Hashtable antCycleParameters;
        /// <summary>
        /// Matriz de custos totais (viagem + estadia).
        /// </summary>
        private static double[][] totalCostMatrix;
        /// <summary>
        /// Data de início do Campeonato
        /// </summary>
        private static DateTime beginDate;

        private static int[][] bTable;

        /// <summary>
        /// Propriedade para obter ou modificar a matriz de custos totais (viagem + estadia).
        /// </summary>
        public static int[][] Table
        {
            get { return bTable; }
            set { bTable = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar a matriz de custos totais (viagem + estadia).
        /// </summary>
        public static DateTime BeginDate
        {
            get { return beginDate; }
            set { beginDate = value; }
        }
        /// <summary>
        /// Propriedade para obter ou modificar a matriz de custos totais (viagem + estadia).
        /// </summary>
        public static double[][] TotalCostMatrix
        {
            get { return totalCostMatrix; }
            set { totalCostMatrix = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar o arrayList para armazenar os times.
        /// </summary>
        public static ArrayList TeamsList
        {
            get { return teams; }
            set { teams = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar o valor do fator de multiplicação para o preço
        /// do traslado entre duas cidades.
        /// </summary>
        public static int TripFactor
        {
            get { return tripFactor; }
            set { tripFactor = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar o valor do fator de multiplicação para o preço
        /// da estadia em uma cidade.
        /// </summary>
        public static int StayFactor
        {
            get { return stayFactor; }
            set { stayFactor = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar o hashtable que armazena os custos de viagem entre duas cidades.
        /// </summary>
        public static Hashtable TripCosts
        {
            get { return tripCosts; }
            set { tripCosts = value; }
        }

        /// <summary>
        /// Propriedade para obter ou modificar o hashtable que armazena os custos de estadia em uma cidade.
        /// </summary>
        public static Hashtable StayCosts
        {
            get { return stayCosts; }
            set { stayCosts = value; }
        }
        /// <summary>
        /// Propriedade para obter ou modificar o hashtable que armazena os parâmetros do AntCycle.
        /// </summary>
        public static Hashtable AntCycleParameters
        {
            get { return antCycleParameters; }
            set { antCycleParameters = value; }

        }

        public static int matches;

        /// <summary>
        /// Propriedade para obter ou modificar o hashtable que armazena os parâmetros do AntCycle.
        /// </summary>
        public static int Matches
        {
            get { return matches; }
            set { matches = value; }

        }
    }
}
