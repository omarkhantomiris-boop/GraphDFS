using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<string, List<string>> graph;

    public Graph()
    {
        graph = new Dictionary<string, List<string>>();
    }

    public void AddVertex(string vertex)
    {
        if (!graph.ContainsKey(vertex))
        {
            graph[vertex] = new List<string>();
        }
    }

    public void AddEdge(string vertex1, string vertex2)
    {
        graph[vertex1].Add(vertex2);
        graph[vertex2].Add(vertex1);
    }

    public void PrintGraph()
    {
        foreach (var vertex in graph)
        {
            Console.Write(vertex.Key + " -> ");

            foreach (var neighbor in vertex.Value)
            {
                Console.Write(neighbor + " ");
            }

            Console.WriteLine();
        }
    }

    public void DFS(string start)
    {
        HashSet<string> visited = new HashSet<string>();
        DFSRecursive(start, visited);
    }

    private void DFSRecursive(string vertex, HashSet<string> visited)
    {
        visited.Add(vertex);
        Console.Write(vertex + " ");

        foreach (var neighbor in graph[vertex])
        {
            if (!visited.Contains(neighbor))
            {
                DFSRecursive(neighbor, visited);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Graph g = new Graph();

        g.AddVertex("A");
        g.AddVertex("B");
        g.AddVertex("C");
        g.AddVertex("D");
        g.AddVertex("E");

        g.AddEdge("A", "B");
        g.AddEdge("A", "C");
        g.AddEdge("B", "D");
        g.AddEdge("C", "E");

        Console.WriteLine("Граф:");
        g.PrintGraph();

        Console.WriteLine("\nDFS :");
        g.DFS("A");
    }
}