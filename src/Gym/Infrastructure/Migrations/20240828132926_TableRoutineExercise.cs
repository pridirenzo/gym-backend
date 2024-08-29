using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableRoutineExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercise_Exercises_ExerciseId",
                table: "RoutineExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercise_Routines_RoutineId",
                table: "RoutineExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutineExercise",
                table: "RoutineExercise");

            migrationBuilder.RenameTable(
                name: "RoutineExercise",
                newName: "RoutinesExercises");

            migrationBuilder.RenameIndex(
                name: "IX_RoutineExercise_ExerciseId",
                table: "RoutinesExercises",
                newName: "IX_RoutinesExercises_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutinesExercises",
                table: "RoutinesExercises",
                columns: new[] { "RoutineId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoutinesExercises_Exercises_ExerciseId",
                table: "RoutinesExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutinesExercises_Routines_RoutineId",
                table: "RoutinesExercises",
                column: "RoutineId",
                principalTable: "Routines",
                principalColumn: "RoutineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutinesExercises_Exercises_ExerciseId",
                table: "RoutinesExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutinesExercises_Routines_RoutineId",
                table: "RoutinesExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutinesExercises",
                table: "RoutinesExercises");

            migrationBuilder.RenameTable(
                name: "RoutinesExercises",
                newName: "RoutineExercise");

            migrationBuilder.RenameIndex(
                name: "IX_RoutinesExercises_ExerciseId",
                table: "RoutineExercise",
                newName: "IX_RoutineExercise_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutineExercise",
                table: "RoutineExercise",
                columns: new[] { "RoutineId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercise_Exercises_ExerciseId",
                table: "RoutineExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercise_Routines_RoutineId",
                table: "RoutineExercise",
                column: "RoutineId",
                principalTable: "Routines",
                principalColumn: "RoutineId");
        }
    }
}
