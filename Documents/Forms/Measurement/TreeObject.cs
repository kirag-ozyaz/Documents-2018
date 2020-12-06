using System;
using System.Runtime.CompilerServices;

namespace Documents.Forms.Measurement
{
	public struct TreeObject
	{
		public TypeNode TypeNode { get; set; }

		public int idBus { get; set; }

		public int idSub { get; set; }

		public int idTransf { get; set; }

		public string NameTransf { get; set; }

		[CompilerGenerated]
		private TypeNode typeNode_0;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		[CompilerGenerated]
		private string string_0;
	}
}
