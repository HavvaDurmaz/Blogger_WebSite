namespace Blogger_WebSite.Areas.admin.Data
{
    public class DosyaYukleme
    {
        public static string Yukle(IFormFile file)
        {

            string Uzanti = Path.GetExtension(file.FileName);
            if (Uzanti == ".jpg" || Uzanti == ".png" || Uzanti == ".jpeg")
            {

                string YeniDosyaAdi = new Random().Next(1, 999999999) + Uzanti;
                string YuklenecekAdres = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images", YeniDosyaAdi);
                using (var stream = new FileStream(YuklenecekAdres, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }
                return YeniDosyaAdi;
            }
            else
            {
                return "0";
            }
        }
    }
}
