using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini5
{
    public class Solution
    {
        static void Main()
        {
            var graph = new UndirectedWeightedDenseGraph<string>();

            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v" };

            graph.AddVertices(verticesSet1);

            graph.AddEdge("a", "s", 1);
            graph.AddEdge("a", "z", 2);
            graph.AddEdge("s", "x", 3);
            graph.AddEdge("x", "d", 1);
            graph.AddEdge("x", "c", 2);
            graph.AddEdge("x", "a", 3);
            graph.AddEdge("d", "f", 1);
            graph.AddEdge("d", "c", 2);
            graph.AddEdge("d", "s", 3);
            graph.AddEdge("c", "f", 1);
            graph.AddEdge("c", "v", 2);


            var allEdges = graph.Edges.ToList();

            Console.WriteLine(graph.ToReadable());
        }
    }

        
    }

    public class UndirectedWeightedDenseGraph<T> : UndirectedDenseGraph<T>, IWeightedGraph<T> where T : IComparable<T>
    {
        /// <summary>
        /// INSTANCE VARIABLES
        /// </summary>
        private const long EMPTY_EDGE_SLOT = 0;
        private const object EMPTY_VERTEX_SLOT = (object)null;

        // Store edges and their weights as integers.
        // Any edge with a value of zero means it doesn't exist. Otherwise, it exist with a specific weight value.
        // Default value for positive edges is 1.
        protected new long[,] _adjacencyMatrix { get; set; }


        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public UndirectedWeightedDenseGraph(uint capacity = 10)
        {
            this._edgesCount = 0;
            this._verticesCount = 0;
            this._verticesCapacity = (int)capacity;

            this._vertices = new ArrayList<object>(this._verticesCapacity);
            this._adjacencyMatrix = new long[this._verticesCapacity, this._verticesCapacity];
            this._adjacencyMatrix.Populate(rows: this._verticesCapacity, columns: this._verticesCapacity, defaultValue: EMPTY_EDGE_SLOT);
        }


        /// <summary>
        /// Helper function. Checks if edge exist in graph.
        /// </summary>
        protected override bool _doesEdgeExist(int source, int destination)
        {
            return (this._adjacencyMatrix[source, destination] != EMPTY_EDGE_SLOT) || (this._adjacencyMatrix[destination, source] != EMPTY_EDGE_SLOT);
        }

        /// <summary>
        /// Helper function. Gets the weight of a undirected edge.
        /// </summary>
        private long _getEdgeWeight(int source, int destination)
        {
            return (this._adjacencyMatrix[source, destination] != EMPTY_EDGE_SLOT ? this._adjacencyMatrix[source, destination] : this._adjacencyMatrix[destination, source]);
        }


        /// <summary>
        /// Returns true, if graph is weighted; false otherwise.
        /// </summary>
        public override bool IsWeighted
        {
            get { return true; }
        }

        /// <summary>
        /// An enumerable collection of edges.
        /// </summary>
        public virtual IEnumerable<WeightedEdge<T>> Edges
        {
            get
            {
                var seen = new HashSet<KeyValuePair<T, T>>();

                foreach (var vertex in this._vertices)
                {
                    int source = this._vertices.IndexOf(vertex);

                    for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
                    {
                        // Check existence of vertex
                        if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                        {
                            var neighbor = (T)this._vertices[adjacent];
                            var weight = this._getEdgeWeight(source, adjacent);

                            var outgoingEdge = new KeyValuePair<T, T>((T)vertex, neighbor);
                            var incomingEdge = new KeyValuePair<T, T>(neighbor, (T)vertex);

                            // Undirected edges should be checked once
                            if (seen.Contains(incomingEdge) || seen.Contains(outgoingEdge))
                                continue;
                            else
                                seen.Add(outgoingEdge);

                            yield return (new WeightedEdge<T>(outgoingEdge.Key, outgoingEdge.Value, weight));
                        }
                    }
                }//end-foreach
            }
        }

        /// <summary>
        /// Get all incoming edges to a vertex
        /// </summary>
        public virtual IEnumerable<WeightedEdge<T>> IncomingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            int source = this._vertices.IndexOf(vertex);

            for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
            {
                if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                {
                    yield return (new WeightedEdge<T>(
                        (T)this._vertices[adjacent],             // from
                        vertex,                             // to
                        this._getEdgeWeight(source, adjacent)    // weight
                    ));
                }
            }//end-for
        }

        /// <summary>
        /// Get all outgoing weighted edges from vertex
        /// </summary>
        public virtual IEnumerable<WeightedEdge<T>> OutgoingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            int source = this._vertices.IndexOf(vertex);

            for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
            {
                if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                {
                    yield return (new WeightedEdge<T>(
                        vertex,                             // from
                        (T)this._vertices[adjacent],             // to
                        this._getEdgeWeight(source, adjacent)    // weight
                    ));
                }
            }//end-for
        }


        /// <summary>
        /// Obsolete. Another AddEdge function is implemented with a weight parameter.
        /// </summary>
        [Obsolete("Use the AddEdge method with the weight parameter.")]
        public new bool AddEdge(T source, T destination)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connects two vertices together with a weight, in the direction: first->second.
        /// </summary>
        public virtual bool AddEdge(T source, T destination, long weight)
        {
            // Return if the weight is equals to the empty edge value
            if (weight == EMPTY_EDGE_SLOT)
                return false;

            // Get indices of vertices
            int srcIndex = this._vertices.IndexOf(source);
            int dstIndex = this._vertices.IndexOf(destination);

            // Check existence of vertices and non-existence of edge
            if (srcIndex == -1 || dstIndex == -1)
                return false;
            else if (this._doesEdgeExist(srcIndex, dstIndex))
                return false;

            // Use only one triangle of the matrix
            this._adjacencyMatrix[srcIndex, dstIndex] = weight;

            // Increment edges count
            ++this._edgesCount;

            return true;
        }

        /// <summary>
        /// Removes edge, if exists, from source to destination.
        /// </summary>
        public override bool RemoveEdge(T source, T destination)
        {
            // Get indices of vertices
            int srcIndex = this._vertices.IndexOf(source);
            int dstIndex = this._vertices.IndexOf(destination);

            // Check existence of vertices and non-existence of edge
            if (srcIndex == -1 || dstIndex == -1)
                return false;
            else if (!this._doesEdgeExist(srcIndex, dstIndex))
                return false;

            // Reset it both ways
            this._adjacencyMatrix[srcIndex, dstIndex] = EMPTY_EDGE_SLOT;
            this._adjacencyMatrix[dstIndex, srcIndex] = EMPTY_EDGE_SLOT;

            // Increment edges count
            --this._edgesCount;

            return true;
        }

        /// <summary>
        /// Updates the edge weight from source to destination.
        /// </summary>
        public virtual bool UpdateEdgeWeight(T source, T destination, long weight)
        {
            // Return if the weight is equals to the empty edge value
            if (weight == EMPTY_EDGE_SLOT)
                return false;

            // Get indices of vertices
            int srcIndex = this._vertices.IndexOf(source);
            int dstIndex = this._vertices.IndexOf(destination);

            // Check existence of vertices and non-existence of edge
            if (srcIndex == -1 || dstIndex == -1)
                return false;
            else if (!this._doesEdgeExist(srcIndex, dstIndex))
                return false;

            // Edge exists, use only one triangle of the matrix
            if (this._adjacencyMatrix[srcIndex, dstIndex] != EMPTY_EDGE_SLOT)
                this._adjacencyMatrix[srcIndex, dstIndex] = weight;
            else
                this._adjacencyMatrix[dstIndex, srcIndex] = weight;

            return true;
        }

        /// <summary>
        /// Removes the specified vertex from graph.
        /// </summary>
        public override bool RemoveVertex(T vertex)
        {
            // Return if graph is empty
            if (this._verticesCount == 0)
                return false;

            // Get index of vertex
            int index = this._vertices.IndexOf(vertex);

            // Return if vertex doesn't exists
            if (index == -1)
                return false;

            // Lazy-delete the vertex from graph
            //_vertices.Remove (vertex);
            this._vertices[index] = EMPTY_VERTEX_SLOT;

            // Decrement the vertices count
            --this._verticesCount;

            // Remove all outgoing and incoming edges to this vertex
            for (int i = 0; i < this._verticesCapacity; ++i)
            {
                if (this._doesEdgeExist(i, index))
                {
                    this._adjacencyMatrix[index, i] = EMPTY_EDGE_SLOT;
                    this._adjacencyMatrix[i, index] = EMPTY_EDGE_SLOT;

                    // Decrement the edges count
                    --this._edgesCount;
                }
            }

            return true;
        }

        /// <summary>
        /// Get edge object from source to destination.
        /// </summary>
        public virtual WeightedEdge<T> GetEdge(T source, T destination)
        {
            // Get indices of vertices
            int srcIndex = this._vertices.IndexOf(source);
            int dstIndex = this._vertices.IndexOf(destination);

            // Check the existence of vertices and the undirected edge
            if (srcIndex == -1 || dstIndex == -1)
                throw new Exception("One of the vertices or both of them doesn't exist.");
            else if (!this._doesEdgeExist(srcIndex, dstIndex))
                throw new Exception("Edge doesn't exist.");

            return (new WeightedEdge<T>(source, destination, this._getEdgeWeight(srcIndex, dstIndex)));
        }

        /// <summary>
        /// Returns the edge weight from source to destination.
        /// </summary>
        public virtual long GetEdgeWeight(T source, T destination)
        {
            return this.GetEdge(source, destination).Weight;
        }

        /// <summary>
        /// Returns the neighbours of a vertex as a dictionary of nodes-to-weights.
        /// </summary>
        public virtual Dictionary<T, long> NeighboursMap(T vertex)
        {
            if (!this.HasVertex(vertex))
                return null;

            var neighbors = new Dictionary<T, long>();
            int source = this._vertices.IndexOf(vertex);

            // Check existence of vertex
            if (source != -1)
                for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
                    if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                        neighbors.Add((T)this._vertices[adjacent], this._getEdgeWeight(source, adjacent));

            return neighbors;
        }

        /// <summary>
        /// Returns a human-readable string of the graph.
        /// </summary>
        public override string ToReadable()
        {
            string output = string.Empty;

            for (int i = 0; i < this._vertices.Count; ++i)
            {
                if (this._vertices[i] == null)
                    continue;

                var node = (T)this._vertices[i];
                var adjacents = string.Empty;

                output = String.Format("{0}\r\n{1}: [", output, node);

                foreach (var adjacentNode in this.NeighboursMap(node))
                    adjacents = String.Format("{0}{1}({2}), ", adjacents, adjacentNode.Key, adjacentNode.Value);

                if (adjacents.Length > 0)
                    adjacents = adjacents.TrimEnd(new char[] { ',', ' ' });

                output = String.Format("{0}{1}]", output, adjacents);
            }

            return output;
        }

        /// <summary>
        /// Clear this graph.
        /// </summary>
        public override void Clear()
        {
            this._edgesCount = 0;
            this._verticesCount = 0;
            this._vertices = new ArrayList<object>(this._verticesCapacity);
            this._adjacencyMatrix = new long[this._verticesCapacity, this._verticesCapacity];
            this._adjacencyMatrix.Populate(rows: this._verticesCapacity, columns: this._verticesCapacity, defaultValue: EMPTY_EDGE_SLOT);
        }
    }

    public class UndirectedDenseGraph<T> : IGraph<T> where T : IComparable<T>
    {
        /// <summary>
        /// INSTANCE VARIABLES
        /// </summary>
        private const object EMPTY_VERTEX_SLOT = (object)null;

        protected virtual int _edgesCount { get; set; }
        protected virtual int _verticesCount { get; set; }
        protected virtual int _verticesCapacity { get; set; }
        protected virtual ArrayList<object> _vertices { get; set; }
        protected virtual T _firstInsertedNode { get; set; }
        protected virtual bool[,] _adjacencyMatrix { get; set; }


        /// <summary>
        /// CONSTRUCTORS
        /// </summary>
        public UndirectedDenseGraph(uint capacity = 10)
        {
            this._edgesCount = 0;
            this._verticesCount = 0;
            this._verticesCapacity = (int)capacity;

            this._vertices = new ArrayList<object>(this._verticesCapacity);
            this._adjacencyMatrix = new bool[this._verticesCapacity, this._verticesCapacity];
            this._adjacencyMatrix.Populate(rows: this._verticesCapacity, columns: this._verticesCapacity, defaultValue: false);
        }


        /// <summary>
        /// Helper function. Checks if edge exist in graph.
        /// </summary>
        protected virtual bool _doesEdgeExist(int index1, int index2)
        {
            return (this._adjacencyMatrix[index1, index2] || this._adjacencyMatrix[index2, index1]);
        }

        /// <summary>
        /// Helper function that checks whether a vertex exist.
        /// </summary>
        protected virtual bool _doesVertexExist(T vertex)
        {
            return this._vertices.Contains(vertex);
        }


        /// <summary>
        /// Returns true, if graph is directed; false otherwise.
        /// </summary>
        public virtual bool IsDirected
        {
            get { return false; }
        }

        /// <summary>
        /// Returns true, if graph is weighted; false otherwise.
        /// </summary>
        public virtual bool IsWeighted
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the count of vetices.
        /// </summary>
        public virtual int VerticesCount
        {
            get { return this._verticesCount; }
        }

        /// <summary>
        /// Gets the count of edges.
        /// </summary>
        public virtual int EdgesCount
        {
            get { return this._edgesCount; }
        }

        /// <summary>
        /// Returns the list of Vertices.
        /// </summary>
        public virtual IEnumerable<T> Vertices
        {
            get
            {
                foreach (var item in this._vertices)
                    if (item != null)
                        yield return (T)item;
            }
        }


        IEnumerable<IEdge<T>> IGraph<T>.Edges
        {
            get { return this.Edges; }
        }

        IEnumerable<IEdge<T>> IGraph<T>.IncomingEdges(T vertex)
        {
            return this.IncomingEdges(vertex);
        }

        IEnumerable<IEdge<T>> IGraph<T>.OutgoingEdges(T vertex)
        {
            return this.OutgoingEdges(vertex);
        }


        /// <summary>
        /// An enumerable collection of edges.
        /// </summary>
        public virtual IEnumerable<UnweightedEdge<T>> Edges
        {
            get
            {
                var seen = new HashSet<KeyValuePair<T, T>>();

                foreach (var vertex in this._vertices)
                {
                    int source = this._vertices.IndexOf(vertex);

                    for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
                    {
                        // Check existence of vertex
                        if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                        {
                            var neighbor = (T)this._vertices[adjacent];

                            var outgoingEdge = new KeyValuePair<T, T>((T)vertex, neighbor);
                            var incomingEdge = new KeyValuePair<T, T>(neighbor, (T)vertex);

                            if (seen.Contains(incomingEdge) || seen.Contains(outgoingEdge))
                                continue;
                            else
                                seen.Add(outgoingEdge);

                            yield return new UnweightedEdge<T>(outgoingEdge.Key, outgoingEdge.Value);
                        }
                    }
                }//end-foreach
            }
        }

        /// <summary>
        /// Get all incoming edges to a vertex
        /// </summary>
        public IEnumerable<UnweightedEdge<T>> IncomingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            int source = this._vertices.IndexOf(vertex);

            for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
            {
                if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                {
                    yield return (new UnweightedEdge<T>(
                        (T)this._vertices[adjacent], // from
                        vertex                  // to
                    ));
                }
            }//end-for
        }

        /// <summary>
        /// Get all outgoing edges from a vertex.
        /// </summary>
        public IEnumerable<UnweightedEdge<T>> OutgoingEdges(T vertex)
        {
            if (!this.HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            int source = this._vertices.IndexOf(vertex);

            for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
            {
                if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                {
                    yield return (new UnweightedEdge<T>(
                        vertex,                 // from
                        (T)this._vertices[adjacent]  // to
                    ));
                }
            }//end-for
        }


        /// <summary>
        /// Connects two vertices together.
        /// </summary>
        public virtual bool AddEdge(T firstVertex, T secondVertex)
        {
            int indexOfFirst = this._vertices.IndexOf(firstVertex);
            int indexOfSecond = this._vertices.IndexOf(secondVertex);

            if (indexOfFirst == -1 || indexOfSecond == -1)
                return false;
            else if (this._doesEdgeExist(indexOfFirst, indexOfSecond))
                return false;

            this._adjacencyMatrix[indexOfFirst, indexOfSecond] = true;
            this._adjacencyMatrix[indexOfSecond, indexOfFirst] = true;

            // Increment the edges count.
            ++this._edgesCount;

            return true;
        }

        /// <summary>
        /// Deletes an edge, if exists, between two vertices.
        /// </summary>
        public virtual bool RemoveEdge(T firstVertex, T secondVertex)
        {
            int indexOfFirst = this._vertices.IndexOf(firstVertex);
            int indexOfSecond = this._vertices.IndexOf(secondVertex);

            if (indexOfFirst == -1 || indexOfSecond == -1)
                return false;
            else if (!this._doesEdgeExist(indexOfFirst, indexOfSecond))
                return false;

            this._adjacencyMatrix[indexOfFirst, indexOfSecond] = false;
            this._adjacencyMatrix[indexOfSecond, indexOfFirst] = false;

            // Decrement the edges count.
            --this._edgesCount;

            return true;
        }

        /// <summary>
        /// Adds a list of vertices to the graph.
        /// </summary>
        public virtual void AddVertices(IList<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            foreach (var item in collection)
                this.AddVertex(item);
        }

        /// <summary>
        /// Adds a new vertex to graph.
        /// </summary>
        public virtual bool AddVertex(T vertex)
        {
            // Return if graph reached it's maximum capacity
            if (this._verticesCount >= this._verticesCapacity)
                return false;

            // Return if vertex exists
            if (this._doesVertexExist(vertex))
                return false;

            // Initialize first inserted node
            if (this._verticesCount == 0)
                this._firstInsertedNode = vertex;

            // Try inserting vertex at previously lazy-deleted slot
            int indexOfDeleted = this._vertices.IndexOf(EMPTY_VERTEX_SLOT);

            if (indexOfDeleted != -1)
                this._vertices[indexOfDeleted] = vertex;
            else
                this._vertices.Add(vertex);

            // Increment the vertices count
            ++this._verticesCount;

            return true;
        }

        /// <summary>
        /// Removes the specified vertex from graph.
        /// </summary>
        public virtual bool RemoveVertex(T vertex)
        {
            // Return if graph is empty
            if (this._verticesCount == 0)
                return false;

            // Get index of vertex
            int index = this._vertices.IndexOf(vertex);

            // Return if vertex doesn't exists
            if (index == -1)
                return false;

            // Lazy-delete the vertex from graph
            //_vertices.Remove (vertex);
            this._vertices[index] = EMPTY_VERTEX_SLOT;

            // Decrement the vertices count
            --this._verticesCount;

            // Delete the edges
            for (int i = 0; i < this._verticesCapacity; ++i)
            {
                if (this._doesEdgeExist(index, i))
                {
                    this._adjacencyMatrix[index, i] = false;
                    this._adjacencyMatrix[i, index] = false;

                    // Decrement the edges count
                    --this._edgesCount;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether two vertices are connected (there is an edge between firstVertex & secondVertex)
        /// </summary>
        public virtual bool HasEdge(T firstVertex, T secondVertex)
        {
            int indexOfFirst = this._vertices.IndexOf(firstVertex);
            int indexOfSecond = this._vertices.IndexOf(secondVertex);

            // Check the existence of vertices and the directed edge
            return (indexOfFirst != -1 && indexOfSecond != -1 && this._doesEdgeExist(indexOfFirst, indexOfSecond) == true);
        }

        /// <summary>
        /// Determines whether this graph has the specified vertex.
        /// </summary>
        public virtual bool HasVertex(T vertex)
        {
            return this._vertices.Contains(vertex);
        }

        /// <summary>
        /// Returns the neighbours doubly-linked list for the specified vertex.
        /// </summary>
        public virtual DLinkedList<T> Neighbours(T vertex)
        {
            var neighbours = new DLinkedList<T>();
            int source = this._vertices.IndexOf(vertex);

            if (source != -1)
                for (int adjacent = 0; adjacent < this._vertices.Count; ++adjacent)
                    if (this._vertices[adjacent] != null && this._doesEdgeExist(source, adjacent))
                        neighbours.Append((T)this._vertices[adjacent]);

            return neighbours;
        }

        /// <summary>
        /// Returns the degree of the specified vertex.
        /// </summary>
        public virtual int Degree(T vertex)
        {
            if (!this.HasVertex(vertex))
                throw new KeyNotFoundException();

            return this.Neighbours(vertex).Count;
        }

        /// <summary>
        /// Returns a human-readable string of the graph.
        /// </summary>
        public virtual string ToReadable()
        {
            string output = string.Empty;

            for (int i = 0; i < this._vertices.Count; ++i)
            {
                if (this._vertices[i] == null)
                    continue;

                var node = (T)this._vertices[i];
                var adjacents = string.Empty;

                output = String.Format("{0}\r\n{1}: [", output, node);

                foreach (var adjacentNode in this.Neighbours(node))
                    adjacents = String.Format("{0}{1},", adjacents, adjacentNode);

                if (adjacents.Length > 0)
                    adjacents = adjacents.TrimEnd(new char[] { ',', ' ' });

                output = String.Format("{0}{1}]", output, adjacents);
            }

            return output;
        }

        /// <summary>
        /// A depth first search traversal of the graph starting from the first inserted node.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public virtual IEnumerable<T> DepthFirstWalk()
        {
            return this.DepthFirstWalk(this._firstInsertedNode);
        }

        /// <summary>
        /// A depth first search traversal of the graph, starting from a specified vertex.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public virtual IEnumerable<T> DepthFirstWalk(T source)
        {
            if (this._verticesCount == 0)
                return new ArrayList<T>();
            else if (!this.HasVertex(source))
                throw new Exception("The specified starting vertex doesn't exist.");

            var stack = new Stack<T>(this._verticesCount);
            var visited = new HashSet<T>();
            var listOfNodes = new ArrayList<T>(this._verticesCount);

            stack.Push(source);

            while (!stack.IsEmpty)
            {
                var current = stack.Pop();

                if (!visited.Contains(current))
                {
                    listOfNodes.Add(current);
                    visited.Add(current);

                    foreach (var adjacent in this.Neighbours(current))
                        if (!visited.Contains(adjacent))
                            stack.Push(adjacent);
                }
            }

            return listOfNodes;
        }

        /// <summary>
        /// A breadth first search traversal of the graphstarting from the first inserted node.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public virtual IEnumerable<T> BreadthFirstWalk()
        {
            return this.BreadthFirstWalk(this._firstInsertedNode);
        }

        /// <summary>
        /// A breadth first search traversal of the graph, starting from a specified vertex.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public virtual IEnumerable<T> BreadthFirstWalk(T source)
        {
            if (this._verticesCount == 0)
                return new ArrayList<T>();
            else if (!this.HasVertex(source))
                throw new Exception("The specified starting vertex doesn't exist.");

            var visited = new HashSet<T>();
            var queue = new Queue<T>(this.VerticesCount);
            var listOfNodes = new ArrayList<T>(this.VerticesCount);

            listOfNodes.Add(source);
            visited.Add(source);

            queue.Enqueue(source);

            while (!queue.IsEmpty)
            {
                var current = queue.Dequeue();
                var neighbors = this.Neighbours(current);

                foreach (var adjacent in neighbors)
                {
                    if (!visited.Contains(adjacent))
                    {
                        listOfNodes.Add(adjacent);
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                    }
                }
            }

            return listOfNodes;
        }

        /// <summary>
        /// Clear this graph.
        /// </summary>
        public virtual void Clear()
        {
            this._edgesCount = 0;
            this._verticesCount = 0;
            this._vertices.Clear();
            this._adjacencyMatrix = new bool[this._verticesCapacity, this._verticesCapacity];
            this._adjacencyMatrix.Populate(rows: this._verticesCapacity, columns: this._verticesCapacity, defaultValue: false);
        }

    }

    public interface IGraph<T> where T : IComparable<T>
    {
        /// <summary>
        /// Returns true, if graph is directed; false otherwise.
        /// </summary>
        bool IsDirected { get; }

        /// <summary>
        /// Returns true, if graph is weighted; false otherwise.
        /// </summary>
        bool IsWeighted { get; }

        /// <summary>
        /// Gets the count of vetices.
        /// </summary>
        int VerticesCount { get; }

        /// <summary>
        /// Gets the count of edges.
        /// </summary>
        int EdgesCount { get; }

        /// <summary>
        /// Returns the list of Vertices.
        /// </summary>
        IEnumerable<T> Vertices { get; }

        /// <summary>
        /// An enumerable collection of edges.
        /// </summary>
        IEnumerable<IEdge<T>> Edges { get; }

        /// <summary>
        /// Get all incoming edges from vertex
        /// </summary>
        IEnumerable<IEdge<T>> IncomingEdges(T vertex);

        /// <summary>
        /// Get all outgoing edges from vertex
        /// </summary>
        IEnumerable<IEdge<T>> OutgoingEdges(T vertex);

        /// <summary>
        /// Connects two vertices together.
        /// </summary>
        bool AddEdge(T firstVertex, T secondVertex);

        /// <summary>
        /// Deletes an edge, if exists, between two vertices.
        /// </summary>
        bool RemoveEdge(T firstVertex, T secondVertex);

        /// <summary>
        /// Adds a list of vertices to the graph.
        /// </summary>
        void AddVertices(IList<T> collection);

        /// <summary>
        /// Adds a new vertex to graph.
        /// </summary>
        bool AddVertex(T vertex);

        /// <summary>
        /// Removes the specified vertex from graph.
        /// </summary>
        bool RemoveVertex(T vertex);

        /// <summary>
        /// Checks whether two vertices are connected (there is an edge between firstVertex & secondVertex)
        /// </summary>
        bool HasEdge(T firstVertex, T secondVertex);

        /// <summary>
        /// Determines whether this graph has the specified vertex.
        /// </summary>
        bool HasVertex(T vertex);

        /// <summary>
        /// Returns the neighbours doubly-linked list for the specified vertex.
        /// </summary>
        DLinkedList<T> Neighbours(T vertex);

        /// <summary>
        /// Returns the degree of the specified vertex.
        /// </summary>
        int Degree(T vertex);

        /// <summary>
        /// Returns a human-readable string of the graph.
        /// </summary>
        string ToReadable();

        /// <summary>
        /// A depth first search traversal of the graph. Prints nodes as they get visited.
        /// It considers the first inserted vertex as the start-vertex for the walk.
        /// </summary>
        IEnumerable<T> DepthFirstWalk();

        /// <summary>
        /// A depth first search traversal of the graph, starting from a specified vertex. Prints nodes as they get visited.
        /// </summary>
        IEnumerable<T> DepthFirstWalk(T startingVertex);

        /// <summary>
        /// A breadth first search traversal of the graph. Prints nodes as they get visited.
        /// It considers the first inserted vertex as the start-vertex for the walk.
        /// </summary>
        IEnumerable<T> BreadthFirstWalk();

        /// <summary>
        /// A breadth first search traversal of the graph, starting from a specified vertex. Prints nodes as they get visited.
        /// </summary>
        IEnumerable<T> BreadthFirstWalk(T startingVertex);

        /// <summary>
        /// Clear this graph.
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// The Array-Based List Data Structure.
    /// </summary>
    public class ArrayList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Instance variables.
        /// </summary>

        // This sets the default maximum array length to refer to MAXIMUM_ARRAY_LENGTH_x64
        // Set the flag IsMaximumCapacityReached to false
        bool DefaultMaxCapacityIsX64 = true;
        bool IsMaximumCapacityReached = false;

        // The C# Maximum Array Length (before encountering overflow)
        // Reference: http://referencesource.microsoft.com/#mscorlib/system/array.cs,2d2b551eabe74985
        public const int MAXIMUM_ARRAY_LENGTH_x64 = 0X7FEFFFFF; //x64
        public const int MAXIMUM_ARRAY_LENGTH_x86 = 0x8000000; //x86

        // This is used as a default empty list initialization.
        private readonly T[] _emptyArray = new T[0];

        // The default capacity to resize to, when a minimum is lower than 5.
        private const int _defaultCapacity = 8;

        // The internal array of elements.
        // NOT A PROPERTY.
        private T[] _collection;

        // This keeps track of the number of elements added to the array.
        // Serves as an index of last item + 1.
        private int _size { get; set; }


        /// <summary>
        /// CONSTRUCTORS
        /// </summary>
        public ArrayList() : this(capacity: 0) { }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (capacity == 0)
            {
                this._collection = this._emptyArray;
            }
            else
            {
                this._collection = new T[capacity];
            }

            // Zerofiy the _size;
            this._size = 0;
        }


        /// <summary>
        /// Ensures the capacity.
        /// </summary>
        /// <param name="minCapacity">Minimum capacity.</param>
        private void _ensureCapacity(int minCapacity)
        {
            // If the length of the inner collection is less than the minCapacity
            // ... and if the maximum capacity wasn't reached yet, 
            // ... then maximize the inner collection.
            if (this._collection.Length < minCapacity && this.IsMaximumCapacityReached == false)
            {
                int newCapacity = (this._collection.Length == 0 ? _defaultCapacity : this._collection.Length * 2);

                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                int maxCapacity = (this.DefaultMaxCapacityIsX64 == true ? MAXIMUM_ARRAY_LENGTH_x64 : MAXIMUM_ARRAY_LENGTH_x86);

                if (newCapacity < minCapacity)
                    newCapacity = minCapacity;

                if (newCapacity >= maxCapacity)
                {
                    newCapacity = maxCapacity - 1;
                    this.IsMaximumCapacityReached = true;
                }

                this._resizeCapacity(newCapacity);
            }
        }


        /// <summary>
        /// Resizes the collection to a new maximum number of capacity.
        /// </summary>
        /// <param name="newCapacity">New capacity.</param>
        private void _resizeCapacity(int newCapacity)
        {
            if (newCapacity != this._collection.Length && newCapacity > this._size)
            {
                try
                {
                    Array.Resize<T>(ref this._collection, newCapacity);
                }
                catch (OutOfMemoryException)
                {
                    if (this.DefaultMaxCapacityIsX64 == true)
                    {
                        this.DefaultMaxCapacityIsX64 = false;
                        this._ensureCapacity(newCapacity);
                    }

                    throw;
                }
            }
        }


        /// <summary>
        /// Gets the the number of elements in list.
        /// </summary>
        /// <value>Int.</value>
        public int Count
        {
            get
            {
                return this._size;
            }
        }


        /// <summary>
        /// Returns the capacity of list, which is the total number of slots.
        /// </summary>
        public int Capacity
        {
            get { return this._collection.Length; }
        }


        /// <summary>
        /// Determines whether this list is empty.
        /// </summary>
        /// <returns><c>true</c> if list is empty; otherwise, <c>false</c>.</returns>
        public bool IsEmpty
        {
            get
            {
                return (this.Count == 0);
            }
        }


        /// <summary>
        /// Gets the first element in the list.
        /// </summary>
        /// <value>The first.</value>
        public T First
        {
            get
            {
                if (this.Count == 0)
                {
                    throw new IndexOutOfRangeException("List is empty.");
                }
                else
                {
                    return this._collection[0];
                }
            }
        }


        /// <summary>
        /// Gets the last element in the list.
        /// </summary>
        /// <value>The last.</value>
        public T Last
        {
            get
            {
                if (this.IsEmpty)
                {
                    throw new IndexOutOfRangeException("List is empty.");
                }
                else
                {
                    return this._collection[this.Count - 1];
                }
            }
        }


        /// <summary>
        /// Gets or sets the item at the specified index.
        /// example: var a = list[0];
        /// example: list[0] = 1;
        /// </summary>
        /// <param name="index">Index.</param>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this._size)
                {
                    throw new IndexOutOfRangeException();
                }

                return this._collection[index];
            }

            set
            {
                if (index < 0 || index >= this._size)
                {
                    throw new IndexOutOfRangeException();
                }

                this._collection[index] = value;
            }
        }


        /// <summary>
        /// Add the specified dataItem to list.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        public void Add(T dataItem)
        {
            if (this._size == this._collection.Length)
            {
                this._ensureCapacity(this._size + 1);
            }

            this._collection[this._size++] = dataItem;
        }


        /// <summary>
        /// Adds an enumerable collection of items to list.
        /// </summary>
        /// <param name="elements"></param>
        public void AddRange(IEnumerable<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();

            // make sure the size won't overflow by adding the range
            if (((uint)this._size + elements.Count()) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();

            // grow the internal collection once to avoid doing multiple redundant grows
            if (elements.Any())
            {
                this._ensureCapacity(this._size + elements.Count());

                foreach (var element in elements)
                    this.Add(element);
            }
        }


        /// <summary>
        /// Adds an element to list repeatedly for a specified count.
        /// </summary>
        public void AddRepeatedly(T value, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            if (((uint)this._size + count) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();

            // grow the internal collection once to avoid doing multiple redundant grows
            if (count > 0)
            {
                this._ensureCapacity(this._size + count);

                for (int i = 0; i < count; i++)
                    this.Add(value);
            }
        }


        /// <summary>
        /// Inserts a new element at an index. Doesn't override the cell at index.
        /// </summary>
        /// <param name="dataItem">Data item to insert.</param>
        /// <param name="index">Index of insertion.</param>
        public void InsertAt(T dataItem, int index)
        {
            if (index < 0 || index > this._size)
            {
                throw new IndexOutOfRangeException("Please provide a valid index.");
            }

            // If the inner array is full and there are no extra spaces, 
            // ... then maximize it's capacity to a minimum of _size + 1.
            if (this._size == this._collection.Length)
            {
                this._ensureCapacity(this._size + 1);
            }

            // If the index is not "at the end", then copy the elements of the array
            // ... between the specified index and the last index to the new range (index + 1, _size);
            // The cell at "index" will become available.
            if (index < this._size)
            {
                Array.Copy(this._collection, index, this._collection, index + 1, (this._size - index));
            }

            // Write the dataItem to the available cell.
            this._collection[index] = dataItem;

            // Increase the size.
            this._size++;
        }


        /// <summary>
        /// Removes the specified dataItem from list.
        /// </summary>
        /// <returns>>True if removed successfully, false otherwise.</returns>
        /// <param name="dataItem">Data item.</param>
        public bool Remove(T dataItem)
        {
            int index = this.IndexOf(dataItem);

            if (index >= 0)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Removes the list element at the specified index.
        /// </summary>
        /// <param name="index">Index of element.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this._size)
            {
                throw new IndexOutOfRangeException("Please pass a valid index.");
            }

            // Decrease the size by 1, to avoid doing Array.Copy if the element is to be removed from the tail of list. 
            this._size--;

            // If the index is still less than size, perform an Array.Copy to override the cell at index.
            // This operation is O(N), where N = size - index.
            if (index < this._size)
            {
                Array.Copy(this._collection, index + 1, this._collection, index, (this._size - index));
            }

            // Reset the writable cell to the default value of type T.
            this._collection[this._size] = default(T);
        }


        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            if (this._size > 0)
            {
                this._size = 0;
                Array.Clear(this._collection, 0, this._size);
                this._collection = this._emptyArray;
            }
        }


        /// <summary>
        /// Resize the List to a new size.
        /// </summary>
        public void Resize(int newSize)
        {
            this.Resize(newSize, default(T));
        }


        /// <summary>
        /// Resize the list to a new size.
        /// </summary>
        public void Resize(int newSize, T defaultValue)
        {
            int currentSize = this.Count;

            if (newSize < currentSize)
            {
                this._ensureCapacity(newSize);
            }
            else if (newSize > currentSize)
            {
                // Optimisation step.
                // This is just to avoid multiple automatic capacity changes.
                if (newSize > this._collection.Length)
                    this._ensureCapacity(newSize + 1);

                this.AddRange(Enumerable.Repeat<T>(defaultValue, newSize - currentSize));
            }
        }


        /// <summary>
        /// Reverses this list.
        /// </summary>
        public void Reverse()
        {
            this.Reverse(0, this._size);
        }


        /// <summary>
        /// Reverses the order of a number of elements. Starting a specific index.
        /// </summary>
        /// <param name="startIndex">Start index.</param>
        /// <param name="count">Count of elements to reverse.</param>
        public void Reverse(int startIndex, int count)
        {
            // Handle the bounds of startIndex
            if (startIndex < 0 || startIndex >= this._size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }

            // Handle the bounds of count and startIndex with respect to _size.
            if (count < 0 || startIndex > (this._size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            // Use Array.Reverse
            // Running complexity is better than O(N). But unknown.
            // Array.Reverse uses the closed-source function TrySZReverse.
            Array.Reverse(this._collection, startIndex, count);
        }


        /// <summary>
        /// For each element in list, apply the specified action to it.
        /// </summary>
        /// <param name="action">Typed Action.</param>
        public void ForEach(Action<T> action)
        {
            // Null actions are not allowed.
            if (action == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this._size; ++i)
            {
                action(this._collection[i]);
            }
        }


        /// <summary>
        /// Checks whether the list contains the specified dataItem.
        /// </summary>
        /// <returns>True if list contains the dataItem, false otherwise.</returns>
        /// <param name="dataItem">Data item.</param>
        public bool Contains(T dataItem)
        {
            // Null-value check
            if ((Object)dataItem == null)
            {
                for (int i = 0; i < this._size; ++i)
                {
                    if ((Object)this._collection[i] == null) return true;
                }
            }
            else
            {
                // Construct a default equality comparer for this Type T
                // Use it to get the equal match for the dataItem
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;

                for (int i = 0; i < this._size; ++i)
                {
                    if (comparer.Equals(this._collection[i], dataItem)) return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Checks whether the list contains the specified dataItem.
        /// </summary>
        /// <returns>True if list contains the dataItem, false otherwise.</returns>
        /// <param name="dataItem">Data item.</param>
        /// <param name="comparer">The Equality Comparer object.</param>
        public bool Contains(T dataItem, IEqualityComparer<T> comparer)
        {
            // Null comparers are not allowed.
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            // Null-value check
            if ((Object)dataItem == null)
            {
                for (int i = 0; i < this._size; ++i)
                {
                    if ((Object)this._collection[i] == null) return true;
                }
            }
            else
            {
                for (int i = 0; i < this._size; ++i)
                {
                    if (comparer.Equals(this._collection[i], dataItem)) return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Checks whether an item specified via a Predicate<T> function exists exists in list.
        /// </summary>
        /// <param name="searchMatch">Match predicate.</param>
        public bool Exists(Predicate<T> searchMatch)
        {
            // Use the FindIndex to look through the collection
            // If the returned index != -1 then it does exist, otherwise it doesn't.
            return (this.FindIndex(searchMatch) != -1);
        }


        /// <summary>
        /// Finds the index of the element that matches the predicate.
        /// </summary>
        /// <returns>The index of element if found, -1 otherwise.</returns>
        /// <param name="searchMatch">Match predicate.</param>
        public int FindIndex(Predicate<T> searchMatch)
        {
            return this.FindIndex(0, this._size, searchMatch);
        }


        /// <summary>
        /// Finds the index of the element that matches the predicate.
        /// </summary>
        /// <returns>The index of the element if found, -1 otherwise.</returns>
        /// <param name="startIndex">Starting index to search from.</param>
        /// <param name="searchMatch">Match predicate.</param>
        public int FindIndex(int startIndex, Predicate<T> searchMatch)
        {
            return this.FindIndex(startIndex, (this._size - startIndex), searchMatch);
        }


        /// <summary>
        /// Finds the index of the first element that matches the given predicate function.
        /// </summary>
        /// <returns>The index of element if found, -1 if not found.</returns>
        /// <param name="startIndex">Starting index of search.</param>
        /// <param name="count">Count of elements to search through.</param>
        /// <param name="searchMatch">Match predicate function.</param>
        public int FindIndex(int startIndex, int count, Predicate<T> searchMatch)
        {
            // Check bound of startIndex
            if (startIndex < 0 || startIndex > this._size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }

            // CHeck the bounds of count and startIndex with respect to _size
            if (count < 0 || startIndex > (this._size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            // Null match-predicates are not allowed
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            // Start the search
            int endIndex = startIndex + count;
            for (int index = startIndex; index < endIndex; ++index)
            {
                if (searchMatch(this._collection[index]) == true) return index;
            }

            // Not found, return -1
            return -1;
        }


        /// <summary>
        /// Returns the index of a given dataItem.
        /// </summary>
        /// <returns>Index of element in list.</returns>
        /// <param name="dataItem">Data item.</param>
        public int IndexOf(T dataItem)
        {
            return this.IndexOf(dataItem, 0, this._size);
        }


        /// <summary>
        /// Returns the index of a given dataItem.
        /// </summary>
        /// <returns>Index of element in list.</returns>
        /// <param name="dataItem">Data item.</param>
        /// <param name="startIndex">The starting index to search from.</param>
        public int IndexOf(T dataItem, int startIndex)
        {
            return this.IndexOf(dataItem, startIndex, this._size);
        }


        /// <summary>
        /// Returns the index of a given dataItem.
        /// </summary>
        /// <returns>Index of element in list.</returns>
        /// <param name="dataItem">Data item.</param>
        /// <param name="startIndex">The starting index to search from.</param>
        /// <param name="count">Count of elements to search through.</param>
        public int IndexOf(T dataItem, int startIndex, int count)
        {
            // Check the bound of the starting index.
            if (startIndex < 0 || (uint)startIndex > (uint)this._size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }

            // Check the bounds of count and starting index with respect to _size.
            if (count < 0 || startIndex > (this._size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            // Everything is cool, start looking for the index
            // Use the Array.IndexOf
            // Array.IndexOf has a O(n) running time complexity, where: "n = count - size".
            // Array.IndexOf uses EqualityComparer<T>.Default to return the index of element which loops
            // ... over all the elements in the range [startIndex,count) in the array.
            return Array.IndexOf(this._collection, dataItem, startIndex, count);
        }


        /// <summary>
        /// Find the specified element that matches the Search Predication.
        /// </summary>
        /// <param name="searchMatch">Match predicate.</param>
        public T Find(Predicate<T> searchMatch)
        {
            // Null Predicate functions are not allowed. 
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            // Begin searching, and return the matched element
            for (int i = 0; i < this._size; ++i)
            {
                if (searchMatch(this._collection[i]))
                {
                    return this._collection[i];
                }
            }

            // Not found, return the default value of the type T.
            return default(T);
        }


        /// <summary>
        /// Finds all the elements that match the typed Search Predicate.
        /// </summary>
        /// <returns>ArrayList<T> of matched elements. Empty list is returned if not element was found.</returns>
        /// <param name="searchMatch">Match predicate.</param>
        public ArrayList<T> FindAll(Predicate<T> searchMatch)
        {
            // Null Predicate functions are not allowed. 
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            ArrayList<T> matchedElements = new ArrayList<T>();

            // Begin searching, and add the matched elements to the new list.
            for (int i = 0; i < this._size; ++i)
            {
                if (searchMatch(this._collection[i]))
                {
                    matchedElements.Add(this._collection[i]);
                }
            }

            // Return the new list of elements.
            return matchedElements;
        }


        /// <summary>
        /// Get a range of elements, starting from an index..
        /// </summary>
        /// <returns>The range as ArrayList<T>.</returns>
        /// <param name="startIndex">Start index to get range from.</param>
        /// <param name="count">Count of elements.</param>
        public ArrayList<T> GetRange(int startIndex, int count)
        {
            // Handle the bound errors of startIndex
            if (startIndex < 0 || (uint)startIndex > (uint)this._size)
            {
                throw new IndexOutOfRangeException("Please provide a valid starting index.");
            }

            // Handle the bound errors of count and startIndex with respect to _size
            if (count < 0 || startIndex > (this._size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            var newArrayList = new ArrayList<T>(count);

            // Use Array.Copy to quickly copy the contents from this array to the new list's inner array.
            Array.Copy(this._collection, startIndex, newArrayList._collection, 0, count);

            // Assign count to the new list's inner _size counter.
            newArrayList._size = count;

            return newArrayList;
        }


        /// <summary>
        /// Return an array version of this list.
        /// </summary>
        /// <returns>Array.</returns>
        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];

            if (this.Count > 0)
            {
                Array.Copy(this._collection, 0, newArray, 0, this.Count);
            }

            return newArray;
        }


        /// <summary>
        /// Return an array version of this list.
        /// </summary>
        /// <returns>Array.</returns>
        public List<T> ToList()
        {
            var newList = new List<T>(this.Count);

            if (this.Count > 0)
            {
                for (int i = 0; i < this.Count; ++i)
                {
                    newList.Add(this._collection[i]);
                }
            }

            return newList;
        }


        /// <summary>
        /// Return a human readable, multi-line, print-out (string) of this list.
        /// </summary>
        /// <returns>The human readable string.</returns>
        /// <param name="addHeader">If set to <c>true</c> a header with count and Type is added; otherwise, only elements are printed.</param>
        public string ToHumanReadable(bool addHeader = false)
        {
            int i = 0;
            string listAsString = string.Empty;

            string preLineIndent = (addHeader == false ? "" : "\t");

            for (i = 0; i < this.Count; ++i)
            {
                listAsString = String.Format("{0}{1}[{2}] => {3}\r\n", listAsString, preLineIndent, i, this._collection[i]);
            }

            if (addHeader == true)
            {
                listAsString = String.Format("ArrayList of count: {0}.\r\n(\r\n{1})", this.Count, listAsString);
            }

            return listAsString;
        }


        /********************************************************************************/


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._collection[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }

    /// <summary>
    /// This interface should be implemented by all edges classes.
    /// </summary>
    public interface IEdge<TVertex> : IComparable<IEdge<TVertex>> where TVertex : IComparable<TVertex>
    {
        /// <summary>
        /// Gets a value indicating whether this edge is weighted.
        /// </summary>
        /// <value><c>true</c> if this edge is weighted; otherwise, <c>false</c>.</value>
        bool IsWeighted { get; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        TVertex Source { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        TVertex Destination { get; set; }

        /// <summary>
        /// Gets or sets the weight of edge.
        /// Unwighted edges can be thought of as edges of the same weight
        /// </summary>
        /// <value>The weight.</value>
        Int64 Weight { get; set; }
    }

    /// <summary>
    /// The graph edge class.
    /// </summary>
    public class UnweightedEdge<TVertex> : IEdge<TVertex> where TVertex : IComparable<TVertex>
    {
        private const int _edgeWeight = 0;

        /// <summary>
        /// Gets or sets the source vertex.
        /// </summary>
        /// <value>The source.</value>
        public TVertex Source { get; set; }

        /// <summary>
        /// Gets or sets the destination vertex.
        /// </summary>
        /// <value>The destination.</value>
        public TVertex Destination { get; set; }

        /// <summary>
        /// [PRIVATE MEMBER] Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public Int64 Weight
        {
            get { throw new NotImplementedException("Unweighted edges don't have weights."); }
            set { throw new NotImplementedException("Unweighted edges can't have weights."); }
        }

        /// <summary>
        /// Gets a value indicating whether this edge is weighted.
        /// </summary>
        public bool IsWeighted
        {
            get
            { return false; }
        }

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public UnweightedEdge(TVertex src, TVertex dst)
        {
            this.Source = src;
            this.Destination = dst;
        }


        #region IComparable implementation
        public int CompareTo(IEdge<TVertex> other)
        {
            if (other == null)
                return -1;

            bool areNodesEqual = this.Source.IsEqualTo<TVertex>(other.Source) && this.Destination.IsEqualTo<TVertex>(other.Destination);

            if (!areNodesEqual)
                return -1;
            else
                return 0;
        }
        #endregion
    }

    public static class Comparers
    {
        /// <summary>
        /// Determines if a specific value is a number.
        /// </summary>
        /// <returns><c>true</c> if the value is a number; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The Type of value.</typeparam>
        public static bool IsNumber<T>(this T value)
        {
            if (value is sbyte) return true;
            if (value is byte) return true;
            if (value is short) return true;
            if (value is ushort) return true;
            if (value is int) return true;
            if (value is uint) return true;
            if (value is long) return true;
            if (value is ulong) return true;
            if (value is float) return true;
            if (value is double) return true;
            if (value is decimal) return true;
            return false;
        }

        public static bool IsEqualTo<T>(this T firstValue, T secondValue) where T : IComparable<T>
        {
            return firstValue.Equals(secondValue);
        }

        public static bool IsGreaterThan<T>(this T firstValue, T secondValue) where T : IComparable<T>
        {
            return firstValue.CompareTo(secondValue) > 0;
        }

        public static bool IsLessThan<T>(this T firstValue, T secondValue) where T : IComparable<T>
        {
            return firstValue.CompareTo(secondValue) < 0;
        }

        public static bool IsGreaterThanOrEqualTo<T>(this T firstValue, T secondValue) where T : IComparable<T>
        {
            return (firstValue.IsEqualTo(secondValue) || firstValue.IsGreaterThan(secondValue));
        }

        public static bool IsLessThanOrEqualTo<T>(this T firstValue, T secondValue) where T : IComparable<T>
        {
            return (firstValue.IsEqualTo(secondValue) || firstValue.IsLessThan(secondValue));
        }
    }

    /// <summary>
    /// The Doubly-Linked List Node class.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class DLinkedListNode<T> : IComparable<DLinkedListNode<T>> where T : IComparable<T>
    {
        private T _data;
        private DLinkedListNode<T> _next;
        private DLinkedListNode<T> _previous;

        public DLinkedListNode() : this(default(T)) { }
        public DLinkedListNode(T dataItem) : this(dataItem, null, null) { }
        public DLinkedListNode(T dataItem, DLinkedListNode<T> next, DLinkedListNode<T> previous)
        {
            this.Data = dataItem;
            this.Next = next;
            this.Previous = previous;
        }

        public virtual T Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public virtual DLinkedListNode<T> Next
        {
            get { return this._next; }
            set { this._next = value; }
        }

        public virtual DLinkedListNode<T> Previous
        {
            get { return this._previous; }
            set { this._previous = value; }
        }

        public int CompareTo(DLinkedListNode<T> other)
        {
            if (other == null) return -1;

            return this.Data.CompareTo(other.Data);
        }
    }


    /***********************************************************************************/


    /// <summary>
    /// Doubly-Linked List Data Structure.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class DLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Instance variables.
        /// </summary>
        private int _count;
        private DLinkedListNode<T> _firstNode { get; set; }
        private DLinkedListNode<T> _lastNode { get; set; }

        public virtual DLinkedListNode<T> Head
        {
            get { return this._firstNode; }
        }

        public virtual int Count
        {
            get { return this._count; }
        }


        /// <summary>
        /// Gets the element at the specified index
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns>Element</returns>
        protected virtual T _getElementAt(int index)
        {
            if (this.IsEmpty() || index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("List is empty.");

            if (index == 0)
            {
                return this.First;
            }
            else if (index == (this.Count - 1))
            {
                return this.Last;
            }
            else
            {
                DLinkedListNode<T> currentNode = null;

                // Decide from which reference to traverse the list, and then move the currentNode reference to the index
                // If index > half then traverse it from the end (_lastNode reference)
                // Otherwise, traverse it from the beginning (_firstNode refrence)
                if (index > (this.Count / 2))
                {
                    currentNode = this._lastNode;
                    for (int i = (this.Count - 1); i > index; --i)
                    {
                        currentNode = currentNode.Previous;
                    }
                }
                else
                {
                    currentNode = this._firstNode;
                    for (int i = 0; i < index; ++i)
                    {
                        currentNode = currentNode.Next;
                    }
                }

                return currentNode.Data;
            }
        }

        /// <summary>
        /// Sets the value of the element at the specified index
        /// </summary>
        /// <param name="index">Index of element to update.</param>
        /// <returns>Element</returns>
        protected virtual void _setElementAt(int index, T value)
        {
            if (this.IsEmpty() || index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("List is empty.");

            if (index == 0)
            {
                this._firstNode.Data = value;
            }
            else if (index == (this.Count - 1))
            {
                this._lastNode.Data = value;
            }
            else
            {
                DLinkedListNode<T> currentNode = null;

                // Decide from which reference to traverse the list, and then move the currentNode reference to the index
                // If index > half then traverse it from the end (_lastNode reference)
                // Otherwise, traverse it from the beginning (_firstNode refrence)
                if (index > (this.Count / 2))
                {
                    currentNode = this._lastNode;
                    for (int i = (this.Count - 1); i > index; --i)
                    {
                        currentNode = currentNode.Previous;
                    }
                }
                else
                {
                    currentNode = this._firstNode;
                    for (int i = 0; i < index; ++i)
                    {
                        currentNode = currentNode.Next;
                    }
                }

                currentNode.Data = value;
            }
        }


        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public DLinkedList()
        {
            this._count = 0;
            this._firstNode = null;
            this._lastNode = null;
        }

        /// <summary>
        /// Determines whether this List is empty.
        /// </summary>
        /// <returns><c>true</c> if this list is empty; otherwise, <c>false</c>.</returns>
        public virtual bool IsEmpty()
        {
            return (this.Count == 0);
        }

        /// <summary>
        /// Getter function that returns the first element
        /// </summary>
        public virtual T First
        {
            get
            {
                if (this.IsEmpty())
                {
                    throw new Exception("Empty list.");
                }
                else
                {
                    return this._firstNode.Data;
                }
            }
        }

        /// <summary>
        /// Getter function that returns the last element
        /// </summary>
        public virtual T Last
        {
            get
            {
                if (this.IsEmpty())
                {
                    throw new Exception("Empty list.");
                }
                else if (this._lastNode == null)
                {
                    var currentNode = this._firstNode;
                    while (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                    this._lastNode = currentNode;
                    return currentNode.Data;
                }
                else
                {
                    return this._lastNode.Data;
                }
            }
        }

        /// <summary>
        /// Implements the collection-index operator.
        /// Gets or sets the element at the specified index
        /// </summary>
        /// <param name="index">Index of element.</param>
        public virtual T this[int index]
        {
            get { return this._getElementAt(index); }
            set { this._setElementAt(index, value); }
        }

        /// <summary>
        /// Returns the index of an item if exists.
        /// </summary>
        public virtual int IndexOf(T dataItem)
        {
            int i = 0;
            bool found = false;
            var currentNode = this._firstNode;

            // Get currentNode to reference the element at the index.
            while (i < this.Count)
            {
                if (currentNode.Data.IsEqualTo(dataItem))
                {
                    found = true;
                    break;
                }

                currentNode = currentNode.Next;
                i++;
            }//end-while

            return (found == true ? i : -1);
        }

        /// <summary>
        /// Prepend the specified dataItem at the beginning of the list.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        public virtual void Prepend(T dataItem)
        {
            DLinkedListNode<T> newNode = new DLinkedListNode<T>(dataItem);

            if (this._firstNode == null)
            {
                this._firstNode = this._lastNode = newNode;
            }
            else
            {
                var currentNode = this._firstNode;
                newNode.Next = currentNode;
                currentNode.Previous = newNode;
                this._firstNode = newNode;
            }

            // Increment the count.
            this._count++;
        }

        /// <summary>
        /// Append the specified dataItem at the end of the list.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        public virtual void Append(T dataItem)
        {
            DLinkedListNode<T> newNode = new DLinkedListNode<T>(dataItem);

            if (this._firstNode == null)
            {
                this._firstNode = this._lastNode = newNode;
            }
            else
            {
                var currentNode = this._lastNode;
                currentNode.Next = newNode;
                newNode.Previous = currentNode;
                this._lastNode = newNode;
            }

            // Increment the count.
            this._count++;
        }

        /// <summary>
        /// Inserts the dataItem at the specified index.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        /// <param name="index">Index.</param>
        public virtual void InsertAt(T dataItem, int index)
        {
            if (index < 0 || index > this.Count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                this.Prepend(dataItem);
            }
            else if (index == this.Count)
            {
                this.Append(dataItem);
            }
            else
            {
                DLinkedListNode<T> currentNode = null;
                DLinkedListNode<T> newNode = new DLinkedListNode<T>(dataItem);

                currentNode = this._firstNode;
                for (int i = 0; i < index - 1; ++i)
                {
                    currentNode = currentNode.Next;
                }

                var oldNext = currentNode.Next;

                if (oldNext != null)
                    currentNode.Next.Previous = newNode;

                newNode.Next = oldNext;
                currentNode.Next = newNode;
                newNode.Previous = currentNode;

                // Increment the count
                this._count++;
            }
        }

        /// <summary>
        /// Inserts the dataItem after specified index.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        /// <param name="index">Index.</param>
        public virtual void InsertAfter(T dataItem, int index)
        {
            // Insert at previous index.
            this.InsertAt(dataItem, index - 1);
        }

        /// <summary>
        /// Remove the specified dataItem.
        /// </summary>
        public virtual void Remove(T dataItem)
        {
            // Handle index out of bound errors
            if (this.IsEmpty())
                throw new IndexOutOfRangeException();

            if (this._firstNode.Data.IsEqualTo(dataItem))
            {
                this._firstNode = this._firstNode.Next;

                if (this._firstNode != null)
                    this._firstNode.Previous = null;
            }
            else if (this._lastNode.Data.IsEqualTo(dataItem))
            {
                this._lastNode = this._lastNode.Previous;

                if (this._lastNode != null)
                    this._lastNode.Next = null;
            }
            else
            {
                // Remove
                var currentNode = this._firstNode;

                // Get currentNode to reference the element at the index.
                while (currentNode.Next != null)
                {
                    if (currentNode.Data.IsEqualTo(dataItem))
                        break;

                    currentNode = currentNode.Next;
                }//end-while

                // Throw exception if item was not found
                if (!currentNode.Data.IsEqualTo(dataItem))
                    throw new Exception("Item was not found!");

                // Remove element
                DLinkedListNode<T> newPrevious = currentNode.Previous;
                DLinkedListNode<T> newNext = currentNode.Next;

                if (newPrevious != null)
                    newPrevious.Next = newNext;

                if (newNext != null)
                    newNext.Previous = newPrevious;

                currentNode = newPrevious;
            }

            // Decrement count.
            this._count--;
        }

        /// <summary>
        /// Remove the specified dataItem.
        /// </summary>
        public virtual void RemoveFirstMatch(Predicate<T> match)
        {
            // Handle index out of bound errors
            if (this.IsEmpty())
                throw new IndexOutOfRangeException();

            if (match(this._firstNode.Data))
            {
                this._firstNode = this._firstNode.Next;

                if (this._firstNode != null)
                    this._firstNode.Previous = null;
            }
            else if (match(this._lastNode.Data))
            {
                this._lastNode = this._lastNode.Previous;

                if (this._lastNode != null)
                    this._lastNode.Next = null;
            }
            else
            {
                // Remove
                var currentNode = this._firstNode;

                // Get currentNode to reference the element at the index.
                while (currentNode.Next != null)
                {
                    if (match(currentNode.Data))
                        break;

                    currentNode = currentNode.Next;
                }//end-while

                // If we reached the last node and item was not found
                // Throw exception
                if (!match(currentNode.Data))
                    throw new Exception("Item was not found!");

                // Remove element
                DLinkedListNode<T> newPrevious = currentNode.Previous;
                DLinkedListNode<T> newNext = currentNode.Next;

                if (newPrevious != null)
                    newPrevious.Next = newNext;

                if (newNext != null)
                    newNext.Previous = newPrevious;

                currentNode = newPrevious;
            }

            // Decrement count.
            this._count--;
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <returns>True if removed successfully, false otherwise.</returns>
        /// <param name="index">Index of item.</param>
        public virtual void RemoveAt(int index)
        {
            // Handle index out of bound errors
            if (this.IsEmpty() || index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException();

            // Remove
            if (index == 0)
            {
                this._firstNode = this._firstNode.Next;

                if (this._firstNode != null)
                    this._firstNode.Previous = null;
            }
            else if (index == this.Count - 1)
            {
                this._lastNode = this._lastNode.Previous;

                if (this._lastNode != null)
                    this._lastNode.Next = null;
            }
            else
            {
                int i = 0;
                var currentNode = this._firstNode;

                // Get currentNode to reference the element at the index.
                while (i < index)
                {
                    currentNode = currentNode.Next;
                    i++;
                }//end-while


                // Remove element
                var newPrevious = currentNode.Previous;
                var newNext = currentNode.Next;
                newPrevious.Next = newNext;

                if (newNext != null)
                    newNext.Previous = newPrevious;

                currentNode = newPrevious;
            }//end-else

            // Decrement count.
            this._count--;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public virtual void Clear()
        {
            this._count = 0;
            this._firstNode = this._lastNode = null;
        }

        /// <summary>
        /// Chesk whether the specified element exists in the list.
        /// </summary>
        /// <param name="dataItem">Value to check for.</param>
        /// <returns>True if found; false otherwise.</returns>
        public virtual bool Contains(T dataItem)
        {
            try
            {
                return this.Find(dataItem).IsEqualTo(dataItem);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Find the specified item in the list.
        /// </summary>
        /// <param name="dataItem">Value to find.</param>
        /// <returns>value.</returns>
        public virtual T Find(T dataItem)
        {
            if (this.IsEmpty())
                throw new Exception("List is empty.");

            var currentNode = this._firstNode;
            while (currentNode != null)
            {
                if (currentNode.Data.IsEqualTo(dataItem))
                    return dataItem;

                currentNode = currentNode.Next;
            }

            throw new Exception("Item was not found.");
        }

        /// <summary>
        /// Tries to find a match for the predicate. Returns true if found; otherwise false.
        /// </summary>
        public virtual bool TryFindFirst(Predicate<T> match, out T found)
        {
            // Initialize the output parameter
            found = default(T);

            if (this.IsEmpty())
                return false;

            var currentNode = this._firstNode;

            try
            {
                while (currentNode != null)
                {
                    if (match(currentNode.Data))
                    {
                        found = currentNode.Data;
                        return true;
                    }

                    currentNode = currentNode.Next;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Find the first element that matches the predicate from all elements in list.
        /// </summary>
        public virtual T FindFirst(Predicate<T> match)
        {
            if (this.IsEmpty())
                throw new Exception("List is empty.");

            var currentNode = this._firstNode;

            while (currentNode != null)
            {
                if (match(currentNode.Data))
                    return currentNode.Data;

                currentNode = currentNode.Next;
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Find all elements in list that match the predicate.
        /// </summary>
        /// <param name="match">Predicate function.</param>
        /// <returns>List of elements.</returns>
        public virtual List<T> FindAll(Predicate<T> match)
        {
            if (this.IsEmpty())
                throw new Exception("List is empty.");

            var currentNode = this._firstNode;
            var list = new List<T>();

            while (currentNode != null)
            {
                if (match(currentNode.Data))
                    list.Add(currentNode.Data);

                currentNode = currentNode.Next;
            }

            return list;
        }

        /// <summary>
        /// Returns a number of elements as specified by countOfElements, starting from the specified index.
        /// </summary>
        /// <param name="index">Starting index.</param>
        /// <param name="countOfElements">The number of elements to return.</param>
        /// <returns>Doubly-Linked List of elements</returns>
        public virtual DLinkedList<T> GetRange(int index, int countOfElements)
        {
            DLinkedListNode<T> currentNode = null;
            DLinkedList<T> newList = new DLinkedList<T>();

            // Handle Index out of Bound errors
            if (this.Count == 0)
            {
                return newList;
            }
            else if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            // Decide from which reference to traverse the list, and then move the currentNode reference to the index
            // If index > half then traverse it from the end (_lastNode reference)
            // Otherwise, traverse it from the beginning (_firstNode refrence)
            if (index > (this.Count / 2))
            {
                currentNode = this._lastNode;
                for (int i = (this.Count - 1); i > index; --i)
                {
                    currentNode = currentNode.Previous;
                }
            }
            else
            {
                currentNode = this._firstNode;
                for (int i = 0; i < index; ++i)
                {
                    currentNode = currentNode.Next;
                }
            }

            // Append the elements to the new list using the currentNode reference
            while (currentNode != null && newList.Count <= countOfElements)
            {
                newList.Append(currentNode.Data);
                currentNode = currentNode.Next;
            }

            return newList;
        }

        /// <summary>
        /// Sorts the entire list using Selection Sort.
        /// </summary>
        public virtual void SelectionSort()
        {
            if (this.IsEmpty())
                return;

            var currentNode = this._firstNode;
            while (currentNode != null)
            {
                var nextNode = currentNode.Next;
                while (nextNode != null)
                {
                    if (nextNode.Data.IsLessThan(currentNode.Data))
                    {
                        var temp = nextNode.Data;
                        nextNode.Data = currentNode.Data;
                        currentNode.Data = temp;
                    }

                    nextNode = nextNode.Next;
                }

                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Return an array version of this list.
        /// </summary>
        /// <returns></returns>
        public virtual T[] ToArray()
        {
            T[] array = new T[this.Count];

            var currentNode = this._firstNode;
            for (int i = 0; i < this.Count; ++i)
            {
                if (currentNode != null)
                {
                    array[i] = currentNode.Data;
                    currentNode = currentNode.Next;
                }
                else
                {
                    break;
                }
            }

            return array;
        }

        /// <summary>
        /// Returns a System.List version of this DLList instace.
        /// </summary>
        /// <returns>System.List of elements</returns>
        public virtual List<T> ToList()
        {
            List<T> list = new List<T>(this.Count);

            var currentNode = this._firstNode;
            for (int i = 0; i < this.Count; ++i)
            {
                if (currentNode != null)
                {
                    list.Add(currentNode.Data);
                    currentNode = currentNode.Next;
                }
                else
                {
                    break;
                }
            }

            return list;
        }

        /// <summary>
        /// Returns the list items as a readable multi--line string.
        /// </summary>
        /// <returns></returns>
        public virtual string ToReadable()
        {
            string listAsString = string.Empty;
            int i = 0;
            var currentNode = this._firstNode;

            while (currentNode != null)
            {
                listAsString = String.Format("{0}[{1}] => {2}\r\n", listAsString, i, currentNode.Data);
                currentNode = currentNode.Next;
                ++i;
            }

            return listAsString;
        }

        /********************************************************************************/

        public IEnumerator<T> GetEnumerator()
        {
            var node = this._firstNode;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }

            // Alternative: IEnumerator class instance
            // return new DLinkedListEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();

            // Alternative: IEnumerator class instance
            // return new DLinkedListEnumerator(this);
        }

        /********************************************************************************/

        internal class DLinkedListEnumerator : IEnumerator<T>
        {
            private DLinkedListNode<T> _current;
            private DLinkedList<T> _doublyLinkedList;

            public DLinkedListEnumerator(DLinkedList<T> list)
            {
                this._current = list.Head;
                this._doublyLinkedList = list;
            }

            public T Current
            {
                get { return this._current.Data; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                if (this._current.Next != null)
                    this._current = this._current.Next;
                else
                    return false;

                return true;
            }

            public bool MovePrevious()
            {
                if (this._current.Previous != null)
                    this._current = this._current.Previous;
                else
                    return false;

                return true;
            }

            public void Reset()
            {
                this._current = this._doublyLinkedList.Head;
            }

            public void Dispose()
            {
                this._current = null;
                this._doublyLinkedList = null;
            }
        }

    }

    /// <summary>
    /// The Stack (LIFO) Data Structure.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class Stack<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Instance variables.
        /// _collection: Array-Based List.
        /// Count: Public Getter for returning the number of elements.
        /// </summary>
        private ArrayList<T> _collection { get; set; }
        public int Count { get { return this._collection.Count; } }


        /// <summary>
        /// CONSTRUCTORS
        /// </summary>
        public Stack()
        {
            // The internal collection is implemented as an array-based list.
            // See the ArrayList.cs for the list implementation.
            this._collection = new ArrayList<T>();
        }


        public Stack(int initialCapacity)
        {
            if (initialCapacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            // The internal collection is implemented as an array-based list.
            // See the ArrayList.cs for the list implementation.
            this._collection = new ArrayList<T>(initialCapacity);
        }


        /// <summary>
        /// Checks whether the stack is empty.
        /// </summary>
        /// <returns>True if stack is empty, false otherwise.</returns>
        public bool IsEmpty
        {
            get
            {
                return this._collection.IsEmpty;
            }
        }


        /// <summary>
        /// Returns the top element in the stack.
        /// </summary>
        public T Top
        {
            get
            {
                try
                {
                    return this._collection[this._collection.Count - 1];
                }
                catch (Exception)
                {
                    throw new Exception("Stack is empty.");
                }
            }
        }


        /// <summary>
        /// Inserts an element at the top of the stack.
        /// </summary>
        /// <param name="dataItem">Element to be inserted.</param>
        public void Push(T dataItem)
        {
            this._collection.Add(dataItem);
        }


        /// <summary>
        /// Removes the top element from stack.
        /// </summary>
        public T Pop()
        {
            if (this.Count > 0)
            {
                var top = this.Top;
                this._collection.RemoveAt(this._collection.Count - 1);
                return top;
            }
            else
            {
                throw new Exception("Stack is empty.");
            }
        }

        /// <summary>
        /// Returns an array version of this stack.
        /// </summary>
        /// <returns>System.Array.</returns>
        public T[] ToArray()
        {
            return this._collection.ToArray();
        }


        /// <summary>
        /// Returns a human-readable, multi-line, print-out (string) of this stack.
        /// </summary>
        /// <returns>String.</returns>
        public string ToHumanReadable()
        {
            return this._collection.ToHumanReadable();
        }


        /********************************************************************************/


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this._collection.Count - 1; i >= 0; --i)
                yield return this._collection[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }

    /// <summary>
    /// The Queue (FIFO) Data Structure.
    /// </summary>
    public class Queue<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        /// INSTANCE VARIABLE.
        /// </summary>
        private int _size { get; set; }
        private int _headPointer { get; set; }
        private int _tailPointer { get; set; }

        // The internal collection.
        private object[] _collection { get; set; }
        private const int _defaultCapacity = 8;

        // This sets the default maximum array length to refer to MAXIMUM_ARRAY_LENGTH_x64
        // Set the flag IsMaximumCapacityReached to false
        bool DefaultMaxCapacityIsX64 = true;
        bool IsMaximumCapacityReached = false;

        // The C# Maximum Array Length (before encountering overflow)
        // Reference: http://referencesource.microsoft.com/#mscorlib/system/array.cs,2d2b551eabe74985
        public const int MAXIMUM_ARRAY_LENGTH_x64 = 0X7FEFFFFF; //x64
        public const int MAXIMUM_ARRAY_LENGTH_x86 = 0x8000000; //x86


        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public Queue() : this(_defaultCapacity) { }

        public Queue(int initialCapacity)
        {
            if (initialCapacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this._size = 0;
            this._headPointer = 0;
            this._tailPointer = 0;
            this._collection = new object[initialCapacity];
        }


        /// <summary>
        /// Resize the internal array to a new size.
        /// </summary>
        private void _resize(int newSize)
        {
            if (newSize > this._size && !this.IsMaximumCapacityReached)
            {
                int capacity = (this._collection.Length == 0 ? _defaultCapacity : this._collection.Length * 2);

                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                int maxCapacity = (this.DefaultMaxCapacityIsX64 == true ? MAXIMUM_ARRAY_LENGTH_x64 : MAXIMUM_ARRAY_LENGTH_x86);

                // Handle the new proper size
                if (capacity < newSize)
                    capacity = newSize;

                if (capacity >= maxCapacity)
                {
                    capacity = maxCapacity - 1;
                    this.IsMaximumCapacityReached = true;
                }

                // Try resizing and handle overflow
                try
                {
                    //Array.Resize (ref _collection, newSize);

                    var tempCollection = new object[newSize];
                    Array.Copy(this._collection, this._headPointer, tempCollection, 0, this._size);
                    this._collection = tempCollection;
                }
                catch (OutOfMemoryException)
                {
                    if (this.DefaultMaxCapacityIsX64 == true)
                    {
                        this.DefaultMaxCapacityIsX64 = false;
                        this._resize(capacity);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// Returns count of elements in queue
        /// </summary>
        public int Count
        {
            get { return this._size; }
        }

        /// <summary>
        /// Checks whether the queue is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return this._size == 0; }
        }

        /// <summary>
        /// Returns the top element in queue
        /// </summary>
        public T Top
        {
            get
            {
                if (this.IsEmpty)
                    throw new Exception("Queue is empty.");

                return (T)this._collection[this._headPointer];
            }
        }

        /// <summary>
        /// Inserts an element at the end of the queue
        /// </summary>
        /// <param name="dataItem">Element to be inserted.</param>
        public void Enqueue(T dataItem)
        {
            if (this._size == this._collection.Length)
            {
                try
                {
                    this._resize(this._collection.Length * 2);
                }
                catch (OutOfMemoryException ex)
                {
                    throw ex;
                }
            }

            // Enqueue item at tail and then increment tail
            this._collection[this._tailPointer++] = dataItem;

            // Wrap around
            if (this._tailPointer == this._collection.Length)
                this._tailPointer = 0;

            // Increment size
            this._size++;
        }

        /// <summary>
        /// Removes the Top Element from queue, and assigns it's value to the "top" parameter.
        /// </summary>
        /// <return>The top element container.</return>
        public T Dequeue()
        {
            if (this.IsEmpty)
                throw new Exception("Queue is empty.");

            var topItem = this._collection[this._headPointer];
            this._collection[this._headPointer] = null;

            // Decrement the size
            this._size--;

            // Increment the head pointer
            this._headPointer++;

            // Reset the pointer
            if (this._headPointer == this._collection.Length)
                this._headPointer = 0;

            // Shrink the internal collection
            if (this._size > 0 && this._collection.Length > _defaultCapacity && this._size <= this._collection.Length / 4)
            {
                // Get head and tail
                var head = this._collection[this._headPointer];
                var tail = this._collection[this._tailPointer];

                // Shrink
                this._resize((this._collection.Length / 3) * 2);

                // Update head and tail pointers
                this._headPointer = Array.IndexOf(this._collection, head);
                this._tailPointer = Array.IndexOf(this._collection, tail);
            }

            return (T)topItem;
        }

        /// <summary>
        /// Returns an array version of this queue.
        /// </summary>
        /// <returns>System.Array.</returns>
        public T[] ToArray()
        {
            var array = new T[this._size];

            int j = 0;
            for (int i = 0; i < this._size; ++i)
            {
                array[j] = (T)this._collection[this._headPointer + i];
                j++;
            }

            return array;
        }

        /// <summary>
        /// Returns a human-readable, multi-line, print-out (string) of this queue.
        /// </summary>
        public string ToHumanReadable()
        {
            var array = this.ToArray();
            string listAsString = string.Empty;

            int i = 0;
            for (i = 0; i < this.Count; ++i)
                listAsString = String.Format("{0}[{1}] => {2}\r\n", listAsString, i, array[i]);

            return listAsString;
        }


        /********************************************************************************/


        public IEnumerator<T> GetEnumerator()
        {
            return this._collection.GetEnumerator() as IEnumerator<T>;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public static class Helpers
    {
        /// <summary>
        /// Swap two values in an IList<T> collection given their indexes.
        /// </summary>
        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)   //This check is not required but Partition function may make many calls so its for perf reason
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        /// <summary>
        /// Swap two values in an ArrayList<T> collection given their indexes.
        /// </summary>
        public static void Swap<T>(this ArrayList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)   //This check is not required but Partition function may make many calls so its for perf reason
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        /// <summary>
        /// Centralize a text.
        /// </summary>
        public static string PadCenter(this string text, int newWidth, char fillerCharacter = ' ')
        {
            if (string.IsNullOrEmpty(text))
                return text;

            int length = text.Length;
            int charactersToPad = newWidth - length;
            if (charactersToPad < 0) throw new ArgumentException("New width must be greater than string length.", "newWidth");
            int padLeft = charactersToPad / 2 + charactersToPad % 2;
            //add a space to the left if the string is an odd number
            int padRight = charactersToPad / 2;

            return new String(fillerCharacter, padLeft) + text + new String(fillerCharacter, padRight);
        }

        /// <summary>
        /// Populates the specified two-dimensional with a default value.
        /// </summary>
        public static void Populate<T>(this T[,] array, int rows, int columns, T defaultValue = default(T))
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    array[i, j] = defaultValue;
                }
            }
        }
    }

    /// <summary>
    /// This interface should be implemented alongside the IGraph interface.
    /// </summary>
    public interface IWeightedGraph<T> where T : IComparable<T>
    {
        /// <summary>
        /// Connects two vertices together with a weight, in the direction: first->second.
        /// </summary>
        bool AddEdge(T source, T destination, long weight);

        /// <summary>
        /// Updates the edge weight from source to destination.
        /// </summary>
        bool UpdateEdgeWeight(T source, T destination, long weight);

        /// <summary>
        /// Get edge object from source to destination.
        /// </summary>
        WeightedEdge<T> GetEdge(T source, T destination);

        /// <summary>
        /// Returns the edge weight from source to destination.
        /// </summary>
        long GetEdgeWeight(T source, T destination);

        /// <summary>
        /// Returns the neighbours of a vertex as a dictionary of nodes-to-weights.
        /// </summary>
        System.Collections.Generic.Dictionary<T, long> NeighboursMap(T vertex);
    }

    /// <summary>
    /// The graph weighted edge class.
    /// </summary>
    public class WeightedEdge<TVertex> : IEdge<TVertex> where TVertex : IComparable<TVertex>
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public TVertex Source { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public TVertex Destination { get; set; }

        /// <summary>
        /// Gets or sets the weight of edge.
        /// </summary>
        /// <value>The weight.</value>
        public Int64 Weight { get; set; }

        /// <summary>
        /// Gets a value indicating whether this edge is weighted.
        /// </summary>
        public bool IsWeighted
        {
            get
            { return false; }
        }

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public WeightedEdge(TVertex src, TVertex dst, Int64 weight)
        {
            this.Source = src;
            this.Destination = dst;
            this.Weight = weight;
        }


        #region IComparable implementation
        public int CompareTo(IEdge<TVertex> other)
        {
            if (other == null)
                return -1;

            bool areNodesEqual = this.Source.IsEqualTo<TVertex>(other.Source) && this.Destination.IsEqualTo<TVertex>(other.Destination);

            if (!areNodesEqual)
                return -1;
            else
                return this.Weight.CompareTo(other.Weight);
        }
        #endregion
    }
}
