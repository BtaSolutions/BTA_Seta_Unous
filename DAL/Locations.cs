using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Locations
    {
        public static async Task<List<DTO.Location>> retornaLocations(DTO.Config config)
        {
            NpgsqlConnection psqlConn = new NpgsqlConnection("" +
                 "Server=" + config.server +
                 ";Port=" + config.port +
                 ";User Id=" + config.user +
                 ";Password=" + config.password +
                 ";Database=" + config.database +
                 ";CommandTimeout=5000 " +
                 //";Timeout=1024 " +
                 //";KeepAlive = 10000" +
                 ";Application Name = BTA Seta Unous");

            try
            {
                var objs = new List<DTO.Location>();

                await psqlConn.OpenAsync();

                NpgsqlCommand cmd = new NpgsqlCommand(" select " +
                                                        " * " +
                                                        " from unous_locations " +
                                                        " " +
                                                        " order by 2 desc " +
                                                        "  ", psqlConn);

                NpgsqlDataReader dr = await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    var obj = new DTO.Location();

                    System.Reflection.PropertyInfo[] p = obj.GetType().GetProperties();

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        for (int j = 0; j < p.Count(); j++)
                        {
                            if (p[j].Name.ToLower() == dr.GetName(i).ToLower())
                            {
                                if (dr[i] != DBNull.Value)
                                {
                                    var t = Nullable.GetUnderlyingType(p[j].PropertyType) ?? p[j].PropertyType;
                                    var safeValue = (dr[i] == null) ? null : Convert.ChangeType(dr[i], t);

                                    p[j].SetValue(obj, safeValue);
                                    break;
                                }
                            }
                        }
                    }

                    objs.Add(obj);
                }

                return objs;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await psqlConn.CloseAsync();
            }
        }
    }
}
