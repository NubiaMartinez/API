using Clases.ApiRest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clases
{
    public partial class Apiii : Form
    {
        APII dBApi = new APII();
        public Apiii()
        {
            InitializeComponent();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            dynamic respuesta = dBApi.Get("https://reqres.in/api/users?page=1");
            pictureBox1.ImageLocation = respuesta.data[1].avatar.ToString();
            txtNombreGET.Text = respuesta.data[1].first_name.ToString();
            txtApellidoGET.Text = respuesta.data[1].last_name.ToString();
            txtEmail.Text = respuesta.data[1].email.ToString();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona
            {
                job = txtTrabajador.Text,
                name = txtNombresPost.Text
            };

            string json = JsonConvert.SerializeObject(persona);

            dynamic respuesta = dBApi.Post("https://reqres.in/api/users",json);

            MessageBox.Show(respuesta.ToString());
        }

        private void txtNombresPost_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Persona
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}

