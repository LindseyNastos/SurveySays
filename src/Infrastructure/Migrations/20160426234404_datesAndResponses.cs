using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Infrastructure.Migrations
{
    public partial class datesAndResponses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Question_QuestionId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Survey_SurveyId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_SurveyToTake_Course_CourseId", table: "SurveyToTake");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "CourseId", table: "SurveyToTake");
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTaken",
                table: "SurveyToTake",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<int>(
                name: "TroopNum",
                table: "SurveyToTake",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Survey",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<int>(
                name: "NumResponses",
                table: "Survey",
                nullable: false,
                defaultValue: 0);
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
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Question_QuestionId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_QuestionSurvey_Survey_SurveyId", table: "QuestionSurvey");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "DateTaken", table: "SurveyToTake");
            migrationBuilder.DropColumn(name: "TroopNum", table: "SurveyToTake");
            migrationBuilder.DropColumn(name: "DateCreated", table: "Survey");
            migrationBuilder.DropColumn(name: "NumResponses", table: "Survey");
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "SurveyToTake",
                nullable: true);
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
