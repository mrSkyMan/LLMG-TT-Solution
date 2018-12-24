using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMG_TT
{     
    public class BinaryTreeNode<T> where T : IComparable 
    {
        public BinaryTreeNode<T> Right { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public T Value { get; set; }
        public User User { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is BinaryTreeNode<T> other)
            {
                if (ReferenceEquals(Value, other.Value)) return true;
                return Value.Equals(other.Value);
            }
            return false;
        }

        public override int GetHashCode() => Value == null ? 0 : Value.GetHashCode();

        public static bool operator ==(BinaryTreeNode<T> left, BinaryTreeNode<T> right) => ReferenceEquals(left, right) || (left?.Equals(right) ?? false);
        public static bool operator !=(BinaryTreeNode<T> left, BinaryTreeNode<T> right) => !(left == right);

        public static bool operator <(BinaryTreeNode<T> left, BinaryTreeNode<T> right) => left.Value.CompareTo(right.Value) < 0;
        public static bool operator >(BinaryTreeNode<T> left, BinaryTreeNode<T> right) => left.Value.CompareTo(right.Value) > 0;
        
    }
}
