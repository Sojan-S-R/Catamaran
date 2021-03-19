using Catamaran_API.Models;
using Catamaran_Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catamaran_API.DataAccess
{
    public interface IDatabaseAccessManager
    {
        Task<List<TransactionModel>> FetchTransaction(DataSearchModel search);

        Task<int> InsertTransaction(TransactionModel model);
    }
}
