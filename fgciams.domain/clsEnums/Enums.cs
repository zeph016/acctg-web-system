using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsEnums
{
    public class Enums
    {
      public enum ProjectCategory : byte
        {
            Project = 0,
            OtherDepartment = 1,
            OtherProject = 2,
            Equipment = 3,
            OtherEquipment = 4,
            Employee = 5,
            NonEmployee = 6,
            Section = 7,
            Company = 8,
            PrivateCustomer = 9,
            Product = 10,
            EquipmentNonEmployee = 11,
            Quarry = 12,
            FGDepartment = 13,
            EquipmentPPEType = 14,
            None = 15,
            Payee = 16,
            ProjectChargingLine = 17,
            SubCon = 18,
            Supplier = 19
        }
        public enum AccountingRequestCategory : byte
        {
            [Description("Request For Payment")]
            RFP = 0,
            [Description("Petty Cash")]
            PettyCash = 1
        }
        public enum BankCurrency : byte
        {
            [Description("PHP")]
            PhilippinePeso = 0,
            [Description("USD")]
            UnitedStatesDollar = 1
        }
        public enum Gender : byte
        {
            [Description("Male")]
            Male = 0,
            [Description("Female")]
            Female = 1
        }
        public enum MRARType :byte
        {
            [Description("None")]
            None = 0,
            [Description("MR")]
            MR = 1,
            [Description("AR")]
            AR =2
        }
        public enum AccountingStatusEnumCategory : byte
        {
            [Description("Petty Cash Generated")]
            PCG = 0,
            [Description("Petty Cash Approved")]
            PCA = 1,
            [Description("Petty Cash Cancelled")]
            PCC = 2,
            [Description("Petty Cash Received")]
            PCR = 3,
            [Description("Liquidation Generated")]
            LG = 4,
            [Description("Liquidation Approved")]
            LA = 5,
            [Description("Liquidation Cancelled")]
            LC = 6,
            [Description("Request for Payment Generated")]
            RFPG = 7,
            [Description("Request for Payment Approved")]
            RFPA = 8,
            [Description("Request for Payment Cancelled")]
            RFPC = 9,
            [Description("Petty Cash Liquidated")]
            PCL = 10,
            [Description("Voucher Generated")]
            VG = 11,
            [Description("Voucher Approved")]
            VA = 12,
            [Description("Voucher Cancelled")]
            VC = 13,
            [Description("Check Issued")]
            CI = 14,
            [Description("Check Released")]
            CR = 15,
            [Description("Check Cleared")]
            CCLRD = 16,
            [Description("Check Cancelled")]
            CC = 17,
        }
        public enum RFPDetailTypeId
        {
            [Description("None")]
            None = 0,
            [Description("Liquidation")]
            Liquidation = 1,
            [Description("PO Billing")]
            POBilling = 2,
            [Description("PO")]
            PO = 3,
            [Description("Reversal")]
            Reversal = 4,
            [Description("Labor")]
            Labor = 5
        }
        public enum LookUpType :byte
        {
            [Description("Employee")]
            Employee = 0,
            [Description("Project")]
            Project = 1,
            [Description("Expense Line")]
            ExpLine = 2,
            [Description("Charging Line")]
            ChargeLine = 3,
            [Description("Division")]
            Division = 4,
            [Description("PO Billing")]
            POBilling = 5,
            [Description("Liquidation")]
            Liquidation = 6,
            [Description("Petty Cash")]
            PettyCash = 7,
            [Description("PO")]
            PO = 8,
            [Description("RFP Voucher")]
            RFPVoucher = 9,
            [Description("Voucher")]
            Voucher = 10

        }
        public enum ActionMode : byte
        {
            [Description("Create")]
            Create = 0,
            [Description("Update")]
            Update = 1,
            [Description("Cancel")]
            Cancel = 2,
            [Description("Approve")]
            Approve = 3,
            [Description("Delete")]
            Delete = 4,
            [Description("Receive")]
            Receive = 5,
            [Description("Void")]
            Void = 6,
            [Description("Issue")]
            Issued = 6,
            [Description("Release")]
            Released = 7,
            [Description("Clear")]
            Cleared = 8,
            [Description("Deactivate")]
            Deactivate = 9,
            [Description("Route")]
            Route = 10,
            [Description("Invalid")]
            Invalid = 11,
        }
        public enum AccountReportGroup : byte
        {
            [Description("Balance Sheet")]
            BalanceSheet = 0
        }
        public enum AccountDefaultBalance : byte
        {
            [Description("Debit")]
            Debit = 0,
            [Description("Credit")]
            Credit = 1
        }
        public enum AccountingAccessLevel
        {
            [Description("Administrator")]
            Administrator = 0,
            [Description("Accounting-Admin")]
            AccountingAdmin = 1,
            [Description("Accounting-Requestor")]
            AccountingRequestor = 2,
            [Description("Accounting-Issuer")]
            AccountingIssuer = 3,
            [Description("Accounting-Viewer")]
            AccountingViewer = 4,
            [Description("Others-Requestor")]
            OthersRequestor = 5,
            [Description("Others-Viewer")]
            OthersViewer = 6,
        }
    }
}