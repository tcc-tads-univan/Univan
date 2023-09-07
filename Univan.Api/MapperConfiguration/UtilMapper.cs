using System.Text.RegularExpressions;

namespace Univan.Api.MapperConfiguration
{
    public static class UtilMapper
    {
        private static Regex regex = new Regex(@"[^\d]");
        public static string CleanCpf(string cpf)
        {
            return regex.Replace(cpf, "");
        }
        public static string CleanPhone(string phoneNumber)
        {
            return regex.Replace(phoneNumber, "");
        } 
        
        public static string CleanCnh(string cnh)
        {
            return regex.Replace(cnh, "");
        }

        public static Stream GetPictureValue(IFormFile image)
        {
            return image is null ? Stream.Null : image.OpenReadStream();
        }
    }
}
