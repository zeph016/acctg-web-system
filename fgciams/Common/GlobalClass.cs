using System;
using System.Collections.Generic;
using System.Linq;
using fgciams.domain.clsUserAccount;
using fgciams.domain.clsAccountingStatus;
using fgciams.domain.clsRequest;
using fgciams.domain.clsModeOfPayment;
using fgciams.domain.clsEmployee;
using fgciams.domain.clsDivision;
using fgciams.domain.clsBank;
using fgciams.domain.clsProjectChargingLine;
using fgciams.domain.clsPayeeCategory;
using fgciams.domain.clsRequestType;
using fgciams.domain.clsSubcon;
using fgciams.domain.clsSubContractorPosition;
using fgciams.domain.clsSubConGeneralInformation;
using fgciams.domain.clsBillingDocument;
using fgciams.domain.clsPayee;
using fgciams.domain.clsEnums;
using fgciams.domain.clsRFPBillingDocuments;
using fgciams.domain.clsProject;
using fgciams.domain.clsLiquidation;
using fgciams.domain.clsPettyCash;
using fgciams.domain.clsPettyCashAuditTrail;
using fgciams.domain.clsExpenseLine;
using fgciams.domain.clsRequestForPaymentAuditTrail;
using fgciams.domain.clsAccountingPOBilling;
using fgciams.domain.clsVoucher;

namespace fgciams.Common
{
    public static class GlobalClass
    {
        public static string token { get; set; } = string.Empty;
        public static string pageTitle { get; set; } = default!;
        public static bool isUserAuth { get; set; }
        public static string selectedIcon {get;set;} = string.Empty;
        public static object selectedIconType {get;set;} = string.Empty;
        public static UserAccount currentUserAccount { get; set; } = default!; 
        public static RequestForPaymentModel requestForPayment {get; set;} = default!;
        public static AccountingStatusModel acctgStatus { get;  set; } = default!;
        public static BankModel bank {get; set;} = default!;
        public static BillingDocumentModel billingDoc { get; set; } = default!;
        public static DivisionModel division { get; set; } = default!;
        public static ModeOfPaymentModel modeOfPayment { get; set; } = default!;
        public static PayeeModel payee { get; set; } = default!;
        public static PayeeCategoryModel payeeCategory = default!;
        public static ProjectChargingLineModel projectChargingLine {get; set;} = default!;
        public static RequestTypeModel requestType {get; set;} = default!;
        public static SubContractorCompanyModel subContractorCompany {get; set;} = default!;
        public static SubContractorPositionModel subContractorPosition {get; set;} = default!;
        public static SubConGeneralInformationModel subConGeneralInformation {get; set; } = default!;
        public static PettyCashModel pettyCash { get; set; } = default!;
        public static LiquidationModel liquidation {get; set;} = default!;
        public static ExpenseLineModel expenseLine {get; set;} = default!;
        public static LiquidationModel forPrintingOrSaveLiquidation {get; set;} = default!;
        public static RequestForPaymentModel forPrintingOrSaveRFP {get; set; } = default!;
        public static VoucherModel voucher {get; set;} = default!;
        public static VoucherModel forPrintingOrSaveVoucher {get; set;} = default!;
    }
    public static class GlobalClassList
    {
        public static List<AccountingStatusModel> accountingStatusList { get; set; } = default!;
        public static List<RequestForPaymentDetailModel> requestForPayments {get; set;} = default!;
        public static List<ModeOfPaymentModel> modeOfPaymentList { get; set; } = default!;
        public static List<DivisionModel> divisionList {get;set;} = default!;
        public static List<BankModel> banks {get; set;} = default!; 
        public static List<ProjectChargingLineModel> projectChargingLines {get; set;} = default!;
        public static List<PayeeCategoryModel> payeeCategoryList {get;set;} = default!;
        public static List<RequestTypeModel> requestTypes {get; set;} = default!;
        public static List<RFPBillingDocumentModel> RFPBillingDocuments {get; set;} = default!;
        public static List<SubContractorCompanyModel> subContractorCompanies {get; set;} = default!;
        public static List<SubContractorPositionModel> subContractorPositions {get; set;} = default!;
        public static List<SubConGeneralInformationModel> subConGeneralInformations {get; set;} = default!;
        public static List<BillingDocumentModel> billingDocumentList {get;set;} = default!;
        public static List<PayeeModel> payeeList {get;set;} = default!;
        public static List<RequestForPaymentModel> requestForPaymentsList {get; set;} = default!;
        public static List<PettyCashModel> pettyCashList {get;set;} = default!;
        public static List<LiquidationModel> liquidations {get; set;} = default!;
        public static List<LiquidationDetailModel> liquidationDetails {get; set;} = default!;
        public static List<PettyCashModel> liquidationPettyCash {get; set;} = default!;
        public static List<PettyCashModel> listOfPettyCash {get; set;} = default!;
        public static List<PettyCashModel> notLiquidatedPettyCashList {get; set;} = default!;
        public static List<PettyCashAuditTrail> currrentAuditTrail {get; set;} = default!;
        public static List<ExpenseLineModel> expenseLineList {get; set;} = default!;
         public static List<RequestForPaymentAuditTrailModel> rfpAuditTrailList {get; set;} = default!;
        public static List<LiquidationModel> LiquidationNotInRFP {get;set;} = default!;
        public static List<AccountingPOBillingModel> POBillingList {get; set;} = default!;
        public static List<VoucherModel> Vouchers {get; set;} = default!;
    }

    public static class GlobalVariable
    {
        public static bool drawerOpen { get; set; } = true;
        public static bool hideExpandIcon { get; set; }
    }
}