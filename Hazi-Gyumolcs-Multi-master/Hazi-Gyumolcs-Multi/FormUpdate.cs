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
    public partial class FormUpdate : Form
    {
        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            loadFruit(Program.formNyito.getSelectedFruit());
        }

        private void loadFruit(Fruit f)
        {
            textBox_name.Text = f.Name;
            numericUpDown_quantity.Value = f.Quantity;
            numericUpDown_price.Value = f.Price;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            updateFruit(Program.formNyito.getSelectedFruit(), createFruitFromInput());
        }

        private Fruit createFruitFromInput()
        {
            var name = textBox_name.Text;
            var price = (int)numericUpDown_price.Value;
            var quantity = (int)numericUpDown_quantity.Value;
            return new Fruit(0, name, price, quantity);
        }

        private void updateFruit(Fruit from, Fruit to)
        {
            Program.database.Query("UPDATE `gyumolcs` SET `nev` = @2, `egysegar` = @3, `mennyiseg` = @4 WHERE `gyumolcs`.`id` = @1;",
                from.Id, to.Name, to.Price, to.Quantity);
            Close();

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
