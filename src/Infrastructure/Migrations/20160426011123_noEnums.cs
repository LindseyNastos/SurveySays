using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Infrastructure.Migrations
{
    public partial class noEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Question_QuestionId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Survey_SurveyId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "Course", table: "SurveyToTake");
            migrationBuilder.DropColumn(name: "Course", table: "Survey");
            migrationBuilder.DropColumn(name: "QuestionType", table: "Question");
            migrationBuilder.DropColumn(name: "CourseTaught", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "Location", table: "AspNetUsers");
            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Class = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "SurveyToTake",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Survey",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "QuestionTypeId",
                table: "Question",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "CourseTaughtId",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Answer",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "SurveyToTakeId",
                table: "Answer",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Answer_SurveyToTake_SurveyToTakeId",
                table: "Answer",
                column: "SurveyToTakeId",
                principalTable: "SurveyToTake",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Course_CourseTaughtId",
                table: "AspNetUsers",
                column: "CourseTaughtId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Campus_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Campus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Question_QuestionType_QuestionTypeId",
                table: "Question",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSurvey_Question_QuestionId",
                table: "QuestionSurvey",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSurvey_Survey_SurveyId",
                table: "QuestionSurvey",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Survey_Course_CourseId",
                table: "Survey",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SurveyToTake_Course_CourseId",
                table: "SurveyToTake",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Answer_SurveyToTake_SurveyToTakeId", table: "Answer");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUser_Course_CourseTaughtId", table: "AspNetUsers");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUser_Campus_LocationId", table: "AspNetUsers");
            migrationBuilder.DropForeignKey(name: "FK_Question_QuestionType_QuestionTypeId", table: "Question");
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Question_QuestionId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Survey_SurveyId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_Survey_Course_CourseId", table: "Survey");
            migrationBuilder.DropForeignKey(name: "FK_SurveyToTake_Course_CourseId", table: "SurveyToTake");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "CourseId", table: "SurveyToTake");
            migrationBuilder.DropColumn(name: "CourseId", table: "Survey");
            migrationBuilder.DropColumn(name: "QuestionTypeId", table: "Question");
            migrationBuilder.DropColumn(name: "CourseTaughtId", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "LocationId", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "QuestionId", table: "Answer");
            migrationBuilder.DropColumn(name: "SurveyToTakeId", table: "Answer");
            migrationBuilder.DropTable("Campus");
            migrationBuilder.DropTable("Course");
            migrationBuilder.DropTable("QuestionType");
            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "SurveyToTake",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "Survey",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "Question",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "CourseTaught",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSurvey_Question_QuestionId",
                table: "QuestionSurvey",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSurvey_Survey_SurveyId",
                table: "QuestionSurvey",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
