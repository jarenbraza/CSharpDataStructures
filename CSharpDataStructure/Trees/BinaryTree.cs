namespace CSharpDataStructures
{
	/// <summary>
	/// Represents a collection of binary tree nodes.
	/// </summary>
	/// <typeparam name="TValue">The type of the values in the binary tree.</typeparam>
	class BinaryTree<TValue>
	{
		public int Count { get; private set; } = 0;
		public bool IsReadOnly { get; } = false;
		public BinaryTreeNode<TValue> Root { get; private set; }

		public BinaryTree(BinaryTreeNode<TValue> root)
		{
			Root = root;
		}

		public BinaryTree(TValue value)
		{
			Root = new BinaryTreeNode<TValue>(value);
		}
	}

	class BinaryTreeNode<TValue>
	{
		public TValue Value { get; set; }
		public BinaryTreeNode<TValue> Left { get; set; }
		public BinaryTreeNode<TValue> Right { get; set; }
		public BinaryTree<TValue> Tree { get; }

		public BinaryTreeNode(TValue value)
		{
			Value = value;
		}
	}
}