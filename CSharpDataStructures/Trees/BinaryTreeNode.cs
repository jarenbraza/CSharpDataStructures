namespace CSharpDataStructures
{
	using System;

	public sealed class BinaryTreeNode<T> where T : IComparable
	{
		public T Value { get; set; }
		public BinaryTreeNode<T> Left { get; set; }
		public BinaryTreeNode<T> Right { get; set; }

		public BinaryTreeNode(T value)
		{
			Value = value;
		}
	}
}
