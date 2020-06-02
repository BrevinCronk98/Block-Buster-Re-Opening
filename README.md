# **Blockbuster**

#### Author: **_Jessica Hvozdovich and Brevin Cronk_**
#### June 2, 2020

<!-- ![Site Screenshot](./HairSalon/wwwroot/img/readmescreenshot.jpg) -->

### Description

_The purpose of this project is to create a C# web application and employ database basics with MySQL, Entity, and Identity. It also demonstrates the use of MVC routes that follow RESTful convention. This application takes user input to display different Directors and Movies that belong to in a many to many relationship._

### Instructions for use:

1. Open Terminal (macOS) or PowerShell (Windows)
2. To download the project directory to your desktop enter the following commands:
```
cd Desktop
git clone https://github.com/jhvozdovich/blockbuster.git
cd BlockBuster (or the file name you created for the main directory of the download)
```
3. To view the downloaded files, open them in a text editor or IDE of your choice.
* if you have VSCode for example, when your terminal is within the main project directory you can open all of the files with the command:
```
code .
```
4. Create a file within the Blockbuster folder named appsettings.json.
5. Add the following code:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=blockbuster;uid=root;pwd=YOURMYSQLPASSWORDHERE;"
  }
}
```
* Make any other changes needed if you have an alternative server, port, or uid selected. These are the default settings.

5. If you need to install the REPL dotnet script enter the following command in your terminal: 
```
dotnet tool install -g dotnet-script
```
6. To install the necessary dependencies and start a local host, after replicating the database steps below run the following commands:
```
dotnet restore
dotnet build
dotnet run
```

#### If you need to install and configure MySQL:
1. Download the MySQL Community Server DMG file [here](https://dev.mysql.com/downloads/file/?id=484914) with the "No thanks, just start my download" link.
2. On the configuration page of the installer select the following options:
* Use legacy password encryption
* Set your password
3. Open the terminal and enter the command:
*'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile
4. Download the MySQL Workbench DMG file [here](https://dev.mysql.com/downloads/file/?id=484391)
5. Open Local Instance 3306 with the password you set.

#### To create a local version of the database:
1. Open MySQL Workbench and Local Instance 3306.
2. Select the SQL + button in the top left of the navigation bar.
3. Paste the following in the query section to create the database:

```
CREATE DATABASE `blockbuster`;

USE `blockbuster`;
w
CREATE TABLE `movies` (
  `MovieId` int(11) NOT NULL AUTO_INCREMENT,
  `DirectorId` int(11) NOT NULL DEFAULT '0',
  `Name` varchar(255) DEFAULT NULL,
  `Regularmovie` tinyint(4) DEFAULT '0',
  `Usual` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`movieId`)
);

CREATE TABLE `directors` (
  `DirectorId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Specialty` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`DirectorId`)
);

```

4. Press the lightning bolt button to run this command.
5. If the database does not appear, right click in the schemas bar and select Refresh All.

### Known Bugs

No bugs have been identified at the time of this update.

### Support and Contact Information

Please contact me with any suggestions or questions at jhvozdovich@gmail.com. Thank you for your input!  
_Have a bug or an issue with this application? [Open a new issue](https://github.com/jhvozdovich/blockbuster/issues) here on GitHub._

### Technologies Used

* C#
* `ASP.NET` Core
* `ASP.NET` Core MVC
* Entity Framework Core
* `ASP.NET` Core Identity
* MySQL
* Git and GitHub

### Specs
| Spec | Input | Output |
| :------------- | :------------- | :------------- |
| **User enters home page** | User Input:"URL: localhost:5000/" | Output: “Welcome!” |
| **User can navigate to a page that lists directors** | User Input:"Click: View directors" | Output: “Wes Anderson, Patty Jenkins, Ryan Coogler” |
| **If no directors have been added a message appears** | User Input:"Click: View directors" | Output: “You have no directors listed! Add a few.” |
| **User can navigate to an add directors page** | User Input:"Click: Add directors" | Output: “Create a new director.” |
| **Owner can fill out the Add directors form** | User Input:"Enter New Director Name: Quentin Tarantino, Academy Awards: 0" | Output: “directors: Wes Anderson, Patty Jenkins, Ryan Coogler, Quentin Tarantino” |
| **User can click on directors to view their details and movies** | User Input:"Click: Patty Jenkins" | Output: “Name: Patty Jenkins Movies: Wonder Woman, Monster, Academy Awards: 0” |
| **If no movies have been added a message appears** | User Input:"Click: View movies" | Output: “You have no movies listed.” |
| **Owner can navigate to a create new movies page for each director** | User Input:"Click: Quentin Tarantino Click: Add movie" | Output: “Movie Form" |
| **Owner can add a new movie for each director** | User Input:"Name: Kill Bill, Year: 2003, Genre: Action" | Output: “Quentin Tarantiono movies: Kill Bill, Django Unchained, Inglourious Basterds, Pulp Fiction” |
| **User can view movie details when clicked** | User Input:"Click: Kill Bill" | Output: “Movie Details: "Name: Kill Bill, Year: 2003, Genre: Action, Copies: 3” |
| **User can delete a director** | User Input:"Click: Delete Director" | Output: “You have removed this Director!” |
| **User can delete a movie** | User Input:"Click: Delete movie" | Output: “You have removed this movie!” |
| **Patron can register** | User Input:"Click: Register" | Output: “Registration form” |
| **Patron can fill out registration information** | User Input:"Username: jhvozdovich Name: Jessica Password: HelloWorld" | Output: “Welcome Jessica” |
| **Patron can checkout** | User Input:"Movie: Kill Bill Date: Today's Date" | Output: “Due date: Two weeks from today” |
| **Patron can't checkout if no copies available** | User Input:"Movie: Kill Bill Date: Today's Date" | Output: “Copies: 0, Not available” |
| **Patron can view movies that are currently checked out** | User Input:"Click-Checkouts" | Output: “Movie: Kill Bill Due Date: June 16, 2020, Movie: Peter Pan Due Date June 20, 2020” |
| **Owner can view movies that are currently overdue** | User Input:"Click-Overdue" | Output: “Jessica - Kill Bill - Overdue - May 29, 2020, Brevin - Wonder Woman - Overdue May 30, 2020” |
| **Checkouts are only available to signed in patrons and are exclusive to their own history** | User Input:"Click: Checkouts" | Output: “Kill Bill - March 3, 2019, Wonder Woman - April 18, 2020” |

### Stretch Goals
&#9744; Genre table
&#9744; Connect user preferences to genre table

<!-- &#9745; -->

### Resources
(Background Image)[https://unsplash.com/photos/atsUqIm3wxo]

#### License

This software is licensed under the MIT license.

Copyright © 2020 **_Jessica Hvozdovich and Brevin Cronk_**