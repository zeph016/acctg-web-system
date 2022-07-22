using fgciams.domain.clsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsPO
{
    public class POModel
    {
        public POModel()
        {
            POId = 0;
            PODate = DateTime.Now;
            PONumber = "";
            SupplierId = 0;
            SupplierName = "";
            TermsOfPayment = "";
            PlaceOfDelivery = "";
            Remarks = "";
            SupplierAddress = "";
            PRSNumber = "";

            POStatusId = 0;
            StatusDate = DateTime.Now;
            StatusRemarks = "";
            PreparedById = 0;
            PreparedBy = "";
            DeliveryDate = null;
            PRSNumbers = "";
        }
        public Int64 POId { get; set; }
        public DateTime PODate { get; set; }
        public String PONumber { get; set; }
        public Int64 SupplierId { get; set; }
        public String SupplierName { get; set; }
        public String SupplierAddress { get; set; }
        public string PRSNumbers { get; set; }
        public String PRSNumber { get; set; }
        public string TermsOfPayment { get; set; }
        public string PlaceOfDelivery { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Remarks { get; set; }
        public int POStatusId { get; set; }
        public string POStatusView { get; set; } = string.Empty;

        public DateTime StatusDate { get; set; }
        public string StatusRemarks { get; set; }
        public decimal Amount { get; set; }
        public Int64 PreparedById { get; set; }
        public string PreparedBy { get; set; }
    }
}
