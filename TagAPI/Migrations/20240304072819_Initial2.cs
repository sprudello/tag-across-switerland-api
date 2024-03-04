using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TagAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChallenges_ChallengeCards_CardID",
                table: "GroupChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChallenges_Groups_UserID",
                table: "GroupChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupItems_Groups_UserID",
                table: "GroupItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupItems_Items_ItemID",
                table: "GroupItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTransactions_Groups_UserID",
                table: "GroupTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTransportations_Groups_UserID",
                table: "GroupTransportations");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTransportations_Transportations_TypeID",
                table: "GroupTransportations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTransportations",
                table: "GroupTransportations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTransactions",
                table: "GroupTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupItems",
                table: "GroupItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChallenges",
                table: "GroupChallenges");

            migrationBuilder.RenameTable(
                name: "GroupTransportations",
                newName: "UserTransportations");

            migrationBuilder.RenameTable(
                name: "GroupTransactions",
                newName: "UserTransactions");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "GroupItems",
                newName: "UserItems");

            migrationBuilder.RenameTable(
                name: "GroupChallenges",
                newName: "UserChallenges");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTransportations_UserID",
                table: "UserTransportations",
                newName: "IX_UserTransportations_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTransportations_TypeID",
                table: "UserTransportations",
                newName: "IX_UserTransportations_TypeID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTransactions_UserID",
                table: "UserTransactions",
                newName: "IX_UserTransactions_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupItems_UserID",
                table: "UserItems",
                newName: "IX_UserItems_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupItems_ItemID",
                table: "UserItems",
                newName: "IX_UserItems_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChallenges_UserID",
                table: "UserChallenges",
                newName: "IX_UserChallenges_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChallenges_CardID",
                table: "UserChallenges",
                newName: "IX_UserChallenges_CardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTransportations",
                table: "UserTransportations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTransactions",
                table: "UserTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserItems",
                table: "UserItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChallenges",
                table: "UserChallenges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChallenges_ChallengeCards_CardID",
                table: "UserChallenges",
                column: "CardID",
                principalTable: "ChallengeCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChallenges_Users_UserID",
                table: "UserChallenges",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Items_ItemID",
                table: "UserItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Users_UserID",
                table: "UserItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTransactions_Users_UserID",
                table: "UserTransactions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTransportations_Transportations_TypeID",
                table: "UserTransportations",
                column: "TypeID",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTransportations_Users_UserID",
                table: "UserTransportations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChallenges_ChallengeCards_CardID",
                table: "UserChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChallenges_Users_UserID",
                table: "UserChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Items_ItemID",
                table: "UserItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Users_UserID",
                table: "UserItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTransactions_Users_UserID",
                table: "UserTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTransportations_Transportations_TypeID",
                table: "UserTransportations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTransportations_Users_UserID",
                table: "UserTransportations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTransportations",
                table: "UserTransportations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTransactions",
                table: "UserTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserItems",
                table: "UserItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChallenges",
                table: "UserChallenges");

            migrationBuilder.RenameTable(
                name: "UserTransportations",
                newName: "GroupTransportations");

            migrationBuilder.RenameTable(
                name: "UserTransactions",
                newName: "GroupTransactions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "UserItems",
                newName: "GroupItems");

            migrationBuilder.RenameTable(
                name: "UserChallenges",
                newName: "GroupChallenges");

            migrationBuilder.RenameIndex(
                name: "IX_UserTransportations_UserID",
                table: "GroupTransportations",
                newName: "IX_GroupTransportations_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserTransportations_TypeID",
                table: "GroupTransportations",
                newName: "IX_GroupTransportations_TypeID");

            migrationBuilder.RenameIndex(
                name: "IX_UserTransactions_UserID",
                table: "GroupTransactions",
                newName: "IX_GroupTransactions_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserItems_UserID",
                table: "GroupItems",
                newName: "IX_GroupItems_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserItems_ItemID",
                table: "GroupItems",
                newName: "IX_GroupItems_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_UserChallenges_UserID",
                table: "GroupChallenges",
                newName: "IX_GroupChallenges_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserChallenges_CardID",
                table: "GroupChallenges",
                newName: "IX_GroupChallenges_CardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTransportations",
                table: "GroupTransportations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTransactions",
                table: "GroupTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupItems",
                table: "GroupItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChallenges",
                table: "GroupChallenges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChallenges_ChallengeCards_CardID",
                table: "GroupChallenges",
                column: "CardID",
                principalTable: "ChallengeCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChallenges_Groups_UserID",
                table: "GroupChallenges",
                column: "UserID",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupItems_Groups_UserID",
                table: "GroupItems",
                column: "UserID",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupItems_Items_ItemID",
                table: "GroupItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTransactions_Groups_UserID",
                table: "GroupTransactions",
                column: "UserID",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTransportations_Groups_UserID",
                table: "GroupTransportations",
                column: "UserID",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTransportations_Transportations_TypeID",
                table: "GroupTransportations",
                column: "TypeID",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
