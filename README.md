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
	* [C# Tests](project/test/Clippy.Tests)
	* [Javascript Tests](project/src/Clippy/ClientApp/src)
- Product Demonstration

## Task Allocation

Joshua Frazer - Fixed UI glitches dealing with UserNavbar.css and Header.css due to css class names causing conflict with one another. Converted entire webpage to work on mobile without any glitching or scaling issues. Dedicated time in researching OAuth on frontend and helped in the decision process for project restructure.

Jordyn Hayden -

Jerrett Longworth - Added continuous integration using GitHub Actions, created a basic API call to interface with the React frontend, and worked on some styling for the about page.

Diego Rodrigues - Contributed to the front end OAuth research and attempted on implementing  AuthO for the React front end. Helped in the decision process for the project restructure. 

Jaeivan Romero -
