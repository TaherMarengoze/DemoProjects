using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConverterDemo.Client;

namespace ViewConverterDemo
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvIdentities.DataSource = controller.GetIdentities();
            dgvDetails.DataSource = controller.GetItemDetails();
        }
    }
}
