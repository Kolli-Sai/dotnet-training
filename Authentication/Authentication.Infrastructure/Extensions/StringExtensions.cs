using System.Text;

namespace Authentication.Extensions
{
    public static class StringExtensions
    {
        public static byte[] GetByteArray(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }
    }
}
