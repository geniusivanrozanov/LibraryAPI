# Library API

## General information
CRUD Web API to simulate library (create, read, update, delete), runs on ASP.NET Core using Entity Framework Core

## Technologies

- ASP.NET Core
- Entity Framework Core
- Postgres
- JWT Bearer
- Identity
- AutoMapper
- Fluent Validation
- Swagger

Architecture &ndash; n-layer

---

## Get started

- [Launch](#launch)
  - [Run with docker](#run-with-docker)
  - [Run without docker](#run-without-docker)
- [Authorization](#authorization)
  - [Default users](#default-users)
  - [Registration](#registration)
  - [Log in](#log-in)
- [Books](#books)
  - [Get all books](#get-all-books)
  - [Get book by id](#get-book-by-id)
  - [Get book by ISBN](#get-book-by-isbn)
  - [Create new book](#create-new-book)
  - [Update existing book](#update-existing-book)
  - [Delete existing book](#delete-existing-book)
  - [Add author to book](#add-author-to-book)
  - [Remove author from book](#remove-author-from-book)
  - [Add genre to book](#add-genre-to-book)
  - [Remove genre from book](#remove-genre-from-book)
- [Authors](#authors)
  - [Get all authors](#get-all-authors)
  - [Get author by id](#get-author-by-id)
  - [Create new author](#create-new-author)
  - [Update existing author](#update-existing-author)
  - [Delete existing author](#delete-existing-author)
- [Genres](#genres)
  - [Get all genres](#get-all-genres)
  - [Get genre by id](#get-genre-by-id)
  - [Create new genre](#create-new-genre)
  - [Update existing genre](#update-existing-genre)
  - [Delete existing genre](#delete-existing-genre)
- [Rents](#rents)
  - [Get all rents](#get-all-rents)
  - [Get rent by id](#get-rent-by-id)
  - [Create new rent](#create-new-rent)
  - [Update existing rent](#update-existing-rent)
  - [Delete existing rent](#delete-existing-rent)

### Launch
It is advisable to use docker to run the application.

By default application starts in development environment, so you can use swagger to send requests.

#### Run with docker
To run the application use this command:
```console
docker-compose up
```
Use address `http://localhost:5000` to send requests.

___NOTE:___ using docker application works only with __http__.

#### Run without docker
Add your Postgres connection string to [appsettings.json](./LibraryAPI/appsettings.json) or [appsettings.Development.json](./LibraryAPI/appsettings.Development.json).

For example:
```json
{
  "ConnectionStrings": {
    "LibraryConnectionString": "Server=localhost;Port=5432;Database=Library;User Id=<your-postgres-user>;Password=<your-postgres-password>;"
  }
}
```
And use this command from root directory to run the application:
```console
dotnet run --project .\LibraryAPI\LibraryAPI.csproj
```
Use address `https://localhost:7259` or `http://localhost:5289` to send requests.

### Authorization

#### Default users
In [appsettings.json](./LibraryAPI/appsettings.json) you can find default users:
```json
{
  "DefaultUsers": [
    {
      "UserName": "admin",
      "Password": "admin",
      "Role": "admin"
    },
    {
      "UserName": "admin1",
      "Password": "admin1",
      "Role": "admin"
    },
    {
      "UserName": "user",
      "Password": "user",
      "Role": "user"
    }
  ]
}
```
You can add here your default user using next schema:
```json
{
  "UserName": "<your username>",
  "Password": "<your password>",
  "Role": "<user|admin>"
}
```
___NOTE:___ you can add __admin__ only by adding default user.

#### Registration
Send POST request on `/api/users/registration` with username and password in body:
```json
{
  "username": "<your username>",
  "password": "<your password>"
}
```
You will get token if user is created.

#### Log in
Send POST request on `/api/users/login` with username and password in body:
```json
{
  "username": "<your username>",
  "password": "<your password>"
}
```
You will get token if successfully logged in. Send `Bearer <your token>` in `Authorization` header in your requests. If you use swagger you can can pass it in "Authorize" window (without word "Bearer").

### Books

#### Get all books
To get all books send GET request on `/api/books`.

#### Get book by id
To get book by id send GET request on `/api/books/{id}`. You can use `664d355c-9a27-45af-ab4e-4a94f314367a` to try.

#### Get book by ISBN
To get book by ISBN send GET request on `/api/books/search` and pass ISBN in query parameters like `api/books/search?isbn=<ISBN>`. You can use `978-5-17-098748-1` to try.

#### Create new book
To create new book send POST request on `/api/books` with book data in body. Endpoint requires authorization as admin. Use next schema to try:
```json
{
  "isbn": "<book ISBN>",
  "name": "<book name>",
  "description": "<book description>"
}
```

___NOTE:___ book will be created without genres and authors. See [Add author to book](#add-author-to-book), [Remove author from book](#remove-author-from-book), [Add genre to book](#add-genre-to-book) and [Remove genre from book](#remove-genre-from-book).

#### Update existing book
To update existing book send PUT request on `/api/books/{id}` with book data in body. Endpoint requires authorization as admin. Use next schema to try:
```json
{
  "id": "<book id>",
  "isbn": "<book ISBN>",
  "name": "<book name>",
  "description": "<book description>"
}
```

#### Delete existing book
To delete existing book send DELETE request on `/api/books/{id}`. Endpoint requires authorization as admin.

#### Add author to book
To add author to book send POST request on `/api/books/{bookId}/authors` with `authorId` in body:
```json
"{authorId}"
```
Endpoint requires authorization as admin.

#### Remove author from book
To remove author from book send DELETE request on `/api/books/{bookId}/authors/{authorId}`.
Endpoint requires authorization as admin.

#### Add genre to book
To add genre to book send POST request on `/api/books/{bookId}/genres` with `genreId` in body:
```json
"{genreId}"
```
Endpoint requires authorization as admin.

#### Remove genre from book
To remove genre from book send DELETE request on `/api/books/{bookId}/genres/{genreId}`. Endpoint requires authorization as admin.

### Authors

#### Get all authors
To get all authors send GET request on `/api/authors`.

#### Get author by id
To get author by id send GET request on `/api/authors/{id}`. You can use `33ecf2d1-6a08-41b4-ae09-01931b0eaba3` to try.

#### Create new author
To create new author send POST request on `/api/authors` with author data in body. Endpoint requires authorization as admin. Use next schema to try:
```json
{
  "firstName": "<author`s first name>",
  "lastName": "<author`s last name>"
}
```

#### Update existing author
To update existing author send PUT request on `/api/authors/{id}` with author data in body. Endpoint requires authorization as admin. Use next schema to try:
```json
{
  "id": "<author id>",
  "firstName": "<author`s first name>",
  "lastName": "<author`s last name>"
}
```

#### Delete existing author
To delete existing author send DELETE request on `/api/authors/{id}`. Endpoint requires authorization as admin.

### Genres

#### Get all genres
To get all genres send GET request on `/api/genres`.

#### Get genre by id
To get genre by id send GET request on `/api/genres/{id}`. You can use `1264a07b-1bf4-4b65-bbc1-fc3e53cff87a` to try.

#### Create new genre
To create new genre send POST request on `/api/genres` with genre data in body. Endpoint requires authorization as admin. Use next schema to try:
```json
{
  "name": "<genre name>"
}
```

#### Update existing genre
To update existing genre send PUT request on `/api/genres/{id}` with genre data in body. Endpoint requires authorization as admin. Use next schema to try:
```json
{
  "id": "<genre id>",
  "name": "<genre name>"
}
```

#### Delete existing genre
To delete existing genre send DELETE request on `/api/genres/{id}`. Endpoint requires authorization as admin.

### Renting a book

#### Get all rents
To get all rents send GET request on `/api/bookrents`. Endpoint requires authorization as admin.

#### Get rent by id
To get rent by id send GET request on `/api/bookrents/{id}`. Endpoint requires authorization as admin.

#### Create new rent
To create new rent send POST request on `/api/bookrents` with rent data in body. Endpoint requires authorization. Use next schema to try:
```json
{
  "takingDate": "<yyyy-mm-dd>",
  "returnDate": "<yyyy-mm-dd>",
  "bookId": "<book id>"
}
```
___NOTE:___ id of the user who took the book stores in token.

#### Update existing rent
To update existing rent send PUT request on `/api/bookrents/{id}` with rent data in body. Endpoint requires authorization as admin. Use next schema to try:
```json
{
  "id": "<rent id>",
  "takingDate": "<yyyy-mm-dd>",
  "returnDate": "<yyyy-mm-dd>",
  "bookId": "<book id>"
}
```

#### Delete existing rent
To delete existing rent send DELETE request on `/api/bookrents/{id}`. Endpoint requires authorization as admin.