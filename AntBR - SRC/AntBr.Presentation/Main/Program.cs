using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AntBr.Commons.Util.XMLFileReader;
using System.Collections;
using AntBr.Commons.Entity;
using AntBr.Commons.Config;
using AntBr.Presentation.UI;


namespace AntBr.Presentation
{
    /// <summary>
    /// Classe que serve como ponte de entrada para execu��o da aplica��o.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// M�todo principal. Ponto de entrada da aplica��o.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configura��es padr�o do visual studio
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Carrega par�mtros de configura��o da aplica��o
            // Ex: times, custos de viagem e estadia etc.
            ConfigureAntBr.loadApplicationParameters();
            // Gera a matriz de custos total (estadia + viagem).
            ConfigureAntBr.caulculateTotalCostMatrix();
            // Carrega par�metros do m�todo AntCycle
            // Ex.: N�mero de formigas, par�metro alfa, beta etc.
            ConfigureAntBr.loadAntCycleParameters();
            ConfigureAntBr.setBrazilianTable();
            // Inicia a execu��o do Form.
            Application.Run(new SettingParameters());

        }
    }
}