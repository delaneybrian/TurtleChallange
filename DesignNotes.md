# Design Notes
 
## Overall Design
The overall architecture is along the lines of Onion architecture where inner parts of the service, i.e. the domain, do not take a dependency on the external components i.e. file system, database, host etc. This allows for good separation of concerns and allows us to easily switch in and out components if required. 
 
While this is clearly a simple problem to solve my goal was to create a robust, extendable and reliable enterprise grade solution for it. Some of the parts may be overkill but they demonstrate the approaches that may be more valid in a real business scenario. 
 
Performance was considered as a secondary requirement in this solution. However I would consider the solution to perform adequately for this point of view at present without any evidence to suggest otherwise. 
 
## Project Descriptions 
 
### TurtleChallanage.Application
This project contains the code for tying all the parts of the service together. It gathers the required information and coordinates the interaction with the Domain. It should have no Infrastructure dependencies. It performs validation on the inputs while adhearing to the Open/Close principle of OOP.
 
### TurtleChallanage.Definitions
This project contains the data objects used throughout the service. These do not contain any logic and are dumb DTOs with no dependencies. I did not add validation attributes on these objects as I feel that this would be mixing logic and data which I wanted to avoid where possible.
 
### TurtleChallanage.Domain
This project contains all the logic for playing the actual TutleChallange Game itself. This project has external dependencies (except to TutrleChallange.Definitions) and is completely isolated to how the system is hosted, data is provided etc. 
 
Only the core business logic written by a domain expert is contained in this project. It should be easily understood by semi technical domain experts and product managers. The core logic should be encapsulated so that it can only be interacted with in certain specific ways. 
 
### TurtleChallanage.Interfaces
The interfaces shared throughout the service. These are the abstractions on which some of the other projects depend. 
 
### TurtleChallanage.Host
Hosts the project and configures the DI container. Should be barebones allowing us to easily switch how the service is hosted if required.
 
### TurtleChallanage.Infrastrucure
Implementations for the required classes that take a major dependency i.e. file system, db, output etc. Only the host should have a reference to this allowing the other projects to change the concrete implementation if required.
 
## Some Suggested Further Improvements
 
* Increased test coverage of the core domain (i.e. TurtleGame.cs). Currently this can be difficult to test because of the random placement of the mines. It may be worthwhile to abstract this randomness away from the Domain layer as the Randomness could be considered a dependency. 
 
* Better feedback to the user when validation fails. 
 
* Move of validation to its own _ValidationEngine_ rather than have it in the core _GameEngine_ to better adhere to the SRP.
 
* Better exception handling.
 
* Possibly move logic into other Domain Entities (i.e.) _BoardPoint.cs_ as _TurtleGame.cs_ may be considered to be doing too much.
 
* Reduce code duplication in UnitTests by having an abstract TestContextBase with shared logic
 
_any questions please feel free to email delaneybrian6@gmail.com_
 

