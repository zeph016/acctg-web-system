namespace fgciams.Common
{
    public class AmountToWords
    {
    public static string DecimalToWords(decimal number)
    {
    if (number == 0)
        return "***Zero***";

    if (number < 0)
        return "***Minus " + DecimalToWords(Math.Abs(number)).Substring(3);

    string words = "";

    int intPortion = (int)number;
    decimal fraction = (number - intPortion)*100;
    int decPortion = (int)fraction;

    words = NumberToWords(intPortion)+" Pesos And 0/100 Only";
    if (decPortion > 0)
    {
        words = NumberToWords(intPortion);
        words += " Pesos And ";
        words += decPortion+"/100 Only";
    }
    return String.Format("***{0}***",words);
    }
    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "***Zero***";
        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0){
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;}
        if ((number / 1000) > 0){
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;}
        if ((number / 100) > 0){
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;}
        if (number > 0){
            if (words != "")
                words += "and ";
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Wwelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            if (number < 20)
                words += unitsMap[number];
            else{
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }   
        }
        return words;
    }
    }
}