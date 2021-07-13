namespace CSharpDataStructures.Test
{
	public static class TreeTestUtilities
	{
		/// <summary>
		/// Gets the root of a complete tree with three levels shown below.
		/// 
		///      4
		///    /   \ 
		///   2     6
		///  / \     \
		/// 1   3     7
		/// </summary>
		/// <returns>The root of a complete binary tree with three levels.</returns>
		public static BinaryTreeNode<int> GetRootOfCompleteBinaryTree()
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

			return root;
		}

		/// <summary>
		/// Gets the root of a perfect tree with three levels shown below.
		/// 
		///      4
		///    /   \ 
		///   2     6
		///  / \   / \
		/// 1   3 5   7
		/// </summary>
		/// <returns>The root of a perfect binary tree with three levels.</returns>
		public static BinaryTreeNode<int> GetRootOfPerfectBinaryTree()
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

			return root;
		}
	}
}
