using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using fgciams.Common;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using fgciams.domain.clsUserAccount;
using fgciams.domain.clsAccountingStatus;
using fgciams.service.UserAccountServices;
using System.IdentityModel.Tokens.Jwt;
using MudBlazor;
using System.Net;

public class Extensions
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
        bool isTokenExist = await CheckGlobalTokenV2(localStorageService);
        bool isAuth;
        if (isTokenExist) {
            return isAuth = isTokenExist ? await AuthenticateToken(userAccountService, GlobalClass.token) : false;
        } else if (!isTokenExist) {
            bool isTokenSet = await GetSetToken(localStorageService, jsRuntimeService);
            return isAuth = isTokenSet ? await AuthenticateToken(userAccountService, GlobalClass.token) : false;
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

    public static async Task<bool> AuthenticateToken(IUserAccountService userAccountService, string token)
    {
        UserAccount userAccount = await userAccountService.AuthenticateToken(new UserAccount(), token);
        GlobalClass.currentUserAccount = userAccount ?? new UserAccount();
        if (GlobalClass.currentUserAccount.httpResponse == System.Net.HttpStatusCode.OK)
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

    public static bool CheckUrlType(string url)
    {
        bool urlType = url.Contains("create") ? true : false;
        return urlType;
    }

    public static string GetIconValue(object iconType, string iconName)
    {
        return iconType.GetType().GetProperty(iconName)?.GetValue(iconType, null)?.ToString() ?? string.Empty;
    }
    public static List<object> IconTypes()
    {
        List<object> icons = new List<object>();
            icons.Add(MudBlazor.Icons.Filled);
            icons.Add(MudBlazor.Icons.Outlined);
            icons.Add(MudBlazor.Icons.Rounded);
            icons.Add(MudBlazor.Icons.Sharp);
            icons.Add(MudBlazor.Icons.TwoTone);
        return icons;
    }
    public static string GetIconPrefix(string iconName)
    {
        return iconName.Split('.')[0]+"."+iconName.Split('.')[1]?? string.Empty;
    }
    public static string GetIconName(string iconName)
    {
        return iconName.Split(".")[2];
    }
    public static object GetIconType(string iconName){
        object obj = new();
        foreach(var icons in IconTypes())
        {
            if(icons.ToString() == GetIconPrefix(iconName)){
                obj =  icons;
                break;
            }
        }
        return obj;
    }
    public static string Icon(string iconName)
    {
        return GetIconValue(GetIconType(iconName),GetIconName(iconName));
    }
    public static string GetAcctgStatusColor(long acctgStatusId)
    {
        var acctgStatus = new AccountingStatusModel();
        acctgStatus = GlobalClassList.accountingStatusList.Where(x => x.Id == acctgStatusId).FirstOrDefault();
        return "background-color:" + acctgStatus?.StatusColor;
    }
    
}
