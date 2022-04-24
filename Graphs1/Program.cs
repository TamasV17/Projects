using System;
using System.Collections.Generic;

namespace Graphs1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Graph<Person> graph = new Graph<Person>();
            Person Stew = new Person("Stew");
            graph.AddNode(Stew);
            Person Joseph = new Person("Joseph");
            graph.AddNode(Joseph);
            Person Marge = new Person("Marge");
            graph.AddNode(Marge);
            Person Gerald = new Person("Gerald");
            graph.AddNode(Gerald);
            Person Zack = new Person("Zack");
            graph.AddNode(Zack);
            Person Janet = new Person("Janet");
            graph.AddNode(Janet);
            Person Peter = new Person("Peter");
            graph.AddNode(Peter);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Stew)], graph.contents[graph.contents.IndexOf(Marge)], EdgeDisplay);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Stew)], graph.contents[graph.contents.IndexOf(Joseph)], EdgeDisplay);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Marge)], graph.contents[graph.contents.IndexOf(Joseph)], EdgeDisplay);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Joseph)], graph.contents[graph.contents.IndexOf(Gerald)], EdgeDisplay);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Joseph)], graph.contents[graph.contents.IndexOf(Zack)], EdgeDisplay);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Zack)], graph.contents[graph.contents.IndexOf(Gerald)], EdgeDisplay);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Zack)], graph.contents[graph.contents.IndexOf(Peter)], EdgeDisplay);
            graph.AddEdge(graph.contents[graph.contents.IndexOf(Peter)], graph.contents[graph.contents.IndexOf(Janet)], EdgeDisplay);
            Console.WriteLine("BFS test:");
            graph.BFS(Janet, Show);
            Console.WriteLine("DFS test:");
            graph.DFS_starter(Zack, Show);

        }
        static void EdgeDisplay(object source, GraphEventArgs<Person> geargs)
        {
            Console.WriteLine($"Edge between {geargs.From} and {geargs.To}");
        }
        static void CounterDisplay(string From, string To, int r_Counter)
        {
            Console.WriteLine($"{From} and {To} {r_Counter}-nd/st/th neighbors.");
        }
        public static void Show(string content)
        {
            Console.WriteLine(content);
        }
    }
}
