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

[DesignerCategory("code")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[ToolboxItem(true)]
[XmlRoot("DataSetFailure")]
[HelpKeyword("vs.data.DataSet")]
[Serializable]
internal class Class126 : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class126()
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		
		base.BeginInit();
		this.method_2();
		CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_4);
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		base.EndInit();
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected Class126(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		base..ctor(serializationInfo_0, streamingContext_0, false);
		if (base.IsBinarySerialized(serializationInfo_0, streamingContext_0))
		{
			this.method_1(false);
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_4);
			this.DataTableCollection_0.CollectionChanged += value;
			this.DataRelationCollection_0.CollectionChanged += value;
			return;
		}
		string s = (string)serializationInfo_0.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(serializationInfo_0, streamingContext_0) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["tJ_TechnologicalFailures"] != null)
			{
				base.Tables.Add(new Class126.Class127(dataSet.Tables["tJ_TechnologicalFailures"]));
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
		CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_4);
		base.Tables.CollectionChanged += value2;
		this.DataRelationCollection_0.CollectionChanged += value2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class126.Class127 tJ_TechnologicalFailures
	{
		get
		{
			return this.class127_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Browsable(true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataTableCollection DataTableCollection_0
	{
		get
		{
			return base.Tables;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataRelationCollection DataRelationCollection_0
	{
		get
		{
			return base.Relations;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected override void InitializeDerivedDataSet()
	{
		base.BeginInit();
		this.method_2();
		base.EndInit();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public override DataSet Clone()
	{
		Class126 @class = (Class126)base.Clone();
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected override void ReadXmlSerializable(XmlReader reader)
	{
		if (base.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
		{
			this.Reset();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(reader);
			if (dataSet.Tables["tJ_TechnologicalFailures"] != null)
			{
				base.Tables.Add(new Class126.Class127(dataSet.Tables["tJ_TechnologicalFailures"]));
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal void method_0()
	{
		this.method_1(true);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal void method_1(bool bool_0)
	{
		this.class127_0 = (Class126.Class127)base.Tables["tJ_TechnologicalFailures"];
		if (bool_0 && this.class127_0 != null)
		{
			this.class127_0.method_3();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_2()
	{
		base.DataSetName = "DataSetFailure";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/DataSetFailure.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class127_0 = new Class126.Class127();
		base.Tables.Add(this.class127_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_3()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_4(object sender, CollectionChangeEventArgs e)
	{
		if (e.Action == CollectionChangeAction.Remove)
		{
			this.method_0();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
	{
		Class126 @class = new Class126();
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

	private Class126.Class127 class127_0;

	private SchemaSerializationMode schemaSerializationMode_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate54(object sender, Class126.EventArgs53 e);

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class127 : TypedTableBase<Class126.Class128>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class127()
		{
			
			
			base.TableName = "tJ_TechnologicalFailures";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class127(DataTable dataTable_0)
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
		protected Class127(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn schmObjColumn
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn dateOnColumn
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[Browsable(false)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class126.Class128 this[int int_0]
		{
			get
			{
				return (Class126.Class128)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class126.Delegate54 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class126.Delegate54 @delegate = this.delegate54_0;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class126.Delegate54 @delegate = this.delegate54_0;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class126.Delegate54 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class126.Delegate54 @delegate = this.delegate54_1;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class126.Delegate54 @delegate = this.delegate54_1;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class126.Delegate54 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class126.Delegate54 @delegate = this.delegate54_2;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class126.Delegate54 @delegate = this.delegate54_2;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class126.Delegate54 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class126.Delegate54 @delegate = this.delegate54_3;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class126.Delegate54 @delegate = this.delegate54_3;
				Class126.Delegate54 delegate2;
				do
				{
					delegate2 = @delegate;
					Class126.Delegate54 value2 = (Class126.Delegate54)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class126.Delegate54>(ref this.delegate54_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class126.Class128 class128_0)
		{
			base.Rows.Add(class128_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class126.Class128 method_1(int int_0, DateTime dateTime_0, string string_0, string string_1, DateTime dateTime_1, string string_2, int int_1)
		{
			Class126.Class128 @class = (Class126.Class128)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				dateTime_0,
				string_0,
				string_1,
				dateTime_1,
				string_2,
				int_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class126.Class128 method_2(int int_0)
		{
			return (Class126.Class128)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class126.Class127 @class = (Class126.Class127)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class126.Class127();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["num"];
			this.dataColumn_2 = base.Columns["dateOff"];
			this.dataColumn_3 = base.Columns["schmObj"];
			this.dataColumn_4 = base.Columns["text"];
			this.dataColumn_5 = base.Columns["dateOn"];
			this.dataColumn_6 = base.Columns["abonents"];
			this.dataColumn_7 = base.Columns["DownTime"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("num", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("dateOff", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("schmObj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("text", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("dateOn", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("abonents", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("DownTime", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AutoIncrement = true;
			this.dataColumn_0.AutoIncrementSeed = -1L;
			this.dataColumn_0.AutoIncrementStep = -1L;
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_4.MaxLength = 1024;
			this.dataColumn_6.MaxLength = 1024;
			this.dataColumn_7.ReadOnly = true;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class126.Class128 method_5()
		{
			return (Class126.Class128)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class126.Class128(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class126.Class128);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate54_1 != null)
			{
				this.delegate54_1(this, new Class126.EventArgs53((Class126.Class128)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate54_0 != null)
			{
				this.delegate54_0(this, new Class126.EventArgs53((Class126.Class128)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate54_3 != null)
			{
				this.delegate54_3(this, new Class126.EventArgs53((Class126.Class128)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate54_2 != null)
			{
				this.delegate54_2(this, new Class126.EventArgs53((Class126.Class128)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class126.Class128 class128_0)
		{
			base.Rows.Remove(class128_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class126 @class = new Class126();
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
			xmlSchemaAttribute2.FixedValue = "tJ_TechnologicalFailuresDataTable";
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

		[CompilerGenerated]
		private Class126.Delegate54 delegate54_0;

		[CompilerGenerated]
		private Class126.Delegate54 delegate54_1;

		[CompilerGenerated]
		private Class126.Delegate54 delegate54_2;

		[CompilerGenerated]
		private Class126.Delegate54 delegate54_3;
	}

	public class Class128 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class128(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class127_0 = (Class126.Class127)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class127_0.idColumn];
			}
			set
			{
				base[this.class127_0.idColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int num
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class127_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'num' in table 'tJ_TechnologicalFailures' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class127_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateOff
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class127_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateOff' in table 'tJ_TechnologicalFailures' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class127_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string schmObj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class127_0.schmObjColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'schmObj' in table 'tJ_TechnologicalFailures' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class127_0.schmObjColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string text
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class127_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'text' in table 'tJ_TechnologicalFailures' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class127_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateOn
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class127_0.dateOnColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateOn' in table 'tJ_TechnologicalFailures' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class127_0.dateOnColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string abonents
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class127_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'abonents' in table 'tJ_TechnologicalFailures' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class127_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int DownTime
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class127_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DownTime' in table 'tJ_TechnologicalFailures' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class127_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class127_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class127_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class127_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class127_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class127_0.schmObjColumn);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class127_0.schmObjColumn] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class127_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class127_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class127_0.dateOnColumn);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class127_0.dateOnColumn] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class127_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class127_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class127_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class127_0.DataColumn_4] = Convert.DBNull;
		}

		private Class126.Class127 class127_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs53 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs53(Class126.Class128 class128_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class128_0 = class128_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class126.Class128 Row
		{
			get
			{
				return this.class128_0;
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

		private Class126.Class128 class128_0;

		private DataRowAction dataRowAction_0;
	}
}
