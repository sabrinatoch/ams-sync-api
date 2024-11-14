using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SyncAMS.Models;

public partial class AmsContext : DbContext
{
    public AmsContext()
    {
    }

    public AmsContext(DbContextOptions<AmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

    public virtual DbSet<AspnetApplication> AspnetApplications { get; set; }

    public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }

    public virtual DbSet<AspnetPath> AspnetPaths { get; set; }

    public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

    public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

    public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }

    public virtual DbSet<AspnetRole> AspnetRoles { get; set; }

    public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

    public virtual DbSet<AspnetUserPasswordReset> AspnetUserPasswordResets { get; set; }

    public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DemoTable> DemoTables { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EducationType> EducationTypes { get; set; }

    public virtual DbSet<EmployeeUser> EmployeeUsers { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<NonProgramCompetency> NonProgramCompetencies { get; set; }

    public virtual DbSet<PageRoleSecurity> PageRoleSecurities { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<ProgramVersion> ProgramVersions { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<ProvinceState> ProvinceStates { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<StudentUser> StudentUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<ViewAduser> ViewAdusers { get; set; }

    public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

    public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

    public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

    public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

    public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

    public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

    public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

    public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

    public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }

    public virtual DbSet<VwObjectif> VwObjectifs { get; set; }

    public virtual DbSet<VwSelectActiveUserRole> VwSelectActiveUserRoles { get; set; }

    public virtual DbSet<VwStudentUser> VwStudentUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=cstest;Database=AMS;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Idapplication).HasName("PK_App");

            entity.ToTable("Application", "Applications");

            entity.Property(e => e.Idapplication).HasColumnName("IDApplication");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApplicationRole>(entity =>
        {
            entity.HasKey(e => e.IdapplicationRole).HasName("PK_AppRole");

            entity.ToTable("ApplicationRole", "Applications");

            entity.Property(e => e.IdapplicationRole).HasColumnName("IDApplicationRole");
            entity.Property(e => e.Idapplication).HasColumnName("IDApplication");
            entity.Property(e => e.Idrole).HasColumnName("IDRole");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");

            entity.HasOne(d => d.IdapplicationNavigation).WithMany(p => p.ApplicationRoles)
                .HasForeignKey(d => d.Idapplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppRole_App");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.ApplicationRoles)
                .HasForeignKey(d => d.Idrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppRole_Role");
        });

        modelBuilder.Entity<AspnetApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId)
                .HasName("PK__aspnet_A__C93A4C9842E1EEFE")
                .IsClustered(false);

            entity.ToTable("aspnet_Applications", "NetMem");

            entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE440058253").IsUnique();

            entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__309103313D2915A8").IsUnique();

            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspnetMembership>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_M__1788CC4D46B27FE2")
                .IsClustered(false);

            entity.ToTable("aspnet_Membership", "NetMem");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.Password).HasMaxLength(128);
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.PasswordSalt).HasMaxLength(128);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__214BF109");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                .HasForeignKey<AspnetMembership>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__22401542");
        });

        modelBuilder.Entity<AspnetPath>(entity =>
        {
            entity.HasKey(e => e.PathId)
                .HasName("PK__aspnet_P__CD67DC584A8310C6")
                .IsClustered(false);

            entity.ToTable("aspnet_Paths", "NetMem");

            entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetPaths)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pa__Appli__2D12A970");
        });

        modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__aspnet_P__CD67DC594E53A1AA");

            entity.ToTable("aspnet_PersonalizationAllUsers", "NetMem");

            entity.Property(e => e.PathId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithOne(p => p.AspnetPersonalizationAllUser)
                .HasForeignKey<AspnetPersonalizationAllUser>(d => d.PathId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pe__PathI__24285DB4");
        });

        modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__aspnet_P__3214EC065224328E")
                .IsClustered(false);

            entity.ToTable("aspnet_PersonalizationPerUser", "NetMem");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__aspnet_Pe__PathI__251C81ED");

            entity.HasOne(d => d.User).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__aspnet_Pe__UserI__2FEF161B");
        });

        modelBuilder.Entity<AspnetProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4C55F4C372");

            entity.ToTable("aspnet_Profile", "NetMem");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PropertyNames).HasColumnType("ntext");
            entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");
            entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
                .HasForeignKey<AspnetProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pr__UserI__30E33A54");
        });

        modelBuilder.Entity<AspnetRole>(entity =>
        {
            entity.HasKey(e => e.RoleId)
                .HasName("PK__aspnet_R__8AFACE1B59C55456")
                .IsClustered(false);

            entity.ToTable("aspnet_Roles", "NetMem");

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Ro__Appli__27F8EE98");
        });

        modelBuilder.Entity<AspnetSchemaVersion>(entity =>
        {
            entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC15D95E53A");

            entity.ToTable("aspnet_SchemaVersions", "NetMem");

            entity.Property(e => e.Feature).HasMaxLength(128);
            entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
        });

        modelBuilder.Entity<AspnetUser>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_U__1788CC4D625A9A57")
                .IsClustered(false);

            entity.ToTable("aspnet_Users", "NetMem");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias)
                .HasMaxLength(16)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__Appli__28ED12D1");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspnetUsersInRole",
                    r => r.HasOne<AspnetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__RoleI__29E1370A"),
                    l => l.HasOne<AspnetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__UserI__34B3CB38"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__aspnet_U__AF2760AD662B2B3B");
                        j.ToTable("aspnet_UsersInRoles", "NetMem");
                    });
        });

        modelBuilder.Entity<AspnetUserPasswordReset>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("aspnet_UserPasswordReset", "NetMem");

            entity.Property(e => e.PasswordResetExpiration).HasColumnType("datetime");
        });

        modelBuilder.Entity<AspnetWebEventEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__aspnet_W__7944C81069FBBC1F");

            entity.ToTable("aspnet_WebEvent_Events", "NetMem");

            entity.Property(e => e.EventId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicationPath).HasMaxLength(256);
            entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);
            entity.Property(e => e.Details).HasColumnType("ntext");
            entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasMaxLength(256);
            entity.Property(e => e.ExceptionType).HasMaxLength(256);
            entity.Property(e => e.MachineName).HasMaxLength(256);
            entity.Property(e => e.Message).HasMaxLength(1024);
            entity.Property(e => e.RequestUrl).HasMaxLength(1024);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Idcountry);

            entity.ToTable("Country", "Resources");

            entity.HasIndex(e => e.Name, "UniqueName").IsUnique();

            entity.Property(e => e.Idcountry).HasColumnName("IDCountry");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DemoTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Demo_Table");

            entity.Property(e => e.DemoColumn)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Demo Column");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Iddepartment);

            entity.ToTable("Department");

            entity.Property(e => e.Iddepartment).HasColumnName("IDDepartment");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        modelBuilder.Entity<EducationType>(entity =>
        {
            entity.HasKey(e => e.IdeducationType);

            entity.ToTable("EducationType", "Resources");

            entity.Property(e => e.IdeducationType).HasColumnName("IDEducationType");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeUser>(entity =>
        {
            entity.HasKey(e => e.Iduser);

            entity.ToTable("EmployeeUser", "Users");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("IDUser");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Idemploye).HasColumnName("IDEmploye");

            entity.HasOne(d => d.IduserNavigation).WithOne(p => p.EmployeeUser)
                .HasForeignKey<EmployeeUser>(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeUser_User");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language", "Resources");

            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.Language1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Language");
        });

        modelBuilder.Entity<NonProgramCompetency>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NonProgramCompetency");

            entity.Property(e => e.CompetencyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.NonProgramCompetencyId).HasColumnName("NonProgramCompetencyID");
        });

        modelBuilder.Entity<PageRoleSecurity>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PageRoleSecurity", "Applications");

            entity.Property(e => e.Idapplication).HasColumnName("IDApplication");
            entity.Property(e => e.PageName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdapplicationNavigation).WithMany()
                .HasForeignKey(d => d.Idapplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PageRoleSecurity_Application");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Idprogram);

            entity.ToTable("Program", "Resources");

            entity.Property(e => e.Idprogram).HasColumnName("IDProgram");
            entity.Property(e => e.IdeducationType).HasColumnName("IDEducationType");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdeducationTypeNavigation).WithMany(p => p.Programs)
                .HasForeignKey(d => d.IdeducationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Program_EducationType");
        });

        modelBuilder.Entity<ProgramVersion>(entity =>
        {
            entity.HasKey(e => e.IdprogramVersion);

            entity.ToTable("ProgramVersion", "Resources");

            entity.HasIndex(e => new { e.Idprogram, e.IdprogramClara }, "CK_ProgramVersion").IsUnique();

            entity.HasIndex(e => new { e.Idprogram, e.IdprogramClara }, "UC_ProgramVersion").IsUnique();

            entity.Property(e => e.IdprogramVersion).HasColumnName("IDProgramVersion");
            entity.Property(e => e.Idprogram).HasColumnName("IDProgram");
            entity.Property(e => e.IdprogramClara).HasColumnName("IDProgramClara");

            entity.HasOne(d => d.IdprogramNavigation).WithMany(p => p.ProgramVersions)
                .HasForeignKey(d => d.Idprogram)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProgramVersion_Program");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Idprovince);

            entity.ToTable("Province", "Resources");

            entity.Property(e => e.Idprovince).HasColumnName("IDProvince");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("XX")
                .IsFixedLength();
            entity.Property(e => e.Text)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProvinceState>(entity =>
        {
            entity.HasKey(e => e.IdprovinceState);

            entity.ToTable("ProvinceState", "Resources");

            entity.Property(e => e.IdprovinceState).HasColumnName("IDProvinceState");
            entity.Property(e => e.Idcountry).HasColumnName("IDCountry");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdcountryNavigation).WithMany(p => p.ProvinceStates)
                .HasForeignKey(d => d.Idcountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProvinceState_Country");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole);

            entity.ToTable("Role", "Applications");

            entity.Property(e => e.Idrole).HasColumnName("IDRole");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SecurityQuestion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SecurityQuestions", "Resources");

            entity.Property(e => e.IdsecurityQuestion)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDSecurityQuestion");
            entity.Property(e => e.Text)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Settings", "Applications");
        });

        modelBuilder.Entity<StudentUser>(entity =>
        {
            entity.HasKey(e => e.Iduser);

            entity.ToTable("StudentUser", "Users");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("IDUser");
            entity.Property(e => e.Idetudiant).HasColumnName("IDEtudiant");

            entity.HasOne(d => d.IduserNavigation).WithOne(p => p.StudentUser)
                .HasForeignKey<StudentUser>(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentUser_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser);

            entity.ToTable("User", "Users");

            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.FirstName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ValidatedInAd).HasColumnName("ValidatedInAD");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.IduserRole);

            entity.ToTable("UserRole", "Applications");

            entity.Property(e => e.IduserRole).HasColumnName("IDUserRole");
            entity.Property(e => e.Idrole).HasColumnName("IDRole");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.Idrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_UserRole");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");
        });

        modelBuilder.Entity<ViewAduser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewADUsers");

            entity.Property(e => e.Givenname)
                .HasMaxLength(4000)
                .HasColumnName("givenname");
            entity.Property(e => e.Mailnickname)
                .HasMaxLength(4000)
                .HasColumnName("mailnickname");
            entity.Property(e => e.Sn)
                .HasMaxLength(4000)
                .HasColumnName("SN");
        });

        modelBuilder.Entity<VwAspnetApplication>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Applications", "NetMem");

            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetMembershipUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_MembershipUsers", "NetMem");

            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Profiles", "NetMem");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PropertyNames).HasColumnType("ntext");
            entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");
            entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");
        });

        modelBuilder.Entity<VwAspnetRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Roles", "NetMem");

            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Users", "NetMem");

            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUsersInRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_UsersInRoles", "NetMem");
        });

        modelBuilder.Entity<VwAspnetWebPartStatePath>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Paths", "NetMem");

            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Shared", "NetMem");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_User", "NetMem");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwObjectif>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwObjectif");

            entity.Property(e => e.DateActivation).HasColumnType("datetime");
            entity.Property(e => e.DateDesactivation).HasColumnType("datetime");
            entity.Property(e => e.Idobjectif).HasColumnName("IDObjectif");
            entity.Property(e => e.IdorganismeCreateur).HasColumnName("IDOrganismeCreateur");
            entity.Property(e => e.IdtypeComposanteFormation).HasColumnName("IDTypeComposanteFormation");
            entity.Property(e => e.LangueOrigine)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomTraduit)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwSelectActiveUserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SelectActiveUserRoles");

            entity.Property(e => e.Idemploye).HasColumnName("IDEmploye");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
        });

        modelBuilder.Entity<VwStudentUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwStudentUser");

            entity.Property(e => e.FirstName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Idetudiant).HasColumnName("IDEtudiant");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
