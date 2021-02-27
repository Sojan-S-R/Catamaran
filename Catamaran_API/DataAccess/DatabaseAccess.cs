using Catamaran_API.Models;
using Catamaran_Models.Interfaces;
using Catamaran_Models.Models;
using Catamaran_Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catamaran_API.DataAccess
{
    public static class DatabaseAccess
    {
        public static ITransactionModel FetchTransaction(DataSearchModel search)
        {
            try
            {
                if (search.Month != Months.NotSet)
                {
                    
                }
                else if (search.TransactionId.HasValue)
                {

                }
                else if (search.Year.HasValue)
                {

                }
            }
            catch (Exception ex)
            { 
            
            }
            return new TransactionModel();
        }
    }
}
