using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace SCEngine {
    public partial class WidgetExportXmlDialog : DarkDialog {
        public string XmlPath {
            get => pathTextbox.Text;
            set => pathTextbox.Text = value;
        }
        public string RootNodeText {
            get => rootNodeTextbox.Text;
            set => rootNodeTextbox.Text = value;
        }
        public WidgetExportXmlDialog() {
            InitializeComponent();
        }

        private void chooesPathButton_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.Title = "导出至...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                pathTextbox.Text = Path.GetFullPath(saveFileDialog.FileName);
            }
        }

        private void pathTextbox_Validating(object sender, CancelEventArgs e) {
            if (!IsValidPath(pathTextbox.Text, out string result)) {
                DarkMessageBox.ShowError(result, "");
                pathTextbox.Focus();
            }
        }

        static bool IsValidPath(string path, out string result) {

            Regex regex = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
            Match m = regex.Match(path);
            if (!m.Success) {
                result = "非法的文件保存路径，请重新选择或输入！";
                return false;
            }
            if (path.Any(x => Path.GetInvalidPathChars().Contains(x))) {
                result = "请勿在文件名中包含\\ / : * ？ \" < > |等字符，请重新输入有效文件名！";
                return false;
            }
            result = "路径合法";
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (!IsValidPath(pathTextbox.Text, out string result)) {
                DarkMessageBox.ShowError(result, "");
                pathTextbox.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}
