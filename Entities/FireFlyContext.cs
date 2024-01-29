using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FireFly_Dotnet.Entities;

public partial class FireFlyContext : DbContext
{
    public FireFlyContext()
    {
    }

    public FireFlyContext(DbContextOptions<FireFlyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Qapair> Qapairs { get; set; }

    public virtual DbSet<QapairsCategory> QapairsCategories { get; set; }

    public virtual DbSet<StoryLine> StoryLines { get; set; }

    public virtual DbSet<StoryMarc> StoryMarcs { get; set; }

    public virtual DbSet<StoryQuestionCategory> StoryQuestionCategories { get; set; }

    public virtual DbSet<UserStudentAnswer> UserStudentAnswers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=34.123.144.175;Database=FireFly;User Id=sqlserver;Password=Fireflydeveloper;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Qapair>(entity =>
        {
            entity.ToTable("QAPairs");

            entity.Property(e => e.Answer).HasMaxLength(2000);
            entity.Property(e => e.Question).HasMaxLength(255);
        });

        modelBuilder.Entity<QapairsCategory>(entity =>
        {
            entity.ToTable("QAPairsCategories");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StoryLine>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");
            entity.Property(e => e.StepCcssreference)
                .HasMaxLength(50)
                .HasColumnName("StepCCSSReference");
            entity.Property(e => e.StoryId).HasColumnName("StoryID");
        });

        modelBuilder.Entity<StoryMarc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stories");

            entity.ToTable("StoryMARC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Audience).HasMaxLength(50);
            entity.Property(e => e.Authors).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Illustrator).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Language)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Publisher).HasMaxLength(50);
            entity.Property(e => e.SeriesTitle).HasMaxLength(50);
            entity.Property(e => e.StoryName).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<StoryQuestionCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QuestionTypes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserStudentAnswer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
