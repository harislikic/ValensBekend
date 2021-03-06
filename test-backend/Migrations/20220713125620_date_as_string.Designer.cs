// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test_backend.Data;

namespace test_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220713125620_date_as_string")]
    partial class date_as_string
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test_backend.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Movies_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Movies_id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("test_backend.Models.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("test_backend.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfRelase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<int?>("MovieGenre_id")
                        .HasColumnType("int");

                    b.Property<string>("MoviePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TorentLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieGenre_id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("test_backend.Models.Comments", b =>
                {
                    b.HasOne("test_backend.Models.Movies", "movies")
                        .WithMany()
                        .HasForeignKey("Movies_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movies");
                });

            modelBuilder.Entity("test_backend.Models.Movies", b =>
                {
                    b.HasOne("test_backend.Models.MovieGenre", "MovieGenre")
                        .WithMany()
                        .HasForeignKey("MovieGenre_id");

                    b.Navigation("MovieGenre");
                });
#pragma warning restore 612, 618
        }
    }
}
