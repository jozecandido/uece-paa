using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AntBr.Algorithms.AntSystem;
using AntBr.Commons.Config;

namespace AntBr.Presentation.UI
{
    public partial class SettingParameters : Form
    {
        public SettingParameters()
        {
            InitializeComponent();
            txtTrailQuantity.Text = AntCycle.TrailQuantity.ToString();
            txtTrailSignificance.Text = AntCycle.TrailSignificance.ToString();
            txtVisibilitySignificance.Text = AntCycle.VisibilitySignificance.ToString();
            txtEvaporationCoeficient.Text = AntCycle.EvaporationCoeficient.ToString();
            txtMaxCyclesNumber.Text = AntCycle.MaxCyclesNumber.ToString();
            txtInitialTrail.Text = AntCycle.InitialTrail.ToString();
            txtStagnationCycles.Text = AntCycle.StagnationCyclesNumber.ToString();
            AntCycle.configure(ApplicationParameters.TotalCostMatrix);
             cbHomeMatches.SelectedItem = 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                AntCycle.TrailQuantity = Convert.ToDouble(txtTrailQuantity.Text);
                AntCycle.TrailSignificance = Convert.ToDouble(txtTrailSignificance.Text);
                AntCycle.VisibilitySignificance = Convert.ToDouble(txtVisibilitySignificance.Text);
                AntCycle.EvaporationCoeficient = Convert.ToDouble(txtEvaporationCoeficient.Text);
                AntCycle.InitialTrail = Convert.ToDouble(txtInitialTrail.Text);
                AntCycle.MaxCyclesNumber = Convert.ToInt32(txtMaxCyclesNumber.Text);
                AntCycle.StagnationCyclesNumber = Convert.ToInt32(txtStagnationCycles.Text);
                ApplicationParameters.BeginDate = dateTimePicker1.Value;
            }
            catch
            {
                MessageBox.Show("Verifique se há valores inválidos");
            }
            AntCycle.executeCycle();
            ResultTable form = new ResultTable();
            form.Show();
            form.showTable();
        }

        private void lblStagnationCycles_Click(object sender, EventArgs e)
        {

        }

        private void cbHomeMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationParameters.Matches = Convert.ToInt32(cbHomeMatches.SelectedValue);
        }

    }
}