using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace SCEngine {
    public partial class XmlDisplayDialog : DarkDialog {
        public string XmlString {
            get => xmlTextBox.Text;
            set => xmlTextBox.Text = value;
        }
        public XmlDisplayDialog(string xmlString) {
            InitializeComponent();
            XmlString = xmlString;
        }
    }
}
