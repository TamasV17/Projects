using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs1
{
    class Graph<T>
    {
        public delegate void ExternalProcessor(string item);
        public delegate void GraphEventHandler<T>(object source, GraphEventArgs<T> geargs);
        public delegate void Counter(string From, string To, int r_Counter);
        public void BFS(T from, T to, Counter _method)
        {
            int r_counter = 0;
            Counter method = _method;
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();

            S.Enqueue(from);
            F.Add(from);

            while (S.Count != 0 && !F.Contains(to))
            {
                T k = S.Dequeue();
               
                foreach (T x in Neighbors(k))
                {
                    if (!F.Contains(x))
                    {
                        S.Enqueue(x);
                        F.Add(x);
                    }
                }
                r_counter++;
            }
            method?.Invoke(from.ToString(), to.ToString(), r_counter);
        }
        public List<T> contents;
        public List<List<T>> neighbors;

        public Graph()
        {
            contents = new List<T>();
            neighbors = new List<List<T>>();
        }
        

        public void AddNode(T node)
        {
            contents.Add(node);
            neighbors.Add(new List<T>());
        }
        public void AddEdge(T from, T to, GraphEventHandler<T> _method) //directed
        {
            neighbors[contents.IndexOf(from)].Add(to);
            neighbors[contents.IndexOf(to)].Add(from);
            GraphEventHandler<T> method = _method;
            method?.Invoke(this, new GraphEventArgs<T>(from, to));
            //undirected
            //int index = contents.IndexOf(from);
            //neighbors[index].Add(to);
        }
        public bool HasEdge(T from, T to)
        {
            int index = contents.IndexOf(from);
            if (neighbors[index].Contains(to))
            {
                return true;
            }
            return false;
        }
        public List<T> Neighbors(T node)
        {
            return neighbors[contents.IndexOf(node)];
        }

        public void BFS(T from, ExternalProcessor _method)
        {
            ExternalProcessor method = _method;
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();

            S.Enqueue(from);
            F.Add(from);

            while (S.Count!=0)
            {
                T k = S.Dequeue();
                method?.Invoke(k.ToString());
                foreach (T x in Neighbors(k))
                {
                    if (!F.Contains(x))
                    {
                        S.Enqueue(x);
                        F.Add(x);
                    }
                }
            }
        }
        public void DFS_starter(T from, ExternalProcessor _method)
        {
            List<T> F = new List<T>();
        }
        public void DFS(T from, ref List<T> to, ExternalProcessor _method)
        {
            ExternalProcessor method = _method;
            to.Add(from);
            method?.Invoke(from.ToString());
            foreach (T y in Neighbors(from))
            {
                if (!to.Contains(y))
                {
                    DFS(from, ref to, method);
                }
            }
        }
    }
}
