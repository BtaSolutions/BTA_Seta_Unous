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
                dtpDate01.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                BLL.Config_Sessao.carregarConfig(Directory.GetCurrentDirectory());
            }
            catch (Exception)
            {

                throw;
            }
        }

        int qtde_Registros = 5000;

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var tokenOut = await BLL.Token.retornaToken();
                
                var products = await DAL.Products.retornaProducts(BLL.Config_Sessao.config, dtpDate01.Value, dtpDate02.Value);
                int iCount = 1;

                for (int i=0; i < products.Count; i++)
                {
                    iCount++;

                    var products_Send = new  List<DTO.Product>();

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

        private async void btnSuppliers_Click(object sender, EventArgs e)
        {
            try
            {
                var tokenOut = await BLL.Token.retornaToken();

                var suppliers = await DAL.Suppliers.retornaSuppliers(BLL.Config_Sessao.config, dtpDate01.Value, dtpDate02.Value);

                File.WriteAllText(@"c:\bta\suppliers.json", JsonConvert.SerializeObject(suppliers, Formatting.Indented));

                //File.WriteAllText(@"c:\bta\locations.json", JsonConvert.SerializeObject(locations, Formatting.Indented));

                var resposta = await BLL.Suppliers.enviarSuppliers(tokenOut.access_token, suppliers);

                if (resposta.statusDescription != "OK")
                {
                    MessageBox.Show(resposta.responseFromServer, resposta.statusDescription, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dynamic objResp = JsonConvert.DeserializeObject(resposta.responseFromServer);

                    MessageBox.Show(objResp.message.ToString(), objResp.statusReply.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //if (Convert.ToInt32(objResp.statusReply) != 0)
                    //{
                    //    
                    //}
                }

                //File.WriteAllText(@"c:\bta\products_out.json", Newtonsoft.Json.JsonConvert.SerializeObject(resposta, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnOpenOrders_Click(object sender, EventArgs e)
        {
            try
            {
                var tokenOut = await BLL.Token.retornaToken();

                var openOrders = await DAL.OpenOrders.retornaOpenOrders(BLL.Config_Sessao.config);

                File.WriteAllText(@"c:\bta\openOrders.json", 
                    JsonConvert.SerializeObject
                    (
                        openOrders,
                        Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        }
                    ));

                var resposta = await BLL.OpenOrders.enviarOpenOrders(tokenOut.access_token, openOrders);
                
                if (resposta.statusDescription != "OK")
                {
                    MessageBox.Show(resposta.responseFromServer, resposta.statusDescription, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dynamic objResp = JsonConvert.DeserializeObject(resposta.responseFromServer);
                
                    MessageBox.Show(objResp.message.ToString(), objResp.statusReply.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        DateTime agora = DateTime.Now;

        private async void btnMetric_Click(object sender, EventArgs e)
        {
            try
            {
                var tokenOut = await BLL.Token.retornaToken();

                agora = DateTime.Now;

                var metrics = await DAL.Metric_Data.retornaMetricData(BLL.Config_Sessao.config, dtpDate01.Value, dtpDate02.Value);
                int iCount = 1;

                for (int i = 0; i < metrics.Count; i++)
                {
                    iCount++;

                    var objs_Send = new List<DTO.Metric_Data>();

                    for (int j = 0; j < qtde_Registros; j++)
                    {
                        i++;

                        if (i < metrics.Count)
                        {
                            objs_Send.Add(metrics[i]);
                        }
                    }

                    var resposta = await BLL.Metric_Data.enviarMetricData(tokenOut.access_token, objs_Send);

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

                MessageBox.Show("Acabou " + (DateTime.Now - agora).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
