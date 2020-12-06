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
[HelpKeyword("vs.data.DataSet")]
[XmlRoot("DataSetCalcPrimer")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[ToolboxItem(true)]
[Serializable]
internal class Class230 : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class230()
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		
		base.BeginInit();
		this.method_2();
		CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_15);
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		base.EndInit();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected Class230(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		base..ctor(serializationInfo_0, streamingContext_0, false);
		if (base.IsBinarySerialized(serializationInfo_0, streamingContext_0))
		{
			this.method_1(false);
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_15);
			this.DataTableCollection_0.CollectionChanged += value;
			this.DataRelationCollection_0.CollectionChanged += value;
			return;
		}
		string s = (string)serializationInfo_0.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(serializationInfo_0, streamingContext_0) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["dtAbonent"] != null)
			{
				base.Tables.Add(new Class230.Class231(dataSet.Tables["dtAbonent"]));
			}
			if (dataSet.Tables["dtAbnObj"] != null)
			{
				base.Tables.Add(new Class230.Class232(dataSet.Tables["dtAbnObj"]));
			}
			if (dataSet.Tables["dtDeviceMark"] != null)
			{
				base.Tables.Add(new Class230.Class233(dataSet.Tables["dtDeviceMark"]));
			}
			if (dataSet.Tables["Трасформатор"] != null)
			{
				base.Tables.Add(new Class230.Class234(dataSet.Tables["Трасформатор"]));
			}
			if (dataSet.Tables["Кабель"] != null)
			{
				base.Tables.Add(new Class230.Class235(dataSet.Tables["Кабель"]));
			}
			if (dataSet.Tables["Журнал расчетов"] != null)
			{
				base.Tables.Add(new Class230.Class236(dataSet.Tables["Журнал расчетов"]));
			}
			if (dataSet.Tables["Расчет трансформатора"] != null)
			{
				base.Tables.Add(new Class230.Class237(dataSet.Tables["Расчет трансформатора"]));
			}
			if (dataSet.Tables["Расчет высоковольтной линии"] != null)
			{
				base.Tables.Add(new Class230.Class238(dataSet.Tables["Расчет высоковольтной линии"]));
			}
			if (dataSet.Tables["Расчет кабельной линии"] != null)
			{
				base.Tables.Add(new Class230.Class239(dataSet.Tables["Расчет кабельной линии"]));
			}
			if (dataSet.Tables["Классификатор"] != null)
			{
				base.Tables.Add(new Class230.Class240(dataSet.Tables["Классификатор"]));
			}
			if (dataSet.Tables["dtAbnObjDevice"] != null)
			{
				base.Tables.Add(new Class230.Class241(dataSet.Tables["dtAbnObjDevice"]));
			}
			if (dataSet.Tables["Предопределенные значения колонок"] != null)
			{
				base.Tables.Add(new Class230.Class242(dataSet.Tables["Предопределенные значения колонок"]));
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
		CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_15);
		base.Tables.CollectionChanged += value2;
		this.DataRelationCollection_0.CollectionChanged += value2;
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class230.Class231 dtAbonent
	{
		get
		{
			return this.class231_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class230.Class232 dtAbnObj
	{
		get
		{
			return this.class232_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class230.Class233 dtDeviceMark
	{
		get
		{
			return this.class233_0;
		}
	}

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class230.Class234 Class234_0
	{
		get
		{
			return this.class234_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public Class230.Class235 Class235_0
	{
		get
		{
			return this.class235_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public Class230.Class236 Class236_0
	{
		get
		{
			return this.class236_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class230.Class237 Class237_0
	{
		get
		{
			return this.class237_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class230.Class238 Class238_0
	{
		get
		{
			return this.class238_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class230.Class239 Class239_0
	{
		get
		{
			return this.class239_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class230.Class240 Class240_0
	{
		get
		{
			return this.class240_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class230.Class241 dtAbnObjDevice
	{
		get
		{
			return this.class241_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class230.Class242 Class242_0
	{
		get
		{
			return this.class242_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[Browsable(true)]
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public override DataSet Clone()
	{
		Class230 @class = (Class230)base.Clone();
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
			if (dataSet.Tables["dtAbonent"] != null)
			{
				base.Tables.Add(new Class230.Class231(dataSet.Tables["dtAbonent"]));
			}
			if (dataSet.Tables["dtAbnObj"] != null)
			{
				base.Tables.Add(new Class230.Class232(dataSet.Tables["dtAbnObj"]));
			}
			if (dataSet.Tables["dtDeviceMark"] != null)
			{
				base.Tables.Add(new Class230.Class233(dataSet.Tables["dtDeviceMark"]));
			}
			if (dataSet.Tables["Трасформатор"] != null)
			{
				base.Tables.Add(new Class230.Class234(dataSet.Tables["Трасформатор"]));
			}
			if (dataSet.Tables["Кабель"] != null)
			{
				base.Tables.Add(new Class230.Class235(dataSet.Tables["Кабель"]));
			}
			if (dataSet.Tables["Журнал расчетов"] != null)
			{
				base.Tables.Add(new Class230.Class236(dataSet.Tables["Журнал расчетов"]));
			}
			if (dataSet.Tables["Расчет трансформатора"] != null)
			{
				base.Tables.Add(new Class230.Class237(dataSet.Tables["Расчет трансформатора"]));
			}
			if (dataSet.Tables["Расчет высоковольтной линии"] != null)
			{
				base.Tables.Add(new Class230.Class238(dataSet.Tables["Расчет высоковольтной линии"]));
			}
			if (dataSet.Tables["Расчет кабельной линии"] != null)
			{
				base.Tables.Add(new Class230.Class239(dataSet.Tables["Расчет кабельной линии"]));
			}
			if (dataSet.Tables["Классификатор"] != null)
			{
				base.Tables.Add(new Class230.Class240(dataSet.Tables["Классификатор"]));
			}
			if (dataSet.Tables["dtAbnObjDevice"] != null)
			{
				base.Tables.Add(new Class230.Class241(dataSet.Tables["dtAbnObjDevice"]));
			}
			if (dataSet.Tables["Предопределенные значения колонок"] != null)
			{
				base.Tables.Add(new Class230.Class242(dataSet.Tables["Предопределенные значения колонок"]));
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
		this.class231_0 = (Class230.Class231)base.Tables["dtAbonent"];
		if (bool_0 && this.class231_0 != null)
		{
			this.class231_0.method_2();
		}
		this.class232_0 = (Class230.Class232)base.Tables["dtAbnObj"];
		if (bool_0 && this.class232_0 != null)
		{
			this.class232_0.method_2();
		}
		this.class233_0 = (Class230.Class233)base.Tables["dtDeviceMark"];
		if (bool_0 && this.class233_0 != null)
		{
			this.class233_0.method_2();
		}
		this.class234_0 = (Class230.Class234)base.Tables["Трасформатор"];
		if (bool_0 && this.class234_0 != null)
		{
			this.class234_0.method_2();
		}
		this.class235_0 = (Class230.Class235)base.Tables["Кабель"];
		if (bool_0 && this.class235_0 != null)
		{
			this.class235_0.method_2();
		}
		this.class236_0 = (Class230.Class236)base.Tables["Журнал расчетов"];
		if (bool_0 && this.class236_0 != null)
		{
			this.class236_0.method_3();
		}
		this.class237_0 = (Class230.Class237)base.Tables["Расчет трансформатора"];
		if (bool_0 && this.class237_0 != null)
		{
			this.class237_0.method_2();
		}
		this.class238_0 = (Class230.Class238)base.Tables["Расчет высоковольтной линии"];
		if (bool_0 && this.class238_0 != null)
		{
			this.class238_0.method_2();
		}
		this.class239_0 = (Class230.Class239)base.Tables["Расчет кабельной линии"];
		if (bool_0 && this.class239_0 != null)
		{
			this.class239_0.method_2();
		}
		this.class240_0 = (Class230.Class240)base.Tables["Классификатор"];
		if (bool_0 && this.class240_0 != null)
		{
			this.class240_0.method_2();
		}
		this.class241_0 = (Class230.Class241)base.Tables["dtAbnObjDevice"];
		if (bool_0 && this.class241_0 != null)
		{
			this.class241_0.method_2();
		}
		this.class242_0 = (Class230.Class242)base.Tables["Предопределенные значения колонок"];
		if (bool_0 && this.class242_0 != null)
		{
			this.class242_0.method_2();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_2()
	{
		base.DataSetName = "DataSetCalcPrimer";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/DataSetCalcPrimer.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class231_0 = new Class230.Class231();
		base.Tables.Add(this.class231_0);
		this.class232_0 = new Class230.Class232();
		base.Tables.Add(this.class232_0);
		this.class233_0 = new Class230.Class233();
		base.Tables.Add(this.class233_0);
		this.class234_0 = new Class230.Class234();
		base.Tables.Add(this.class234_0);
		this.class235_0 = new Class230.Class235();
		base.Tables.Add(this.class235_0);
		this.class236_0 = new Class230.Class236();
		base.Tables.Add(this.class236_0);
		this.class237_0 = new Class230.Class237();
		base.Tables.Add(this.class237_0);
		this.class238_0 = new Class230.Class238();
		base.Tables.Add(this.class238_0);
		this.class239_0 = new Class230.Class239();
		base.Tables.Add(this.class239_0);
		this.class240_0 = new Class230.Class240();
		base.Tables.Add(this.class240_0);
		this.class241_0 = new Class230.Class241();
		base.Tables.Add(this.class241_0);
		this.class242_0 = new Class230.Class242();
		base.Tables.Add(this.class242_0);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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
	private bool method_8()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_9()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_10()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_11()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_12()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_13()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_14()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_15(object sender, CollectionChangeEventArgs e)
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
		Class230 @class = new Class230();
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

	private Class230.Class231 class231_0;

	private Class230.Class232 class232_0;

	private Class230.Class233 class233_0;

	private Class230.Class234 class234_0;

	private Class230.Class235 class235_0;

	private Class230.Class236 class236_0;

	private Class230.Class237 class237_0;

	private Class230.Class238 class238_0;

	private Class230.Class239 class239_0;

	private Class230.Class240 class240_0;

	private Class230.Class241 class241_0;

	private Class230.Class242 class242_0;

	private SchemaSerializationMode schemaSerializationMode_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate100(object sender, Class230.EventArgs96 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate101(object sender, Class230.EventArgs97 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate102(object sender, Class230.EventArgs98 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate103(object sender, Class230.EventArgs99 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate104(object sender, Class230.EventArgs100 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate105(object sender, Class230.EventArgs101 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate106(object sender, Class230.EventArgs102 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate107(object sender, Class230.EventArgs103 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate108(object sender, Class230.EventArgs104 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate109(object sender, Class230.EventArgs105 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate110(object sender, Class230.EventArgs106 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate111(object sender, Class230.EventArgs107 e);

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class231 : TypedTableBase<Class230.Class243>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class231()
		{
			
			
			base.TableName = "dtAbonent";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class231(DataTable dataTable_0)
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
		protected Class231(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
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
		public Class230.Class243 this[int int_0]
		{
			get
			{
				return (Class230.Class243)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate100 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate100 @delegate = this.delegate100_0;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate100 @delegate = this.delegate100_0;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate100 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate100 @delegate = this.delegate100_1;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate100 @delegate = this.delegate100_1;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate100 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate100 @delegate = this.delegate100_2;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate100 @delegate = this.delegate100_2;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate100 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate100 @delegate = this.delegate100_3;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate100 @delegate = this.delegate100_3;
				Class230.Delegate100 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate100 value2 = (Class230.Delegate100)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate100>(ref this.delegate100_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class243 class243_0)
		{
			base.Rows.Add(class243_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class243 method_1()
		{
			Class230.Class243 @class = (Class230.Class243)base.NewRow();
			object[] itemArray = new object[0];
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class231 @class = (Class230.Class231)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class231();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class243 method_4()
		{
			return (Class230.Class243)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class243(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class243);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate100_1 != null)
			{
				this.delegate100_1(this, new Class230.EventArgs96((Class230.Class243)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate100_0 != null)
			{
				this.delegate100_0(this, new Class230.EventArgs96((Class230.Class243)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate100_3 != null)
			{
				this.delegate100_3(this, new Class230.EventArgs96((Class230.Class243)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate100_2 != null)
			{
				this.delegate100_2(this, new Class230.EventArgs96((Class230.Class243)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class230.Class243 class243_0)
		{
			base.Rows.Remove(class243_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "dtAbonentDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate100 delegate100_0;

		[CompilerGenerated]
		private Class230.Delegate100 delegate100_1;

		[CompilerGenerated]
		private Class230.Delegate100 delegate100_2;

		[CompilerGenerated]
		private Class230.Delegate100 delegate100_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class232 : TypedTableBase<Class230.Class244>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class232()
		{
			
			
			base.TableName = "dtAbnObj";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class232(DataTable dataTable_0)
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
		protected Class232(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class244 this[int int_0]
		{
			get
			{
				return (Class230.Class244)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate101 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate101 @delegate = this.delegate101_0;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate101 @delegate = this.delegate101_0;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate101 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate101 @delegate = this.delegate101_1;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate101 @delegate = this.delegate101_1;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate101 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate101 @delegate = this.delegate101_2;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate101 @delegate = this.delegate101_2;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate101 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate101 @delegate = this.delegate101_3;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate101 @delegate = this.delegate101_3;
				Class230.Delegate101 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate101 value2 = (Class230.Delegate101)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate101>(ref this.delegate101_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class230.Class244 class244_0)
		{
			base.Rows.Add(class244_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class244 method_1()
		{
			Class230.Class244 @class = (Class230.Class244)base.NewRow();
			object[] itemArray = new object[0];
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class232 @class = (Class230.Class232)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class232();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class244 method_4()
		{
			return (Class230.Class244)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class244(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class244);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate101_1 != null)
			{
				this.delegate101_1(this, new Class230.EventArgs97((Class230.Class244)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate101_0 != null)
			{
				this.delegate101_0(this, new Class230.EventArgs97((Class230.Class244)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate101_3 != null)
			{
				this.delegate101_3(this, new Class230.EventArgs97((Class230.Class244)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate101_2 != null)
			{
				this.delegate101_2(this, new Class230.EventArgs97((Class230.Class244)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class230.Class244 class244_0)
		{
			base.Rows.Remove(class244_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "dtAbnObjDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate101 delegate101_0;

		[CompilerGenerated]
		private Class230.Delegate101 delegate101_1;

		[CompilerGenerated]
		private Class230.Delegate101 delegate101_2;

		[CompilerGenerated]
		private Class230.Delegate101 delegate101_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class233 : TypedTableBase<Class230.Class245>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class233()
		{
			
			
			base.TableName = "dtDeviceMark";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class233(DataTable dataTable_0)
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
		protected Class233(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class245 this[int int_0]
		{
			get
			{
				return (Class230.Class245)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate102 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate102 @delegate = this.delegate102_0;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate102 @delegate = this.delegate102_0;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate102 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate102 @delegate = this.delegate102_1;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate102 @delegate = this.delegate102_1;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate102 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate102 @delegate = this.delegate102_2;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate102 @delegate = this.delegate102_2;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate102 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate102 @delegate = this.delegate102_3;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate102 @delegate = this.delegate102_3;
				Class230.Delegate102 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate102 value2 = (Class230.Delegate102)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate102>(ref this.delegate102_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class245 class245_0)
		{
			base.Rows.Add(class245_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class245 method_1()
		{
			Class230.Class245 @class = (Class230.Class245)base.NewRow();
			object[] itemArray = new object[0];
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class233 @class = (Class230.Class233)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class233();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class245 method_4()
		{
			return (Class230.Class245)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class245(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class245);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate102_1 != null)
			{
				this.delegate102_1(this, new Class230.EventArgs98((Class230.Class245)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate102_0 != null)
			{
				this.delegate102_0(this, new Class230.EventArgs98((Class230.Class245)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate102_3 != null)
			{
				this.delegate102_3(this, new Class230.EventArgs98((Class230.Class245)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate102_2 != null)
			{
				this.delegate102_2(this, new Class230.EventArgs98((Class230.Class245)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class230.Class245 class245_0)
		{
			base.Rows.Remove(class245_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "dtDeviceMarkDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate102 delegate102_0;

		[CompilerGenerated]
		private Class230.Delegate102 delegate102_1;

		[CompilerGenerated]
		private Class230.Delegate102 delegate102_2;

		[CompilerGenerated]
		private Class230.Delegate102 delegate102_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class234 : TypedTableBase<Class230.Class246>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class234()
		{
			
			
			base.TableName = "Трасформатор";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class234(DataTable dataTable_0)
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
		protected Class234(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class246 this[int int_0]
		{
			get
			{
				return (Class230.Class246)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate103 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate103 @delegate = this.delegate103_0;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate103 @delegate = this.delegate103_0;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate103 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate103 @delegate = this.delegate103_1;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate103 @delegate = this.delegate103_1;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate103 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate103 @delegate = this.delegate103_2;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate103 @delegate = this.delegate103_2;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate103 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate103 @delegate = this.delegate103_3;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate103 @delegate = this.delegate103_3;
				Class230.Delegate103 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate103 value2 = (Class230.Delegate103)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate103>(ref this.delegate103_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class246 class246_0)
		{
			base.Rows.Add(class246_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class246 method_1()
		{
			Class230.Class246 @class = (Class230.Class246)base.NewRow();
			object[] itemArray = new object[0];
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class230.Class234 @class = (Class230.Class234)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class234();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class246 method_4()
		{
			return (Class230.Class246)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class246(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class246);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate103_1 != null)
			{
				this.delegate103_1(this, new Class230.EventArgs99((Class230.Class246)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate103_0 != null)
			{
				this.delegate103_0(this, new Class230.EventArgs99((Class230.Class246)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate103_3 != null)
			{
				this.delegate103_3(this, new Class230.EventArgs99((Class230.Class246)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate103_2 != null)
			{
				this.delegate103_2(this, new Class230.EventArgs99((Class230.Class246)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class230.Class246 class246_0)
		{
			base.Rows.Remove(class246_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "ТрасформаторDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate103 delegate103_0;

		[CompilerGenerated]
		private Class230.Delegate103 delegate103_1;

		[CompilerGenerated]
		private Class230.Delegate103 delegate103_2;

		[CompilerGenerated]
		private Class230.Delegate103 delegate103_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class235 : TypedTableBase<Class230.Class247>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class235()
		{
			
			
			base.TableName = "Кабель";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class235(DataTable dataTable_0)
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
		protected Class235(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
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
		public Class230.Class247 this[int int_0]
		{
			get
			{
				return (Class230.Class247)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate104 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate104 @delegate = this.delegate104_0;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate104 @delegate = this.delegate104_0;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate104 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate104 @delegate = this.delegate104_1;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate104 @delegate = this.delegate104_1;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate104 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate104 @delegate = this.delegate104_2;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate104 @delegate = this.delegate104_2;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate104 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate104 @delegate = this.delegate104_3;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate104 @delegate = this.delegate104_3;
				Class230.Delegate104 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate104 value2 = (Class230.Delegate104)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate104>(ref this.delegate104_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class247 class247_0)
		{
			base.Rows.Add(class247_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class247 method_1()
		{
			Class230.Class247 @class = (Class230.Class247)base.NewRow();
			object[] itemArray = new object[0];
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class230.Class235 @class = (Class230.Class235)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class235();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class247 method_4()
		{
			return (Class230.Class247)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class247(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class247);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate104_1 != null)
			{
				this.delegate104_1(this, new Class230.EventArgs100((Class230.Class247)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate104_0 != null)
			{
				this.delegate104_0(this, new Class230.EventArgs100((Class230.Class247)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate104_3 != null)
			{
				this.delegate104_3(this, new Class230.EventArgs100((Class230.Class247)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate104_2 != null)
			{
				this.delegate104_2(this, new Class230.EventArgs100((Class230.Class247)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class230.Class247 class247_0)
		{
			base.Rows.Remove(class247_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "КабельDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate104 delegate104_0;

		[CompilerGenerated]
		private Class230.Delegate104 delegate104_1;

		[CompilerGenerated]
		private Class230.Delegate104 delegate104_2;

		[CompilerGenerated]
		private Class230.Delegate104 delegate104_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class236 : TypedTableBase<Class230.Class248>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class236()
		{
			
			
			base.TableName = "Журнал расчетов";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class236(DataTable dataTable_0)
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
		protected Class236(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_6;
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
		public Class230.Class248 this[int int_0]
		{
			get
			{
				return (Class230.Class248)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate105 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate105 @delegate = this.delegate105_0;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate105 @delegate = this.delegate105_0;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate105 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate105 @delegate = this.delegate105_1;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate105 @delegate = this.delegate105_1;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate105 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate105 @delegate = this.delegate105_2;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate105 @delegate = this.delegate105_2;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate105 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate105 @delegate = this.delegate105_3;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate105 @delegate = this.delegate105_3;
				Class230.Delegate105 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate105 value2 = (Class230.Delegate105)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate105>(ref this.delegate105_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class248 class248_0)
		{
			base.Rows.Add(class248_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class248 method_1(short short_0, short short_1, int int_0, bool bool_0, string string_0, DateTime dateTime_0, string string_1)
		{
			Class230.Class248 @class = (Class230.Class248)base.NewRow();
			object[] itemArray = new object[]
			{
				short_0,
				short_1,
				int_0,
				bool_0,
				string_0,
				dateTime_0,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class248 method_2(short short_0)
		{
			return (Class230.Class248)base.Rows.Find(new object[]
			{
				short_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class236 @class = (Class230.Class236)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class236();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["ROW_ID"];
			this.dataColumn_1 = base.Columns["idDocType"];
			this.dataColumn_2 = base.Columns["IdOwner"];
			this.dataColumn_3 = base.Columns["Deleted"];
			this.dataColumn_4 = base.Columns["Comment"];
			this.dataColumn_5 = base.Columns["DataDok"];
			this.dataColumn_6 = base.Columns["NumberDok"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("ROW_ID", typeof(short), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idDocType", typeof(short), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("IdOwner", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("DataDok", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("NumberDok", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AutoIncrementSeed = 1L;
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_4.MaxLength = 512;
			this.dataColumn_5.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class248 method_5()
		{
			return (Class230.Class248)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class248(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class248);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate105_1 != null)
			{
				this.delegate105_1(this, new Class230.EventArgs101((Class230.Class248)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate105_0 != null)
			{
				this.delegate105_0(this, new Class230.EventArgs101((Class230.Class248)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate105_3 != null)
			{
				this.delegate105_3(this, new Class230.EventArgs101((Class230.Class248)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate105_2 != null)
			{
				this.delegate105_2(this, new Class230.EventArgs101((Class230.Class248)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class230.Class248 class248_0)
		{
			base.Rows.Remove(class248_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "Журнал_расчетовDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate105 delegate105_0;

		[CompilerGenerated]
		private Class230.Delegate105 delegate105_1;

		[CompilerGenerated]
		private Class230.Delegate105 delegate105_2;

		[CompilerGenerated]
		private Class230.Delegate105 delegate105_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class237 : TypedTableBase<Class230.Class249>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class237()
		{
			
			
			base.TableName = "Расчет трансформатора";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class237(DataTable dataTable_0)
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
		protected Class237(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class230.Class249 this[int int_0]
		{
			get
			{
				return (Class230.Class249)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate106 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate106 @delegate = this.delegate106_0;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate106 @delegate = this.delegate106_0;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate106 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate106 @delegate = this.delegate106_1;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate106 @delegate = this.delegate106_1;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate106 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate106 @delegate = this.delegate106_2;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate106 @delegate = this.delegate106_2;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate106 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate106 @delegate = this.delegate106_3;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate106 @delegate = this.delegate106_3;
				Class230.Delegate106 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate106 value2 = (Class230.Delegate106)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate106>(ref this.delegate106_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class249 class249_0)
		{
			base.Rows.Add(class249_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class249 method_1(int int_0)
		{
			Class230.Class249 @class = (Class230.Class249)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class230.Class237 @class = (Class230.Class237)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class237();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["idTypeDevice"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("idTypeDevice", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_0.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class249 method_4()
		{
			return (Class230.Class249)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class249(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class249);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate106_1 != null)
			{
				this.delegate106_1(this, new Class230.EventArgs102((Class230.Class249)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate106_0 != null)
			{
				this.delegate106_0(this, new Class230.EventArgs102((Class230.Class249)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate106_3 != null)
			{
				this.delegate106_3(this, new Class230.EventArgs102((Class230.Class249)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate106_2 != null)
			{
				this.delegate106_2(this, new Class230.EventArgs102((Class230.Class249)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class230.Class249 class249_0)
		{
			base.Rows.Remove(class249_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "Расчет_трансформатораDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate106 delegate106_0;

		[CompilerGenerated]
		private Class230.Delegate106 delegate106_1;

		[CompilerGenerated]
		private Class230.Delegate106 delegate106_2;

		[CompilerGenerated]
		private Class230.Delegate106 delegate106_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class238 : TypedTableBase<Class230.Class250>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class238()
		{
			
			
			base.TableName = "Расчет высоковольтной линии";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class238(DataTable dataTable_0)
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
		protected Class238(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class250 this[int int_0]
		{
			get
			{
				return (Class230.Class250)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate107 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate107 @delegate = this.delegate107_0;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate107 @delegate = this.delegate107_0;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate107 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate107 @delegate = this.delegate107_1;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate107 @delegate = this.delegate107_1;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate107 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate107 @delegate = this.delegate107_2;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate107 @delegate = this.delegate107_2;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate107 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate107 @delegate = this.delegate107_3;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate107 @delegate = this.delegate107_3;
				Class230.Delegate107 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate107 value2 = (Class230.Delegate107)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate107>(ref this.delegate107_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class250 class250_0)
		{
			base.Rows.Add(class250_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class250 method_1(string string_0)
		{
			Class230.Class250 @class = (Class230.Class250)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class238 @class = (Class230.Class238)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class238();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["idTypeDevice"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("idTypeDevice", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class250 method_4()
		{
			return (Class230.Class250)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class250(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class250);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate107_1 != null)
			{
				this.delegate107_1(this, new Class230.EventArgs103((Class230.Class250)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate107_0 != null)
			{
				this.delegate107_0(this, new Class230.EventArgs103((Class230.Class250)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate107_3 != null)
			{
				this.delegate107_3(this, new Class230.EventArgs103((Class230.Class250)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate107_2 != null)
			{
				this.delegate107_2(this, new Class230.EventArgs103((Class230.Class250)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class230.Class250 class250_0)
		{
			base.Rows.Remove(class250_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "Расчет_высоковольтной_линииDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate107 delegate107_0;

		[CompilerGenerated]
		private Class230.Delegate107 delegate107_1;

		[CompilerGenerated]
		private Class230.Delegate107 delegate107_2;

		[CompilerGenerated]
		private Class230.Delegate107 delegate107_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class239 : TypedTableBase<Class230.Class251>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class239()
		{
			
			
			base.TableName = "Расчет кабельной линии";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class239(DataTable dataTable_0)
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
		protected Class239(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class230.Class251 this[int int_0]
		{
			get
			{
				return (Class230.Class251)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate108 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate108 @delegate = this.delegate108_0;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate108 @delegate = this.delegate108_0;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate108 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate108 @delegate = this.delegate108_1;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate108 @delegate = this.delegate108_1;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate108 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate108 @delegate = this.delegate108_2;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate108 @delegate = this.delegate108_2;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate108 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate108 @delegate = this.delegate108_3;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate108 @delegate = this.delegate108_3;
				Class230.Delegate108 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate108 value2 = (Class230.Delegate108)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate108>(ref this.delegate108_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class251 class251_0)
		{
			base.Rows.Add(class251_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class251 method_1(string string_0)
		{
			Class230.Class251 @class = (Class230.Class251)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class230.Class239 @class = (Class230.Class239)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class239();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["idTypeDevice"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("idTypeDevice", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class251 method_4()
		{
			return (Class230.Class251)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class251(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class251);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate108_1 != null)
			{
				this.delegate108_1(this, new Class230.EventArgs104((Class230.Class251)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate108_0 != null)
			{
				this.delegate108_0(this, new Class230.EventArgs104((Class230.Class251)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate108_3 != null)
			{
				this.delegate108_3(this, new Class230.EventArgs104((Class230.Class251)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate108_2 != null)
			{
				this.delegate108_2(this, new Class230.EventArgs104((Class230.Class251)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class230.Class251 class251_0)
		{
			base.Rows.Remove(class251_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "Расчет_кабельной_линииDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate108 delegate108_0;

		[CompilerGenerated]
		private Class230.Delegate108 delegate108_1;

		[CompilerGenerated]
		private Class230.Delegate108 delegate108_2;

		[CompilerGenerated]
		private Class230.Delegate108 delegate108_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class240 : TypedTableBase<Class230.Class252>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class240()
		{
			
			
			base.TableName = "Классификатор";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class240(DataTable dataTable_0)
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
		protected Class240(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
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
		public Class230.Class252 this[int int_0]
		{
			get
			{
				return (Class230.Class252)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate109 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate109 @delegate = this.delegate109_0;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate109 @delegate = this.delegate109_0;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate109 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate109 @delegate = this.delegate109_1;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate109 @delegate = this.delegate109_1;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate109 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate109 @delegate = this.delegate109_2;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate109 @delegate = this.delegate109_2;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate109 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate109 @delegate = this.delegate109_3;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate109 @delegate = this.delegate109_3;
				Class230.Delegate109 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate109 value2 = (Class230.Delegate109)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate109>(ref this.delegate109_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class252 class252_0)
		{
			base.Rows.Add(class252_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class252 method_1()
		{
			Class230.Class252 @class = (Class230.Class252)base.NewRow();
			object[] itemArray = new object[0];
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class240 @class = (Class230.Class240)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class240();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class252 method_4()
		{
			return (Class230.Class252)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class252(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class252);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate109_1 != null)
			{
				this.delegate109_1(this, new Class230.EventArgs105((Class230.Class252)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate109_0 != null)
			{
				this.delegate109_0(this, new Class230.EventArgs105((Class230.Class252)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate109_3 != null)
			{
				this.delegate109_3(this, new Class230.EventArgs105((Class230.Class252)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate109_2 != null)
			{
				this.delegate109_2(this, new Class230.EventArgs105((Class230.Class252)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class230.Class252 class252_0)
		{
			base.Rows.Remove(class252_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "КлассификаторDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate109 delegate109_0;

		[CompilerGenerated]
		private Class230.Delegate109 delegate109_1;

		[CompilerGenerated]
		private Class230.Delegate109 delegate109_2;

		[CompilerGenerated]
		private Class230.Delegate109 delegate109_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class241 : TypedTableBase<Class230.Class253>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class241()
		{
			
			
			base.TableName = "dtAbnObjDevice";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class241(DataTable dataTable_0)
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
		protected Class241(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
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
		public Class230.Class253 this[int int_0]
		{
			get
			{
				return (Class230.Class253)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate110 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate110 @delegate = this.delegate110_0;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate110 @delegate = this.delegate110_0;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate110 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate110 @delegate = this.delegate110_1;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate110 @delegate = this.delegate110_1;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate110 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate110 @delegate = this.delegate110_2;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate110 @delegate = this.delegate110_2;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate110 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate110 @delegate = this.delegate110_3;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate110 @delegate = this.delegate110_3;
				Class230.Delegate110 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate110 value2 = (Class230.Delegate110)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate110>(ref this.delegate110_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class230.Class253 class253_0)
		{
			base.Rows.Add(class253_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class253 method_1()
		{
			Class230.Class253 @class = (Class230.Class253)base.NewRow();
			object[] itemArray = new object[0];
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class241 @class = (Class230.Class241)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class241();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class253 method_4()
		{
			return (Class230.Class253)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class253(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class253);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate110_1 != null)
			{
				this.delegate110_1(this, new Class230.EventArgs106((Class230.Class253)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate110_0 != null)
			{
				this.delegate110_0(this, new Class230.EventArgs106((Class230.Class253)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate110_3 != null)
			{
				this.delegate110_3(this, new Class230.EventArgs106((Class230.Class253)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate110_2 != null)
			{
				this.delegate110_2(this, new Class230.EventArgs106((Class230.Class253)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class230.Class253 class253_0)
		{
			base.Rows.Remove(class253_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "dtAbnObjDeviceDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate110 delegate110_0;

		[CompilerGenerated]
		private Class230.Delegate110 delegate110_1;

		[CompilerGenerated]
		private Class230.Delegate110 delegate110_2;

		[CompilerGenerated]
		private Class230.Delegate110 delegate110_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class242 : TypedTableBase<Class230.Class254>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class242()
		{
			
			
			base.TableName = "Предопределенные значения колонок";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class242(DataTable dataTable_0)
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
		protected Class242(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		[Browsable(false)]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class254 this[int int_0]
		{
			get
			{
				return (Class230.Class254)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate111 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate111 @delegate = this.delegate111_0;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate111 @delegate = this.delegate111_0;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate111 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate111 @delegate = this.delegate111_1;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate111 @delegate = this.delegate111_1;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate111 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate111 @delegate = this.delegate111_2;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate111 @delegate = this.delegate111_2;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class230.Delegate111 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class230.Delegate111 @delegate = this.delegate111_3;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class230.Delegate111 @delegate = this.delegate111_3;
				Class230.Delegate111 delegate2;
				do
				{
					delegate2 = @delegate;
					Class230.Delegate111 value2 = (Class230.Delegate111)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class230.Delegate111>(ref this.delegate111_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class230.Class254 class254_0)
		{
			base.Rows.Add(class254_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class254 method_1(bool bool_0)
		{
			Class230.Class254 @class = (Class230.Class254)base.NewRow();
			object[] itemArray = new object[]
			{
				bool_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class230.Class242 @class = (Class230.Class242)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class230.Class242();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Description"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Description", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_0.AllowDBNull = false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class254 method_4()
		{
			return (Class230.Class254)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class230.Class254(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class230.Class254);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate111_1 != null)
			{
				this.delegate111_1(this, new Class230.EventArgs107((Class230.Class254)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate111_0 != null)
			{
				this.delegate111_0(this, new Class230.EventArgs107((Class230.Class254)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate111_3 != null)
			{
				this.delegate111_3(this, new Class230.EventArgs107((Class230.Class254)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate111_2 != null)
			{
				this.delegate111_2(this, new Class230.EventArgs107((Class230.Class254)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class230.Class254 class254_0)
		{
			base.Rows.Remove(class254_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class230 @class = new Class230();
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
			xmlSchemaAttribute2.FixedValue = "Предопределенные_значения_колонокDataTable";
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

		[CompilerGenerated]
		private Class230.Delegate111 delegate111_0;

		[CompilerGenerated]
		private Class230.Delegate111 delegate111_1;

		[CompilerGenerated]
		private Class230.Delegate111 delegate111_2;

		[CompilerGenerated]
		private Class230.Delegate111 delegate111_3;
	}

	public class Class243 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class243(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class231_0 = (Class230.Class231)base.Table;
		}

		private Class230.Class231 class231_0;
	}

	public class Class244 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class244(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class232_0 = (Class230.Class232)base.Table;
		}

		private Class230.Class232 class232_0;
	}

	public class Class245 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class245(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class233_0 = (Class230.Class233)base.Table;
		}

		private Class230.Class233 class233_0;
	}

	public class Class246 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class246(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class234_0 = (Class230.Class234)base.Table;
		}

		private Class230.Class234 class234_0;
	}

	public class Class247 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class247(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class235_0 = (Class230.Class235)base.Table;
		}

		private Class230.Class235 class235_0;
	}

	public class Class248 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class248(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class236_0 = (Class230.Class236)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public short ROW_ID
		{
			get
			{
				return (short)base[this.class236_0.DataColumn_0];
			}
			set
			{
				base[this.class236_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public short idDocType
		{
			get
			{
				return (short)base[this.class236_0.DataColumn_1];
			}
			set
			{
				base[this.class236_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int IdOwner
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class236_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IdOwner' in table 'Журнал расчетов' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class236_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class236_0.DataColumn_3];
			}
			set
			{
				base[this.class236_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Comment
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class236_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'Журнал расчетов' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class236_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DataDok
		{
			get
			{
				return (DateTime)base[this.class236_0.DataColumn_5];
			}
			set
			{
				base[this.class236_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NumberDok
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class236_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NumberDok' in table 'Журнал расчетов' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class236_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class236_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class236_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class236_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class236_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class236_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class236_0.DataColumn_6] = Convert.DBNull;
		}

		private Class230.Class236 class236_0;
	}

	public class Class249 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class249(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class237_0 = (Class230.Class237)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idTypeDevice
		{
			get
			{
				return (int)base[this.class237_0.DataColumn_0];
			}
			set
			{
				base[this.class237_0.DataColumn_0] = value;
			}
		}

		private Class230.Class237 class237_0;
	}

	public class Class250 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class250(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class238_0 = (Class230.Class238)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string idTypeDevice
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class238_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idTypeDevice' in table 'Расчет высоковольтной линии' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class238_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class238_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class238_0.DataColumn_0] = Convert.DBNull;
		}

		private Class230.Class238 class238_0;
	}

	public class Class251 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class251(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class239_0 = (Class230.Class239)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string idTypeDevice
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class239_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idTypeDevice' in table 'Расчет кабельной линии' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class239_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class239_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class239_0.DataColumn_0] = Convert.DBNull;
		}

		private Class230.Class239 class239_0;
	}

	public class Class252 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class252(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class240_0 = (Class230.Class240)base.Table;
		}

		private Class230.Class240 class240_0;
	}

	public class Class253 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class253(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class241_0 = (Class230.Class241)base.Table;
		}

		private Class230.Class241 class241_0;
	}

	public class Class254 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class254(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class242_0 = (Class230.Class242)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Description
		{
			get
			{
				return (bool)base[this.class242_0.DataColumn_0];
			}
			set
			{
				base[this.class242_0.DataColumn_0] = value;
			}
		}

		private Class230.Class242 class242_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs96 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs96(Class230.Class243 class243_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class243_0 = class243_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class243 Row
		{
			get
			{
				return this.class243_0;
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

		private Class230.Class243 class243_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs97 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs97(Class230.Class244 class244_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class244_0 = class244_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class244 Row
		{
			get
			{
				return this.class244_0;
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

		private Class230.Class244 class244_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs98 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs98(Class230.Class245 class245_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class245_0 = class245_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class245 Row
		{
			get
			{
				return this.class245_0;
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

		private Class230.Class245 class245_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs99 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs99(Class230.Class246 class246_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class246_0 = class246_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class246 Row
		{
			get
			{
				return this.class246_0;
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

		private Class230.Class246 class246_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs100 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs100(Class230.Class247 class247_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class247_0 = class247_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class247 Row
		{
			get
			{
				return this.class247_0;
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

		private Class230.Class247 class247_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs101 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs101(Class230.Class248 class248_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class248_0 = class248_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class248 Row
		{
			get
			{
				return this.class248_0;
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

		private Class230.Class248 class248_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs102 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs102(Class230.Class249 class249_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class249_0 = class249_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class249 Row
		{
			get
			{
				return this.class249_0;
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

		private Class230.Class249 class249_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs103 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs103(Class230.Class250 class250_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class250_0 = class250_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class230.Class250 Row
		{
			get
			{
				return this.class250_0;
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

		private Class230.Class250 class250_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs104 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs104(Class230.Class251 class251_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class251_0 = class251_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class251 Row
		{
			get
			{
				return this.class251_0;
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

		private Class230.Class251 class251_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs105 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs105(Class230.Class252 class252_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class252_0 = class252_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class252 Row
		{
			get
			{
				return this.class252_0;
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

		private Class230.Class252 class252_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs106 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs106(Class230.Class253 class253_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class253_0 = class253_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class253 Row
		{
			get
			{
				return this.class253_0;
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

		private Class230.Class253 class253_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs107 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs107(Class230.Class254 class254_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class254_0 = class254_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class230.Class254 Row
		{
			get
			{
				return this.class254_0;
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

		private Class230.Class254 class254_0;

		private DataRowAction dataRowAction_0;
	}
}
