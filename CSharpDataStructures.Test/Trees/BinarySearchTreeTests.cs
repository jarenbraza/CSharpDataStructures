namespace CSharpDataStructures.Test
{
	using CSharpDataStructures.Test.Constants;
	using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class BinarySearchTreeTests
	{
        #region Add tests
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
        #endregion

        #region Contains
        [Test]
		public void Contains_EmptyTreeAndItemNotInTree_ReturnFalse()
		{
			// Arrange
			var tree = new BinarySearchTree<int>();

			// Act
			bool containsItem = tree.Contains(TestConstants.Item);

			// Assert
			Assert.IsFalse(containsItem);
		}

		[Test]
		public void Contains_TreeWithOneNodeAndSmallerItemNotInTree_ReturnFalse()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TestConstants.Item);

			// Act
			bool containsItem = tree.Contains(TestConstants.SmallerItem);

			// Assert
			Assert.IsFalse(containsItem);
		}

		[Test]
		public void Contains_TreeWithOneNodeAndLargerItemNotInTree_ReturnFalse()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TestConstants.Item);

			// Act
			bool containsItem = tree.Contains(TestConstants.LargerItem);

			// Assert
			Assert.IsFalse(containsItem);
		}

		[Test]
		public void Contains_CompleteTreeAndItemInTree_ReturnTrue()
		{
			// Arrange
			var tree = new BinarySearchTree<int>(TreeTestUtilities.GetRootOfCompleteBinaryTree());

			// Act
			bool containsItem = tree.Contains(TestConstants.ItemInTreeOfGetRootOfCompleteBinaryTree);

			// Assert
			Assert.IsTrue(containsItem);
		}
        #endregion

        #region Remove
        public void Remove_EmptyTreeAndItemNotInTree_ReturnFalse()
        {
            // Arrange
            var tree = new BinarySearchTree<int>();

            // Act
            bool hasRemovedItem = tree.Remove(TestConstants.Item);

            // Assert
            Assert.IsFalse(hasRemovedItem);
        }

        [Test]
        public void Remove_TreeWithOneNodeAndRemoveItemNotInTree_ReturnFalse()
        {
            // Arrange
            var tree = new BinarySearchTree<int>(TestConstants.Item);

            // Act
            bool hasRemovedItem = tree.Contains(TestConstants.SmallerItem);

            // Assert
            Assert.IsFalse(hasRemovedItem);
        }

        [Test]
        public void Remove_PerfectTreeAndItemIsLeaf_ReturnTrue()
        {
            // Arrange
            var tree = new BinarySearchTree<int>(TreeTestUtilities.GetRootOfPerfectBinaryTree());
            var expectedTraversal = new List<int>{ 1, 2, 4, 5, 6, 7 };

            // Act
            bool hasRemovedItem = tree.Remove(3);
            var actualTraversal = tree.InOrderTraversal();

            // Assert
            Assert.IsTrue(hasRemovedItem);
            Assert.IsTrue(expectedTraversal.SequenceEqual(actualTraversal));
        }

        [Test]
        public void Remove_PerfectTreeAndItemInMiddleOfTree_ReturnTrue()
        {
            // Arrange
            var tree = new BinarySearchTree<int>(TreeTestUtilities.GetRootOfPerfectBinaryTree());
            var expectedTraversal = new List<int> { 1, 3, 4, 5, 6, 7 };

            // Act
            bool hasRemovedItem = tree.Remove(2);
            var actualTraversal = tree.InOrderTraversal();

            // Assert
            Assert.IsTrue(hasRemovedItem);
            Assert.IsTrue(expectedTraversal.SequenceEqual(actualTraversal));
        }
        #endregion
    }
}
