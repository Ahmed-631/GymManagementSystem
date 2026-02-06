using GymManegementDAL.Data.Context;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymManagementDAL.Data.DataSeeding
{
    public static class GymDbcontextSeeding
    {


        public static bool DataSeeded(GymDbcontext dbcontext   ) 
        {   
            var HasPlans = dbcontext.Plans.Any();
            var HasCategories = dbcontext.Categories.Any();

            if (HasPlans && HasCategories) return false;


            if (!HasPlans) 
            
            {
                var Plans = LoadDataFromJson<Plan>("Plans.json");
                if (Plans.Any()) dbcontext.Plans.AddRange(Plans); 
                    
     
            };

            if (!HasCategories)

            {
                var Categoris = LoadDataFromJson<Category>("categories.json");
                if (Categoris.Any()) dbcontext.Categories.AddRange(Categoris);

            }

            return dbcontext.SaveChanges() > 0; 


        }

        private static List<T> LoadDataFromJson<T>(string FileName) 
       
        {
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FileName);
            if (!File.Exists(FilePath)) { throw new FileNotFoundException(); }
            var Data = File.ReadAllText(FilePath);
            var Options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<T>>(Data, Options) ?? new List<T>(); ; 
        
        }

    }
}
