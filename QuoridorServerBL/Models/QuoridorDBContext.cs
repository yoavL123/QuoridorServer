using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuoridorServerBL.Models
{
    public partial class QuoridorDBContext : DbContext
    {
        public QuoridorDBContext()
        {
        }

        public QuoridorDBContext(DbContextOptions<QuoridorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameMove> GameMoves { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<RatingChange> RatingChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=QuoridorDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GameDate).HasColumnType("datetime");

                entity.Property(e => e.Player1Id).HasColumnName("Player1ID");

                entity.Property(e => e.Player2Id).HasColumnName("Player2ID");

                entity.HasOne(d => d.Player1)
                    .WithMany(p => p.GamePlayer1s)
                    .HasForeignKey(d => d.Player1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Games__Player1ID__276EDEB3");

                entity.HasOne(d => d.Player2)
                    .WithMany(p => p.GamePlayer2s)
                    .HasForeignKey(d => d.Player2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Games__Player2ID__286302EC");
            });

            modelBuilder.Entity<GameMove>(entity =>
            {
                entity.Property(e => e.GameMoveId).HasColumnName("GameMoveID");

                entity.Property(e => e.BlockDirection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GameMoveGameId).HasColumnName("GameMoveGameID");

                entity.Property(e => e.GameMovePlayerId).HasColumnName("GameMovePlayerID");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.HasOne(d => d.GameMoveGame)
                    .WithMany(p => p.GameMoves)
                    .HasForeignKey(d => d.GameMoveGameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameMoves__GameM__2B3F6F97");

                entity.HasOne(d => d.GameMovePlayer)
                    .WithMany(p => p.GameMoves)
                    .HasForeignKey(d => d.GameMovePlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameMoves__GameM__2C3393D0");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.Email, "UC_Email")
                    .IsUnique();

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PlayerPass)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RatingChange>(entity =>
            {
                entity.Property(e => e.RatingChangeId).HasColumnName("RatingChangeID");

                entity.Property(e => e.RatingChangeDate).HasColumnType("datetime");

                entity.Property(e => e.RatingChangePlayerId).HasColumnName("RatingChangePlayerID");

                entity.HasOne(d => d.RatingChangePlayer)
                    .WithMany(p => p.RatingChanges)
                    .HasForeignKey(d => d.RatingChangePlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RatingCha__Ratin__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
