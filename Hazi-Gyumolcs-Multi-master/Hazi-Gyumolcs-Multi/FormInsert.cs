using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hazi_Gyumolcs_Multi
{
    public partial class FormInsert : Form
    {
        public FormInsert()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            createFruit(createFruitFromInput());
            Close();
        }

        private void createFruit(Fruit fruit)
        {
            Program.database.Query("INSERT INTO `gyumolcs` (`nev`, `egysegar`, `mennyiseg`) VALUES (@1, @2, @3);"
                , fruit.Name, fruit.Price, fruit.Quantity);
        }
        private Fruit createFruitFromInput()
        {
            var name = textBox_name.Text;
            var price = (int)numericUpDown_price.Value;
            var quantity = (int)numericUpDown_quantity.Value;
            return new Fruit(0, name, price, quantity);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
