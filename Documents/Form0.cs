using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using FormLbr;

internal partial class Form0 : FormBase
{
	[Browsable(false)]
	public FormBase FormBase_0
	{
		get
		{
			return this.formBase_0;
		}
		set
		{
			this.formBase_0 = value;
		}
	}

	[Browsable(false)]
	internal int Id
	{
		get
		{
			return this.int_0;
		}
		set
		{
			this.int_0 = value;
		}
	}

	[Browsable(false)]
	internal int Int32_0
	{
		get
		{
			return this.int_1;
		}
		set
		{
			this.int_1 = value;
		}
	}

	[Browsable(true)]
	[Description("Статус полного доступа к элементам формы. false - update; true - insert")]
	internal bool Boolean_0
	{
		get
		{
			return this.bool_1;
		}
		set
		{
			this.bool_1 = value;
		}
	}

	internal Form0()
	{
		
		this.int_0 = -1;
		this.int_1 = 276;
		this.bool_1 = true;
		
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form0));
		base.Icon = (Icon)componentResourceManager.GetObject("Document");
	}

	[Browsable(false)]
	public SqlTransaction sqlTransaction_0;

	private FormBase formBase_0;

	private int int_0;

	private int int_1;

	[Browsable(false)]
	internal bool bool_0;

	internal bool bool_1;
}
