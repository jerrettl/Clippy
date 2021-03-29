# Clippy

[![Tests](https://github.com/Clippy5/Clippy/actions/workflows/tests.yml/badge.svg)](https://github.com/Clippy5/Clippy/actions/workflows/tests.yml)

# Product Vision

For internet users who find themselves having a difficult time organizing and discovering resources on the Web that sparks their interest, we introduce Clippy. Clippy is a social bookmarking service designed for users to explore and manage resources on the Internet. Users can immerse themselves in their own distraction-free space curated by them or explore resources gathered by others in the community. Unlike many other social bookmarking services, such as Pocket, Clippy is currently open source for anyone to adapt or use for themselves.

## Team Members

- Joshua Frazer (@BlackOutDevelops)
- Jordyn Hayden (@jordynhayden)
- Jerrett Longworth (@jerrettl)
- Diego Rodrigues (@diegoro1)
- Jaeivan Romero (@jaerom)

# Sprint 1

- [Product Backlog](https://trello.com/b/ui7fei2w/clippy)
- [Sprint Backlog](https://trello.com/b/ui7fei2w/clippy)
- [Requirements](https://trello.com/b/ui7fei2w/clippy)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)

## Task Allocation

Joshua Frazer - I setup the sub tasks and requirements for user stories on Trello. I also aided in creating multiple user stories which became of use for this week's sprint.

Jordyn Hayden - I setup my development enviornment by installing Visual Studio Code and .NET 5. I also created the API project which involved creating a blank .NET Core WebAPI project, adding an API status, swashbuckle dependency, .gitignore, and a README.md. I also setup a development server for the API where I installed the IIS and .NET Core hosting bundle, created the website, binded the domain to the website and installed an SSL certificate. Also, I installed an object-relational mapper, database migration files, and initial database. Finally, I aided in the creation of user stories and project documentation.

Jerrett Longworth - I created and refined the user stories for the project, as well as clarified the structure and format of the burndown chart.

Diego Rodrigues - I set up Visual Studio Code with multiple extensions for Javascript(React)/HTML/CSS for better productivity. Then, I created a new react-app, installed MaterialUI, and developed the website's static landing page. I placed the build on our server and configured it to output at the homepage. I finalized my tasks by contributing to the readme and other necessary documents.

Jaeivan Romero - I wrote the underlying code for our velocity chart and burndown chart using Python. I also slightly helped with the organization of user stories.

# Sprint 2

- [Trello Board](https://trello.com/b/ui7fei2w/clippy) (Backlogs and Requirements)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)
- [System Architecture](artifacts/architecture.md)
- [Product Demonstration](https://www.youtube.com/watch?v=-NDbI9Itwfs)

## Task Allocation

Joshua Frazer - I created complete UI Mockup of the Clippy website, incorporating the user stories from sprint 1 as a guide. I also revised the user stories by transitioning some of the requirements to separate cards while following the required format. In addition, I donated some time for project documentation such as the beginning of the high-level diagrams.

Jordyn Hayden - I created the ER diagram, helped with the development of the C4 Model, added to the UI mockup, and refined user stories and requirements.

Jerrett Longworth - I helped revise the user stories and requirements, worked on the high-level and class-level architecture diagrams, and worked on the system design document.

Diego Rodrigues - I contributed to the low-level UML diagrams by adding the React components and their functionalities. I also worked on the UI diagrams by creating pages and elements as well as its documentation. Finally, I created and edited the product demonstration.

Jaeivan Romero - I mainly worked on the first three levels of our achitecture diagrams and on the front end porition of the class-level diagram.

# Sprint 3

- [Trello Board](https://trello.com/b/ui7fei2w/clippy) (Backlogs and Requirements)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)
- [System Architecture](artifacts/architecture.md)
- [Source Code](project/src/Clippy)
- [Automated Tests](project/test/Clippy.Tests)
- [Product Demonstration](https://www.youtube.com/watch?v=WLseZofyHbY)

## Task Allocation

Joshua Frazer - Established an AWS server to better further frontend pair programming capabilities that is accessed through VS Code Live Share. Added UI components from Material UI relevant to user stories that linked to search bar, sign in button, avatar icon, navigation bar for sign in and rest of site, and clippy logo. Helped in folder reconstruction to better testing and clean up the components folder within the ClientApp folder.

Jordyn Hayden - I added React to the Clippy project so development of the UI, API, and Admin Portal is super slick and builds together. I created an xUnit unit test project that supports the running of automated tests. I developed the Admin Portal and secured it with a custom implementation of GitHub OAuth. I also completed several requirements: all communication is forced to use SSL, admins have the ability to log on and log off with GitHub, and admins are properly navigated after such actions. I documented all of this in the repository, complete with a getting started guide and details on development and testing configuration.

Jerrett Longworth - I created the product demonstration video and saw that the burndown and velocity charts are updated with the latest information from the Trello board.

Diego Rodrigues - Redesigned the login page to better-fit user stories. Added routers to the react frontend app for better transitioning between pages. Started the bookmarks pages as well as the UserNavbar component and added elements according to user stories. Changed the layout component to better-fit the UI diagrams and swapped bootstrap to material UI for the frontend. Established a VS code connection with pair programming capabilities to better the frontend development and helped create a second development server.

Jaeivan Romero - I restructured our React components folder to fit testing standards. I also setup our first frontend test.

# Sprint 4

- [Trello Board](https://trello.com/b/ui7fei2w/clippy) (Backlogs and Requirements)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)
- [System Architecture](artifacts/architecture.md)
- [Source Code](project/src/Clippy)
- Automated Tests:
  - [C# Tests](project/test/Clippy.Tests)
  - ~~[Javascript Tests](https://github.com/Clippy5/Clippy/tree/sprint-4/project/src/Clippy/ClientApp/src)~~
- [Product Demonstration](https://youtu.be/ETisNxjQkSE)

## Task Allocation

Joshua Frazer - Fixed UI glitches dealing with UserNavbar.css and Header.css due to css class names causing conflict with one another. Converted entire webpage to work on mobile without any glitching or scaling issues. Dedicated time in researching OAuth on frontend and helped in the decision process for project restructure.

Jordyn Hayden - I created the resources table in the database as well as the data version control files and seed data. I created the admin pages to add, edit, view, and delete each resource. I wrote the code that validates the resource data and tests to ensure the functionality and validation works properly. I also designed and coded the admin homepage that displays most recent resources added to the table. I published it all to our production server. I also recorded and published the demo. Finally, along with my team I contributed in the discussions and decisions of project restructure.

Jerrett Longworth - Added continuous integration using GitHub Actions, created a basic API call to interface with the React frontend, and worked on some styling for the about page.

Diego Rodrigues - Contributed to the front end OAuth research and attempted on implementing AuthO for the React front end. Helped in the decision process for the project restructure.

Jaeivan Romero - I restructed our components section to switch the landing page to the about page. Also added an about page with some basic content.

# Sprint 5

- [Trello Board](https://trello.com/b/ui7fei2w/clippy) (Backlogs and Requirements)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)
- [System Architecture](artifacts/architecture.md)
- [Source Code](project/src/Clippy)
  - `/Pages`: Contains all dynamic HTML (including reading from and writing to database).
  - `/wwwroot`: Contains all static content (including images, CSS, and JS).
- [Automated Tests](project/test/Clippy.Tests)
- [Product Demonstration](https://youtu.be/pUUb3lAEkcI)

## Task Allocation

Joshua Frazer - Pushed pages such as the About page from react to razor pages. Pair programmed backend to get our Users, Resources, and Bookmark databases up and running.

Jordyn Hayden - I restructured the project to use Razor Pages for the frontend, and also added Razor Runtime Compliations. I created the bookmarks table, the data migration files, all its seed data, and the data access interface to access it. I also created the users table, the data migration files, its seed data, and the data access interface to access it. I co-authored the user admin pages to add, edit, view, and delete users. I created the bookmark admin pages for view and delete. I created all the C# unit tests. I recorded a tutorial to help teach others how to code using Razor Pages. I wrote the code that validates the users and bookmarks data and tests to ensure the functionality and validation works properly. Finally, I created this week's demo.

Jerrett Longworth - Assisted in transitioning to Razor pages and user login flow (002). Added functionality to add bookmarks as an administrator (030).

Diego Rodrigues - Contributed to the user and resources backend functionalities. Fixed the bookmark's page UI and made it mobile-friendly.

Jaeivan Romero - I helped transtion our frontend to razor pages and worked on getting user login and backend data visible on the frontend.

# Sprint 6

- [Trello Board](https://trello.com/b/ui7fei2w/clippy) (Backlogs and Requirements)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)
- [System Architecture](artifacts/architecture.md)
- [Source Code](project/src/Clippy)
  - `/Pages`: Contains all dynamic HTML (including reading from and writing to database).
  - `/wwwroot`: Contains all static content (including images, CSS, and JS).
- [Automated Tests](project/test/Clippy.Tests)
- [Product Demonstration](https://youtu.be/N9ZHO5tC84Q)

## Task Allocation

Joshua Frazer - Made the avatar drop down list operational. Within the list is the new logout feature I implemented. Changed the entire explore page card layout to follow grid functionality. This way, when a bookmark gets added in the list, it is always updated and configured into a grid with autofitting. As for the bookmarks page, card layout had to be changed as well due to the cards carrying different behaviors. Helped redesign front page.

Jordyn Hayden - I completed 11 user stories for this sprint. I added filtering and sorting capabilities to all admin tables. I created the Tags table, the data migration files, all its seed data, and the data access interface to access it. I added the ability for the admin to add, edit, delete, and assign roles. I created the Roles table, the data migration files, all its seed data, and the data access interface to access it. I created a new database table that allows users to follow and subscribe to the bookmarks of other users. In addition, I created the ability for admins to assign subscriptions to users while adding a user. I wrote all of the C# unit tests associated with the admin functionality. I also styled the admin homepage to make it look cleaner and sexier. Finally, I recorded, edited and uploaded the demo for this sprint.

Jerrett Longworth - Worked on displaying a user's bookmarks on the main bookmarks page (043), and created the initial "Explore" page to explore the bookmarks of other users (017, 042).

Diego Rodrigues - Redesigned the front page to the original design listed in the UI diagram. Fixed the mobile dropdown menu to deliver a better user experience. Invested time into illustrator to design better assets for the website. (fix/homepage branch)

Jaeivan Romero - I worked on getting a users name and bookmarks on our main page and worked on our explore page which include other users bookmarks.

# Sprint 7

- [Trello Board](https://trello.com/b/ui7fei2w/clippy) (Backlogs and Requirements)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)
- [System Architecture](artifacts/architecture.md)
- [Source Code](project/src/Clippy)
  - `/Pages`: Contains all dynamic HTML (including reading from and writing to database).
  - `/wwwroot`: Contains all static content (including images, CSS, and JS).
- [Automated Tests](project/test/Clippy.Tests)
- [Product Demonstration](https://youtu.be/ceX5tmxsBVw)

## Task Allocation

Joshua Frazer - Added adding bookmark functionality to Clippy. Modified and finalized the entire card layout so columns of populated data won't be constrained to one window size. Helped create the entire profile page with all elements ready for future data. Updated the database to include unique descriptions and titles for each bookmark. Fixed UI bugs such as UI looking different across browsers and certain display elements not showing up on certain browsers.

Jordyn Hayden - I added successful notifications throughout the entire Admin which includes notifications for successful adds, updates, and deletes across the user, bookmark, resource, and roles tables. I also added unsuccessful notifications throughout the admin portal when an admin attempts to edit, update, or delete a record in the database that does not exist. Like the previous successful notifications, these unsuccessful notifications applies to users, bookmarks, roles, and resources. I refactored repetitive logic done in the frontend associated with displaying the avatar for the logged-in user by moving the code to a common component thereby removing redundency in the code base. I implemented application-wide logging, allowing developers to log meaningful events in a consistent manner. I configured two logging sources, a console and a rolling log file. I implemented critical logging associated with user accounts in the admin when an admin adds, updates, and deletes user accounts. Finally, I recorded, editing, and uploaded this sprint's demo.

Jerrett Longworth - Added automatic image downloading from bookmarked sites (057) and basic user bio functionality (058).

Diego Rodrigues - Completely remade the homepage with new assets created in photoshop and made the page responsive. Helped create the user page by establishing a responsive grid, layout, and aided in the data display process on the page. Helped fixed test failing bugs.

Jaeivan Romero - I helped with adding description and viewing for bookmarks. I also helped with laying out bookmarks in a compact fashion.

# Sprint 8

- [Trello Board](https://trello.com/b/ui7fei2w/clippy) (Backlogs and Requirements)
- [Burndown Chart](charts/README.md)
- [Velocity Chart](charts/README.md)
- [System Architecture](artifacts/architecture.md)
- [Source Code](project/src/Clippy)
  - `/Pages`: Contains all dynamic HTML (including reading from and writing to database).
  - `/wwwroot`: Contains all static content (including images, CSS, and JS).
- [Automated Tests](project/test/Clippy.Tests)
- Product Demonstration
  - [User Stakeholders](https://www.youtube.com/watch?v=ciMRdhPCCwo)
  - [Admin Stakeholders](https://youtu.be/6SsVq-Kz7jk)

## Task Allocation

Joshua Frazer - Add favorite bookmark functionality, deleting and editing bookmarks, following other people, viewing people that are following you and adding the clippy background.

Jordyn Hayden - I completed 11 user stories for this sprint. I implemented role-based security which among other things allows the Admin section to be secured by users with the Admin role. I added the ability to import bookmarks, users, roles, and resources. For all imports, I added a convenient sample so that an Admin can quickly view the schema for imports. I also added exporting capability for bookmarks, users, roles, and resources in the case an Admin wants to backup the data or transfer the data to a new database. I added public and favorite to Admin add, edit, view, import, and export bookmarks. I styled the explore, and profile page such that the cards appear more aesthetic. I also recorded, edited, and uploaded the Admin perspective sprint 8 demo. 

Jerrett Longworth - Added favorite bookmark functionality (013), deleting and editing bookmarks (004), following other people (045), viewing the profiles of other people, search functionality, and setting bookmarks as public/private (007).

Diego Rodrigues - Helped with the notifications functionality and profile page. Created the developer information page.

Jaeivan Romero - Added settings page, profile page, following page, notifications page. Added notification functionality and fix edit button.
