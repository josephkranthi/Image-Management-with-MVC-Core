## Image Project
Implemented a concept-oriented strategy within an ASP.NET Core MVC framework to handle image details in both a SQL Server Database and on a local machine. This involves utilizing a user interface for modifying images. The application facilitates CRUD operations, encompassing the creation, retrieval, updating, and deletion of image data in both the database and the local machine. Additionally, I've crafted sample websites covering topics such as fries, life, JSON file conversion, and nature using HTML, CSS, Bootstrap, JavaScript, and Fetch.

 ## Tech Stacks
 C#, .NET MVC Core, Entity Framework Core, SQL Server, Html, bootstrap, Javascript, jquery

## Database Setup
The project uses a SQL Server database to store contact information. 
  ~~~~sql
CREATE TABLE [dbo].[Images](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](100) NULL,
	[ImageData] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
  ~~~~

## How to Run the Project
To run the project, follow these steps:

* Clone the project to your local machine.
* Open the project in Visual Studio 2019 or later.
* Ensure that you have SQl Server installed and running on your machine.
* Open the web.config file and update the connection string to point to your Sql Server instance.
* Run the project. The API will be hosted on http://localhost:7083.
