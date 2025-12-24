namespace Codespirals.Base.Extensions;
/// <summary>
/// Extensions on <see cref="object"/>
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Check if the object is a String or Char
    /// </summary>
    /// <param name="obj">The object to check</param>
    /// <returns></returns>
    public static bool IsText(this object obj)
    {
        return Type.GetTypeCode(obj.GetType()) switch
        {
            TypeCode.Char or TypeCode.String => true,
            _ => false,
        };
    }
    /// <summary>
    /// Check if the object is any of Byte, Decimal, Double, Int, Byte, Single or Char
    /// </summary>
    /// <param name="obj">The object to check</param>
    /// <returns></returns>
    public static bool IsNumber(this object obj)
    {
        return Type.GetTypeCode(obj.GetType()) switch
        {
            TypeCode.Byte or TypeCode.Decimal or TypeCode.Double or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.SByte or TypeCode.Single or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or TypeCode.Char => true,
            _ => false,
        };
    }

    /// <summary>
    /// Check if the object is any of Byte, Decimal, Double, Int, Byte, Single, Char or String
    /// </summary>
    /// <param name="obj">The object to check</param>
    /// <returns></returns>
    public static bool IsTextOrNumber(this object obj)
    {
        return Type.GetTypeCode(obj.GetType()) switch
        {
            TypeCode.Byte or TypeCode.Decimal or TypeCode.Double or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.SByte or TypeCode.Single or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or TypeCode.Char or TypeCode.String => true,
            _ => false,
        };
    }

    /// <summary>
    /// Check if the object is any of Byte, Decimal, Double, Int, Byte, Single, Bool, Char, DateTime or String
    /// </summary>
    /// <param name="obj">The object to check</param>
    /// <returns></returns>
    public static bool IsBaseType(this object obj)
    {
        return Type.GetTypeCode(obj.GetType()) switch
        {
            TypeCode.Byte or TypeCode.Decimal or TypeCode.Double or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.SByte or TypeCode.Single or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or TypeCode.Boolean or TypeCode.Char or TypeCode.DateTime or TypeCode.String => true,
            _ => false,
        };
    }
}
