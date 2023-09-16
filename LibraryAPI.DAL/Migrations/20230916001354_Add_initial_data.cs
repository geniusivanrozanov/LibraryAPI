using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.DAL.Migrations
{
    public partial class Add_initial_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("33ecf2d1-6a08-41b4-ae09-01931b0eaba3"), "Douglas", "Adams" },
                    { new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f"), "Ilya", "Ilf" },
                    { new Guid("90bb4ac3-913d-4969-b722-e2572e303266"), "Yevgeniy", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "ISBN", "Name" },
                values: new object[,]
                {
                    { new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text adventure game, and 2005 feature film.", "978-5-17-098748-1", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"), "The Twelve Chairs is a classic satirical novel by the Soviet authors Ilf and Petrov, published in 1928. Its plot follows characters attempting to obtain jewelry hidden in a chair. A sequel was published in 1931. The novel has been adapted to other media, primarily film.", "978-5-906947-13-0", "The Twelve Chairs" },
                    { new Guid("db60cfb8-c695-4424-93b2-16f399659560"), "One-storied America is a 1937 book based on a published travelogue across the United States by two Soviet authors, Ilf and Petrov. The book, divided into eleven chapters and in the uninhibited humorous style typical of Ilf and Petrov, paints a multi-faceted picture of the US.", "5-7516-0630-2", "One-storied America" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1264a07b-1bf4-4b65-bbc1-fc3e53cff87a"), "Adventure" },
                    { new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c"), "Novel" },
                    { new Guid("7a3b1aaf-1dbd-4136-8fcc-97df1e539910"), "Fiction" },
                    { new Guid("9284771e-b85d-4921-9d58-5c9aa91f8f5f"), "Sci-fy" },
                    { new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d"), "Humor" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { new Guid("33ecf2d1-6a08-41b4-ae09-01931b0eaba3"), new Guid("664d355c-9a27-45af-ab4e-4a94f314367a") },
                    { new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f"), new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca") },
                    { new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f"), new Guid("db60cfb8-c695-4424-93b2-16f399659560") },
                    { new Guid("90bb4ac3-913d-4969-b722-e2572e303266"), new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca") },
                    { new Guid("90bb4ac3-913d-4969-b722-e2572e303266"), new Guid("db60cfb8-c695-4424-93b2-16f399659560") }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"), new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c") },
                    { new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"), new Guid("9284771e-b85d-4921-9d58-5c9aa91f8f5f") },
                    { new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"), new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d") },
                    { new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"), new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c") },
                    { new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"), new Guid("7a3b1aaf-1dbd-4136-8fcc-97df1e539910") },
                    { new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"), new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d") },
                    { new Guid("db60cfb8-c695-4424-93b2-16f399659560"), new Guid("1264a07b-1bf4-4b65-bbc1-fc3e53cff87a") },
                    { new Guid("db60cfb8-c695-4424-93b2-16f399659560"), new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("33ecf2d1-6a08-41b4-ae09-01931b0eaba3"), new Guid("664d355c-9a27-45af-ab4e-4a94f314367a") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f"), new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f"), new Guid("db60cfb8-c695-4424-93b2-16f399659560") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("90bb4ac3-913d-4969-b722-e2572e303266"), new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("90bb4ac3-913d-4969-b722-e2572e303266"), new Guid("db60cfb8-c695-4424-93b2-16f399659560") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"), new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"), new Guid("9284771e-b85d-4921-9d58-5c9aa91f8f5f") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"), new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"), new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"), new Guid("7a3b1aaf-1dbd-4136-8fcc-97df1e539910") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"), new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("db60cfb8-c695-4424-93b2-16f399659560"), new Guid("1264a07b-1bf4-4b65-bbc1-fc3e53cff87a") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("db60cfb8-c695-4424-93b2-16f399659560"), new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("33ecf2d1-6a08-41b4-ae09-01931b0eaba3"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("90bb4ac3-913d-4969-b722-e2572e303266"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("db60cfb8-c695-4424-93b2-16f399659560"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1264a07b-1bf4-4b65-bbc1-fc3e53cff87a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1aaf-1dbd-4136-8fcc-97df1e539910"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9284771e-b85d-4921-9d58-5c9aa91f8f5f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d"));
        }
    }
}
