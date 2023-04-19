using System.Globalization;
using fgciams.domain.clsUserAccount;
using fgciams.domain.clsRequest;
using fgciams.domain.clsModeOfPayment;
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
using fgciams.domain.clsRFPBillingDocuments;
using fgciams.domain.clsPettyCashAuditTrail;
using fgciams.domain.clsExpenseLine;
using fgciams.domain.clsRequestForPaymentAuditTrail;
using fgciams.domain.clsAccountingPOBilling;
using fgciams.domain.clsAccountType;
using fgciams.domain.clsAccountingLine;
using fgciams.domain.clsVoucherRouteBatch;
using fgciams.domain.clsTaxCode;
using fgciams.domain.clsSupplier;
using fgciams.domain.clsTermsOfPayment;
using fgciams.domain.clsMuniCity;
using fgciams.domain.clsBIR;
using fgciams.domain.clsScopeOfWork;
using fgciams.domain.clsSubContractProject;
using fgciams.domain.clsBankDeposit;
using fgciams.domain.clsCheckLedger;
using fgciams.domain.clsVoucherRouteTag;
using fgciams.domain.clsAccessLevel;
using fgciams.domain.clsCustomer;

namespace fgciams.Common
{
    public static class GlobalClass
    {
        public static string token { get; set; } = string.Empty;
        public static string pageTitle { get; set; } = string.Empty;
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
        public static PettyCashModel pettyCash { get; set; } = new();
        public static PettyCashModel pettyCashForPrint { get; set; } = new();
        public static LiquidationModel liquidation {get; set;} = default!;
        public static ExpenseLineModel expenseLine {get; set;} = default!;
        public static LiquidationModel forPrintingOrSaveLiquidation {get; set;} = default!;
        public static RequestForPaymentModel forPrintingOrSaveRFP {get; set; } = default!;
        public static VoucherModel voucher {get; set;} = default!;
        public static VoucherModel forPrintingOrSaveVoucher {get; set;} = default!;
        public static AccountTypeModel accountTypeModel {get; set;} = default!;
        public static AccountLineGroupModel accountLineGroup {get; set;} = default!;
        public static AccountLineTypeModel accountLineType {get; set;} = default!;
        public static CheckModel checkModel {get;set;} = new();
        public static CheckVoucherModel checkVoucher {get;set;} = new();
        public static VoucherRouteBatchModel voucherRouteBatch {get; set; } = default!;
        public static VoucherRouteModel voucherRoute {get;set;} = new();
        public static TaxCodeModel taxCode {get; set;} = new();
        public static SupplierModel supplier {get; set;} = default!;
        public static TermsOfPaymentModel termsOfPayment { get; set; } = default!;
        public static MuniCityModel muniCity {get;set;} = default!;
        public static SupplierContactModel supplierContact {get; set;} = default!;
        public static VoucherBIRModel voucherBIRModel {get;set;} = default!;
        public static ScopeOfWorkModel scopeOfWork  {get;set;} = default!;
        public static BankCheckNumberModel bankCheckNumberModel  {get;set;} = new();
        public static SubContractorProjectModel subContractProject  {get;set;} = new();
        public static Project project  {get;set;} = new();
        public static CollectionModel collection {get;set;} = new();
        public static BankDepositModel bankDeposit {get;set;} = new();
        public static DebitModel debit {get;set;} = new();
        public static ModuleAssigmentModel moduleAssignment {get;set;} = new();
        public static FunctionAssigmentModel functionAssignment {get;set;} = new();
        public static CustomerTypeModel customerType { get;set; } = new();
        public static CustomerModel customer { get;set; } = new();
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
        public static List<PettyCashModel> pettyCashList {get;set;} = new();
        public static List<LiquidationModel> liquidations {get; set;} = default!;
        public static List<LiquidationDetailModel> liquidationDetails {get; set;} = default!;
        public static List<PettyCashModel> liquidationPettyCash {get; set;} = default!;
        public static List<PettyCashModel> listOfPettyCash {get; set;} = default!;
        public static List<PettyCashModel> notLiquidatedPettyCashList {get; set;} = default!;
        public static List<PettyCashAuditTrail> PettyCashAuditTrail {get; set;} = default!;
        public static List<ExpenseLineModel> expenseLineList {get; set;} = default!;
        public static List<RequestForPaymentAuditTrailModel> RFPAuditTrail {get; set;} = default!;
        public static List<LiquidationModel> LiquidationNotInRFP {get;set;} = default!;
        public static List<AccountingPOBillingModel> POBillingList {get; set;} = default!;
        public static List<VoucherModel> Vouchers {get; set;} = new();
        public static List<AccountTypeModel> listOfAccountTypes {get;set;} = default!;
        public static List<AccountLineGroupModel> accountLineGroups {get; set;} = default!;
        public static List<AccountLineTypeModel> accountLineTypes {get; set;} = default!;
        public static List<CheckModel> listOfChecks {get; set;} = new();
        public static List<CheckVoucherModel> listOfCheckVouchers {get; set;} =  default!;
        public static List<VoucherModel> BatchVouchers {get; set;} = default!;
        public static List<VoucherRouteBatchDetailModel> VoucherBatchList {get; set;} = default!;
        public static List<VoucherRouteBatchModel> VoucherBatches {get; set;} = default!;
        public static List<VoucherRouteModel> currentVoucherRoutes {get; set;} =  new();
        public static List<VoucherRouteAuditTrailModel> voucherRouteAuditTrail {get;set;} = default!;
        public static List<TaxCodeModel> taxCodes {get; set;} = default!;
        public static List<VoucherModel> selectedVoucherToRoute {get;set;} = new();
        public static List<SupplierModel> supplierList {get; set;} = default!;
        public static List<TermsOfPaymentModel> termsOfPayments {get; set;} = default!;
        public static List<MuniCityModel>  muniCityList {get;set;} = default!;
        public static List<VoucherModel>  previousVouchers {get;set;} = default!;
        public static List<ScopeOfWorkModel> scopeOfWork  {get;set;} = default!;
        public static List<BankCheckNumberModel> bankCheckNumberList  {get;set;} = default!;
        public static List<SubContractorProjectModel> subContractorProjectist  {get;set;} = default!;
        public static List<Project> projectList  {get;set;} = default!;
        public static List<Project> subConProjectList  {get;set;} = default!;
        public static List<CollectionModel> collectionList {get;set;} = new();
        public static List<CollectionModel> selectedCollections {get;set;} = new();
        public static List<CollectionExpenseModel> collectionExpenses {get;set;} = new();
        public static List<BankDepositModel> bankDepositList {get;set;} = new();
        public static List<CollectionModel> projectLedgerList {get;set;} = new();
        public static List<CheckLedgerModel> checkLegderList {get;set;} = new();
        public static List<DebitModel> debitList {get;set;} = new();
        public static List<VoucherRouteTagUserModel> routeTagUserList {get;set;} = new();
        public static List<VoucherDetailModel> journalList {get;set;} = new();
        public static List<VoucherDetailModel> subconARList {get;set;} = new();
        public static List<VoucherDetailModel> subconAPList {get;set;} = new();
        public static List<VoucherDetailModel> voucherDetailList {get;set;} = new();
        public static List<ModuleAssigmentModel> moduleAssignmentList {get;set;} = new();
        public static List<FunctionAssigmentModel> functionAssignmentList {get;set;} = new();
        public static List<NotificationModel> notificationList {get;set;} = new();
        public static List<CustomerTypeModel> customerTypeList { get;set; } = new();
        public static List<CustomerModel> customerList { get;set; } = new();
        public static List<Project> voucherPayeeList = new();
    }
    public static class GlobalVariable
    {
        public static FilterParameter filterParameter = new FilterParameter();
        public static bool hideExpandIcon { get; set; }
        public static HubConnection? AMSHubConnection {get; set;}
        public static string errorPromptText {get;set;} = string.Empty;
        public static int[] pageSize = new int[] { 15, 30, 45, 60, 75, 90, 100 };
        public static DateTime ServerTime { get; set; } = default!;
        public static string PromptRemarks { get; set; } = string.Empty;
        public static bool DrawerOpen { get; set; }
        public static CultureInfo CulturePh = CultureInfo.GetCultureInfo("en-PH");
        public static int LastPage { get; set; } = 0;
        public static int PageSize { get; set; } = 15;
        public static Enums.FileType FileType { get; set; } = Enums.FileType.PDF;
        public static bool FileDownloading { get; set; } = false;

    }
}