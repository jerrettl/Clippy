# Program Organization

<details><summary>System Context Diagram</summary>
<p>
Our system appears as one monolith to users, as well as administrators. Clippy depends on GitHub for providing authentication, and so users and administrators will be redirected to GitHub before being granted access to the Clippy System. The choice to require logins was deemed from user stories 001 and 022, and the choice to use GitHub is based on requirements R039 and R055.
<img src="assets/system-context-diagram.png" alt="System Context Diagram">
</p>
</details>

<details><summary>Container Diagram</summary>
<p>
The user will interact with a web-based application that is served from the ASP.NET server. The dynamic data served with the page is handled internally with in both the administrator-facing and user-facing pages.

ASP.NET was chosen out of its ability to communicate with a database model directly, utilizing the .NET Entity Framework, which maps database entries to objects. This choice is based on a prior level of familiarity using the framework within the group members.
<img src="assets/container-diagram.png" alt="Container Diagram">
</p>
</details>

<details><summary>Component Diagram</summary>
<p>
When the server runs, ASP.NET middleware handles exceptions, routing, authentication, authorization, among other tasks, with the goal of being able to work on the main user-facing product on top of a robust and pre-tested solution. The authorization and authentication component is augmented with an external GitHub OAuth application to provide login via GitHub. As part of the .NET Entity Framework, database entries are loaded with an object-relational mapper, which allows for accessing entries like they were members of a C# class.

The decision to use this set of components specifically is simply due to the structure of the ASP.NET framework, and building off of it is not necessarily a difficult task.
<img src="assets/component-diagram.png" alt="Component Diagram">
</p>
</details>

</br>

All components related to user functionality were created to fulfill user stories 001, 002, 003. The administrator portal is a result of user story 018. In a previous iteration of this architecture, a React.js project was used in tandem with Razor Pages, however the decision was made to remove React later, as it added extra complexity to the project as a whole.

# Code Design

## Front End Description

The front end will be composed of 5 pages, each connected by a router.

The login page is used to send the user's inputs gathered by the sign-in form component to be authenticated and is the gateway to the other pages.

The bookmark page component is composed of a sidebar component, that fetches the user's bookmarks to be filtered and sent to the bookmark display component which displays the props by calling multiple bookmark card components.

The profile page component is composed of two components. The user header, which displays the user's information, as well as the bookmark display components, which will display the filtered bookmarks by calling the bookmark card component.

The community page component consists of a bookmarks display component that also calls a bookmark card component to display the bookmark data.

The following page component calls the community component that fetches the user followers and following data and passes it to a user follower display component to then display such data.

Finally, the notification component fetches the user's follower's data and sends the said data to the display notification components that will then display the desired information.

All components have a navbar component that links all of them together.

</br>

<div align="center">
    <img src="assets/frontend.jpg" alt="frontend">
</div>

## Backend Server (from level 4 C4 Model)

![ER Diagam](assets/backend-server-level-4.png)

## Backend Server Description
Clippy uses C# for all of its technologies for the backend. The project is a series of controllers and classes that hook into the available ASP.NET and Entity Framework libraries. The classes in the project act as a bridge between these libraries, and allow for a project that is built on a robust existing framework.

Generally, each folder within the `project/src/Clippy` directory is a grouping of related classes. For example, `Data/` contains classes that directly interface with the database using the Entity Framework. `Entities/` contains classes that encapsulate entities within the Entity Framework. `Pages/` contains the classes and Razor page data for Clippy.

Apart from these folders, the `Program` and `Startup` classes handle the program initialization and setup.

### User Story Association

| Class               | User Story IDs                           |
|---------------------|-----------------------------------------|
| StatusController    |                                         |
| UsersController     | 001 016                                 |
| TagsController      | 013                                     |
| ResourcesController | 003 010 017                             |
| BookmarksController | 003 004 006                             |
| AuthController      | 001 016                                 |
| User                | 001 002                                 |
| Resource            | 003 006                                 |
| Bookmark            | 003 004 006                             |
| Tag                 | 013                                     |
| ClippyContext       | 001 002 003 004 006 010 013 016 017 018 |

# Data Design

![ER Diagam](assets/er-diagram.png)

# Business Rules

- The database must never be out of date with the user interface. For example, if a change is made on the user interface, the user interface must not update and reflect those changes until the database has confirmed and finished the transaction. *(Requirements R006, R010, R011)*
- The user interface must never have direct access to the database. Instead, there must always be an intermediate party that is connected to in order to communicate with the database. *(Requirements R040, R042)*
- It is assumed that there will be malicious data being sent in every step of Clippy's functionality. There must always be checks to validate the data passed into every function created. *(Requirement R004)*
- Performance is not considered a strict priority for this project, however, all interactions must have immediate feedback. Even if a transaction is being processed, there must still be feedback showing that some action is happening. *(Requirement R045)*
- Security is important to the operation of Clippy. At the very least, all information must be transferred over a secure protocol and sensitive data (like passwords and session keys) must be either hashed using a cryptographic hashing algorithm or encrypted with a sufficiently secure protocol. *(Requirements R039, R040, R041, R042)*

# User Interface Design

To access Clippy, the user must first create an account or log in. Once the login is successful, the user will be greeted with their list of saved bookmarks. The user then has the freedom to access their explore page, following page, profile page, and notifications page through the navigation bar.

<img src="assets/login-page.png" alt="Login Page">

The bookmark page is where the user will be given the capability of managing their bookmarks. They will be able to add, remove, and edit bookmarks.

<img src="assets/bookmarks-page.png" alt="Bookmarks Page">

The explore page will show the user a simple display of the trending bookmarks. The user will be able to add these bookmarks to their own favorites list.

<img src="assets/explore-page.png" alt="Explore Page">

The following page will display either the list of followers or the list of following. This list will be sorted by the search input, if used. The user can then unfollow any user they desire.

<img src="assets/following-page.png" alt="Following Page">

The profile page will display the user's information. Here, the user will be shown a list of recent bookmarks, followers, and favorite bookmarks. The user will also be able to change their biography.

<img src="assets/profile-page.png" alt="Profile Page">

The notifications page will simply show the user their follower's actions.

<img src="assets/notifications-page.png" alt="Notifications Page">

| UID | Page           | Effect on the UI                                                  |
| --- | :------------: | ----------------------------------------------------------------- |
| 001 | Log in page    | The only entrance to the web app is by login.                     |
| 003 | Bookmark page  | The bookmark page allows a user to add a bookmark.                |
| 004 | Bookmark page  | The bookmark page allows a user to delete a bookmark.             |
| 009 | Log in page    | The login page displays the logo.                                 |
| 010 | Community page | The community page grants the ability to see community bookmarks. |
| 013 | Community page | The community page lets users favorite bookmarks.                 |
| 017 | Community page | The community page grants the ability to see community bookmarks. |

The User Interface Design with connecting transitions and user story documentation is also [here](https://www.figma.com/proto/IhVm7SrVe4bDZPFF8QcuLI/Clippy-UI-Mockup?node-id=0%3A3&scaling=min-zoom). There you can preview the UI by clicking through each dynamic component.

# Resource Management

Given the number of users expected to use Clippy, we foresee that the current architecture should be able to handle load reasonably. For this reason, the currently pre-built solutions for handling authentication and routing using the .NET Framework should be appropriate. In the case that high system load causes errors in regular operation, the architecture would be reevaluated.

# Security

Certainly with most web-based applications, security poses a major role in architecture considerations. The ASP.NET architecture being used for this project handles many of the most important security points, and restricts access behind a login when necessary. Since the authentication middleware lies between the routing middleware and Razor Pages in the ASP.NET architecture, this is expected to be covered easily. There are no plans at this time to implement rate limiting or IP-based banning.

With any user-generated input, it should also be a high priority to ensure the internal database cannot be used maliciously. This is covered with the .NET Entity Framework as well, since it abstracts database queries from the programmer's use. Any manual SQL queries use standard parameterized queries to avoid SQL injection.

# Performance

The current system in place to deploy Clippy should be noted to be a low-power system, so there is reason to believe it may not perform well in extreme cases. For the state that the project is in now, it is expected that system performance should still meet the expectations for the quantity of users that will be on Clippy concurrently. For the purposes of illustration, it is expected that 30 users should be able to be handled simultaneously. There is not sufficient data to determine whether these expectations are able to be met at this time.

# Scalability

The system is currently designed in a way where basic functionality should be available for up to 30 users concurrently. Since, again, there is no data to determine how this system will perform under heavy load at this time, a lower number of concurrent users will be used to estimate performance. The system is not expected to grow considerably, so scalability will not be considered a priority at this time.

# Interoperability

The server is mainly alone in its operation and has no need to share resources with other systems. The only connection to outside web services it has is with the GitHub OAuth Application, which serves to provide an authentication method for users. This is required for the server to run properly and it will fail without it since there would otherwise be no way to authenticate a user.

# Internationalization/Localization

There is no intention at this time to support l18n or i10n for Clippy. It will only be available in English using the en_US locale. Unicode will be the default character set.

# Input/Output

All data will be handled just-in-time. The only data being written to and from local storage is the database, and tremendous corruption of data is not expected. Manual backups of the database will be kept at regular intervals to assure data is not lost in the worst situation.

# Error Processing

On a broad level, errors will only be detected, not corrected. Each class that receives input will check the validity of its incoming data before proceeding further. If for any reason, an input is perceived to be invalid, it will be rejected and the user would be shown an error message. The system will not attempt to proceed further. The system will anticipate errors with sanitization and validity checking.

Error messages will use a predefined set of strings available for the user, using as little variable output as possible. This will prevent malicious data collection from error messages to occur. In the event that an error needs further explanation, temporary debugging code will be written, to be removed upon resolving the issue.

All exceptions will be caught, providing information in the Javascript debugging console, given that proper debugging flags are enabled. The end-user should have little access to this information as to avoid possible leakage of sensitive data. Errors will be passed up the call chain.

# Fault Tolerance

The system presently is not intended to tolerate faults. Either an operation succeeds or fails, passing the result to the end user. This way, there is no ambiguous operations that arise from attempting to fix the error using an alternate method.

# Architectural Feasibility

Within the resources available, the architecture of the system should be feasible in its operation. The system is small enough to the extent that this is not a concern for the time being.

# Overengineering

The decision was made to have a project architecture that is likely more complex than necessary for the sake of using technologies and frameworks used in industry. While this does make the project more complex in scope, it also allows for a learning experience that is considered valuable. Generally, this project's approach will err on the side of overengineering to achieve this goal.

# Build-vs-Buy Decisions

With the novice level of experience between the developers involved in this project, the option was chosen to use pre-made solutions for many of the components in this project. As time progresses, first-party solutions may be used to replace the existing solution.

- User interface components will use the [React framework](https://reactjs.org/), specifically using components from [Material-UI](https://material-ui.com/).
- The API will be handled using [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore), built with ASP.NET Core.
- To interact with the database, the [SQLite Entity Framework Core Database Provider](https://docs.microsoft.com/en-us/ef/core/providers/sqlite/) from the .NET framework will be used.
- The administrator portal will use [Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/) in ASP.NET Core.

# Reuse

Since the third-party components inherently act as core components of the system, they will be coupled directly into the base functionality. In the event that different third-party tools are used, the changes would however still be isolated to their respective system. For example, if a different architecture were to be used for the API, any code on the React Server would be unaffected.

# Change Strategy

All changes to the code will be tracked using Git, allowing for modular changes to be made to the system and merged with ease. In the event that a new bug emerges, the Git repository can be used to revert to a previous state of the project and find the point in which that bug emerged, and find the change that caused it.
