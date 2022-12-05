using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hazi_Gyumolcs_Multi
{
    public partial class FormNyito : Form
    {
        public FormNyito()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateList();          
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            new FormInsert().ShowDialog();
            updateList();

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            new FormUpdate().ShowDialog();
            updateList();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            removeFruit(getSelectedFruit());
            updateList();

        }

        public Fruit getSelectedFruit()
        {
            return (Fruit)comboBox_fruits.SelectedItem;
        }

        public void updateList()
        {
            comboBox_fruits.Items.Clear();
            foreach (var item in getAllFruits())
                comboBox_fruits.Items.Add(item);
            if (comboBox_fruits.Items.Count != 0)
                comboBox_fruits.SelectedIndex = 0;
        }

        private List<Fruit> getAllFruits()
        {
            var res = Program.database.Query("SELECT `id`, `nev`, `egysegar`, `mennyiseg` FROM `gyumolcs`;");
            List<Fruit> fruits = new List<Fruit>();
            foreach (var item in res.Values)
            {
                var id = int.Parse(item[0]);
                var name = item[1];
                var price = int.Parse(item[2]);
                var quantity = int.Parse(item[3]);
                fruits.Add(new Fruit(id, name, price, quantity));
            }
            return fruits;
        }

        private void removeFruit(Fruit fruit)
        {
            Program.database.Query("DELETE FROM gyumolcs WHERE `gyumolcs`.`id` = @1;", fruit.Id);
        }

    }
}
