using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Services.Data {
    public class AppDb : DbContext {
        public AppDb() { }
        public AppDb(DbContextOptions<AppDb> options) : base(options) {
            //
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TruckInspectionCategory> TruckInspectionCategories { get; set; }
        public DbSet<TruckInspectionItem> TruckInspectionItems { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<TruckInspectionCard> TruckInspectionCards { get; set; }
        public DbSet<TruckInspectionCardDetail> TruckInspectionCardDetails { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<CorrectiveActionRequest> CorrectiveActionRequests { get; set; }
        public DbSet<CorrectiveActionRequestItem> CorrectiveActionRequestItems { get; set; }
        public DbSet<CorrectiveActionRequestStatus> CorrectiveActionRequestStatuses { get; set; }
        public DbSet<LogNumber> LogNumbers { get; set; }
        public DbSet<SubContact> SubContacts { get; set; }
        public DbSet<CardControl> CardControls { get; set; }

        public DbSet<InvestigateCard> InvestigateCards { get; set; }
        public DbSet<PartOne> PartOnes { get; set; }
        public DbSet<PartTwo> PartTwos { get; set; }
        public DbSet<PartThree> PartThrees { get; set; }
        public DbSet<PartFour> PartFours { get; set; }
        public DbSet<PartFive> PartFives { get; set; }
        public DbSet<PartSix> PartSixes { get; set; }

        public DbSet<IncidentTruck> IncidentTrucks { get; set; }
        public DbSet<IncidentTruckPositon> IncidentTruckPositons { get; set; }
        public DbSet<IncidentArea> IncidentAreas { get; set; }
        public DbSet<IncidentRoad> IncidentRoads { get; set; }
        public DbSet<AreaCondition> AreaConditions { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Traffic> Traffics { get; set; }
        public DbSet<IncidentDepot> IncidentDepots { get; set; }

        public DbSet<PartFiveDetail> PartFiveDetails { get; set; }
        public DbSet<UnsafeCategory> UnsafeCategories { get; set; }
        public DbSet<UnsafeItem> UnsafeItems { get; set; }
        public DbSet<InvestigateStatus> InvestigateStatuses { get; set; }
        public DbSet<LogEmployeeAccident> LogEmployeeAccidents { get; set; }
        public DbSet<DeductPoint> DeductPoints { get; set; }
        public DbSet<PenaltyNotice> PenaltyNotices { get; set; }
        public DbSet<PenaltyNoticeDetail> PenaltyNoticeDetails { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Carrier> Carriers { get; set; }

        //for stack chart
        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //index
            modelBuilder.Entity<TruckInspectionCategory>()
                .HasIndex(x => x.Name).IsUnique(true);

            modelBuilder.Entity<Branch>()
                .HasIndex(x => x.Name)
                .IsUnique(true);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(x => x.PlateNumber)
                .IsUnique(true);

            modelBuilder.Entity<Region>()
                .HasIndex(x => x.Name)
                .IsUnique(true);

            modelBuilder.Entity<SubContact>()
                .HasIndex(x => x.Name)
                .IsUnique(false);

            modelBuilder.Entity<SubContact>()
                .HasIndex(x => x.Username)
                .IsUnique(true);

            modelBuilder.Entity<TruckInspectionCard>()
                .HasIndex(x => x.VehicleId).IsUnique(false);

            modelBuilder.Entity<TruckInspectionCard>()
                .HasIndex(x => x.InspectionDate).IsUnique(false);

            modelBuilder.Entity<PartOne>()
                .HasIndex(x => x.EmployeeCode).IsUnique(false);

            modelBuilder.Entity<Carrier>()
                .HasIndex(x => x.Name).IsUnique(true);

            //cascade set null
            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(x => x.Branch)
            //    .WithMany(x => x.Vehicles)
            //    .OnDelete(DeleteBehavior.SetNull);

            //cascade set restrict
            modelBuilder.Entity<TruckInspectionCard>()
               .HasOne(x => x.Employee)
               .WithMany(x => x.TruckInspectionCards)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TruckInspectionCard>()
                .HasOne(x => x.Vehicle)
                .WithMany(x => x.TruckInspectionCards)
                .OnDelete(DeleteBehavior.Restrict);

            //enum to string
            modelBuilder.Entity<Vehicle>()
                .Property(x => x.VehicleType)
                .HasConversion<string>();

            modelBuilder.Entity<CorrectiveActionRequest>()
                .Property(x => x.VehicleType)
                .HasConversion<string>();

            modelBuilder.Entity<TruckInspectionCard>()
                .Property(x => x.VehicleType)
                .HasConversion<string>();

            //enum to string PartOne
            modelBuilder.Entity<PartOne>()
                .Property(x => x.CaseType)
                .HasConversion<string>();

            modelBuilder.Entity<PartOne>()
                .Property(x => x.AccidentMode)
                .HasConversion<string>();

            modelBuilder.Entity<PartOne>()
                .Property(x => x.TransportBy)
                .HasConversion<string>();

            modelBuilder.Entity<PartOne>()
                .Property(x => x.OtherBy)
                .HasConversion<string>();

            modelBuilder.Entity<PartOne>()
                .Property(x => x.Rank)
                .HasConversion<string>();

            //enum to string PartTwo
            modelBuilder.Entity<PartTwo>()
                .Property(x => x.IncidentRoute)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.CaseEffect)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.EmpInjure)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.PartiesInjure)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.ThirdPartiesInjure)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.TruckDamage)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.PartiesDamage)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.EquipmentDamage)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.Training)
                .HasConversion<string>();

            modelBuilder.Entity<PartTwo>()
                .Property(x => x.Camera)
                .HasConversion<string>();

            modelBuilder.Entity<UnsafeCategory>()
                .Property(x => x.UnsafeType)
                .HasConversion<string>();

            // casecade delete investigate card
            //modelBuilder.Entity<PenaltyNotice>()
            //    .HasOne(x => x.InvestigateCard)
            //    .WithMany(x => x.PenaltyNotices)
            //    .OnDelete(DeleteBehavior.Cascade);

            //index
            modelBuilder.Entity<PenaltyNotice>()
                .HasIndex(x => x.InvestigateCardId)
                .IsUnique(true);

            modelBuilder.Entity<PartFive>()
                .HasIndex(x => x.InvestigateCardId)
                .IsUnique(true);
        }
    }
}
