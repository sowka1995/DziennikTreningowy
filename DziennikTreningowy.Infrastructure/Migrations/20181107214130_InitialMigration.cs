using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikTreningowy.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Avatar = table.Column<byte[]>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserExercise",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercise", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_UserExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercise_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.WorkoutId);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTemplates",
                columns: table => new
                {
                    WorkoutTemplateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTemplates", x => x.WorkoutTemplateId);
                    table.ForeignKey(
                        name: "FK_WorkoutTemplates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    WorkoutExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SetNumber = table.Column<int>(nullable: false),
                    NumberOfReps = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: true),
                    WorkoutId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => x.WorkoutExerciseId);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTemplateExercise",
                columns: table => new
                {
                    WorkoutTemplateId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTemplateExercise", x => new { x.WorkoutTemplateId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_WorkoutTemplateExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutTemplateExercise_WorkoutTemplates_WorkoutTemplateId",
                        column: x => x.WorkoutTemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "WorkoutTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_ExerciseId",
                table: "UserExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_WorkoutId",
                table: "WorkoutExercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTemplateExercise_ExerciseId",
                table: "WorkoutTemplateExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTemplates_UserId",
                table: "WorkoutTemplates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExercise");

            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "WorkoutTemplateExercise");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutTemplates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
