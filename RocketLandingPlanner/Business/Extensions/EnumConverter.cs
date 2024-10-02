using System.ComponentModel;
using System.Reflection;

namespace RocketLandingPlanner.Business.Extensions
{
    public static class EnumConverter
    {
        public static string GetDescription(this Enum e)
        {
            var attribute =
                e.GetType()
                    .GetTypeInfo()
                    .GetMember(e.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault()
                    as DescriptionAttribute;

            return attribute?.Description ?? e.ToString();

            #region Açıklamalar
            //Roket iniş isteğine cevaben dönülecek 3 adet servis cevabının enum değerlerini açıklama olarak
            //basmak amaçlı eklenmiş bir .Net extension metodudur.
            #endregion
        }
    }
}
