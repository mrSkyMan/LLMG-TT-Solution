using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMG_TT
{
    public static class BinaryTreeSearch
    {
        public static BinaryTreeNode<T> FindNode<T>(T value, BinaryTreeNode<T> source) where T : IComparable
        {
            if (source == null) return null;

            var nodeToFind = new BinaryTreeNode<T> { Value = value };

            if (nodeToFind == source)
            {
                return source;
            }

            if (nodeToFind > source)    
            {
                return FindNode<T>(value, source.Right);
            }

            if (nodeToFind < source)
            {
                return FindNode<T>(value, source.Left);
            }

            return null;
        }
    }

}
