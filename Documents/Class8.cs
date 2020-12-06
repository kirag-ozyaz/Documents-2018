using System;
using System.Runtime.CompilerServices;

internal class Class8
{
	public int Id { get; set; }

	public string Name { get; set; }

	[CompilerGenerated]
	public string method_0()
	{
		return this.string_1;
	}

	[CompilerGenerated]
	public void method_1(string string_2)
	{
		this.string_1 = string_2;
	}

	[CompilerGenerated]
	public int method_2()
	{
		return this.int_1;
	}

	[CompilerGenerated]
	public void method_3(int int_3)
	{
		this.int_1 = int_3;
	}

	public int IdParent { get; set; }

	public Class8(int int_3, int int_4, int int_5, string string_2, string string_3)
	{
		
		
		this.Id = int_3;
		this.IdParent = int_4;
		this.method_3(int_5);
		this.Name = string_2;
		this.method_1(string_3);
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
	private int int_1;

	[CompilerGenerated]
	private int int_2;
}
