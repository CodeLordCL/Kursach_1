using Kursach_1.Managers;
using System.Text;

namespace Kursach_1
{
    public partial class Form1 : Form
    {
        public string AES_key;
        public byte[] AES_IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "DES")
            {
                if (textBox1.Text.Length > 0)
                {
                    DESSymmetricCypher des_cypher = new DESSymmetricCypher(textBox1.Text, "DES_sym_out1.txt", "DES_sym_in.txt");
                    des_cypher.encrypt_des();
                }
                else MessageBox.Show("Enter key word!");
            }
            if (comboBox1.SelectedItem.ToString() == "AES")
            {
                if (textBox1.Text.Length > 0)
                {
                    if (textBox1.Text.Length == 16)
                    {
                        AES_key = textBox1.Text;
                        AES_Random_IV();
                        AES_Encrypt(AES_key, AES_IV, "AES_in.txt", "AES_out1.txt");
                    }
                    else MessageBox.Show("Write 16 characters.");
                }
                else MessageBox.Show("Enter key word!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "DES")
            {
                if (textBox1.Text.Length > 0)
                {
                    DESSymmetricCypher des_cypher = new DESSymmetricCypher(textBox1.Text, "DES_sym_out2.txt", "DES_sym_out1.txt");
                    des_cypher.decrypt_des();
                }
                else MessageBox.Show("Enter key word!");
            }
            if (comboBox1.SelectedItem.ToString() == "AES")
            {
                if (textBox1.Text.Length > 0)
                {
                    if (AES_key.Length == 16)
                    {
                        AES_Decrypt(AES_key, AES_IV, "AES_out1.txt", "AES_out2.txt");
                    }
                    else MessageBox.Show("Write 16 characters.");
                }
                else MessageBox.Show("Enter key word!");
            }
        }

        private void AES_Encrypt(string key, byte[] IV, string file_from, string fileTo)
        {
            Reader reader = new Reader();
            string fileString = reader.ReadFile(file_from);

            AES_Cypher aes_cypher = new AES_Cypher();
            string encryptedString = aes_cypher.Encrypt_AES(fileString, key, IV);

            Wrighter wr = new Wrighter();
            wr.WrightFile(encryptedString, fileTo);
        }

        private void AES_Decrypt(string key, byte[] IV, string fileFrom, string fileTo)
        {
            Reader rd = new Reader();
            string fileString = rd.ReadFile(fileFrom);

            AES_Cypher aes_cypher = new AES_Cypher();
            string decryptedString = aes_cypher.Decrypt_AES(fileString, key, IV);

            Wrighter wr = new Wrighter();
            wr.WrightFile(decryptedString, fileTo);
        }

        private void AES_Random_IV()
        {
            Random random = new Random();

            int i = 0;

            while (i < AES_IV.Length)
            {
                AES_IV[i] = Convert.ToByte(random.Next(255));

                i += 1;
            }

            textBox2.Text = "";

            foreach (byte j in AES_IV)
            {
                textBox2.Text += j;

                textBox2.Text += " ";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "DES")
            {
                label1.Text = "Key 1";
                label2.Text = "Write 8 characters.";
                textBox2.Visible = false;
            }
            if (comboBox1.SelectedItem.ToString() == "AES")
            {
                label1.Text = "Key";
                label2.Text = "IV";
                textBox2.Visible = true;
                textBox1.Text = Encoding.UTF8.GetString(AES_IV);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}