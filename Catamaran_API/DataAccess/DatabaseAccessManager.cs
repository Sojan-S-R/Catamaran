using Catamaran_API.Models;
using Catamaran_Models.Enums;
using Catamaran_Models.Interfaces;
using Catamaran_Models.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Catamaran_API.DataAccess
{
    public class DatabaseAccessManager
    {
        private static IConfiguration _configuration { get; set; }
        private static Dictionary<object, object> KeyValues;

        public DatabaseAccessManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static async Task<List<TransactionModel>> FetchTransaction(DataSearchModel search)
        {
            KeyValues.Add("@TransactionID", null);
            KeyValues.Add("@TransactionMonth", null);
            KeyValues.Add("@TransactionYear", null);

            if (search.Month != Months.NotSet)
            {
                KeyValues["@TransactionMonth"] = search.Month;
                return await FetchFromDB(KeyValues);
            }
            else if (search.TransactionId.HasValue)
            {
                KeyValues["@TransactionId"] = search.TransactionId;
                return await FetchFromDB(KeyValues);
            }
            else if (search.Year.HasValue)
            {
                KeyValues["@TransactionYear"] = search.Year;
                return await FetchFromDB(KeyValues);
            }
            return null;
        }

        private static async Task<List<TransactionModel>> FetchFromDB(Dictionary<object,object> parameterValues)
        {

            List<TransactionModel> returnList = new List<TransactionModel>();
            TransactionModel model = new TransactionModel();
            try
            {
                var connectionString = _configuration.GetConnectionString("CatamaranDB");
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Retreive_Transaction", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@TransactionID", System.Data.SqlDbType.UniqueIdentifier).Value = "";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                        model.TransactionId = (Guid)rdr["TransactionID"];
                        model.TransactionDate = (DateTime)rdr["TransactionDate"];
                        model.TransactionAmount = (long)rdr["TransactionAmount"];
                        model.Vendor = (string)rdr["Vendor"];
                        model.Product = (string)rdr["Product"];
                        model.PaymentMethod = (PaymentModes)Enum.Parse(typeof(PaymentModes), (string)rdr["PaymentMode"], true);
                        returnList.Add(model);
                }
                await rdr.DisposeAsync();
                conn.Close();
            }
            catch (Exception)
            {
                return null;
            }
            return returnList;
        }
    }
}
