﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bagaround.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Bagaround_ShopEntities1 : DbContext
    {
        public Bagaround_ShopEntities1()
            : base("name=Bagaround_ShopEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BrandProduct> BrandProduct { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductInCart> ProductInCart { get; set; }
        public virtual DbSet<TypeProduct> TypeProduct { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}