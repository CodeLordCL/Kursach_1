using System.Text;
using System.Security.Cryptography;

namespace Kursach_1.Managers
{
    internal class DESSymmetricCypher
    {
        string pass;
        FileStream file_encr;
        FileStream file_input;


        public DESSymmetricCypher(string pass, string file_encr_name, string file_input_name) 
        { 
            this.pass = pass;
            this.file_encr = new FileStream(file_encr_name, FileMode.Create, FileAccess.Write);
            this.file_input = new FileStream(file_input_name, FileMode.Open, FileAccess.Read);
        }
        public void encrypt_des()
        {

            //FileStream file_encr = new FileStream("DES_sym_out1.txt", FileMode.Create, FileAccess.Write);

            //FileStream file_input = new FileStream("DES_sym_in.txt", FileMode.Open, FileAccess.Read);

            var des = new DESCryptoServiceProvider();
            try
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(pass);

                des.IV = ASCIIEncoding.ASCII.GetBytes(pass);

                ICryptoTransform des_encr = des.CreateEncryptor();

                CryptoStream stream = new CryptoStream(file_encr, des_encr, CryptoStreamMode.Write);

                byte[] input_array = new byte[file_input.Length - 0];

                file_input.Read(input_array, 0, input_array.Length);

                stream.Write(input_array, 0, input_array.Length);

                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return;
        }

        public void decrypt_des()
        {
            //FileStream file_encr = new FileStream("DES_sym_out2.txt", FileMode.Create, FileAccess.Write);

            //FileStream file_input = new FileStream("DES_sym_out1.txt", FileMode.Open, FileAccess.Read);

            var des = new DESCryptoServiceProvider();
            try
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(pass);

                des.IV = ASCIIEncoding.ASCII.GetBytes(pass);

                ICryptoTransform des_encr = des.CreateDecryptor();

                CryptoStream stream = new CryptoStream(file_encr, des_encr, CryptoStreamMode.Write);

                byte[] bytearrayinput = new byte[file_input.Length - 0];

                file_input.Read(bytearrayinput, 0, bytearrayinput.Length);

                stream.Write(bytearrayinput, 0, bytearrayinput.Length);

                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return;
        }
    }
}
