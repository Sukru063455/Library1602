using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Contexts
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>// LibraryContext objesini oluşturup kullanılmasını sağlayan fabrika class'ı,
                                                                                    // scaffolding işlemleri için bu class oluşturulmalıdır
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=Library;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;");
            // önce veritabanımızın (development veritabanı kullanılması daha uygundur) connection string'ini içeren bir obje oluşturuyoruz

            return new LibraryContext(optionsBuilder.Options); // daha sonra yukarıda oluşturduğumuz obje üzerinden LibraryContext tipinde bir obje dönüyoruz
        }
    }
    
    
}
