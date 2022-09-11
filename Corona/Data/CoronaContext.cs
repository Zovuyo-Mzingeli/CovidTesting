using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Corona.Models;
using Corona.Models.Content;
using System;
using System.Linq;

namespace Corona.Data
{
    public partial class CoronaContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public CoronaContext()
        {
        }

        public CoronaContext(DbContextOptions<CoronaContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DBCoronaVirus;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }
      

        public virtual DbSet<City> tblCity { get; set; }
        public virtual DbSet<Suburb> tblSuburb { get; set; }
        public virtual DbSet<MedicalAid> tblMedicalAid { get; set; }
        public virtual DbSet<Province> tblProvince { get; set; }
        public virtual DbSet<Claim> tblClaims { get; set; }
        public virtual DbSet<MedicalPlan> tblMedicalPlans { get; set; }
        public virtual DbSet<RequestTest> tblRequestTest { get; set; }
        public virtual DbSet<ApplicationUser> tblApplicationUsers { get; set; }
        public virtual DbSet<TestBooking> tblTestBooking { get; set; }
        public virtual DbSet<Dependent> tblDependent { get; set; }
        public virtual DbSet<FavouriteSuburb> tblFavourateSuburb { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
               new City
               {
                   CityId = "1",
                   CityName = "Gqeberha"
               }
           );
            modelBuilder.Entity<Suburb>().HasData(
                new Suburb
                {
                    SuburbId = "57",
                    SuburbName = "Humewood",
                    CityId = "1"
                  
              
                }
            );
            modelBuilder.Entity<Suburb>().HasData(
                new Suburb
                {
                    SuburbId = "126",
                    SuburbName = "Summerstrand",
                    CityId = "1"
                }
            );
            modelBuilder.Entity<Suburb>().HasData(
               new Suburb
               {
                   SuburbId = "127",
                   SuburbName = "Summerwood",
                   CityId = "1"
               }
           );
            modelBuilder.Entity<Suburb>().HasData(
              new Suburb
              {
                  SuburbId = "56",
                  SuburbName = "Humerail",
                  CityId = "1"
              }
          );
            modelBuilder.Entity<Suburb>().HasData(
            new Suburb
            {
                SuburbId = "91",
                SuburbName = "New Brighton",
                CityId = "1"
            }
        );
            modelBuilder.Entity<Suburb>().HasData(
           new Suburb
           {
               SuburbId = "117",
               SuburbName = "Sherwood",
               CityId = "1"
           }
       );

            modelBuilder.Entity<MedicalAid>().HasData(
            new MedicalAid
            {
                MedicalAidId = "1",
                MedicalName = "BestMed"
            }
        );
            modelBuilder.Entity<MedicalAid>().HasData(
            new MedicalAid
            {
                MedicalAidId = "2",
                MedicalName = "Bonitas"
            }
        );
            modelBuilder.Entity<MedicalAid>().HasData(
            new MedicalAid
            {
                MedicalAidId = "3",
                MedicalName = "Discovery Health"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
          new MedicalPlan
          {
              MedicalPlanId = "1",
              MedicalAidId = "1",
              PlanName = "Beat 1"
          }
      );
            modelBuilder.Entity<MedicalPlan>().HasData(
           new MedicalPlan
           {
               MedicalPlanId = "2",
               MedicalAidId = "1",
               PlanName = "Beat 2"
           }
       );
            modelBuilder.Entity<MedicalPlan>().HasData(
          new MedicalPlan
          {
              MedicalPlanId = "3",
              MedicalAidId = "1",
              PlanName = "Beat 3"
          }
      );
            modelBuilder.Entity<MedicalPlan>().HasData(
           new MedicalPlan
           {
               MedicalPlanId = "4",
               MedicalAidId = "1",
               PlanName = "Beat 4"
           }
       );
            modelBuilder.Entity<MedicalPlan>().HasData(
          new MedicalPlan
          {
              MedicalPlanId = "5",
              MedicalAidId = "1",
              PlanName = "Pulse 1"
          }
      );
            modelBuilder.Entity<MedicalPlan>().HasData(
         new MedicalPlan
         {
             MedicalPlanId = "6",
             MedicalAidId = "1",
             PlanName = "Pulse 2"
         }
     );
            modelBuilder.Entity<MedicalPlan>().HasData(
        new MedicalPlan
        {
            MedicalPlanId = "7",
            MedicalAidId = "1",
            PlanName = "Pace 1"
        }
    );
            modelBuilder.Entity<MedicalPlan>().HasData(
        new MedicalPlan
        {
            MedicalPlanId = "8",
            MedicalAidId = "1",
            PlanName = "Pulse 2"
        }
    );
            modelBuilder.Entity<MedicalPlan>().HasData(
        new MedicalPlan
        {
            MedicalPlanId = "9",
            MedicalAidId = "1",
            PlanName = "Pulse 3"
        }
    );
            modelBuilder.Entity<MedicalPlan>().HasData(
                new MedicalPlan
                {
                    MedicalPlanId = "10",
                    MedicalAidId = "1",
                    PlanName = "Pulse 4"
                }
            );
            modelBuilder.Entity<MedicalPlan>().HasData(
               new MedicalPlan
               {
                   MedicalPlanId = "11",
                   MedicalAidId = "2",
                   PlanName = "BonStart"
               }
           );
            modelBuilder.Entity<MedicalPlan>().HasData(
              new MedicalPlan
              {
                  MedicalPlanId = "12",
                  MedicalAidId = "2",
                  PlanName = "Primary"
              }
          );
            modelBuilder.Entity<MedicalPlan>().HasData(
              new MedicalPlan
              {
                  MedicalPlanId = "13",
                  MedicalAidId = "2",
                  PlanName = "Primary Select"
              }
          );
            modelBuilder.Entity<MedicalPlan>().HasData(
              new MedicalPlan
              {
                  MedicalPlanId = "14",
                  MedicalAidId = "2",
                  PlanName = "Standard"
              }
          );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "15",
                 MedicalAidId = "2",
                 PlanName = "Standard Select"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "16",
                 MedicalAidId = "2",
                 PlanName = "BonFit Select"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "17",
                 MedicalAidId = "2",
                 PlanName = "BonSave"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "18",
                 MedicalAidId = "2",
                 PlanName = "BonComplete"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "19",
                 MedicalAidId = "2",
                 PlanName = "BonClassic"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "20",
                 MedicalAidId = "2",
                 PlanName = "BonComprehensive"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "21",
                 MedicalAidId = "2",
                 PlanName = "Hospital Standard"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "22",
                 MedicalAidId = "2",
                 PlanName = "BonEssential"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "23",
                 MedicalAidId = "2",
                 PlanName = "BonEssentialSelect"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "24",
                 MedicalAidId = "2",
                 PlanName = "BonCap"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "25",
                 MedicalAidId = "3",
                 PlanName = "Executive"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "26",
                 MedicalAidId = "3",
                 PlanName = "Classic Comprehensive"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "27",
                 MedicalAidId = "3",
                 PlanName = "Classic Delta Comprehensive"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "28",
                 MedicalAidId = "3",
                 PlanName = "Classic Smart Comprehensive"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "29",
                MedicalAidId = "3",
                PlanName = "Essential Comprehensive"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "30",
                MedicalAidId = "3",
                PlanName = "Essential Delta"
            }
        ); modelBuilder.Entity<MedicalPlan>().HasData(
             new MedicalPlan
             {
                 MedicalPlanId = "31",
                 MedicalAidId = "3",
                 PlanName = "Essential Comprehensive"
             }
         );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "32",
                MedicalAidId = "3",
                PlanName = "Essential Priority"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "33",
                MedicalAidId = "3",
                PlanName = "Classic Saver"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "34",
                MedicalAidId = "3",
                PlanName = "Classic Delta Saver"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "35",
                MedicalAidId = "3",
                PlanName = "Essential Saver"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "36",
                MedicalAidId = "3",
                PlanName = "Essential Delta Saver"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "37",
                MedicalAidId = "3",
                PlanName = "Coastal Saver"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "38",
                MedicalAidId = "3",
                PlanName = "Classic Smart"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "39",
                MedicalAidId = "3",
                PlanName = "Essential Smart"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "40",
                MedicalAidId = "3",
                PlanName = "Classic Core"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "41",
                MedicalAidId = "3",
                PlanName = "Classic Delta Core"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "42",
                MedicalAidId = "3",
                PlanName = "Essential Core"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "43",
                MedicalAidId = "3",
                PlanName = "Essential Delta Core"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "44",
                MedicalAidId = "3",
                PlanName = "Coastal Core"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "45",
                MedicalAidId = "3",
                PlanName = "Keycare Plus"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "46",
                MedicalAidId = "3",
                PlanName = "Keycare Smart"
            }
        );
            modelBuilder.Entity<MedicalPlan>().HasData(
            new MedicalPlan
            {
                MedicalPlanId = "47",
                MedicalAidId = "3",
                PlanName = "Keycare Core"
            }
        );
        //    modelBuilder.Entity<MedicalPlan>().HasData(
        //    new MedicalPlan
        //    {
        //        MedicalPlanId = "29",
        //        MedicalAidId = "3",
        //        PlanName = "Essential Comprehensive"
        //    }
        //);
        //    modelBuilder.Entity<MedicalPlan>().HasData(
        //    new MedicalPlan
        //    {
        //        MedicalPlanId = "29",
        //        MedicalAidId = "3",
        //        PlanName = "Essential Comprehensive"
        //    }
        //);
        //    modelBuilder.Entity<MedicalPlan>().HasData(
        //    new MedicalPlan
        //    {
        //        MedicalPlanId = "29",
        //        MedicalAidId = "3",
        //        PlanName = "Essential Comprehensive"
        //    }
        //);
            modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "1",
                UserName = "maria@gmail.com",
                PasswordHash = "maria"
            }
        );
            modelBuilder.Entity<Dependent>().HasData(
            new Dependent
            {
                DependentId = "91",
                PatientId = "2",
                Idnumber = "8009160225083",
                FirstName = "Daleen",
                LastName = "Meintjies",
                PhoneNumber = "0832458796",
                Email = "daleen@gmail.com",
                AddressLine1 = "19 Admirality Way",
                AddressLine2 = "",
                SuburbId = "126",
                MedicalPlanId = "8",
                MedicalAidNumber = "285465885",

                
            }
        );
            //modelBuilder
            //  .Entity<RequestTest>()
            //  .HasOne(a => a.Dependent)
            //  .WithMany(p => p.DependentRequests)
            //  .HasForeignKey(a => a.DependentId)
            //  .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder
            //  .Entity<Dependent>()
            //  .HasOne(a => a.Suburb)
            //  .WithMany(p => p.Dependents)
            //  .HasForeignKey(a => a.SuburbId)
            //  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<RequestTest>()
                .HasOne(a => a.Requestor)
                .WithMany(p => p.PatientRequest)
                .HasForeignKey(a => a.RequestorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<RequestTest>()
               .HasOne(a => a.Nurse)
               .WithMany(p => p.NurseRequest)
               .HasForeignKey(a => a.NurseId)
               .OnDelete(DeleteBehavior.Restrict);



            modelBuilder
               .Entity<PatientVitals>()
               .HasOne(a => a.LabUser)
               .WithMany(p => p.LabUsers)
               .HasForeignKey(a => a.LabUserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<PatientVitals>()
               .HasOne(a => a.Nurse)
               .WithMany(p => p.Nurses)
               .HasForeignKey(a => a.NurseId)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId);
                entity.Property(e => e.CityId).HasMaxLength(50);


                entity.ToTable("tblCity");
                entity.Property(e => e.CityId).ValueGeneratedOnAdd();

                entity.Property(e => e.CityName)
                                      .IsRequired()
                                      .HasMaxLength(50);

            });

            modelBuilder.Entity<Suburb>(entity =>
            {
                entity.HasKey(e => e.SuburbId);
                entity.Property(e => e.SuburbId).HasMaxLength(50);

                entity.ToTable("tblSuburb");
                entity.Property(e => e.SuburbId).ValueGeneratedOnAdd();

                entity.Property(e => e.SuburbName)
                                      .IsRequired()
                                      .HasMaxLength(50);

            });

            modelBuilder.Entity<MedicalAid>(entity =>
            {
                entity.HasKey(e => e.MedicalAidId);
                entity.Property(e => e.MedicalAidId).HasMaxLength(50);

                entity.ToTable("tblMedicalAid");
                entity.Property(e => e.MedicalAidId).ValueGeneratedOnAdd();

                entity.Property(e => e.MedicalName)
                                      .IsRequired()
                                      .HasMaxLength(50);


            });
            modelBuilder.Entity<MedicalPlan>(entity =>
            {
                entity.HasKey(e => e.MedicalPlanId);
                entity.Property(e => e.MedicalPlanId).HasMaxLength(50);

                entity.ToTable("tblMedicalPlans");
                entity.Property(e => e.MedicalPlanId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlanName)
                                      .IsRequired()
                                      .HasMaxLength(50);


            });
            modelBuilder.Entity<TestBooking>(entity =>
            {
                entity.ToTable("tblTestBooking");

                entity.HasKey(e => e.TestBookingId);

                entity.Property(e => e.TestBookingId).HasMaxLength(450)
                .HasDefaultValueSql("(newid())");

            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.ToTable("tblDependent");

                entity.HasKey(e => e.DependentId);

                entity.Property(e => e.DependentId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<FavouriteSuburb>(entity =>
            {
                entity.ToTable("tblFavourateSuburb");

                entity.HasKey(e => e.FavouriteId);

                entity.Property(e => e.FavouriteId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<RequestTest>(entity =>
            {
                entity.ToTable("tblRequestTest");

                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.RequestId).HasMaxLength(450)
                .HasDefaultValueSql("(newid())");

            });


            base.OnModelCreating(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}