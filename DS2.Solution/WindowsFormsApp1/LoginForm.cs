using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        DS2Entities db = new DS2Entities();
        List<string> msg = new List<string>();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                DoLogin();
            }
            else
            {
                var list = string.Empty;
                foreach (var item in msg)
                {
                    list += item + "\n";
                }

                MessageBox.Show(list, "INTEC SYSTEM");
            }
        }

        private void DoLogin()
        {
            var user = db.User.FirstOrDefault(x=> x.Username == txtUsername.Text && x.Password == txtPassword.Text);
            if (user == null)
            {
                MessageBox.Show("USUARIO INVALIDO");
                return;
            }

            var obj = new MainForm();
            obj.Show();

            this.Hide();
        }

        bool ValidateLogin()
        {
            msg = new List<string>();
            bool result = true;

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                msg.Add("El Usuario es un valor requerido.");
                result = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                msg.Add("La Contraseña es un valor requerido.");
                result = false;
            }

            return result;
        }
    }
}
