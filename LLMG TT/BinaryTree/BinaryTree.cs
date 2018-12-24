using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMG_TT
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; set; }

        //recursively insert new node into the bst instance with T data 
        public void Insert(T value, User user, BinaryTreeNode<T> node)
        {
            var nodeToInsert = new BinaryTreeNode<T> { Value = value, User = user };

            if (nodeToInsert > node)
            {
                if (node.Right == null)
                {
                    node.Right = nodeToInsert;
                }
                else
                {
                    Insert(value, user, node.Right);
                    Console.WriteLine("right");
                }
            }

            if (nodeToInsert < node)
            {
                if (node.Left == null)
                {
                    node.Left = nodeToInsert;
                }
                else
                {
                    Insert(value, user, node.Left);
                    Console.WriteLine("left");
                }
            }
        }

        /// <summary>
        /// Inseration method
        /// </summary>
        /// <param name="value">Key (Guid)</param>
        /// <param name="user">User object</param>
        public void Insert(T value, User user)
        {
            var nodeToInsert = new BinaryTreeNode<T> { Value = value, User = user };

            if (Root == null)
            {
                Root = nodeToInsert;
            }

            var current = Root;

            while (current != null)
            {
                if (nodeToInsert > current)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                        continue;
                    }
                    current.Right = nodeToInsert;
                    continue;
                }

                if (nodeToInsert < current)
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                        continue;
                    }
                    current.Left = nodeToInsert;
                    continue;
                }

                return;
            }
        }
        /// <summary>
        /// Remove node from tree
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="guid">Value to remove</param>
        /// <returns></returns>
        public BinaryTreeNode<Guid> Delete(BinaryTreeNode<Guid> root, Guid guid)
        {
            if (root == null)
            {
                return null;
            }
            root.Left = Delete(root.Left, guid);
            root.Right = Delete(root.Right, guid);

            if (root.Value == guid && root.Left == null && root.Right == null)
            {
                return null;
            }

            return root;
        }
        /// <summary>
        /// Print all tree
        /// </summary>
        public void Print()
        {
            if(this.Root == null)
            {
                Console.WriteLine("Empty tree");
                return;
            }
            Print(this.Root);
        }

        /// <summary>
        /// Print tree starts from cur node
        /// </summary>
        /// <param name="node"></param>
        private void Print(BinaryTreeNode<T> node)
        {
            if (node == null) return;
            Console.WriteLine($"Guid: {node.Value}\tName: {node.User.Name}\tAge: {node.User.Age}");
            if (node.Left != null)
            {
                Console.Write("Left: ");
                Print(node.Left);
            }

            if (node.Right != null)
            {
                Console.Write("Right: ");
                Print(node.Right);
            }
        }
        
        public void EditNode(ref BinaryTreeNode<T> node, T guid, User user)
        {
            node.Value = guid;
            node.User = user;
        }

    }
}
