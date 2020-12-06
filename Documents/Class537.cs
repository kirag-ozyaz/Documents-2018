using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[ToolboxItem(true)]
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("dsFind")]
[Serializable]
internal class Class537 : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class537()
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		
		base.BeginInit();
		this.method_2();
		CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_8);
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		base.EndInit();
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected Class537(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		base..ctor(serializationInfo_0, streamingContext_0, false);
		if (base.IsBinarySerialized(serializationInfo_0, streamingContext_0))
		{
			this.method_1(false);
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_8);
			this.DataTableCollection_0.CollectionChanged += value;
			this.DataRelationCollection_0.CollectionChanged += value;
			return;
		}
		string s = (string)serializationInfo_0.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(serializationInfo_0, streamingContext_0) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["vG_Find"] != null)
			{
				base.Tables.Add(new Class537.Class538(dataSet.Tables["vG_Find"]));
			}
			if (dataSet.Tables["vG_AbnObjCntShort"] != null)
			{
				base.Tables.Add(new Class537.Class539(dataSet.Tables["vG_AbnObjCntShort"]));
			}
			if (dataSet.Tables["tAbn"] != null)
			{
				base.Tables.Add(new Class537.Class540(dataSet.Tables["tAbn"]));
			}
			if (dataSet.Tables["vG_AbnObjCnt"] != null)
			{
				base.Tables.Add(new Class537.Class541(dataSet.Tables["vG_AbnObjCnt"]));
			}
			if (dataSet.Tables["vG_AbnObjCnt1"] != null)
			{
				base.Tables.Add(new Class537.Class542(dataSet.Tables["vG_AbnObjCnt1"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			base.Merge(dataSet, false, MissingSchemaAction.Add);
			this.method_0();
		}
		else
		{
			base.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
		}
		base.GetSerializationData(serializationInfo_0, streamingContext_0);
		CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_8);
		base.Tables.CollectionChanged += value2;
		this.DataRelationCollection_0.CollectionChanged += value2;
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class537.Class538 vG_Find
	{
		get
		{
			return this.class538_0;
		}
	}

	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class537.Class539 vG_AbnObjCntShort
	{
		get
		{
			return this.class539_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class537.Class540 tAbn
	{
		get
		{
			return this.class540_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class537.Class541 vG_AbnObjCnt
	{
		get
		{
			return this.class541_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class537.Class542 vG_AbnObjCnt1
	{
		get
		{
			return this.class542_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override SchemaSerializationMode SchemaSerializationMode
	{
		get
		{
			return this.schemaSerializationMode_0;
		}
		set
		{
			this.schemaSerializationMode_0 = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataTableCollection DataTableCollection_0
	{
		get
		{
			return base.Tables;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataRelationCollection DataRelationCollection_0
	{
		get
		{
			return base.Relations;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override void InitializeDerivedDataSet()
	{
		base.BeginInit();
		this.method_2();
		base.EndInit();
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public override DataSet Clone()
	{
		Class537 @class = (Class537)base.Clone();
		@class.method_0();
		@class.SchemaSerializationMode = this.SchemaSerializationMode;
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected override bool ShouldSerializeTables()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected override bool ShouldSerializeRelations()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override void ReadXmlSerializable(XmlReader reader)
	{
		if (base.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
		{
			this.Reset();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(reader);
			if (dataSet.Tables["vG_Find"] != null)
			{
				base.Tables.Add(new Class537.Class538(dataSet.Tables["vG_Find"]));
			}
			if (dataSet.Tables["vG_AbnObjCntShort"] != null)
			{
				base.Tables.Add(new Class537.Class539(dataSet.Tables["vG_AbnObjCntShort"]));
			}
			if (dataSet.Tables["tAbn"] != null)
			{
				base.Tables.Add(new Class537.Class540(dataSet.Tables["tAbn"]));
			}
			if (dataSet.Tables["vG_AbnObjCnt"] != null)
			{
				base.Tables.Add(new Class537.Class541(dataSet.Tables["vG_AbnObjCnt"]));
			}
			if (dataSet.Tables["vG_AbnObjCnt1"] != null)
			{
				base.Tables.Add(new Class537.Class542(dataSet.Tables["vG_AbnObjCnt1"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			base.Merge(dataSet, false, MissingSchemaAction.Add);
			this.method_0();
			return;
		}
		base.ReadXml(reader);
		this.method_0();
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected override XmlSchema GetSchemaSerializable()
	{
		MemoryStream memoryStream = new MemoryStream();
		base.WriteXmlSchema(new XmlTextWriter(memoryStream, null));
		memoryStream.Position = 0L;
		return XmlSchema.Read(new XmlTextReader(memoryStream), null);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal void method_0()
	{
		this.method_1(true);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal void method_1(bool bool_0)
	{
		this.class538_0 = (Class537.Class538)base.Tables["vG_Find"];
		if (bool_0 && this.class538_0 != null)
		{
			this.class538_0.method_2();
		}
		this.class539_0 = (Class537.Class539)base.Tables["vG_AbnObjCntShort"];
		if (bool_0 && this.class539_0 != null)
		{
			this.class539_0.method_2();
		}
		this.class540_0 = (Class537.Class540)base.Tables["tAbn"];
		if (bool_0 && this.class540_0 != null)
		{
			this.class540_0.method_3();
		}
		this.class541_0 = (Class537.Class541)base.Tables["vG_AbnObjCnt"];
		if (bool_0 && this.class541_0 != null)
		{
			this.class541_0.method_2();
		}
		this.class542_0 = (Class537.Class542)base.Tables["vG_AbnObjCnt1"];
		if (bool_0 && this.class542_0 != null)
		{
			this.class542_0.method_2();
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_2()
	{
		base.DataSetName = "dsFind";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/dsFind.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class538_0 = new Class537.Class538();
		base.Tables.Add(this.class538_0);
		this.class539_0 = new Class537.Class539();
		base.Tables.Add(this.class539_0);
		this.class540_0 = new Class537.Class540();
		base.Tables.Add(this.class540_0);
		this.class541_0 = new Class537.Class541();
		base.Tables.Add(this.class541_0);
		this.class542_0 = new Class537.Class542();
		base.Tables.Add(this.class542_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_3()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_4()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_5()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_6()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_7()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_8(object sender, CollectionChangeEventArgs e)
	{
		if (e.Action == CollectionChangeAction.Remove)
		{
			this.method_0();
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
	{
		Class537 @class = new Class537();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = @class.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = @class.GetSchemaSerializable();
		if (xmlSchemaSet_0.Contains(schemaSerializable.TargetNamespace))
		{
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream2 = new MemoryStream();
			try
			{
				schemaSerializable.Write(memoryStream);
				foreach (object obj in xmlSchemaSet_0.Schemas(schemaSerializable.TargetNamespace))
				{
					XmlSchema xmlSchema = (XmlSchema)obj;
					memoryStream2.SetLength(0L);
					xmlSchema.Write(memoryStream2);
					if (memoryStream.Length == memoryStream2.Length)
					{
						memoryStream.Position = 0L;
						memoryStream2.Position = 0L;
						while (memoryStream.Position != memoryStream.Length)
						{
							if (memoryStream.ReadByte() != memoryStream2.ReadByte())
							{
								break;
							}
						}
						if (memoryStream.Position == memoryStream.Length)
						{
							return xmlSchemaComplexType;
						}
					}
				}
				goto IL_13A;
			}
			finally
			{
				if (memoryStream != null)
				{
					memoryStream.Close();
				}
				if (memoryStream2 != null)
				{
					memoryStream2.Close();
				}
			}
			XmlSchemaComplexType result;
			return result;
		}
		IL_13A:
		xmlSchemaSet_0.Add(schemaSerializable);
		return xmlSchemaComplexType;
	}

	private Class537.Class538 class538_0;

	private Class537.Class539 class539_0;

	private Class537.Class540 class540_0;

	private Class537.Class541 class541_0;

	private Class537.Class542 class542_0;

	private SchemaSerializationMode schemaSerializationMode_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate252(object sender, Class537.EventArgs248 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate253(object sender, Class537.EventArgs249 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate254(object sender, Class537.EventArgs250 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate255(object sender, Class537.EventArgs251 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate256(object sender, Class537.EventArgs252 e);

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class538 : TypedTableBase<Class537.Class543>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class538()
		{
			
			
			base.TableName = "vG_Find";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class538(DataTable dataTable_0)
		{
			
			
			base.TableName = dataTable_0.TableName;
			if (dataTable_0.CaseSensitive != dataTable_0.DataSet.CaseSensitive)
			{
				base.CaseSensitive = dataTable_0.CaseSensitive;
			}
			if (dataTable_0.Locale.ToString() != dataTable_0.DataSet.Locale.ToString())
			{
				base.Locale = dataTable_0.Locale;
			}
			if (dataTable_0.Namespace != dataTable_0.DataSet.Namespace)
			{
				base.Namespace = dataTable_0.Namespace;
			}
			base.Prefix = dataTable_0.Prefix;
			base.MinimumCapacity = dataTable_0.MinimumCapacity;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected Class538(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_0
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_1;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class543 this[int int_0]
		{
			get
			{
				return (Class537.Class543)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate252 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate252 @delegate = this.delegate252_0;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate252 @delegate = this.delegate252_0;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate252 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate252 @delegate = this.delegate252_1;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate252 @delegate = this.delegate252_1;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate252 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate252 @delegate = this.delegate252_2;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate252 @delegate = this.delegate252_2;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate252 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate252 @delegate = this.delegate252_3;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate252 @delegate = this.delegate252_3;
				Class537.Delegate252 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate252 value2 = (Class537.Delegate252)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate252>(ref this.delegate252_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class537.Class543 class543_0)
		{
			base.Rows.Add(class543_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class543 method_1(int int_0, string string_0, string string_1, int int_1, int int_2)
		{
			Class537.Class543 @class = (Class537.Class543)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				string_1,
				int_1,
				int_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class537.Class538 @class = (Class537.Class538)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class537.Class538();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["CodeAbonent"];
			this.dataColumn_1 = base.Columns["Name"];
			this.dataColumn_2 = base.Columns["ObjName"];
			this.dataColumn_3 = base.Columns["idAbn"];
			this.dataColumn_4 = base.Columns["idAbnObj"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("ObjName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_1.MaxLength = 100;
			this.dataColumn_2.MaxLength = 255;
			this.dataColumn_3.AllowDBNull = false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class543 method_4()
		{
			return (Class537.Class543)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class537.Class543(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class537.Class543);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate252_1 != null)
			{
				this.delegate252_1(this, new Class537.EventArgs248((Class537.Class543)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate252_0 != null)
			{
				this.delegate252_0(this, new Class537.EventArgs248((Class537.Class543)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate252_3 != null)
			{
				this.delegate252_3(this, new Class537.EventArgs248((Class537.Class543)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate252_2 != null)
			{
				this.delegate252_2(this, new Class537.EventArgs248((Class537.Class543)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class537.Class543 class543_0)
		{
			base.Rows.Remove(class543_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class537 @class = new Class537();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = "http://www.w3.org/2001/XMLSchema";
			xmlSchemaAny.MinOccurs = 0m;
			xmlSchemaAny.MaxOccurs = decimal.MaxValue;
			xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
			xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			xmlSchemaAny2.MinOccurs = 1m;
			xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny2);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute();
			xmlSchemaAttribute.Name = "namespace";
			xmlSchemaAttribute.FixedValue = @class.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "vG_FindDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = @class.GetSchemaSerializable();
			if (xmlSchemaSet_0.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					schemaSerializable.Write(memoryStream);
					foreach (object obj in xmlSchemaSet_0.Schemas(schemaSerializable.TargetNamespace))
					{
						XmlSchema xmlSchema = (XmlSchema)obj;
						memoryStream2.SetLength(0L);
						xmlSchema.Write(memoryStream2);
						if (memoryStream.Length == memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							memoryStream2.Position = 0L;
							while (memoryStream.Position != memoryStream.Length)
							{
								if (memoryStream.ReadByte() != memoryStream2.ReadByte())
								{
									break;
								}
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								return xmlSchemaComplexType;
							}
						}
					}
					goto IL_1ED;
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream2 != null)
					{
						memoryStream2.Close();
					}
				}
				XmlSchemaComplexType result;
				return result;
			}
			IL_1ED:
			xmlSchemaSet_0.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataColumn dataColumn_4;

		[CompilerGenerated]
		private Class537.Delegate252 delegate252_0;

		[CompilerGenerated]
		private Class537.Delegate252 delegate252_1;

		[CompilerGenerated]
		private Class537.Delegate252 delegate252_2;

		[CompilerGenerated]
		private Class537.Delegate252 delegate252_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class539 : TypedTableBase<Class537.Class544>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class539()
		{
			
			
			base.TableName = "vG_AbnObjCntShort";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class539(DataTable dataTable_0)
		{
			
			
			base.TableName = dataTable_0.TableName;
			if (dataTable_0.CaseSensitive != dataTable_0.DataSet.CaseSensitive)
			{
				base.CaseSensitive = dataTable_0.CaseSensitive;
			}
			if (dataTable_0.Locale.ToString() != dataTable_0.DataSet.Locale.ToString())
			{
				base.Locale = dataTable_0.Locale;
			}
			if (dataTable_0.Namespace != dataTable_0.DataSet.Namespace)
			{
				base.Namespace = dataTable_0.Namespace;
			}
			base.Prefix = dataTable_0.Prefix;
			base.MinimumCapacity = dataTable_0.MinimumCapacity;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected Class539(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_0
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.VefHzzartws;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[DebuggerNonUserCode]
		[Browsable(false)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class544 this[int int_0]
		{
			get
			{
				return (Class537.Class544)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate253 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate253 @delegate = this.delegate253_0;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate253 @delegate = this.delegate253_0;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate253 OxjHzBjraVF
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate253 @delegate = this.delegate253_1;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate253 @delegate = this.delegate253_1;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate253 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate253 @delegate = this.delegate253_2;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate253 @delegate = this.delegate253_2;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate253 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate253 @delegate = this.delegate253_3;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate253 @delegate = this.delegate253_3;
				Class537.Delegate253 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate253 value2 = (Class537.Delegate253)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate253>(ref this.delegate253_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class537.Class544 class544_0)
		{
			base.Rows.Add(class544_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class544 method_1(int int_0, string string_0, string string_1, int int_1)
		{
			Class537.Class544 @class = (Class537.Class544)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				string_1,
				int_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class537.Class539 @class = (Class537.Class539)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class537.Class539();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["CodeAbonent"];
			this.dataColumn_1 = base.Columns["Name"];
			this.VefHzzartws = base.Columns["AbnWorker"];
			this.dataColumn_2 = base.Columns["idAbn"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.VefHzzartws = new DataColumn("AbnWorker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.VefHzzartws);
			this.dataColumn_2 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_1.MaxLength = 100;
			this.VefHzzartws.MaxLength = 30;
			this.dataColumn_2.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class544 method_4()
		{
			return (Class537.Class544)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class537.Class544(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class537.Class544);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate253_1 != null)
			{
				this.delegate253_1(this, new Class537.EventArgs249((Class537.Class544)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate253_0 != null)
			{
				this.delegate253_0(this, new Class537.EventArgs249((Class537.Class544)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate253_3 != null)
			{
				this.delegate253_3(this, new Class537.EventArgs249((Class537.Class544)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate253_2 != null)
			{
				this.delegate253_2(this, new Class537.EventArgs249((Class537.Class544)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class537.Class544 class544_0)
		{
			base.Rows.Remove(class544_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class537 @class = new Class537();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = "http://www.w3.org/2001/XMLSchema";
			xmlSchemaAny.MinOccurs = 0m;
			xmlSchemaAny.MaxOccurs = decimal.MaxValue;
			xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
			xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			xmlSchemaAny2.MinOccurs = 1m;
			xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny2);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute();
			xmlSchemaAttribute.Name = "namespace";
			xmlSchemaAttribute.FixedValue = @class.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "vG_AbnObjCntShortDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = @class.GetSchemaSerializable();
			if (xmlSchemaSet_0.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					schemaSerializable.Write(memoryStream);
					foreach (object obj in xmlSchemaSet_0.Schemas(schemaSerializable.TargetNamespace))
					{
						XmlSchema xmlSchema = (XmlSchema)obj;
						memoryStream2.SetLength(0L);
						xmlSchema.Write(memoryStream2);
						if (memoryStream.Length == memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							memoryStream2.Position = 0L;
							while (memoryStream.Position != memoryStream.Length)
							{
								if (memoryStream.ReadByte() != memoryStream2.ReadByte())
								{
									break;
								}
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								return xmlSchemaComplexType;
							}
						}
					}
					goto IL_1ED;
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream2 != null)
					{
						memoryStream2.Close();
					}
				}
				XmlSchemaComplexType result;
				return result;
			}
			IL_1ED:
			xmlSchemaSet_0.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn VefHzzartws;

		private DataColumn dataColumn_2;

		[CompilerGenerated]
		private Class537.Delegate253 delegate253_0;

		[CompilerGenerated]
		private Class537.Delegate253 delegate253_1;

		[CompilerGenerated]
		private Class537.Delegate253 delegate253_2;

		[CompilerGenerated]
		private Class537.Delegate253 delegate253_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class540 : TypedTableBase<Class537.Class545>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class540()
		{
			
			
			base.TableName = "tAbn";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class540(DataTable dataTable_0)
		{
			
			
			base.TableName = dataTable_0.TableName;
			if (dataTable_0.CaseSensitive != dataTable_0.DataSet.CaseSensitive)
			{
				base.CaseSensitive = dataTable_0.CaseSensitive;
			}
			if (dataTable_0.Locale.ToString() != dataTable_0.DataSet.Locale.ToString())
			{
				base.Locale = dataTable_0.Locale;
			}
			if (dataTable_0.Namespace != dataTable_0.DataSet.Namespace)
			{
				base.Namespace = dataTable_0.Namespace;
			}
			base.Prefix = dataTable_0.Prefix;
			base.MinimumCapacity = dataTable_0.MinimumCapacity;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected Class540(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn idColumn
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_0
		{
			get
			{
				return this.dataColumn_1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn idWorkerColumn
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[Browsable(false)]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class545 this[int int_0]
		{
			get
			{
				return (Class537.Class545)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate254 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate254 @delegate = this.delegate254_0;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate254 @delegate = this.delegate254_0;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate254 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate254 @delegate = this.delegate254_1;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate254 @delegate = this.delegate254_1;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate254 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate254 @delegate = this.delegate254_2;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate254 @delegate = this.delegate254_2;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate254 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate254 @delegate = this.delegate254_3;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate254 @delegate = this.delegate254_3;
				Class537.Delegate254 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate254 value2 = (Class537.Delegate254)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate254>(ref this.delegate254_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class537.Class545 class545_0)
		{
			base.Rows.Add(class545_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class545 method_1(int int_0, string string_0, int int_1, int int_2, bool bool_0)
		{
			Class537.Class545 @class = (Class537.Class545)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				string_0,
				int_1,
				int_2,
				bool_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class545 method_2(int int_0)
		{
			return (Class537.Class545)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class537.Class540 @class = (Class537.Class540)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class537.Class540();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["CodeAbonent"];
			this.dataColumn_2 = base.Columns["Name"];
			this.dataColumn_3 = base.Columns["TypeAbn"];
			this.dataColumn_4 = base.Columns["idWorker"];
			this.dataColumn_5 = base.Columns["Deleted"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("TypeAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("idWorker", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AutoIncrement = true;
			this.dataColumn_0.AutoIncrementSeed = -1L;
			this.dataColumn_0.AutoIncrementStep = -1L;
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.ReadOnly = true;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.MaxLength = 100;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_4.AllowDBNull = false;
			this.dataColumn_5.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class545 method_5()
		{
			return (Class537.Class545)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class537.Class545(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class537.Class545);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate254_1 != null)
			{
				this.delegate254_1(this, new Class537.EventArgs250((Class537.Class545)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate254_0 != null)
			{
				this.delegate254_0(this, new Class537.EventArgs250((Class537.Class545)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate254_3 != null)
			{
				this.delegate254_3(this, new Class537.EventArgs250((Class537.Class545)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate254_2 != null)
			{
				this.delegate254_2(this, new Class537.EventArgs250((Class537.Class545)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class537.Class545 class545_0)
		{
			base.Rows.Remove(class545_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class537 @class = new Class537();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = "http://www.w3.org/2001/XMLSchema";
			xmlSchemaAny.MinOccurs = 0m;
			xmlSchemaAny.MaxOccurs = decimal.MaxValue;
			xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
			xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			xmlSchemaAny2.MinOccurs = 1m;
			xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny2);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute();
			xmlSchemaAttribute.Name = "namespace";
			xmlSchemaAttribute.FixedValue = @class.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "tAbnDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = @class.GetSchemaSerializable();
			if (xmlSchemaSet_0.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					schemaSerializable.Write(memoryStream);
					foreach (object obj in xmlSchemaSet_0.Schemas(schemaSerializable.TargetNamespace))
					{
						XmlSchema xmlSchema = (XmlSchema)obj;
						memoryStream2.SetLength(0L);
						xmlSchema.Write(memoryStream2);
						if (memoryStream.Length == memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							memoryStream2.Position = 0L;
							while (memoryStream.Position != memoryStream.Length)
							{
								if (memoryStream.ReadByte() != memoryStream2.ReadByte())
								{
									break;
								}
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								return xmlSchemaComplexType;
							}
						}
					}
					goto IL_1ED;
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream2 != null)
					{
						memoryStream2.Close();
					}
				}
				XmlSchemaComplexType result;
				return result;
			}
			IL_1ED:
			xmlSchemaSet_0.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataColumn dataColumn_4;

		private DataColumn dataColumn_5;

		[CompilerGenerated]
		private Class537.Delegate254 delegate254_0;

		[CompilerGenerated]
		private Class537.Delegate254 delegate254_1;

		[CompilerGenerated]
		private Class537.Delegate254 delegate254_2;

		[CompilerGenerated]
		private Class537.Delegate254 delegate254_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class541 : TypedTableBase<Class537.Class546>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class541()
		{
			
			
			base.TableName = "vG_AbnObjCnt";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class541(DataTable dataTable_0)
		{
			
			
			base.TableName = dataTable_0.TableName;
			if (dataTable_0.CaseSensitive != dataTable_0.DataSet.CaseSensitive)
			{
				base.CaseSensitive = dataTable_0.CaseSensitive;
			}
			if (dataTable_0.Locale.ToString() != dataTable_0.DataSet.Locale.ToString())
			{
				base.Locale = dataTable_0.Locale;
			}
			if (dataTable_0.Namespace != dataTable_0.DataSet.Namespace)
			{
				base.Namespace = dataTable_0.Namespace;
			}
			base.Prefix = dataTable_0.Prefix;
			base.MinimumCapacity = dataTable_0.MinimumCapacity;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected Class541(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_0
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_8
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_9
		{
			get
			{
				return this.dataColumn_9;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_10
		{
			get
			{
				return this.dataColumn_10;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn QchWosrhrud
		{
			get
			{
				return this.dataColumn_11;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_11
		{
			get
			{
				return this.dataColumn_12;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_12
		{
			get
			{
				return this.dataColumn_13;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_13
		{
			get
			{
				return this.dataColumn_14;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_14
		{
			get
			{
				return this.dataColumn_15;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_15
		{
			get
			{
				return this.dataColumn_16;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_16
		{
			get
			{
				return this.dataColumn_17;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_17
		{
			get
			{
				return this.dataColumn_18;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_18
		{
			get
			{
				return this.dataColumn_19;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_19
		{
			get
			{
				return this.dataColumn_20;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[Browsable(false)]
		[DebuggerNonUserCode]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class546 this[int int_0]
		{
			get
			{
				return (Class537.Class546)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate255 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate255 @delegate = this.delegate255_0;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate255 @delegate = this.delegate255_0;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate255 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate255 @delegate = this.delegate255_1;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate255 @delegate = this.delegate255_1;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate255 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate255 @delegate = this.delegate255_2;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate255 @delegate = this.delegate255_2;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate255 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate255 @delegate = this.delegate255_3;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate255 @delegate = this.delegate255_3;
				Class537.Delegate255 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate255 value2 = (Class537.Delegate255)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate255>(ref this.delegate255_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class537.Class546 class546_0)
		{
			base.Rows.Add(class546_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class546 method_1(int int_0, string string_0, string string_1, string string_2, string string_3, int int_1, string string_4, string string_5, int int_2, int int_3, int int_4, string string_6, int int_5, int int_6, int int_7, int int_8, DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, DateTime dateTime_3, string string_7)
		{
			Class537.Class546 @class = (Class537.Class546)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				string_1,
				string_2,
				string_3,
				int_1,
				string_4,
				string_5,
				int_2,
				int_3,
				int_4,
				string_6,
				int_5,
				int_6,
				int_7,
				int_8,
				dateTime_0,
				dateTime_1,
				dateTime_2,
				dateTime_3,
				string_7
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class537.Class541 @class = (Class537.Class541)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class537.Class541();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["CodeAbonent"];
			this.dataColumn_1 = base.Columns["Name"];
			this.dataColumn_2 = base.Columns["ObjName"];
			this.dataColumn_3 = base.Columns["Number"];
			this.dataColumn_4 = base.Columns["Name_Group"];
			this.dataColumn_5 = base.Columns["idAbn"];
			this.dataColumn_6 = base.Columns["AbnWorker"];
			this.dataColumn_7 = base.Columns["ObjWorker"];
			this.dataColumn_8 = base.Columns["idAbnObj"];
			this.dataColumn_9 = base.Columns["NumberObj"];
			this.dataColumn_10 = base.Columns["NumberSubObj"];
			this.dataColumn_11 = base.Columns["TypeAbn"];
			this.dataColumn_12 = base.Columns["idTypeAbn"];
			this.dataColumn_13 = base.Columns["idNet"];
			this.dataColumn_14 = base.Columns["idSale"];
			this.dataColumn_15 = base.Columns["Flag"];
			this.dataColumn_16 = base.Columns["DateOn"];
			this.dataColumn_17 = base.Columns["DateOff"];
			this.dataColumn_18 = base.Columns["DateBegin"];
			this.dataColumn_19 = base.Columns["DateEnd"];
			this.dataColumn_20 = base.Columns["CodeAbnStr"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("ObjName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Number", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Name_Group", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("AbnWorker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("ObjWorker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("NumberObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("NumberSubObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("TypeAbn", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("idTypeAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("idNet", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("idSale", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("Flag", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("DateOn", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("DateOff", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("DateBegin", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("DateEnd", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("CodeAbnStr", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_1.MaxLength = 100;
			this.dataColumn_2.MaxLength = 255;
			this.dataColumn_3.MaxLength = 50;
			this.dataColumn_4.MaxLength = 50;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_6.MaxLength = 30;
			this.dataColumn_7.MaxLength = 30;
			this.dataColumn_11.MaxLength = 100;
			this.dataColumn_12.AllowDBNull = false;
			this.dataColumn_15.ReadOnly = true;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class546 method_4()
		{
			return (Class537.Class546)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class537.Class546(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class537.Class546);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate255_1 != null)
			{
				this.delegate255_1(this, new Class537.EventArgs251((Class537.Class546)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate255_0 != null)
			{
				this.delegate255_0(this, new Class537.EventArgs251((Class537.Class546)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate255_3 != null)
			{
				this.delegate255_3(this, new Class537.EventArgs251((Class537.Class546)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate255_2 != null)
			{
				this.delegate255_2(this, new Class537.EventArgs251((Class537.Class546)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class537.Class546 class546_0)
		{
			base.Rows.Remove(class546_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class537 @class = new Class537();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = "http://www.w3.org/2001/XMLSchema";
			xmlSchemaAny.MinOccurs = 0m;
			xmlSchemaAny.MaxOccurs = decimal.MaxValue;
			xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
			xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			xmlSchemaAny2.MinOccurs = 1m;
			xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny2);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute();
			xmlSchemaAttribute.Name = "namespace";
			xmlSchemaAttribute.FixedValue = @class.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "vG_AbnObjCntDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = @class.GetSchemaSerializable();
			if (xmlSchemaSet_0.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					schemaSerializable.Write(memoryStream);
					foreach (object obj in xmlSchemaSet_0.Schemas(schemaSerializable.TargetNamespace))
					{
						XmlSchema xmlSchema = (XmlSchema)obj;
						memoryStream2.SetLength(0L);
						xmlSchema.Write(memoryStream2);
						if (memoryStream.Length == memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							memoryStream2.Position = 0L;
							while (memoryStream.Position != memoryStream.Length)
							{
								if (memoryStream.ReadByte() != memoryStream2.ReadByte())
								{
									break;
								}
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								return xmlSchemaComplexType;
							}
						}
					}
					goto IL_1ED;
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream2 != null)
					{
						memoryStream2.Close();
					}
				}
				XmlSchemaComplexType result;
				return result;
			}
			IL_1ED:
			xmlSchemaSet_0.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataColumn dataColumn_4;

		private DataColumn dataColumn_5;

		private DataColumn dataColumn_6;

		private DataColumn dataColumn_7;

		private DataColumn dataColumn_8;

		private DataColumn dataColumn_9;

		private DataColumn dataColumn_10;

		private DataColumn dataColumn_11;

		private DataColumn dataColumn_12;

		private DataColumn dataColumn_13;

		private DataColumn dataColumn_14;

		private DataColumn dataColumn_15;

		private DataColumn dataColumn_16;

		private DataColumn dataColumn_17;

		private DataColumn dataColumn_18;

		private DataColumn dataColumn_19;

		private DataColumn dataColumn_20;

		[CompilerGenerated]
		private Class537.Delegate255 delegate255_0;

		[CompilerGenerated]
		private Class537.Delegate255 delegate255_1;

		[CompilerGenerated]
		private Class537.Delegate255 delegate255_2;

		[CompilerGenerated]
		private Class537.Delegate255 delegate255_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class542 : TypedTableBase<Class537.Class547>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class542()
		{
			
			
			base.TableName = "vG_AbnObjCnt1";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class542(DataTable dataTable_0)
		{
			
			
			base.TableName = dataTable_0.TableName;
			if (dataTable_0.CaseSensitive != dataTable_0.DataSet.CaseSensitive)
			{
				base.CaseSensitive = dataTable_0.CaseSensitive;
			}
			if (dataTable_0.Locale.ToString() != dataTable_0.DataSet.Locale.ToString())
			{
				base.Locale = dataTable_0.Locale;
			}
			if (dataTable_0.Namespace != dataTable_0.DataSet.Namespace)
			{
				base.Namespace = dataTable_0.Namespace;
			}
			base.Prefix = dataTable_0.Prefix;
			base.MinimumCapacity = dataTable_0.MinimumCapacity;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected Class542(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_0
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_8
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_9
		{
			get
			{
				return this.dataColumn_9;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_10
		{
			get
			{
				return this.dataColumn_10;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_11
		{
			get
			{
				return this.dataColumn_11;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_12
		{
			get
			{
				return this.dataColumn_12;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_13
		{
			get
			{
				return this.dataColumn_13;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_14
		{
			get
			{
				return this.dataColumn_14;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_15
		{
			get
			{
				return this.dataColumn_15;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_16
		{
			get
			{
				return this.dataColumn_16;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_17
		{
			get
			{
				return this.dataColumn_17;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_18
		{
			get
			{
				return this.dataColumn_18;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_19
		{
			get
			{
				return this.dataColumn_19;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class547 this[int int_0]
		{
			get
			{
				return (Class537.Class547)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate256 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate256 @delegate = this.delegate256_0;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate256 @delegate = this.delegate256_0;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate256 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate256 @delegate = this.delegate256_1;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate256 @delegate = this.delegate256_1;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate256 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate256 @delegate = this.delegate256_2;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate256 @delegate = this.delegate256_2;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class537.Delegate256 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class537.Delegate256 @delegate = this.delegate256_3;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class537.Delegate256 @delegate = this.delegate256_3;
				Class537.Delegate256 delegate2;
				do
				{
					delegate2 = @delegate;
					Class537.Delegate256 value2 = (Class537.Delegate256)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class537.Delegate256>(ref this.delegate256_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class537.Class547 class547_0)
		{
			base.Rows.Add(class547_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class547 method_1(int int_0, string string_0, string string_1, string string_2, string string_3, int int_1, string string_4, string string_5, int int_2, int int_3, int int_4, string string_6, int int_5, int int_6, int int_7, int int_8, DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, DateTime dateTime_3)
		{
			Class537.Class547 @class = (Class537.Class547)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				string_1,
				string_2,
				string_3,
				int_1,
				string_4,
				string_5,
				int_2,
				int_3,
				int_4,
				string_6,
				int_5,
				int_6,
				int_7,
				int_8,
				dateTime_0,
				dateTime_1,
				dateTime_2,
				dateTime_3
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class537.Class542 @class = (Class537.Class542)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class537.Class542();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["CodeAbonent"];
			this.dataColumn_1 = base.Columns["Name"];
			this.dataColumn_2 = base.Columns["ObjName"];
			this.dataColumn_3 = base.Columns["Number"];
			this.dataColumn_4 = base.Columns["Name_Group"];
			this.dataColumn_5 = base.Columns["idAbn"];
			this.dataColumn_6 = base.Columns["AbnWorker"];
			this.dataColumn_7 = base.Columns["ObjWorker"];
			this.dataColumn_8 = base.Columns["idAbnObj"];
			this.dataColumn_9 = base.Columns["NumberObj"];
			this.dataColumn_10 = base.Columns["NumberSubObj"];
			this.dataColumn_11 = base.Columns["TypeAbn"];
			this.dataColumn_12 = base.Columns["idTypeAbn"];
			this.dataColumn_13 = base.Columns["idNet"];
			this.dataColumn_14 = base.Columns["idSale"];
			this.dataColumn_15 = base.Columns["Flag"];
			this.dataColumn_16 = base.Columns["DateOn"];
			this.dataColumn_17 = base.Columns["DateOff"];
			this.dataColumn_18 = base.Columns["DateBegin"];
			this.dataColumn_19 = base.Columns["DateEnd"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("ObjName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Number", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Name_Group", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("AbnWorker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("ObjWorker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("NumberObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("NumberSubObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("TypeAbn", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("idTypeAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("idNet", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("idSale", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("Flag", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("DateOn", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("DateOff", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("DateBegin", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("DateEnd", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_1.MaxLength = 100;
			this.dataColumn_2.MaxLength = 255;
			this.dataColumn_3.MaxLength = 50;
			this.dataColumn_4.MaxLength = 50;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_6.MaxLength = 30;
			this.dataColumn_7.MaxLength = 30;
			this.dataColumn_11.MaxLength = 100;
			this.dataColumn_12.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class547 method_4()
		{
			return (Class537.Class547)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class537.Class547(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class537.Class547);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate256_1 != null)
			{
				this.delegate256_1(this, new Class537.EventArgs252((Class537.Class547)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate256_0 != null)
			{
				this.delegate256_0(this, new Class537.EventArgs252((Class537.Class547)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate256_3 != null)
			{
				this.delegate256_3(this, new Class537.EventArgs252((Class537.Class547)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate256_2 != null)
			{
				this.delegate256_2(this, new Class537.EventArgs252((Class537.Class547)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class537.Class547 class547_0)
		{
			base.Rows.Remove(class547_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class537 @class = new Class537();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = "http://www.w3.org/2001/XMLSchema";
			xmlSchemaAny.MinOccurs = 0m;
			xmlSchemaAny.MaxOccurs = decimal.MaxValue;
			xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
			xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			xmlSchemaAny2.MinOccurs = 1m;
			xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny2);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute();
			xmlSchemaAttribute.Name = "namespace";
			xmlSchemaAttribute.FixedValue = @class.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "vG_AbnObjCnt1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = @class.GetSchemaSerializable();
			if (xmlSchemaSet_0.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					schemaSerializable.Write(memoryStream);
					foreach (object obj in xmlSchemaSet_0.Schemas(schemaSerializable.TargetNamespace))
					{
						XmlSchema xmlSchema = (XmlSchema)obj;
						memoryStream2.SetLength(0L);
						xmlSchema.Write(memoryStream2);
						if (memoryStream.Length == memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							memoryStream2.Position = 0L;
							while (memoryStream.Position != memoryStream.Length)
							{
								if (memoryStream.ReadByte() != memoryStream2.ReadByte())
								{
									break;
								}
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								return xmlSchemaComplexType;
							}
						}
					}
					goto IL_1ED;
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream2 != null)
					{
						memoryStream2.Close();
					}
				}
				XmlSchemaComplexType result;
				return result;
			}
			IL_1ED:
			xmlSchemaSet_0.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataColumn dataColumn_4;

		private DataColumn dataColumn_5;

		private DataColumn dataColumn_6;

		private DataColumn dataColumn_7;

		private DataColumn dataColumn_8;

		private DataColumn dataColumn_9;

		private DataColumn dataColumn_10;

		private DataColumn dataColumn_11;

		private DataColumn dataColumn_12;

		private DataColumn dataColumn_13;

		private DataColumn dataColumn_14;

		private DataColumn dataColumn_15;

		private DataColumn dataColumn_16;

		private DataColumn dataColumn_17;

		private DataColumn dataColumn_18;

		private DataColumn dataColumn_19;

		[CompilerGenerated]
		private Class537.Delegate256 delegate256_0;

		[CompilerGenerated]
		private Class537.Delegate256 delegate256_1;

		[CompilerGenerated]
		private Class537.Delegate256 delegate256_2;

		[CompilerGenerated]
		private Class537.Delegate256 delegate256_3;
	}

	public class Class543 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class543(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class538_0 = (Class537.Class538)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class538_0.DataColumn_0];
			}
			set
			{
				base[this.class538_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Name
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class538_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vG_Find' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class538_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string ObjName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class538_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ObjName' in table 'vG_Find' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class538_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				return (int)base[this.class538_0.DataColumn_3];
			}
			set
			{
				base[this.class538_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbnObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class538_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbnObj' in table 'vG_Find' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class538_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class538_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class538_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class538_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class538_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class538_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class538_0.DataColumn_4] = Convert.DBNull;
		}

		private Class537.Class538 class538_0;
	}

	public class Class544 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class544(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class539_0 = (Class537.Class539)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class539_0.DataColumn_0];
			}
			set
			{
				base[this.class539_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Name
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class539_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vG_AbnObjCntShort' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class539_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string AbnWorker
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class539_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AbnWorker' in table 'vG_AbnObjCntShort' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class539_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				return (int)base[this.class539_0.DataColumn_3];
			}
			set
			{
				base[this.class539_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class539_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class539_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class539_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class539_0.DataColumn_2] = Convert.DBNull;
		}

		private Class537.Class539 class539_0;
	}

	public class Class545 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class545(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class540_0 = (Class537.Class540)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class540_0.idColumn];
			}
			set
			{
				base[this.class540_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class540_0.DataColumn_0];
			}
			set
			{
				base[this.class540_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Name
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class540_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'tAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class540_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeAbn
		{
			get
			{
				return (int)base[this.class540_0.DataColumn_2];
			}
			set
			{
				base[this.class540_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idWorker
		{
			get
			{
				return (int)base[this.class540_0.idWorkerColumn];
			}
			set
			{
				base[this.class540_0.idWorkerColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class540_0.DataColumn_3];
			}
			set
			{
				base[this.class540_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class540_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class540_0.DataColumn_1] = Convert.DBNull;
		}

		private Class537.Class540 class540_0;
	}

	public class Class546 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class546(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class541_0 = (Class537.Class541)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class541_0.DataColumn_0];
			}
			set
			{
				base[this.class541_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Name
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string ObjName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ObjName' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Number
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Number' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Name_Group
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name_Group' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				return (int)base[this.class541_0.DataColumn_5];
			}
			set
			{
				base[this.class541_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string AbnWorker
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AbnWorker' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ObjWorker
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ObjWorker' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbnObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class541_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbnObj' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int NumberObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class541_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NumberObj' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int NumberSubObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class541_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NumberSubObj' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_10] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string TypeAbn
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.QchWosrhrud];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeAbn' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.QchWosrhrud] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idTypeAbn
		{
			get
			{
				return (int)base[this.class541_0.DataColumn_11];
			}
			set
			{
				base[this.class541_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idNet
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class541_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idNet' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idSale
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class541_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idSale' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_13] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Flag
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class541_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Flag' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_14] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateOn
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class541_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOn' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_15] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateOff
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class541_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOff' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_16] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateBegin
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class541_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateBegin' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_17] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateEnd
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class541_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateEnd' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_18] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string CodeAbnStr
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class541_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CodeAbnStr' in table 'vG_AbnObjCnt' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class541_0.DataColumn_19] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class541_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class541_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class541_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class541_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class541_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class541_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class541_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class541_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class541_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class541_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class541_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class541_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class541_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class541_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class541_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class541_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class541_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class541_0.DataColumn_10] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class541_0.QchWosrhrud);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class541_0.QchWosrhrud] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class541_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class541_0.DataColumn_12] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_22()
		{
			return base.IsNull(this.class541_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class541_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class541_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class541_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class541_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_27()
		{
			base[this.class541_0.DataColumn_15] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class541_0.DataColumn_16);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_29()
		{
			base[this.class541_0.DataColumn_16] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class541_0.DataColumn_17);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class541_0.DataColumn_17] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_32()
		{
			return base.IsNull(this.class541_0.DataColumn_18);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_33()
		{
			base[this.class541_0.DataColumn_18] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_34()
		{
			return base.IsNull(this.class541_0.DataColumn_19);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_35()
		{
			base[this.class541_0.DataColumn_19] = Convert.DBNull;
		}

		private Class537.Class541 class541_0;
	}

	public class Class547 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class547(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class542_0 = (Class537.Class542)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class542_0.DataColumn_0];
			}
			set
			{
				base[this.class542_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Name
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class542_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string ObjName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class542_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ObjName' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Number
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class542_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Number' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Name_Group
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class542_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name_Group' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idAbn
		{
			get
			{
				return (int)base[this.class542_0.DataColumn_5];
			}
			set
			{
				base[this.class542_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string AbnWorker
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class542_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AbnWorker' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ObjWorker
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class542_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ObjWorker' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idAbnObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class542_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbnObj' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int NumberObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class542_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NumberObj' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int NumberSubObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class542_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NumberSubObj' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string TypeAbn
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class542_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeAbn' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idTypeAbn
		{
			get
			{
				return (int)base[this.class542_0.DataColumn_12];
			}
			set
			{
				base[this.class542_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idNet
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class542_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idNet' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_13] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idSale
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class542_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idSale' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_14] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Flag
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class542_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Flag' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_15] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateOn
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class542_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOn' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_16] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateOff
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class542_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOff' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateBegin
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class542_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateBegin' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_18] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateEnd
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class542_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateEnd' in table 'vG_AbnObjCnt1' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class542_0.DataColumn_19] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class542_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class542_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class542_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class542_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class542_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class542_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class542_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class542_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class542_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class542_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class542_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class542_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class542_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class542_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class542_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class542_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class542_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class542_0.DataColumn_10] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class542_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_19()
		{
			base[this.class542_0.DataColumn_11] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class542_0.DataColumn_13);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class542_0.DataColumn_13] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class542_0.DataColumn_14);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class542_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_24()
		{
			return base.IsNull(this.class542_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class542_0.DataColumn_15] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class542_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_27()
		{
			base[this.class542_0.DataColumn_16] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class542_0.DataColumn_17);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_29()
		{
			base[this.class542_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class542_0.DataColumn_18);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_31()
		{
			base[this.class542_0.DataColumn_18] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_32()
		{
			return base.IsNull(this.class542_0.DataColumn_19);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_33()
		{
			base[this.class542_0.DataColumn_19] = Convert.DBNull;
		}

		private Class537.Class542 class542_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs248 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs248(Class537.Class543 class543_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class543_0 = class543_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class543 Row
		{
			get
			{
				return this.class543_0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataRowAction DataRowAction_0
		{
			get
			{
				return this.dataRowAction_0;
			}
		}

		private Class537.Class543 class543_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs249 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs249(Class537.Class544 class544_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class544_0 = class544_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class544 Row
		{
			get
			{
				return this.class544_0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataRowAction DataRowAction_0
		{
			get
			{
				return this.dataRowAction_0;
			}
		}

		private Class537.Class544 class544_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs250 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs250(Class537.Class545 class545_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class545_0 = class545_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class537.Class545 Row
		{
			get
			{
				return this.class545_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataRowAction DataRowAction_0
		{
			get
			{
				return this.dataRowAction_0;
			}
		}

		private Class537.Class545 class545_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs251 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs251(Class537.Class546 class546_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class546_0 = class546_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class546 Row
		{
			get
			{
				return this.class546_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataRowAction DataRowAction_0
		{
			get
			{
				return this.dataRowAction_0;
			}
		}

		private Class537.Class546 class546_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs252 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs252(Class537.Class547 class547_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class547_0 = class547_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class537.Class547 Row
		{
			get
			{
				return this.class547_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataRowAction DataRowAction_0
		{
			get
			{
				return this.dataRowAction_0;
			}
		}

		private Class537.Class547 class547_0;

		private DataRowAction dataRowAction_0;
	}
}
