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
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("DataSetExcavation")]
[HelpKeyword("vs.data.DataSet")]
[Serializable]
internal class DataSetExcavation : DataSet
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataSetExcavation()
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		
		base.BeginInit();
		this.method_2();
		CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_20);
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		base.EndInit();
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected DataSetExcavation(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		base..ctor(serializationInfo_0, streamingContext_0, false);
		if (base.IsBinarySerialized(serializationInfo_0, streamingContext_0))
		{
			this.method_1(false);
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_20);
			this.DataTableCollection_0.CollectionChanged += value;
			this.DataRelationCollection_0.CollectionChanged += value;
			return;
		}
		string s = (string)serializationInfo_0.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(serializationInfo_0, streamingContext_0) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["tJ_ExcavationAddress"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class131(dataSet.Tables["tJ_ExcavationAddress"]));
			}
			if (dataSet.Tables["tJ_ExcavationSurface"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class132(dataSet.Tables["tJ_ExcavationSurface"]));
			}
			if (dataSet.Tables["tR_Classifier"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class133(dataSet.Tables["tR_Classifier"]));
			}
			if (dataSet.Tables["vJ_ExcavationAddress"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class134(dataSet.Tables["vJ_ExcavationAddress"]));
			}
			if (dataSet.Tables["tJ_Excavation"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class135(dataSet.Tables["tJ_Excavation"]));
			}
			if (dataSet.Tables["tAbn"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class136(dataSet.Tables["tAbn"]));
			}
			if (dataSet.Tables["tAbnType"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class137(dataSet.Tables["tAbnType"]));
			}
			if (dataSet.Tables["vJ_Excavation"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class138(dataSet.Tables["vJ_Excavation"]));
			}
			if (dataSet.Tables["vJ_ExcavationSchmObj"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class139(dataSet.Tables["vJ_ExcavationSchmObj"]));
			}
			if (dataSet.Tables["tJ_ExcavationSchmObj"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class140(dataSet.Tables["tJ_ExcavationSchmObj"]));
			}
			if (dataSet.Tables["tJ_ExcavationStatus"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class141(dataSet.Tables["tJ_ExcavationStatus"]));
			}
			if (dataSet.Tables["vJ_ExcavationStatus"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class142(dataSet.Tables["vJ_ExcavationStatus"]));
			}
			if (dataSet.Tables["vJ_ExcavationSurface"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class143(dataSet.Tables["vJ_ExcavationSurface"]));
			}
			if (dataSet.Tables["tJ_ExcavationFile"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class144(dataSet.Tables["tJ_ExcavationFile"]));
			}
			if (dataSet.Tables["vJ_ExcavationFile"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class145(dataSet.Tables["vJ_ExcavationFile"]));
			}
			if (dataSet.Tables["vR_KladrStreet"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class146(dataSet.Tables["vR_KladrStreet"]));
			}
			if (dataSet.Tables["vAbnType"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class147(dataSet.Tables["vAbnType"]));
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
		CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_20);
		base.Tables.CollectionChanged += value2;
		this.DataRelationCollection_0.CollectionChanged += value2;
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataSetExcavation.Class131 tJ_ExcavationAddress
	{
		get
		{
			return this.class131_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public DataSetExcavation.Class132 tJ_ExcavationSurface
	{
		get
		{
			return this.class132_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public DataSetExcavation.Class133 tR_Classifier
	{
		get
		{
			return this.class133_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public DataSetExcavation.Class134 vJ_ExcavationAddress
	{
		get
		{
			return this.class134_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public DataSetExcavation.Class135 tJ_Excavation
	{
		get
		{
			return this.class135_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public DataSetExcavation.Class136 tAbn
	{
		get
		{
			return this.class136_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public DataSetExcavation.Class137 tAbnType
	{
		get
		{
			return this.class137_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public DataSetExcavation.Class138 vJ_Excavation
	{
		get
		{
			return this.class138_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public DataSetExcavation.Class139 vJ_ExcavationSchmObj
	{
		get
		{
			return this.class139_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public DataSetExcavation.Class140 tJ_ExcavationSchmObj
	{
		get
		{
			return this.class140_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataSetExcavation.Class141 tJ_ExcavationStatus
	{
		get
		{
			return this.class141_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataSetExcavation.Class142 vJ_ExcavationStatus
	{
		get
		{
			return this.class142_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataSetExcavation.Class143 vJ_ExcavationSurface
	{
		get
		{
			return this.class143_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataSetExcavation.Class144 tJ_ExcavationFile
	{
		get
		{
			return this.class144_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataSetExcavation.Class145 vJ_ExcavationFile
	{
		get
		{
			return this.class145_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataSetExcavation.Class146 vR_KladrStreet
	{
		get
		{
			return this.class146_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public DataSetExcavation.Class147 vAbnType
	{
		get
		{
			return this.class147_0;
		}
	}

	[Browsable(true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DebuggerNonUserCode]
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
		DataSetExcavation @class = (DataSetExcavation)base.Clone();
		@class.method_0();
		@class.SchemaSerializationMode = this.SchemaSerializationMode;
		return @class;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
			if (dataSet.Tables["tJ_ExcavationAddress"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class131(dataSet.Tables["tJ_ExcavationAddress"]));
			}
			if (dataSet.Tables["tJ_ExcavationSurface"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class132(dataSet.Tables["tJ_ExcavationSurface"]));
			}
			if (dataSet.Tables["tR_Classifier"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class133(dataSet.Tables["tR_Classifier"]));
			}
			if (dataSet.Tables["vJ_ExcavationAddress"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class134(dataSet.Tables["vJ_ExcavationAddress"]));
			}
			if (dataSet.Tables["tJ_Excavation"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class135(dataSet.Tables["tJ_Excavation"]));
			}
			if (dataSet.Tables["tAbn"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class136(dataSet.Tables["tAbn"]));
			}
			if (dataSet.Tables["tAbnType"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class137(dataSet.Tables["tAbnType"]));
			}
			if (dataSet.Tables["vJ_Excavation"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class138(dataSet.Tables["vJ_Excavation"]));
			}
			if (dataSet.Tables["vJ_ExcavationSchmObj"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class139(dataSet.Tables["vJ_ExcavationSchmObj"]));
			}
			if (dataSet.Tables["tJ_ExcavationSchmObj"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class140(dataSet.Tables["tJ_ExcavationSchmObj"]));
			}
			if (dataSet.Tables["tJ_ExcavationStatus"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class141(dataSet.Tables["tJ_ExcavationStatus"]));
			}
			if (dataSet.Tables["vJ_ExcavationStatus"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class142(dataSet.Tables["vJ_ExcavationStatus"]));
			}
			if (dataSet.Tables["vJ_ExcavationSurface"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class143(dataSet.Tables["vJ_ExcavationSurface"]));
			}
			if (dataSet.Tables["tJ_ExcavationFile"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class144(dataSet.Tables["tJ_ExcavationFile"]));
			}
			if (dataSet.Tables["vJ_ExcavationFile"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class145(dataSet.Tables["vJ_ExcavationFile"]));
			}
			if (dataSet.Tables["vR_KladrStreet"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class146(dataSet.Tables["vR_KladrStreet"]));
			}
			if (dataSet.Tables["vAbnType"] != null)
			{
				base.Tables.Add(new DataSetExcavation.Class147(dataSet.Tables["vAbnType"]));
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal void method_1(bool bool_0)
	{
		this.class131_0 = (DataSetExcavation.Class131)base.Tables["tJ_ExcavationAddress"];
		if (bool_0 && this.class131_0 != null)
		{
			this.class131_0.method_3();
		}
		this.class132_0 = (DataSetExcavation.Class132)base.Tables["tJ_ExcavationSurface"];
		if (bool_0 && this.class132_0 != null)
		{
			this.class132_0.method_3();
		}
		this.class133_0 = (DataSetExcavation.Class133)base.Tables["tR_Classifier"];
		if (bool_0 && this.class133_0 != null)
		{
			this.class133_0.method_3();
		}
		this.class134_0 = (DataSetExcavation.Class134)base.Tables["vJ_ExcavationAddress"];
		if (bool_0 && this.class134_0 != null)
		{
			this.class134_0.method_3();
		}
		this.class135_0 = (DataSetExcavation.Class135)base.Tables["tJ_Excavation"];
		if (bool_0 && this.class135_0 != null)
		{
			this.class135_0.method_3();
		}
		this.class136_0 = (DataSetExcavation.Class136)base.Tables["tAbn"];
		if (bool_0 && this.class136_0 != null)
		{
			this.class136_0.method_3();
		}
		this.class137_0 = (DataSetExcavation.Class137)base.Tables["tAbnType"];
		if (bool_0 && this.class137_0 != null)
		{
			this.class137_0.method_3();
		}
		this.class138_0 = (DataSetExcavation.Class138)base.Tables["vJ_Excavation"];
		if (bool_0 && this.class138_0 != null)
		{
			this.class138_0.method_2();
		}
		this.class139_0 = (DataSetExcavation.Class139)base.Tables["vJ_ExcavationSchmObj"];
		if (bool_0 && this.class139_0 != null)
		{
			this.class139_0.method_3();
		}
		this.class140_0 = (DataSetExcavation.Class140)base.Tables["tJ_ExcavationSchmObj"];
		if (bool_0 && this.class140_0 != null)
		{
			this.class140_0.method_3();
		}
		this.class141_0 = (DataSetExcavation.Class141)base.Tables["tJ_ExcavationStatus"];
		if (bool_0 && this.class141_0 != null)
		{
			this.class141_0.method_3();
		}
		this.class142_0 = (DataSetExcavation.Class142)base.Tables["vJ_ExcavationStatus"];
		if (bool_0 && this.class142_0 != null)
		{
			this.class142_0.method_3();
		}
		this.class143_0 = (DataSetExcavation.Class143)base.Tables["vJ_ExcavationSurface"];
		if (bool_0 && this.class143_0 != null)
		{
			this.class143_0.method_3();
		}
		this.class144_0 = (DataSetExcavation.Class144)base.Tables["tJ_ExcavationFile"];
		if (bool_0 && this.class144_0 != null)
		{
			this.class144_0.method_3();
		}
		this.class145_0 = (DataSetExcavation.Class145)base.Tables["vJ_ExcavationFile"];
		if (bool_0 && this.class145_0 != null)
		{
			this.class145_0.method_3();
		}
		this.class146_0 = (DataSetExcavation.Class146)base.Tables["vR_KladrStreet"];
		if (bool_0 && this.class146_0 != null)
		{
			this.class146_0.method_3();
		}
		this.class147_0 = (DataSetExcavation.Class147)base.Tables["vAbnType"];
		if (bool_0 && this.class147_0 != null)
		{
			this.class147_0.method_2();
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_2()
	{
		base.DataSetName = "DataSetExcavation";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/DataSetExcavation.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class131_0 = new DataSetExcavation.Class131();
		base.Tables.Add(this.class131_0);
		this.class132_0 = new DataSetExcavation.Class132();
		base.Tables.Add(this.class132_0);
		this.class133_0 = new DataSetExcavation.Class133();
		base.Tables.Add(this.class133_0);
		this.class134_0 = new DataSetExcavation.Class134();
		base.Tables.Add(this.class134_0);
		this.class135_0 = new DataSetExcavation.Class135();
		base.Tables.Add(this.class135_0);
		this.class136_0 = new DataSetExcavation.Class136();
		base.Tables.Add(this.class136_0);
		this.class137_0 = new DataSetExcavation.Class137();
		base.Tables.Add(this.class137_0);
		this.class138_0 = new DataSetExcavation.Class138();
		base.Tables.Add(this.class138_0);
		this.class139_0 = new DataSetExcavation.Class139();
		base.Tables.Add(this.class139_0);
		this.class140_0 = new DataSetExcavation.Class140();
		base.Tables.Add(this.class140_0);
		this.class141_0 = new DataSetExcavation.Class141();
		base.Tables.Add(this.class141_0);
		this.class142_0 = new DataSetExcavation.Class142();
		base.Tables.Add(this.class142_0);
		this.class143_0 = new DataSetExcavation.Class143();
		base.Tables.Add(this.class143_0);
		this.class144_0 = new DataSetExcavation.Class144();
		base.Tables.Add(this.class144_0);
		this.class145_0 = new DataSetExcavation.Class145();
		base.Tables.Add(this.class145_0);
		this.class146_0 = new DataSetExcavation.Class146();
		base.Tables.Add(this.class146_0);
		this.class147_0 = new DataSetExcavation.Class147();
		base.Tables.Add(this.class147_0);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_7()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_8()
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
	private bool method_16()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_17()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_18()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_19()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_20(object sender, CollectionChangeEventArgs e)
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
		DataSetExcavation @class = new DataSetExcavation();
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

	private DataSetExcavation.Class131 class131_0;

	private DataSetExcavation.Class132 class132_0;

	private DataSetExcavation.Class133 class133_0;

	private DataSetExcavation.Class134 class134_0;

	private DataSetExcavation.Class135 class135_0;

	private DataSetExcavation.Class136 class136_0;

	private DataSetExcavation.Class137 class137_0;

	private DataSetExcavation.Class138 class138_0;

	private DataSetExcavation.Class139 class139_0;

	private DataSetExcavation.Class140 class140_0;

	private DataSetExcavation.Class141 class141_0;

	private DataSetExcavation.Class142 class142_0;

	private DataSetExcavation.Class143 class143_0;

	private DataSetExcavation.Class144 class144_0;

	private DataSetExcavation.Class145 class145_0;

	private DataSetExcavation.Class146 class146_0;

	private DataSetExcavation.Class147 class147_0;

	private SchemaSerializationMode schemaSerializationMode_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate55(object sender, DataSetExcavation.EventArgs54 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate56(object sender, DataSetExcavation.EventArgs55 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate57(object sender, DataSetExcavation.EventArgs56 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate58(object sender, DataSetExcavation.EventArgs57 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate59(object sender, DataSetExcavation.EventArgs58 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate60(object sender, DataSetExcavation.EventArgs59 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate61(object sender, DataSetExcavation.EventArgs60 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate62(object sender, DataSetExcavation.EventArgs61 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate63(object sender, DataSetExcavation.EventArgs62 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate64(object sender, DataSetExcavation.EventArgs63 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate65(object sender, DataSetExcavation.EventArgs64 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate66(object sender, DataSetExcavation.EventArgs65 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate67(object sender, DataSetExcavation.EventArgs66 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate68(object sender, DataSetExcavation.EventArgs67 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate69(object sender, DataSetExcavation.EventArgs68 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate70(object sender, DataSetExcavation.EventArgs69 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate71(object sender, DataSetExcavation.EventArgs70 e);

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class131 : TypedTableBase<DataSetExcavation.Class148>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class131()
		{
			
			
			base.TableName = "tJ_ExcavationAddress";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class131(DataTable dataTable_0)
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
		protected Class131(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn idColumn
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
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
		public DataSetExcavation.Class148 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class148)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate55 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_0;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_0;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate55 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_1;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_1;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate55 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_2;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_2;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate55 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_3;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate55 @delegate = this.delegate55_3;
				DataSetExcavation.Delegate55 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate55 value2 = (DataSetExcavation.Delegate55)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate55>(ref this.delegate55_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class148 class148_0)
		{
			base.Rows.Add(class148_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class148 method_1(int int_0, int int_1, int int_2, string string_0, string string_1)
		{
			DataSetExcavation.Class148 @class = (DataSetExcavation.Class148)base.NewRow();
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class148 method_2(int int_0)
		{
			return (DataSetExcavation.Class148)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			DataSetExcavation.Class131 @class = (DataSetExcavation.Class131)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class131();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["idRegion"];
			this.dataColumn_3 = base.Columns["idStreet"];
			this.dataColumn_4 = base.Columns["House"];
			this.dataColumn_5 = base.Columns["Comment"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idRegion", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idStreet", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("House", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
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
			this.dataColumn_5.MaxLength = 256;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class148 method_5()
		{
			return (DataSetExcavation.Class148)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class148(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class148);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate55_1 != null)
			{
				this.delegate55_1(this, new DataSetExcavation.EventArgs54((DataSetExcavation.Class148)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate55_0 != null)
			{
				this.delegate55_0(this, new DataSetExcavation.EventArgs54((DataSetExcavation.Class148)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate55_3 != null)
			{
				this.delegate55_3(this, new DataSetExcavation.EventArgs54((DataSetExcavation.Class148)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate55_2 != null)
			{
				this.delegate55_2(this, new DataSetExcavation.EventArgs54((DataSetExcavation.Class148)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(DataSetExcavation.Class148 class148_0)
		{
			base.Rows.Remove(class148_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "tJ_ExcavationAddressDataTable";
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
		private DataSetExcavation.Delegate55 delegate55_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate55 delegate55_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate55 delegate55_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate55 delegate55_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class132 : TypedTableBase<DataSetExcavation.Class149>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class132()
		{
			
			
			base.TableName = "tJ_ExcavationSurface";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class132(DataTable dataTable_0)
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
		protected Class132(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
				return this.NcaZyyNvYkM;
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
		public DataColumn DataColumn_4
		{
			get
			{
				return this.eavZymEnaDZ;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_4;
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
		public DataSetExcavation.Class149 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class149)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate56 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_0;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_0;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate56 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_1;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_1;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate56 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_2;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_2;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate56 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_3;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate56 @delegate = this.delegate56_3;
				DataSetExcavation.Delegate56 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate56 value2 = (DataSetExcavation.Delegate56)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate56>(ref this.delegate56_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class149 class149_0)
		{
			base.Rows.Add(class149_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class149 method_1(int int_0, int int_1, int int_2, double double_0, string string_0, string string_1)
		{
			DataSetExcavation.Class149 @class = (DataSetExcavation.Class149)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				int_2,
				double_0,
				string_0,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class149 method_2(int int_0)
		{
			return (DataSetExcavation.Class149)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class132 @class = (DataSetExcavation.Class132)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class132();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.NcaZyyNvYkM = base.Columns["idType"];
			this.dataColumn_2 = base.Columns["idSurface"];
			this.dataColumn_3 = base.Columns["Value"];
			this.eavZymEnaDZ = base.Columns["unit"];
			this.dataColumn_4 = base.Columns["comment"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.NcaZyyNvYkM = new DataColumn("idType", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.NcaZyyNvYkM);
			this.dataColumn_2 = new DataColumn("idSurface", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Value", typeof(double), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.eavZymEnaDZ = new DataColumn("unit", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.eavZymEnaDZ);
			this.dataColumn_4 = new DataColumn("comment", typeof(string), null, MappingType.Element);
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
			this.NcaZyyNvYkM.AllowDBNull = false;
			this.dataColumn_2.AllowDBNull = false;
			this.eavZymEnaDZ.MaxLength = 10;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class149 method_5()
		{
			return (DataSetExcavation.Class149)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class149(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class149);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate56_1 != null)
			{
				this.delegate56_1(this, new DataSetExcavation.EventArgs55((DataSetExcavation.Class149)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate56_0 != null)
			{
				this.delegate56_0(this, new DataSetExcavation.EventArgs55((DataSetExcavation.Class149)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate56_3 != null)
			{
				this.delegate56_3(this, new DataSetExcavation.EventArgs55((DataSetExcavation.Class149)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate56_2 != null)
			{
				this.delegate56_2(this, new DataSetExcavation.EventArgs55((DataSetExcavation.Class149)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class149 class149_0)
		{
			base.Rows.Remove(class149_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "tJ_ExcavationSurfaceDataTable";
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

		private DataColumn NcaZyyNvYkM;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataColumn eavZymEnaDZ;

		private DataColumn dataColumn_4;

		[CompilerGenerated]
		private DataSetExcavation.Delegate56 delegate56_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate56 delegate56_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate56 delegate56_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate56 delegate56_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class133 : TypedTableBase<DataSetExcavation.Class150>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class133()
		{
			
			
			base.TableName = "tR_Classifier";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class133(DataTable dataTable_0)
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
		protected Class133(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
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
		public DataColumn fovZyJiCboO
		{
			get
			{
				return this.dataColumn_1;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn JdlZyIosdQH
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn BdmZyOgdnco
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_9;
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class150 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class150)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate57 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_0;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_0;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate57 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_1;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_1;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate57 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_2;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_2;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate57 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_3;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate57 @delegate = this.delegate57_3;
				DataSetExcavation.Delegate57 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate57 value2 = (DataSetExcavation.Delegate57)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate57>(ref this.delegate57_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(DataSetExcavation.Class150 class150_0)
		{
			base.Rows.Add(class150_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class150 method_1(string string_0, string string_1, decimal decimal_0, string string_2, int int_0, string string_3, byte[] byte_0, bool bool_0, bool bool_1)
		{
			DataSetExcavation.Class150 @class = (DataSetExcavation.Class150)base.NewRow();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class150 method_2(int int_0)
		{
			return (DataSetExcavation.Class150)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			DataSetExcavation.Class133 @class = (DataSetExcavation.Class133)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class133();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class150 method_5()
		{
			return (DataSetExcavation.Class150)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class150(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class150);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate57_1 != null)
			{
				this.delegate57_1(this, new DataSetExcavation.EventArgs56((DataSetExcavation.Class150)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate57_0 != null)
			{
				this.delegate57_0(this, new DataSetExcavation.EventArgs56((DataSetExcavation.Class150)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate57_3 != null)
			{
				this.delegate57_3(this, new DataSetExcavation.EventArgs56((DataSetExcavation.Class150)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate57_2 != null)
			{
				this.delegate57_2(this, new DataSetExcavation.EventArgs56((DataSetExcavation.Class150)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class150 class150_0)
		{
			base.Rows.Remove(class150_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
		private DataSetExcavation.Delegate57 delegate57_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate57 delegate57_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate57 delegate57_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate57 delegate57_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class134 : TypedTableBase<DataSetExcavation.Class151>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class134()
		{
			
			
			base.TableName = "vJ_ExcavationAddress";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class134(DataTable dataTable_0)
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
		protected Class134(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_6
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class151 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class151)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate58 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_0;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_0;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate58 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_1;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_1;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate58 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_2;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_2;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate58 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_3;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate58 @delegate = this.delegate58_3;
				DataSetExcavation.Delegate58 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate58 value2 = (DataSetExcavation.Delegate58)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate58>(ref this.delegate58_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class151 class151_0)
		{
			base.Rows.Add(class151_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class151 method_1(int int_0, int int_1, int int_2, int int_3, string string_0, string string_1, string string_2, string string_3)
		{
			DataSetExcavation.Class151 @class = (DataSetExcavation.Class151)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				int_3,
				string_0,
				string_1,
				string_2,
				string_3
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class151 method_2(int int_0)
		{
			return (DataSetExcavation.Class151)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class134 @class = (DataSetExcavation.Class134)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class134();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["idRegion"];
			this.dataColumn_3 = base.Columns["idStreet"];
			this.dataColumn_4 = base.Columns["House"];
			this.dataColumn_5 = base.Columns["Comment"];
			this.dataColumn_6 = base.Columns["region"];
			this.dataColumn_7 = base.Columns["street"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idRegion", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idStreet", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("House", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("region", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("street", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_4.MaxLength = 50;
			this.dataColumn_5.MaxLength = 256;
			this.dataColumn_6.MaxLength = 100;
			this.dataColumn_7.ReadOnly = true;
			this.dataColumn_7.MaxLength = 91;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class151 method_5()
		{
			return (DataSetExcavation.Class151)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class151(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class151);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate58_1 != null)
			{
				this.delegate58_1(this, new DataSetExcavation.EventArgs57((DataSetExcavation.Class151)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate58_0 != null)
			{
				this.delegate58_0(this, new DataSetExcavation.EventArgs57((DataSetExcavation.Class151)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate58_3 != null)
			{
				this.delegate58_3(this, new DataSetExcavation.EventArgs57((DataSetExcavation.Class151)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate58_2 != null)
			{
				this.delegate58_2(this, new DataSetExcavation.EventArgs57((DataSetExcavation.Class151)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(DataSetExcavation.Class151 class151_0)
		{
			base.Rows.Remove(class151_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vJ_ExcavationAddressDataTable";
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
		private DataSetExcavation.Delegate58 delegate58_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate58 delegate58_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate58 delegate58_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate58 delegate58_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class135 : TypedTableBase<DataSetExcavation.Class152>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class135()
		{
			
			
			base.TableName = "tJ_Excavation";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class135(DataTable dataTable_0)
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
		protected Class135(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_8
		{
			get
			{
				return this.dataColumn_9;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_9
		{
			get
			{
				return this.dataColumn_10;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_10
		{
			get
			{
				return this.dataColumn_11;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_15
		{
			get
			{
				return this.dataColumn_16;
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
		public DataSetExcavation.Class152 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class152)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate59 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_0;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_0;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate59 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_1;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_1;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate59 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_2;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_2;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate59 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_3;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate59 @delegate = this.delegate59_3;
				DataSetExcavation.Delegate59 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate59 value2 = (DataSetExcavation.Delegate59)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate59>(ref this.delegate59_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(DataSetExcavation.Class152 class152_0)
		{
			base.Rows.Add(class152_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class152 method_1(int int_0, DateTime dateTime_0, int int_1, int int_2, DateTime dateTime_1, DateTime dateTime_2, string string_0, DateTime dateTime_3, DateTime dateTime_4, DateTime dateTime_5, DateTime dateTime_6, DateTime dateTime_7, bool bool_0, DateTime dateTime_8, int int_3, int int_4)
		{
			DataSetExcavation.Class152 @class = (DataSetExcavation.Class152)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				dateTime_0,
				int_1,
				int_2,
				dateTime_1,
				dateTime_2,
				string_0,
				dateTime_3,
				dateTime_4,
				dateTime_5,
				dateTime_6,
				dateTime_7,
				bool_0,
				dateTime_8,
				int_3,
				int_4
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class152 method_2(int int_0)
		{
			return (DataSetExcavation.Class152)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class135 @class = (DataSetExcavation.Class135)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class135();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["num"];
			this.dataColumn_2 = base.Columns["dateBeg"];
			this.dataColumn_3 = base.Columns["idContractor"];
			this.dataColumn_4 = base.Columns["TypeWork"];
			this.dataColumn_5 = base.Columns["dateBegOrder"];
			this.dataColumn_6 = base.Columns["dateEndOrder"];
			this.dataColumn_7 = base.Columns["NumPermission"];
			this.dataColumn_8 = base.Columns["DatePermission"];
			this.dataColumn_9 = base.Columns["dateUnderAsphalt"];
			this.dataColumn_10 = base.Columns["dateAsphalt"];
			this.dataColumn_11 = base.Columns["dateEnd"];
			this.dataColumn_12 = base.Columns["datePay"];
			this.dataColumn_13 = base.Columns["agreed"];
			this.dataColumn_14 = base.Columns["dateagreed"];
			this.dataColumn_15 = base.Columns["workeragreed"];
			this.dataColumn_16 = base.Columns["idSR"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("num", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("dateBeg", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idContractor", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("TypeWork", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("dateBegOrder", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("dateEndOrder", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("NumPermission", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("DatePermission", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("dateUnderAsphalt", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("dateAsphalt", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("dateEnd", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("datePay", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("agreed", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("dateagreed", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("workeragreed", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("idSR", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
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
			this.dataColumn_7.MaxLength = 20;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class152 method_5()
		{
			return (DataSetExcavation.Class152)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class152(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class152);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate59_1 != null)
			{
				this.delegate59_1(this, new DataSetExcavation.EventArgs58((DataSetExcavation.Class152)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate59_0 != null)
			{
				this.delegate59_0(this, new DataSetExcavation.EventArgs58((DataSetExcavation.Class152)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate59_3 != null)
			{
				this.delegate59_3(this, new DataSetExcavation.EventArgs58((DataSetExcavation.Class152)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate59_2 != null)
			{
				this.delegate59_2(this, new DataSetExcavation.EventArgs58((DataSetExcavation.Class152)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(DataSetExcavation.Class152 class152_0)
		{
			base.Rows.Remove(class152_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "tJ_ExcavationDataTable";
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

		[CompilerGenerated]
		private DataSetExcavation.Delegate59 delegate59_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate59 delegate59_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate59 delegate59_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate59 delegate59_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class136 : TypedTableBase<DataSetExcavation.Class153>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class136()
		{
			
			
			base.TableName = "tAbn";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class136(DataTable dataTable_0)
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
		protected Class136(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataSetExcavation.Class153 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class153)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate60 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_0;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_0;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate60 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_1;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_1;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate60 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_2;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_2;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate60 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_3;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate60 @delegate = this.delegate60_3;
				DataSetExcavation.Delegate60 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate60 value2 = (DataSetExcavation.Delegate60)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate60>(ref this.delegate60_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class153 class153_0)
		{
			base.Rows.Add(class153_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class153 method_1(int int_0, string string_0, int int_1, int int_2, bool bool_0)
		{
			DataSetExcavation.Class153 @class = (DataSetExcavation.Class153)base.NewRow();
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
		public DataSetExcavation.Class153 method_2(int int_0)
		{
			return (DataSetExcavation.Class153)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class136 @class = (DataSetExcavation.Class136)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class136();
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataSetExcavation.Class153 method_5()
		{
			return (DataSetExcavation.Class153)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class153(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class153);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate60_1 != null)
			{
				this.delegate60_1(this, new DataSetExcavation.EventArgs59((DataSetExcavation.Class153)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate60_0 != null)
			{
				this.delegate60_0(this, new DataSetExcavation.EventArgs59((DataSetExcavation.Class153)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate60_3 != null)
			{
				this.delegate60_3(this, new DataSetExcavation.EventArgs59((DataSetExcavation.Class153)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate60_2 != null)
			{
				this.delegate60_2(this, new DataSetExcavation.EventArgs59((DataSetExcavation.Class153)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(DataSetExcavation.Class153 class153_0)
		{
			base.Rows.Remove(class153_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
		private DataSetExcavation.Delegate60 delegate60_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate60 delegate60_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate60 delegate60_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate60 delegate60_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class137 : TypedTableBase<DataSetExcavation.Class154>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class137()
		{
			
			
			base.TableName = "tAbnType";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class137(DataTable dataTable_0)
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
		protected Class137(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataSetExcavation.Class154 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class154)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate61 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_0;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_0;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate61 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_1;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_1;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate61 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_2;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_2;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate61 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_3;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate61 @delegate = this.delegate61_3;
				DataSetExcavation.Delegate61 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate61 value2 = (DataSetExcavation.Delegate61)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate61>(ref this.delegate61_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class154 class154_0)
		{
			base.Rows.Add(class154_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class154 method_1(int int_0, int int_1)
		{
			DataSetExcavation.Class154 @class = (DataSetExcavation.Class154)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class154 method_2(int int_0)
		{
			return (DataSetExcavation.Class154)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class137 @class = (DataSetExcavation.Class137)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class137();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idAbn"];
			this.dataColumn_2 = base.Columns["typeKontragent"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("typeKontragent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class154 method_5()
		{
			return (DataSetExcavation.Class154)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class154(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class154);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate61_1 != null)
			{
				this.delegate61_1(this, new DataSetExcavation.EventArgs60((DataSetExcavation.Class154)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate61_0 != null)
			{
				this.delegate61_0(this, new DataSetExcavation.EventArgs60((DataSetExcavation.Class154)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate61_3 != null)
			{
				this.delegate61_3(this, new DataSetExcavation.EventArgs60((DataSetExcavation.Class154)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate61_2 != null)
			{
				this.delegate61_2(this, new DataSetExcavation.EventArgs60((DataSetExcavation.Class154)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class154 class154_0)
		{
			base.Rows.Remove(class154_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "tAbnTypeDataTable";
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

		[CompilerGenerated]
		private DataSetExcavation.Delegate61 delegate61_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate61 delegate61_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate61 delegate61_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate61 delegate61_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class138 : TypedTableBase<DataSetExcavation.Class155>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class138()
		{
			
			
			base.TableName = "vJ_Excavation";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class138(DataTable dataTable_0)
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
		protected Class138(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_8
		{
			get
			{
				return this.dataColumn_9;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_11
		{
			get
			{
				return this.dataColumn_12;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_17
		{
			get
			{
				return this.dataColumn_18;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_20
		{
			get
			{
				return this.dataColumn_21;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_21
		{
			get
			{
				return this.dataColumn_22;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_24
		{
			get
			{
				return this.dataColumn_25;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_27
		{
			get
			{
				return this.dataColumn_28;
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
		public DataSetExcavation.Class155 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class155)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate62 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_0;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_0;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate62 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_1;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_1;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate62 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_2;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_2;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate62 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_3;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate62 @delegate = this.delegate62_3;
				DataSetExcavation.Delegate62 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate62 value2 = (DataSetExcavation.Delegate62)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate62>(ref this.delegate62_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(DataSetExcavation.Class155 class155_0)
		{
			base.Rows.Add(class155_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class155 method_1(int int_0, int int_1, DateTime dateTime_0, int int_2, string string_0, int int_3, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, DateTime dateTime_1, DateTime dateTime_2, string string_7, string string_8, DateTime dateTime_3, DateTime dateTime_4, DateTime dateTime_5, DateTime dateTime_6, DateTime dateTime_7, int int_4, bool bool_0, string string_9, int int_5, string string_10, DateTime dateTime_8, string string_11, string string_12)
		{
			DataSetExcavation.Class155 @class = (DataSetExcavation.Class155)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				dateTime_0,
				int_2,
				string_0,
				int_3,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5,
				string_6,
				dateTime_1,
				dateTime_2,
				string_7,
				string_8,
				dateTime_3,
				dateTime_4,
				dateTime_5,
				dateTime_6,
				dateTime_7,
				int_4,
				bool_0,
				string_9,
				int_5,
				string_10,
				dateTime_8,
				string_11,
				string_12
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class138 @class = (DataSetExcavation.Class138)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class138();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["num"];
			this.dataColumn_2 = base.Columns["datebeg"];
			this.dataColumn_3 = base.Columns["idcontractor"];
			this.dataColumn_4 = base.Columns["nameContractor"];
			this.dataColumn_5 = base.Columns["typework"];
			this.dataColumn_6 = base.Columns["typeWorkscr"];
			this.dataColumn_7 = base.Columns["typeWorkName"];
			this.dataColumn_8 = base.Columns["region"];
			this.dataColumn_9 = base.Columns["address"];
			this.dataColumn_10 = base.Columns["nameKL"];
			this.dataColumn_11 = base.Columns["statusOrder"];
			this.dataColumn_12 = base.Columns["dateBegOrder"];
			this.dataColumn_13 = base.Columns["dateEndOrder"];
			this.dataColumn_14 = base.Columns["Permission"];
			this.dataColumn_15 = base.Columns["StatusWork"];
			this.dataColumn_16 = base.Columns["dateUnderAsphalt"];
			this.dataColumn_17 = base.Columns["dateAsphalt"];
			this.dataColumn_18 = base.Columns["dateEnd"];
			this.dataColumn_19 = base.Columns["datePay"];
			this.dataColumn_20 = base.Columns["dateagreed"];
			this.dataColumn_21 = base.Columns["workeragreed"];
			this.dataColumn_22 = base.Columns["agreed"];
			this.dataColumn_23 = base.Columns["Damage"];
			this.dataColumn_24 = base.Columns["idSR"];
			this.dataColumn_25 = base.Columns["SR"];
			this.dataColumn_26 = base.Columns["dateEndPlanned"];
			this.dataColumn_27 = base.Columns["workComment"];
			this.dataColumn_28 = base.Columns["recovery"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("num", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("datebeg", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idcontractor", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("nameContractor", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("typework", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("typeWorkscr", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("typeWorkName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("region", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("address", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("nameKL", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("statusOrder", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("dateBegOrder", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("dateEndOrder", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("Permission", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("StatusWork", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("dateUnderAsphalt", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("dateAsphalt", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("dateEnd", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("datePay", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("dateagreed", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("workeragreed", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("agreed", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_23 = new DataColumn("Damage", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_23);
			this.dataColumn_24 = new DataColumn("idSR", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_24);
			this.dataColumn_25 = new DataColumn("SR", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_25);
			this.dataColumn_26 = new DataColumn("dateEndPlanned", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_26);
			this.dataColumn_27 = new DataColumn("workComment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_27);
			this.dataColumn_28 = new DataColumn("recovery", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_28);
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_4.MaxLength = 100;
			this.dataColumn_6.MaxLength = 50;
			this.dataColumn_7.MaxLength = 100;
			this.dataColumn_8.MaxLength = 100;
			this.dataColumn_9.MaxLength = int.MaxValue;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class155 method_4()
		{
			return (DataSetExcavation.Class155)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class155(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class155);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate62_1 != null)
			{
				this.delegate62_1(this, new DataSetExcavation.EventArgs61((DataSetExcavation.Class155)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate62_0 != null)
			{
				this.delegate62_0(this, new DataSetExcavation.EventArgs61((DataSetExcavation.Class155)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate62_3 != null)
			{
				this.delegate62_3(this, new DataSetExcavation.EventArgs61((DataSetExcavation.Class155)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate62_2 != null)
			{
				this.delegate62_2(this, new DataSetExcavation.EventArgs61((DataSetExcavation.Class155)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(DataSetExcavation.Class155 class155_0)
		{
			base.Rows.Remove(class155_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vJ_ExcavationDataTable";
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

		[CompilerGenerated]
		private DataSetExcavation.Delegate62 delegate62_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate62 delegate62_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate62 delegate62_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate62 delegate62_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class139 : TypedTableBase<DataSetExcavation.Class156>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class139()
		{
			
			
			base.TableName = "vJ_ExcavationSchmObj";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class139(DataTable dataTable_0)
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
		protected Class139(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
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
		public DataSetExcavation.Class156 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class156)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate63 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_0;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_0;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate63 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_1;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_1;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate63 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_2;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_2;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate63 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_3;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate63 @delegate = this.delegate63_3;
				DataSetExcavation.Delegate63 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate63 value2 = (DataSetExcavation.Delegate63)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate63>(ref this.delegate63_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(DataSetExcavation.Class156 class156_0)
		{
			base.Rows.Add(class156_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class156 method_1(int int_0, int int_1, string string_0, int int_2)
		{
			DataSetExcavation.Class156 @class = (DataSetExcavation.Class156)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				string_0,
				int_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class156 method_2(int int_0)
		{
			return (DataSetExcavation.Class156)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			DataSetExcavation.Class139 @class = (DataSetExcavation.Class139)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class139();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["name"];
			this.dataColumn_3 = base.Columns["idKL"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idKL", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.ReadOnly = true;
			this.dataColumn_2.MaxLength = 512;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class156 method_5()
		{
			return (DataSetExcavation.Class156)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class156(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class156);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate63_1 != null)
			{
				this.delegate63_1(this, new DataSetExcavation.EventArgs62((DataSetExcavation.Class156)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate63_0 != null)
			{
				this.delegate63_0(this, new DataSetExcavation.EventArgs62((DataSetExcavation.Class156)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate63_3 != null)
			{
				this.delegate63_3(this, new DataSetExcavation.EventArgs62((DataSetExcavation.Class156)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate63_2 != null)
			{
				this.delegate63_2(this, new DataSetExcavation.EventArgs62((DataSetExcavation.Class156)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(DataSetExcavation.Class156 class156_0)
		{
			base.Rows.Remove(class156_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vJ_ExcavationSchmObjDataTable";
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
		private DataSetExcavation.Delegate63 delegate63_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate63 delegate63_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate63 delegate63_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate63 delegate63_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class140 : TypedTableBase<DataSetExcavation.Class157>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class140()
		{
			
			
			base.TableName = "tJ_ExcavationSchmObj";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class140(DataTable dataTable_0)
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
		protected Class140(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
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
		public DataSetExcavation.Class157 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class157)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate64 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_0;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_0;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate64 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_1;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_1;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate64 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_2;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_2;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate64 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_3;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate64 @delegate = this.delegate64_3;
				DataSetExcavation.Delegate64 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate64 value2 = (DataSetExcavation.Delegate64)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate64>(ref this.delegate64_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(DataSetExcavation.Class157 class157_0)
		{
			base.Rows.Add(class157_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class157 method_1(int int_0, string string_0, int int_1)
		{
			DataSetExcavation.Class157 @class = (DataSetExcavation.Class157)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				string_0,
				int_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class157 method_2(int int_0)
		{
			return (DataSetExcavation.Class157)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class140 @class = (DataSetExcavation.Class140)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class140();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["NameKL"];
			this.dataColumn_3 = base.Columns["idKL"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("NameKL", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idKL", typeof(int), null, MappingType.Element);
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
			this.dataColumn_2.MaxLength = 512;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class157 method_5()
		{
			return (DataSetExcavation.Class157)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class157(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class157);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate64_1 != null)
			{
				this.delegate64_1(this, new DataSetExcavation.EventArgs63((DataSetExcavation.Class157)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate64_0 != null)
			{
				this.delegate64_0(this, new DataSetExcavation.EventArgs63((DataSetExcavation.Class157)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate64_3 != null)
			{
				this.delegate64_3(this, new DataSetExcavation.EventArgs63((DataSetExcavation.Class157)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate64_2 != null)
			{
				this.delegate64_2(this, new DataSetExcavation.EventArgs63((DataSetExcavation.Class157)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class157 class157_0)
		{
			base.Rows.Remove(class157_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "tJ_ExcavationSchmObjDataTable";
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
		private DataSetExcavation.Delegate64 delegate64_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate64 delegate64_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate64 delegate64_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate64 delegate64_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class141 : TypedTableBase<DataSetExcavation.Class158>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class141()
		{
			
			
			base.TableName = "tJ_ExcavationStatus";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class141(DataTable dataTable_0)
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
		protected Class141(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_6;
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
		public DataSetExcavation.Class158 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class158)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate65 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_0;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_0;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate65 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_1;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_1;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate65 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_2;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_2;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate65 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_3;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate65 @delegate = this.delegate65_3;
				DataSetExcavation.Delegate65 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate65 value2 = (DataSetExcavation.Delegate65)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate65>(ref this.delegate65_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class158 class158_0)
		{
			base.Rows.Add(class158_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class158 method_1(int int_0, short short_0, int int_1, DateTime dateTime_0, DateTime dateTime_1, string string_0)
		{
			DataSetExcavation.Class158 @class = (DataSetExcavation.Class158)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				short_0,
				int_1,
				dateTime_0,
				dateTime_1,
				string_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class158 method_2(int int_0)
		{
			return (DataSetExcavation.Class158)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			DataSetExcavation.Class141 @class = (DataSetExcavation.Class141)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class141();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["idType"];
			this.dataColumn_3 = base.Columns["idStatus"];
			this.dataColumn_4 = base.Columns["dateChange"];
			this.dataColumn_5 = base.Columns["dateElongation"];
			this.dataColumn_6 = base.Columns["Comment"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idType", typeof(short), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idStatus", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("dateChange", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("dateElongation", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
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
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class158 method_5()
		{
			return (DataSetExcavation.Class158)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class158(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class158);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate65_1 != null)
			{
				this.delegate65_1(this, new DataSetExcavation.EventArgs64((DataSetExcavation.Class158)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate65_0 != null)
			{
				this.delegate65_0(this, new DataSetExcavation.EventArgs64((DataSetExcavation.Class158)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate65_3 != null)
			{
				this.delegate65_3(this, new DataSetExcavation.EventArgs64((DataSetExcavation.Class158)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate65_2 != null)
			{
				this.delegate65_2(this, new DataSetExcavation.EventArgs64((DataSetExcavation.Class158)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(DataSetExcavation.Class158 class158_0)
		{
			base.Rows.Remove(class158_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "tJ_ExcavationStatusDataTable";
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
		private DataSetExcavation.Delegate65 delegate65_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate65 delegate65_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate65 delegate65_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate65 delegate65_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class142 : TypedTableBase<DataSetExcavation.Class159>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class142()
		{
			
			
			base.TableName = "vJ_ExcavationStatus";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class142(DataTable dataTable_0)
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
		protected Class142(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn idColumn
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_8;
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
		public DataSetExcavation.Class159 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class159)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate66 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_0;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_0;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate66 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_1;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_1;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate66 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_2;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_2;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate66 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_3;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate66 @delegate = this.delegate66_3;
				DataSetExcavation.Delegate66 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate66 value2 = (DataSetExcavation.Delegate66)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate66>(ref this.delegate66_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class159 class159_0)
		{
			base.Rows.Add(class159_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class159 method_1(int int_0, int int_1, short short_0, int int_2, DateTime dateTime_0, DateTime dateTime_1, string string_0, decimal decimal_0, string string_1)
		{
			DataSetExcavation.Class159 @class = (DataSetExcavation.Class159)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				short_0,
				int_2,
				dateTime_0,
				dateTime_1,
				string_0,
				decimal_0,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class159 method_2(int int_0)
		{
			return (DataSetExcavation.Class159)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			DataSetExcavation.Class142 @class = (DataSetExcavation.Class142)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class142();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["idType"];
			this.dataColumn_3 = base.Columns["idStatus"];
			this.dataColumn_4 = base.Columns["dateChange"];
			this.dataColumn_5 = base.Columns["dateElongation"];
			this.dataColumn_6 = base.Columns["statusname"];
			this.dataColumn_7 = base.Columns["statusvalue"];
			this.dataColumn_8 = base.Columns["Comment"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idType", typeof(short), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idStatus", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("dateChange", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("dateElongation", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("statusname", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("statusvalue", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_6.MaxLength = 100;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class159 method_5()
		{
			return (DataSetExcavation.Class159)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class159(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class159);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate66_1 != null)
			{
				this.delegate66_1(this, new DataSetExcavation.EventArgs65((DataSetExcavation.Class159)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate66_0 != null)
			{
				this.delegate66_0(this, new DataSetExcavation.EventArgs65((DataSetExcavation.Class159)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate66_3 != null)
			{
				this.delegate66_3(this, new DataSetExcavation.EventArgs65((DataSetExcavation.Class159)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate66_2 != null)
			{
				this.delegate66_2(this, new DataSetExcavation.EventArgs65((DataSetExcavation.Class159)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(DataSetExcavation.Class159 class159_0)
		{
			base.Rows.Remove(class159_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vJ_ExcavationStatusDataTable";
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
		private DataSetExcavation.Delegate66 delegate66_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate66 delegate66_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate66 delegate66_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate66 delegate66_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class143 : TypedTableBase<DataSetExcavation.Class160>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class143()
		{
			
			
			base.TableName = "vJ_ExcavationSurface";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class143(DataTable dataTable_0)
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
		protected Class143(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_8;
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
		public DataSetExcavation.Class160 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class160)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate67 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_0;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_0;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate67 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_1;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_1;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate67 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_2;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_2;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate67 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_3;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate67 @delegate = this.delegate67_3;
				DataSetExcavation.Delegate67 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate67 value2 = (DataSetExcavation.Delegate67)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate67>(ref this.delegate67_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class160 class160_0)
		{
			base.Rows.Add(class160_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class160 method_1(int int_0, int int_1, int int_2, int int_3, double double_0, string string_0, string string_1, string string_2, string string_3)
		{
			DataSetExcavation.Class160 @class = (DataSetExcavation.Class160)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				int_3,
				double_0,
				string_0,
				string_1,
				string_2,
				string_3
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class160 method_2(int int_0)
		{
			return (DataSetExcavation.Class160)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class143 @class = (DataSetExcavation.Class143)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class143();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["idType"];
			this.dataColumn_3 = base.Columns["idSurface"];
			this.dataColumn_4 = base.Columns["Value"];
			this.dataColumn_5 = base.Columns["unit"];
			this.dataColumn_6 = base.Columns["comment"];
			this.dataColumn_7 = base.Columns["surName"];
			this.dataColumn_8 = base.Columns["surSocrName"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idType", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idSurface", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Value", typeof(double), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("unit", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("surName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("surSocrName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_2.Caption = "isType";
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_5.MaxLength = 10;
			this.dataColumn_7.MaxLength = 100;
			this.dataColumn_8.MaxLength = 50;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class160 method_5()
		{
			return (DataSetExcavation.Class160)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class160(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class160);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate67_1 != null)
			{
				this.delegate67_1(this, new DataSetExcavation.EventArgs66((DataSetExcavation.Class160)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate67_0 != null)
			{
				this.delegate67_0(this, new DataSetExcavation.EventArgs66((DataSetExcavation.Class160)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate67_3 != null)
			{
				this.delegate67_3(this, new DataSetExcavation.EventArgs66((DataSetExcavation.Class160)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate67_2 != null)
			{
				this.delegate67_2(this, new DataSetExcavation.EventArgs66((DataSetExcavation.Class160)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class160 class160_0)
		{
			base.Rows.Remove(class160_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vJ_ExcavationSurfaceDataTable";
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
		private DataSetExcavation.Delegate67 delegate67_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate67 delegate67_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate67 delegate67_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate67 delegate67_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class144 : TypedTableBase<DataSetExcavation.Class161>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class144()
		{
			
			
			base.TableName = "tJ_ExcavationFile";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class144(DataTable dataTable_0)
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
		protected Class144(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
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
		public DataSetExcavation.Class161 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class161)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate68 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_0;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_0;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate68 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_1;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_1;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate68 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_2;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_2;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate68 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_3;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate68 @delegate = this.delegate68_3;
				DataSetExcavation.Delegate68 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate68 value2 = (DataSetExcavation.Delegate68)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate68>(ref this.delegate68_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(DataSetExcavation.Class161 class161_0)
		{
			base.Rows.Add(class161_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class161 method_1(int int_0, int int_1, string string_0, byte[] byte_0)
		{
			DataSetExcavation.Class161 @class = (DataSetExcavation.Class161)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				string_0,
				byte_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class161 method_2(int int_0)
		{
			return (DataSetExcavation.Class161)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class144 @class = (DataSetExcavation.Class144)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class144();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["typeFile"];
			this.dataColumn_3 = base.Columns["FileName"];
			this.dataColumn_4 = base.Columns["File"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("typeFile", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("FileName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("File", typeof(byte[]), null, MappingType.Element);
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
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class161 method_5()
		{
			return (DataSetExcavation.Class161)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class161(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class161);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate68_1 != null)
			{
				this.delegate68_1(this, new DataSetExcavation.EventArgs67((DataSetExcavation.Class161)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate68_0 != null)
			{
				this.delegate68_0(this, new DataSetExcavation.EventArgs67((DataSetExcavation.Class161)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate68_3 != null)
			{
				this.delegate68_3(this, new DataSetExcavation.EventArgs67((DataSetExcavation.Class161)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate68_2 != null)
			{
				this.delegate68_2(this, new DataSetExcavation.EventArgs67((DataSetExcavation.Class161)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class161 class161_0)
		{
			base.Rows.Remove(class161_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "tJ_ExcavationFileDataTable";
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
		private DataSetExcavation.Delegate68 delegate68_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate68 delegate68_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate68 delegate68_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate68 delegate68_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class145 : TypedTableBase<DataSetExcavation.Class162>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class145()
		{
			
			
			base.TableName = "vJ_ExcavationFile";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class145(DataTable dataTable_0)
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
		protected Class145(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_3();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_5;
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
		public DataSetExcavation.Class162 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class162)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate69 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_0;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_0;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate69 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_1;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_1;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate69 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_2;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_2;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate69 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_3;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate69 @delegate = this.delegate69_3;
				DataSetExcavation.Delegate69 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate69 value2 = (DataSetExcavation.Delegate69)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate69>(ref this.delegate69_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class162 class162_0)
		{
			base.Rows.Add(class162_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class162 method_1(int int_0, int int_1, int int_2, string string_0, byte[] byte_0, string string_1)
		{
			DataSetExcavation.Class162 @class = (DataSetExcavation.Class162)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				string_0,
				byte_0,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class162 method_2(int int_0)
		{
			return (DataSetExcavation.Class162)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			DataSetExcavation.Class145 @class = (DataSetExcavation.Class145)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class145();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idExcavation"];
			this.dataColumn_2 = base.Columns["typeFile"];
			this.dataColumn_3 = base.Columns["FileName"];
			this.dataColumn_4 = base.Columns["File"];
			this.dataColumn_5 = base.Columns["typeFileName"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idExcavation", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("typeFile", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("FileName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("File", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("typeFileName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 1024;
			this.dataColumn_5.MaxLength = 100;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class162 method_5()
		{
			return (DataSetExcavation.Class162)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class162(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class162);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate69_1 != null)
			{
				this.delegate69_1(this, new DataSetExcavation.EventArgs68((DataSetExcavation.Class162)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate69_0 != null)
			{
				this.delegate69_0(this, new DataSetExcavation.EventArgs68((DataSetExcavation.Class162)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate69_3 != null)
			{
				this.delegate69_3(this, new DataSetExcavation.EventArgs68((DataSetExcavation.Class162)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate69_2 != null)
			{
				this.delegate69_2(this, new DataSetExcavation.EventArgs68((DataSetExcavation.Class162)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class162 class162_0)
		{
			base.Rows.Remove(class162_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vJ_ExcavationFileDataTable";
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
		private DataSetExcavation.Delegate69 delegate69_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate69 delegate69_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate69 delegate69_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate69 delegate69_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class146 : TypedTableBase<DataSetExcavation.Class163>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class146()
		{
			
			
			base.TableName = "vR_KladrStreet";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class146(DataTable dataTable_0)
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
		protected Class146(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
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
		public DataSetExcavation.Class163 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class163)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate70 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_0;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_0;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate70 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_1;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_1;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate70 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_2;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_2;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate70 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_3;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate70 @delegate = this.delegate70_3;
				DataSetExcavation.Delegate70 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate70 value2 = (DataSetExcavation.Delegate70)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate70>(ref this.delegate70_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class163 class163_0)
		{
			base.Rows.Add(class163_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class163 method_1(int int_0, string string_0, string string_1, string string_2, string string_3, string string_4, bool bool_0)
		{
			DataSetExcavation.Class163 @class = (DataSetExcavation.Class163)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				bool_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class163 method_2(int int_0)
		{
			return (DataSetExcavation.Class163)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			DataSetExcavation.Class146 @class = (DataSetExcavation.Class146)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class146();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["KladrObjId"];
			this.dataColumn_2 = base.Columns["Name"];
			this.dataColumn_3 = base.Columns["Socr"];
			this.dataColumn_4 = base.Columns["KladrCode"];
			this.dataColumn_5 = base.Columns["Index"];
			this.dataColumn_6 = base.Columns["GNINMB"];
			this.dataColumn_7 = base.Columns["Deleted"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("KladrObjId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Socr", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("KladrCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Index", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("GNINMB", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
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
			this.dataColumn_2.ReadOnly = true;
			this.dataColumn_2.MaxLength = 91;
			this.dataColumn_3.MaxLength = 50;
			this.dataColumn_4.MaxLength = 17;
			this.dataColumn_5.MaxLength = 6;
			this.dataColumn_6.MaxLength = 4;
			this.dataColumn_7.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class163 method_5()
		{
			return (DataSetExcavation.Class163)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class163(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class163);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate70_1 != null)
			{
				this.delegate70_1(this, new DataSetExcavation.EventArgs69((DataSetExcavation.Class163)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate70_0 != null)
			{
				this.delegate70_0(this, new DataSetExcavation.EventArgs69((DataSetExcavation.Class163)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate70_3 != null)
			{
				this.delegate70_3(this, new DataSetExcavation.EventArgs69((DataSetExcavation.Class163)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate70_2 != null)
			{
				this.delegate70_2(this, new DataSetExcavation.EventArgs69((DataSetExcavation.Class163)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(DataSetExcavation.Class163 class163_0)
		{
			base.Rows.Remove(class163_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vR_KladrStreetDataTable";
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
		private DataSetExcavation.Delegate70 delegate70_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate70 delegate70_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate70 delegate70_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate70 delegate70_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class147 : TypedTableBase<DataSetExcavation.Class164>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class147()
		{
			
			
			base.TableName = "vAbnType";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class147(DataTable dataTable_0)
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
		protected Class147(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_2();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn idColumn
		{
			get
			{
				return this.dataColumn_0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn idWorkerColumn
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_8;
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
		public DataSetExcavation.Class164 this[int int_0]
		{
			get
			{
				return (DataSetExcavation.Class164)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate71 Event_0
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_0;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_0;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate71 Event_1
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_1;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_1;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate71 Event_2
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_2;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_2;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event DataSetExcavation.Delegate71 Event_3
		{
			[CompilerGenerated]
			add
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_3;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				DataSetExcavation.Delegate71 @delegate = this.delegate71_3;
				DataSetExcavation.Delegate71 delegate2;
				do
				{
					delegate2 = @delegate;
					DataSetExcavation.Delegate71 value2 = (DataSetExcavation.Delegate71)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DataSetExcavation.Delegate71>(ref this.delegate71_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(DataSetExcavation.Class164 class164_0)
		{
			base.Rows.Add(class164_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class164 method_1(int int_0, int int_1, int int_2, string string_0, int int_3, int int_4, bool bool_0, int int_5, string string_1)
		{
			DataSetExcavation.Class164 @class = (DataSetExcavation.Class164)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				string_0,
				int_3,
				int_4,
				bool_0,
				int_5,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataSetExcavation.Class147 @class = (DataSetExcavation.Class147)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DataSetExcavation.Class147();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idAbn"];
			this.dataColumn_2 = base.Columns["CodeAbonent"];
			this.dataColumn_3 = base.Columns["Name"];
			this.dataColumn_4 = base.Columns["TypeAbn"];
			this.dataColumn_5 = base.Columns["idWorker"];
			this.dataColumn_6 = base.Columns["Deleted"];
			this.dataColumn_7 = base.Columns["typeKontragent"];
			this.dataColumn_8 = base.Columns["typeKontragentName"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("TypeAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idWorker", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("typeKontragent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("typeKontragentName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 100;
			this.dataColumn_4.AllowDBNull = false;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_6.AllowDBNull = false;
			this.dataColumn_8.MaxLength = 100;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class164 method_4()
		{
			return (DataSetExcavation.Class164)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataSetExcavation.Class164(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataSetExcavation.Class164);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate71_1 != null)
			{
				this.delegate71_1(this, new DataSetExcavation.EventArgs70((DataSetExcavation.Class164)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate71_0 != null)
			{
				this.delegate71_0(this, new DataSetExcavation.EventArgs70((DataSetExcavation.Class164)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate71_3 != null)
			{
				this.delegate71_3(this, new DataSetExcavation.EventArgs70((DataSetExcavation.Class164)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate71_2 != null)
			{
				this.delegate71_2(this, new DataSetExcavation.EventArgs70((DataSetExcavation.Class164)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(DataSetExcavation.Class164 class164_0)
		{
			base.Rows.Remove(class164_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSetExcavation @class = new DataSetExcavation();
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
			xmlSchemaAttribute2.FixedValue = "vAbnTypeDataTable";
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
		private DataSetExcavation.Delegate71 delegate71_0;

		[CompilerGenerated]
		private DataSetExcavation.Delegate71 delegate71_1;

		[CompilerGenerated]
		private DataSetExcavation.Delegate71 delegate71_2;

		[CompilerGenerated]
		private DataSetExcavation.Delegate71 delegate71_3;
	}

	public class Class148 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class148(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class131_0 = (DataSetExcavation.Class131)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class131_0.idColumn];
			}
			set
			{
				base[this.class131_0.idColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class131_0.DataColumn_0];
			}
			set
			{
				base[this.class131_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idRegion
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class131_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idRegion' in table 'tJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class131_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idStreet
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class131_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idStreet' in table 'tJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class131_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string House
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class131_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'House' in table 'tJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class131_0.DataColumn_3] = value;
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
					result = (string)base[this.class131_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class131_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class131_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class131_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class131_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class131_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class131_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class131_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class131_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class131_0.DataColumn_4] = Convert.DBNull;
		}

		private DataSetExcavation.Class131 class131_0;
	}

	public class Class149 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class149(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class132_0 = (DataSetExcavation.Class132)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class132_0.idColumn];
			}
			set
			{
				base[this.class132_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class132_0.DataColumn_0];
			}
			set
			{
				base[this.class132_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idType
		{
			get
			{
				return (int)base[this.class132_0.DataColumn_1];
			}
			set
			{
				base[this.class132_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idSurface
		{
			get
			{
				return (int)base[this.class132_0.DataColumn_2];
			}
			set
			{
				base[this.class132_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public double Value
		{
			get
			{
				double result;
				try
				{
					result = (double)base[this.class132_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Value' in table 'tJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class132_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string unit
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class132_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'unit' in table 'tJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class132_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string comment
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class132_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'comment' in table 'tJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class132_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class132_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class132_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class132_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class132_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class132_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class132_0.DataColumn_5] = Convert.DBNull;
		}

		private DataSetExcavation.Class132 class132_0;
	}

	public class Class150 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class150(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class133_0 = (DataSetExcavation.Class133)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Id
		{
			get
			{
				return (int)base[this.class133_0.DataColumn_0];
			}
			set
			{
				base[this.class133_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Name
		{
			get
			{
				return (string)base[this.class133_0.fovZyJiCboO];
			}
			set
			{
				base[this.class133_0.fovZyJiCboO] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string SocrName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class133_0.JdlZyIosdQH];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SocrName' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class133_0.JdlZyIosdQH] = value;
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
					result = (decimal)base[this.class133_0.BdmZyOgdnco];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Value' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class133_0.BdmZyOgdnco] = value;
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
					result = (string)base[this.class133_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class133_0.DataColumn_1] = value;
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
					result = (int)base[this.class133_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentId' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class133_0.DataColumn_2] = value;
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
					result = (string)base[this.class133_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentKey' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class133_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public byte[] OtherId
		{
			get
			{
				byte[] result;
				try
				{
					result = (byte[])base[this.class133_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherId' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class133_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsGroup
		{
			get
			{
				return (bool)base[this.class133_0.DataColumn_5];
			}
			set
			{
				base[this.class133_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class133_0.DataColumn_6];
			}
			set
			{
				base[this.class133_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class133_0.JdlZyIosdQH);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class133_0.JdlZyIosdQH] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class133_0.BdmZyOgdnco);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class133_0.BdmZyOgdnco] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class133_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class133_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class133_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class133_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class133_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class133_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class133_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class133_0.DataColumn_4] = Convert.DBNull;
		}

		private DataSetExcavation.Class133 class133_0;
	}

	public class Class151 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class151(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class134_0 = (DataSetExcavation.Class134)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class134_0.idColumn];
			}
			set
			{
				base[this.class134_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class134_0.DataColumn_0];
			}
			set
			{
				base[this.class134_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idRegion
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class134_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idRegion' in table 'vJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class134_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idStreet
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class134_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idStreet' in table 'vJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class134_0.DataColumn_2] = value;
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
					result = (string)base[this.class134_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'House' in table 'vJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class134_0.DataColumn_3] = value;
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
					result = (string)base[this.class134_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'vJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class134_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string region
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class134_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'region' in table 'vJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class134_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string street
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class134_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'street' in table 'vJ_ExcavationAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class134_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class134_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class134_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class134_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class134_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class134_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class134_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class134_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class134_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class134_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class134_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class134_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class134_0.DataColumn_6] = Convert.DBNull;
		}

		private DataSetExcavation.Class134 class134_0;
	}

	public class Class152 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class152(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class135_0 = (DataSetExcavation.Class135)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class135_0.idColumn];
			}
			set
			{
				base[this.class135_0.idColumn] = value;
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
					result = (int)base[this.class135_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'num' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateBeg
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateBeg' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idContractor
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class135_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idContractor' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int TypeWork
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class135_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeWork' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateBegOrder
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateBegOrder' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateEndOrder
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateEndOrder' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NumPermission
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class135_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NumPermission' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DatePermission
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DatePermission' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateUnderAsphalt
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateUnderAsphalt' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateAsphalt
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateAsphalt' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateEnd
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateEnd' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime datePay
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'datePay' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool agreed
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class135_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'agreed' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateagreed
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class135_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateagreed' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_13] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int workeragreed
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class135_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'workeragreed' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_14] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idSR
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class135_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idSR' in table 'tJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class135_0.DataColumn_15] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class135_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class135_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class135_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class135_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class135_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class135_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class135_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class135_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class135_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class135_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class135_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class135_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class135_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class135_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class135_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class135_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class135_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class135_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class135_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class135_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_20()
		{
			return base.IsNull(this.class135_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_21()
		{
			base[this.class135_0.DataColumn_10] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_22()
		{
			return base.IsNull(this.class135_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class135_0.DataColumn_11] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_24()
		{
			return base.IsNull(this.class135_0.DataColumn_12);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_25()
		{
			base[this.class135_0.DataColumn_12] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class135_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_27()
		{
			base[this.class135_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class135_0.DataColumn_14);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_29()
		{
			base[this.class135_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class135_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class135_0.DataColumn_15] = Convert.DBNull;
		}

		private DataSetExcavation.Class135 class135_0;
	}

	public class Class153 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class153(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class136_0 = (DataSetExcavation.Class136)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class136_0.idColumn];
			}
			set
			{
				base[this.class136_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class136_0.DataColumn_0];
			}
			set
			{
				base[this.class136_0.DataColumn_0] = value;
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
					result = (string)base[this.class136_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'tAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class136_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeAbn
		{
			get
			{
				return (int)base[this.class136_0.DataColumn_2];
			}
			set
			{
				base[this.class136_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idWorker
		{
			get
			{
				return (int)base[this.class136_0.idWorkerColumn];
			}
			set
			{
				base[this.class136_0.idWorkerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class136_0.DataColumn_3];
			}
			set
			{
				base[this.class136_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class136_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class136_0.DataColumn_1] = Convert.DBNull;
		}

		private DataSetExcavation.Class136 class136_0;
	}

	public class Class154 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class154(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class137_0 = (DataSetExcavation.Class137)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class137_0.idColumn];
			}
			set
			{
				base[this.class137_0.idColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idAbn
		{
			get
			{
				return (int)base[this.class137_0.DataColumn_0];
			}
			set
			{
				base[this.class137_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int typeKontragent
		{
			get
			{
				return (int)base[this.class137_0.DataColumn_1];
			}
			set
			{
				base[this.class137_0.DataColumn_1] = value;
			}
		}

		private DataSetExcavation.Class137 class137_0;
	}

	public class Class155 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class155(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class138_0 = (DataSetExcavation.Class138)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class138_0.idColumn];
			}
			set
			{
				base[this.class138_0.idColumn] = value;
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
					result = (int)base[this.class138_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'num' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime datebeg
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'datebeg' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idcontractor
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class138_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idcontractor' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string nameContractor
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameContractor' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int typework
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class138_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typework' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string typeWorkscr
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeWorkscr' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string typeWorkName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeWorkName' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string region
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'region' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string address
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'address' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string nameKL
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameKL' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string statusOrder
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'statusOrder' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_10] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateBegOrder
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateBegOrder' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_11] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateEndOrder
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateEndOrder' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Permission
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Permission' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string StatusWork
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StatusWork' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_14] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateUnderAsphalt
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateUnderAsphalt' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_15] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateAsphalt
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateAsphalt' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_16] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateEnd
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateEnd' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime datePay
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'datePay' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_18] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateagreed
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateagreed' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_19] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int workeragreed
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class138_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'workeragreed' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_20] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool agreed
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class138_0.DataColumn_21];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'agreed' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_21] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Damage
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_22];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Damage' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_22] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idSR
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class138_0.DataColumn_23];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idSR' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_23] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string SR
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_24];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SR' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_24] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateEndPlanned
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class138_0.DataColumn_25];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateEndPlanned' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_25] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string workComment
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_26];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'workComment' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_26] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string recovery
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class138_0.DataColumn_27];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'recovery' in table 'vJ_Excavation' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class138_0.DataColumn_27] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class138_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class138_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class138_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class138_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class138_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class138_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class138_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class138_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class138_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class138_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class138_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class138_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class138_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class138_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class138_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class138_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class138_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class138_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class138_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class138_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class138_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_21()
		{
			base[this.class138_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class138_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class138_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class138_0.DataColumn_12);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_25()
		{
			base[this.class138_0.DataColumn_12] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_26()
		{
			return base.IsNull(this.class138_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_27()
		{
			base[this.class138_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class138_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_29()
		{
			base[this.class138_0.DataColumn_14] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_30()
		{
			return base.IsNull(this.class138_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class138_0.DataColumn_15] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_32()
		{
			return base.IsNull(this.class138_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_33()
		{
			base[this.class138_0.DataColumn_16] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_34()
		{
			return base.IsNull(this.class138_0.DataColumn_17);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_35()
		{
			base[this.class138_0.DataColumn_17] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_36()
		{
			return base.IsNull(this.class138_0.DataColumn_18);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_37()
		{
			base[this.class138_0.DataColumn_18] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_38()
		{
			return base.IsNull(this.class138_0.DataColumn_19);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_39()
		{
			base[this.class138_0.DataColumn_19] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_40()
		{
			return base.IsNull(this.class138_0.DataColumn_20);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_41()
		{
			base[this.class138_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_42()
		{
			return base.IsNull(this.class138_0.DataColumn_21);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_43()
		{
			base[this.class138_0.DataColumn_21] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_44()
		{
			return base.IsNull(this.class138_0.DataColumn_22);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_45()
		{
			base[this.class138_0.DataColumn_22] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_46()
		{
			return base.IsNull(this.class138_0.DataColumn_23);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_47()
		{
			base[this.class138_0.DataColumn_23] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_48()
		{
			return base.IsNull(this.class138_0.DataColumn_24);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_49()
		{
			base[this.class138_0.DataColumn_24] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_50()
		{
			return base.IsNull(this.class138_0.DataColumn_25);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_51()
		{
			base[this.class138_0.DataColumn_25] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_52()
		{
			return base.IsNull(this.class138_0.DataColumn_26);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_53()
		{
			base[this.class138_0.DataColumn_26] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_54()
		{
			return base.IsNull(this.class138_0.DataColumn_27);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_55()
		{
			base[this.class138_0.DataColumn_27] = Convert.DBNull;
		}

		private DataSetExcavation.Class138 class138_0;
	}

	public class Class156 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class156(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class139_0 = (DataSetExcavation.Class139)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class139_0.idColumn];
			}
			set
			{
				base[this.class139_0.idColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class139_0.DataColumn_0];
			}
			set
			{
				base[this.class139_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string name
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class139_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'name' in table 'vJ_ExcavationSchmObj' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class139_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idKL
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class139_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idKL' in table 'vJ_ExcavationSchmObj' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class139_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool likZpjLihk9()
		{
			return base.IsNull(this.class139_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0()
		{
			base[this.class139_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_1()
		{
			return base.IsNull(this.class139_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_2()
		{
			base[this.class139_0.DataColumn_2] = Convert.DBNull;
		}

		private DataSetExcavation.Class139 class139_0;
	}

	public class Class157 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class157(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class140_0 = (DataSetExcavation.Class140)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class140_0.idColumn];
			}
			set
			{
				base[this.class140_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class140_0.DataColumn_0];
			}
			set
			{
				base[this.class140_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NameKL
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class140_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NameKL' in table 'tJ_ExcavationSchmObj' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class140_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idKL
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class140_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idKL' in table 'tJ_ExcavationSchmObj' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class140_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class140_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class140_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class140_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class140_0.DataColumn_2] = Convert.DBNull;
		}

		private DataSetExcavation.Class140 class140_0;
	}

	public class Class158 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class158(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class141_0 = (DataSetExcavation.Class141)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class141_0.idColumn];
			}
			set
			{
				base[this.class141_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class141_0.DataColumn_0];
			}
			set
			{
				base[this.class141_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public short idType
		{
			get
			{
				return (short)base[this.class141_0.DataColumn_1];
			}
			set
			{
				base[this.class141_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idStatus
		{
			get
			{
				return (int)base[this.class141_0.DataColumn_2];
			}
			set
			{
				base[this.class141_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime dateChange
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class141_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateChange' in table 'tJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class141_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateElongation
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class141_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateElongation' in table 'tJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class141_0.DataColumn_4] = value;
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
					result = (string)base[this.class141_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class141_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class141_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class141_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class141_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class141_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class141_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class141_0.DataColumn_5] = Convert.DBNull;
		}

		private DataSetExcavation.Class141 class141_0;
	}

	public class Class159 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class159(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class142_0 = (DataSetExcavation.Class142)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class142_0.idColumn];
			}
			set
			{
				base[this.class142_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class142_0.DataColumn_0];
			}
			set
			{
				base[this.class142_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public short idType
		{
			get
			{
				return (short)base[this.class142_0.DataColumn_1];
			}
			set
			{
				base[this.class142_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idStatus
		{
			get
			{
				return (int)base[this.class142_0.DataColumn_2];
			}
			set
			{
				base[this.class142_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateChange
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class142_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateChange' in table 'vJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class142_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateElongation
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class142_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'dateElongation' in table 'vJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class142_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string statusname
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class142_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'statusname' in table 'vJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class142_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal statusvalue
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class142_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'statusvalue' in table 'vJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class142_0.DataColumn_6] = value;
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
					result = (string)base[this.class142_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'vJ_ExcavationStatus' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class142_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class142_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class142_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class142_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class142_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class142_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class142_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class142_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class142_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class142_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class142_0.DataColumn_7] = Convert.DBNull;
		}

		private DataSetExcavation.Class142 class142_0;
	}

	public class Class160 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class160(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class143_0 = (DataSetExcavation.Class143)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class143_0.idColumn];
			}
			set
			{
				base[this.class143_0.idColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class143_0.DataColumn_0];
			}
			set
			{
				base[this.class143_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idType
		{
			get
			{
				return (int)base[this.class143_0.DataColumn_1];
			}
			set
			{
				base[this.class143_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idSurface
		{
			get
			{
				return (int)base[this.class143_0.DataColumn_2];
			}
			set
			{
				base[this.class143_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public double Value
		{
			get
			{
				double result;
				try
				{
					result = (double)base[this.class143_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Value' in table 'vJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class143_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string unit
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class143_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'unit' in table 'vJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class143_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string comment
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class143_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'comment' in table 'vJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class143_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string surName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class143_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'surName' in table 'vJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class143_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string surSocrName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class143_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'surSocrName' in table 'vJ_ExcavationSurface' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class143_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class143_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class143_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class143_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class143_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool ntfZfqGskho()
		{
			return base.IsNull(this.class143_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_4()
		{
			base[this.class143_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_5()
		{
			return base.IsNull(this.class143_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6()
		{
			base[this.class143_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_7()
		{
			return base.IsNull(this.class143_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_8()
		{
			base[this.class143_0.DataColumn_7] = Convert.DBNull;
		}

		private DataSetExcavation.Class143 class143_0;
	}

	public class Class161 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class161(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class144_0 = (DataSetExcavation.Class144)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class144_0.idColumn];
			}
			set
			{
				base[this.class144_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class144_0.DataColumn_0];
			}
			set
			{
				base[this.class144_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int typeFile
		{
			get
			{
				return (int)base[this.class144_0.DataColumn_1];
			}
			set
			{
				base[this.class144_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FileName
		{
			get
			{
				return (string)base[this.class144_0.DataColumn_2];
			}
			set
			{
				base[this.class144_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public byte[] File
		{
			get
			{
				byte[] result;
				try
				{
					result = (byte[])base[this.class144_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'File' in table 'tJ_ExcavationFile' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class144_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class144_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class144_0.DataColumn_3] = Convert.DBNull;
		}

		private DataSetExcavation.Class144 class144_0;
	}

	public class Class162 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class162(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class145_0 = (DataSetExcavation.Class145)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class145_0.idColumn];
			}
			set
			{
				base[this.class145_0.idColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idExcavation
		{
			get
			{
				return (int)base[this.class145_0.DataColumn_0];
			}
			set
			{
				base[this.class145_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int typeFile
		{
			get
			{
				return (int)base[this.class145_0.DataColumn_1];
			}
			set
			{
				base[this.class145_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string FileName
		{
			get
			{
				return (string)base[this.class145_0.DataColumn_2];
			}
			set
			{
				base[this.class145_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public byte[] File
		{
			get
			{
				byte[] result;
				try
				{
					result = (byte[])base[this.class145_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'File' in table 'vJ_ExcavationFile' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class145_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string typeFileName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class145_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeFileName' in table 'vJ_ExcavationFile' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class145_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class145_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class145_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class145_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class145_0.DataColumn_4] = Convert.DBNull;
		}

		private DataSetExcavation.Class145 class145_0;
	}

	public class Class163 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class163(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class146_0 = (DataSetExcavation.Class146)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				return (int)base[this.class146_0.DataColumn_0];
			}
			set
			{
				base[this.class146_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int KladrObjId
		{
			get
			{
				return (int)base[this.class146_0.DataColumn_1];
			}
			set
			{
				base[this.class146_0.DataColumn_1] = value;
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
					result = (string)base[this.class146_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vR_KladrStreet' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class146_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Socr
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class146_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Socr' in table 'vR_KladrStreet' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class146_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string KladrCode
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class146_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'KladrCode' in table 'vR_KladrStreet' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class146_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Index
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class146_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Index' in table 'vR_KladrStreet' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class146_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string GNINMB
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class146_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GNINMB' in table 'vR_KladrStreet' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class146_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class146_0.DataColumn_7];
			}
			set
			{
				base[this.class146_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class146_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class146_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class146_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class146_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class146_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class146_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class146_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class146_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class146_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class146_0.DataColumn_6] = Convert.DBNull;
		}

		private DataSetExcavation.Class146 class146_0;
	}

	public class Class164 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class164(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class147_0 = (DataSetExcavation.Class147)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class147_0.idColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'id' in table 'vAbnType' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class147_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				return (int)base[this.class147_0.DataColumn_0];
			}
			set
			{
				base[this.class147_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class147_0.DataColumn_1];
			}
			set
			{
				base[this.class147_0.DataColumn_1] = value;
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
					result = (string)base[this.class147_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vAbnType' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class147_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeAbn
		{
			get
			{
				return (int)base[this.class147_0.DataColumn_3];
			}
			set
			{
				base[this.class147_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idWorker
		{
			get
			{
				return (int)base[this.class147_0.idWorkerColumn];
			}
			set
			{
				base[this.class147_0.idWorkerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class147_0.DataColumn_4];
			}
			set
			{
				base[this.class147_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int typeKontragent
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class147_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeKontragent' in table 'vAbnType' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class147_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string typeKontragentName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class147_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeKontragentName' in table 'vAbnType' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class147_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class147_0.idColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class147_0.idColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class147_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class147_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class147_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class147_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class147_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class147_0.DataColumn_6] = Convert.DBNull;
		}

		private DataSetExcavation.Class147 class147_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs54 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs54(DataSetExcavation.Class148 class148_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class148_0 = class148_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class148 Row
		{
			get
			{
				return this.class148_0;
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

		private DataSetExcavation.Class148 class148_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs55 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs55(DataSetExcavation.Class149 class149_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class149_0 = class149_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class149 Row
		{
			get
			{
				return this.class149_0;
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

		private DataSetExcavation.Class149 class149_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs56 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs56(DataSetExcavation.Class150 class150_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class150_0 = class150_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class150 Row
		{
			get
			{
				return this.class150_0;
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

		private DataSetExcavation.Class150 class150_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs57 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs57(DataSetExcavation.Class151 class151_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class151_0 = class151_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class151 Row
		{
			get
			{
				return this.class151_0;
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

		private DataSetExcavation.Class151 class151_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs58 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs58(DataSetExcavation.Class152 class152_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class152_0 = class152_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class152 Row
		{
			get
			{
				return this.class152_0;
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

		private DataSetExcavation.Class152 class152_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs59 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs59(DataSetExcavation.Class153 class153_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class153_0 = class153_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class153 Row
		{
			get
			{
				return this.class153_0;
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

		private DataSetExcavation.Class153 class153_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs60 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs60(DataSetExcavation.Class154 class154_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class154_0 = class154_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class154 Row
		{
			get
			{
				return this.class154_0;
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

		private DataSetExcavation.Class154 class154_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs61 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs61(DataSetExcavation.Class155 class155_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class155_0 = class155_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class155 Row
		{
			get
			{
				return this.class155_0;
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

		private DataSetExcavation.Class155 class155_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs62 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs62(DataSetExcavation.Class156 class156_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class156_0 = class156_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class156 Row
		{
			get
			{
				return this.class156_0;
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

		private DataSetExcavation.Class156 class156_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs63 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs63(DataSetExcavation.Class157 class157_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class157_0 = class157_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class157 Row
		{
			get
			{
				return this.class157_0;
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

		private DataSetExcavation.Class157 class157_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs64 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs64(DataSetExcavation.Class158 class158_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class158_0 = class158_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class158 Row
		{
			get
			{
				return this.class158_0;
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

		private DataSetExcavation.Class158 class158_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs65 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs65(DataSetExcavation.Class159 class159_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class159_0 = class159_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class159 Row
		{
			get
			{
				return this.class159_0;
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

		private DataSetExcavation.Class159 class159_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs66 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs66(DataSetExcavation.Class160 class160_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class160_0 = class160_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class160 Row
		{
			get
			{
				return this.class160_0;
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

		private DataSetExcavation.Class160 class160_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs67 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs67(DataSetExcavation.Class161 class161_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class161_0 = class161_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class161 Row
		{
			get
			{
				return this.class161_0;
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

		private DataSetExcavation.Class161 class161_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs68 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs68(DataSetExcavation.Class162 class162_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class162_0 = class162_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class162 Row
		{
			get
			{
				return this.class162_0;
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

		private DataSetExcavation.Class162 class162_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs69 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs69(DataSetExcavation.Class163 class163_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class163_0 = class163_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataSetExcavation.Class163 Row
		{
			get
			{
				return this.class163_0;
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

		private DataSetExcavation.Class163 class163_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs70 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs70(DataSetExcavation.Class164 class164_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class164_0 = class164_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetExcavation.Class164 Row
		{
			get
			{
				return this.class164_0;
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

		private DataSetExcavation.Class164 class164_0;

		private DataRowAction dataRowAction_0;
	}
}
