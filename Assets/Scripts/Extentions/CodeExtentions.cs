using System;
/// <summary>
/// this class will handle all the extra extentions needed for our code to work. 
/// </summary>
public static class CodeExtentions 
{
    public static TEnum Parse <TEnum>(this string context) where TEnum : struct, Enum
    {
        if (Enum.TryParse(context, true, out TEnum result))
        {
            return result;
        }
        else
        {
            throw new ArgumentException($"Unable to parse '{context}' to enum type {typeof(TEnum)}");
        }
    }

}
