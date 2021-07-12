namespace CSharpDataStructures
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class BinarySearchTree<T> : BinaryTree<T>, ICollection<T>, IEnumerable<T> where T : IComparable
	{
		public BinarySearchTree() : base()
		{
		}

		public BinarySearchTree(BinaryTreeNode<T> root) : base(root)
		{
		}

		public BinarySearchTree(T item) : base(item)
		{
		}

		/// <summary>
		/// Adds a <see cref="BinaryTreeNode{T}"/> with the <paramref name="value"/> to the <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		/// <param name="value">The object to add to the <see cref="BinarySearchTree{T}"/>.</param>
		public void Add(T item)
		{
			Root = AddHelper(item, Root);
			Count++;
		}

		public bool Remove(T item)
		{
			Root = RemoveHelper(item, Root, out var hasRemoved);
			Count--;
			return hasRemoved;
		}

		/// <summary>
		/// Determines whether the <see cref="BinarySearchTree{T}"/> contains the specified value.
		/// </summary>
		/// <param name="item">The object to locate in the <see cref="BinarySearchTree{T}"/>.</param>
		/// <returns>true if item is found in the <see cref="BinarySearchTree{T}"/>; otherwise, false</returns>
		public bool Contains(T item)
		{
			return ContainsHelper(item, Root);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Adds a <see cref="BinaryTreeNode{T}"/> with <paramref name="value"/> to the <see cref="BinarySearchTree{T}"/>.
		/// Creates a new <see cref="BinaryTreeNode{T}"/> with <paramref name="value"/> if the <paramref name="root"/> is null.
		/// </summary>
		/// <param name="value">The object to add to the <see cref="BinarySearchTree{T}"/>.</param>
		/// <param name="root">The root of the current subtree.</param>
		/// <returns>The current <see cref="BinaryTreeNode{T}"/> at the current subtree.</returns>
		private BinaryTreeNode<T> AddHelper(T value, BinaryTreeNode<T> root)
		{
			if (root == null)
			{
				return new BinaryTreeNode<T>(value);
			}

			if (value.CompareTo(root.Value) < 0)
			{
				root.Left = AddHelper(value, root.Left);
			}
			else
			{
				root.Right = AddHelper(value, root.Right);
			}

			return root;
		}

		private BinaryTreeNode<T> RemoveHelper(T value, BinaryTreeNode<T> root, out bool hasRemovedValue)
		{
			if (root == null)
			{
				hasRemovedValue = false;
				return null;
			}

			if (value.CompareTo(root.Value) < 0)
			{
				root.Left = RemoveHelper(value, root.Left, out hasRemovedValue);
			}
			else if (value.CompareTo(root.Value) > 0)
			{
				root.Right = RemoveHelper(value, root.Right, out hasRemovedValue);
			}
			else
			{
				hasRemovedValue = true;

				// No children:
				// Return null, as the root is effectively deleted.
				if (root.Left == null && root.Right == null)
				{
					return null;
				}

				// One child:
				// Return the non-null child.
				if (root.Left == null)
				{
					return root.Right;
				}

				if (root.Right == null)
				{
					return root.Left;
				}

				// Two children:
				// Replace the value of the root with the value of the minimum node in the sub-tree.
				// Remove the minimum node in the sub-tree.
				BinaryTreeNode<T> minNode = GetMinimum(root);
				root.Value = minNode.Value;
				root.Right = RemoveHelper(root.Value, root.Right, out hasRemovedValue);
			}

			return root;
		}

		private BinaryTreeNode<T> GetMinimum(BinaryTreeNode<T> root)
		{
			while (root.Left != null)
			{
				root = root.Left;
			}

			return root;
		}

		/// <summary>
		/// Determines whether the <see cref="BinarySearchTree{T}"/> contains the specified value in the current subtree.
		/// The search domain is tightened based on comparison between the specified value and the value of the root of the current subtree.
		/// </summary>
		/// <param name="item">The object to locate in the <see cref="BinarySearchTree{T}"/>.</param>
		/// <returns>true if item is found in the current subtree; otherwise, false</returns>
		private bool ContainsHelper(T value, BinaryTreeNode<T> root)
		{
			if (root == null)
			{
				return false;
			}

			if (value.CompareTo(root.Value) < 0)
			{
				return ContainsHelper(value, root.Left);
			}

			if (value.CompareTo(root.Value) > 0)
			{
				return ContainsHelper(value, root.Right);
			}

			return true;
		}
	}
}