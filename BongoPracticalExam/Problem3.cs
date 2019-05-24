using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoPracticalExam
{
    class Problem3
    {
        BinaryTree BTree;
        public void Start()
        {
            PopulateData();
            PrintTree();

            Console.WriteLine("Enter 1st Value:");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 2nd Value:");
            int y = Convert.ToInt32(Console.ReadLine());

            Node Result = BTree.LCA(BTree.RootNode, x, y);

            Console.WriteLine("LCA of {0} & {1} is {2}.", x, y, Result.Data);

        }

        private void PrintTree()
        {
            string[,] TreeArray = new string[4, 9];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //TreeArray[i,j] = "*";
                    TreeArray[i, j] = " ";
                }
            }

            TreeArray[0, 5] = "1";
            TreeArray[1, 3] = "2";
            TreeArray[1, 7] = "3";
            TreeArray[2, 1] = "4";
            TreeArray[2, 4] = "5";
            TreeArray[2, 6] = "6";
            TreeArray[2, 8] = "7";
            TreeArray[3, 0] = "8";
            TreeArray[3, 2] = "9";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Console.Write("*\t");
                    //Console.Write("[{0},{1}]\t", i, j);                    
                    Console.Write("{0}\t", TreeArray[i, j]);
                }
                Console.Write("\n\n");
            }
        }

        private void PopulateData()
        {
            BTree = new BinaryTree();

            BTree.RootNode = new Node(1);

            BTree.RootNode.LeftNode = new Node(2);
            BTree.RootNode.RightNode = new Node(3);

            BTree.RootNode.LeftNode.LeftNode = new Node(4);
            BTree.RootNode.LeftNode.RightNode = new Node(5);

            BTree.RootNode.LeftNode.LeftNode.LeftNode = new Node(8);
            BTree.RootNode.LeftNode.LeftNode.RightNode = new Node(9);

            BTree.RootNode.RightNode.LeftNode = new Node(6);
            BTree.RootNode.RightNode.RightNode = new Node(7);

            //BTree.RootNode = new Node(20);
            //BTree.RootNode.LeftNode = new Node(8);
            //BTree.RootNode.RightNode = new Node(22);
            //BTree.RootNode.LeftNode.LeftNode = new Node(4);
            //BTree.RootNode.LeftNode.RightNode = new Node(12);
            //BTree.RootNode.LeftNode.RightNode.LeftNode = new Node(10);
            //BTree.RootNode.LeftNode.RightNode.RightNode = new Node(14);
        }
    }

    public class BinaryTree
    {
        public Node RootNode { get; set; }

        public Node LCA(Node CurrentNode, int x, int y)
        {
            if (CurrentNode == null) { return null; }

            if (CurrentNode.Data == x || CurrentNode.Data == y) { return RootNode; }

            Node SearchLeftNode = LCA(CurrentNode.LeftNode, x, y);
            Node SearchRighttNode = LCA(CurrentNode.RightNode, x, y);

            if (SearchLeftNode == null) { return SearchRighttNode; }

            if (SearchRighttNode == null) { return SearchLeftNode; }

            

            return CurrentNode;
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public Node(int Value)
        {
            Data = Value;
            LeftNode = RightNode = null;
        }
    }
}
