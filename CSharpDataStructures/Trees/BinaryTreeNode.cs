using System;

namespace CSharpDataStructures
{
	public sealed class BinaryTreeNode<T> where T : IComparable
	{
		public T Value { get; set; }
		public BinaryTreeNode<T> Left { get; set; }
		public BinaryTreeNode<T> Right { get; set; }
		public BinaryTree<T> Tree { get; }

		public BinaryTreeNode(T value)
		{
			Value = value;
		}
	}
}
