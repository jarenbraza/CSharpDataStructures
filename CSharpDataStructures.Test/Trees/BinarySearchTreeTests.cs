namespace CSharpDataStructures.Test
{
	using CSharpDataStructures.Test.Constants;
	using NUnit.Framework;

	[TestFixture]
	public class BinarySearchTreeTests
	{
		[Test]
		public void Add_EmptyTree_HasNonNullRootAndCountOne()
		{
			// Arrange
			var tree = new BinarySearchTree<int>();

			// Act
			tree.Add(TestConstants.Item);

			// Assert
			Assert.NotNull(tree.Root);
			Assert.Null(tree.Root.Left);
			Assert.Null(tree.Root.Right);

			Assert.AreEqual(tree.Root.Value, TestConstants.Item);

			Assert.AreEqual(tree.Count, 1);
		}

		[Test]
		public void Add_TreeWithOneNodeAndNodeWithSmallerItem_HasNonNullRootAndCountTwo()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TestConstants.Item);

			// Act
			tree.Add(TestConstants.SmallerItem);

			// Assert
			Assert.NotNull(tree.Root);
			Assert.NotNull(tree.Root.Left);
			Assert.Null(tree.Root.Right);

			Assert.AreEqual(tree.Root.Value, TestConstants.Item);
			Assert.AreEqual(tree.Root.Left.Value, TestConstants.SmallerItem);

			Assert.AreEqual(tree.Count, 2);
		}

		[Test]
		public void Add_TreeWithOneNodeAndNodeWithLargerItem_HasNonNullRootAndCountTwo()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TestConstants.Item);

			// Act
			tree.Add(TestConstants.LargerItem);

			// Assert
			Assert.NotNull(tree.Root);
			Assert.Null(tree.Root.Left);
			Assert.NotNull(tree.Root.Right);

			Assert.AreEqual(tree.Root.Value, TestConstants.Item);
			Assert.AreEqual(tree.Root.Right.Value, TestConstants.LargerItem);

			Assert.AreEqual(tree.Count, 2);
		}
		
		[Test]
		public void Contains_EmptyTreeAndItemNotInTree_ReturnFalse()
		{
			// Arrange
			var tree = new BinarySearchTree<int>();

			// Act
			bool contains = tree.Contains(TestConstants.Item);

			// Assert
			Assert.IsFalse(contains);
		}

		[Test]
		public void Contains_TreeWithOneNodeAndSmallerItemNotInTree_ReturnFalse()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TestConstants.Item);

			// Act
			bool contains = tree.Contains(TestConstants.SmallerItem);

			// Assert
			Assert.IsFalse(contains);
		}

		[Test]
		public void Contains_TreeWithOneNodeAndLargerItemNotInTree_ReturnFalse()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TestConstants.Item);

			// Act
			bool contains = tree.Contains(TestConstants.LargerItem);

			// Assert
			Assert.IsFalse(contains);
		}

		[Test]
		public void Contains_CompleteTreeAndItemInTree_ReturnTrue()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TreeTestUtilities.GetRootOfCompleteBinaryTree());

			// Act
			bool contains = tree.Contains(TestConstants.ItemInTreeOfGetRootOfCompleteBinaryTree);

			// Assert
			Assert.IsTrue(contains);
		}
	}
}
