using fgciams.domain.clsBank;
using fgciams.domain.clsFilterParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.BankServices
{
    public interface IBankService
    {
        Task<BankModel> AddBank(BankModel bankModel, string token);
        Task<BankModel> UpdateBank(BankModel bankModel, string token);
        Task<List<BankModel>> LoadBanks(string token);
        Task<BankModel> GetBank(Int64 Id, string token);
        Task<BankCheckNumberModel> AddBankCheckNumber(BankCheckNumberModel model,string token);
        Task<BankCheckNumberModel> UpdateBankCheckNumber(BankCheckNumberModel model,string token);
        Task<List<BankCheckNumberModel>> LoadBankCheckNumber(long id,string token);
        Task<Int64> GetCheckNo(long bankId,string token);
    }
}
