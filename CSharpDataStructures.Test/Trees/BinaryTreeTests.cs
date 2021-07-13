namespace CSharpDataStructures.Test.Trees
{
	using NUnit.Framework;
	using System.Collections.Generic;
	using System.Linq;

	class BinaryTreeTests
	{
		#region IsComplete tests
		[Test]
		public void IsComplete_EmptyTree_ReturnTrue()
		{
			// Arrange
			var tree = new BinarySearchTree<int>();

			// Act
			bool isComplete = tree.IsComplete();

			// Assert
			Assert.IsTrue(isComplete);
		}

		[Test]
		public void IsComplete_TreeWithOneUnfilledLevel_ReturnTrue()
		{
			// Arrange
			var root = new BinaryTreeNode<int>(420);  // 😎🤜 🤛😎
			var left = new BinaryTreeNode<int>(1);
			root.Left = left;

			var tree = new BinarySearchTree<int>(root);

			// Act
			bool isComplete = tree.IsComplete();

			// Assert
			Assert.IsTrue(isComplete);
		}

		[Test]
		public void IsComplete_TwoUnfilledLevels_ReturnFalse()
		{
			// Arrange
			var root = new BinaryTreeNode<int>(3);

			var leftSubtreeRoot = new BinaryTreeNode<int>(1);
			var leftSubtreeLeft = new BinaryTreeNode<int>(0);
			leftSubtreeRoot.Left = leftSubtreeLeft;
			root.Left = leftSubtreeRoot;

			var tree = new BinarySearchTree<int>(root);

			// Act
			bool isComplete = tree.IsComplete();

			// Assert
			Assert.IsFalse(isComplete);
		}

		[Test]
		public void IsComplete_CompleteTreeWithMultipleLevels_ReturnTrue()
		{
			// Arrange
			var root = TreeTestUtilities.GetRootOfCompleteBinaryTree();
			var tree = new BinaryTree<int>(root);

			// Act
			bool isComplete = tree.IsComplete();

			// Assert
			Assert.IsTrue(isComplete);
		}
		#endregion

		#region IsPerfect tests
		[Test]
		public void IsPerfect_EmptyTree_ReturnTrue()
		{
			// Arrange
			var tree = new BinaryTree<int>();

			// Act
			bool isPerfect = tree.IsPerfect();

			// Assert
			Assert.IsTrue(isPerfect);
		}

		[Test]
		public void IsPerfect_TreeWithOneLevel_ReturnTrue()
		{
			// Arrange
			var tree = new BinaryTree<int>(1);

			// Act
			bool isPerfect = tree.IsPerfect();

			// Assert
			Assert.IsTrue(isPerfect);
		}

		[Test]
		public void IsPerfect_CompleteTreeWithMultipleLevels_ReturnFalse()
		{
			// Arrange
			var root = TreeTestUtilities.GetRootOfCompleteBinaryTree();
			var tree = new BinaryTree<int>(root);

			// Act
			bool isPerfect = tree.IsPerfect();

			// Assert
			Assert.IsFalse(isPerfect);
		}

		[Test]
		public void IsPerfect_PerfectTreeWithMultipleLevels_ReturnTrue()
		{
			// Arrange
			var root = TreeTestUtilities.GetRootOfPerfectBinaryTree();
			var tree = new BinaryTree<int>(root);

			// Act
			bool isPerfect = tree.IsPerfect();

			// Assert
			Assert.IsTrue(isPerfect);
		}

		[Test]
		public void IsPerfect_TreeWithOneUnfilledLevel_ReturnFalse()
		{
			// Arrange
			var root = new BinaryTreeNode<int>(3);
			var left = new BinaryTreeNode<int>(1);
			root.Left = left;

			var tree = new BinarySearchTree<int>(root);

			// Act
			bool isPerfect = tree.IsPerfect();

			// Assert
			Assert.IsFalse(isPerfect);
		}
		#endregion

		#region IsClear tests
		[Test]
		public void Clear_EmptyTree_RootIsNullAndCountIsZero()
		{
			// Arrange
			var tree = new BinaryTree<int>();

			// Act
			tree.Clear();

			// Assert
			Assert.IsNull(tree.Root);
			Assert.Zero(tree.Count);
		}

		[Test]
		public void Clear_TreeWithOneLevel_RootIsNullAndCountIsZero()
		{
			// Arrange
			var tree = new BinaryTree<int>(1);

			// Act
			tree.Clear();

			// Assert
			Assert.IsNull(tree.Root);
			Assert.Zero(tree.Count);
		}

		[Test]
		public void Clear_CompleteTreeWithMultipleLevels_RootIsNullAndCountIsZero()
		{
			// Arrange
			var root = TreeTestUtilities.GetRootOfCompleteBinaryTree();
			var tree = new BinaryTree<int>(root);

			// Act
			tree.Clear();

			// Assert
			Assert.IsNull(tree.Root);
			Assert.Zero(tree.Count);
		}
		#endregion

		#region PreOrderTraversal tests
		[Test]
		public void PreOrderTraversal_EmptyTree_ReturnEmptyCollection()
		{
			// Arrange
			var tree = new BinaryTree<int>();

			// Act
			var traversal = tree.PreOrderTraversal();

			// Assert
			Assert.Zero(traversal.Count);
		}

		[Test]
		public void PreOrderTraversal_PerfectTreeWithMultipleLevels_ReturnEqualCollection()
		{
			// Arrange
			var root = TreeTestUtilities.GetRootOfPerfectBinaryTree();
			var tree = new BinaryTree<int>(root);
			var expectedTraversal = new List<int>() { 4, 2, 1, 3, 6, 5, 7 };

			// Act
			var traversal = tree.PreOrderTraversal();

			// Assert
			Assert.IsTrue(traversal.SequenceEqual(expectedTraversal));
		}
		#endregion

		#region InOrderTraversal tests
		[Test]
		public void InOrderTraversal_EmptyTree_ReturnEmptyCollection()
		{
			// Arrange
			var tree = new BinaryTree<int>();

			// Act
			var traversal = tree.InOrderTraversal();

			// Assert
			Assert.Zero(traversal.Count);
		}

		[Test]
		public void InOrderTraversal_PerfectTreeWithMultipleLevels_ReturnEqualCollection()
		{
			// Arrange
			var root = TreeTestUtilities.GetRootOfPerfectBinaryTree();
			var tree = new BinaryTree<int>(root);
			var expectedTraversal = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

			// Act
			var traversal = tree.InOrderTraversal();

			// Assert
			Assert.IsTrue(traversal.SequenceEqual(expectedTraversal));
		}
		#endregion

		#region PostOrderTraversal tests
		[Test]
		public void PostOrderTraversal_EmptyTree_ReturnEmptyCollection()
		{
			// Arrange
			var tree = new BinaryTree<int>();

			// Act
			var traversal = tree.PostOrderTraversal();

			// Assert
			Assert.Zero(traversal.Count);
		}

		[Test]
		public void PostOrderTraversal_PerfectTreeWithMultipleLevels_ReturnEqualCollection()
		{
			// Arrange
			var root = TreeTestUtilities.GetRootOfPerfectBinaryTree();
			var tree = new BinaryTree<int>(root);
			var expectedTraversal = new List<int>() { 1, 3, 2, 5, 7, 6, 4 };

			// Act
			var traversal = tree.PostOrderTraversal();

			// Assert
			Assert.IsTrue(traversal.SequenceEqual(expectedTraversal));
		}
		#endregion
	}
}
