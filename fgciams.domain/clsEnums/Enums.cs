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
            Supplier = 19,
            ProjectCustomer = 20,
            Bank = 21
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
        public enum MRARType : byte
        {
            [Description("None")]
            None = 0,
            [Description("MR")]
            MR = 1,
            [Description("AR")]
            AR = 2
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
            [Description("Collection Generated")]
            CLG = 18,
            [Description("Collection Approved")]
            CLA = 19,
            [Description("Collection Cancelled")]
            CLC = 20
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
        public enum LookUpType : byte
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
            Issue = 6,
            [Description("Release")]
            Release = 7,
            [Description("Clear")]
            Clear = 8,
            [Description("Deactivate")]
            Deactivate = 9,
            [Description("Route")]
            Route = 10,
            [Description("Invalid")]
            Invalid = 11,
            [Description("Prompt")]
            Prompt = 12
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
        public enum AuditTrailMode
        {
            [Description("Petty Cash Audit Trail")]
            PettyCashTrail = 0,
            [Description("Liquidation Audit Trail")]
            LiquidationTrail = 1,
            [Description("Check Audit Trail")]
            CheckTrail = 2,
            [Description("Collection Audit Trail")]
            CollectionTrail = 3,
            [Description("Request for Payment Trail")]
            RFPTrail = 4,
            [Description("Voucher Trail")]
            VoucherTrail = 5,
            [Description("Voucher Batch Trail")]
            VoucherBatch = 6,
            [Description("Debit Trail")]
            DebitTrail = 7
        }
        public enum CollectionCategory
        {
            [Description("P")]
            P = 0,
            [Description("C-Admin")]
            C = 1,
            [Description("AR")]
            AR = 2,
            [Description("CA")]
            CA = 3,
            [Description("Others")]
            Others = 4
        }
        public enum CollectionType
        {
            [Description("Collection")]
            Collection = 0,
            [Description("Billing")]
            Billing = 1
        }
        public enum CollectionPaymentType
        {
            [Description("Cash")]
            Cash = 0,
            [Description("Check")]
            Check = 1,
            [Description("Direct Deposit")]
            DirectDeposit = 2
        }
        public enum AccountReportGroup
        {
            [Description("Balance Sheet")]
            BalanceSheet = 0,
            [Description("Income Statement")]
            IncomeStatement = 1
        }
        public enum SupplierCategory
        {
            Supplier = 0,
            Project = 1,
            Department = 2,
            Section = 3,
            OtherProject = 4
        }
        public enum RouteTag
        {
            [Description("None")]
            None = 0,
            [Description("Govt/EBenefits")]
            GovEBenefit = 1,
            [Description("Billing")]
            Billing = 2,
            [Description("Issuance & Processing")]
            IssuanceAndProcessing = 3,
            [Description("Others")]
            Others = 4
        }
        public enum LaborType
        {
            [Description("None")]
            None = 0,
            [Description("Labor Only")]
            LaborOnly = 1,
            [Description("Labor & Materials")]
            LaborMaterials = 2
        }
        public enum FinancialCapabilityCategory
        {
            [Description("None")]
            None = 0,
            [Description("A")]
            A = 1,
            [Description("B")]
            B = 2,
            [Description("C")]
            C = 3
        }
        public enum CheckCategory
        {
            [Description("None")]
            None = 0,
            [Description("Check")]
            Check = 1,
            [Description("Direct-Deposit")]
            DirectDeposit = 2
        }
        public enum AISUserAccessLevel
        {
            [Description("Administrator")]
            Administrator = 0,
            [Description("Accounting-Billing-Admin")]
            AccountingBillingAdmin = 1,
            [Description("Accounting-Billing-Encoder")]
            AccountingBillingEncoder = 2,
            [Description("Accounting-GovEben-Admin")]
            AccountingGovEbenAdmin = 3,
            [Description("Accounting-GovEben-Encoder")]
            AccountingGovEbenEncoder = 4,
            [Description("Accounting-Issuance-Admin")]
            AccountingIssuanceAdmin = 5,
            [Description("Accounting-Issuance-Encoder")]
            AccountingIssuanceEncoder = 6,
            [Description("Accounting-Disbursing-Admin")]
            AccountingDisbursingAdmin = 7,
            [Description("Accounting-Disbursing-Encoder")]
            AccountingDisbursingEncoder = 8,
            [Description("Accounting-Collection-Admin")]
            AccountingCollectionAdmin = 9,
            [Description("Accounting-Collection-Encoder")]
            AccountingCollectionEncoder = 10,
            [Description("Accounting-Payroll-Admin")]
            AccountingPayrollAdmin = 11,
            [Description("Accounting-Payroll-Encoder")]
            AccountingPayrollEncoder = 12,
            [Description("Accounting-Viewer")]
            AccountingViewer = 13,
            [Description("Non-Accounting - Admin")]
            NonAccountingAdmin = 14,
            [Description("Non-Accounting - Requestor")]
            NonAccountingRequestor = 15,
            [Description("Non-Accounting - Viewer")]
            NonAccountingViewer = 16
        }
        public enum AISModules
        {
            [Description("Dashboard")]
            Dashboard = 0,
            [Description("Petty Cash Entry")]
            PettyCashEntry = 1,
            [Description("Petty Cash List")]
            PettyCashList = 2,
            [Description("Liquidation Entry")]
            LiquidationEntry = 3,
            [Description("Liquidation List")]
            LiquidationList = 4,
            [Description("Request For Payment Entry")]
            RequestForPaymentEntry = 5,
            [Description("Request For Payment List")]
            RequesitForPaymentList = 6,
            [Description("Voucher Entry")]
            VoucherEntry = 7,
            [Description("Voucher List")]
            VoucherList = 8,
            [Description("BIR")]
            BIR = 9,
            [Description("Voucher Route")]
            VoucherRoute = 10,
            [Description("Batch Entry")]
            BatchEntry = 11,
            [Description("Batch List")]
            BatchList = 12,
            [Description("Check Writer Entry")]
            CheckWriteEntry = 13,
            [Description("Check Writer List")]
            CheckWriterList = 14,
            [Description("Debit Entry")]
            DebitEntry = 15,
            [Description("Debit List")]
            DebitList = 16,
            [Description("Direct Deposit Entry")]
            DirectDepositEntry = 17,
            [Description("Direct Deposit List")]
            DirectDepositList = 18,
            [Description("Collection Entry")]
            CollectionEntry = 19,
            [Description("Collection List")]
            CollectionList = 20,
            [Description("Billing Entry")]
            BillingEntry = 21,
            [Description("Billing List")]
            BillingList = 22,
            [Description("Bank Deposit Entry")]
            BankDepositEntry = 23,
            [Description("Bank Deposit List")]
            BankDepositList = 24,
            [Description("Accounting Status")]
            AccountingStatus = 25,
            [Description("Bank")]
            Bank = 26,
            [Description("Billing Document")]
            BillingDocument = 27,
            [Description("Division")]
            Division = 28,
            [Description("Mode of Payment")]
            ModeofPayment = 29,
            [Description("Payee")]
            Payee = 30,
            [Description("Payee Category")]
            PayeeCategory = 31,
            [Description("Project Charging Line")]
            ProjectChargingLine = 32,
            [Description("Request Types")]
            RequestTypes = 33,
            [Description("Subcon")]
            Subcon = 34,
            [Description("Charts of Accounts")]
            ChartsofAccounts = 35,
            [Description("Supplier")]
            Supplier = 36,
            [Description("Voucher Tag")]
            VoucherTag = 37,
            [Description("AR Ledger")]
            ARLedger = 38,
            [Description("AP Ledger")]
            APLedger = 39,
            [Description("Bank Ledger")]
            BankLedger = 40,
            [Description("Sub-con Ledger")]
            SubconLedger = 41,
            [Description("Sub-con AR Ledger")]
            SubconARLedger = 42,
            [Description("Sub-con AP Ledger")]
            SubconAPLedger = 43,
            [Description("OR Listing")]
            ORListing = 44,
            [Description("Project Ledger")]
            ProjectLedger = 45,
            [Description("Journal")]
            Journal = 46,
            [Description("VAT")]
            VAT = 47,
            [Description("User Privilege")]
            UserPrivilege = 48,
        }
        public enum AISModuleFunctions
        {
            [Description("None")]
            None = 0,
            [Description("Add")]
            Add = 1,
            [Description("Edit(All)")]
            Edit = 2,
            [Description("Delete")]
            Delete = 3,
            [Description("Cancel")]
            Cancel = 4,
            [Description("Void")]
            Void = 5,
            [Description("View(All)")]
            View = 6,
            [Description("Change Status")]
            ChangeStatus = 7,
            [Description("BIR")]
            BIR = 8,
            [Description("Deposit")]
            Deposit = 9,
            [Description("View(Department)")]
            ViewDepartment = 10,
            [Description("View(Own)")]
            ViewOwn = 11,
            [Description("Edit(Own)")]
            EditOwn = 12,
            [Description("Edit(Department)")]
            EditDepartment = 13
        }
        public enum AISParentModules
        {
            [Description("Dashboard")]
            Dashboard = 0,
            [Description("Petty Cash")]
            PettyCash = 1,
            [Description("Liquidation")]
            Liquidation = 2,
            [Description("Request For Payment")]
            RequestForPayment = 3,
            [Description("Voucher")]
            Voucher = 4,
            [Description("Check Writer")]
            CheckWriter = 5,
            [Description("Voucher Route")]
            VoucherRoute = 6,
            [Description("Collections")]
            Collections = 7,
            [Description("Ledgers")]
            Ledgers = 8,
            [Description("Settings")]
            Settings = 10
        }
        public enum StatusAction
        {
            Approve = 0,
            Cancel = 1,
            Generate = 2,
            Receive = 2
        }
        public enum CustomerType : byte
        {
            [Description("Private")]
            PrivateType = 1,
            [Description("Semi Private")]
            SemiPrivate = 2,
            [Description("Government")]
            Government = 3,
        }
        public enum FileType : byte
        {
            [Description("PDF")]
            PDF = 1,
            [Description("EXCEL")]
            EXCEL = 2,
        }

        public enum NotificationViewType : byte
        {
            [Description("All")]
            All = 0,
            [Description("Read")]
            Read = 1,
            [Description("Unread")]
            Unread = 2
        }
    }
}