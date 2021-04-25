using Microsoft.AspNetCore.Identity;
using Sewit.Contracts;
using Sewit.Data;
using Sewit.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, 
                                ITopComponentRepository topComponentRepository,
                                ISkirtComponentRepository skirtComponentRepository,
                                ISleeveComponentRepository sleeveComponentRepository, 
                                IDressRepository dressRepository,
                                IInitRepository initRepository)
        {
            var alreadyInit = SeedInit(initRepository);
            if (alreadyInit)
            {
                return;
            }
            SeedAdmin(userManager);
            SeedTops(topComponentRepository);
            SeedSkirts(skirtComponentRepository);
            SeedSleeves(sleeveComponentRepository);
            SeedDresses(dressRepository, topComponentRepository, skirtComponentRepository, sleeveComponentRepository);
        }

        private static bool SeedInit(IInitRepository initRepository)
        {
            return initRepository.IsInit();
        }


        private static void SeedAdmin(UserManager<IdentityUser> userManager)
        {
            var admin = new IdentityUser
            {
                Email = "admin@admin.com",
                UserName = "admin"
            };
            var result = userManager.CreateAsync(admin, "admin").Result;
            
        }

        private static void SeedTops(ITopComponentRepository topComponentRepository)
        {
            using (FileStream fs = File.Open("DataInit\\tops.csv", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(fs);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(new string[] { "," });

                bool first = true;
                while (!parser.EndOfData)
                {

                    // 0: name, 1: path
                    string[] row = parser.ReadFields();
                    if (first)
                    {
                        first = false;
                        continue;
                    }


                    var top = new TopComponent
                    {
                        Name = row[0],
                        PhotoPath = row[1]
                    };

                    topComponentRepository.Create(top);
                }
            }
        }

        private static void SeedSkirts(ISkirtComponentRepository skirtComponentRepository)
        {
            using (FileStream fs = File.Open("DataInit\\skirts.csv", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(fs);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(new string[] { "," });

                bool first = true;
                while (!parser.EndOfData)
                {

                    // 0: name, 1: path
                    string[] row = parser.ReadFields();
                    if (first)
                    {
                        first = false;
                        continue;
                    }


                    var skirt = new SkirtComponent
                    {
                        Name = row[0],
                        PhotoPath = row[1]
                    };

                    skirtComponentRepository.Create(skirt);
                }
            }
        }

        private static void SeedSleeves(ISleeveComponentRepository sleeveComponentRepository)
        {
            using (FileStream fs = File.Open("DataInit\\sleeves.csv", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(fs);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(new string[] { "," });

                bool first = true;
                while (!parser.EndOfData)
                {

                    // 0: name, 1: path
                    string[] row = parser.ReadFields();
                    if (first)
                    {
                        first = false;
                        continue;
                    }


                    var sleeve = new SleeveComponent
                    {
                        Name = row[0],
                        PhotoPath = row[1]
                    };

                    sleeveComponentRepository.Create(sleeve);
                }
            }
        }


        private static void SeedDresses(IDressRepository dressRepository, 
                                        ITopComponentRepository topComponentRepository, 
                                        ISkirtComponentRepository skirtComponentRepository, 
                                        ISleeveComponentRepository sleeveComponentRepository)
        {
            using (FileStream fs = File.Open("DataInit\\dresses.csv", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(fs);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(new string[] { "," });

                bool first = true;
                while (!parser.EndOfData)
                {

                    // 0: url, 1: skirt, 2: top, 3: sleeve, 4: path, 5: price
                    string[] row = parser.ReadFields();
                    if (first)
                    {
                        first = false;
                        continue;
                    }


                    var dress = new Dress
                    {
                        SkirtId = skirtComponentRepository.FindByName(row[1]).SkirtId,
                        TopId = topComponentRepository.FindByName(row[2]).TopId,
                        SleeveId = sleeveComponentRepository.FindByName(row[3]).SleeveId,
                        PhotoPath = row[4],
                        Price = float.Parse(row[5])
                    };

                    dressRepository.Create(dress);
                }
            }
        }
     
        
    }
}
