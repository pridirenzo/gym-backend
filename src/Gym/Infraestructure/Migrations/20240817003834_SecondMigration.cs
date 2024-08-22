using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Machines_MachineId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercise_Exercises_ExerciseId",
                table: "RoutineExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercise_Routines_RoutineId",
                table: "RoutineExercise");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Exercises",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Machines_MachineId",
                table: "Exercises",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Machines_MachineId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercise_Exercises_ExerciseId",
                table: "RoutineExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercise_Routines_RoutineId",
                table: "RoutineExercise");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Machines_MachineId",
                table: "Exercises",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercise_Exercises_ExerciseId",
                table: "RoutineExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercise_Routines_RoutineId",
                table: "RoutineExercise",
                column: "RoutineId",
                principalTable: "Routines",
                principalColumn: "RoutineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
