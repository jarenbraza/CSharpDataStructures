using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpDataStructures.Test
{
	public class BinarySearchTreeTests
	{
		[Test]
		[TestCaseSource(typeof(BinaryTreeTestUtilities), nameof(BinaryTreeTestUtilities.FullTreeTestSuite))]
		public void IsFull(BinarySearchTree<int> tree)
		{
			Assert.IsTrue(tree.IsFull());
		}

		[Test]
		[TestCaseSource(typeof(BinaryTreeTestUtilities), nameof(BinaryTreeTestUtilities.CompleteTreeTestSuite))]
		public void IsComplete(BinarySearchTree<int> tree)
		{
			Assert.IsTrue(tree.IsComplete());
		}
	}
}