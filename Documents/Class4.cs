using System;
using System.IO;
using System.Text;

internal class Class4
{
	internal Class4(string string_0)
	{
		
		
		this.stringReader_0 = new StringReader(string_0);
		this.int_0 = 0;
		this.char_0 = ' ';
		this.int_1 = this.stringReader_0.Read();
		this.char_1 = (char)this.int_1;
		this.char_2 = ' ';
		this.bool_0 = true;
		this.stringBuilder_0 = new StringBuilder(100);
		this.enum0_0 = (Enum0)7;
		this.method_6();
	}

	internal void method_0()
	{
		this.stringBuilder_0.Length = 0;
		if (this.method_17())
		{
			this.enum0_0 = (Enum0)9;
			return;
		}
		if (this.method_18())
		{
			this.method_6();
			if (this.method_16() == '/')
			{
				this.stringBuilder_0.Append("</");
				this.enum0_0 = (Enum0)1;
				this.method_6();
				this.bool_0 = false;
				return;
			}
			this.enum0_0 = (Enum0)0;
			this.stringBuilder_0.Append("<");
			this.bool_0 = true;
			return;
		}
		else
		{
			if (!this.method_20())
			{
				this.enum0_0 = (Enum0)7;
				while (!this.method_18() && !this.method_17() && !this.method_20())
				{
					if (this.method_16() == '<' && !this.method_21() && this.char_1 == '?')
					{
						this.method_15();
					}
					else
					{
						if (this.method_16() <= ' ')
						{
							if (!this.bool_0)
							{
								this.stringBuilder_0.Append(' ');
							}
							this.bool_0 = true;
						}
						else
						{
							this.stringBuilder_0.Append(this.method_16());
							this.bool_0 = false;
						}
						this.method_6();
					}
				}
				return;
			}
			this.method_6();
			if (this.char_1 == '[')
			{
				this.method_12();
				return;
			}
			if (this.char_1 == '-')
			{
				this.method_13();
				return;
			}
			this.method_14();
			return;
		}
	}

	internal void method_1()
	{
		this.stringBuilder_0.Length = 0;
		if (this.method_17())
		{
			this.enum0_0 = (Enum0)9;
			return;
		}
		this.method_7();
		if (this.method_16() == '>' && !this.method_21())
		{
			this.enum0_0 = (Enum0)2;
			this.stringBuilder_0.Append('>');
			this.method_6();
			return;
		}
		if (this.method_16() == '/' && this.char_1 == '>')
		{
			this.enum0_0 = (Enum0)3;
			this.stringBuilder_0.Append("/>");
			this.method_6();
			this.method_6();
			this.bool_0 = false;
			return;
		}
		if (this.method_8(this.method_16()))
		{
			this.enum0_0 = (Enum0)5;
			while (this.method_9(this.method_16()))
			{
				if (this.method_17())
				{
					return;
				}
				this.stringBuilder_0.Append(this.method_16());
				this.method_6();
			}
		}
		else
		{
			this.enum0_0 = (Enum0)6;
			this.stringBuilder_0.Append(this.method_16());
			this.method_6();
		}
	}

	internal void method_2()
	{
		this.stringBuilder_0.Length = 0;
		this.stringBuilder_0.Append('=');
		this.enum0_0 = (Enum0)4;
		this.method_7();
		if (this.method_16() == '=')
		{
			this.method_6();
		}
	}

	internal void method_3()
	{
		this.stringBuilder_0.Length = 0;
		this.method_7();
		this.enum0_0 = (Enum0)6;
		if ((this.method_16() == '\'' || this.method_16() == '"') && !this.method_21())
		{
			char c = this.method_16();
			this.method_6();
			for (;;)
			{
				if (this.method_16() == c)
				{
					if (!this.method_21())
					{
						break;
					}
				}
				if (this.method_17())
				{
					break;
				}
				this.stringBuilder_0.Append(this.method_16());
				this.method_6();
			}
			if (this.method_16() == c)
			{
				this.method_6();
				return;
			}
		}
		else
		{
			while (!this.method_17() && !char.IsWhiteSpace(this.method_16()))
			{
				if (this.method_16() == '>')
				{
					break;
				}
				this.stringBuilder_0.Append(this.method_16());
				this.method_6();
			}
		}
	}

	internal Enum0 method_4()
	{
		return this.enum0_0;
	}

	internal string method_5()
	{
		return this.stringBuilder_0.ToString();
	}

	private void method_6()
	{
		if (this.int_0 == -1)
		{
			throw new InvalidOperationException("GetNextCharacter method called at the end of a stream");
		}
		this.char_2 = this.char_0;
		this.char_0 = this.char_1;
		this.int_0 = this.int_1;
		this.bool_1 = false;
		this.IujoExvcun();
		if (this.char_0 == '&')
		{
			if (this.char_1 == '#')
			{
				int num = 0;
				this.IujoExvcun();
				int num2 = 0;
				while (num2 < 7 && char.IsDigit(this.char_1))
				{
					num = 10 * num + (this.int_1 - 48);
					this.IujoExvcun();
					num2++;
				}
				if (this.char_1 == ';')
				{
					this.IujoExvcun();
					this.int_0 = num;
					this.char_0 = (char)this.int_0;
					this.bool_1 = true;
					return;
				}
				this.char_0 = this.char_1;
				this.int_0 = this.int_1;
				this.IujoExvcun();
				this.bool_1 = false;
				return;
			}
			else if (char.IsLetter(this.char_1))
			{
				string text = "";
				int num3 = 0;
				while (num3 < 10 && (char.IsLetter(this.char_1) || char.IsDigit(this.char_1)))
				{
					text += this.char_1.ToString();
					this.IujoExvcun();
					num3++;
				}
				if (this.char_1 == ';')
				{
					this.IujoExvcun();
					if (Class6.smethod_6(text))
					{
						this.char_0 = Class6.smethod_7(text);
						this.int_0 = (int)this.char_0;
						this.bool_1 = true;
						return;
					}
					this.char_0 = this.char_1;
					this.int_0 = this.int_1;
					this.IujoExvcun();
					this.bool_1 = false;
					return;
				}
				else
				{
					this.char_0 = this.char_1;
					this.IujoExvcun();
					this.bool_1 = false;
				}
			}
		}
	}

	private void IujoExvcun()
	{
		if (this.int_1 != -1)
		{
			this.int_1 = this.stringReader_0.Read();
			this.char_1 = (char)this.int_1;
		}
	}

	private void method_7()
	{
		for (;;)
		{
			if (this.char_0 == '<' && (this.char_1 == '?' || this.char_1 == '!'))
			{
				this.method_6();
				if (this.char_1 == '[')
				{
					while (!this.method_17())
					{
						if (this.char_2 == ']' && this.char_0 == ']' && this.char_1 == '>')
						{
							break;
						}
						this.method_6();
					}
					if (this.char_0 == '>')
					{
						this.method_6();
					}
				}
				else
				{
					while (!this.method_17())
					{
						if (this.char_0 == '>')
						{
							break;
						}
						this.method_6();
					}
					if (this.char_0 == '>')
					{
						this.method_6();
					}
				}
			}
			if (!char.IsWhiteSpace(this.method_16()))
			{
				break;
			}
			this.method_6();
		}
	}

	private bool method_8(char char_3)
	{
		return char_3 == '_' || char.IsLetter(char_3);
	}

	private bool method_9(char char_3)
	{
		return this.method_8(char_3) || char_3 == '.' || char_3 == '-' || char_3 == ':' || char.IsDigit(char_3) || this.method_10(char_3) || this.method_11(char_3);
	}

	private bool method_10(char char_3)
	{
		return false;
	}

	private bool method_11(char char_3)
	{
		return false;
	}

	private void method_12()
	{
		this.enum0_0 = (Enum0)7;
		this.stringBuilder_0.Length = 0;
		this.method_6();
		this.method_6();
		for (;;)
		{
			if (this.char_0 == ']')
			{
				if (this.char_1 == '>')
				{
					break;
				}
			}
			if (this.method_17())
			{
				break;
			}
			this.method_6();
		}
		if (!this.method_17())
		{
			this.method_6();
			this.method_6();
		}
	}

	private void method_13()
	{
		this.enum0_0 = (Enum0)8;
		this.stringBuilder_0.Length = 0;
		this.method_6();
		this.method_6();
		this.method_6();
		for (;;)
		{
			if (!this.method_17() && (this.char_0 != '-' || this.char_1 != '-'))
			{
				if (this.char_0 != '!' || this.char_1 != '>')
				{
					this.stringBuilder_0.Append(this.method_16());
					this.method_6();
					continue;
				}
			}
			this.method_6();
			if (this.char_2 == '-' && this.char_0 == '-' && this.char_1 == '>')
			{
				break;
			}
			if (this.char_2 == '!' && this.char_0 == '>')
			{
				goto IL_CD;
			}
			this.stringBuilder_0.Append(this.char_2);
		}
		this.method_6();
		IL_CD:
		if (this.char_0 == '>')
		{
			this.method_6();
		}
	}

	private void method_14()
	{
		this.enum0_0 = (Enum0)7;
		this.stringBuilder_0.Length = 0;
		this.method_6();
		for (;;)
		{
			if (this.char_0 == '>')
			{
				if (!this.method_21())
				{
					break;
				}
			}
			if (this.method_17())
			{
				break;
			}
			this.method_6();
		}
		if (!this.method_17())
		{
			this.method_6();
		}
	}

	private void method_15()
	{
		this.method_6();
		this.method_6();
		for (;;)
		{
			if (this.char_0 == '?')
			{
				goto IL_0E;
			}
			if (this.char_0 == '/')
			{
				goto IL_0E;
			}
			IL_18:
			if (!this.method_17())
			{
				this.method_6();
				continue;
			}
			break;
			IL_0E:
			if (this.char_1 != '>')
			{
				goto IL_18;
			}
			break;
		}
		if (!this.method_17())
		{
			this.method_6();
			this.method_6();
		}
	}

	private char method_16()
	{
		return this.char_0;
	}

	private bool method_17()
	{
		return this.int_0 == -1;
	}

	private bool method_18()
	{
		return this.char_0 == '<' && (this.char_1 == '/' || this.method_8(this.char_1)) && !this.bool_1;
	}

	private bool method_19()
	{
		if (this.char_0 != '>')
		{
			if (this.char_0 != '/' || this.char_1 != '>')
			{
				return false;
			}
		}
		return !this.bool_1;
	}

	private bool method_20()
	{
		return this.char_0 == '<' && this.char_1 == '!' && !this.method_21();
	}

	private bool method_21()
	{
		return this.bool_1;
	}

	private StringReader stringReader_0;

	private int int_0;

	private char char_0;

	private int int_1;

	private char char_1;

	private char char_2;

	private bool bool_0;

	private bool bool_1;

	private StringBuilder stringBuilder_0;

	private Enum0 enum0_0;
}
