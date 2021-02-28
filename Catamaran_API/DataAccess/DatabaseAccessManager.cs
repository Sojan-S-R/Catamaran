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

        private Dictionary<object, object> KeyValues;

        public DatabaseAccessManager(IConfiguration configuration)
        {
            _configuration = configuration;
            KeyValues = new Dictionary<object, object>();
        }

        public async Task<List<TransactionModel>> FetchTransaction(DataSearchModel search)
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

        public async Task<int> InsertTransaction(TransactionModel model)
        {
            int result = 0;
            var connectionString = _configuration.GetConnectionString("CatamaranDB");
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert_Transaction", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionID", model.TransactionId);
            cmd.Parameters.AddWithValue("@TransactionDate", model.TransactionDate);
            cmd.Parameters.AddWithValue("@TransactionAmount", model.TransactionAmount);
            cmd.Parameters.AddWithValue("@Vendor", model.Vendor);
            cmd.Parameters.AddWithValue("@Product", model.Product);
            cmd.Parameters.AddWithValue("@PaymentMode", model.PaymentMethod);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
                await conn.CloseAsync();
            }
            catch (Exception)
            {
                //Add Logging here
            }
            finally 
            {
                await conn.CloseAsync();
            }
            return result;
        }

        private static async Task<List<TransactionModel>> FetchFromDB(Dictionary<object,object> parameterValues)
        {

            List<TransactionModel> returnList = new List<TransactionModel>();
            TransactionModel model = new TransactionModel();
            SqlDataReader rdr = null;

            var connectionString = _configuration.GetConnectionString("CatamaranDB");
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Retreive_Transaction", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var item in parameterValues)
            {
                if (item.Value != null)
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
            }
            try
            {

                conn.Open();
                rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                    //model.TransactionId = (Guid)rdr["TransactionID"];
                    //model.TransactionDate = (DateTime)rdr["TransactionDate"];
                    //model.TransactionAmount = (decimal)rdr["TransactionAmount"];
                    //model.Vendor = (string)rdr["Vendor"];
                    //model.Product = (string)rdr["Product"];
                    //model.PaymentMethod = (PaymentModes)rdr["PaymentMode"];
                    //returnList.Add(model);

                    returnList.Add(
                        new TransactionModel
                        {
                            TransactionId = (Guid)rdr["TransactionID"],
                            TransactionDate = (DateTime)rdr["TransactionDate"],
                            TransactionAmount = (decimal)rdr["TransactionAmount"],
                            Vendor = (string)rdr["Vendor"],
                            Product = (string)rdr["Product"],
                            PaymentMethod = (PaymentModes)rdr["PaymentMode"],
                        });
                    }

            }
            catch (Exception ex)
            {
                ex.ToString();
                //Add logging
            }
            finally 
            {
                await rdr.DisposeAsync();
                conn.Close();
            }
            return returnList;
        }
    }
}
