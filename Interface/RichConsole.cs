using System.Drawing;
using System.Windows.Forms;
using IronPython.Hosting;
using System.IO;
using Microsoft.Scripting.Hosting;
using System;

namespace PenCode
{
    public partial class RichConsole : Form
    {
        private RichTextBoxWriter richWriter;
        private RichTextBox term;
        private int tabNr;

        public TextWriter RichWriter
        {
            get { return richWriter; }
        }

        public RichConsole(int _tabNr)
        {
            tabNr = _tabNr;
            InitializeComponent();
            InitializeForm();
            InitializeTab();
        }

        private void InitializeForm()
        {
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Visible = true;
            Dock = DockStyle.Fill;
        }

        private void InitializeTab()
        {
            term = new RichTextBox();
            richWriter = new RichTextBoxWriter(term);
            Console.SetOut(richWriter);
            term.KeyDown += richTerm_KeyDown;
            term.Enter += richConsole_Enter;
            term.Name = "term";
            term.ForeColor = Color.Lime;
            term.BackColor = Color.Black;
            term.Font = new Font("Consolas", 8);
            term.Dock = DockStyle.Fill;
            term.Text = "Welcome to PenCode - Tab " + tabNr.ToString();
            Controls.Add(term);
        }

        private bool Interpret() // split
        {
            string lineText = ReadLine();
            string[] inf = lineText.Split('|');
            string plaintext = "", keyv = "";
            int keyc = 0;
            char method = 'a';
            switch (inf[0])
            {
                case "caesar" :
                    plaintext = inf[1];
                    keyc = int.Parse(inf[2]);
                    method = char.Parse(inf[3]);
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic caesar = pyt.UseFile("python\\caesar.py");
                        caesar.mainLike(plaintext, keyc, method);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "vigener" :
                    plaintext = inf[1];
                    keyv = inf[2];
                    method = char.Parse(inf[3]);
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic vigener = pyt.UseFile("python\\vigener.py");
                        vigener.mainFunc(plaintext, keyv, method);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "reverse":
                    plaintext = inf[1];
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic mult = pyt.UseFile("python\\mult.py");
                        mult.reverse(plaintext);
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "lettFreq":
                    plaintext = inf[1];
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic mult = pyt.UseFile("python\\mult.py");
                        mult.lettFreq(plaintext);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "lower":
                    plaintext = inf[1];
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic mult = pyt.UseFile("python\\mult.py");
                        mult.lower(plaintext);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "upper":
                    plaintext = inf[1];
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic mult = pyt.UseFile("python\\mult.py");
                        mult.upper(plaintext);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "length":
                    plaintext = inf[1];
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic mult = pyt.UseFile("python\\mult.py");
                        mult.length(plaintext);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "asciiToDec":
                    plaintext = inf[1];
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic mult = pyt.UseFile("python\\mult.py");
                        mult.asciiToDec(plaintext);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                case "decToAscii":
                    plaintext = inf[1];
                    try
                    {
                        term.AppendText("\n");
                        var pyt = Python.CreateRuntime();
                        dynamic mult = pyt.UseFile("python\\mult.py");
                        mult.decToAscii(plaintext);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return true;
                default :
                    break;

            }
            return false;
            //Debug.WriteLine(lineText);

        }

        private string ReadLine()
        {
            string lineText;
            int lineNr = term.GetLineFromCharIndex(term.SelectionStart);
            lineText = term.Lines[lineNr];
            return lineText;
        }

        private void richTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = Interpret();
            }
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void richConsole_Enter(object sender, EventArgs e)
        {
            Console.SetOut(richWriter);
        }

    }
}

