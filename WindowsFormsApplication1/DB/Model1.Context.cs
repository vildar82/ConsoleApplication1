﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication1.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class databaseTestEntities : DbContext
    {
        public databaseTestEntities()
            : base("name=databaseTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<F_nn_Category_Parameters> F_nn_Category_Parameters { get; set; }
        public virtual DbSet<F_nn_ElementParam_Value> F_nn_ElementParam_Value { get; set; }
        public virtual DbSet<F_nn_Elements_FlatModules> F_nn_Elements_FlatModules { get; set; }
        public virtual DbSet<F_nn_FlatModules> F_nn_FlatModules { get; set; }
        public virtual DbSet<F_R_Flats> F_R_Flats { get; set; }
        public virtual DbSet<F_R_Modules> F_R_Modules { get; set; }
        public virtual DbSet<F_S_Categories> F_S_Categories { get; set; }
        public virtual DbSet<F_S_Elements> F_S_Elements { get; set; }
        public virtual DbSet<F_S_FamilyInfos> F_S_FamilyInfos { get; set; }
        public virtual DbSet<F_S_Parameters> F_S_Parameters { get; set; }
    }
}
