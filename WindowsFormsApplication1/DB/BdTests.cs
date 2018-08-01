using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace WindowsFormsApplication1.DB
{
   public static class BdTests
   {
      public static void FillFlatsModules()
      {
         using (databaseTestEntities entities = new databaseTestEntities())
         {
            F_R_Flats flat1 = entities.F_R_Flats.Add( new F_R_Flats() { COMMERCIAL_NAME = "", WORKNAME = "Flat1", REVISION =0 });
            F_R_Flats flat2 = entities.F_R_Flats.Add( new F_R_Flats() { COMMERCIAL_NAME = "", WORKNAME = "Flat2", REVISION = 0 });
            F_R_Flats flat1r1 = entities.F_R_Flats.Add(new F_R_Flats() { COMMERCIAL_NAME = "", WORKNAME = "Flat2", REVISION = 1 });

            F_R_Modules module1 = entities.F_R_Modules.Add( new F_R_Modules() { NAME_MODULE = "Module1" });
            F_R_Modules module2 = entities.F_R_Modules.Add( new F_R_Modules() { NAME_MODULE = "Module2" });

            F_nn_FlatModules fm11 = entities.F_nn_FlatModules.Add(
               new F_nn_FlatModules()
               {
                  F_R_Flats = flat1,
                  F_R_Modules = module1,
                  DIRECTION = "0,0,0",
                  LOCATION = "0,0,0",
                  REVISION = 0
               });

            F_nn_FlatModules fm12 = entities.F_nn_FlatModules.Add(
               new F_nn_FlatModules()
               {
                  F_R_Flats = flat1,
                  F_R_Modules = module2,
                  DIRECTION = "1,1,0",
                  LOCATION = "100,100,0",
                  REVISION = 0
               });

            F_nn_FlatModules fm11r1 = entities.F_nn_FlatModules.Add(
               new F_nn_FlatModules()
               {
                  F_R_Flats = flat1,
                  F_R_Modules = module1,
                  DIRECTION = "0,0,0",
                  LOCATION = "0,0,0",
                  REVISION = 1
               });            

            entities.SaveChanges();
         }
      }      

      public static void FillParameters()
      {
         using (databaseTestEntities entities = new databaseTestEntities())
         {
            var famInfo1 = entities.F_S_FamilyInfos.Add(new F_S_FamilyInfos() { FAMILY_NAME = "Базовая стена", FAMILY_SYMBOL = "ВН_ЖБ_100" });
            var famInfo2 = entities.F_S_FamilyInfos.Add(new F_S_FamilyInfos() { FAMILY_NAME = "Базовая стена", FAMILY_SYMBOL = "ВН_ЖБ_140" });
            var famInfo3 = entities.F_S_FamilyInfos.Add(new F_S_FamilyInfos() { FAMILY_NAME = "Базовая стена", FAMILY_SYMBOL = "ВН_ЖБ_200" });

            var p1 = entities.F_S_Parameters.Add(new F_S_Parameters() { NAME_PARAMETER = "Direction", TYPE_PARAMETER = "Point" });
            var p2 = entities.F_S_Parameters.Add(new F_S_Parameters() { NAME_PARAMETER = "Location", TYPE_PARAMETER = "Point" });
            var p3 = entities.F_S_Parameters.Add(new F_S_Parameters() { NAME_PARAMETER = "Length", TYPE_PARAMETER = "Double" });
            var p4 = entities.F_S_Parameters.Add(new F_S_Parameters() { NAME_PARAMETER = "Height", TYPE_PARAMETER = "Double" });

            var c1 = entities.F_S_Categories.Add(new F_S_Categories() { NAME_RUS_CATEGORY = "Стены", NAME_ENG_CATEGORY = "" });

            entities.F_nn_Category_Parameters.Add(new F_nn_Category_Parameters() { F_S_Categories = c1, F_S_Parameters = p1 });
            entities.F_nn_Category_Parameters.Add(new F_nn_Category_Parameters() { F_S_Categories = c1, F_S_Parameters = p2 });
            entities.F_nn_Category_Parameters.Add(new F_nn_Category_Parameters() { F_S_Categories = c1, F_S_Parameters = p3 });
            entities.F_nn_Category_Parameters.Add(new F_nn_Category_Parameters() { F_S_Categories = c1, F_S_Parameters = p4 });

            entities.SaveChanges();
         }
      }

      public static void GetFM()
      {
         // Получить квартиро-модули для квартиры
         using (databaseTestEntities entities = new databaseTestEntities())
         {
            var flat = entities.F_R_Flats.FirstOrDefault(f => f.ID_FLAT == 1);

            var fms = flat.F_nn_FlatModules.GroupBy(g => new { g.DIRECTION, g.LOCATION })
               .Select(g => g.MaxBy(r => r.REVISION));

         }
      }

      public static void GetElementParameters()
      {
         using (databaseTestEntities entities = new databaseTestEntities())
         {
            var cps = entities.F_S_Categories.
                  Select(s => 
                           new{
                                 w = s.NAME_RUS_CATEGORY,
                                 p = s.F_nn_Category_Parameters.Select(t => t.F_S_Parameters.NAME_PARAMETER)
                              }
                        ).ToList();
         }
      }

      public static void GetFlatsModules()
      {
         using (databaseTestEntities entities = new databaseTestEntities())
         {
            // Квартиры с последней ревизией
            entities.F_R_Flats.Load();
            var flatsLastR = entities.F_R_Flats.Local.GroupBy(f => f.WORKNAME).Select(s => s.MaxBy(r => r.REVISION));
            foreach (var flat in flatsLastR)
            {
               // Модули с посл ревизией в квартире
               var modulesLastR = flat.F_nn_FlatModules.GroupBy(g => g.F_R_Modules.NAME_MODULE).Select(s => s.Max(r => r.REVISION));
            }
         }
      }
   }
}
