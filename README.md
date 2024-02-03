## Image Project
To manage image details in a SQL Server Database and on a local machine, you can modify images using a UI to perform CRUD operations. This involves creating, retrieving, updating, and deleting image data in the database and the local machine through the application. I have created some example websites (about fry, about life, convert json file and about nature) using HTML, CSS, Bootstrap, JavaScript, and Fetch.
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
