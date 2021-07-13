namespace CSharpDataStructures
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// Represents a collection of binary tree nodes.
	/// </summary>
	/// <typeparam name="T">The type of the values in the binary tree.</typeparam>
	public class BinaryTree<T> : IEnumerable<T> where T : IComparable
	{
		/// <summary>
		/// Gets the number of elements contained in the <see cref="BinaryTree{T}"/>.
		/// </summary>
		/// <returns>
		/// The number of elements contained in the <see cref="BinaryTree{T}"/>.
		/// </returns>
		public int Count { get; protected set; } = 0;

		/// <summary>
		/// Gets a value indicating whether the <see cref="BinaryTree{T}"/> is read-only.
		/// </summary>
		/// <returns>
		/// True if the <see cref="BinaryTree{T}"/> is read-only; otherwise, false.
		/// </returns>
		public bool IsReadOnly { get; } = false;

		/// <summary>The root of the <see cref="BinaryTree{T}"/>.</summary>
		public BinaryTreeNode<T> Root { get; set; }

		public BinaryTree()
		{
			Root = null;
		}

		public BinaryTree(BinaryTreeNode<T> root)
		{
			Root = root;
			Count = PreOrderTraversal().Count;
		}

		public BinaryTree(T value)
		{
			Root = new BinaryTreeNode<T>(value);
			Count = 1;
		}

		/// <summary>
		/// Removes all items from the <see cref="BinaryTree{T}"/>.
		/// </summary>
		public void Clear()
		{
			Root = null;
			Count = 0;
		}

		/// <summary>
		/// Gets whether the <see cref="BinaryTree{T}"/> is complete.
		/// <para>
		/// This is done through level-order traversal.
		/// If at most one level is not filled, then the tree is complete.
		/// Otherwise, the tree is not complete.
		/// </para>
		/// </summary>
		/// <returns>True if the <see cref="BinaryTree{T}"/> is complete; otherwise,
		/// false.</returns>
		public bool IsComplete()
		{
			if (Root == null)
			{
				return true;
			}

			var nodesInLevel = new Queue<BinaryTreeNode<T>>();
			nodesInLevel.Enqueue(Root);

			// Flag that ensures all levels (except possibly the last) is filled.
			bool hasLevelCompletelyFilled = true;

			// Expected count of nodes in each filled level is the next power of 2.
			// For instance, 1st filled level has 1 node, 2nd has 2, 3rd has 4, and so on.
			int expectedNodeCount = 1;

			// Check that the level is filled at each iteration.
			while (nodesInLevel.Count > 0)
			{
				int nodeCount = nodesInLevel.Count;

				if (nodeCount != expectedNodeCount)
				{
					// If more than one level are not filled, the tree is not complete.
					if (!hasLevelCompletelyFilled)
					{
						return false;
					}

					hasLevelCompletelyFilled = false;
				}

				expectedNodeCount *= 2;

				// Gather the next level of nodes into the queue.
				for (int i = 0; i < nodeCount; i++)
				{
					var current = nodesInLevel.Dequeue();

					if (current.Left != null)
					{
						nodesInLevel.Enqueue(current.Left);
					}

					if (current.Right != null)
					{
						nodesInLevel.Enqueue(current.Right);
					}
				}
			}

			// All levels (except possibly the last) are filled, so the tree is complete.
			return true;
		}

		/// <summary>
		/// Gets whether the <see cref="BinaryTree{T}"/> is perfect.
		/// <para>
		/// This is done through level-order traversal.
		/// If all levels are filled, then the tree is perfect.
		/// Otherwise, the tree is not perfect.
		/// </para>
		/// </summary>
		/// <returns>True if the <see cref="BinaryTree{T}"/> is perfect; otherwise, false.</returns>
		public bool IsPerfect()
		{
			if (Root == null)
			{
				return true;
			}

			var nodesInLevel = new Queue<BinaryTreeNode<T>>();
			nodesInLevel.Enqueue(Root);

			// Expected count of nodes in each filled level is the next power of 2.
			// For instance, 1st filled level has 1 node, 2nd has 2, 3rd has 4, and so on.
			int expectedNodeCount = 1;

			// Check that the level (nodes in the queue) is filled at each iteration.
			while (nodesInLevel.Count > 0)
			{
				int nodeCount = nodesInLevel.Count;

				// If any level is not filled, then the tree is not perfect.
				if (nodeCount != expectedNodeCount)
				{
					return false;
				}

				expectedNodeCount *= 2;

				// Gather the next level of nodes into the queue.
				for (int i = 0; i < nodeCount; i++)
				{
					var current = nodesInLevel.Dequeue();

					if (current.Left != null)
					{
						nodesInLevel.Enqueue(current.Left);
					}

					if (current.Right != null)
					{
						nodesInLevel.Enqueue(current.Right);
					}
				}
			}

			// All levels are filled, so the tree is perfect.
			return true;
		}

		/// <summary>
		/// Gets an <see cref="ICollection{T}"/> that represents the pre-order traversal
		/// of the <see cref="BinaryTree{T}"/>.
		/// <para>
		/// Pre-order traversal visits the root, then the left subtree, then the right subtree.
		/// </para>
		/// </summary>
		/// <returns>A <see cref="ICollection{T}"/> that represents the pre-order traversal
		/// of the <see cref="BinaryTree{T}"/>.</returns>
		public ICollection<T> PreOrderTraversal()
		{
			ICollection<T> traversal = new List<T>();
			PreOrderTraversalHelper(Root, traversal);
			return traversal;
		}

		/// <summary>
		/// Recursively performs a pre-order traversal of the tree at <paramref name="root"/>.
		/// <para>
		/// The values of the nodes are stored in <paramref name="traversal"/> ordered by
		/// when the corresponding nodes were visited.
		/// </para>
		/// </summary>
		/// <param name="root">The root of the current subtree.</param>
		/// <param name="traversal">The collection of node values ordered by when the
		/// corresponding nodes were visited.</param>
		private void PreOrderTraversalHelper(BinaryTreeNode<T> root, ICollection<T> traversal)
		{
			if (root != null)
			{
				traversal.Add(root.Value);
				PreOrderTraversalHelper(root.Left, traversal);
				PreOrderTraversalHelper(root.Right, traversal);
			}
		}

		/// <summary>
		/// Gets an <see cref="ICollection{T}"/> that represents the in-order traversal
		/// of the <see cref="BinaryTree{T}"/>.
		/// <para>
		/// In-order traversal visits the left subtree, then the root, then the right subtree.
		/// </para>
		/// </summary>
		/// <returns>A <see cref="ICollection{T}"/> that represents the in-order traversal
		/// of the <see cref="BinaryTree{T}"/>.</returns>
		public ICollection<T> InOrderTraversal()
		{
			ICollection<T> traversal = new List<T>();
			InOrderTraversalHelper(Root, traversal);
			return traversal;
		}

		/// <summary>
		/// Recursively performs a in-order traversal of the tree at <paramref name="root"/>.
		/// <para>
		/// The values of the nodes are stored in <paramref name="traversal"/> ordered by
		/// when the corresponding nodes were visited.
		/// </para>
		/// </summary>
		/// <param name="root">The root of the current subtree.</param>
		/// <param name="traversal">The collection of node values ordered by when the
		/// corresponding nodes were visited.</param>
		private void InOrderTraversalHelper(BinaryTreeNode<T> root, ICollection<T> traversal)
		{
			if (root != null)
			{
				InOrderTraversalHelper(root.Left, traversal);
				traversal.Add(root.Value);
				InOrderTraversalHelper(root.Right, traversal);
			}
		}

		/// <summary>
		/// Gets an <see cref="ICollection{T}"/> that represents the post-order traversal
		/// of the <see cref="BinaryTree{T}"/>.
		/// <para>
		/// Post-order traversal visits the left subtree, then the root, then the right subtree.
		/// </para>
		/// </summary>
		/// <returns>A <see cref="ICollection{T}"/> that represents the post-order traversal
		/// of the <see cref="BinaryTree{T}"/>.</returns>
		public ICollection<T> PostOrderTraversal()
		{
			ICollection<T> traversal = new List<T>();
			PostOrderTraversalHelper(Root, traversal);
			return traversal;
		}

		/// <summary>
		/// Recursively performs a post-order traversal of the tree at <paramref name="root"/>.
		/// <para>
		/// The values of the nodes are stored in <paramref name="traversal"/> ordered by
		/// when the corresponding nodes were visited.
		/// </para>
		/// </summary>
		/// <param name="root">The root of the current subtree.</param>
		/// <param name="traversal">The collection of node values ordered by when the
		/// corresponding nodes were visited.</param>
		private void PostOrderTraversalHelper(BinaryTreeNode<T> root, ICollection<T> traversal)
		{
			if (root != null)
			{
				PostOrderTraversalHelper(root.Left, traversal);
				PostOrderTraversalHelper(root.Right, traversal);
				traversal.Add(root.Value);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new BinaryTreeEnumerator<T>(Root);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new BinaryTreeEnumerator<T>(Root);
		}
	}

	public class BinaryTreeEnumerator<T> : IEnumerator<T> where T : IComparable
	{
		/// <summary>The root of the tree.</summary>
		private readonly BinaryTreeNode<T> root;

		/// <summary>Utility stack to allow for iterative in-order traversal.</summary>
		private readonly Stack<BinaryTreeNode<T>> previousNodes;

		/// <summary>The current node of the in-order traversal.</summary>
		private BinaryTreeNode<T> currentNodeInTraversal;

		public T Current { get { return currentNodeInTraversal.Value; } }

		object IEnumerator.Current { get { return Current; } }

		public BinaryTreeEnumerator(BinaryTreeNode<T> root)
		{
			this.root = root;
			previousNodes = new Stack<BinaryTreeNode<T>>();
			currentNodeInTraversal = new BinaryTreeNode<T>(default);
			currentNodeInTraversal.Right = root;
		}

		public void Dispose()
		{
			Dispose();
		}

		public bool MoveNext()
		{
			GetNextNodeInOrder();
			return currentNodeInTraversal != null;
		}

		public void Reset()
		{
			currentNodeInTraversal = root;
		}

		/// <summary>
		/// Traverses to the next node in respect to an in-order traversal of the tree.
		/// </summary>
		private void GetNextNodeInOrder()
		{
			if (currentNodeInTraversal == null && previousNodes.Count == 0)
			{
				return;
			}

			// Visit the right subtree - done preemptively, due to how the enumerator was initially positioned.
			// It is at the start because enumerators are initially positioned before the first
			// element until the first MoveNext() call.
			currentNodeInTraversal = currentNodeInTraversal.Right;

			// Visit the left subtree, saving all nodes traversed for later processing.
			while (currentNodeInTraversal != null)
			{
				previousNodes.Push(currentNodeInTraversal);
				currentNodeInTraversal = currentNodeInTraversal.Left;
			}

			// Process the next node in traversal.
			if (previousNodes.Count > 0)
			{
				currentNodeInTraversal = previousNodes.Pop();
			}
		}
	}
}