using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PenCode
{
    class RichTextBoxWriter : TextWriter
    {
        private RichTextBox term;

        public RichTextBoxWriter(RichTextBox _term)
        {
            term = _term;
        }

        public RichTextBox Term
        {
            get { return term; }
        }

        public override void Write(string value)
        {
            base.Write(value);
            term.AppendText(value);
        }

        public override Encoding Encoding
        {
           get { return Encoding.UTF8; }
        }
    }
}
