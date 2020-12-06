using System;
using System.Runtime.CompilerServices;

internal class Class9
{
	public int Id { get; set; }

	public string Name { get; set; }

	[CompilerGenerated]
	public string method_0()
	{
		return this.string_1;
	}

	[CompilerGenerated]
	public void method_1(string string_3)
	{
		this.string_1 = string_3;
	}

	public string Comment { get; set; }

	public Class9(int int_1, string string_3, string string_4, string string_5)
	{
		
		
		this.Id = int_1;
		this.Name = string_3;
		this.method_1(string_4);
		this.Comment = string_5;
	}

	public override string ToString()
	{
		return this.Name;
	}

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;
}
