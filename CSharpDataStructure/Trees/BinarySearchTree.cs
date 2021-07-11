using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpDataStructures.Trees
{
	class BinarySearchTree<TValue> : ICollection<TValue>, IEnumerable<TValue>
	{
		/// <summary>
		/// Gets the number of elements contained in the <see cref="BinarySearchTree{TValue}"/>.
		/// </summary>
		/// <returns>
		/// The number of elements contained in the <see cref="BinarySearchTree{TValue}"/>.
		/// </returns>
		public int Count { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the <see cref="BinarySearchTree{TValue}"/> is read-only.
		/// </summary>
		/// <returns>
		/// true if the <see cref="BinarySearchTree{TValue}"/> is read-only; otherwise, false
		/// </returns>
		public bool IsReadOnly { get; } = false;

		/// <summary>
		/// Adds an item to the <see cref="BinarySearchTree{TValue}"/>.
		/// </summary>
		/// <param name="value">The object to add to the <see cref="BinarySearchTree{TValue}"/>.</param>
		public void Add(TValue value)
		{

		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(TValue item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(TValue[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public bool Remove(TValue item)
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}