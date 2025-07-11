﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using zQuitSmoking.Repositories.ThinhTHP.Models;

namespace zQuitSmoking.Repositories.ThinhTHP.DBContext;

public partial class SE18_PRN222_SE1809_G6_QuitSmokingDBContext : DbContext
{
    public SE18_PRN222_SE1809_G6_QuitSmokingDBContext()
    {
    }

    public SE18_PRN222_SE1809_G6_QuitSmokingDBContext(DbContextOptions<SE18_PRN222_SE1809_G6_QuitSmokingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConsultationSessionNamHh> ConsultationSessionNamHhs { get; set; }

    public virtual DbSet<HealthMetricTrungDn> HealthMetricTrungDns { get; set; }

    public virtual DbSet<MembershipPackageQuanNh> MembershipPackageQuanNhs { get; set; }

    public virtual DbSet<NotificationThinhThp> NotificationThinhThps { get; set; }

    public virtual DbSet<PlanStageVietHq> PlanStageVietHqs { get; set; }

    public virtual DbSet<QuitPlanVietHq> QuitPlanVietHqs { get; set; }

    public virtual DbSet<SessionFeedbackNamHh> SessionFeedbackNamHhs { get; set; }

    public virtual DbSet<SmokingRecordTrungDn> SmokingRecordTrungDns { get; set; }

    public virtual DbSet<SystemUserAccount> SystemUserAccounts { get; set; }

    public virtual DbSet<UserNotificationThinhThp> UserNotificationThinhThps { get; set; }

    public virtual DbSet<UserSubscriptionQuanNh> UserSubscriptionQuanNhs { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=PC\\SQLEXPRESS;Initial Catalog=SE18_PRN222_SE1809_G6_QuitSmokingDB;User ID=sa;Password=12345;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConsultationSessionNamHh>(entity =>
        {
            entity.HasKey(e => e.ConsultationSessionNamHhid).HasName("PK__Consulta__14BE24B7522743C3");

            entity.ToTable("ConsultationSessionNamHH");

            entity.Property(e => e.ConsultationSessionNamHhid).HasColumnName("ConsultationSessionNamHHID");
            entity.Property(e => e.CoachId).HasColumnName("CoachID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsCompleted).HasDefaultValue(false);
            entity.Property(e => e.SessionDate).HasColumnType("datetime");
            entity.Property(e => e.SessionTopic)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.Coach).WithMany(p => p.ConsultationSessionNamHhCoaches)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__Coach__6754599E");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.ConsultationSessionNamHhUserAccounts)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__UserA__66603565");
        });

        modelBuilder.Entity<HealthMetricTrungDn>(entity =>
        {
            entity.HasKey(e => e.HealthMetricTrungDnid).HasName("PK__HealthMe__71B39B71B5C5E9E2");

            entity.ToTable("HealthMetricTrungDN");

            entity.Property(e => e.HealthMetricTrungDnid).HasColumnName("HealthMetricTrungDNID");
            entity.Property(e => e.BloodPressure)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsImproved).HasDefaultValue(false);
            entity.Property(e => e.LungCapacity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MetricDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SmokingRecordTrungDnid).HasColumnName("SmokingRecordTrungDNID");

            entity.HasOne(d => d.SmokingRecordTrungDn).WithMany(p => p.HealthMetricTrungDns)
                .HasForeignKey(d => d.SmokingRecordTrungDnid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HealthMet__Smoki__619B8048");
        });

        modelBuilder.Entity<MembershipPackageQuanNh>(entity =>
        {
            entity.HasKey(e => e.MembershipPackageQuanNhid).HasName("PK__Membersh__87EF75941578CF18");

            entity.ToTable("MembershipPackageQuanNH");

            entity.Property(e => e.MembershipPackageQuanNhid).HasColumnName("MembershipPackageQuanNHID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PackageName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<NotificationThinhThp>(entity =>
        {
            entity.HasKey(e => e.NotificationThinhThpid).HasName("PK__Notifica__CE9B7E62C886C42F");

            entity.ToTable("NotificationThinhTHP");

            entity.Property(e => e.NotificationThinhThpid).HasColumnName("NotificationThinhTHPID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NotificationType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ScheduleType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TriggerTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<PlanStageVietHq>(entity =>
        {
            entity.HasKey(e => e.PlanStageVietHqid).HasName("PK__PlanStag__CE50C497D454E09C");

            entity.ToTable("PlanStageVietHQ");

            entity.Property(e => e.PlanStageVietHqid).HasColumnName("PlanStageVietHQID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsCompleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.QuitPlanVietHqid).HasColumnName("QuitPlanVietHQID");
            entity.Property(e => e.StageName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.QuitPlanVietHq).WithMany(p => p.PlanStageVietHqs)
                .HasForeignKey(d => d.QuitPlanVietHqid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlanStage__QuitP__6383C8BA");
        });

        modelBuilder.Entity<QuitPlanVietHq>(entity =>
        {
            entity.HasKey(e => e.QuitPlanVietHqid).HasName("PK__QuitPlan__24BE10A0676F137F");

            entity.ToTable("QuitPlanVietHQ");

            entity.Property(e => e.QuitPlanVietHqid).HasColumnName("QuitPlanVietHQID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpectedEndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PlanName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.QuitPlanVietHqs)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuitPlanV__UserA__628FA481");
        });

        modelBuilder.Entity<SessionFeedbackNamHh>(entity =>
        {
            entity.HasKey(e => e.SessionFeedbackNamHhid).HasName("PK__SessionF__1E90152FAA63E0A2");

            entity.ToTable("SessionFeedbackNamHH");

            entity.Property(e => e.SessionFeedbackNamHhid).HasColumnName("SessionFeedbackNamHHID");
            entity.Property(e => e.ConsultationSessionNamHhid).HasColumnName("ConsultationSessionNamHHID");
            entity.Property(e => e.FeedbackDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FeedbackText)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.IsResolved).HasDefaultValue(false);
            entity.Property(e => e.Response)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.ConsultationSessionNamHh).WithMany(p => p.SessionFeedbackNamHhs)
                .HasForeignKey(d => d.ConsultationSessionNamHhid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SessionFe__Consu__68487DD7");
        });

        modelBuilder.Entity<SmokingRecordTrungDn>(entity =>
        {
            entity.HasKey(e => e.SmokingRecordTrungDnid).HasName("PK__SmokingR__C17B24D6060666E0");

            entity.ToTable("SmokingRecordTrungDN");

            entity.Property(e => e.SmokingRecordTrungDnid).HasColumnName("SmokingRecordTrungDNID");
            entity.Property(e => e.CostPerPack).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsCurrent).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RecordDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.SmokingRecordTrungDns)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SmokingRe__UserA__60A75C0F");
        });

        modelBuilder.Entity<SystemUserAccount>(entity =>
        {
            entity.HasKey(e => e.UserAccountId).HasName("PK__System_U__DA6C70BA0E48B43A");

            entity.ToTable("System_UserAccount");

            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserNotificationThinhThp>(entity =>
        {
            entity.HasKey(e => e.UserNotificationThinhThpid).HasName("PK__UserNoti__E93D3877F2CE70E8");

            entity.ToTable("UserNotificationThinhTHP");

            entity.Property(e => e.UserNotificationThinhThpid).HasColumnName("UserNotificationThinhTHPID");
            entity.Property(e => e.AttemptCount).HasDefaultValue(0);
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.LastAttemptDate).HasColumnType("datetime");
            entity.Property(e => e.NotificationThinhThpid).HasColumnName("NotificationThinhTHPID");
            entity.Property(e => e.Response)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.NotificationThinhThp).WithMany(p => p.UserNotificationThinhThps)
                .HasForeignKey(d => d.NotificationThinhThpid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserNotif__Notif__656C112C");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.UserNotificationThinhThps)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserNotif__UserA__6477ECF3");
        });

        modelBuilder.Entity<UserSubscriptionQuanNh>(entity =>
        {
            entity.HasKey(e => e.UserSubscriptionQuanNhid).HasName("PK__UserSubs__ACFC44D912610383");

            entity.ToTable("UserSubscriptionQuanNH");

            entity.Property(e => e.UserSubscriptionQuanNhid).HasColumnName("UserSubscriptionQuanNHID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MembershipPackageQuanNhid).HasColumnName("MembershipPackageQuanNHID");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransactionId)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TransactionID");
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.MembershipPackageQuanNh).WithMany(p => p.UserSubscriptionQuanNhs)
                .HasForeignKey(d => d.MembershipPackageQuanNhid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserSubsc__Membe__5FB337D6");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.UserSubscriptionQuanNhs)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserSubsc__UserA__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}