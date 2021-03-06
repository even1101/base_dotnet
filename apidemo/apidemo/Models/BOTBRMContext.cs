using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class BOTBRMContext : DbContext
    {
        public BOTBRMContext()
        {
        }

        public BOTBRMContext(DbContextOptions<BOTBRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<AnnouncementTarget> AnnouncementTarget { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<CodeTable> CodeTable { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentManager> DepartmentManager { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Faq> Faq { get; set; }
        public virtual DbSet<Marquee> Marquee { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleAuthorize> RoleAuthorize { get; set; }
        public virtual DbSet<RoleFlow> RoleFlow { get; set; }
        public virtual DbSet<TemplateFile> TemplateFile { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<VisitTarget> VisitTarget { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("Announcement", "BRM");

                entity.HasComment("公告資料檔");

                entity.Property(e => e.AnnouncementId)
                    .HasComment("公告識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("內容");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("發佈迄日");

                entity.Property(e => e.IsPublic).HasComment("是否公開");

                entity.Property(e => e.MarqueeId).HasComment("跑馬燈識別碼");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasComment("發佈起日");

                entity.Property(e => e.StressTypeId).HasComment("重要性識別碼");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("主旨");

                entity.HasOne(d => d.Marquee)
                    .WithMany(p => p.Announcement)
                    .HasForeignKey(d => d.MarqueeId)
                    .HasConstraintName("fk_Announcement_Marquee");

                entity.HasOne(d => d.StressType)
                    .WithMany(p => p.Announcement)
                    .HasForeignKey(d => d.StressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Announcement_StressType");
            });

            modelBuilder.Entity<AnnouncementTarget>(entity =>
            {
                entity.ToTable("AnnouncementTarget", "BRM");

                entity.HasComment("公告對象資料檔");

                entity.Property(e => e.AnnouncementTargetId)
                    .HasComment("公告對象識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnnouncementId).HasComment("公告識別碼");

                entity.Property(e => e.DepartmentId).HasComment("單位識別碼");

                entity.Property(e => e.EmployeeId).HasComment("人員識別碼");

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.AnnouncementTarget)
                    .HasForeignKey(d => d.AnnouncementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AnnouncementTarget_Announcement");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AnnouncementTarget)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_AnnouncementTarget_Department");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AnnouncementTarget)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_AnnouncementTarget_Employee");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment", "BRM");

                entity.HasComment("附件資料檔");

                entity.Property(e => e.AttachmentId)
                    .HasComment("附件識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttachmentTypeId).HasComment("附件類別識別碼");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.FileDescription)
                    .HasMaxLength(200)
                    .HasComment("檔案說明");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("檔案名稱");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("檔案路徑");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.OriginalName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasComment("原始檔案名稱");

                entity.Property(e => e.ReferenceId).HasComment("參照識別碼");

                entity.HasOne(d => d.AttachmentType)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.AttachmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Attachment_AttachmentType");
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.HasKey(e => e.CalendarDate)
                    .HasName("pk_Calendar");

                entity.ToTable("Calendar", "BRM");

                entity.HasComment("行事曆資料檔");

                entity.Property(e => e.CalendarDate)
                    .HasColumnType("date")
                    .HasComment("行事曆日期");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.IsWorkDay).HasComment("是否為工作日");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("備註");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");
            });

            modelBuilder.Entity<CodeTable>(entity =>
            {
                entity.ToTable("CodeTable", "Framework");

                entity.HasComment("代碼資料檔");

                entity.Property(e => e.CodeTableId)
                    .HasComment("代碼識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("代碼");

                entity.Property(e => e.CodeTypeId).HasComment("代碼類型識別碼");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.DeleteDateTime)
                    .HasColumnType("datetime")
                    .HasComment("刪除時間");

                entity.Property(e => e.DeleteDepartment)
                    .HasMaxLength(50)
                    .HasComment("刪除單位");

                entity.Property(e => e.DeleteEmployee)
                    .HasMaxLength(50)
                    .HasComment("刪除人員");

                entity.Property(e => e.IsReadOnly).HasComment("是否唯讀");

                entity.Property(e => e.Memo)
                    .HasMaxLength(2000)
                    .HasComment("說明");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("名稱");

                entity.Property(e => e.OrderNo).HasComment("順序");

                entity.Property(e => e.ParentCodeTableId).HasComment("父項代碼識別碼");

                entity.HasOne(d => d.CodeType)
                    .WithMany(p => p.InverseCodeType)
                    .HasForeignKey(d => d.CodeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CodeTable_CodeType");

                entity.HasOne(d => d.ParentCodeTable)
                    .WithMany(p => p.InverseParentCodeTable)
                    .HasForeignKey(d => d.ParentCodeTableId)
                    .HasConstraintName("fk_CodeTable_ParentCodeTable");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "Framework");

                entity.HasComment("單位資料檔");

                entity.Property(e => e.DepartmentId)
                    .HasComment("單位識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.DepartmentNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("單位編號");

                entity.Property(e => e.DepartmentTeamId).HasComment("單位分組識別碼");

                entity.Property(e => e.DepartmentTypeId).HasComment("單位類型識別碼");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("date")
                    .HasComment("生效日期");

                entity.Property(e => e.GeographyAreaId).HasComment("地理區域識別碼");

                entity.Property(e => e.IneffectiveDate)
                    .HasColumnType("date")
                    .HasComment("失效日期");

                entity.Property(e => e.IsDisplay).HasComment("是否顯示");

                entity.Property(e => e.IsEnable).HasComment("是否啟用");

                entity.Property(e => e.ManageAreaId).HasComment("管理區域識別碼");

                entity.Property(e => e.MergeDepartmentId).HasComment("合併單位識別碼");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("單位名稱");

                entity.Property(e => e.OrderNo).HasComment("順序");

                entity.Property(e => e.ParentDepartmentId).HasComment("上層單位識別碼");

                entity.HasOne(d => d.DepartmentTeam)
                    .WithMany(p => p.DepartmentDepartmentTeam)
                    .HasForeignKey(d => d.DepartmentTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Department_DepartmentTeam");

                entity.HasOne(d => d.DepartmentType)
                    .WithMany(p => p.DepartmentDepartmentType)
                    .HasForeignKey(d => d.DepartmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Department_DepartmentType");

                entity.HasOne(d => d.GeographyArea)
                    .WithMany(p => p.DepartmentGeographyArea)
                    .HasForeignKey(d => d.GeographyAreaId)
                    .HasConstraintName("fk_Department_GeographyArea");

                entity.HasOne(d => d.ManageArea)
                    .WithMany(p => p.DepartmentManageArea)
                    .HasForeignKey(d => d.ManageAreaId)
                    .HasConstraintName("fk_Department_ManageArea");

                entity.HasOne(d => d.MergeDepartment)
                    .WithMany(p => p.InverseMergeDepartment)
                    .HasForeignKey(d => d.MergeDepartmentId)
                    .HasConstraintName("fk_Department_MergeDepartment");

                entity.HasOne(d => d.ParentDepartment)
                    .WithMany(p => p.InverseParentDepartment)
                    .HasForeignKey(d => d.ParentDepartmentId)
                    .HasConstraintName("fk_Department_ParentDepartment");
            });

            modelBuilder.Entity<DepartmentManager>(entity =>
            {
                entity.ToTable("DepartmentManager", "Framework");

                entity.HasComment("單位管理人員資料檔");

                entity.Property(e => e.DepartmentManagerId)
                    .HasComment("單位管理人員識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.DepartmentId).HasComment("單位識別碼");

                entity.Property(e => e.EmployeeId).HasComment("人員識別碼");

                entity.Property(e => e.ManagerTypeId).HasComment("管理類型識別碼");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentManager)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DepartmentManager_Department");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DepartmentManager)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DepartmentManager_Employee");

                entity.HasOne(d => d.ManagerType)
                    .WithMany(p => p.DepartmentManager)
                    .HasForeignKey(d => d.ManagerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DepartmentManager_ManagerType");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "Framework");

                entity.HasComment("人員帳號資料檔");

                entity.Property(e => e.EmployeeId)
                    .HasComment("人員識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComment("員工編號");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.DepartmentId).HasComment("單位識別碼");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("date")
                    .HasComment("生效日");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("電子郵件");

                entity.Property(e => e.IneffectiveDate)
                    .HasColumnType("date")
                    .HasComment("失效日");

                entity.Property(e => e.IsEnable).HasComment("是否啟用");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasComment("名稱");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .HasComment("職稱");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Employee_Department");
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("Faq", "BRM");

                entity.HasComment("問與答資料檔");

                entity.Property(e => e.FaqId)
                    .HasComment("問與答識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("內容");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.FontColorId).HasComment("文字顏色識別碼");

                entity.Property(e => e.IsCancel).HasComment("是否下架");

                entity.Property(e => e.IsPublic).HasComment("是否公開");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.OrderNo).HasComment("順序");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("主旨");

                entity.HasOne(d => d.FontColor)
                    .WithMany(p => p.Faq)
                    .HasForeignKey(d => d.FontColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Faq_FontColor");
            });

            modelBuilder.Entity<Marquee>(entity =>
            {
                entity.ToTable("Marquee", "BRM");

                entity.HasComment("跑馬燈資料檔");

                entity.Property(e => e.MarqueeId)
                    .HasComment("跑馬燈識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("結束日期");

                entity.Property(e => e.FontColorId).HasComment("文字顏色識別碼");

                entity.Property(e => e.FontSizeId).HasComment("文字大小識別碼");

                entity.Property(e => e.IsEnable).HasComment("是否啟用");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasComment("開始日期");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("主旨");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .HasComment("連結網址");

                entity.HasOne(d => d.FontColor)
                    .WithMany(p => p.MarqueeFontColor)
                    .HasForeignKey(d => d.FontColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Marquee_FontColor");

                entity.HasOne(d => d.FontSize)
                    .WithMany(p => p.MarqueeFontSize)
                    .HasForeignKey(d => d.FontSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Marquee_FontSize");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu", "Framework");

                entity.HasComment("選單資料檔");

                entity.Property(e => e.MenuId)
                    .HasComment("選單識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("代碼");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.Memo)
                    .HasMaxLength(2000)
                    .HasComment("說明");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasComment("名稱");

                entity.Property(e => e.OrderNo).HasComment("順序");

                entity.Property(e => e.ParentMenuId).HasComment("上層選單識別碼");

                entity.Property(e => e.Url)
                    .HasMaxLength(2000)
                    .HasComment("網址");

                entity.HasOne(d => d.ParentMenu)
                    .WithMany(p => p.InverseParentMenu)
                    .HasForeignKey(d => d.ParentMenuId)
                    .HasConstraintName("fk_Menu_ParentMenu");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Framework");

                entity.HasComment("角色資料檔");

                entity.Property(e => e.RoleId)
                    .HasComment("角色識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("代碼");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.InfoNo)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComment("單一簽入資訊代號");

                entity.Property(e => e.Memo)
                    .HasMaxLength(2000)
                    .HasComment("備註");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("名稱");

                entity.Property(e => e.OrderNo).HasComment("順序");
            });

            modelBuilder.Entity<RoleAuthorize>(entity =>
            {
                entity.ToTable("RoleAuthorize", "Framework");

                entity.HasComment("角色權限資料檔");

                entity.Property(e => e.RoleAuthorizeId).ValueGeneratedNever();

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.RoleId).HasComment("角色識別碼");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleAuthorize)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoleAuthorize_Menu");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAuthorize)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoleAuthorize_Role");
            });

            modelBuilder.Entity<RoleFlow>(entity =>
            {
                entity.ToTable("RoleFlow", "Framework");

                entity.HasComment("角色流程資料檔");

                entity.Property(e => e.RoleFlowId)
                    .HasComment("角色流程識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.DataPermissionId).HasComment("資料權限識別碼");

                entity.Property(e => e.IsApprovable).HasComment("是否可核定");

                entity.Property(e => e.IsEditable).HasComment("是否可編輯");

                entity.Property(e => e.IsMaintainable).HasComment("是否可維護");

                entity.Property(e => e.IsReviewable).HasComment("是否可覆核");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.RoleId).HasComment("角色識別碼");

                entity.HasOne(d => d.DataPermission)
                    .WithMany(p => p.RoleFlow)
                    .HasForeignKey(d => d.DataPermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoleFlow_DataPermission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleFlow)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoleFlow_Role");
            });

            modelBuilder.Entity<TemplateFile>(entity =>
            {
                entity.ToTable("TemplateFile", "BRM");

                entity.HasComment("範本資料檔");

                entity.Property(e => e.TemplateFileId)
                    .HasComment("範本識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("檔案名稱");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("檔案路徑");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("範本名稱");
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.ToTable("UserLog", "BRM");

                entity.HasComment("使用者操作紀錄資料檔");

                entity.Property(e => e.UserLogId)
                    .HasComment("使用者操作紀錄識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .HasComment("單位名稱");

                entity.Property(e => e.DepartmentNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("單位編號");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .HasComment("人員名稱");

                entity.Property(e => e.EmployeeNo)
                    .HasMaxLength(25)
                    .HasComment("人員編號");

                entity.Property(e => e.IsSuccess).HasComment("是否執行成功");

                entity.Property(e => e.LogDateTime)
                    .HasColumnType("datetime")
                    .HasComment("紀錄時間");

                entity.Property(e => e.Memo)
                    .HasMaxLength(1000)
                    .HasComment("備註");

                entity.Property(e => e.MenuAuthorityCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("選單權限代碼");

                entity.Property(e => e.MenuAuthorityName)
                    .HasMaxLength(200)
                    .HasComment("選單權限名稱");

                entity.Property(e => e.MenuCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("選單代碼");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(40)
                    .HasComment("選單名稱");

                entity.Property(e => e.SourceIp)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("來源位址");
            });

            modelBuilder.Entity<VisitTarget>(entity =>
            {
                entity.ToTable("VisitTarget", "BRM");

                entity.HasComment("外訪目標資料檔");

                entity.Property(e => e.VisitTargetId)
                    .HasComment("外訪目標識別碼")
                    .ValueGeneratedNever();

                entity.Property(e => e.Count).HasComment("次數");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔單位");

                entity.Property(e => e.CreateEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("建檔人員");

                entity.Property(e => e.DepartmentId).HasComment("單位識別碼");

                entity.Property(e => e.ModifyDateTime)
                    .HasColumnType("datetime")
                    .HasComment("異動時間");

                entity.Property(e => e.ModifyDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動單位");

                entity.Property(e => e.ModifyEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("異動人員");

                entity.Property(e => e.Month).HasComment("月份");

                entity.Property(e => e.Year).HasComment("年度");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.VisitTarget)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VisitTarget_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
