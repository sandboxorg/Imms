using System;
using System.Collections.Generic;

namespace Solid.Convertion
{
	public static class Converters
	{
		/// <summary>
		/// Creates a Sequence from a collection of items.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <returns></returns>
		public static Sequence<T> ToSequence<T>(this IEnumerable<T> items)
		{
			return Sequence<T>.Empty.AddRangeLast(items);
		}

		/// <summary>
		/// Creates a vector from a collection of items.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <returns></returns>
		public static Vector<T> ToVector<T> (this IEnumerable<T> items)
		{
			return Vector<T>.Empty.AddRange(items);
		}
		/// <summary>
		/// Creates a HashMap from a collection of KeyValuePair objects. The keys must all be unique.
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="items">The collection of items.</param>
		/// <param name="comparer">
		/// The equality comparer used by the instance to determine equality. 
		/// If this parameter is not specified, the default equality comparer is used instead, which makes use of instance methods.</param>
		/// <returns></returns>
		public static HashMap<TKey,TValue> ToHashMap<TKey,TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> items, IEqualityComparer<TKey> comparer = null)
		{
			var hm = comparer == null ? HashMap<TKey, TValue>.Empty : HashMap<TKey, TValue>.WithComparer(comparer);
			var dict = new Dictionary<TKey, TValue>();
			foreach (var item in items)
			{
				hm = hm.Add(item.Key, item.Value);
			}
			return hm;
		}
		/// <summary>
		/// Converts a Sequence into a mutable Queue object from the standard collection library.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="seq"></param>
		/// <returns></returns>
		public static Queue<T> ToQueue<T>(this Sequence<T> seq)
		{
			var q = new Queue<T>(seq.Count);
			seq.ForEach(q.Enqueue);
			return q;
		}

		

		/// <summary>
		/// Converts the HashMap to a Dictionary object from the standard collection library.
		/// The dictionary is created using the HashMap's equality comparer if none is specified..
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="map"></param>
		/// <param name="comparer"> </param>
		/// <returns></returns>
		public static Dictionary<TKey,TValue> ToDictionary<TKey,TValue>(this HashMap<TKey,TValue> map, IEqualityComparer<TKey> comparer)
			where TKey : IEquatable<TKey>
		{
			var dict = new Dictionary<TKey, TValue>(comparer ?? map.Comparer);
			map.ForEach(dict.Add);
			return dict;
		}
		/// <summary>
		/// Converts the Sequence to an array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="seq"></param>
		/// <returns></returns>
		public static T[] ToArray<T>(this Sequence<T> seq)
		{
			var list = new T[seq.Count];
			int index = 0;
			seq.ForEach(v =>
			            {
				            list[index] = v;
				            index++;
			            });
			return list;
		}
		/// <summary>
		/// Converts the Vector to an array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="vect"></param>
		/// <returns></returns>
		public static T[] ToArray<T>(this Vector<T> vect)
		{
			var list = new T[vect.Count];
			int index = 0;
			vect.ForEach(v =>
			             {
				             list[index] = v;
				             index++;
			             });
			return list;
		}

	
	}
}
