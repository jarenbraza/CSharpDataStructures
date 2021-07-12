﻿namespace CSharpDataStructures.Test.Trees
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
			var tree = TreeTestUtilities.GetCompleteBinaryTreeWithMultipleLevels();

			// Act
			bool isComplete = tree.IsComplete();

			// Assert
			Assert.IsTrue(isComplete);
		}
		#endregion

		#region IsFull tests
		[Test]
		public void IsFull_EmptyTree_ReturnTrue()
		{
			// Arrange
			var tree = new BinaryTree<int>();

			// Act
			bool isFull = tree.IsFull();

			// Assert
			Assert.IsTrue(isFull);
		}

		[Test]
		public void IsFull_TreeWithOneLevel_ReturnTrue()
		{
			// Arrange
			var tree = new BinaryTree<int>(1);

			// Act
			bool isFull = tree.IsFull();

			// Assert
			Assert.IsTrue(isFull);
		}

		[Test]
		public void IsFull_CompleteTreeWithMultipleLevels_ReturnFalse()
		{
			// Arrange
			var tree = TreeTestUtilities.GetCompleteBinaryTreeWithMultipleLevels();

			// Act
			bool isFull = tree.IsFull();

			// Assert
			Assert.IsFalse(isFull);
		}

		[Test]
		public void IsFull_FullTreeWithMultipleLevels_ReturnTrue()
		{
			// Arrange
			var tree = TreeTestUtilities.GetFullBinaryTreeWithMultipleLevels();

			// Act
			bool isFull = tree.IsFull();

			// Assert
			Assert.IsTrue(isFull);
		}

		[Test]
		public void IsFull_TreeWithOneUnfilledLevel_ReturnFalse()
		{
			// Arrange
			var root = new BinaryTreeNode<int>(3);
			var left = new BinaryTreeNode<int>(1);
			root.Left = left;

			var tree = new BinarySearchTree<int>(root);

			// Act
			bool isFull = tree.IsFull();

			// Assert
			Assert.IsFalse(isFull);
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
			var tree = TreeTestUtilities.GetCompleteBinaryTreeWithMultipleLevels();

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
		public void PreOrderTraversal_FullTreeWithMultipleLevels_ReturnEqualCollection()
		{
			// Arrange
			var tree = TreeTestUtilities.GetFullBinaryTreeWithMultipleLevels();
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
		public void InOrderTraversal_FullTreeWithMultipleLevels_ReturnEqualCollection()
		{
			// Arrange
			var tree = TreeTestUtilities.GetFullBinaryTreeWithMultipleLevels();
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
		public void PostOrderTraversal_FullTreeWithMultipleLevels_ReturnEqualCollection()
		{
			// Arrange
			var tree = TreeTestUtilities.GetFullBinaryTreeWithMultipleLevels();
			var expectedTraversal = new List<int>() { 1, 3, 2, 5, 7, 6, 4 };

			// Act
			var traversal = tree.PostOrderTraversal();

			// Assert
			Assert.IsTrue(traversal.SequenceEqual(expectedTraversal));
		}
		#endregion
	}
}