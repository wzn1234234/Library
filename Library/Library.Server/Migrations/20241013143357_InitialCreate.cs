using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookCheckOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookCheckOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookCheckOuts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookCheckOuts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Librarian", "LIBRARIAN" },
                    { 2, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CoverImagePath", "CreatedBy", "CreatedDate", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Ina Garten", "Autobiographies", "1.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8736), "Here, for the first time, Ina Garten presents an intimate, entertaining, and inspiring account of her remarkable journey. Ina's gift is to make everything look easy, yet all her accomplishments have been the result of hard work, audacious choices, and exquisite attention to detail. In her unmistakable voice (no one tells a story like Ina), she brings her past and her process to life in a high-spirited and no-holds-barred memoir that chronicles decades of personal challenges, adventures (and misadventures) and unexpected career twists, all delivered with her signature combination of playfulness and purpose. From a difficult childhood to meeting the love of her life, Jeffrey, and marrying him while still in college, from a boring bureaucratic job in Washington, D.C., to answering an ad for a specialty food store in the Hamptons, from the owner of one Barefoot Contessa shop to author of bestselling cookbooks and celebrated television host, Ina has blazed her own trail and, in the meantime, taught millions of people how to cook and entertain. Now, she invites them to come closer to experience her story in vivid detail and to share the important life lessons she learned along the way: do what you love because if you love it you'll be really good at it, swing for the fences, and always Be Ready When the Luck Happens.", "9780593799895", 320, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crown Publishing Group (NY)", "Be Ready When the Luck Happens", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8807) },
                    { 2, "Cicatelli-Kuc, Katie", "Fiction", "2.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8828), "sixteen-year-old Lucy Kane hates the uber-popular PSL. She finds it overrated -- especially when you consider the fact that there isn't even pumpkin in it! -- which is bad because she works at Cup o' Jo, the local coffee shop her mom owns. Business at Cup o' Jo hasn't been great in the off-season, but that's okay because it always picks up during the fall... Until Java Junction, a multinational coffee chain, opens across the street and makes things harder for the small shop. And to make matters worse, it turns out Jack Harper, the new kid in school and Lucy's secret crush, is the son of the owner.\"-- Provided by publisher.", "9781339030753", 336, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scholastic Press", "Pumpkin spice & everything nice", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8842) },
                    { 3, "Jeff Kinney", "Fiction", "3.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8859), "Greg Heffley is caught in the middle as the two halves of his extended family come together in a sidesplittingly relatable summer story! When the Heffleys agree to spend summer break with both Mom's and Dad's relatives at the same time, they have to figure out how to be in two places at once. With Greg caught in the middle, can the Heffleys pull off the ultimate scheme? Or will their vacation turn into a hilarious hot mess?", "9781419766954", 224, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry N. Abrams", "Diary of a Wimpy Kid Hot Mess", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8889) },
                    { 4, "Peter Brown", "Fiction", "4.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8922), "Roz the robot discovers that she is alone on a remote, wild island with no memory of where she is from or why she is there, and her only hope of survival is to try to learn about her new environment from the island's hostile inhabitants.", "9780316382007", 320, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Little, Brown Books for Young Readers", "The Wild Robot", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8936) },
                    { 5, "Han Kang and Deborah Smith", "Fiction", "5.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8953), "Before the nightmares began, Yeong-hye and her husband lived an ordinary, controlled life. But the dreams—invasive images of blood and brutality—torture her, driving Yeong-hye to purge her mind and renounce eating meat altogether. It’s a small act of independence, but it interrupts her marriage and sets into motion an increasingly grotesque chain of events at home. As her husband, her brother-in-law and sister each fight to reassert their control, Yeong-hye obsessively defends the choice that’s become sacred to her. Soon their attempts turn desperate, subjecting first her mind, and then her body, to ever more intrusive and perverse violations, sending Yeong-hye spiraling into a dangerous, bizarre estrangement, not only from those closest to her, but also from herself.   Celebrated by critics around the world, The Vegetarian From the Hardcover edition.", "9781101906118", 208, new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hogarth Press", "The Vegetarian", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8967) },
                    { 6, "Trey Gowdy", "Psychology", "6.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(8989), "Former federal prosecutor and congressman for South Carolina breaks down the art of persuasion into a few shockingly simple, easy-to-follow, and proven steps that will help readers win arguments, gain support for their cause, and convey their message successfully", "9780593138915", 288, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forum", "Doesn't Hurt to Ask : Using the Power of Questions to Communicate, Connect, and Persuade", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9003) },
                    { 7, "Al Pacino", "Biography", "7.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9019), "\"From one of the most iconic actors in the history of film, an astonishingly revelatory account of a creative life in full To the wider world, Al Pacino exploded onto the scene like a supernova. He landed his first leading role in The Panic in Needle Park in 1971, and by 1975, he had starred in four movies-The Godfather and The Godfather: Part II, Serpico, and Dog Day Afternoon-that were not just successes but landmarks in the history of film. Those performances became legendary and changed his life forever. Not since Marlon Brando and James Dean in the late 1950s had an actor landed in the culture with such force. But Pacino was in his mid-thirties by then and had already lived several lives. A fixture of avant-garde theater in New York, he had led a bohemian existence, working odd jobs to support his craft. He was raised by a fiercely loving but mentally unwell mother and her parents after his father left them when Pacino was a boy. In a real sense he was raised by the streets of the South Bronx and by the troop of buccaneering young friends he ran with, whose spirits never left him. After a teacher recognized his acting promise and pushed him toward New York's fabled High School of Performing Arts, the die was cast. In good times and in bad, in poverty and in wealth, through pain and through joy, acting was his lifeline, its community his tribe. Sonny Boy is the memoir of a man who has nothing left to fear and nothing left to hide. All the great roles, the essential collaborations, and the important relationships are given their full due, as is the vexed marriage between creativity and commerce at the highest levels. The book's golden thread, however, is the spirit of love and purpose. Love can fail you, and you can be defeated in your ambitions-the same lights that shine bright can also dim. But Al Pacino was lucky enough to fall deeply in love with a craft before he had the foggiest idea of any of its earthly rewards, and he never fell out of love. That has made all the difference\"-- Provided by publisher.", "9780593655115", 384, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Penguin Random House", "Sonny Boy : A Memoir", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9033) },
                    { 8, "David Allen Sibley", "Graphic", "8.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9051), "The bird book for birders and nonbirders alike that will excite and inspire by providing a new and deeper understanding of what common, mostly backyard, birds are doing--and why: \"Can birds smell?\"; \"Is this the same cardinal that was at my feeder last year?\"; \"Do robins 'hear' worms?\"\"The book's beauty mirrors the beauty of birds it describes so marvelously.\" --NPR In What It's Like to Be a Bird, David Sibley answers the most frequently asked questions about the birds we see most often. This special, large-format volume is geared as much to nonbirders as it is to the out-and-out obsessed, covering more than two hundred species and including more than 330 new illustrations by the author. While its focus is on familiar backyard birds--blue jays, nuthatches, chickadees--it also examines certain species that can be fairly easily observed, such as the seashore-dwelling Atlantic puffin. David Sibley's exacting artwork and wide-ranging expertise bring observed behaviors vividly to life. (For most species, the primary illustration is reproduced life-sized.) And while the text is aimed at adults--including fascinating new scientific research on the myriad ways birds have adapted to environmental changes--it is nontechnical, making it the perfect occasion for parents and grandparents to share their love of birds with young children, who will delight in the big, full-color illustrations of birds in action. Unlike any other book he has written, What It's Like to Be a Bird is poised to bring a whole new audience to David Sibley's world of birds.", "9780307957894", 240, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Knopf Publishing Group", "What It's Like to Be a Bird : From Flying to Nesting, Eating to Singing--What Birds Are Doing, and Why", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9089) },
                    { 9, "Akira Toriyama and Toyotarou", "Comics", "9.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9107), "\"In the wake of the commotion on Mt. Butterfly, Trunks decides to take a look into the data on the disc that he stole from Dr. Hedo's lab. However, the evil scientist intends to steal it back! And his genius plan is to create an android to infiltrate Trunks's school as a transfer student named Baytah. Meanwhile, the dastardly Red Ribbon Army is rising from the ashes and making new plans of their own.\"--Provided by publisher.", "9781974746866", 192, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viz Media", "Dragon Ball Super, Vol. 21", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9120) },
                    { 10, "Shea McGee", "Decoration", "10.png", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9139), "The long-awaited design book from Shea McGee, beautifully showcasing all that is possible for every room of your home.\r\n", "9780785236832", 408, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper Horizon", "The Art of Home : A Designer Guide to Creating an Elevated Yet Approachable Home", "admin", new DateTime(2024, 10, 13, 7, 33, 55, 296, DateTimeKind.Local).AddTicks(9152) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookCheckOuts_BookId",
                table: "UserBookCheckOuts",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookCheckOuts_UserId",
                table: "UserBookCheckOuts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookReviews_BookId",
                table: "UserBookReviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookReviews_UserId",
                table: "UserBookReviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserBookCheckOuts");

            migrationBuilder.DropTable(
                name: "UserBookReviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
