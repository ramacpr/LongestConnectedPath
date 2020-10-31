using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestConnectedPath
{
    public class Node
    {
        public int Data;
        public bool IsVisited;
        public int Row;
        public int Column;
        public Node(int value, int row, int column)
        {
            Data = value;
            IsVisited = false;
            Row = row;
            Column = column; 
        }
    }
    class Program
    {
        static Node[,] data = new Node[5, 5] {
                { new Node(1, 0, 0), new Node(1, 0, 1), new Node(0, 0, 2), new Node(0, 0, 3), new Node(0, 0, 4) },
                { new Node(0, 1, 0), new Node(1, 1, 1), new Node(1, 1, 2), new Node(0, 1, 3), new Node(0, 1, 4) },
                { new Node(0, 2, 0), new Node(0, 2, 1), new Node(1, 2, 2), new Node(0, 2, 3), new Node(1, 2, 4) },
                { new Node(1, 3, 0), new Node(0, 3, 1), new Node(0, 3, 2), new Node(0, 3, 3), new Node(1, 3, 4) },
                { new Node(0, 4, 0), new Node(1, 4, 1), new Node(0, 4, 2), new Node(1, 4, 3), new Node(1, 4, 4) }
            };

        static void Main(string[] args)
        {     
            int tmp = 0, globalMaxima = 0; 
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (data[i, j].IsVisited)
                        continue;

                    if (data[i, j].Data == 0)
                    {
                        data[i, j].IsVisited = true;
                        continue;
                    }

                    tmp = Handle1sCell(data[i, j]);
                    if (tmp > globalMaxima)
                        globalMaxima = tmp;
                }
            }

            Console.WriteLine("Global Maxima = " + globalMaxima.ToString());
            Console.ReadLine();
        }

        static int Handle1sCell(Node cell)
        {
            int localMaxima = 1;

            cell.IsVisited = true; 

            List<Node> neighbours = GetNeighbours(cell); 
            foreach(var neighbour in neighbours)
            {
                if(!neighbour.IsVisited && neighbour.Data == 1)
                {
                    localMaxima += Handle1sCell(neighbour);
                }
            }
            return localMaxima; 
        }

        static List<Node> GetNeighbours(Node cell)
        {
            List<Node> neighbourNodes = new List<Node>();

            ///   top-left      top       top-right
            ///     left      <cell>        right
            /// bottom-left    down      bottom-right
            int tempRowIndex, tempColumnIndex;

            // top left
            tempRowIndex = cell.Row - 1; tempColumnIndex = cell.Column - 1;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);
            // top
            tempRowIndex = cell.Row - 1; tempColumnIndex = cell.Column;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);
            // top right
            tempRowIndex = cell.Row - 1; tempColumnIndex = cell.Column + 1;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);
            // left
            tempRowIndex = cell.Row; tempColumnIndex = cell.Column - 1;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);
            // right
            tempRowIndex = cell.Row; tempColumnIndex = cell.Column + 1;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);
            // bottom left
            tempRowIndex = cell.Row + 1; tempColumnIndex = cell.Column - 1;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);
            // bottom
            tempRowIndex = cell.Row + 1; tempColumnIndex = cell.Column;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);
            // bottom right
            tempRowIndex = cell.Row + 1; tempColumnIndex = cell.Column + 1;
            if (IsNeighbourIndexValid(tempRowIndex, tempColumnIndex))
                neighbourNodes.Add(data[tempRowIndex, tempColumnIndex]);

            return neighbourNodes;
        }

        static bool IsNeighbourIndexValid(int row, int column)
        {
            if (row < 0 || row >= 5)
                return false; 
            else if(column < 0 || column >= 5)
                return false;
            return true;
        }
    }
}
