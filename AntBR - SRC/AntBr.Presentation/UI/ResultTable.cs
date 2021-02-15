using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AntBr.Commons.Config;
using AntBr.Algorithms.AntSystem;
using AntBr.Commons.Entity;

namespace AntBr.Presentation
{
    public partial class ResultTable : Form
    {
        /// <summary>
        /// Construtor do Fomulario. Inicializa componentes e parâmetros.
        /// </summary>
        public ResultTable()
        {
            // Incializa componentes da interface.
            InitializeComponent();
            // Adiciona 20 linhas em branco ao DatagridView
            dataGridView1.Rows.Add(380);
            
            
        }

        public void showTable()
        {
            int[][] table = (int[][])AntCycle.Results[AntCycle.Cost];
            for (int i = 0; i < AntCycle.AntNumber / 2; i++)
            {
                for (int j = 0; j < AntCycle.NodeCount - 2; j++)
                {
                    dataGridView1.Rows[(j * 10) + i].Cells["Round"].Value = j + 1;
                    dataGridView1.Rows[(j * 10) + i].Cells["Date"].Value = ApplicationParameters.BeginDate.AddDays((j * 7)).ToShortDateString();
                    dataGridView1.Rows[(j * 10) + i].Cells["Vs"].Value = "vs";

                    int node = table[j][i];

                    if (node > 19)
                        node = (table[j][i] - 19) * -1;


                    for (int k = 0; k < ApplicationParameters.TeamsList.Count; k++)
                    {
                        if (i == ((ITeam)ApplicationParameters.TeamsList[k]).ID)
                        {

                            if (node > 0)
                            {
                                dataGridView1.Rows[(j * 10) + i].Cells["HomeTeam"].Value = ((ITeam)ApplicationParameters.TeamsList[k]).NAME;
                                dataGridView1.Rows[(j * 10) + i].Cells["Local"].Value = ((ITeam)ApplicationParameters.TeamsList[k]).CITY;
                                dataGridView1.Rows[(j * 10) + i].Cells["LocalIcon"].Value = Image.FromFile(System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "") + "\\Img\\" + 
                                    ((ITeam)ApplicationParameters.TeamsList[k]).ICON);
                            }
                            else
                            {
                                dataGridView1.Rows[(j * 10) + i].Cells["AwayTeam"].Value = ((ITeam)ApplicationParameters.TeamsList[k]).NAME;
                                dataGridView1.Rows[(j * 10) + i].Cells["AwayIcon"].Value = Image.FromFile(System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "") + "\\Img\\" +
                                    ((ITeam)ApplicationParameters.TeamsList[k]).ICON);
                            }
                        }
                        if (node >= 0)
                        {
                            if ((node) == ((ITeam)ApplicationParameters.TeamsList[k]).ID)
                            {
                                dataGridView1.Rows[(j * 10) + i].Cells["AwayTeam"].Value = ((ITeam)ApplicationParameters.TeamsList[k]).NAME;
                                dataGridView1.Rows[(j * 10) + i].Cells["AwayIcon"].Value = Image.FromFile(System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "") + "\\Img\\" +
                                    ((ITeam)ApplicationParameters.TeamsList[k]).ICON);
                            }
                        }
                        else
                        {
                            if (-1 * (node + 1) == ((ITeam)ApplicationParameters.TeamsList[k]).ID)
                            {
                                dataGridView1.Rows[(j * 10) + i].Cells["HomeTeam"].Value = ((ITeam)ApplicationParameters.TeamsList[k]).NAME;
                                dataGridView1.Rows[(j * 10) + i].Cells["Local"].Value = ((ITeam)ApplicationParameters.TeamsList[k]).CITY;
                                dataGridView1.Rows[(j * 10) + i].Cells["LocalIcon"].Value = Image.FromFile(System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "") + "\\Img\\" +
                                    ((ITeam)ApplicationParameters.TeamsList[k]).ICON);
                            }
                        }

                    }
                }
            }
            MessageBox.Show("Custo Total: " + AntCycle.Cost.ToString());
            // Laço para preencher o DataGrid View com os dados da matriz de custos totais.
            //for (int i=0; i<ApplicationParameters.TotalCostMatrix.Length; i++)
            //{
            //    for (int j=0; j<ApplicationParameters.TotalCostMatrix.Length; j++)
            //    {
            //        // Adiciona dada a sua célula correpondente.
            //        dataGridView1.Rows[i].Cells[j].Value = ApplicationParameters.TotalCostMatrix[i][j];
            //    }
            //}
        }
    }
}