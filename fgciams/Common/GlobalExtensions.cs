using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;
using fgciams.Common;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using MudBlazor;
using Microsoft.AspNetCore.SignalR.Client;
using System.IdentityModel.Tokens.Jwt;

using fgciams.domain.clsEnums;
using fgciams.domain.clsUserAccount;
using fgciams.domain.clsAccountingStatus;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsBank;
using fgciams.domain.clsExpenseLine;

using fgciams.service.ExpenseLineServices;
using fgciams.service.GlobalServices;
using fgciams.service.UserAccountServices;
using fgciams.domain.clsProject;
using fgciams.domain.clsRequest;

public static class Extensions
{
    public static bool CheckGlobalToken()
    {
        if (string.IsNullOrWhiteSpace(GlobalClass.token)) {
            return false;
        } else if (!string.IsNullOrWhiteSpace(GlobalClass.token)) {
            return true;
        }
        return false;
    }
    public static async Task<bool> CheckGlobalTokenV2(ILocalStorageService localStorageService)
    {
        GlobalClass.token = await localStorageService.GetItemAsync<string>("token");
        if (!string.IsNullOrWhiteSpace(GlobalClass.token))
            return true;
        return false;
    }

    public static async Task<bool> ValidateToken(IUserAccountService userAccountService, ILocalStorageService localStorageService, IJSRuntime jsRuntimeService)
    {
        bool isTokenExist = await CheckGlobalTokenV2(localStorageService) ? true : await GetSetToken(localStorageService, jsRuntimeService);
        bool isAuthExpired;
        if (isTokenExist) {
            isAuthExpired = isTokenExpired(await localStorageService.GetItemAsync<string>("token"));
            if (!isAuthExpired) {
                await ClearRemainingCookie(jsRuntimeService);
                return await AuthenticateToken(userAccountService, GlobalClass.token);
            }
            else if (isAuthExpired) {
                await GetSetToken(localStorageService, jsRuntimeService);
                return await AuthenticateToken(userAccountService, GlobalClass.token);
            }
        }
        return false;
    }

    public static async Task<bool> GetSetToken(ILocalStorageService localStorageService, IJSRuntime jsRuntimeService)
    {
        var cookieToken = await jsRuntimeService.InvokeAsync<string>("GetCookie", "token");
        if (!string.IsNullOrWhiteSpace(cookieToken)) {
            await localStorageService.SetItemAsync<string>("token", cookieToken);
            GlobalClass.token = await localStorageService.GetItemAsync<string>("token");
            await jsRuntimeService.InvokeAsync<string>("DeleteCookie");
            return true;
        } else if (string.IsNullOrWhiteSpace(cookieToken))
            return false;
        return false;
    }
    public static async Task ClearAllToken(ILocalStorageService localStorageService, IJSRuntime jsRuntimeService)
    {
        await localStorageService.ClearAsync();
        await jsRuntimeService.InvokeAsync<string>("DeleteCookie");
    }

    public static async Task ClearRemainingCookie(IJSRuntime jsRuntimeService)
    {
        await jsRuntimeService.InvokeAsync<string>("DeleteCookie");
    }

    public static async Task<bool> AuthenticateToken(IUserAccountService userAccountService, string token)
    {
        UserAccount userAccount = await userAccountService.AuthenticateToken(new UserAccount(), token);
        GlobalClass.currentUserAccount = userAccount ?? new UserAccount();
        Console.WriteLine(GlobalClass.currentUserAccount.httpResponse);
        if (GlobalClass.currentUserAccount.httpResponse == System.Net.HttpStatusCode.OK 
        && GlobalClass.currentUserAccount.httpResponse != System.Net.HttpStatusCode.Unauthorized)
            return true;
        return false;
    }
    public static string GetEnumDescription(Enum value)  
    {  
        var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();  
        var descriptionAttribute =  
            enumMember == null  
                ? default(DescriptionAttribute)  
                : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;  
        return  
            descriptionAttribute == null  
                ? value.ToString()  
                : descriptionAttribute.Description;  
    }

    public static bool isTokenExpired(string token)
    {
        const int second = 1;
        const int minute = 60 * second;
        const int hour = 60 * minute;

        var handler = new JwtSecurityTokenHandler(); 
        var jwt = handler.ReadJwtToken(token);
        var name = jwt.Claims.First(claim => claim.Type == "unique_name").Value;
        var userId = jwt.Claims.First(claim => claim.Type == "EmployeeId").Value;
        var tokenDate = jwt.Claims.First(claim => claim.Type == "exp").Value;
        DateTime expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(tokenDate)).DateTime;
        
        var ts = new TimeSpan(DateTime.Now.Ticks - expirationTime.Ticks);
        double delta = Math.Abs(ts.TotalSeconds);
        if (delta > 8 * hour)
            return true;
        return false;
    }
    public static void ShowAlert(string message, Variant variant, ISnackbar snackbarService, Severity severityType)
    {
        snackbarService.Clear();
        snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
        snackbarService.Configuration.SnackbarVariant = variant;
        snackbarService.Configuration.MaxDisplayedSnackbars = 10;
        snackbarService.Configuration.VisibleStateDuration = 2000;
        snackbarService.Add($"{message}", severityType);
    }
    public static void ShowAlertV2(string message, Variant variant, ISnackbar snackbarService, Severity severityType, string iconString, string position)
    {
        snackbarService.Clear();
        snackbarService.Configuration.PositionClass = position;
        snackbarService.Configuration.SnackbarVariant = variant;
        snackbarService.Configuration.MaxDisplayedSnackbars = 10;
        snackbarService.Configuration.VisibleStateDuration = 2000;
        snackbarService.Add($"{message}", severityType, config => 
        {
            if (!string.IsNullOrWhiteSpace(iconString)) config.Icon = iconString;
        });
    }

    public static bool CheckUrlType(string url)
    {
        bool urlType = url.Contains("create") ? true : false;
        return urlType;
    }

    public static string GetIconValue(object iconType, string iconName)
    {
        return iconType.GetType().GetProperty(iconName)?.GetValue(iconType, null)?.ToString() ?? string.Empty;
    }
    public static string GetIconPrefix(string iconName)
    {
        return iconName.Split('.')[0]+"."+iconName.Split('.')[1]?? string.Empty;
    }
    public static string GetIconName(string iconName)
    {
        return iconName.Split(".")[2];
    }
    public static string Icon(string iconName)
    {
        // return GetIconValue(GetIconType(iconName),GetIconName(iconName));
        return string.Empty;
    }
    public static string GetAcctgStatusColor(long acctgStatusId)
    {
        var acctgStatus = new AccountingStatusModel();
        acctgStatus = GlobalClassList.accountingStatusList.Where(x => x.Id == acctgStatusId).FirstOrDefault();
        return "background-color:" + acctgStatus?.StatusColor;
    }
    public static string BorderColor(long statusId)
    {
        var acctgStatus = GlobalClassList.accountingStatusList.Where(x=>x.Id == statusId).FirstOrDefault();
        if (acctgStatus != null)
            return "border-color:" + acctgStatus.StatusColor;
        return string.Empty;
    }
    public static string FontColor(long statusId)
    {
        var acctgStatus = GlobalClassList.accountingStatusList.Where(x=>x.Id == statusId).FirstOrDefault();
        if (acctgStatus != null)
            return "color:" + acctgStatus.StatusColor;
        return string.Empty;
    }
     public static string BGColor(long statusId)
    {
        var acctgStatus = GlobalClassList.accountingStatusList.Where(x=>x.Id == statusId).FirstOrDefault();
        if (acctgStatus != null)
            return "background-color:" + acctgStatus.StatusColor + ";color:white";
        return string.Empty;
    }
    public static HubConnection ConnectionBuilder(string connection)
    {
      HubConnection hubConnection = new HubConnectionBuilder()
      .WithUrl(connection)
      .WithAutomaticReconnect()
      .Build();

       return hubConnection;
    }
    

    //NOT USED FOR NOW - MIGHT BE USED IN THE FUTURE
    public static ValueTask FocusAsync(this IJSRuntime jSRuntimeService, string className)
    {
        return jSRuntimeService.InvokeVoidAsync("AutoFocusElement", className);
    }

    public static async Task<IEnumerable<UserAccount>> LoadEmployeesExt(IGlobalService globalService, string employeeName)
    {
        var filterParameter = new FilterParameter()
        {
            IsName = true,
            Name = employeeName,
            IsLookUp = true
        };
        var employee = await globalService.LoadAllEmployee(filterParameter, GlobalClass.token);
        return employee;
    }

    public static async Task CopyTextToClipboard(string strToCopy, ISnackbar snackbarService, IJSRuntime JSRuntime)
    {
        await JSRuntime.InvokeAsync<object>("copyToClipboard", strToCopy);
        ShowAlert("Copied to clipboard.", Variant.Filled, snackbarService, Severity.Normal);
    }
    public static string BankShortCutName(long bankID)
    {
        return GlobalClassList.banks.Where( bank => bank.Id == bankID)
            .SelectMany( bank => new List<string> { bank.ShortcutName, bank.AccountNo })
            .Aggregate( ( shortcutName, accountNumber ) => shortcutName+" | "+accountNumber);
    }
    public static string DivisionShorcutName(long divId)
    {
        return GlobalClassList.divisionList.Where( div => div.Id == divId)
            .Select( div => div.shortcutName).FirstOrDefault()?? string.Empty;
    }
    public static async Task<IEnumerable<BankModel>> SearchBank(string bankAccount, bool isDistinct)
    {
        var banks = GlobalClassList.banks;
        if(isDistinct)
        {
            return await Task.FromResult(banks.Where(x => x.AccountNo.Contains(bankAccount, StringComparison.OrdinalIgnoreCase)
            || x.BankName.Contains(bankAccount, StringComparison.OrdinalIgnoreCase) || x.ShortcutName.Contains(bankAccount, StringComparison.OrdinalIgnoreCase))
            .DistinctBy( b => b.BankName).ToList());
        } else 
        {
            return await Task.FromResult(banks.Where(x => x.AccountNo.Contains(bankAccount, StringComparison.OrdinalIgnoreCase)
            || x.BankName.Contains(bankAccount, StringComparison.OrdinalIgnoreCase) || x.ShortcutName.Contains(bankAccount, StringComparison.OrdinalIgnoreCase))
            .ToList());
        }
    }
    public static Enums.SupplierCategory POSupplierCategory(Enums.ProjectCategory cat)
    {
        if(cat == Enums.ProjectCategory.Project)
            return Enums.SupplierCategory.Project;
        else if(cat == Enums.ProjectCategory.FGDepartment)
            return Enums.SupplierCategory.Department;
        else if(cat == Enums.ProjectCategory.Section)
            return Enums.SupplierCategory.Section;
        else if(cat == Enums.ProjectCategory.OtherProject)
            return Enums.SupplierCategory.OtherProject;
        return Enums.SupplierCategory.Supplier;
    }
    //Usage Extensions.InvokeSignalR<ModelName>(arguments);
    public static void InvokeSignalR<T>(string endPoint, MudTable<T> tableVariable, Action refresh)
    {
        if(GlobalVariable.AMSHubConnection != null)
            GlobalVariable.AMSHubConnection.On<T>(endPoint, async (modelName) => 
            {
                //this method is working but reload table not working
                await tableVariable.ReloadServerData();
                refresh.Invoke();
                Console.WriteLine("Test");
            });
    }

    public static string DetermineActionTaken(string activity)
    {
        if(activity.Contains("Create", StringComparison.InvariantCultureIgnoreCase) || activity.Contains("Add Liquidation", StringComparison.InvariantCultureIgnoreCase))
            return Enums.ActionMode.Create.ToString();
        if(activity.Contains("Approve", StringComparison.InvariantCultureIgnoreCase))
            return Enums.ActionMode.Approve.ToString();
        if(activity.Contains("Update", StringComparison.InvariantCultureIgnoreCase) || activity.Contains("Edit", StringComparison.InvariantCultureIgnoreCase))
            return Enums.ActionMode.Update.ToString();
        if(activity.Contains("Cancel", StringComparison.InvariantCultureIgnoreCase))
            return Enums.ActionMode.Cancel.ToString();
        if(activity.Contains("Receive", StringComparison.InvariantCultureIgnoreCase))
            return Enums.ActionMode.Receive.ToString();
        if(activity.Contains("Liquidated", StringComparison.InvariantCultureIgnoreCase))
            return "Liquidated";
        return string.Empty;
    }

    public static string DetermineActionColor(bool isBGColor, string activity, string moduleName)
    {
        AccountingStatusModel accountingStatusModel = new();
        var enumsKeyWord = new Enums.AccountingStatusEnumCategory();
        if(activity.Contains("Create", StringComparison.InvariantCultureIgnoreCase) || activity.Contains("Add", StringComparison.InvariantCultureIgnoreCase))
        {
            if(moduleName.Equals("pettyCash", StringComparison.InvariantCultureIgnoreCase))
                enumsKeyWord = Enums.AccountingStatusEnumCategory.PCG;
            if(moduleName.Equals("liquidation", StringComparison.InvariantCultureIgnoreCase))
                enumsKeyWord = Enums.AccountingStatusEnumCategory.LG;
        }
           
        if(activity.Contains("Approve", StringComparison.InvariantCultureIgnoreCase) || activity.Contains("Approved", StringComparison.InvariantCultureIgnoreCase))
        {
            if(moduleName.Equals("pettyCash", StringComparison.InvariantCultureIgnoreCase))
                enumsKeyWord = Enums.AccountingStatusEnumCategory.PCA;
            if(moduleName.Equals("liquidation", StringComparison.InvariantCultureIgnoreCase))
                enumsKeyWord = Enums.AccountingStatusEnumCategory.LA;
        }
        if(activity.Contains("Cancel", StringComparison.InvariantCultureIgnoreCase))
        {
            if(moduleName.Equals("pettyCash", StringComparison.InvariantCultureIgnoreCase))
                enumsKeyWord = Enums.AccountingStatusEnumCategory.PCC;
        }
        if(activity.Contains("Receive Petty Cash", StringComparison.InvariantCultureIgnoreCase))
        {
            if(moduleName.Equals("pettyCash", StringComparison.InvariantCultureIgnoreCase))
                enumsKeyWord = Enums.AccountingStatusEnumCategory.PCR;
        }
        if(activity.Contains("Liquidated", StringComparison.InvariantCultureIgnoreCase)) 
        {
            if(moduleName.Equals("pettyCash", StringComparison.InvariantCultureIgnoreCase))
                enumsKeyWord = Enums.AccountingStatusEnumCategory.PCL;
        }
           
        if(activity.Contains("Update", StringComparison.InvariantCultureIgnoreCase) || activity.Contains("Edit", StringComparison.InvariantCultureIgnoreCase))
        {
            if (isBGColor)
                return "background-color: lightblue";
            else 
                return "border-color: lightblue";
        }

        accountingStatusModel = GlobalClassList.accountingStatusList.Find(x=> x.StatusEnumCategoryId == enumsKeyWord) ?? accountingStatusModel;

        if (isBGColor)
            return BGColor(accountingStatusModel.Id) ?? string.Empty;
        else 
            return BorderColor(accountingStatusModel.Id) ?? string.Empty;
    }
    public static async Task<IEnumerable<ExpenseLineModel>> LoadExpense(string expenseLine, IExpenseLineService expenseLineService)
    {
      var charging = await expenseLineService.LoadExpenseLine(GlobalClass.token);
      return charging.Where(x=>x.ExpenseName.Contains(expenseLine, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public static string ProjectReference(Project project)
    {
        if(GlobalClassList.payeeList.Where( p => p.Id == project.ProjectId && p.PayeeName == project.ProjectName).FirstOrDefault() != null)
            return "[AIS Payee List]";
        switch(project.ProjectCategoryId)
        {
            case Enums.ProjectCategory.Supplier:
                return "[POBS Supplier Masterlist]";
            case Enums.ProjectCategory.Employee:
                return "[Employee Masterlist]";
            case Enums.ProjectCategory.Company:
                return "[Company Masterlist]";
            case Enums.ProjectCategory.Project:
                return "[Project Masterlist]";
            case Enums.ProjectCategory.Product:
                return "[Product Masterlist]";
            case Enums.ProjectCategory.Equipment:
                return "[Equipment Masterlist]";
            case Enums.ProjectCategory.OtherDepartment:
                return "[Other Department]";
            case Enums.ProjectCategory.OtherProject:
                return "[Other Project]";
            case Enums.ProjectCategory.OtherEquipment:
                return "[Other Equipment]";
            case Enums.ProjectCategory.NonEmployee:
                return "[Non Employee]";
            case Enums.ProjectCategory.PrivateCustomer:
                return "[Private Customer]";
            case Enums.ProjectCategory.EquipmentNonEmployee:
                return "[Equipmen Non Employee]";
            case Enums.ProjectCategory.FGDepartment:
                return "[FG Department Masterlist]";
            case Enums.ProjectCategory.EquipmentPPEType:
                return "[Equipment PPE Type]";
            case Enums.ProjectCategory.ProjectChargingLine:
                return "[Project Charging Line]";
            default:
                return String.Format("[{0}]", project.ProjectCategoryId.ToString());
        }
    }
    public static ExpenseLineModel DefaultExpenseNone()
    {
        return GlobalClassList.expenseLineList.Where( ex => ex.ExpenseName == "None").FirstOrDefault()?? new();
    }
}
