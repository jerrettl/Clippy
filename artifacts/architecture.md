Populate each section with information as it applies to your project. If a section does not apply, explain why. Include diagrams (or links to diagrams) in each section, as appropriate. For example, sketches of the user interfaces along with an explanation of how the interface components will work; ERD diagrams of the database; rough class diagrams; context diagrams showing the system boundary; etc. Do _not_ link to your diagrams, embed them directly in this document by uploading the images to your GitHub and linking to them. Do _not_ leave any section blank.

# Program Organization

You should have your context, container, and component (c4model.com) diagrams in this section, along with a description and explanation of each diagram and a table that relates each block to one or more user stories.

See Code Complete, Chapter 3 and https://c4model.com/

# Code Design

You should have your UML Class diagram and any other useful UML diagrams in this section. Each diagram should be accompanied by a brief description explaining what the elements are and why they are in the diagram. For your class diagram, you must also include a table that relates each class to one or more user stories.

See Code Complete, Chapter 3 and https://c4model.com/

# Data Design

If you are using a database, you should have a basic Entity Relationship Diagram (ERD) in this section. This diagram should describe the tables in your database and their relationship to one another (especially primary/foreign keys), including the columns within each table.

See Code Complete, Chapter 3

# Business Rules

You should list the assumptions, rules, and guidelines from external sources that are impacting your program design.

See Code Complete, Chapter 3

# User Interface Design

The User Interface Design with connecting transitions and user story documentation is [here](https://www.figma.com/file/IhVm7SrVe4bDZPFF8QcuLI/Clippy-UI-Mockup?node-id=0%3A1).

# Resource Management

Given the architecture as it is currently and the number of users expected to use Clippy, we foresee that the architecture should be able to handle load reasonably. For this reason, the currently pre-built solutions for handling API calls with the .NET libraries should be appropriate. In the case that system load exceeds what can be reasonably handled, the architecture would be reevaluated.

# Security

Certainly with most web-based applications, security poses a major role in architecture considerations. In the case of Clippy, we will have a two-fold security measure in terms of API calls with the database. First, there will be a component between the API and the user interface, aptly called the API-UI Connector. This component will sanitize the data that comes from user input. Once the API call is received, the API will then check again for the validity of its input, since the API could be called directly from a third-party application. In the event that the input is invalid or possibly malicious, the input will be rejected. Any information transferred over the internet will use the HTTPS protocol. There are no plans at this time to implement rate limiting or IP-based banning.

In terms of storage, any sensitive information like passwords or login keys will be hashed using SHA-2.

# Performance

See Code Complete, Chapter 3

# Scalability

See Code Complete, Chapter 3

# Interoperability

See Code Complete, Chapter 3

# Internationalization/Localization

See Code Complete, Chapter 3

# Input/Output

See Code Complete, Chapter 3

# Error Processing

See Code Complete, Chapter 3

# Fault Tolerance

See Code Complete, Chapter 3

# Architectural Feasibility

See Code Complete, Chapter 3

# Overengineering

See Code Complete, Chapter 3

# Build-vs-Buy Decisions

This section should list the third party libraries your system is using and describe what those libraries are being used for.

See Code Complete, Chapter 3

# Reuse

See Code Complete, Chapter 3

# Change Strategy

See Code Complete, Chapter 3
