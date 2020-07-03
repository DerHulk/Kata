using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palindrom.Forms
{
    public partial class Form1 : Form
    {
        private (int input, int foundPalindrom, int cyle)? LastCalculation { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.txt_Input.Text, out var number))
            {
                var transfomer = new Palindrom.Transform();
                var result = transfomer.palindrome(number);

                this.lbl_Result.Text = $"Palindrom is {result.foundPalindrom} found with { result.cyle } cyles.";
                this.LastCalculation = (number, result.foundPalindrom, result.cyle);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.LastCalculation.HasValue)
                return;

            var history = this.LoadHistory();

            history.Add(this.LastCalculation.Value);
            var json = JsonConvert.SerializeObject(history);

            Properties.Settings.Default.History = json;
            Properties.Settings.Default.Save();
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            var history = this.LoadHistory();
            this.lb_History.Items.Clear();

            foreach(var item in history)
            {
                this.lb_History.Items.Add(HistroyToString(item));
            }
            
        }

        private List<(int input, int foundPalindrom, int cyle)> LoadHistory()
        {
            return string.IsNullOrEmpty(Properties.Settings.Default.History) ?
                    new List<(int input, int foundPalindrom, int cyle)>() :
                        JsonConvert.DeserializeObject<List<(int input, int foundPalindrom, int cyle)>>(Properties.Settings.Default.History);
        }

        private string HistroyToString((int input, int foundPalindrom, int cyle) historyItem)
        {
            return $"{historyItem.input}/{historyItem.foundPalindrom}/{ historyItem.cyle } cyles.";
        }
    }
}
