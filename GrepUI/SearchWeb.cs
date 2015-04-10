using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataProvider;
using GrepEngine;

namespace GrepUI
{
    public partial class SearchWeb : Form
    {
        private Thread _searchingTask;
        private bool _ifSearching;
        

        public SearchWeb()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ifSearching = !_ifSearching;
            if (_ifSearching)
            {
                button1.Text = "Cancel";
                DataProvider.DataProvider downloader = new DataProvider.DataProvider();
                var pageText= downloader.DownloadPageContent(textBox1.Text, true);
                Searcher searcher= new Searcher(new ProffessionalLogger());
                _searchingTask = new Thread(()=>FinishSearch(searcher,pageText));
                _searchingTask.Start();
            }
            else
            {
                button1.Text = "Search";
                _searchingTask.Abort();
            }
        }

        private void FinishSearch(Searcher searcher, IEnumerable<string> pageText )
        {
            var output = searcher.FindLineWithString(pageText, textBox2.Text);
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke((MethodInvoker)(delegate()
                {
                    updateRichTextBox(output);
                }));

                button1.BeginInvoke((MethodInvoker)(delegate()
                {
                    button1.Text = "Search";
                }));
            }


        }

        private void updateRichTextBox(IEnumerable<string> content)
        {
            var builder = new StringBuilder();
            foreach (var line in content)
            {
                builder.AppendLine(line);
            }
            richTextBox1.Text = builder.ToString();

        }
    }
}
