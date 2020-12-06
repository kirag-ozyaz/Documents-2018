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
[XmlRoot("DataSetGES")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[Serializable]
internal class Class3 : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class3()
	{
		Class38.TqlX7ZmzmDDi2();
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		
		base.BeginInit();
		this.method_2();
		CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_16);
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		base.EndInit();
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected Class3(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
	{
		Class38.TqlX7ZmzmDDi2();
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		base..ctor(serializationInfo_0, streamingContext_0, false);
		if (base.IsBinarySerialized(serializationInfo_0, streamingContext_0))
		{
			this.method_1(false);
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_16);
			this.DataTableCollection_0.CollectionChanged += value;
			this.DataRelationCollection_0.CollectionChanged += value;
			return;
		}
		string s = (string)serializationInfo_0.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(serializationInfo_0, streamingContext_0) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["tR_Classifier"] != null)
			{
				base.Tables.Add(new Class3.Class4(dataSet.Tables["tR_Classifier"]));
			}
			if (dataSet.Tables["vSchm_ObjList"] != null)
			{
				base.Tables.Add(new Class3.Class5(dataSet.Tables["vSchm_ObjList"]));
			}
			if (dataSet.Tables["vSchm_TreeCellLine"] != null)
			{
				base.Tables.Add(new Class3.Class6(dataSet.Tables["vSchm_TreeCellLine"]));
			}
			if (dataSet.Tables["tSchm_Relation"] != null)
			{
				base.Tables.Add(new Class3.Class7(dataSet.Tables["tSchm_Relation"]));
			}
			if (dataSet.Tables["tL_RequestForRepairSchmObjList"] != null)
			{
				base.Tables.Add(new Class3.Class8(dataSet.Tables["tL_RequestForRepairSchmObjList"]));
			}
			if (dataSet.Tables["tJ_RequestForRepair"] != null)
			{
				base.Tables.Add(new Class3.Class9(dataSet.Tables["tJ_RequestForRepair"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairDaily"] != null)
			{
				base.Tables.Add(new Class3.Class10(dataSet.Tables["tJ_RequestForRepairDaily"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairDoc"] != null)
			{
				base.Tables.Add(new Class3.Class11(dataSet.Tables["tJ_RequestForRepairDoc"]));
			}
			if (dataSet.Tables["tR_RequestForRepairClient"] != null)
			{
				base.Tables.Add(new Class3.Class12(dataSet.Tables["tR_RequestForRepairClient"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairAddress"] != null)
			{
				base.Tables.Add(new Class3.Class13(dataSet.Tables["tJ_RequestForRepairAddress"]));
			}
			if (dataSet.Tables["tJ_Damage"] != null)
			{
				base.Tables.Add(new Class3.Class14(dataSet.Tables["tJ_Damage"]));
			}
			if (dataSet.Tables["tJ_DamageHV"] != null)
			{
				base.Tables.Add(new Class3.Class15(dataSet.Tables["tJ_DamageHV"]));
			}
			if (dataSet.Tables["tJ_DamageLV"] != null)
			{
				base.Tables.Add(new Class3.Class16(dataSet.Tables["tJ_DamageLV"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairLog"] != null)
			{
				base.Tables.Add(new Class3.Class17(dataSet.Tables["tJ_RequestForRepairLog"]));
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
		CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_16);
		base.Tables.CollectionChanged += value2;
		this.DataRelationCollection_0.CollectionChanged += value2;
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public Class3.Class4 tR_Classifier
	{
		get
		{
			return this.class4_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public Class3.Class5 vSchm_ObjList
	{
		get
		{
			return this.class5_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class3.Class6 vSchm_TreeCellLine
	{
		get
		{
			return this.class6_0;
		}
	}

	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class3.Class7 tSchm_Relation
	{
		get
		{
			return this.class7_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class3.Class8 tL_RequestForRepairSchmObjList
	{
		get
		{
			return this.class8_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class3.Class9 tJ_RequestForRepair
	{
		get
		{
			return this.class9_0;
		}
	}

	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class3.Class10 tJ_RequestForRepairDaily
	{
		get
		{
			return this.class10_0;
		}
	}

	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class3.Class11 tJ_RequestForRepairDoc
	{
		get
		{
			return this.class11_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class3.Class12 tR_RequestForRepairClient
	{
		get
		{
			return this.class12_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class3.Class13 tJ_RequestForRepairAddress
	{
		get
		{
			return this.class13_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public Class3.Class14 tJ_Damage
	{
		get
		{
			return this.class14_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class3.Class15 tJ_DamageHV
	{
		get
		{
			return this.class15_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class3.Class16 tJ_DamageLV
	{
		get
		{
			return this.class16_0;
		}
	}

	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class3.Class17 tJ_RequestForRepairLog
	{
		get
		{
			return this.class17_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public override DataSet Clone()
	{
		Class3 @class = (Class3)base.Clone();
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
			if (dataSet.Tables["tR_Classifier"] != null)
			{
				base.Tables.Add(new Class3.Class4(dataSet.Tables["tR_Classifier"]));
			}
			if (dataSet.Tables["vSchm_ObjList"] != null)
			{
				base.Tables.Add(new Class3.Class5(dataSet.Tables["vSchm_ObjList"]));
			}
			if (dataSet.Tables["vSchm_TreeCellLine"] != null)
			{
				base.Tables.Add(new Class3.Class6(dataSet.Tables["vSchm_TreeCellLine"]));
			}
			if (dataSet.Tables["tSchm_Relation"] != null)
			{
				base.Tables.Add(new Class3.Class7(dataSet.Tables["tSchm_Relation"]));
			}
			if (dataSet.Tables["tL_RequestForRepairSchmObjList"] != null)
			{
				base.Tables.Add(new Class3.Class8(dataSet.Tables["tL_RequestForRepairSchmObjList"]));
			}
			if (dataSet.Tables["tJ_RequestForRepair"] != null)
			{
				base.Tables.Add(new Class3.Class9(dataSet.Tables["tJ_RequestForRepair"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairDaily"] != null)
			{
				base.Tables.Add(new Class3.Class10(dataSet.Tables["tJ_RequestForRepairDaily"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairDoc"] != null)
			{
				base.Tables.Add(new Class3.Class11(dataSet.Tables["tJ_RequestForRepairDoc"]));
			}
			if (dataSet.Tables["tR_RequestForRepairClient"] != null)
			{
				base.Tables.Add(new Class3.Class12(dataSet.Tables["tR_RequestForRepairClient"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairAddress"] != null)
			{
				base.Tables.Add(new Class3.Class13(dataSet.Tables["tJ_RequestForRepairAddress"]));
			}
			if (dataSet.Tables["tJ_Damage"] != null)
			{
				base.Tables.Add(new Class3.Class14(dataSet.Tables["tJ_Damage"]));
			}
			if (dataSet.Tables["tJ_DamageHV"] != null)
			{
				base.Tables.Add(new Class3.Class15(dataSet.Tables["tJ_DamageHV"]));
			}
			if (dataSet.Tables["tJ_DamageLV"] != null)
			{
				base.Tables.Add(new Class3.Class16(dataSet.Tables["tJ_DamageLV"]));
			}
			if (dataSet.Tables["tJ_RequestForRepairLog"] != null)
			{
				base.Tables.Add(new Class3.Class17(dataSet.Tables["tJ_RequestForRepairLog"]));
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
		this.class4_0 = (Class3.Class4)base.Tables["tR_Classifier"];
		if (bool_0 && this.class4_0 != null)
		{
			this.class4_0.method_3();
		}
		this.class5_0 = (Class3.Class5)base.Tables["vSchm_ObjList"];
		if (bool_0 && this.class5_0 != null)
		{
			this.class5_0.method_3();
		}
		this.class6_0 = (Class3.Class6)base.Tables["vSchm_TreeCellLine"];
		if (bool_0 && this.class6_0 != null)
		{
			this.class6_0.method_2();
		}
		this.class7_0 = (Class3.Class7)base.Tables["tSchm_Relation"];
		if (bool_0 && this.class7_0 != null)
		{
			this.class7_0.method_3();
		}
		this.class8_0 = (Class3.Class8)base.Tables["tL_RequestForRepairSchmObjList"];
		if (bool_0 && this.class8_0 != null)
		{
			this.class8_0.method_3();
		}
		this.class9_0 = (Class3.Class9)base.Tables["tJ_RequestForRepair"];
		if (bool_0 && this.class9_0 != null)
		{
			this.class9_0.method_3();
		}
		this.class10_0 = (Class3.Class10)base.Tables["tJ_RequestForRepairDaily"];
		if (bool_0 && this.class10_0 != null)
		{
			this.class10_0.method_3();
		}
		this.class11_0 = (Class3.Class11)base.Tables["tJ_RequestForRepairDoc"];
		if (bool_0 && this.class11_0 != null)
		{
			this.class11_0.method_3();
		}
		this.class12_0 = (Class3.Class12)base.Tables["tR_RequestForRepairClient"];
		if (bool_0 && this.class12_0 != null)
		{
			this.class12_0.method_3();
		}
		this.class13_0 = (Class3.Class13)base.Tables["tJ_RequestForRepairAddress"];
		if (bool_0 && this.class13_0 != null)
		{
			this.class13_0.method_2();
		}
		this.class14_0 = (Class3.Class14)base.Tables["tJ_Damage"];
		if (bool_0 && this.class14_0 != null)
		{
			this.class14_0.method_3();
		}
		this.class15_0 = (Class3.Class15)base.Tables["tJ_DamageHV"];
		if (bool_0 && this.class15_0 != null)
		{
			this.class15_0.method_3();
		}
		this.class16_0 = (Class3.Class16)base.Tables["tJ_DamageLV"];
		if (bool_0 && this.class16_0 != null)
		{
			this.class16_0.method_3();
		}
		this.class17_0 = (Class3.Class17)base.Tables["tJ_RequestForRepairLog"];
		if (bool_0 && this.class17_0 != null)
		{
			this.class17_0.method_3();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_2()
	{
		base.DataSetName = "DataSetGES";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/DataSetGES.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class4_0 = new Class3.Class4();
		base.Tables.Add(this.class4_0);
		this.class5_0 = new Class3.Class5();
		base.Tables.Add(this.class5_0);
		this.class6_0 = new Class3.Class6();
		base.Tables.Add(this.class6_0);
		this.class7_0 = new Class3.Class7();
		base.Tables.Add(this.class7_0);
		this.class8_0 = new Class3.Class8();
		base.Tables.Add(this.class8_0);
		this.class9_0 = new Class3.Class9();
		base.Tables.Add(this.class9_0);
		this.class10_0 = new Class3.Class10();
		base.Tables.Add(this.class10_0);
		this.class11_0 = new Class3.Class11();
		base.Tables.Add(this.class11_0);
		this.class12_0 = new Class3.Class12();
		base.Tables.Add(this.class12_0);
		this.class13_0 = new Class3.Class13();
		base.Tables.Add(this.class13_0);
		this.class14_0 = new Class3.Class14();
		base.Tables.Add(this.class14_0);
		this.class15_0 = new Class3.Class15();
		base.Tables.Add(this.class15_0);
		this.class16_0 = new Class3.Class16();
		base.Tables.Add(this.class16_0);
		this.class17_0 = new Class3.Class17();
		base.Tables.Add(this.class17_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_3()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool zmlMeDyxhg()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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
	private bool method_15()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_16(object sender, CollectionChangeEventArgs e)
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
		Class3 @class = new Class3();
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

	private Class3.Class4 class4_0;

	private Class3.Class5 class5_0;

	private Class3.Class6 class6_0;

	private Class3.Class7 class7_0;

	private Class3.Class8 class8_0;

	private Class3.Class9 class9_0;

	private Class3.Class10 class10_0;

	private Class3.Class11 class11_0;

	private Class3.Class12 class12_0;

	private Class3.Class13 class13_0;

	private Class3.Class14 class14_0;

	private Class3.Class15 class15_0;

	private Class3.Class16 class16_0;

	private Class3.Class17 class17_0;

	private SchemaSerializationMode schemaSerializationMode_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate0(object sender, Class3.EventArgs0 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate1(object sender, Class3.EventArgs1 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate2(object sender, Class3.EventArgs2 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate3(object sender, Class3.EventArgs3 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate4(object sender, Class3.EventArgs4 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate5(object sender, Class3.EventArgs5 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate6(object sender, Class3.EventArgs6 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate7(object sender, Class3.EventArgs7 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate8(object sender, Class3.EventArgs8 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate9(object sender, Class3.EventArgs9 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate10(object sender, Class3.EventArgs10 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate11(object sender, Class3.EventArgs11 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate12(object sender, Class3.EventArgs12 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate13(object sender, Class3.EventArgs13 e);

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class4 : TypedTableBase<Class3.Class18>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class4()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tR_Classifier";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class4(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class4(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		[Browsable(false)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class18 this[int int_0]
		{
			get
			{
				return (Class3.Class18)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate0 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate0 @delegate = this.delegate0_0;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate0 @delegate = this.delegate0_0;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate0 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate0 @delegate = this.delegate0_1;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate0 @delegate = this.delegate0_1;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate0 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate0 @delegate = this.delegate0_2;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate0 @delegate = this.delegate0_2;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate0 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate0 @delegate = this.delegate0_3;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate0 @delegate = this.delegate0_3;
				Class3.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate0 value2 = (Class3.Delegate0)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate0>(ref this.delegate0_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class18 class18_0)
		{
			base.Rows.Add(class18_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class18 method_1(string string_0, string string_1, decimal decimal_0, string string_2, int int_0, string string_3, byte[] byte_0, bool bool_0, bool bool_1)
		{
			Class3.Class18 @class = (Class3.Class18)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				string_0,
				string_1,
				decimal_0,
				string_2,
				int_0,
				string_3,
				byte_0,
				bool_0,
				bool_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class18 method_2(int int_0)
		{
			return (Class3.Class18)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class4 @class = (Class3.Class4)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class4();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["Name"];
			this.dataColumn_2 = base.Columns["SocrName"];
			this.dataColumn_3 = base.Columns["Value"];
			this.dataColumn_4 = base.Columns["Comment"];
			this.dataColumn_5 = base.Columns["ParentId"];
			this.dataColumn_6 = base.Columns["ParentKey"];
			this.dataColumn_7 = base.Columns["OtherId"];
			this.dataColumn_8 = base.Columns["IsGroup"];
			this.dataColumn_9 = base.Columns["Deleted"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("SocrName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Value", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("ParentId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("ParentKey", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("OtherId", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("IsGroup", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
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
			this.dataColumn_1.MaxLength = 100;
			this.dataColumn_2.MaxLength = 50;
			this.dataColumn_4.MaxLength = 1024;
			this.dataColumn_6.MaxLength = 50;
			this.dataColumn_8.AllowDBNull = false;
			this.dataColumn_9.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class18 method_5()
		{
			return (Class3.Class18)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class18(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class18);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate0_1 != null)
			{
				this.delegate0_1(this, new Class3.EventArgs0((Class3.Class18)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate0_0 != null)
			{
				this.delegate0_0(this, new Class3.EventArgs0((Class3.Class18)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate0_3 != null)
			{
				this.delegate0_3(this, new Class3.EventArgs0((Class3.Class18)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate0_2 != null)
			{
				this.delegate0_2(this, new Class3.EventArgs0((Class3.Class18)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class18 class18_0)
		{
			base.Rows.Remove(class18_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tR_ClassifierDataTable";
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

		[CompilerGenerated]
		private Class3.Delegate0 delegate0_0;

		[CompilerGenerated]
		private Class3.Delegate0 delegate0_1;

		[CompilerGenerated]
		private Class3.Delegate0 delegate0_2;

		[CompilerGenerated]
		private Class3.Delegate0 delegate0_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class5 : TypedTableBase<Class3.Class19>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class5()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "vSchm_ObjList";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class5(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class5(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class19 this[int int_0]
		{
			get
			{
				return (Class3.Class19)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate1 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate1 @delegate = this.delegate1_0;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate1 @delegate = this.delegate1_0;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate1 fSoCukHxeS
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate1 @delegate = this.delegate1_1;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate1 @delegate = this.delegate1_1;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate1 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate1 @delegate = this.delegate1_2;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate1 @delegate = this.delegate1_2;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate1 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate1 @delegate = this.delegate1_3;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate1 @delegate = this.delegate1_3;
				Class3.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate1 value2 = (Class3.Delegate1)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate1>(ref this.delegate1_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class19 class19_0)
		{
			base.Rows.Add(class19_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class19 method_1(int int_0, string string_0, int int_1, string string_1, string string_2, int int_2, bool bool_0, int int_3, bool bool_1)
		{
			Class3.Class19 @class = (Class3.Class19)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				int_1,
				string_1,
				string_2,
				int_2,
				bool_0,
				int_3,
				bool_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class19 method_2(int int_0)
		{
			return (Class3.Class19)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class3.Class5 @class = (Class3.Class5)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class5();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["Name"];
			this.dataColumn_2 = base.Columns["TypeCodeId"];
			this.dataColumn_3 = base.Columns["typecode"];
			this.dataColumn_4 = base.Columns["typeCodeSocr"];
			this.dataColumn_5 = base.Columns["IdParent"];
			this.dataColumn_6 = base.Columns["OnOff"];
			this.dataColumn_7 = base.Columns["NameP"];
			this.dataColumn_8 = base.Columns["Deleted"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("TypeCodeId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("typecode", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("typeCodeSocr", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("IdParent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("OnOff", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("NameP", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.MaxLength = 512;
			this.dataColumn_3.MaxLength = 100;
			this.dataColumn_4.MaxLength = 50;
			this.dataColumn_7.ReadOnly = true;
			this.dataColumn_8.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class19 method_5()
		{
			return (Class3.Class19)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class19(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class19);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate1_1 != null)
			{
				this.delegate1_1(this, new Class3.EventArgs1((Class3.Class19)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate1_0 != null)
			{
				this.delegate1_0(this, new Class3.EventArgs1((Class3.Class19)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate1_3 != null)
			{
				this.delegate1_3(this, new Class3.EventArgs1((Class3.Class19)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate1_2 != null)
			{
				this.delegate1_2(this, new Class3.EventArgs1((Class3.Class19)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class19 class19_0)
		{
			base.Rows.Remove(class19_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "vSchm_ObjListDataTable";
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

		[CompilerGenerated]
		private Class3.Delegate1 delegate1_0;

		[CompilerGenerated]
		private Class3.Delegate1 delegate1_1;

		[CompilerGenerated]
		private Class3.Delegate1 delegate1_2;

		[CompilerGenerated]
		private Class3.Delegate1 delegate1_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class6 : TypedTableBase<Class3.Class20>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class6()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "vSchm_TreeCellLine";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class6(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class6(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
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

		[Browsable(false)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class20 this[int int_0]
		{
			get
			{
				return (Class3.Class20)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate2 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate2 @delegate = this.delegate2_0;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate2 @delegate = this.delegate2_0;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate2 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate2 @delegate = this.delegate2_1;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate2 @delegate = this.delegate2_1;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate2 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate2 @delegate = this.delegate2_2;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate2 @delegate = this.delegate2_2;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate2 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate2 @delegate = this.delegate2_3;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate2 @delegate = this.delegate2_3;
				Class3.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate2 value2 = (Class3.Delegate2)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate2>(ref this.delegate2_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class3.Class20 class20_0)
		{
			base.Rows.Add(class20_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class20 method_1(int int_0, int int_1, int int_2, string string_0, string string_1, string string_2)
		{
			Class3.Class20 @class = (Class3.Class20)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				string_0,
				string_1,
				string_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class3.Class6 @class = (Class3.Class6)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class6();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["ParentLink"];
			this.dataColumn_2 = base.Columns["TypeCodeId"];
			this.dataColumn_3 = base.Columns["ParentKey"];
			this.dataColumn_4 = base.Columns["Name"];
			this.dataColumn_5 = base.Columns["FullName"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("ParentLink", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("TypeCodeId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("ParentKey", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("FullName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 50;
			this.dataColumn_4.MaxLength = 512;
			this.dataColumn_5.ReadOnly = true;
			this.dataColumn_5.MaxLength = 565;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class20 method_4()
		{
			return (Class3.Class20)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class20(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class20);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate2_1 != null)
			{
				this.delegate2_1(this, new Class3.EventArgs2((Class3.Class20)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate2_0 != null)
			{
				this.delegate2_0(this, new Class3.EventArgs2((Class3.Class20)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate2_3 != null)
			{
				this.delegate2_3(this, new Class3.EventArgs2((Class3.Class20)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate2_2 != null)
			{
				this.delegate2_2(this, new Class3.EventArgs2((Class3.Class20)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class3.Class20 class20_0)
		{
			base.Rows.Remove(class20_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "vSchm_TreeCellLineDataTable";
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
		private Class3.Delegate2 delegate2_0;

		[CompilerGenerated]
		private Class3.Delegate2 delegate2_1;

		[CompilerGenerated]
		private Class3.Delegate2 delegate2_2;

		[CompilerGenerated]
		private Class3.Delegate2 delegate2_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class7 : TypedTableBase<Class3.Class21>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class7()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tSchm_Relation";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class7(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class7(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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

		[Browsable(false)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class21 this[int int_0]
		{
			get
			{
				return (Class3.Class21)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate3 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate3 @delegate = this.delegate3_0;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate3 @delegate = this.delegate3_0;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate3 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate3 @delegate = this.delegate3_1;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate3 @delegate = this.delegate3_1;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate3 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate3 @delegate = this.delegate3_2;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate3 @delegate = this.delegate3_2;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate3 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate3 @delegate = this.delegate3_3;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate3 @delegate = this.delegate3_3;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class3.Class21 class21_0)
		{
			base.Rows.Add(class21_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class21 method_1(int int_0, int int_1, int int_2)
		{
			Class3.Class21 @class = (Class3.Class21)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				int_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class21 method_2(int int_0)
		{
			return (Class3.Class21)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class7 @class = (Class3.Class7)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class7();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["SourceObj"];
			this.dataColumn_2 = base.Columns["DestObj"];
			this.dataColumn_3 = base.Columns["Edge"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("SourceObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("DestObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Edge", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
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
			this.dataColumn_2.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class21 method_5()
		{
			return (Class3.Class21)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class21(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class21);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate3_1 != null)
			{
				this.delegate3_1(this, new Class3.EventArgs3((Class3.Class21)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate3_0 != null)
			{
				this.delegate3_0(this, new Class3.EventArgs3((Class3.Class21)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate3_3 != null)
			{
				this.delegate3_3(this, new Class3.EventArgs3((Class3.Class21)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate3_2 != null)
			{
				this.delegate3_2(this, new Class3.EventArgs3((Class3.Class21)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class21 class21_0)
		{
			base.Rows.Remove(class21_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tSchm_RelationDataTable";
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

		[CompilerGenerated]
		private Class3.Delegate3 delegate3_0;

		[CompilerGenerated]
		private Class3.Delegate3 delegate3_1;

		[CompilerGenerated]
		private Class3.Delegate3 delegate3_2;

		[CompilerGenerated]
		private Class3.Delegate3 delegate3_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class8 : TypedTableBase<Class3.Class22>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class8()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tL_RequestForRepairSchmObjList";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class8(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class8(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class22 this[int int_0]
		{
			get
			{
				return (Class3.Class22)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate4 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate4 @delegate = this.delegate4_0;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate4 @delegate = this.delegate4_0;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate4 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate4 @delegate = this.delegate4_1;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate4 @delegate = this.delegate4_1;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate4 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate4 @delegate = this.delegate4_2;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate4 @delegate = this.delegate4_2;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate4 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate4 @delegate = this.delegate4_3;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate4 @delegate = this.delegate4_3;
				Class3.Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate4 value2 = (Class3.Delegate4)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate4>(ref this.delegate4_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class22 class22_0)
		{
			base.Rows.Add(class22_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class22 method_1(int int_0, int int_1, DateTime dateTime_0, DateTime dateTime_1, string string_0, short short_0)
		{
			Class3.Class22 @class = (Class3.Class22)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				dateTime_0,
				dateTime_1,
				string_0,
				short_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class22 method_2(int int_0)
		{
			return (Class3.Class22)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class3.Class8 @class = (Class3.Class8)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class8();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idRequest"];
			this.dataColumn_2 = base.Columns["idSchmObj"];
			this.dataColumn_3 = base.Columns["DateBeg"];
			this.dataColumn_4 = base.Columns["DateEnd"];
			this.dataColumn_5 = base.Columns["Duration"];
			this.dataColumn_6 = base.Columns["Num"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idRequest", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idSchmObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("DateBeg", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("DateEnd", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Duration", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Num", typeof(short), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
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
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_4.AllowDBNull = false;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_5.MaxLength = 100;
			this.dataColumn_6.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class22 method_5()
		{
			return (Class3.Class22)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class22(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class22);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate4_1 != null)
			{
				this.delegate4_1(this, new Class3.EventArgs4((Class3.Class22)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate4_0 != null)
			{
				this.delegate4_0(this, new Class3.EventArgs4((Class3.Class22)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate4_3 != null)
			{
				this.delegate4_3(this, new Class3.EventArgs4((Class3.Class22)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate4_2 != null)
			{
				this.delegate4_2(this, new Class3.EventArgs4((Class3.Class22)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class22 class22_0)
		{
			base.Rows.Remove(class22_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tL_RequestForRepairSchmObjListDataTable";
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
		private Class3.Delegate4 delegate4_0;

		[CompilerGenerated]
		private Class3.Delegate4 delegate4_1;

		[CompilerGenerated]
		private Class3.Delegate4 delegate4_2;

		[CompilerGenerated]
		private Class3.Delegate4 delegate4_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class9 : TypedTableBase<Class3.Class23>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class9()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_RequestForRepair";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class9(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class9(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_8
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn SaymedyAh6
		{
			get
			{
				return this.dataColumn_9;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_9
		{
			get
			{
				return this.dataColumn_10;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_10
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_16
		{
			get
			{
				return this.dataColumn_17;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_19
		{
			get
			{
				return this.dataColumn_20;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_20
		{
			get
			{
				return this.dataColumn_21;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_21
		{
			get
			{
				return this.dataColumn_22;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_22
		{
			get
			{
				return this.dataColumn_23;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_23
		{
			get
			{
				return this.dataColumn_24;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_24
		{
			get
			{
				return this.dataColumn_25;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_25
		{
			get
			{
				return this.dataColumn_26;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_26
		{
			get
			{
				return this.dataColumn_27;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_27
		{
			get
			{
				return this.dataColumn_28;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_28
		{
			get
			{
				return this.dataColumn_29;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_29
		{
			get
			{
				return this.dataColumn_30;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_30
		{
			get
			{
				return this.dataColumn_31;
			}
		}

		[Browsable(false)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class23 this[int int_0]
		{
			get
			{
				return (Class3.Class23)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate5 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate5 @delegate = this.delegate5_0;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate5 @delegate = this.delegate5_0;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate5 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate5 @delegate = this.delegate5_1;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate5 @delegate = this.delegate5_1;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate5 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate5 @delegate = this.delegate5_2;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate5 @delegate = this.delegate5_2;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate5 UmtsIfbsAs
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate5 @delegate = this.delegate5_3;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate5 @delegate = this.delegate5_3;
				Class3.Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate5 value2 = (Class3.Delegate5)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate5>(ref this.delegate5_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class23 class23_0)
		{
			base.Rows.Add(class23_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class23 method_1(int int_0, DateTime dateTime_0, int int_1, string string_0, int int_2, string string_1, string string_2, bool bool_0, bool bool_1, string string_3, string string_4, string string_5, bool bool_2, DateTime dateTime_1, int int_3, int int_4, int int_5, bool bool_3, int int_6, int int_7, DateTime dateTime_2, int int_8, int int_9, int int_10, int int_11, int int_12, string string_6, bool bool_4, string string_7, bool bool_5, string string_8)
		{
			Class3.Class23 @class = (Class3.Class23)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				dateTime_0,
				int_1,
				string_0,
				int_2,
				string_1,
				string_2,
				bool_0,
				bool_1,
				string_3,
				string_4,
				string_5,
				bool_2,
				dateTime_1,
				int_3,
				int_4,
				int_5,
				bool_3,
				int_6,
				int_7,
				dateTime_2,
				int_8,
				int_9,
				int_10,
				int_11,
				int_12,
				string_6,
				bool_4,
				string_7,
				bool_5,
				string_8
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class23 method_2(int int_0)
		{
			return (Class3.Class23)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class9 @class = (Class3.Class9)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class9();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["num"];
			this.dataColumn_2 = base.Columns["dateCreate"];
			this.dataColumn_3 = base.Columns["idWorker"];
			this.dataColumn_4 = base.Columns["reguestFiled"];
			this.dataColumn_5 = base.Columns["idSR"];
			this.dataColumn_6 = base.Columns["schmObj"];
			this.dataColumn_7 = base.Columns["Purpose"];
			this.dataColumn_8 = base.Columns["IsPlanned"];
			this.dataColumn_9 = base.Columns["Crash"];
			this.dataColumn_10 = base.Columns["AgreeWith"];
			this.dataColumn_11 = base.Columns["Comment"];
			this.dataColumn_12 = base.Columns["Address"];
			this.dataColumn_13 = base.Columns["Agreed"];
			this.dataColumn_14 = base.Columns["DateAgreed"];
			this.dataColumn_15 = base.Columns["WorkerAgreed"];
			this.dataColumn_16 = base.Columns["iddivision"];
			this.dataColumn_17 = base.Columns["idUserCreate"];
			this.dataColumn_18 = base.Columns["deleted"];
			this.dataColumn_19 = base.Columns["idRegion"];
			this.dataColumn_20 = base.Columns["typeDisable"];
			this.dataColumn_21 = base.Columns["dateFactEnd"];
			this.dataColumn_22 = base.Columns["organization"];
			this.dataColumn_23 = base.Columns["performerOrganization"];
			this.dataColumn_24 = base.Columns["groupWorks"];
			this.dataColumn_25 = base.Columns["status"];
			this.dataColumn_26 = base.Columns["idRIC"];
			this.dataColumn_27 = base.Columns["messageRIC"];
			this.dataColumn_28 = base.Columns["isSend"];
			this.dataColumn_29 = base.Columns["idTypeDamage"];
			this.dataColumn_30 = base.Columns["SendSite"];
			this.dataColumn_31 = base.Columns["LogXml"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("num", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("dateCreate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idWorker", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("reguestFiled", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idSR", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("schmObj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Purpose", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("IsPlanned", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Crash", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("AgreeWith", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("Agreed", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("DateAgreed", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("WorkerAgreed", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("iddivision", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("idUserCreate", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("idRegion", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("typeDisable", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("dateFactEnd", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("organization", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_23 = new DataColumn("performerOrganization", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_23);
			this.dataColumn_24 = new DataColumn("groupWorks", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_24);
			this.dataColumn_25 = new DataColumn("status", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_25);
			this.dataColumn_26 = new DataColumn("idRIC", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_26);
			this.dataColumn_27 = new DataColumn("messageRIC", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_27);
			this.dataColumn_28 = new DataColumn("isSend", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_28);
			this.dataColumn_29 = new DataColumn("idTypeDamage", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_29);
			this.dataColumn_30 = new DataColumn("SendSite", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_30);
			this.dataColumn_31 = new DataColumn("LogXml", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_31);
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
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_4.AllowDBNull = false;
			this.dataColumn_4.MaxLength = 256;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_6.AllowDBNull = false;
			this.dataColumn_6.MaxLength = 256;
			this.dataColumn_7.AllowDBNull = false;
			this.dataColumn_7.MaxLength = 256;
			this.dataColumn_8.AllowDBNull = false;
			this.dataColumn_10.MaxLength = 256;
			this.dataColumn_11.MaxLength = 256;
			this.dataColumn_13.AllowDBNull = false;
			this.dataColumn_16.AllowDBNull = false;
			this.dataColumn_18.DefaultValue = false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class23 method_5()
		{
			return (Class3.Class23)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class23(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class23);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate5_1 != null)
			{
				this.delegate5_1(this, new Class3.EventArgs5((Class3.Class23)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate5_0 != null)
			{
				this.delegate5_0(this, new Class3.EventArgs5((Class3.Class23)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate5_3 != null)
			{
				this.delegate5_3(this, new Class3.EventArgs5((Class3.Class23)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate5_2 != null)
			{
				this.delegate5_2(this, new Class3.EventArgs5((Class3.Class23)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class23 class23_0)
		{
			base.Rows.Remove(class23_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_RequestForRepairDataTable";
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

		private DataColumn dataColumn_21;

		private DataColumn dataColumn_22;

		private DataColumn dataColumn_23;

		private DataColumn dataColumn_24;

		private DataColumn dataColumn_25;

		private DataColumn dataColumn_26;

		private DataColumn dataColumn_27;

		private DataColumn dataColumn_28;

		private DataColumn dataColumn_29;

		private DataColumn dataColumn_30;

		private DataColumn dataColumn_31;

		[CompilerGenerated]
		private Class3.Delegate5 delegate5_0;

		[CompilerGenerated]
		private Class3.Delegate5 delegate5_1;

		[CompilerGenerated]
		private Class3.Delegate5 delegate5_2;

		[CompilerGenerated]
		private Class3.Delegate5 delegate5_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class10 : TypedTableBase<Class3.Class24>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class10()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_RequestForRepairDaily";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class10(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class10(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
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
		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class24 this[int int_0]
		{
			get
			{
				return (Class3.Class24)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate6 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate6 @delegate = this.delegate6_0;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate6 @delegate = this.delegate6_0;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate6 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate6 @delegate = this.delegate6_1;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate6 @delegate = this.delegate6_1;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate6 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate6 @delegate = this.delegate6_2;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate6 @delegate = this.delegate6_2;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate6 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate6 @delegate = this.delegate6_3;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate6 @delegate = this.delegate6_3;
				Class3.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate6 value2 = (Class3.Delegate6)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate6>(ref this.delegate6_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class24 class24_0)
		{
			base.Rows.Add(class24_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class24 method_1(int int_0, DateTime dateTime_0, DateTime dateTime_1)
		{
			Class3.Class24 @class = (Class3.Class24)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				dateTime_0,
				dateTime_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class24 method_2(int int_0)
		{
			return (Class3.Class24)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class10 @class = (Class3.Class10)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class10();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idRequest"];
			this.dataColumn_2 = base.Columns["dateBeg"];
			this.dataColumn_3 = base.Columns["dateEnd"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idRequest", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("dateBeg", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("dateEnd", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
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
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class24 method_5()
		{
			return (Class3.Class24)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class24(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class24);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate6_1 != null)
			{
				this.delegate6_1(this, new Class3.EventArgs6((Class3.Class24)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate6_0 != null)
			{
				this.delegate6_0(this, new Class3.EventArgs6((Class3.Class24)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate6_3 != null)
			{
				this.delegate6_3(this, new Class3.EventArgs6((Class3.Class24)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate6_2 != null)
			{
				this.delegate6_2(this, new Class3.EventArgs6((Class3.Class24)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class3.Class24 class24_0)
		{
			base.Rows.Remove(class24_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_RequestForRepairDailyDataTable";
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

		[CompilerGenerated]
		private Class3.Delegate6 delegate6_0;

		[CompilerGenerated]
		private Class3.Delegate6 delegate6_1;

		[CompilerGenerated]
		private Class3.Delegate6 delegate6_2;

		[CompilerGenerated]
		private Class3.Delegate6 delegate6_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class11 : TypedTableBase<Class3.Class25>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class11()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_RequestForRepairDoc";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class11(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class11(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class25 this[int int_0]
		{
			get
			{
				return (Class3.Class25)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate7 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate7 @delegate = this.delegate7_0;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate7 @delegate = this.delegate7_0;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate7 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate7 @delegate = this.delegate7_1;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate7 @delegate = this.delegate7_1;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate7 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate7 @delegate = this.delegate7_2;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate7 @delegate = this.delegate7_2;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate7 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate7 @delegate = this.delegate7_3;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate7 @delegate = this.delegate7_3;
				Class3.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate7 value2 = (Class3.Delegate7)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate7>(ref this.delegate7_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class25 class25_0)
		{
			base.Rows.Add(class25_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class25 method_1(int int_0, byte[] byte_0, string string_0, string string_1)
		{
			Class3.Class25 @class = (Class3.Class25)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				byte_0,
				string_0,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class25 method_2(int int_0)
		{
			return (Class3.Class25)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class3.Class11 @class = (Class3.Class11)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class11();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idRequest"];
			this.dataColumn_2 = base.Columns["Document"];
			this.dataColumn_3 = base.Columns["FileName"];
			this.dataColumn_4 = base.Columns["Comment"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idRequest", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Document", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("FileName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
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
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 1024;
			this.dataColumn_4.MaxLength = 1024;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class25 method_5()
		{
			return (Class3.Class25)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class25(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class25);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate7_1 != null)
			{
				this.delegate7_1(this, new Class3.EventArgs7((Class3.Class25)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate7_0 != null)
			{
				this.delegate7_0(this, new Class3.EventArgs7((Class3.Class25)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate7_3 != null)
			{
				this.delegate7_3(this, new Class3.EventArgs7((Class3.Class25)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate7_2 != null)
			{
				this.delegate7_2(this, new Class3.EventArgs7((Class3.Class25)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class25 class25_0)
		{
			base.Rows.Remove(class25_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_RequestForRepairDocDataTable";
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
		private Class3.Delegate7 delegate7_0;

		[CompilerGenerated]
		private Class3.Delegate7 delegate7_1;

		[CompilerGenerated]
		private Class3.Delegate7 delegate7_2;

		[CompilerGenerated]
		private Class3.Delegate7 delegate7_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class12 : TypedTableBase<Class3.Class26>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class12()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tR_RequestForRepairClient";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class12(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class12(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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

		[Browsable(false)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class26 this[int int_0]
		{
			get
			{
				return (Class3.Class26)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate8 MwgalhbYrD
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate8 @delegate = this.delegate8_0;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate8 @delegate = this.delegate8_0;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate8 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate8 @delegate = this.delegate8_1;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate8 @delegate = this.delegate8_1;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate8 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate8 @delegate = this.delegate8_2;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate8 @delegate = this.delegate8_2;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate8 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate8 @delegate = this.delegate8_3;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate8 @delegate = this.delegate8_3;
				Class3.Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate8 value2 = (Class3.Delegate8)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate8>(ref this.delegate8_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class3.Class26 class26_0)
		{
			base.Rows.Add(class26_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class26 method_1(string string_0, int int_0, int int_1, int int_2, string string_1, bool bool_0)
		{
			Class3.Class26 @class = (Class3.Class26)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				string_0,
				int_0,
				int_1,
				int_2,
				string_1,
				bool_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class26 method_2(int int_0)
		{
			return (Class3.Class26)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class12 @class = (Class3.Class12)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class12();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["Name"];
			this.dataColumn_2 = base.Columns["Value"];
			this.dataColumn_3 = base.Columns["Type"];
			this.dataColumn_4 = base.Columns["GesId"];
			this.dataColumn_5 = base.Columns["GesName"];
			this.dataColumn_6 = base.Columns["IsDefault"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Value", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Type", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("GesId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("GesName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("IsDefault", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
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
			this.dataColumn_1.MaxLength = 1024;
			this.dataColumn_5.MaxLength = 1024;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class26 method_5()
		{
			return (Class3.Class26)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class26(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class26);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate8_1 != null)
			{
				this.delegate8_1(this, new Class3.EventArgs8((Class3.Class26)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate8_0 != null)
			{
				this.delegate8_0(this, new Class3.EventArgs8((Class3.Class26)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate8_3 != null)
			{
				this.delegate8_3(this, new Class3.EventArgs8((Class3.Class26)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate8_2 != null)
			{
				this.delegate8_2(this, new Class3.EventArgs8((Class3.Class26)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class26 class26_0)
		{
			base.Rows.Remove(class26_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tR_RequestForRepairClientDataTable";
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
		private Class3.Delegate8 delegate8_0;

		[CompilerGenerated]
		private Class3.Delegate8 delegate8_1;

		[CompilerGenerated]
		private Class3.Delegate8 delegate8_2;

		[CompilerGenerated]
		private Class3.Delegate8 delegate8_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class13 : TypedTableBase<Class3.Class27>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class13()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_RequestForRepairAddress";
			this.BeginInit();
			this.uiYayEolhs();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class13(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class13(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class27 this[int int_0]
		{
			get
			{
				return (Class3.Class27)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate9 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate9 @delegate = this.delegate9_0;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate9 @delegate = this.delegate9_0;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate9 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate9 @delegate = this.delegate9_1;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate9 @delegate = this.delegate9_1;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate9 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate9 @delegate = this.delegate9_2;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate9 @delegate = this.delegate9_2;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate9 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate9 @delegate = this.delegate9_3;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate9 @delegate = this.delegate9_3;
				Class3.Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate9 value2 = (Class3.Delegate9)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate9>(ref this.delegate9_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class3.Class27 class27_0)
		{
			base.Rows.Add(class27_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class27 ChqaHmDsiK(int int_0, int int_1, int int_2, string string_0, string string_1)
		{
			Class3.Class27 @class = (Class3.Class27)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				int_2,
				string_0,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class27 method_1(int int_0)
		{
			return (Class3.Class27)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class3.Class13 @class = (Class3.Class13)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class13();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idRequest"];
			this.dataColumn_2 = base.Columns["idKladrObj"];
			this.dataColumn_3 = base.Columns["idKladrStreet"];
			this.dataColumn_4 = base.Columns["House"];
			this.dataColumn_5 = base.Columns["Name"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void uiYayEolhs()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idRequest", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idKladrObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idKladrStreet", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("House", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Name", typeof(string), null, MappingType.Element);
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
			this.dataColumn_4.MaxLength = 50;
			this.dataColumn_5.MaxLength = 512;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class27 method_3()
		{
			return (Class3.Class27)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class27(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class27);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate9_1 != null)
			{
				this.delegate9_1(this, new Class3.EventArgs9((Class3.Class27)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate9_0 != null)
			{
				this.delegate9_0(this, new Class3.EventArgs9((Class3.Class27)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate9_3 != null)
			{
				this.delegate9_3(this, new Class3.EventArgs9((Class3.Class27)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate9_2 != null)
			{
				this.delegate9_2(this, new Class3.EventArgs9((Class3.Class27)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_4(Class3.Class27 class27_0)
		{
			base.Rows.Remove(class27_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_RequestForRepairAddressDataTable";
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
		private Class3.Delegate9 delegate9_0;

		[CompilerGenerated]
		private Class3.Delegate9 delegate9_1;

		[CompilerGenerated]
		private Class3.Delegate9 delegate9_2;

		[CompilerGenerated]
		private Class3.Delegate9 delegate9_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class14 : TypedTableBase<Class3.Class28>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class14()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_Damage";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class14(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class14(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataColumn DataColumn_11
		{
			get
			{
				return this.dataColumn_11;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_12
		{
			get
			{
				return this.dataColumn_12;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_13
		{
			get
			{
				return this.dataColumn_13;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_14
		{
			get
			{
				return this.dataColumn_14;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_17
		{
			get
			{
				return this.dataColumn_17;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_18
		{
			get
			{
				return this.dataColumn_18;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_19
		{
			get
			{
				return this.dataColumn_19;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_20
		{
			get
			{
				return this.dataColumn_20;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_21
		{
			get
			{
				return this.dataColumn_21;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_22
		{
			get
			{
				return this.dataColumn_22;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_23
		{
			get
			{
				return this.dataColumn_23;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_24
		{
			get
			{
				return this.dataColumn_24;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_25
		{
			get
			{
				return this.dataColumn_25;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_26
		{
			get
			{
				return this.dataColumn_26;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_27
		{
			get
			{
				return this.dataColumn_27;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_28
		{
			get
			{
				return this.dataColumn_28;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_29
		{
			get
			{
				return this.dataColumn_29;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_30
		{
			get
			{
				return this.dataColumn_30;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_31
		{
			get
			{
				return this.dataColumn_31;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_32
		{
			get
			{
				return this.dataColumn_32;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class28 this[int int_0]
		{
			get
			{
				return (Class3.Class28)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate10 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate10 @delegate = this.delegate10_0;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate10 @delegate = this.delegate10_0;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate10 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate10 @delegate = this.delegate10_1;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate10 @delegate = this.delegate10_1;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate10 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate10 @delegate = this.delegate10_2;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate10 @delegate = this.delegate10_2;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate10 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate10 @delegate = this.delegate10_3;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate10 @delegate = this.delegate10_3;
				Class3.Delegate10 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate10 value2 = (Class3.Delegate10)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate10>(ref this.delegate10_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class28 class28_0)
		{
			base.Rows.Add(class28_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class28 method_1(int int_0, DateTime dateTime_0, int int_1, string string_0, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, string string_1, int int_8, int int_9, string string_2, bool bool_0, int int_10, DateTime dateTime_1, int int_11, bool bool_1, int int_12, int int_13, DateTime dateTime_2, DateTime dateTime_3, int int_14, string string_3, string string_4, int int_15, string string_5, string string_6, int int_16, bool bool_2, bool bool_3)
		{
			Class3.Class28 @class = (Class3.Class28)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				dateTime_0,
				int_1,
				string_0,
				int_2,
				int_3,
				int_4,
				int_5,
				int_6,
				int_7,
				string_1,
				int_8,
				int_9,
				string_2,
				bool_0,
				int_10,
				dateTime_1,
				int_11,
				bool_1,
				int_12,
				int_13,
				dateTime_2,
				dateTime_3,
				int_14,
				string_3,
				string_4,
				int_15,
				string_5,
				string_6,
				int_16,
				bool_2,
				bool_3
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class28 method_2(int int_0)
		{
			return (Class3.Class28)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class14 @class = (Class3.Class14)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class14();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["numDoc"];
			this.dataColumn_2 = base.Columns["DateDoc"];
			this.dataColumn_3 = base.Columns["TypeDoc"];
			this.dataColumn_4 = base.Columns["NumRequest"];
			this.dataColumn_5 = base.Columns["idCompiler"];
			this.dataColumn_6 = base.Columns["idDivision"];
			this.dataColumn_7 = base.Columns["idSchmObj"];
			this.dataColumn_8 = base.Columns["idMap"];
			this.dataColumn_9 = base.Columns["idLineSchmObj"];
			this.dataColumn_10 = base.Columns["idLineSection"];
			this.dataColumn_11 = base.Columns["DefectLocation"];
			this.dataColumn_12 = base.Columns["idReason"];
			this.dataColumn_13 = base.Columns["idCompletedWork"];
			this.dataColumn_14 = base.Columns["ComletedWorkText"];
			this.dataColumn_15 = base.Columns["isApply"];
			this.dataColumn_16 = base.Columns["idWorkerApply"];
			this.dataColumn_17 = base.Columns["DateApply"];
			this.dataColumn_18 = base.Columns["idDivisionApply"];
			this.dataColumn_19 = base.Columns["isLaboratory"];
			this.dataColumn_20 = base.Columns["idParent"];
			this.dataColumn_21 = base.Columns["idOwner"];
			this.dataColumn_22 = base.Columns["DateOwner"];
			this.dataColumn_23 = base.Columns["DatePlanApply"];
			this.dataColumn_24 = base.Columns["idReasonPTS"];
			this.dataColumn_25 = base.Columns["DivisionInstruction"];
			this.dataColumn_26 = base.Columns["LaboratoryInstruction"];
			this.dataColumn_27 = base.Columns["idCompletedWorkODS"];
			this.dataColumn_28 = base.Columns["CompletedWorkTextODS"];
			this.dataColumn_29 = base.Columns["CommentXml"];
			this.dataColumn_30 = base.Columns["idReqForRepair"];
			this.dataColumn_31 = base.Columns["Deleted"];
			this.dataColumn_32 = base.Columns["is81"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("numDoc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("DateDoc", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("TypeDoc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("NumRequest", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idCompiler", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("idDivision", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("idSchmObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("idMap", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("idLineSchmObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("idLineSection", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("DefectLocation", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("idReason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("idCompletedWork", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("ComletedWorkText", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("isApply", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("idWorkerApply", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("DateApply", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("idDivisionApply", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("isLaboratory", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("idParent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("idOwner", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("DateOwner", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_23 = new DataColumn("DatePlanApply", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_23);
			this.dataColumn_24 = new DataColumn("idReasonPTS", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_24);
			this.dataColumn_25 = new DataColumn("DivisionInstruction", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_25);
			this.dataColumn_26 = new DataColumn("LaboratoryInstruction", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_26);
			this.dataColumn_27 = new DataColumn("idCompletedWorkODS", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_27);
			this.dataColumn_28 = new DataColumn("CompletedWorkTextODS", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_28);
			this.dataColumn_29 = new DataColumn("CommentXml", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_29);
			this.dataColumn_30 = new DataColumn("idReqForRepair", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_30);
			this.dataColumn_31 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_31);
			this.dataColumn_32 = new DataColumn("is81", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_32);
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
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_4.MaxLength = 50;
			this.dataColumn_11.MaxLength = 1024;
			this.dataColumn_14.MaxLength = 2028;
			this.dataColumn_25.MaxLength = 2028;
			this.dataColumn_26.MaxLength = 2028;
			this.dataColumn_28.MaxLength = 2028;
			this.dataColumn_29.MaxLength = int.MaxValue;
			this.dataColumn_31.AllowDBNull = false;
			this.dataColumn_31.DefaultValue = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class28 method_5()
		{
			return (Class3.Class28)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class28(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class28);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate10_1 != null)
			{
				this.delegate10_1(this, new Class3.EventArgs10((Class3.Class28)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate10_0 != null)
			{
				this.delegate10_0(this, new Class3.EventArgs10((Class3.Class28)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate10_3 != null)
			{
				this.delegate10_3(this, new Class3.EventArgs10((Class3.Class28)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate10_2 != null)
			{
				this.delegate10_2(this, new Class3.EventArgs10((Class3.Class28)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class3.Class28 class28_0)
		{
			base.Rows.Remove(class28_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_DamageDataTable";
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

		private DataColumn dataColumn_21;

		private DataColumn dataColumn_22;

		private DataColumn dataColumn_23;

		private DataColumn dataColumn_24;

		private DataColumn dataColumn_25;

		private DataColumn dataColumn_26;

		private DataColumn dataColumn_27;

		private DataColumn dataColumn_28;

		private DataColumn dataColumn_29;

		private DataColumn dataColumn_30;

		private DataColumn dataColumn_31;

		private DataColumn dataColumn_32;

		[CompilerGenerated]
		private Class3.Delegate10 delegate10_0;

		[CompilerGenerated]
		private Class3.Delegate10 delegate10_1;

		[CompilerGenerated]
		private Class3.Delegate10 delegate10_2;

		[CompilerGenerated]
		private Class3.Delegate10 delegate10_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class15 : TypedTableBase<Class3.Class29>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class15()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_DamageHV";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class15(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class15(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_11
		{
			get
			{
				return this.dataColumn_11;
			}
		}

		[DebuggerNonUserCode]
		[Browsable(false)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class29 this[int int_0]
		{
			get
			{
				return (Class3.Class29)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate11 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate11 @delegate = this.delegate11_0;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate11 @delegate = this.delegate11_0;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate11 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate11 @delegate = this.delegate11_1;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate11 @delegate = this.delegate11_1;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate11 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate11 @delegate = this.delegate11_2;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate11 @delegate = this.delegate11_2;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate11 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate11 @delegate = this.delegate11_3;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate11 @delegate = this.delegate11_3;
				Class3.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate11 value2 = (Class3.Delegate11)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate11>(ref this.delegate11_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class29 class29_0)
		{
			base.Rows.Add(class29_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class29 method_1(int int_0, int int_1, int int_2, int int_3, decimal decimal_0, decimal decimal_1, decimal decimal_2, bool bool_0, bool bool_1, decimal decimal_3, decimal decimal_4, decimal decimal_5)
		{
			Class3.Class29 @class = (Class3.Class29)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				int_3,
				decimal_0,
				decimal_1,
				decimal_2,
				bool_0,
				bool_1,
				decimal_3,
				decimal_4,
				decimal_5
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class29 method_2(int int_0)
		{
			return (Class3.Class29)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class15 @class = (Class3.Class15)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class15();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["idDamage"];
			this.dataColumn_1 = base.Columns["idTypeRZA"];
			this.dataColumn_2 = base.Columns["CountSchmObj"];
			this.dataColumn_3 = base.Columns["CountSchmObjOff"];
			this.dataColumn_4 = base.Columns["ConnectedPower"];
			this.dataColumn_5 = base.Columns["CoefFI"];
			this.dataColumn_6 = base.Columns["NoAdmissionKWT"];
			this.dataColumn_7 = base.Columns["AVR"];
			this.dataColumn_8 = base.Columns["APR"];
			this.dataColumn_9 = base.Columns["PowerA"];
			this.dataColumn_10 = base.Columns["PowerV"];
			this.dataColumn_11 = base.Columns["CoefSeason"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("idDamage", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idTypeRZA", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("CountSchmObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("CountSchmObjOff", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("ConnectedPower", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("CoefFI", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("NoAdmissionKWT", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("AVR", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("APR", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("PowerA", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("PowerV", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("CoefSeason", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class29 method_5()
		{
			return (Class3.Class29)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class29(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class29);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate11_1 != null)
			{
				this.delegate11_1(this, new Class3.EventArgs11((Class3.Class29)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate11_0 != null)
			{
				this.delegate11_0(this, new Class3.EventArgs11((Class3.Class29)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate11_3 != null)
			{
				this.delegate11_3(this, new Class3.EventArgs11((Class3.Class29)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate11_2 != null)
			{
				this.delegate11_2(this, new Class3.EventArgs11((Class3.Class29)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class3.Class29 class29_0)
		{
			base.Rows.Remove(class29_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_DamageHVDataTable";
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

		[CompilerGenerated]
		private Class3.Delegate11 delegate11_0;

		[CompilerGenerated]
		private Class3.Delegate11 delegate11_1;

		[CompilerGenerated]
		private Class3.Delegate11 delegate11_2;

		[CompilerGenerated]
		private Class3.Delegate11 delegate11_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class16 : TypedTableBase<Class3.Class30>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class16()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_DamageLV";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class16(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class16(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
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
		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class30 this[int int_0]
		{
			get
			{
				return (Class3.Class30)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate12 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate12 @delegate = this.delegate12_0;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate12 @delegate = this.delegate12_0;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate12 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate12 @delegate = this.delegate12_1;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate12 @delegate = this.delegate12_1;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate12 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate12 @delegate = this.delegate12_2;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate12 @delegate = this.delegate12_2;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate12 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate12 @delegate = this.delegate12_3;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate12 @delegate = this.delegate12_3;
				Class3.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate12 value2 = (Class3.Delegate12)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate12>(ref this.delegate12_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class3.Class30 class30_0)
		{
			base.Rows.Add(class30_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class30 method_1(int int_0, string string_0, string string_1, string string_2)
		{
			Class3.Class30 @class = (Class3.Class30)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				string_1,
				string_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class30 method_2(int int_0)
		{
			return (Class3.Class30)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class16 @class = (Class3.Class16)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class16();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["idDamage"];
			this.dataColumn_1 = base.Columns["Declarer"];
			this.dataColumn_2 = base.Columns["DeclarerTel"];
			this.dataColumn_3 = base.Columns["DeclarerAddress"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("idDamage", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Declarer", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("DeclarerTel", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("DeclarerAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.MaxLength = 256;
			this.dataColumn_2.MaxLength = 256;
			this.dataColumn_3.MaxLength = 512;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class30 method_5()
		{
			return (Class3.Class30)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class30(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class30);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate12_1 != null)
			{
				this.delegate12_1(this, new Class3.EventArgs12((Class3.Class30)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate12_0 != null)
			{
				this.delegate12_0(this, new Class3.EventArgs12((Class3.Class30)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate12_3 != null)
			{
				this.delegate12_3(this, new Class3.EventArgs12((Class3.Class30)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate12_2 != null)
			{
				this.delegate12_2(this, new Class3.EventArgs12((Class3.Class30)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class3.Class30 class30_0)
		{
			base.Rows.Remove(class30_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_DamageLVDataTable";
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

		[CompilerGenerated]
		private Class3.Delegate12 delegate12_0;

		[CompilerGenerated]
		private Class3.Delegate12 delegate12_1;

		[CompilerGenerated]
		private Class3.Delegate12 delegate12_2;

		[CompilerGenerated]
		private Class3.Delegate12 delegate12_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class17 : TypedTableBase<Class3.Class31>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class17()
		{
			Class38.TqlX7ZmzmDDi2();
			
			base.TableName = "tJ_RequestForRepairLog";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class17(DataTable dataTable_0)
		{
			Class38.TqlX7ZmzmDDi2();
			
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
		protected Class17(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class38.TqlX7ZmzmDDi2();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_8
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[Browsable(false)]
		[DebuggerNonUserCode]
		public int Int32_0
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class31 this[int int_0]
		{
			get
			{
				return (Class3.Class31)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate13 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate13 @delegate = this.delegate13_0;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate13 @delegate = this.delegate13_0;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate13 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate13 @delegate = this.delegate13_1;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate13 @delegate = this.delegate13_1;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate13 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate13 @delegate = this.delegate13_2;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate13 @delegate = this.delegate13_2;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class3.Delegate13 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class3.Delegate13 @delegate = this.delegate13_3;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class3.Delegate13 @delegate = this.delegate13_3;
				Class3.Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate13 value2 = (Class3.Delegate13)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate13>(ref this.delegate13_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class3.Class31 class31_0)
		{
			base.Rows.Add(class31_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class31 method_1(int int_0, DateTime dateTime_0, int int_1, string string_0, string string_1, int int_2, string string_2, bool bool_0)
		{
			Class3.Class31 @class = (Class3.Class31)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				dateTime_0,
				int_1,
				string_0,
				string_1,
				int_2,
				string_2,
				bool_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class31 method_2(int int_0)
		{
			return (Class3.Class31)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class3.Class17 @class = (Class3.Class17)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class3.Class17();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idRequest"];
			this.dataColumn_2 = base.Columns["dateLog"];
			this.dataColumn_3 = base.Columns["userLogID"];
			this.dataColumn_4 = base.Columns["userLog"];
			this.dataColumn_5 = base.Columns["userLogName"];
			this.dataColumn_6 = base.Columns["idCommand"];
			this.dataColumn_7 = base.Columns["Command"];
			this.dataColumn_8 = base.Columns["isSite"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idRequest", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("dateLog", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("userLogID", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("userLog", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("userLogName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("idCommand", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Command", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("isSite", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
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
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_4.MaxLength = 50;
			this.dataColumn_5.MaxLength = 128;
			this.dataColumn_6.AllowDBNull = false;
			this.dataColumn_7.MaxLength = 128;
			this.dataColumn_8.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class31 method_5()
		{
			return (Class3.Class31)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class3.Class31(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class3.Class31);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate13_1 != null)
			{
				this.delegate13_1(this, new Class3.EventArgs13((Class3.Class31)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate13_0 != null)
			{
				this.delegate13_0(this, new Class3.EventArgs13((Class3.Class31)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate13_3 != null)
			{
				this.delegate13_3(this, new Class3.EventArgs13((Class3.Class31)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate13_2 != null)
			{
				this.delegate13_2(this, new Class3.EventArgs13((Class3.Class31)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class3.Class31 class31_0)
		{
			base.Rows.Remove(class31_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class3 @class = new Class3();
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
			xmlSchemaAttribute2.FixedValue = "tJ_RequestForRepairLogDataTable";
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

		[CompilerGenerated]
		private Class3.Delegate13 delegate13_0;

		[CompilerGenerated]
		private Class3.Delegate13 delegate13_1;

		[CompilerGenerated]
		private Class3.Delegate13 delegate13_2;

		[CompilerGenerated]
		private Class3.Delegate13 delegate13_3;
	}

	public class Class18 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class18(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class4_0 = (Class3.Class4)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				return (int)base[this.class4_0.DataColumn_0];
			}
			set
			{
				base[this.class4_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Name
		{
			get
			{
				return (string)base[this.class4_0.DataColumn_1];
			}
			set
			{
				base[this.class4_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string SocrName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class4_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SocrName' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class4_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal Value
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class4_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Value' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class4_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Comment
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class4_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class4_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int ParentId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class4_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentId' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class4_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string ParentKey
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class4_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentKey' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class4_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public byte[] OtherId
		{
			get
			{
				byte[] result;
				try
				{
					result = (byte[])base[this.class4_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherId' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class4_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsGroup
		{
			get
			{
				return (bool)base[this.class4_0.DataColumn_8];
			}
			set
			{
				base[this.class4_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class4_0.DataColumn_9];
			}
			set
			{
				base[this.class4_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class4_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class4_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class4_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class4_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class4_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class4_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class4_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class4_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class4_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class4_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class4_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class4_0.DataColumn_7] = Convert.DBNull;
		}

		private Class3.Class4 class4_0;
	}

	public class Class19 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class19(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class5_0 = (Class3.Class5)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				return (int)base[this.class5_0.DataColumn_0];
			}
			set
			{
				base[this.class5_0.DataColumn_0] = value;
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
					result = (string)base[this.class5_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vSchm_ObjList' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class5_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeCodeId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class5_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeCodeId' in table 'vSchm_ObjList' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class5_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string typecode
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class5_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typecode' in table 'vSchm_ObjList' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class5_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string typeCodeSocr
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class5_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeCodeSocr' in table 'vSchm_ObjList' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class5_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int IdParent
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class5_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IdParent' in table 'vSchm_ObjList' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class5_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool OnOff
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class5_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OnOff' in table 'vSchm_ObjList' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class5_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int NameP
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class5_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NameP' in table 'vSchm_ObjList' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class5_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class5_0.DataColumn_8];
			}
			set
			{
				base[this.class5_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class5_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class5_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class5_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class5_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class5_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class5_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class5_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class5_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class5_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class5_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class5_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class5_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class5_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class5_0.DataColumn_7] = Convert.DBNull;
		}

		private Class3.Class5 class5_0;
	}

	public class Class20 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class20(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class6_0 = (Class3.Class6)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Id
		{
			get
			{
				return (int)base[this.class6_0.DataColumn_0];
			}
			set
			{
				base[this.class6_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int ParentLink
		{
			get
			{
				return (int)base[this.class6_0.DataColumn_1];
			}
			set
			{
				base[this.class6_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeCodeId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class6_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeCodeId' in table 'vSchm_TreeCellLine' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class6_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ParentKey
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class6_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentKey' in table 'vSchm_TreeCellLine' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class6_0.DataColumn_3] = value;
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
					result = (string)base[this.class6_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vSchm_TreeCellLine' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class6_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string FullName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class6_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FullName' in table 'vSchm_TreeCellLine' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class6_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class6_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class6_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class6_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class6_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool xaolqWiSiY()
		{
			return base.IsNull(this.class6_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_4()
		{
			base[this.class6_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_5()
		{
			return base.IsNull(this.class6_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6()
		{
			base[this.class6_0.DataColumn_5] = Convert.DBNull;
		}

		private Class3.Class6 class6_0;
	}

	public class Class21 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class21(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class7_0 = (Class3.Class7)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class7_0.DataColumn_0];
			}
			set
			{
				base[this.class7_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int SourceObj
		{
			get
			{
				return (int)base[this.class7_0.DataColumn_1];
			}
			set
			{
				base[this.class7_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int DestObj
		{
			get
			{
				return (int)base[this.class7_0.DataColumn_2];
			}
			set
			{
				base[this.class7_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Edge
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class7_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Edge' in table 'tSchm_Relation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class7_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class7_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class7_0.DataColumn_3] = Convert.DBNull;
		}

		private Class3.Class7 class7_0;
	}

	public class Class22 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class22(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class8_0 = (Class3.Class8)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class8_0.DataColumn_0];
			}
			set
			{
				base[this.class8_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idRequest
		{
			get
			{
				return (int)base[this.class8_0.DataColumn_1];
			}
			set
			{
				base[this.class8_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idSchmObj
		{
			get
			{
				return (int)base[this.class8_0.DataColumn_2];
			}
			set
			{
				base[this.class8_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateBeg
		{
			get
			{
				return (DateTime)base[this.class8_0.DataColumn_3];
			}
			set
			{
				base[this.class8_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateEnd
		{
			get
			{
				return (DateTime)base[this.class8_0.DataColumn_4];
			}
			set
			{
				base[this.class8_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Duration
		{
			get
			{
				return (string)base[this.class8_0.DataColumn_5];
			}
			set
			{
				base[this.class8_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public short Num
		{
			get
			{
				return (short)base[this.class8_0.DataColumn_6];
			}
			set
			{
				base[this.class8_0.DataColumn_6] = value;
			}
		}

		private Class3.Class8 class8_0;
	}

	public class Class23 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class23(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class9_0 = (Class3.Class9)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class9_0.DataColumn_0];
			}
			set
			{
				base[this.class9_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int num
		{
			get
			{
				return (int)base[this.class9_0.DataColumn_1];
			}
			set
			{
				base[this.class9_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateCreate
		{
			get
			{
				return (DateTime)base[this.class9_0.DataColumn_2];
			}
			set
			{
				base[this.class9_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idWorker
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idWorker' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string reguestFiled
		{
			get
			{
				return (string)base[this.class9_0.DataColumn_4];
			}
			set
			{
				base[this.class9_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idSR
		{
			get
			{
				return (int)base[this.class9_0.DataColumn_5];
			}
			set
			{
				base[this.class9_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string schmObj
		{
			get
			{
				return (string)base[this.class9_0.DataColumn_6];
			}
			set
			{
				base[this.class9_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Purpose
		{
			get
			{
				return (string)base[this.class9_0.DataColumn_7];
			}
			set
			{
				base[this.class9_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsPlanned
		{
			get
			{
				return (bool)base[this.class9_0.DataColumn_8];
			}
			set
			{
				base[this.class9_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Crash
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class9_0.SaymedyAh6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Crash' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.SaymedyAh6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string AgreeWith
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class9_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AgreeWith' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_9] = value;
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
					result = (string)base[this.class9_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Address
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class9_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Address' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_11] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Agreed
		{
			get
			{
				return (bool)base[this.class9_0.DataColumn_12];
			}
			set
			{
				base[this.class9_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateAgreed
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class9_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateAgreed' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int WorkerAgreed
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WorkerAgreed' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_14] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int iddivision
		{
			get
			{
				return (int)base[this.class9_0.DataColumn_15];
			}
			set
			{
				base[this.class9_0.DataColumn_15] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idUserCreate
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idUserCreate' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_16] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool deleted
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class9_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'deleted' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_17] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idRegion
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idRegion' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_18] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int typeDisable
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeDisable' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_19] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateFactEnd
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class9_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateFactEnd' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_20] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int organization
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_21];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'organization' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_21] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int performerOrganization
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_22];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'performerOrganization' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_22] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int groupWorks
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_23];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'groupWorks' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_23] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int status
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_24];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'status' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_24] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idRIC
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class9_0.DataColumn_25];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idRIC' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_25] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string String_0
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class9_0.DataColumn_26];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'messageRIC' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_26] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool isSend
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class9_0.DataColumn_27];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'isSend' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_27] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string idTypeDamage
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class9_0.DataColumn_28];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idTypeDamage' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_28] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool SendSite
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class9_0.DataColumn_29];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SendSite' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_29] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string LogXml
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class9_0.DataColumn_30];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LogXml' in table 'tJ_RequestForRepair' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class9_0.DataColumn_30] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class9_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class9_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class9_0.SaymedyAh6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class9_0.SaymedyAh6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class9_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class9_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class9_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class9_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class9_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class9_0.DataColumn_11] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class9_0.DataColumn_13);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class9_0.DataColumn_13] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class9_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class9_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class9_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class9_0.DataColumn_16] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class9_0.DataColumn_17);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class9_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class9_0.DataColumn_18);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class9_0.DataColumn_18] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class9_0.DataColumn_19);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class9_0.DataColumn_19] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class9_0.DataColumn_20);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class9_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_24()
		{
			return base.IsNull(this.class9_0.DataColumn_21);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class9_0.DataColumn_21] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class9_0.DataColumn_22);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_27()
		{
			base[this.class9_0.DataColumn_22] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_28()
		{
			return base.IsNull(this.class9_0.DataColumn_23);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_29()
		{
			base[this.class9_0.DataColumn_23] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_30()
		{
			return base.IsNull(this.class9_0.DataColumn_24);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class9_0.DataColumn_24] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_32()
		{
			return base.IsNull(this.class9_0.DataColumn_25);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_33()
		{
			base[this.class9_0.DataColumn_25] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_34()
		{
			return base.IsNull(this.class9_0.DataColumn_26);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_35()
		{
			base[this.class9_0.DataColumn_26] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_36()
		{
			return base.IsNull(this.class9_0.DataColumn_27);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_37()
		{
			base[this.class9_0.DataColumn_27] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_38()
		{
			return base.IsNull(this.class9_0.DataColumn_28);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_39()
		{
			base[this.class9_0.DataColumn_28] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_40()
		{
			return base.IsNull(this.class9_0.DataColumn_29);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_41()
		{
			base[this.class9_0.DataColumn_29] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_42()
		{
			return base.IsNull(this.class9_0.DataColumn_30);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_43()
		{
			base[this.class9_0.DataColumn_30] = Convert.DBNull;
		}

		private Class3.Class9 class9_0;
	}

	public class Class24 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class24(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class10_0 = (Class3.Class10)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class10_0.DataColumn_0];
			}
			set
			{
				base[this.class10_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idRequest
		{
			get
			{
				return (int)base[this.class10_0.DataColumn_1];
			}
			set
			{
				base[this.class10_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateBeg
		{
			get
			{
				return (DateTime)base[this.class10_0.DataColumn_2];
			}
			set
			{
				base[this.class10_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateEnd
		{
			get
			{
				return (DateTime)base[this.class10_0.DataColumn_3];
			}
			set
			{
				base[this.class10_0.DataColumn_3] = value;
			}
		}

		private Class3.Class10 class10_0;
	}

	public class Class25 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class25(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class11_0 = (Class3.Class11)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class11_0.DataColumn_0];
			}
			set
			{
				base[this.class11_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idRequest
		{
			get
			{
				return (int)base[this.class11_0.DataColumn_1];
			}
			set
			{
				base[this.class11_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public byte[] Document
		{
			get
			{
				return (byte[])base[this.class11_0.DataColumn_2];
			}
			set
			{
				base[this.class11_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FileName
		{
			get
			{
				return (string)base[this.class11_0.DataColumn_3];
			}
			set
			{
				base[this.class11_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Comment
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class11_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tJ_RequestForRepairDoc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class11_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class11_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class11_0.DataColumn_4] = Convert.DBNull;
		}

		private Class3.Class11 class11_0;
	}

	public class Class26 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class26(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class12_0 = (Class3.Class12)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class12_0.DataColumn_0];
			}
			set
			{
				base[this.class12_0.DataColumn_0] = value;
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
					result = (string)base[this.class12_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'tR_RequestForRepairClient' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class12_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Value
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class12_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Value' in table 'tR_RequestForRepairClient' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class12_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Type
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class12_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Type' in table 'tR_RequestForRepairClient' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class12_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int GesId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class12_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GesId' in table 'tR_RequestForRepairClient' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class12_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string GesName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class12_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GesName' in table 'tR_RequestForRepairClient' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class12_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsDefault
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class12_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IsDefault' in table 'tR_RequestForRepairClient' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class12_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class12_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class12_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class12_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class12_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class12_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class12_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class12_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class12_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class12_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class12_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class12_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class12_0.DataColumn_6] = Convert.DBNull;
		}

		private Class3.Class12 class12_0;
	}

	public class Class27 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class27(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class13_0 = (Class3.Class13)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class13_0.DataColumn_0];
			}
			set
			{
				base[this.class13_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idRequest
		{
			get
			{
				return (int)base[this.class13_0.DataColumn_1];
			}
			set
			{
				base[this.class13_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idKladrObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class13_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idKladrObj' in table 'tJ_RequestForRepairAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class13_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idKladrStreet
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class13_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idKladrStreet' in table 'tJ_RequestForRepairAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class13_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string House
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class13_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'House' in table 'tJ_RequestForRepairAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class13_0.DataColumn_4] = value;
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
					result = (string)base[this.class13_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'tJ_RequestForRepairAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class13_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class13_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class13_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class13_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class13_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class13_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class13_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class13_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class13_0.DataColumn_5] = Convert.DBNull;
		}

		private Class3.Class13 class13_0;
	}

	public class Class28 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class28(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class14_0 = (Class3.Class14)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class14_0.DataColumn_0];
			}
			set
			{
				base[this.class14_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int numDoc
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'numDoc' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateDoc
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class14_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateDoc' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeDoc
		{
			get
			{
				return (int)base[this.class14_0.DataColumn_3];
			}
			set
			{
				base[this.class14_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NumRequest
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class14_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NumRequest' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idCompiler
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idCompiler' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idDivision
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idDivision' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idSchmObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idSchmObj' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idMap
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idMap' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idLineSchmObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idLineSchmObj' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idLineSection
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idLineSection' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string DefectLocation
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class14_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DefectLocation' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_11] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idReason
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idReason' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idCompletedWork
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idCompletedWork' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_13] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ComletedWorkText
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class14_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ComletedWorkText' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_14] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool isApply
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class14_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'isApply' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_15] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idWorkerApply
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idWorkerApply' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_16] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateApply
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class14_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateApply' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idDivisionApply
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idDivisionApply' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_18] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool isLaboratory
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class14_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'isLaboratory' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_19] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idParent
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idParent' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_20] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idOwner
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_21];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idOwner' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_21] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateOwner
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class14_0.DataColumn_22];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOwner' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_22] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DatePlanApply
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class14_0.DataColumn_23];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DatePlanApply' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_23] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Int32_0
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_24];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idReasonPTS' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_24] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string DivisionInstruction
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class14_0.DataColumn_25];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DivisionInstruction' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_25] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string LaboratoryInstruction
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class14_0.DataColumn_26];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LaboratoryInstruction' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_26] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idCompletedWorkODS
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_27];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idCompletedWorkODS' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_27] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string CompletedWorkTextODS
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class14_0.DataColumn_28];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CompletedWorkTextODS' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_28] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string CommentXml
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class14_0.DataColumn_29];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CommentXml' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_29] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idReqForRepair
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class14_0.DataColumn_30];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idReqForRepair' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_30] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class14_0.DataColumn_31];
			}
			set
			{
				base[this.class14_0.DataColumn_31] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool is81
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class14_0.DataColumn_32];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'is81' in table 'tJ_Damage' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class14_0.DataColumn_32] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class14_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class14_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class14_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class14_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class14_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class14_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class14_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class14_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class14_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class14_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class14_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class14_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class14_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class14_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class14_0.DataColumn_9);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class14_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class14_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class14_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class14_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_19()
		{
			base[this.class14_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_20()
		{
			return base.IsNull(this.class14_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class14_0.DataColumn_12] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class14_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class14_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class14_0.DataColumn_14);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_25()
		{
			base[this.class14_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class14_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_27()
		{
			base[this.class14_0.DataColumn_15] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class14_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_29()
		{
			base[this.class14_0.DataColumn_16] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class14_0.DataColumn_17);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class14_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_32()
		{
			return base.IsNull(this.class14_0.DataColumn_18);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_33()
		{
			base[this.class14_0.DataColumn_18] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_34()
		{
			return base.IsNull(this.class14_0.DataColumn_19);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_35()
		{
			base[this.class14_0.DataColumn_19] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_36()
		{
			return base.IsNull(this.class14_0.DataColumn_20);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_37()
		{
			base[this.class14_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_38()
		{
			return base.IsNull(this.class14_0.DataColumn_21);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_39()
		{
			base[this.class14_0.DataColumn_21] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_40()
		{
			return base.IsNull(this.class14_0.DataColumn_22);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_41()
		{
			base[this.class14_0.DataColumn_22] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_42()
		{
			return base.IsNull(this.class14_0.DataColumn_23);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_43()
		{
			base[this.class14_0.DataColumn_23] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_44()
		{
			return base.IsNull(this.class14_0.DataColumn_24);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_45()
		{
			base[this.class14_0.DataColumn_24] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_46()
		{
			return base.IsNull(this.class14_0.DataColumn_25);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_47()
		{
			base[this.class14_0.DataColumn_25] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_48()
		{
			return base.IsNull(this.class14_0.DataColumn_26);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_49()
		{
			base[this.class14_0.DataColumn_26] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_50()
		{
			return base.IsNull(this.class14_0.DataColumn_27);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_51()
		{
			base[this.class14_0.DataColumn_27] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_52()
		{
			return base.IsNull(this.class14_0.DataColumn_28);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_53()
		{
			base[this.class14_0.DataColumn_28] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_54()
		{
			return base.IsNull(this.class14_0.DataColumn_29);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_55()
		{
			base[this.class14_0.DataColumn_29] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_56()
		{
			return base.IsNull(this.class14_0.DataColumn_30);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_57()
		{
			base[this.class14_0.DataColumn_30] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_58()
		{
			return base.IsNull(this.class14_0.DataColumn_32);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_59()
		{
			base[this.class14_0.DataColumn_32] = Convert.DBNull;
		}

		private Class3.Class14 class14_0;
	}

	public class Class29 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class29(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class15_0 = (Class3.Class15)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idDamage
		{
			get
			{
				return (int)base[this.class15_0.DataColumn_0];
			}
			set
			{
				base[this.class15_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Int32_0
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class15_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idTypeRZA' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CountSchmObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class15_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CountSchmObj' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CountSchmObjOff
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class15_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CountSchmObjOff' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal ConnectedPower
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class15_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ConnectedPower' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal CoefFI
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class15_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoefFI' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal NoAdmissionKWT
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class15_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NoAdmissionKWT' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool AVR
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class15_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AVR' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool APR
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class15_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'APR' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal PowerA
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class15_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PowerA' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal PowerV
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class15_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PowerV' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoefSeason
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class15_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoefSeason' in table 'tJ_DamageHV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class15_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class15_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class15_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class15_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class15_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class15_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class15_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class15_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class15_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class15_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class15_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class15_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void aYoAgUeaHD()
		{
			base[this.class15_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_11()
		{
			return base.IsNull(this.class15_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_12()
		{
			base[this.class15_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_13()
		{
			return base.IsNull(this.class15_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_14()
		{
			base[this.class15_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_15()
		{
			return base.IsNull(this.class15_0.DataColumn_9);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_16()
		{
			base[this.class15_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_17()
		{
			return base.IsNull(this.class15_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_18()
		{
			base[this.class15_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_19()
		{
			return base.IsNull(this.class15_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_20()
		{
			base[this.class15_0.DataColumn_11] = Convert.DBNull;
		}

		private Class3.Class15 class15_0;
	}

	public class Class30 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class30(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class16_0 = (Class3.Class16)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idDamage
		{
			get
			{
				return (int)base[this.class16_0.DataColumn_0];
			}
			set
			{
				base[this.class16_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Declarer
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class16_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Declarer' in table 'tJ_DamageLV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class16_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string DeclarerTel
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class16_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DeclarerTel' in table 'tJ_DamageLV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class16_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string DeclarerAddress
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class16_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DeclarerAddress' in table 'tJ_DamageLV' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class16_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class16_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class16_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class16_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class16_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class16_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class16_0.DataColumn_3] = Convert.DBNull;
		}

		private Class3.Class16 class16_0;
	}

	public class Class31 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class31(DataRowBuilder dataRowBuilder_0)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(dataRowBuilder_0);
			this.class17_0 = (Class3.Class17)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class17_0.DataColumn_0];
			}
			set
			{
				base[this.class17_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idRequest
		{
			get
			{
				return (int)base[this.class17_0.DataColumn_1];
			}
			set
			{
				base[this.class17_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateLog
		{
			get
			{
				return (DateTime)base[this.class17_0.DataColumn_2];
			}
			set
			{
				base[this.class17_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int userLogID
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class17_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'userLogID' in table 'tJ_RequestForRepairLog' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class17_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string userLog
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class17_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'userLog' in table 'tJ_RequestForRepairLog' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class17_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string userLogName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class17_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'userLogName' in table 'tJ_RequestForRepairLog' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class17_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idCommand
		{
			get
			{
				return (int)base[this.class17_0.DataColumn_6];
			}
			set
			{
				base[this.class17_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Command
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class17_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Command' in table 'tJ_RequestForRepairLog' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class17_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool isSite
		{
			get
			{
				return (bool)base[this.class17_0.DataColumn_8];
			}
			set
			{
				base[this.class17_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class17_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class17_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class17_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class17_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class17_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class17_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class17_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class17_0.DataColumn_7] = Convert.DBNull;
		}

		private Class3.Class17 class17_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs0 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs0(Class3.Class18 class18_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class18_0 = class18_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class18 Row
		{
			get
			{
				return this.class18_0;
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

		private Class3.Class18 class18_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs1 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs1(Class3.Class19 class19_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class19_0 = class19_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class19 Row
		{
			get
			{
				return this.class19_0;
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

		private Class3.Class19 class19_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs2 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs2(Class3.Class20 class20_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class20_0 = class20_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class20 Row
		{
			get
			{
				return this.class20_0;
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

		private Class3.Class20 class20_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs3 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs3(Class3.Class21 class21_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class21_0 = class21_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class21 Row
		{
			get
			{
				return this.class21_0;
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

		private Class3.Class21 class21_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs4 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs4(Class3.Class22 class22_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class22_0 = class22_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class22 Row
		{
			get
			{
				return this.class22_0;
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

		private Class3.Class22 class22_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs5 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs5(Class3.Class23 class23_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class23_0 = class23_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class23 Row
		{
			get
			{
				return this.class23_0;
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

		private Class3.Class23 class23_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs6 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs6(Class3.Class24 class24_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class24_0 = class24_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class24 Row
		{
			get
			{
				return this.class24_0;
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

		private Class3.Class24 class24_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs7 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs7(Class3.Class25 class25_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class25_0 = class25_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class25 Row
		{
			get
			{
				return this.class25_0;
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

		private Class3.Class25 class25_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs8 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs8(Class3.Class26 class26_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class26_0 = class26_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class26 Row
		{
			get
			{
				return this.class26_0;
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

		private Class3.Class26 class26_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs9 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs9(Class3.Class27 class27_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class27_0 = class27_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class27 Row
		{
			get
			{
				return this.class27_0;
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

		private Class3.Class27 class27_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs10 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs10(Class3.Class28 class28_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class28_0 = class28_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class28 Row
		{
			get
			{
				return this.class28_0;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataRowAction xhwKufqhQi
		{
			get
			{
				return this.dataRowAction_0;
			}
		}

		private Class3.Class28 class28_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs11 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs11(Class3.Class29 class29_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class29_0 = class29_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class29 Row
		{
			get
			{
				return this.class29_0;
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

		private Class3.Class29 class29_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs12 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs12(Class3.Class30 class30_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class30_0 = class30_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class3.Class30 Row
		{
			get
			{
				return this.class30_0;
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

		private Class3.Class30 class30_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs13 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs13(Class3.Class31 class31_1, DataRowAction dataRowAction_1)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.class31_0 = class31_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class3.Class31 Row
		{
			get
			{
				return this.class31_0;
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

		private Class3.Class31 class31_0;

		private DataRowAction dataRowAction_0;
	}
}
