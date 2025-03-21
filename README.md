# Best-Route

.Net 9 Console API implementing the best route algorithm.

### Program Functions

- **GetRoutesFromFile**:
    Loads all avaiable routes from Routes.csv file.

- **GetGraphFromRoutes**:
    Gets a graph from all the routes origins combined with all the destinies.

- **FindBestRoute**:
    Finds the best route for the rigin and destiny based on the routes graph.

### Algorithm

The algorithm uses a [PriorityQueue](https://learn.microsoft.com/pt-br/dotnet/api/system.collections.generic.priorityqueue-2?view=net-9.0) (System.Collections.Generic) to recursively enquee all graph origin and destiny using the value as the priority to dequeue and when the route match with the destiny, so the best value is finded.


## Configuration

### Requirements

Need to install the follow:

- Git:
    https://git-scm.com/downloads

- Dotnet Core 9.0 SDK and Runtime:
    https://dotnet.microsoft.com/en-us/download/dotnet/9.0


## Getting Started

#### Clone the repository:

```bash
git clone https://github.com/fksalviano/best-route.git
```

#### Go to the project directory

```bash
cd best-route
```

#### Build the project

```bash
dotnet build
```

#### Run the application project

```bash
dotnet run --project Application/
```
