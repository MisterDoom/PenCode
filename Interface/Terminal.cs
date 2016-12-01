using System;
using System.Windows.Forms;

namespace PenCode
{
    public partial class Terminal : Form
    {

        #region Fields

        private int opTabs = 0;

        #endregion

        public Terminal()
        {
            InitializeComponent();
            InitializeNewTab();
        }

        private void InitializeNewTab()
        {
            opTabs++;
            TabPage newPage = new TabPage("Tab" + opTabs.ToString());
            newPage.Controls.Add(new RichConsole(opTabs));
            newPage.Name = "term";
            tabTerminal.TabPages.Add(newPage);
            tabTerminal.SelectedIndex = opTabs - 1;
        }

        #region Menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeNewTab();
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabTerminal.SelectedTab.Dispose();
            opTabs--;
            tabTerminal.SelectedIndex = opTabs - 1;
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void tabTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                int nextInd = (opTabs + 1 > tabTerminal.TabCount? 0 : opTabs + 1);
                tabTerminal.SelectedIndex = nextInd;
            }
        }

    }
}
