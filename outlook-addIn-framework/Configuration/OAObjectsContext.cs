using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OAFramework.User;

namespace OAFramework
{
    public enum Env{PROD,DEV};
    
    public class OAObjectsContext : DbContext
    {
        private const string ConnectionString = "name=FiMailConnectionString";

        public OAObjectsContext()
            : base(ConnectionString)
        {
            // NE PAS LIVRER EN PROD AVEC LA LIGNE SUIVANTE  !!!! RESET DE LA BASE
            Database.SetInitializer<OAObjectsContext>(new OAObjectsInitializer());
            Database.SetInitializer<OAObjectsContext>(null);
        }

        public DbSet<EFDataField> DataFields { get; set; }
        public DbSet<EFDataFieldGroup> DataFieldGroups { get; set; }
        public DbSet<EFDataUnitText> DataUnitTexts { get; set; }
        public DbSet<EFDataUnitDate> DataUnitDates { get; set; }
        public DbSet<EFDataUnitComboStatic> DataUnitComboStatics { get; set; }
        public DbSet<EFDataUnitComboQuery> DataUnitComboQuerys { get; set; }
        public DbSet<EFDataUnitCheck> DataUnitChecks { get; set; }
        public DbSet<EFTemplate> Templates { get; set; }
        public DbSet<EFMail> Mails { get; set; }
        public DbSet<EFMailGroup> MailGroups { get; set; }
        public DbSet<EFUser> Users { get; set; }
        public DbSet<EFUserGroup> UserGroups { get; set; }
        public DbSet<EFFieldComboValue> FieldComboValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            base.OnModelCreating(modelBuilder);
        }
    }
}
