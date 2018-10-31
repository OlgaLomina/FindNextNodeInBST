using System;
/* Write an algorithm to find the next node (i.e in-order successor) of a given node in a binary search tree. 
 * You may assume that each node has a link to its parent
 * */
namespace Tree1
{
    public class Node
    {
        public int data;
        public Node left, right, parent;

        public Node()
        {
            data = 0;
            left = right = parent = null;
        }
        public Node(int val)
        {
            data = val;
            left = right = parent = null;
        }
    }

    public class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }

        public Node FindNextNode(Node node)
        {
            Node cur = node.right;
            if (cur != null)
            {
                //minNode left side
                while (cur.left != null)
                {
                    cur = cur.left;
                }
                return cur;
            }
            else
            {
                //go up to parent and check that is right child and parent != null
                Node p = node.parent;
                while (p != null && node == p.right)
                {
                    node = p;
                    p = p.parent;
                }
                return p;
            }
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            Node nodeNext, cur, left, right;
            Node node = new Node(50);
            node.left = new Node(25);
            left = node.left;
            node.right = new Node(70);
            right = node.right;
            left.parent = right.parent = node;

            left.left = new Node(10);
            left.right = new Node(40);
            left.left.parent = left.right.parent = left;

            right.left = new Node(60);
            cur = right.right = new Node(80);
            right.left.parent = right.right.parent = right;

            Tree bst = new Tree();
            
            nodeNext = bst.FindNextNode(cur);
            if (nodeNext != null)
                Console.WriteLine(cur.data + " -> " + nodeNext.data);
            else
                Console.WriteLine("null");
        }
    }
}
