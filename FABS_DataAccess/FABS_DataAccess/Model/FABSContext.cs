using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class FABSContext : DbContext
    {
        public FABSContext()
        {
        }

        public FABSContext(DbContextOptions<FABSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Association> Associations { get; set; }
        public virtual DbSet<AssociationPerson> AssociationPeople { get; set; }
        public virtual DbSet<AssociationWarehouse> AssociationWarehouses { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingLine> BookingLines { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Kayak> Kayaks { get; set; }
        public virtual DbSet<KayakType> KayakTypes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<ZipcodeCountryCity> ZipcodeCountryCities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=FABS;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApartmentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("apartment_number");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("street_name");

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("street_number");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("zipcode");

                entity.HasOne(d => d.ZipcodeCountryCity)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => new { d.Zipcode, d.Country })
                    .HasConstraintName("FK_addresses_zipcode_country_city");
            });

            modelBuilder.Entity<Association>(entity =>
            {
                entity.ToTable("associations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressesId).HasColumnName("addresses_id");

                entity.Property(e => e.Cvr)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("cvr");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Addresses)
                    .WithMany(p => p.Associations)
                    .HasForeignKey(d => d.AddressesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_associations_addresses");
            });

            modelBuilder.Entity<AssociationPerson>(entity =>
            {
                entity.HasKey(e => new { e.AssociationsId, e.PeopleId });

                entity.ToTable("association_person");

                entity.Property(e => e.AssociationsId).HasColumnName("associations_id");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.HasOne(d => d.Associations)
                    .WithMany(p => p.AssociationPeople)
                    .HasForeignKey(d => d.AssociationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_association_person_associations");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.AssociationPeople)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_association_person_people");
            });

            modelBuilder.Entity<AssociationWarehouse>(entity =>
            {
                entity.HasKey(e => new { e.AssociationsId, e.WarehousesId });

                entity.ToTable("association_warehouse");

                entity.Property(e => e.AssociationsId).HasColumnName("associations_id");

                entity.Property(e => e.WarehousesId).HasColumnName("warehouses_id");

                entity.HasOne(d => d.Associations)
                    .WithMany(p => p.AssociationWarehouses)
                    .HasForeignKey(d => d.AssociationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_association_warehouse_associations");

                entity.HasOne(d => d.Warehouses)
                    .WithMany(p => p.AssociationWarehouses)
                    .HasForeignKey(d => d.WarehousesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_association_warehouse_warehouses");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("bookings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_datetime");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.Property(e => e.StartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_datetime");

                entity.Property(e => e.StatusesId).HasColumnName("statuses_id");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bookings_people");

                entity.HasOne(d => d.Statuses)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.StatusesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bookings_statuses");
            });

            modelBuilder.Entity<BookingLine>(entity =>
            {
                entity.ToTable("booking_line");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingsId).HasColumnName("bookings_id");

                entity.Property(e => e.ItemsId).HasColumnName("items_id");

                entity.HasOne(d => d.Bookings)
                    .WithMany(p => p.BookingLines)
                    .HasForeignKey(d => d.BookingsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booking_line_bookings");

                entity.HasOne(d => d.Items)
                    .WithMany(p => p.BookingLines)
                    .HasForeignKey(d => d.ItemsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booking_line_items");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AssociationId).HasColumnName("association_id");

                entity.Property(e => e.StatusesId).HasColumnName("statuses_id");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.AssociationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_items_associations");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Item)
                    .HasForeignKey<Item>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_items_kayaks");

                entity.HasOne(d => d.Statuses)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.StatusesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_items_statuses");
            });

            modelBuilder.Entity<Kayak>(entity =>
            {
                entity.HasKey(e => e.ItemsId);

                entity.ToTable("kayaks");

                entity.Property(e => e.ItemsId)
                    .ValueGeneratedNever()
                    .HasColumnName("items_id");

                entity.Property(e => e.KayakTypesId).HasColumnName("kayak_types_id");

                entity.Property(e => e.LocationsId).HasColumnName("locations_id");

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("serial");

                entity.HasOne(d => d.KayakTypes)
                    .WithMany(p => p.Kayaks)
                    .HasForeignKey(d => d.KayakTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_kayaks_kayak_types");

                entity.HasOne(d => d.Locations)
                    .WithMany(p => p.Kayaks)
                    .HasForeignKey(d => d.LocationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_kayaks_locations");
            });

            modelBuilder.Entity<KayakType>(entity =>
            {
                entity.ToTable("kayak_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.LengthMeter)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("length_meter");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PersonCapacity).HasColumnName("person_capacity");

                entity.Property(e => e.WeightLimit).HasColumnName("weight_limit");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsInUse).HasColumnName("is_in_use");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.Property(e => e.PickLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pick_location");

                entity.Property(e => e.WarehousesId).HasColumnName("warehouses_id");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.PeopleId)
                    .HasConstraintName("FK_locations_people");

                entity.HasOne(d => d.Warehouses)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.WarehousesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_locations_warehouses");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("logins");

                entity.HasIndex(e => e.Email, "IX_logins")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdressesId).HasColumnName("adresses_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.LoginsId).HasColumnName("logins_id");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telephone_number");

                entity.HasOne(d => d.Adresses)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AdressesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_people_addresses");

                entity.HasOne(d => d.Logins)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.LoginsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_people_logins");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("statuses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressesId).HasColumnName("addresses_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Addresses)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.AddressesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_warehouses_addresses");
            });

            modelBuilder.Entity<ZipcodeCountryCity>(entity =>
            {
                entity.HasKey(e => new { e.Zipcode, e.Country });

                entity.ToTable("zipcode_country_city");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("zipcode");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
