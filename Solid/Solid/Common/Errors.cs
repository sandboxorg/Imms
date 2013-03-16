﻿using System;
using System.Collections.Generic;

namespace Solid.Common
{
	internal static class Errors
	{
		private const string str__is_empty = "The operation is invalid because the data structure is empty.";
		private const string str__index_out_of_range = "The index is out of range of this data structure";

		private const string str__too_many_hash_collisions =
			"An abnormally large number of hash collisions has occurred. This may be a sign that equality members must be reimplemented.";

		private const string str__key_exists = "The specified key already exists.";
		private const string str__key_not_found = "The specified key does not exist in this data structure.";
		private const string str__argument_null = "The argument cannot be null.",
			str__invalid_digit_size = "This operation cannot be performed on a digit with this size.",
			str__invalid_leaf_invocation = "This operation cannot be performed on a leaf.",
			str__invalid_exeuction_path = "A switch statement took an invalid execution path.";

		public static InvalidOperationException Is_empty
		{
			get
			{
				return new InvalidOperationException(str__is_empty);
			}
		}

		public static IndexOutOfRangeException Index_out_of_range
		{
			get
			{
				return new IndexOutOfRangeException(str__index_out_of_range);
			}
		}

		public static InvalidOperationException Too_many_hash_collisions
		{
			get
			{
				return new InvalidOperationException(
					str__too_many_hash_collisions);
			}
		}

		public static ArgumentException Key_exists
		{
			get
			{
				return new ArgumentException(str__key_exists);
			}
		}

		public static KeyNotFoundException Key_not_found
		{
			get
			{
				return new KeyNotFoundException(str__key_not_found);
			}
		}

		public static ArgumentNullException Argument_null(string name)
		{
			return new ArgumentNullException(name, str__argument_null);
		}


			

		public static InvalidOperationException Invalid_digit_size
		{
			get
			{
				return new InvalidOperationException(str__invalid_digit_size);
			}
		}

		public static InvalidOperationException Invalid_leaf_invocation
		{
			get
			{
				return new InvalidOperationException(str__invalid_leaf_invocation);
			}
		}

		public static InvalidOperationException Invalid_execution_path
		{
			get
			{
				return new InvalidOperationException(str__invalid_exeuction_path);
			}
		}
	}
}