using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpDataStructures.Test
{
	public static class BinaryTreeTestUtilities
	{
		public static IEnumerable<TestCaseData> CompleteTreeTestSuite
		{
			get
			{
				yield return new TestCaseData(GetBinarySearchTreeIsCompleteWithMultipleLevels());
				yield return new TestCaseData(GetBinarySearchTreeWithOneLevel());
				yield return new TestCaseData(GetBinarySearchTreeIsEmpty());
			}
		}

		public static IEnumerable<TestCaseData> FullTreeTestSuite
		{
			get
			{
				yield return new TestCaseData(GetBinarySearchTreeIsFullWithMultipleLevels());
				yield return new TestCaseData(GetBinarySearchTreeWithOneLevel());
				yield return new TestCaseData(GetBinarySearchTreeIsEmpty());
			}
		}

		/// <summary>
		/// Creates a complete tree with three levels shown below.
		/// 
		///      4
		///    /   \ 
		///   2     6
		///  / \     \
		/// 1   3     7
		/// </summary>
		/// <returns>A complete binary search tree with three levels.</returns>
		public static BinarySearchTree<int> GetBinarySearchTreeIsCompleteWithMultipleLevels()
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

			return new BinarySearchTree<int>(root);
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
		/// <returns>A full binary search tree with three levels.</returns>
		public static BinarySearchTree<int> GetBinarySearchTreeIsFullWithMultipleLevels()
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

			return new BinarySearchTree<int>(root);
		}

		/// <summary>
		/// Creates a tree with one level (and therefore, one node).
		/// </summary>
		/// <returns>A binary search tree with one level.</returns>
		public static BinarySearchTree<int> GetBinarySearchTreeWithOneLevel()
		{
			var root = new BinaryTreeNode<int>(420);  // 😎🤜 🤛😎
			return new BinarySearchTree<int>(root);
		}

		/// <summary>
		/// Creates an empty tree.
		/// </summary>
		/// <returns>An empty binary search tree.</returns>
		public static BinarySearchTree<int> GetBinarySearchTreeIsEmpty()
		{
			return new BinarySearchTree<int>();
		}
	}
}
