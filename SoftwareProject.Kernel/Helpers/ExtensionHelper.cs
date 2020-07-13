using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SoftwareProject.Associate.Helpers
{
    public static class ExtensionHelper
    {//toshort To double hepsi için yapılabilir.Şuan string için yapıcaz.
        #region Object Extensions
        public static string ToString(this object obj, string defaultValue)
        {
            try
            {
                return obj?.ToString() ?? defaultValue;

            }
            catch (Exception)
            {

                return defaultValue;
            }
        }
        public static int ToInt(this object obj, int defaultValue = int.MinValue)
        {
            if (obj == null || obj.ToString() == String.Empty)
            {
                if (defaultValue != int.MinValue)
                {
                    return defaultValue;
                }
                throw new NullReferenceException("Source objcet to be converted top Int32 is null");
            }
            return Convert.ToInt32(obj);
        }
        #endregion


        #region Type Extension
        public static object GetDefaultValue(this Type t)//ne olduğunu bilmiyoruz type geçiyoruz.
        {
            if (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
            {
                return Activator.CreateInstance(t);//Type'instance'ını create etmiş oluyoruz.
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Generic Type Extension
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable..!", source.ToString());
            }

            if (ReferenceEquals(source, null))//eşit mi değil mi
            {
                return default(T);//Null'sa bana t'yi gönder.
            }
            IFormatter formatter = new BinaryFormatter();//Canlıda serriliaze et.
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
        #endregion
        public static string FormatWith(this string format, params object[] values)
        {
            return string.Format(format, values);
        }
    }
}
