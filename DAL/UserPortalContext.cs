using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace DAL;

public partial class UserPortalContext : DbContext
{
    protected IConfiguration Configuration;

    public UserPortalContext()
    {
        var config = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.json")
     .Build();
        Configuration = config;

    }

    public UserPortalContext(DbContextOptions<UserPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

    public virtual DbSet<CPatient> CPatients { get; set; }

    public virtual DbSet<ChatFile> ChatFiles { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<DeviceCode> DeviceCodes { get; set; }

    public virtual DbSet<DuringRegistrationUser> DuringRegistrationUsers { get; set; }

    public virtual DbSet<Kit> Kits { get; set; }

    public virtual DbSet<KitInfo> KitInfos { get; set; }

    public virtual DbSet<KitNumber> KitNumbers { get; set; }

    public virtual DbSet<MicroGroup> MicroGroups { get; set; }

    public virtual DbSet<MicroLayer> MicroLayers { get; set; }

    public virtual DbSet<Microb> Microbs { get; set; }

    public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

    public virtual DbSet<Probiotic> Probiotics { get; set; }

    public virtual DbSet<Summary> Summaries { get; set; }

    public virtual DbSet<TrendItem> TrendItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VWfResult> VWfResults { get; set; }

    public virtual DbSet<VjsfForm> VjsfForms { get; set; }

    public virtual DbSet<VjsfFormData> VjsfFormDatas { get; set; }

    public virtual DbSet<VueComponent> VueComponents { get; set; }

    public virtual DbSet<VueComponentData> VueComponentDatas { get; set; }

    public virtual DbSet<WfResult> WfResults { get; set; }

    public virtual DbSet<WfResultPoint> WfResultPoints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
      //  => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=UserPortal;Username=postgres;Password=Qazwsx123");
            
    {

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            // builder.AddFilter("Microsoft", LogLevel.Warning)
            //     .AddFilter("System", LogLevel.Warning)
            builder.AddFilter("", LogLevel.Debug);
            
        }
        );

        options.UseLoggerFactory(loggerFactory) //tie-up DbContext with LoggerFactory object
            .EnableSensitiveDataLogging();

        var connect = Configuration.GetConnectionString("WebApiDatabase");

        options.UseNpgsql(connect);
    }

}
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("taxonomylevel", new[] { "Kingdom", "Phylum", "Class", "Order", "Family", "Genus", "Species" })
            .HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<BinaryObject>(entity =>
        {
            entity.ToTable("BinaryObject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Extention)
                .HasMaxLength(30)
                .HasColumnName("extention");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CPatient>(entity =>
        {
            entity.ToTable("c_patient");

            entity.HasIndex(e => e.Email, "IX_Patient_email");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
        });

        modelBuilder.Entity<ChatFile>(entity =>
        {
            entity.HasIndex(e => e.BinaryObjectId, "IX_ChatFiles_BinaryObjectId");

            entity.HasIndex(e => e.ChatMessageId, "IX_ChatFiles_ChatMessageId");

            entity.HasOne(d => d.BinaryObject).WithMany(p => p.ChatFiles).HasForeignKey(d => d.BinaryObjectId);

            entity.HasOne(d => d.ChatMessage).WithMany(p => p.ChatFiles).HasForeignKey(d => d.ChatMessageId);
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.Property(e => e.CrDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<DeviceCode>(entity =>
        {
            entity.HasKey(e => e.UserCode);

            entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode").IsUnique();

            entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

            entity.Property(e => e.UserCode).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.CreationTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Data).HasMaxLength(50000);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.DeviceCode1)
                .HasMaxLength(200)
                .HasColumnName("DeviceCode");
            entity.Property(e => e.Expiration).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
        });

        modelBuilder.Entity<DuringRegistrationUser>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_reg_email");

            entity.HasIndex(e => e.Logon, "IX_reg_logon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDay).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.Logon).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Kit>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Kits_UserId");

            entity.HasIndex(e => e.WorkflowResultId, "IX_Kits_WorkflowResultId");

            entity.Property(e => e.ActivationCode).HasMaxLength(255);
            entity.Property(e => e.CollectedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.User).WithMany(p => p.Kits).HasForeignKey(d => d.UserId);

            entity.HasOne(d => d.WorkflowResult).WithMany(p => p.Kits)
                .HasForeignKey(d => d.WorkflowResultId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<KitInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("KitInfo");

            entity.Property(e => e.ActivationCode).HasMaxLength(255);
            entity.Property(e => e.BirthDay).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
        });

        modelBuilder.Entity<KitNumber>(entity =>
        {
            entity.HasIndex(e => e.Number, "IX_KitNumber_Number").IsUnique();

            entity.Property(e => e.Number)
                .HasMaxLength(9)
                .IsFixedLength();
        });

        modelBuilder.Entity<MicroGroup>(entity =>
        {
            entity.Property(e => e.Id).HasIdentityOptions(null, null, 0L, null, null, null);
            entity.Property(e => e.FrequencyJsonB).HasColumnType("jsonb");
            entity.Property(e => e.Mean).HasColumnName("mean");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Sd).HasColumnName("sd");
            entity.Property(e => e._90Percentile).HasColumnName("90.percentile");
        });

        modelBuilder.Entity<MicroLayer>(entity =>
        {
            entity.Property(e => e.Id).HasIdentityOptions(null, null, 0L, null, null, null);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Microb>(entity =>
        {
            entity.HasIndex(e => e.LayersId, "IX_Microbs_LayersId");

            entity.HasIndex(e => new { e.Name, e.LayersId }, "IX_Microbs_Name_LayersId").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.JsonBbody)
                .HasColumnType("jsonb")
                .HasColumnName("JsonBBody");
            entity.Property(e => e.Mean).HasColumnName("mean");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Sd).HasColumnName("sd");

            entity.HasOne(d => d.Layers).WithMany(p => p.Microbs)
                .HasForeignKey(d => d.LayersId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Microbs_LayersID_MicroLayers");
        });

        modelBuilder.Entity<PersistedGrant>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

            entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

            entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type }, "IX_PersistedGrants_SubjectId_SessionId_Type");

            entity.Property(e => e.Key).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.ConsumedTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CreationTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Data).HasMaxLength(50000);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Expiration).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Probiotic>(entity =>
        {
            entity.Property(e => e.GenusName).HasMaxLength(100);
            entity.Property(e => e.Label).HasMaxLength(200);
            entity.Property(e => e.SpeciesName).HasMaxLength(100);
        });

        modelBuilder.Entity<Summary>(entity =>
        {
            entity.HasIndex(e => e.WorkflowResultId, "IX_Summaries_WorkflowResultId");

            entity.Property(e => e.Class).HasMaxLength(200);
            entity.Property(e => e.Family).HasMaxLength(200);
            entity.Property(e => e.Genus).HasMaxLength(200);
            entity.Property(e => e.Kingdom).HasMaxLength(200);
            entity.Property(e => e.Order).HasMaxLength(200);
            entity.Property(e => e.Phylum).HasMaxLength(200);
            entity.Property(e => e.Species).HasMaxLength(200);

            entity.HasOne(d => d.WorkflowResult).WithMany(p => p.Summaries)
                .HasForeignKey(d => d.WorkflowResultId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrendItem>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.ImageDataId, "IX_Users_ImageDataId");

            entity.HasIndex(e => e.Email, "IX_user_email");

            entity.HasIndex(e => e.Logon, "IX_user_logon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDay).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.Logon).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ImageData).WithMany(p => p.Users)
                .HasForeignKey(d => d.ImageDataId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<VWfResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_wf_result");

            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.JsonData).HasColumnType("json");
        });

        modelBuilder.Entity<VjsfForm>(entity =>
        {
            entity.HasIndex(e => e.VariableName, "IX_Vjsf_Form_Variable_Name").IsUnique();

            entity.Property(e => e.Model).HasColumnType("jsonb");
            entity.Property(e => e.Options).HasColumnType("jsonb");
            entity.Property(e => e.RefTable).HasMaxLength(255);
            entity.Property(e => e.Schema).HasColumnType("jsonb");
            entity.Property(e => e.VariableName).HasMaxLength(255);
        });

        modelBuilder.Entity<VjsfFormData>(entity =>
        {
            entity.HasIndex(e => e.VjsfFormId, "IX_VjsfFormDatas_VjsfFormId");

            entity.Property(e => e.Json).HasColumnType("jsonb");
            entity.Property(e => e.RefToTable).HasColumnType("jsonb");

            entity.HasOne(d => d.VjsfForm).WithMany(p => p.VjsfFormData).HasForeignKey(d => d.VjsfFormId);
        });

        modelBuilder.Entity<VueComponent>(entity =>
        {
            entity.HasIndex(e => e.VariableName, "IX_Vue_Component_Variable_Name").IsUnique();

            entity.Property(e => e.Json).HasColumnType("jsonb");
            entity.Property(e => e.RefTable).HasMaxLength(255);
            entity.Property(e => e.VariableName).HasMaxLength(255);
        });

        modelBuilder.Entity<VueComponentData>(entity =>
        {
            entity.HasIndex(e => e.VueComponentId, "IX_VueComponentDatas_VueComponentId");

            entity.Property(e => e.Json).HasColumnType("jsonb");
            entity.Property(e => e.RefToTable).HasColumnType("jsonb");

            entity.HasOne(d => d.VueComponent).WithMany(p => p.VueComponentData).HasForeignKey(d => d.VueComponentId);
        });

        modelBuilder.Entity<WfResult>(entity =>
        {
            entity.ToTable("wf_result");

            entity.HasIndex(e => e.PatientId, "IX_wf_result_PatientId");

            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Patient).WithMany(p => p.WfResults)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<WfResultPoint>(entity =>
        {
            entity.ToTable("wf_result_point");

            entity.HasIndex(e => e.Point, "IX_wf_result_point_Point").HasMethod("gist");

            entity.HasIndex(e => e.WorkflowResultId, "IX_wf_result_point_WorkflowResultId");

            entity.Property(e => e.Point).HasDefaultValueSql("'(0,0)'::point");

            entity.HasOne(d => d.WorkflowResult).WithMany(p => p.WfResultPoints).HasForeignKey(d => d.WorkflowResultId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
