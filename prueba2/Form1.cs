using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba2
{
    public partial class Form1 : Form
    {
        private Dictionary<Button, Item> buttonItems = new Dictionary<Button, Item>();
        List<Button> buttons = new List<Button>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                Button btn = CreateNewButton();
                this.Controls.Add(btn);
                buttons.Add(btn);
            }
        }
        private Button CreateNewButton()
        {
            Button btn = new Button();
            btn.Text = "Button";
            btn.Location = new Point(rnd.Next(this.Width - 50), rnd.Next(this.Height - 50));
            btn.Size = new Size(50, 30);
            btn.Click += Btn_Click;
            btn.Image = Image.FromFile("C:\\Users\\Patricio\\Downloads\\pixil-frame-0.png");

            Item item = new Item();
            buttonItems.Add(btn, item);
            return btn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && buttons.Contains(btn))
            {
                buttons.Remove(btn);
                listBox1.Items.Add(btn.Text);
                this.Controls.Remove(btn);

                Item item = buttonItems[btn];
                MessageBox.Show($"Has recogido el objeto {item.Name} con un valor de {item.Value}", "Objeto recogido");
            }
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
