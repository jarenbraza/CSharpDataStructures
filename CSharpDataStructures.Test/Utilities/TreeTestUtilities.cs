namespace CSharpDataStructures.Test
{
	public static class TreeTestUtilities
	{
		/// <summary>
		/// Creates a complete tree with three levels shown below.
		/// 
		///      4
		///    /   \ 
		///   2     6
		///  / \     \
		/// 1   3     7
		/// </summary>
		/// <returns>A complete binary tree with three levels.</returns>
		public static BinaryTree<int> GetCompleteBinaryTreeWithMultipleLevels()
		{
			var root = new BinaryTreeNode<int>(4);

			// Construct subtree to the left of the root and add connections
			var leftSubtreeRoot = new BinaryTreeNode<int>(2);
			var leftSubtreeLeft = new BinaryTreeNode<int>(1);
			var leftSubtreeRight = new BinaryTreeNode<int>(3);

			leftSubtreeRoot.Left = leftSubtreeLeft;
			leftSubtreeRoot.Right = leftSubtreeRight;

			// Construct subtree to the right of the root and add connections
			var rightSubtreeRoot = new BinaryTreeNode<int>(6);
			var rightSubtreeRight = new BinaryTreeNode<int>(7);

			rightSubtreeRoot.Right = rightSubtreeRight;

			// Connect root to subtrees
			root.Left = leftSubtreeRoot;
			root.Right = rightSubtreeRoot;

			return new BinaryTree<int>(root);
		}

		/// <summary>
		/// Creates a full tree with three levels shown below.
		/// 
		///      4
		///    /   \ 
		///   2     6
		///  / \   / \
		/// 1   3 5   7
		/// </summary>
		/// <returns>A full binary tree with three levels.</returns>
		public static BinaryTree<int> GetFullBinaryTreeWithMultipleLevels()
		{
			var root = new BinaryTreeNode<int>(4);

			// Construct subtree to the left of the root and add connections
			var leftSubtreeRoot = new BinaryTreeNode<int>(2);
			var leftSubtreeLeft = new BinaryTreeNode<int>(1);
			var leftSubtreeRight = new BinaryTreeNode<int>(3);

			leftSubtreeRoot.Left = leftSubtreeLeft;
			leftSubtreeRoot.Right = leftSubtreeRight;

			// Construct subtree to the right of the root and add connections
			var rightSubtreeRoot = new BinaryTreeNode<int>(6);
			var rightSubtreeLeft = new BinaryTreeNode<int>(5);
			var rightSubtreeRight = new BinaryTreeNode<int>(7);

			rightSubtreeRoot.Left = rightSubtreeLeft;
			rightSubtreeRoot.Right = rightSubtreeRight;

			// Connect root to subtrees
			root.Left = leftSubtreeRoot;
			root.Right = rightSubtreeRoot;

			return new BinaryTree<int>(root);
		}
	}
}
