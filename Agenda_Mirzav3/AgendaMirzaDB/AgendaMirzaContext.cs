using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Mirzav3.AgendaMirzaDB;

public partial class AgendaMirzaContext : DbContext
{
    public AgendaMirzaContext()
    {
    }

    public AgendaMirzaContext(DbContextOptions<AgendaMirzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<SocialMedium> SocialMedia { get; set; }

    public virtual DbSet<SocialProfil> SocialProfils { get; set; }

    public virtual DbSet<StatusContact> StatusContacts { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_mirza", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Idcontact).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.HasIndex(e => e.StatusContactIdStatusContact, "fk_Contact_Status Contact_idx");

            entity.Property(e => e.Idcontact)
                .ValueGeneratedNever()
                .HasColumnName("idcontact");
            entity.Property(e => e.Adresse).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Numero).HasMaxLength(20);
            entity.Property(e => e.Prenom).HasMaxLength(45);
            entity.Property(e => e.Sexe).HasColumnType("enum('Men','Woman')");
            entity.Property(e => e.StatusContactIdStatusContact).HasColumnName("Status Contact_idStatus Contact");
        });

        modelBuilder.Entity<SocialMedium>(entity =>
        {
            entity.HasKey(e => e.IdSocialMedia).HasName("PRIMARY");

            entity.ToTable("social media");

            entity.Property(e => e.IdSocialMedia).HasColumnName("idSocial Media");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<SocialProfil>(entity =>
        {
            entity.HasKey(e => new { e.IdSocialProfil, e.ContactIdcontact, e.SocialMediaIdSocialMedia })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("social profil");

            entity.HasIndex(e => e.ContactIdcontact, "fk_Social Profil_Contact1_idx");

            entity.HasIndex(e => e.SocialMediaIdSocialMedia, "fk_Social Profil_Social Media1_idx");

            entity.Property(e => e.IdSocialProfil)
                .ValueGeneratedOnAdd()
                .HasColumnName("idSocial Profil");
            entity.Property(e => e.ContactIdcontact).HasColumnName("Contact_idcontact");
            entity.Property(e => e.SocialMediaIdSocialMedia).HasColumnName("Social Media_idSocial Media");

            entity.HasOne(d => d.ContactIdcontactNavigation).WithMany(p => p.SocialProfils)
                .HasForeignKey(d => d.ContactIdcontact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Social Profil_Contact1");

            entity.HasOne(d => d.SocialMediaIdSocialMediaNavigation).WithMany(p => p.SocialProfils)
                .HasForeignKey(d => d.SocialMediaIdSocialMedia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Social Profil_Social Media1");
        });

        modelBuilder.Entity<StatusContact>(entity =>
        {
            entity.HasKey(e => new { e.IdStatusContact, e.ContactIdcontact })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("status contact");

            entity.HasIndex(e => e.ContactIdcontact, "fk_status contact_contact1_idx");

            entity.Property(e => e.IdStatusContact)
                .ValueGeneratedOnAdd()
                .HasColumnName("idStatus Contact");
            entity.Property(e => e.ContactIdcontact).HasColumnName("contact_idcontact");
            entity.Property(e => e.Status).HasMaxLength(45);

            entity.HasOne(d => d.ContactIdcontactNavigation).WithMany(p => p.StatusContacts)
                .HasForeignKey(d => d.ContactIdcontact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status contact_contact1");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => new { e.IdTask, e.ToDoListIdToDoList })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("task");

            entity.HasIndex(e => e.ToDoListIdToDoList, "fk_Task_To Do List1_idx");

            entity.Property(e => e.IdTask)
                .ValueGeneratedOnAdd()
                .HasColumnName("idTask");
            entity.Property(e => e.ToDoListIdToDoList).HasColumnName("To Do List_idTo Do List");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => new { e.IdToDoList, e.ContactIdcontact })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("to do list");

            entity.HasIndex(e => e.ContactIdcontact, "fk_To Do List_Contact1_idx");

            entity.Property(e => e.IdToDoList)
                .ValueGeneratedOnAdd()
                .HasColumnName("idTo Do List");
            entity.Property(e => e.ContactIdcontact).HasColumnName("Contact_idcontact");
            entity.Property(e => e.DateEnd).HasColumnName("Date End");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Titre).HasMaxLength(45);

            entity.HasOne(d => d.ContactIdcontactNavigation).WithMany(p => p.ToDoLists)
                .HasForeignKey(d => d.ContactIdcontact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_To Do List_Contact1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
