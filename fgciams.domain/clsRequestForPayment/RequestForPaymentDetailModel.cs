using fgciams.domain.clsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsRequest
{
    public class RequestForPaymentDetailModel
    {
      public RequestForPaymentDetailModel()
      {
        Id = 0;
        RequestForPaymentId = 0;
        IsActive = true;
        Particulars = "";
        ChargedId = 0;
        ChargedCategoryId = Enums.ProjectCategory.Project;
        ChargedName = "";
        DivisionId = 0;
        DivisionName = "";
        DivisionShortcutName = "";
        Amount = 0;
        Remarks = "";
        POBillingId = 0;
        POBControlNumber = "";
        ExpenseLineId = 0;
        ExpenseLineName = "";
        InvoiceNo = "";
        PONumber = "";
        LiquidationControlNumber = "";

      }
        public Int64 Id { get; set; }
        public Int64 RequestForPaymentId { get; set; }
        public bool IsActive { get; set; }
        public string Particulars { get; set; }
        public Int64 ChargedId { get; set; }
        public Enums.ProjectCategory ChargedCategoryId { get; set; }
        public string ChargedName { get; set; }
        public Int64 DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string DivisionShortcutName { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public Int64 POBillingId { get; set; }
        public string POBControlNumber { get; set; }
        public string OverAllParticulars
        {
            get
            {
                var stringParticulars = "";
                if (!String.IsNullOrEmpty(Particulars))
                {
                    stringParticulars = Particulars + "; ";
                }
                if (!String.IsNullOrEmpty(POBControlNumber))
                {
                    stringParticulars += POBControlNumber + "; ";
                }

                if (!String.IsNullOrEmpty(stringParticulars))
                {
                    stringParticulars = stringParticulars.Remove(stringParticulars.Length - 2, 2);
                }

                return stringParticulars;
            }
        }
        public Int64 ExpenseLineId { get; set; }
        public string ExpenseLineName { get; set; }
        public string InvoiceNo { get; set; }
        public Int64? POId { get; set; }
        public string PONumber { get; set; } = string.Empty;
        public Int64? LiquidationId { get; set; }
        public string LiquidationControlNumber { get; set; } = string.Empty;
        public int TemporaryId {get; set;}
    }
}
