using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsLiquidation;
using fgciams.domain.clsPayee;
using fgciams.domain.clsPettyCash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.LiquidationServices
{
    public interface ILiquidationService
    {
        Task<List<PettyCashModel>> GetPettyCashNotLiquidated(FilterParameter filterParameter, string token);
        Task<LiquidationModel> AddLiquidation(LiquidationModel liquidationModel, string token);
        Task<LiquidationModel> UpdateLiquidation(LiquidationModel liquidationModel, string token);
        Task<List<LiquidationModel>> LiquidationList(FilterParameter filterParameter, string token);
        Task<List<LiquidationModel>> GetLiquidationById(Int64 liquidationId, string token);
        Task<List<LiquidationDetailModel>> LiquidationDetails(Int64 liquidationId, string token);
        Task<LiquidationDetailModel> GetLiquidationDetail(Int64 liquidationDetailId, string token);
        Task<LiquidationModel> UpdateLiquidationStatus(LiquidationModel liquidation, string token);
        Task<List<LiquidationModel>> LiquidationNotRFP(string token);
        Task<List<LiquidationAuditTrailModel>> LiquidationAuditTrail(Int64 liquidationId, string token);
        Task<string> PrintSaveLiquidation(LiquidationModel liquidation);
    }
}
