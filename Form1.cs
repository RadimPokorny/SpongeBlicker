using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    public partial class Form1 : Form
    {
        
        long gold_count = 0;
        short sword_level = 1;
        long sword_price = 50;
        int damage_index = 1;
        int stamina_index = 1;
        int resistance_index = 1;
        long damage_price = 1;
        long stamina_price = 1;
        long resistance_price = 1;
        long hp;
        long previous;
        int level;

        int damage = 1, stamina = 1, resistance = 1;


        
        public Form1()
        {
            InitializeComponent();
            button2.Cursor = System.Windows.Forms.Cursors.Hand;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Font LargeFont = new Font("Arial", 28);
            label15.Font = LargeFont;
            hp = 100;
            previous = 100;
            level = 1;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            foreach(Control ovladac in this.Controls)
            {

                if (ovladac is Label)
                {

                    (ovladac as Label).ForeColor = Color.White;
                }


            }

            label1.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label17.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label18.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;

            button3.BackColor = Color.Transparent;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nickname = textBox1.Text;
            textBox1.Enabled = false;
            button1.Enabled = false;
            label17.Visible = true;
            label17.Text = "Hello, "+textBox1.Text + ", I´ll give you some golds, if you will hit me..";
            
            foreach(Control ovladac in this.Controls)
            {

                if (ovladac is Button)
                {

                    (ovladac as Button).Enabled = true;

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (handled)
            {
                handled = false;
                return;
            }
            button3.Image = Properties.Resources.spangatisichit;
            label15.Visible = true;
            gold_count += 1*(sword_level);
                    
            label15.Text = "-"+damage.ToString();
            await Task.Delay(200);
            button3.Image = Properties.Resources.spangatisic;
            label15.Visible = false;
            hp -= damage;
            
            
            if(hp > 0) label16.Text = "HP: "+hp.ToString();

            else 
            {
                gold_count += previous;
                hp = previous * 2;
                label16.Text = "HP: " + hp.ToString();
                label18.Text = "Level "+level.ToString();
                MessageBox.Show("Congratulations! You beat the boss level " + level.ToString() + ". Your reward is " + previous.ToString() + " golds");
                previous = hp;
                level++;
            }
            label1.Text = gold_count.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (gold_count >= stamina_price)
            {
                stamina_index++;
                stamina = stamina_index * 30;
                gold_count -= stamina_price;
                stamina_price += 10;
                label7.Text = stamina_index.ToString();
                label10.Text = stamina_price.ToString();
                label13.Text = "(" + stamina.ToString() + ")";
                label1.Text = gold_count.ToString();
            }

            else
            {
                MessageBox.Show("You do not have enough gold!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (gold_count >= resistance_price)
            {
                resistance_index++;
                resistance = resistance_index * 2;
                gold_count -= resistance_price;
                resistance_price += 10;
                label6.Text = resistance_index.ToString();
                label11.Text = resistance_price.ToString();
                label14.Text = "(" + resistance.ToString() + ")";
                label1.Text = gold_count.ToString();
            }

            else
            {
                MessageBox.Show("You do not have enough gold!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            BackColor = Color.Transparent;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            if(gold_count >= sword_price)
            {
                gold_count -= sword_price;
                sword_level++;
                sword_price = (sword_price * 3);
                label2.Text = "Sword Level: " + sword_level.ToString();
                label1.Text = gold_count.ToString();
            }

            else
            {
                MessageBox.Show("You do not have enough gold!");
            }

            button4.Text = "Upgrade sword (Cost " + sword_price.ToString() + " Golds)";

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        bool handled;

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                handled = true;
            }
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (gold_count >= damage_price)
            {
                damage = damage_index * 10;
                damage_index++;
                gold_count -= damage_price;
                damage_price += 10;
                label8.Text = damage_index.ToString();
                label9.Text = damage_price.ToString();
                label12.Text = "(" + damage.ToString() + ")";
                label1.Text = gold_count.ToString();
            }

            else
            {
                MessageBox.Show("You do not have enough gold!");
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            
        }
    }
}
