using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Config_Sessao
    {
        public static DTO.Config config { get; set; }

        public static void carregarConfig(string directory)
        {
            try
            {
                string path = System.IO.Path.Combine(directory, "config.json");

                if (System.IO.File.Exists(path))
                {
                    //pego o json da config e transforma em objeto
                    var configLocal = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.Config>(System.IO.File.ReadAllText(path));

                    //preciso tirar a criptografia dos campos
                    config = new DTO.Config
                    {
                        server      = Crypt.Decrypt(configLocal.server),
                        port        = Crypt.Decrypt(configLocal.port),
                        database    = Crypt.Decrypt(configLocal.database),
                        user        = Crypt.Decrypt(configLocal.user),
                        password    = Crypt.Decrypt(configLocal.password)
                    };
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
