using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastColoredTextBoxNS {
    class DarkFastColoredTextBox : FastColoredTextBox {
        public new string Hotkeys {
            get { return HotkeysMapping.ToString(); }
            set { HotkeysMapping = HotkeysMapping.Parse(value.Replace("后退", "Back")); }
        }
        public DarkFastColoredTextBox() : base() {
            SyntaxHighlighter = new DarkSyntaxHighlighter(this);
        }
    }
}
