using Domain;

var routes = GetRoutesFromFile();

var cancelled = false;
Console.CancelKeyPress += new ConsoleCancelEventHandler((object? sender, ConsoleCancelEventArgs e) =>
{
    e.Cancel = false;
    cancelled = true;
});

while (!cancelled)
{
    Console.Write("Digite a origem e destino: ");

    var input = Console.ReadLine();
    var values = input?.Split("-");

    if (values is null || values.Length != 2)
    {
        Console.WriteLine("Dados inválidos: digite no formato XXX-YYY onde XXX=Origem e YYY=Destino");
        continue;
    }

    var origin = values[0].ToUpper();
    var destiny = values[1].ToUpper();

    var graph = GetGraphFromRoutes(routes);

    FindBestRoute(origin, destiny, graph);
}

static IEnumerable<Route> GetRoutesFromFile()
{
    var file = Path.Combine(AppContext.BaseDirectory, "Routes.csv");

    var routes = File.ReadAllLines(file).Select(line =>
    {
        var values = line.Split(',');
        return new Route(values[0], values[1], Convert.ToDouble(values[2]));
    });

    Console.Clear();
    Console.WriteLine("Rotas disponíveis:");
    Console.WriteLine();

    foreach (var route in routes)
    {
        Console.WriteLine($"{route.Origin}-{route.Destiny} {route.Value:C}");
    }
    Console.WriteLine();
    
    return routes;
}

static Dictionary<string, List<(string destiny, double value)>> GetGraphFromRoutes(IEnumerable<Route> routes)
{
    var graph = new Dictionary<string, List<(string destiny, double value)>>();

    foreach (var route in routes)
    {
        if (!graph.ContainsKey(route.Origin))
            graph[route.Origin] = new();

        graph[route.Origin].Add((route.Destiny, route.Value));
    }

    return graph;
}

static void FindBestRoute(string origin, string destiny, Dictionary<string, List<(string destiny, double value)>> graph)
{
    var queue = new PriorityQueue<(string city, double value, List<string> path), double>();
    queue.Enqueue((origin, 0, new List<string> { origin }), 0);

    while (queue.Count > 0)
    {
        var (city, value, path) = queue.Dequeue();

        if (city == destiny)
        {
            var result = string.Join(" - ", path) + $" ao custo de ${value}";
            Console.WriteLine($"Melhor rota encontrada: {result}");
            break;
        }

        if (graph.ContainsKey(city))
        {
            foreach (var (nextDestiny, nextValue) in graph[city])
            {
                var newPath = new List<string>(path) { nextDestiny };
                queue.Enqueue((nextDestiny, value + nextValue, newPath), priority: value + nextValue);
            }
        }
    }
}