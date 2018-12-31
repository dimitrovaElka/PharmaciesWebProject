using Pharmacies.Data;
using Pharmacies.Models;
using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacies.Web.Utilities
{
    public class SeederFromFiles
    {
        public const string FileWithGenericsNames = "/wwwroot/files/Prilojenie2.txt";

        public async static Task SeedGenerics(PharmaciesDbContext context)
        {
            if (!context.GenericMedicaments.Any())
            {
                var directoryInfo = Directory.GetCurrentDirectory();
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(directoryInfo+FileWithGenericsNames))
                    {
                        
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            var gen = Encoding.UTF8.GetBytes(line);
                            //var sb = new StringBuilder();
                            //foreach (var item in gen)
                            //{
                            //    sb.Append((char)item);
                            //}
                            
                            string name = new string(gen);

                            var currentGeneric = new GenericMedicament { Name = name };
                            await context.GenericMedicaments.AddAsync(currentGeneric);
                            line = sr.ReadLine();
                        }
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
                
               
                //try
                //{
                //    await context.SaveChangesAsync();
                //}
                //catch (Exception)
                //{
                //    throw new Exception("Something wrong in PharmaciesDbContext");
                //}
            }
        }
    }
}
