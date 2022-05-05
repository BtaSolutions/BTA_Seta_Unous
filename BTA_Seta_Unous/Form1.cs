using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BTA_Seta_Unous
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var tokenOut = await BLL.Token.retornaToken();

                MessageBox.Show(tokenOut.access_token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var config = new DTO.Config
                {
                    server      = BLL.Crypt.Encrypt("177.47.16.140"),
                    port        = BLL.Crypt.Encrypt("5432"),
                    user        = BLL.Crypt.Encrypt("seta"),
                    password    = BLL.Crypt.Encrypt("O4RRLAPo"),
                    database    = BLL.Crypt.Encrypt("seta")
                };

                string sPath = Directory.GetCurrentDirectory() + @"\config.json";

                System.IO.File.WriteAllText(sPath, Newtonsoft.Json.JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented));

                MessageBox.Show("OK");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                BLL.Config_Sessao.carregarConfig(Directory.GetCurrentDirectory());
            }
            catch (Exception)
            {

                throw;
            }
        }

        int qtde_Registros = 1000;

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var tokenOut = await BLL.Token.retornaToken();
                
                var products = await DAL.Products.retornaProducts(BLL.Config_Sessao.config);

                for (int i=0; i < products.Count; i++)
                {
                    var products_Send = new  List<DTO.Product_In>();

                    for (int j=0; j < qtde_Registros; j++)
                    {
                        i++;

                        if (i < products.Count)
                        {
                            products_Send.Add(products[i]);
                        }
                    }

                    var resposta = await BLL.Products.enviarProducts(tokenOut.access_token, products_Send);

                    if (resposta.statusDescription != "OK")
                    {
                        dynamic objResp = JsonConvert.DeserializeObject(resposta.responseFromServer);

                        if (Convert.ToInt32(objResp.statusReply) != 0)
                        {
                            MessageBox.Show(objResp.message.ToString());
                        }

                        MessageBox.Show(resposta.statusCode);
                        MessageBox.Show(resposta.statusDescription);
                        MessageBox.Show(resposta.responseFromServer);
                    }
                        
                }

                
                //File.WriteAllText(@"c:\bta\products.json", JsonConvert.SerializeObject(products, Formatting.Indented));
                
                

                //File.WriteAllText(@"c:\bta\products_out.json", Newtonsoft.Json.JsonConvert.SerializeObject(resposta, Formatting.Indented));
                
                MessageBox.Show("Acabou");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLocations_Click(object sender, EventArgs e)
        {
            try
            {
                var tokenOut = await BLL.Token.retornaToken();

                var locations = await DAL.Locations.retornaLocations(BLL.Config_Sessao.config);

                //File.WriteAllText(@"c:\bta\locations.json", JsonConvert.SerializeObject(locations, Formatting.Indented));

                var resposta = await BLL.Locations.enviarLocations(tokenOut.access_token, locations);

                MessageBox.Show(resposta.statusCode);
                MessageBox.Show(resposta.statusDescription);
                MessageBox.Show(resposta.responseFromServer);

                //File.WriteAllText(@"c:\bta\products_out.json", Newtonsoft.Json.JsonConvert.SerializeObject(resposta, Formatting.Indented));

                MessageBox.Show("Test");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
