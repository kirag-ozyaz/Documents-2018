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
[XmlRoot("dsCalc")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[ToolboxItem(true)]
[Serializable]
internal class Class498 : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class498()
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		
		base.BeginInit();
		this.method_2();
		CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_22);
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		base.EndInit();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected Class498(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		base..ctor(serializationInfo_0, streamingContext_0, false);
		if (base.IsBinarySerialized(serializationInfo_0, streamingContext_0))
		{
			this.method_1(false);
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_22);
			this.DataTableCollection_0.CollectionChanged += value;
			this.DataRelationCollection_0.CollectionChanged += value;
			return;
		}
		string s = (string)serializationInfo_0.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(serializationInfo_0, streamingContext_0) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["tDocCalc"] != null)
			{
				base.Tables.Add(new Class498.Class499(dataSet.Tables["tDocCalc"]));
			}
			if (dataSet.Tables["tUser"] != null)
			{
				base.Tables.Add(new Class498.Class500(dataSet.Tables["tUser"]));
			}
			if (dataSet.Tables["tR_Classifier"] != null)
			{
				base.Tables.Add(new Class498.Class501(dataSet.Tables["tR_Classifier"]));
			}
			if (dataSet.Tables["tAbn"] != null)
			{
				base.Tables.Add(new Class498.Class502(dataSet.Tables["tAbn"]));
			}
			if (dataSet.Tables["tMaterial"] != null)
			{
				base.Tables.Add(new Class498.Class503(dataSet.Tables["tMaterial"]));
			}
			if (dataSet.Tables["tblLock"] != null)
			{
				base.Tables.Add(new Class498.Class504(dataSet.Tables["tblLock"]));
			}
			if (dataSet.Tables["tJ_CalcLoss"] != null)
			{
				base.Tables.Add(new Class498.Class505(dataSet.Tables["tJ_CalcLoss"]));
			}
			if (dataSet.Tables["vJ_CalcLoss"] != null)
			{
				base.Tables.Add(new Class498.Class506(dataSet.Tables["vJ_CalcLoss"]));
			}
			if (dataSet.Tables["vAbnObjAddress"] != null)
			{
				base.Tables.Add(new Class498.Class507(dataSet.Tables["vAbnObjAddress"]));
			}
			if (dataSet.Tables["vR_Cable"] != null)
			{
				base.Tables.Add(new Class498.Class508(dataSet.Tables["vR_Cable"]));
			}
			if (dataSet.Tables["tJ_CalcLossCable"] != null)
			{
				base.Tables.Add(new Class498.Class509(dataSet.Tables["tJ_CalcLossCable"]));
			}
			if (dataSet.Tables["vAbn"] != null)
			{
				base.Tables.Add(new Class498.Class510(dataSet.Tables["vAbn"]));
			}
			if (dataSet.Tables["dtSource"] != null)
			{
				base.Tables.Add(new Class498.Class511(dataSet.Tables["dtSource"]));
			}
			if (dataSet.Tables["tJ_CalcLossFile"] != null)
			{
				base.Tables.Add(new Class498.Class512(dataSet.Tables["tJ_CalcLossFile"]));
			}
			if (dataSet.Tables["vL_SchmAbn"] != null)
			{
				base.Tables.Add(new Class498.Class513(dataSet.Tables["vL_SchmAbn"]));
			}
			if (dataSet.Tables["vR_Transformer"] != null)
			{
				base.Tables.Add(new Class498.Class514(dataSet.Tables["vR_Transformer"]));
			}
			if (dataSet.Tables["tJ_CalcLossTrans"] != null)
			{
				base.Tables.Add(new Class498.Class515(dataSet.Tables["tJ_CalcLossTrans"]));
			}
			if (dataSet.Tables["tJ_CalcLossTransHH"] != null)
			{
				base.Tables.Add(new Class498.Class516(dataSet.Tables["tJ_CalcLossTransHH"]));
			}
			if (dataSet.Tables["dtIsolationLoss"] != null)
			{
				base.Tables.Add(new Class498.Class517(dataSet.Tables["dtIsolationLoss"]));
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
		CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_22);
		base.Tables.CollectionChanged += value2;
		this.DataRelationCollection_0.CollectionChanged += value2;
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class498.Class499 tDocCalc
	{
		get
		{
			return this.class499_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class498.Class500 tUser
	{
		get
		{
			return this.class500_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class498.Class501 tR_Classifier
	{
		get
		{
			return this.class501_0;
		}
	}

	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class498.Class502 tAbn
	{
		get
		{
			return this.class502_0;
		}
	}

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class498.Class503 tMaterial
	{
		get
		{
			return this.class503_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class498.Class504 tblLock
	{
		get
		{
			return this.class504_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public Class498.Class505 tJ_CalcLoss
	{
		get
		{
			return this.class505_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class498.Class506 vJ_CalcLoss
	{
		get
		{
			return this.class506_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class498.Class507 vAbnObjAddress
	{
		get
		{
			return this.class507_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class498.Class508 vR_Cable
	{
		get
		{
			return this.class508_0;
		}
	}

	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class498.Class509 tJ_CalcLossCable
	{
		get
		{
			return this.class509_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class498.Class510 vAbn
	{
		get
		{
			return this.class510_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class498.Class511 dtSource
	{
		get
		{
			return this.class511_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class498.Class512 tJ_CalcLossFile
	{
		get
		{
			return this.class512_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class498.Class513 vL_SchmAbn
	{
		get
		{
			return this.class513_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class498.Class514 vR_Transformer
	{
		get
		{
			return this.class514_0;
		}
	}

	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class498.Class515 tJ_CalcLossTrans
	{
		get
		{
			return this.class515_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class498.Class516 tJ_CalcLossTransHH
	{
		get
		{
			return this.class516_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class498.Class517 dtIsolationLoss
	{
		get
		{
			return this.class517_0;
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public DataTableCollection DataTableCollection_0
	{
		get
		{
			return base.Tables;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
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
		Class498 @class = (Class498)base.Clone();
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
			if (dataSet.Tables["tDocCalc"] != null)
			{
				base.Tables.Add(new Class498.Class499(dataSet.Tables["tDocCalc"]));
			}
			if (dataSet.Tables["tUser"] != null)
			{
				base.Tables.Add(new Class498.Class500(dataSet.Tables["tUser"]));
			}
			if (dataSet.Tables["tR_Classifier"] != null)
			{
				base.Tables.Add(new Class498.Class501(dataSet.Tables["tR_Classifier"]));
			}
			if (dataSet.Tables["tAbn"] != null)
			{
				base.Tables.Add(new Class498.Class502(dataSet.Tables["tAbn"]));
			}
			if (dataSet.Tables["tMaterial"] != null)
			{
				base.Tables.Add(new Class498.Class503(dataSet.Tables["tMaterial"]));
			}
			if (dataSet.Tables["tblLock"] != null)
			{
				base.Tables.Add(new Class498.Class504(dataSet.Tables["tblLock"]));
			}
			if (dataSet.Tables["tJ_CalcLoss"] != null)
			{
				base.Tables.Add(new Class498.Class505(dataSet.Tables["tJ_CalcLoss"]));
			}
			if (dataSet.Tables["vJ_CalcLoss"] != null)
			{
				base.Tables.Add(new Class498.Class506(dataSet.Tables["vJ_CalcLoss"]));
			}
			if (dataSet.Tables["vAbnObjAddress"] != null)
			{
				base.Tables.Add(new Class498.Class507(dataSet.Tables["vAbnObjAddress"]));
			}
			if (dataSet.Tables["vR_Cable"] != null)
			{
				base.Tables.Add(new Class498.Class508(dataSet.Tables["vR_Cable"]));
			}
			if (dataSet.Tables["tJ_CalcLossCable"] != null)
			{
				base.Tables.Add(new Class498.Class509(dataSet.Tables["tJ_CalcLossCable"]));
			}
			if (dataSet.Tables["vAbn"] != null)
			{
				base.Tables.Add(new Class498.Class510(dataSet.Tables["vAbn"]));
			}
			if (dataSet.Tables["dtSource"] != null)
			{
				base.Tables.Add(new Class498.Class511(dataSet.Tables["dtSource"]));
			}
			if (dataSet.Tables["tJ_CalcLossFile"] != null)
			{
				base.Tables.Add(new Class498.Class512(dataSet.Tables["tJ_CalcLossFile"]));
			}
			if (dataSet.Tables["vL_SchmAbn"] != null)
			{
				base.Tables.Add(new Class498.Class513(dataSet.Tables["vL_SchmAbn"]));
			}
			if (dataSet.Tables["vR_Transformer"] != null)
			{
				base.Tables.Add(new Class498.Class514(dataSet.Tables["vR_Transformer"]));
			}
			if (dataSet.Tables["tJ_CalcLossTrans"] != null)
			{
				base.Tables.Add(new Class498.Class515(dataSet.Tables["tJ_CalcLossTrans"]));
			}
			if (dataSet.Tables["tJ_CalcLossTransHH"] != null)
			{
				base.Tables.Add(new Class498.Class516(dataSet.Tables["tJ_CalcLossTransHH"]));
			}
			if (dataSet.Tables["dtIsolationLoss"] != null)
			{
				base.Tables.Add(new Class498.Class517(dataSet.Tables["dtIsolationLoss"]));
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
		this.class499_0 = (Class498.Class499)base.Tables["tDocCalc"];
		if (bool_0 && this.class499_0 != null)
		{
			this.class499_0.method_3();
		}
		this.class500_0 = (Class498.Class500)base.Tables["tUser"];
		if (bool_0 && this.class500_0 != null)
		{
			this.class500_0.method_3();
		}
		this.class501_0 = (Class498.Class501)base.Tables["tR_Classifier"];
		if (bool_0 && this.class501_0 != null)
		{
			this.class501_0.method_3();
		}
		this.class502_0 = (Class498.Class502)base.Tables["tAbn"];
		if (bool_0 && this.class502_0 != null)
		{
			this.class502_0.method_3();
		}
		this.class503_0 = (Class498.Class503)base.Tables["tMaterial"];
		if (bool_0 && this.class503_0 != null)
		{
			this.class503_0.method_3();
		}
		this.class504_0 = (Class498.Class504)base.Tables["tblLock"];
		if (bool_0 && this.class504_0 != null)
		{
			this.class504_0.method_3();
		}
		this.class505_0 = (Class498.Class505)base.Tables["tJ_CalcLoss"];
		if (bool_0 && this.class505_0 != null)
		{
			this.class505_0.method_3();
		}
		this.class506_0 = (Class498.Class506)base.Tables["vJ_CalcLoss"];
		if (bool_0 && this.class506_0 != null)
		{
			this.class506_0.jGoHkyLpyby();
		}
		this.class507_0 = (Class498.Class507)base.Tables["vAbnObjAddress"];
		if (bool_0 && this.class507_0 != null)
		{
			this.class507_0.method_2();
		}
		this.class508_0 = (Class498.Class508)base.Tables["vR_Cable"];
		if (bool_0 && this.class508_0 != null)
		{
			this.class508_0.method_3();
		}
		this.class509_0 = (Class498.Class509)base.Tables["tJ_CalcLossCable"];
		if (bool_0 && this.class509_0 != null)
		{
			this.class509_0.method_3();
		}
		this.class510_0 = (Class498.Class510)base.Tables["vAbn"];
		if (bool_0 && this.class510_0 != null)
		{
			this.class510_0.NluHwtocwDU();
		}
		this.class511_0 = (Class498.Class511)base.Tables["dtSource"];
		if (bool_0 && this.class511_0 != null)
		{
			this.class511_0.method_2();
		}
		this.class512_0 = (Class498.Class512)base.Tables["tJ_CalcLossFile"];
		if (bool_0 && this.class512_0 != null)
		{
			this.class512_0.method_3();
		}
		this.class513_0 = (Class498.Class513)base.Tables["vL_SchmAbn"];
		if (bool_0 && this.class513_0 != null)
		{
			this.class513_0.method_3();
		}
		this.class514_0 = (Class498.Class514)base.Tables["vR_Transformer"];
		if (bool_0 && this.class514_0 != null)
		{
			this.class514_0.method_3();
		}
		this.class515_0 = (Class498.Class515)base.Tables["tJ_CalcLossTrans"];
		if (bool_0 && this.class515_0 != null)
		{
			this.class515_0.method_3();
		}
		this.class516_0 = (Class498.Class516)base.Tables["tJ_CalcLossTransHH"];
		if (bool_0 && this.class516_0 != null)
		{
			this.class516_0.method_3();
		}
		this.class517_0 = (Class498.Class517)base.Tables["dtIsolationLoss"];
		if (bool_0 && this.class517_0 != null)
		{
			this.class517_0.method_2();
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_2()
	{
		base.DataSetName = "dsCalc";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/dsCalc.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class499_0 = new Class498.Class499();
		base.Tables.Add(this.class499_0);
		this.class500_0 = new Class498.Class500();
		base.Tables.Add(this.class500_0);
		this.class501_0 = new Class498.Class501();
		base.Tables.Add(this.class501_0);
		this.class502_0 = new Class498.Class502();
		base.Tables.Add(this.class502_0);
		this.class503_0 = new Class498.Class503();
		base.Tables.Add(this.class503_0);
		this.class504_0 = new Class498.Class504();
		base.Tables.Add(this.class504_0);
		this.class505_0 = new Class498.Class505();
		base.Tables.Add(this.class505_0);
		this.class506_0 = new Class498.Class506();
		base.Tables.Add(this.class506_0);
		this.class507_0 = new Class498.Class507();
		base.Tables.Add(this.class507_0);
		this.class508_0 = new Class498.Class508();
		base.Tables.Add(this.class508_0);
		this.class509_0 = new Class498.Class509();
		base.Tables.Add(this.class509_0);
		this.class510_0 = new Class498.Class510();
		base.Tables.Add(this.class510_0);
		this.class511_0 = new Class498.Class511();
		base.Tables.Add(this.class511_0);
		this.class512_0 = new Class498.Class512();
		base.Tables.Add(this.class512_0);
		this.class513_0 = new Class498.Class513();
		base.Tables.Add(this.class513_0);
		this.class514_0 = new Class498.Class514();
		base.Tables.Add(this.class514_0);
		this.class515_0 = new Class498.Class515();
		base.Tables.Add(this.class515_0);
		this.class516_0 = new Class498.Class516();
		base.Tables.Add(this.class516_0);
		this.class517_0 = new Class498.Class517();
		base.Tables.Add(this.class517_0);
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_5()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_19()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private bool method_20()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_21()
	{
		return false;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_22(object sender, CollectionChangeEventArgs e)
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
		Class498 @class = new Class498();
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

	private Class498.Class499 class499_0;

	private Class498.Class500 class500_0;

	private Class498.Class501 class501_0;

	private Class498.Class502 class502_0;

	private Class498.Class503 class503_0;

	private Class498.Class504 class504_0;

	private Class498.Class505 class505_0;

	private Class498.Class506 class506_0;

	private Class498.Class507 class507_0;

	private Class498.Class508 class508_0;

	private Class498.Class509 class509_0;

	private Class498.Class510 class510_0;

	private Class498.Class511 class511_0;

	private Class498.Class512 class512_0;

	private Class498.Class513 class513_0;

	private Class498.Class514 class514_0;

	private Class498.Class515 class515_0;

	private Class498.Class516 class516_0;

	private Class498.Class517 class517_0;

	private SchemaSerializationMode schemaSerializationMode_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate233(object sender, Class498.EventArgs229 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate234(object sender, Class498.EventArgs230 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate235(object sender, Class498.EventArgs231 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate236(object sender, Class498.EventArgs232 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate237(object sender, Class498.EventArgs233 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate238(object sender, Class498.EventArgs234 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate239(object sender, Class498.EventArgs235 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate240(object sender, Class498.EventArgs236 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate241(object sender, Class498.EventArgs237 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate242(object sender, Class498.EventArgs238 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate243(object sender, Class498.EventArgs239 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate244(object sender, Class498.EventArgs240 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate245(object sender, Class498.EventArgs241 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate246(object sender, Class498.EventArgs242 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate247(object sender, Class498.EventArgs243 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate248(object sender, Class498.EventArgs244 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate249(object sender, Class498.EventArgs245 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate250(object sender, Class498.EventArgs246 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate251(object sender, Class498.EventArgs247 e);

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class499 : TypedTableBase<Class498.Class518>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class499()
		{
			
			
			base.TableName = "tDocCalc";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class499(DataTable dataTable_0)
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
		protected Class499(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class518 this[int int_0]
		{
			get
			{
				return (Class498.Class518)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate233 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate233 @delegate = this.delegate233_0;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate233 @delegate = this.delegate233_0;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate233 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate233 @delegate = this.delegate233_1;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate233 @delegate = this.delegate233_1;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate233 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate233 @delegate = this.delegate233_2;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate233 @delegate = this.delegate233_2;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate233 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate233 @delegate = this.delegate233_3;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate233 @delegate = this.delegate233_3;
				Class498.Delegate233 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate233 value2 = (Class498.Delegate233)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate233>(ref this.delegate233_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class518 class518_0)
		{
			base.Rows.Add(class518_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class518 method_1(int int_0, int int_1, int int_2, string string_0, DateTime dateTime_0, DateTime dateTime_1, int int_3, string string_1, decimal decimal_0, decimal decimal_1, decimal decimal_2, int int_4, int int_5, decimal decimal_3, decimal decimal_4, decimal decimal_5, decimal decimal_6, decimal decimal_7, decimal decimal_8, decimal decimal_9, decimal decimal_10, bool bool_0, int int_6)
		{
			Class498.Class518 @class = (Class498.Class518)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				int_2,
				string_0,
				dateTime_0,
				dateTime_1,
				int_3,
				string_1,
				decimal_0,
				decimal_1,
				decimal_2,
				int_4,
				int_5,
				decimal_3,
				decimal_4,
				decimal_5,
				decimal_6,
				decimal_7,
				decimal_8,
				decimal_9,
				decimal_10,
				bool_0,
				int_6
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class518 method_2(int int_0)
		{
			return (Class498.Class518)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class499 @class = (Class498.Class499)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class499();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idDocType"];
			this.dataColumn_2 = base.Columns["IdAbn"];
			this.dataColumn_3 = base.Columns["idMarkCable"];
			this.dataColumn_4 = base.Columns["Representative"];
			this.dataColumn_5 = base.Columns["DateIn"];
			this.dataColumn_6 = base.Columns["DateAct"];
			this.dataColumn_7 = base.Columns["IdOwner"];
			this.dataColumn_8 = base.Columns["Comment"];
			this.dataColumn_9 = base.Columns["LineLength"];
			this.dataColumn_10 = base.Columns["ElectricalResistance"];
			this.dataColumn_11 = base.Columns["AverageVoltage"];
			this.dataColumn_12 = base.Columns["Consumption"];
			this.dataColumn_13 = base.Columns["Period"];
			this.dataColumn_14 = base.Columns["CoefficientPowerReactive"];
			this.dataColumn_15 = base.Columns["SquareCoefficientFormGraphics"];
			this.dataColumn_16 = base.Columns["CoefficientDifferences"];
			this.dataColumn_17 = base.Columns["ActiveResistance"];
			this.dataColumn_18 = base.Columns["LoadPowerLoss"];
			this.dataColumn_19 = base.Columns["LoadAverage"];
			this.dataColumn_20 = base.Columns["LoadLosses"];
			this.dataColumn_21 = base.Columns["CoefficientLoss"];
			this.dataColumn_22 = base.Columns["Deleted"];
			this.dataColumn_23 = base.Columns["CountCepey"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idDocType", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("IdAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idMarkCable", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Representative", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("DateIn", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("DateAct", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("IdOwner", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("LineLength", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("ElectricalResistance", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("AverageVoltage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("Consumption", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("Period", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("CoefficientPowerReactive", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("SquareCoefficientFormGraphics", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("CoefficientDifferences", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("ActiveResistance", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("LoadPowerLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("LoadAverage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("LoadLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("CoefficientLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_23 = new DataColumn("CountCepey", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_23);
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
			this.dataColumn_4.MaxLength = 150;
			this.dataColumn_8.MaxLength = 512;
			this.dataColumn_22.AllowDBNull = false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class518 method_5()
		{
			return (Class498.Class518)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class518(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class518);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate233_1 != null)
			{
				this.delegate233_1(this, new Class498.EventArgs229((Class498.Class518)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate233_0 != null)
			{
				this.delegate233_0(this, new Class498.EventArgs229((Class498.Class518)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate233_3 != null)
			{
				this.delegate233_3(this, new Class498.EventArgs229((Class498.Class518)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate233_2 != null)
			{
				this.delegate233_2(this, new Class498.EventArgs229((Class498.Class518)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class498.Class518 class518_0)
		{
			base.Rows.Remove(class518_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tDocCalcDataTable";
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

		[CompilerGenerated]
		private Class498.Delegate233 delegate233_0;

		[CompilerGenerated]
		private Class498.Delegate233 delegate233_1;

		[CompilerGenerated]
		private Class498.Delegate233 delegate233_2;

		[CompilerGenerated]
		private Class498.Delegate233 delegate233_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class500 : TypedTableBase<Class498.Class519>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class500()
		{
			
			
			base.TableName = "tUser";
			this.BeginInit();
			this.DNNHOUIUCLX();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class500(DataTable dataTable_0)
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
		protected Class500(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class498.Class519 this[int int_0]
		{
			get
			{
				return (Class498.Class519)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate234 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate234 @delegate = this.delegate234_0;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate234 @delegate = this.delegate234_0;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate234 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate234 @delegate = this.delegate234_1;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate234 @delegate = this.delegate234_1;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate234 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate234 @delegate = this.delegate234_2;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate234 @delegate = this.delegate234_2;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate234 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate234 @delegate = this.delegate234_3;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate234 @delegate = this.delegate234_3;
				Class498.Delegate234 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate234 value2 = (Class498.Delegate234)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate234>(ref this.delegate234_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class519 class519_0)
		{
			base.Rows.Add(class519_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class519 method_1(int int_0, string string_0, string string_1, bool bool_0)
		{
			Class498.Class519 @class = (Class498.Class519)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				string_0,
				string_1,
				bool_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class519 method_2(int int_0)
		{
			return (Class498.Class519)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class500 @class = (Class498.Class500)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class500();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["IDUser"];
			this.dataColumn_1 = base.Columns["IdWorker"];
			this.dataColumn_2 = base.Columns["Login"];
			this.dataColumn_3 = base.Columns["Name"];
			this.dataColumn_4 = base.Columns["Deleted"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void DNNHOUIUCLX()
		{
			this.dataColumn_0 = new DataColumn("IDUser", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("IdWorker", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Login", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
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
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_2.MaxLength = 50;
			this.dataColumn_3.MaxLength = 50;
			this.dataColumn_4.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class519 method_4()
		{
			return (Class498.Class519)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class519(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class519);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate234_1 != null)
			{
				this.delegate234_1(this, new Class498.EventArgs230((Class498.Class519)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate234_0 != null)
			{
				this.delegate234_0(this, new Class498.EventArgs230((Class498.Class519)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate234_3 != null)
			{
				this.delegate234_3(this, new Class498.EventArgs230((Class498.Class519)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate234_2 != null)
			{
				this.delegate234_2(this, new Class498.EventArgs230((Class498.Class519)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class498.Class519 class519_0)
		{
			base.Rows.Remove(class519_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tUserDataTable";
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
		private Class498.Delegate234 delegate234_0;

		[CompilerGenerated]
		private Class498.Delegate234 delegate234_1;

		[CompilerGenerated]
		private Class498.Delegate234 delegate234_2;

		[CompilerGenerated]
		private Class498.Delegate234 delegate234_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class501 : TypedTableBase<Class498.Class520>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class501()
		{
			
			
			base.TableName = "tR_Classifier";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class501(DataTable dataTable_0)
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
		protected Class501(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_9
		{
			get
			{
				return this.dataColumn_9;
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
		public Class498.Class520 this[int int_0]
		{
			get
			{
				return (Class498.Class520)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate235 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate235 @delegate = this.delegate235_0;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate235 @delegate = this.delegate235_0;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate235 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate235 @delegate = this.delegate235_1;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate235 @delegate = this.delegate235_1;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate235 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate235 @delegate = this.delegate235_2;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate235 @delegate = this.delegate235_2;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate235 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate235 @delegate = this.delegate235_3;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate235 @delegate = this.delegate235_3;
				Class498.Delegate235 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate235 value2 = (Class498.Delegate235)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate235>(ref this.delegate235_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class520 class520_0)
		{
			base.Rows.Add(class520_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class520 method_1(string string_0, string string_1, decimal decimal_0, string string_2, int int_0, string string_3, byte[] byte_0, bool bool_0, bool bool_1)
		{
			Class498.Class520 @class = (Class498.Class520)base.NewRow();
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
		public Class498.Class520 method_2(int int_0)
		{
			return (Class498.Class520)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class501 @class = (Class498.Class501)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class501();
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
		public Class498.Class520 method_5()
		{
			return (Class498.Class520)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class520(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class520);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate235_1 != null)
			{
				this.delegate235_1(this, new Class498.EventArgs231((Class498.Class520)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate235_0 != null)
			{
				this.delegate235_0(this, new Class498.EventArgs231((Class498.Class520)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate235_3 != null)
			{
				this.delegate235_3(this, new Class498.EventArgs231((Class498.Class520)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate235_2 != null)
			{
				this.delegate235_2(this, new Class498.EventArgs231((Class498.Class520)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class498.Class520 class520_0)
		{
			base.Rows.Remove(class520_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
		private Class498.Delegate235 delegate235_0;

		[CompilerGenerated]
		private Class498.Delegate235 delegate235_1;

		[CompilerGenerated]
		private Class498.Delegate235 delegate235_2;

		[CompilerGenerated]
		private Class498.Delegate235 delegate235_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class502 : TypedTableBase<Class498.Class521>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class502()
		{
			
			
			base.TableName = "tAbn";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class502(DataTable dataTable_0)
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
		protected Class502(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
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
		public Class498.Class521 this[int int_0]
		{
			get
			{
				return (Class498.Class521)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate236 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate236 @delegate = this.delegate236_0;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate236 @delegate = this.delegate236_0;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate236 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate236 @delegate = this.delegate236_1;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate236 @delegate = this.delegate236_1;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate236 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate236 @delegate = this.delegate236_2;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate236 @delegate = this.delegate236_2;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate236 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate236 @delegate = this.delegate236_3;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate236 @delegate = this.delegate236_3;
				Class498.Delegate236 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate236 value2 = (Class498.Delegate236)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate236>(ref this.delegate236_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class521 class521_0)
		{
			base.Rows.Add(class521_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class521 method_1(int int_0, string string_0, int int_1, int int_2, bool bool_0)
		{
			Class498.Class521 @class = (Class498.Class521)base.NewRow();
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class521 method_2(int int_0)
		{
			return (Class498.Class521)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class502 @class = (Class498.Class502)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class502();
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
		public Class498.Class521 method_5()
		{
			return (Class498.Class521)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class521(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class521);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate236_1 != null)
			{
				this.delegate236_1(this, new Class498.EventArgs232((Class498.Class521)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate236_0 != null)
			{
				this.delegate236_0(this, new Class498.EventArgs232((Class498.Class521)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate236_3 != null)
			{
				this.delegate236_3(this, new Class498.EventArgs232((Class498.Class521)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate236_2 != null)
			{
				this.delegate236_2(this, new Class498.EventArgs232((Class498.Class521)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class498.Class521 class521_0)
		{
			base.Rows.Remove(class521_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
		private Class498.Delegate236 delegate236_0;

		[CompilerGenerated]
		private Class498.Delegate236 delegate236_1;

		[CompilerGenerated]
		private Class498.Delegate236 delegate236_2;

		[CompilerGenerated]
		private Class498.Delegate236 delegate236_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class503 : TypedTableBase<Class498.Class522>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class503()
		{
			
			
			base.TableName = "tMaterial";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class503(DataTable dataTable_0)
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
		protected Class503(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_3;
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
		public Class498.Class522 this[int int_0]
		{
			get
			{
				return (Class498.Class522)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate237 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate237 @delegate = this.delegate237_0;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate237 @delegate = this.delegate237_0;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate237 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate237 @delegate = this.delegate237_1;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate237 @delegate = this.delegate237_1;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate237 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate237 @delegate = this.delegate237_2;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate237 @delegate = this.delegate237_2;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate237 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate237 @delegate = this.delegate237_3;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate237 @delegate = this.delegate237_3;
				Class498.Delegate237 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate237 value2 = (Class498.Delegate237)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate237>(ref this.delegate237_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class522 class522_0)
		{
			base.Rows.Add(class522_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class522 method_1(string string_0, bool bool_0, int int_0)
		{
			Class498.Class522 @class = (Class498.Class522)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				string_0,
				bool_0,
				int_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class522 method_2(int int_0)
		{
			return (Class498.Class522)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class503 @class = (Class498.Class503)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class503();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["Name"];
			this.dataColumn_2 = base.Columns["Deleted"];
			this.dataColumn_3 = base.Columns["ParentID"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("ParentID", typeof(int), null, MappingType.Element);
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
			this.dataColumn_1.MaxLength = 50;
			this.dataColumn_2.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class522 method_5()
		{
			return (Class498.Class522)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class522(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class522);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate237_1 != null)
			{
				this.delegate237_1(this, new Class498.EventArgs233((Class498.Class522)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate237_0 != null)
			{
				this.delegate237_0(this, new Class498.EventArgs233((Class498.Class522)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate237_3 != null)
			{
				this.delegate237_3(this, new Class498.EventArgs233((Class498.Class522)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate237_2 != null)
			{
				this.delegate237_2(this, new Class498.EventArgs233((Class498.Class522)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class498.Class522 class522_0)
		{
			base.Rows.Remove(class522_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tMaterialDataTable";
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
		private Class498.Delegate237 delegate237_0;

		[CompilerGenerated]
		private Class498.Delegate237 delegate237_1;

		[CompilerGenerated]
		private Class498.Delegate237 delegate237_2;

		[CompilerGenerated]
		private Class498.Delegate237 delegate237_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class504 : TypedTableBase<Class498.Class523>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class504()
		{
			
			
			base.TableName = "tblLock";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class504(DataTable dataTable_0)
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
		protected Class504(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public DataColumn TableColumn
		{
			get
			{
				return this.dataColumn_1;
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
		public Class498.Class523 this[int int_0]
		{
			get
			{
				return (Class498.Class523)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate238 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate238 @delegate = this.delegate238_0;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate238 @delegate = this.delegate238_0;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate238 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate238 @delegate = this.delegate238_1;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate238 @delegate = this.delegate238_1;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate238 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate238 @delegate = this.delegate238_2;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate238 @delegate = this.delegate238_2;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate238 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate238 @delegate = this.delegate238_3;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate238 @delegate = this.delegate238_3;
				Class498.Delegate238 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate238 value2 = (Class498.Delegate238)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate238>(ref this.delegate238_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class498.Class523 class523_0)
		{
			base.Rows.Add(class523_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class523 method_1(int int_0, string string_0)
		{
			Class498.Class523 @class = (Class498.Class523)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class523 method_2(int int_0, string string_0)
		{
			return (Class498.Class523)base.Rows.Find(new object[]
			{
				int_0,
				string_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class504 @class = (Class498.Class504)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class504();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["idLock"];
			this.dataColumn_1 = base.Columns["Table"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("idLock", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Table", typeof(string), null, MappingType.Element);
			this.dataColumn_1.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "TableColumn");
			this.dataColumn_1.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnTable");
			this.dataColumn_1.ExtendedProperties.Add("Generator_UserColumnName", "Table");
			base.Columns.Add(this.dataColumn_1);
			base.Constraints.Add(new UniqueConstraint("tblLockKey1", new DataColumn[]
			{
				this.dataColumn_0,
				this.dataColumn_1
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_1.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class523 xakHchiowjB()
		{
			return (Class498.Class523)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class523(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class523);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate238_1 != null)
			{
				this.delegate238_1(this, new Class498.EventArgs234((Class498.Class523)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate238_0 != null)
			{
				this.delegate238_0(this, new Class498.EventArgs234((Class498.Class523)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate238_3 != null)
			{
				this.delegate238_3(this, new Class498.EventArgs234((Class498.Class523)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate238_2 != null)
			{
				this.delegate238_2(this, new Class498.EventArgs234((Class498.Class523)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class498.Class523 class523_0)
		{
			base.Rows.Remove(class523_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tblLockDataTable";
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

		[CompilerGenerated]
		private Class498.Delegate238 delegate238_0;

		[CompilerGenerated]
		private Class498.Delegate238 delegate238_1;

		[CompilerGenerated]
		private Class498.Delegate238 delegate238_2;

		[CompilerGenerated]
		private Class498.Delegate238 delegate238_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class505 : TypedTableBase<Class498.Class524>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class505()
		{
			
			
			base.TableName = "tJ_CalcLoss";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class505(DataTable dataTable_0)
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
		protected Class505(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class498.Class524 this[int int_0]
		{
			get
			{
				return (Class498.Class524)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate239 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate239 @delegate = this.delegate239_0;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.delegate239_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate239 @delegate = this.delegate239_0;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.delegate239_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate239 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate239 @delegate = this.rxfHaqyEtqK;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.rxfHaqyEtqK, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate239 @delegate = this.rxfHaqyEtqK;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.rxfHaqyEtqK, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate239 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate239 @delegate = this.delegate239_1;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.delegate239_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate239 @delegate = this.delegate239_1;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.delegate239_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate239 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate239 @delegate = this.delegate239_2;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.delegate239_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate239 @delegate = this.delegate239_2;
				Class498.Delegate239 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate239 value2 = (Class498.Delegate239)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate239>(ref this.delegate239_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class498.Class524 class524_0)
		{
			base.Rows.Add(class524_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class524 method_1(int int_0, int int_1, string string_0, int int_2, int int_3, int int_4, string string_1, DateTime dateTime_0, int int_5, string string_2, bool bool_0, bool bool_1)
		{
			Class498.Class524 @class = (Class498.Class524)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				string_0,
				int_2,
				int_3,
				int_4,
				string_1,
				dateTime_0,
				int_5,
				string_2,
				bool_0,
				bool_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class524 method_2(int int_0)
		{
			return (Class498.Class524)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class505 @class = (Class498.Class505)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class505();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["num"];
			this.dataColumn_2 = base.Columns["typeCalc"];
			this.dataColumn_3 = base.Columns["nameCalc"];
			this.dataColumn_4 = base.Columns["idAbn"];
			this.dataColumn_5 = base.Columns["idAbnObj"];
			this.dataColumn_6 = base.Columns["idAbnBalance"];
			this.dataColumn_7 = base.Columns["tpName"];
			this.dataColumn_8 = base.Columns["DateCalc"];
			this.dataColumn_9 = base.Columns["idOwner"];
			this.dataColumn_10 = base.Columns["Comment"];
			this.dataColumn_11 = base.Columns["isActive"];
			this.dataColumn_12 = base.Columns["deleted"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("num", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("typeCalc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("nameCalc", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("idAbnBalance", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("tpName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("DateCalc", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("idOwner", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("isActive", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
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
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 512;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_6.AllowDBNull = false;
			this.dataColumn_8.AllowDBNull = false;
			this.dataColumn_10.MaxLength = 1024;
			this.dataColumn_11.AllowDBNull = false;
			this.dataColumn_12.AllowDBNull = false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class524 method_5()
		{
			return (Class498.Class524)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class524(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class524);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.rxfHaqyEtqK != null)
			{
				this.rxfHaqyEtqK(this, new Class498.EventArgs235((Class498.Class524)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate239_0 != null)
			{
				this.delegate239_0(this, new Class498.EventArgs235((Class498.Class524)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate239_2 != null)
			{
				this.delegate239_2(this, new Class498.EventArgs235((Class498.Class524)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate239_1 != null)
			{
				this.delegate239_1(this, new Class498.EventArgs235((Class498.Class524)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class498.Class524 class524_0)
		{
			base.Rows.Remove(class524_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tJ_CalcLossDataTable";
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

		[CompilerGenerated]
		private Class498.Delegate239 delegate239_0;

		[CompilerGenerated]
		private Class498.Delegate239 rxfHaqyEtqK;

		[CompilerGenerated]
		private Class498.Delegate239 delegate239_1;

		[CompilerGenerated]
		private Class498.Delegate239 delegate239_2;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class506 : TypedTableBase<Class498.Class525>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class506()
		{
			
			
			base.TableName = "vJ_CalcLoss";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class506(DataTable dataTable_0)
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
		protected Class506(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.jGoHkyLpyby();
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn ArpHkLoHjCu
		{
			get
			{
				return this.dataColumn_19;
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
		public Class498.Class525 this[int int_0]
		{
			get
			{
				return (Class498.Class525)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate240 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate240 @delegate = this.delegate240_0;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate240 @delegate = this.delegate240_0;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate240 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate240 @delegate = this.delegate240_1;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate240 @delegate = this.delegate240_1;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate240 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate240 @delegate = this.delegate240_2;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate240 @delegate = this.delegate240_2;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate240 jDbHkzyjeEy
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate240 @delegate = this.delegate240_3;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate240 @delegate = this.delegate240_3;
				Class498.Delegate240 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate240 value2 = (Class498.Delegate240)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate240>(ref this.delegate240_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class498.Class525 class525_0)
		{
			base.Rows.Add(class525_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class525 method_1(int int_0, int int_1, int int_2, string string_0, string string_1, int int_3, string string_2, int int_4, string string_3, int int_5, string string_4, string string_5, DateTime dateTime_0, int int_6, string string_6, string string_7, bool bool_0, bool bool_1, decimal decimal_0, int int_7)
		{
			Class498.Class525 @class = (Class498.Class525)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				string_0,
				string_1,
				int_3,
				string_2,
				int_4,
				string_3,
				int_5,
				string_4,
				string_5,
				dateTime_0,
				int_6,
				string_6,
				string_7,
				bool_0,
				bool_1,
				decimal_0,
				int_7
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class525 method_2(int int_0)
		{
			return (Class498.Class525)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class506 @class = (Class498.Class506)base.Clone();
			@class.jGoHkyLpyby();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class506();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void jGoHkyLpyby()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["num"];
			this.dataColumn_2 = base.Columns["idTypeCalc"];
			this.dataColumn_3 = base.Columns["typeCalc"];
			this.dataColumn_4 = base.Columns["nameCalc"];
			this.dataColumn_5 = base.Columns["idAbn"];
			this.dataColumn_6 = base.Columns["nameAbn"];
			this.dataColumn_7 = base.Columns["idAbnObj"];
			this.dataColumn_8 = base.Columns["nameObj"];
			this.dataColumn_9 = base.Columns["idAbnBalance"];
			this.dataColumn_10 = base.Columns["nameAbnBalance"];
			this.dataColumn_11 = base.Columns["tpName"];
			this.dataColumn_12 = base.Columns["DateCalc"];
			this.dataColumn_13 = base.Columns["idOwner"];
			this.dataColumn_14 = base.Columns["nameOwner"];
			this.dataColumn_15 = base.Columns["Comment"];
			this.dataColumn_16 = base.Columns["isActive"];
			this.dataColumn_17 = base.Columns["deleted"];
			this.dataColumn_18 = base.Columns["CoeffLosses"];
			this.dataColumn_19 = base.Columns["CodeAbonent"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("num", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idTypeCalc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("typeCalc", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("nameCalc", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("nameAbn", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("nameObj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("idAbnBalance", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("nameAbnBalance", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("tpName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("DateCalc", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("idOwner", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("nameOwner", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("isActive", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("CoeffLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 100;
			this.dataColumn_4.MaxLength = 512;
			this.dataColumn_6.MaxLength = 100;
			this.dataColumn_7.AllowDBNull = false;
			this.dataColumn_8.ReadOnly = true;
			this.dataColumn_8.MaxLength = 385;
			this.dataColumn_9.AllowDBNull = false;
			this.dataColumn_10.MaxLength = 100;
			this.dataColumn_12.AllowDBNull = false;
			this.dataColumn_14.MaxLength = 50;
			this.dataColumn_15.MaxLength = 1024;
			this.dataColumn_16.AllowDBNull = false;
			this.dataColumn_17.AllowDBNull = false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class525 method_4()
		{
			return (Class498.Class525)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class525(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class525);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate240_1 != null)
			{
				this.delegate240_1(this, new Class498.EventArgs236((Class498.Class525)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate240_0 != null)
			{
				this.delegate240_0(this, new Class498.EventArgs236((Class498.Class525)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate240_3 != null)
			{
				this.delegate240_3(this, new Class498.EventArgs236((Class498.Class525)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate240_2 != null)
			{
				this.delegate240_2(this, new Class498.EventArgs236((Class498.Class525)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class498.Class525 class525_0)
		{
			base.Rows.Remove(class525_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "vJ_CalcLossDataTable";
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
		private Class498.Delegate240 delegate240_0;

		[CompilerGenerated]
		private Class498.Delegate240 delegate240_1;

		[CompilerGenerated]
		private Class498.Delegate240 delegate240_2;

		[CompilerGenerated]
		private Class498.Delegate240 delegate240_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class507 : TypedTableBase<Class498.Class526>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class507()
		{
			
			
			base.TableName = "vAbnObjAddress";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class507(DataTable dataTable_0)
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
		protected Class507(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class526 this[int int_0]
		{
			get
			{
				return (Class498.Class526)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate241 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate241 @delegate = this.delegate241_0;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate241 @delegate = this.delegate241_0;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate241 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate241 @delegate = this.delegate241_1;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate241 @delegate = this.delegate241_1;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate241 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate241 @delegate = this.delegate241_2;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate241 @delegate = this.delegate241_2;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate241 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate241 @delegate = this.delegate241_3;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate241 @delegate = this.delegate241_3;
				Class498.Delegate241 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate241 value2 = (Class498.Delegate241)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate241>(ref this.delegate241_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class498.Class526 class526_0)
		{
			base.Rows.Add(class526_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class526 method_1(int int_0, int int_1, int int_2, string string_0, string string_1, int int_3, string string_2, int int_4, string string_3, int int_5, string string_4, int int_6, string string_5, string string_6, bool bool_0, string string_7, double double_0, double double_1, int int_7, int int_8, string string_8, int int_9, int int_10)
		{
			Class498.Class526 @class = (Class498.Class526)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				string_0,
				string_1,
				int_3,
				string_2,
				int_4,
				string_3,
				int_5,
				string_4,
				int_6,
				string_5,
				string_6,
				bool_0,
				string_7,
				double_0,
				double_1,
				int_7,
				int_8,
				string_8,
				int_9,
				int_10
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class507 @class = (Class498.Class507)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class507();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idAbn"];
			this.dataColumn_2 = base.Columns["idMap"];
			this.dataColumn_3 = base.Columns["Name"];
			this.dataColumn_4 = base.Columns["Comment"];
			this.dataColumn_5 = base.Columns["idCity"];
			this.dataColumn_6 = base.Columns["City"];
			this.dataColumn_7 = base.Columns["idRaion"];
			this.dataColumn_8 = base.Columns["Raion"];
			this.dataColumn_9 = base.Columns["idStreet"];
			this.dataColumn_10 = base.Columns["Street"];
			this.dataColumn_11 = base.Columns["House"];
			this.dataColumn_12 = base.Columns["HousePrefix"];
			this.dataColumn_13 = base.Columns["HouseAll"];
			this.dataColumn_14 = base.Columns["IsHouse"];
			this.dataColumn_15 = base.Columns["Index"];
			this.dataColumn_16 = base.Columns["Latitude"];
			this.dataColumn_17 = base.Columns["Longitude"];
			this.dataColumn_18 = base.Columns["idObjParent"];
			this.dataColumn_19 = base.Columns["TypeObj"];
			this.dataColumn_20 = base.Columns["TypeObjName"];
			this.dataColumn_21 = base.Columns["idObjReg"];
			this.dataColumn_22 = base.Columns["TypeObjNew"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idMap", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idCity", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("City", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("idRaion", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Raion", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("idStreet", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("Street", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("House", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("HousePrefix", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("HouseAll", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("IsHouse", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("Index", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("Latitude", typeof(double), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("Longitude", typeof(double), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("idObjParent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("TypeObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("TypeObjName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("idObjReg", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("TypeObjNew", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 255;
			this.dataColumn_4.MaxLength = 512;
			this.dataColumn_6.ReadOnly = true;
			this.dataColumn_6.MaxLength = 51;
			this.dataColumn_8.MaxLength = 100;
			this.dataColumn_10.ReadOnly = true;
			this.dataColumn_10.MaxLength = 91;
			this.dataColumn_12.MaxLength = 20;
			this.dataColumn_13.ReadOnly = true;
			this.dataColumn_13.MaxLength = 30;
			this.dataColumn_15.MaxLength = 6;
			this.dataColumn_20.MaxLength = 100;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class526 method_4()
		{
			return (Class498.Class526)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class526(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class526);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate241_1 != null)
			{
				this.delegate241_1(this, new Class498.EventArgs237((Class498.Class526)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate241_0 != null)
			{
				this.delegate241_0(this, new Class498.EventArgs237((Class498.Class526)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate241_3 != null)
			{
				this.delegate241_3(this, new Class498.EventArgs237((Class498.Class526)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate241_2 != null)
			{
				this.delegate241_2(this, new Class498.EventArgs237((Class498.Class526)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class498.Class526 class526_0)
		{
			base.Rows.Remove(class526_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "vAbnObjAddressDataTable";
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

		[CompilerGenerated]
		private Class498.Delegate241 delegate241_0;

		[CompilerGenerated]
		private Class498.Delegate241 delegate241_1;

		[CompilerGenerated]
		private Class498.Delegate241 delegate241_2;

		[CompilerGenerated]
		private Class498.Delegate241 delegate241_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class508 : TypedTableBase<Class498.Class527>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class508()
		{
			
			
			base.TableName = "vR_Cable";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class508(DataTable dataTable_0)
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
		protected Class508(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_8
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
		public DataColumn UqoHexywpga
		{
			get
			{
				return this.dataColumn_11;
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
		public Class498.Class527 this[int int_0]
		{
			get
			{
				return (Class498.Class527)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate242 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate242 @delegate = this.delegate242_0;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate242 @delegate = this.delegate242_0;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate242 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate242 @delegate = this.delegate242_1;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate242 @delegate = this.delegate242_1;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate242 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate242 @delegate = this.delegate242_2;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate242 @delegate = this.delegate242_2;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate242 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate242 @delegate = this.delegate242_3;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate242 @delegate = this.delegate242_3;
				Class498.Delegate242 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate242 value2 = (Class498.Delegate242)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate242>(ref this.delegate242_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class527 class527_0)
		{
			base.Rows.Add(class527_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class527 method_1(int int_0, string string_0, string string_1, int int_1, float float_0, float float_1, float float_2, string string_2, float float_3, bool bool_0, int int_2, float float_4)
		{
			Class498.Class527 @class = (Class498.Class527)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				string_1,
				int_1,
				float_0,
				float_1,
				float_2,
				string_2,
				float_3,
				bool_0,
				int_2,
				float_4
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class527 method_2(int int_0)
		{
			return (Class498.Class527)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class508 @class = (Class498.Class508)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class508();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["FullName"];
			this.dataColumn_2 = base.Columns["CableMakeup"];
			this.dataColumn_3 = base.Columns["Wires"];
			this.dataColumn_4 = base.Columns["CrossSection"];
			this.dataColumn_5 = base.Columns["Amperage"];
			this.dataColumn_6 = base.Columns["Resistance"];
			this.dataColumn_7 = base.Columns["VoltageTypeName"];
			this.dataColumn_8 = base.Columns["VoltageValue"];
			this.dataColumn_9 = base.Columns["Deleted"];
			this.dataColumn_10 = base.Columns["WiresAddl"];
			this.dataColumn_11 = base.Columns["CrossSectionAddl"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("FullName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("CableMakeup", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Wires", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("CrossSection", typeof(float), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Amperage", typeof(float), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Resistance", typeof(float), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("VoltageTypeName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("VoltageValue", typeof(float), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("WiresAddl", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("CrossSectionAddl", typeof(float), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.ReadOnly = true;
			this.dataColumn_1.MaxLength = 173;
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_2.MaxLength = 50;
			this.dataColumn_7.MaxLength = 100;
			this.dataColumn_9.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class527 method_5()
		{
			return (Class498.Class527)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class527(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class527);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate242_1 != null)
			{
				this.delegate242_1(this, new Class498.EventArgs238((Class498.Class527)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate242_0 != null)
			{
				this.delegate242_0(this, new Class498.EventArgs238((Class498.Class527)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate242_3 != null)
			{
				this.delegate242_3(this, new Class498.EventArgs238((Class498.Class527)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate242_2 != null)
			{
				this.delegate242_2(this, new Class498.EventArgs238((Class498.Class527)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class498.Class527 class527_0)
		{
			base.Rows.Remove(class527_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "vR_CableDataTable";
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
		private Class498.Delegate242 delegate242_0;

		[CompilerGenerated]
		private Class498.Delegate242 delegate242_1;

		[CompilerGenerated]
		private Class498.Delegate242 delegate242_2;

		[CompilerGenerated]
		private Class498.Delegate242 delegate242_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class509 : TypedTableBase<Class498.Class528>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class509()
		{
			
			
			base.TableName = "tJ_CalcLossCable";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class509(DataTable dataTable_0)
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
		protected Class509(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.zIoHwCogNuZ;
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
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_12
		{
			get
			{
				return this.dataColumn_12;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn NfyHbOvdTpT
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
		[DebuggerNonUserCode]
		public DataColumn DataColumn_20
		{
			get
			{
				return this.dataColumn_21;
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
		public Class498.Class528 this[int int_0]
		{
			get
			{
				return (Class498.Class528)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate243 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate243 @delegate = this.delegate243_0;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate243 @delegate = this.delegate243_0;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate243 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate243 @delegate = this.delegate243_1;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate243 @delegate = this.delegate243_1;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate243 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate243 @delegate = this.delegate243_2;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate243 @delegate = this.delegate243_2;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate243 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate243 @delegate = this.delegate243_3;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate243 @delegate = this.delegate243_3;
				Class498.Delegate243 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate243 value2 = (Class498.Delegate243)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate243>(ref this.delegate243_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class528 class528_0)
		{
			base.Rows.Add(class528_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class528 method_1(int int_0, int int_1, decimal decimal_0, decimal decimal_1, decimal decimal_2, int int_2, int int_3, decimal decimal_3, decimal decimal_4, decimal decimal_5, int int_4, decimal decimal_6, decimal decimal_7, decimal decimal_8, decimal decimal_9, decimal decimal_10, decimal decimal_11, decimal decimal_12, decimal decimal_13, bool bool_0, decimal decimal_14, decimal decimal_15)
		{
			Class498.Class528 @class = (Class498.Class528)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				decimal_0,
				decimal_1,
				decimal_2,
				int_2,
				int_3,
				decimal_3,
				decimal_4,
				decimal_5,
				int_4,
				decimal_6,
				decimal_7,
				decimal_8,
				decimal_9,
				decimal_10,
				decimal_11,
				decimal_12,
				decimal_13,
				bool_0,
				decimal_14,
				decimal_15
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class528 method_2(int int_0)
		{
			return (Class498.Class528)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class509 @class = (Class498.Class509)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class509();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idCalc"];
			this.dataColumn_2 = base.Columns["makeupCable"];
			this.dataColumn_3 = base.Columns["lenghtCable"];
			this.dataColumn_4 = base.Columns["UdResistance"];
			this.dataColumn_5 = base.Columns["Voltage"];
			this.zIoHwCogNuZ = base.Columns["consumption"];
			this.dataColumn_6 = base.Columns["period"];
			this.dataColumn_7 = base.Columns["CoeffPowerREactive"];
			this.dataColumn_8 = base.Columns["SquareCoeffFromGraph"];
			this.dataColumn_9 = base.Columns["CoeffDifferences"];
			this.dataColumn_10 = base.Columns["CountChain"];
			this.dataColumn_11 = base.Columns["ActiveResistance"];
			this.dataColumn_12 = base.Columns["LoadPowerLoss"];
			this.dataColumn_13 = base.Columns["LoadAverage"];
			this.dataColumn_14 = base.Columns["LoadLosses"];
			this.dataColumn_15 = base.Columns["UnitYearLoss"];
			this.dataColumn_16 = base.Columns["YearLoss"];
			this.dataColumn_17 = base.Columns["SumLoadLosses"];
			this.dataColumn_18 = base.Columns["CoeffLosses"];
			this.dataColumn_19 = base.Columns["isIsolation"];
			this.dataColumn_20 = base.Columns["CoeffIsolation"];
			this.dataColumn_21 = base.Columns["IsolationLosses"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idCalc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("makeupCable", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("lenghtCable", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("UdResistance", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Voltage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.zIoHwCogNuZ = new DataColumn("consumption", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.zIoHwCogNuZ);
			this.dataColumn_6 = new DataColumn("period", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("CoeffPowerREactive", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("SquareCoeffFromGraph", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("CoeffDifferences", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("CountChain", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("ActiveResistance", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("LoadPowerLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("LoadAverage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("LoadLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("UnitYearLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("YearLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("SumLoadLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("CoeffLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("isIsolation", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("CoeffIsolation", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("IsolationLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
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
			this.dataColumn_19.DefaultValue = false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class528 method_5()
		{
			return (Class498.Class528)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class528(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class528);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate243_1 != null)
			{
				this.delegate243_1(this, new Class498.EventArgs239((Class498.Class528)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate243_0 != null)
			{
				this.delegate243_0(this, new Class498.EventArgs239((Class498.Class528)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate243_3 != null)
			{
				this.delegate243_3(this, new Class498.EventArgs239((Class498.Class528)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate243_2 != null)
			{
				this.delegate243_2(this, new Class498.EventArgs239((Class498.Class528)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class498.Class528 class528_0)
		{
			base.Rows.Remove(class528_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tJ_CalcLossCableDataTable";
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

		private DataColumn zIoHwCogNuZ;

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

		[CompilerGenerated]
		private Class498.Delegate243 delegate243_0;

		[CompilerGenerated]
		private Class498.Delegate243 delegate243_1;

		[CompilerGenerated]
		private Class498.Delegate243 delegate243_2;

		[CompilerGenerated]
		private Class498.Delegate243 delegate243_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class510 : TypedTableBase<Class498.Class529>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class510()
		{
			
			
			base.TableName = "vAbn";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class510(DataTable dataTable_0)
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
		protected Class510(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.NluHwtocwDU();
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
		public DataColumn idWorkerColumn
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_8;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_9;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_8
		{
			get
			{
				return this.dataColumn_10;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_9
		{
			get
			{
				return this.dataColumn_11;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_10
		{
			get
			{
				return this.dataColumn_12;
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
		public Class498.Class529 this[int int_0]
		{
			get
			{
				return (Class498.Class529)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate244 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate244 @delegate = this.delegate244_0;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate244 @delegate = this.delegate244_0;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate244 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate244 @delegate = this.delegate244_1;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate244 @delegate = this.delegate244_1;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate244 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate244 @delegate = this.delegate244_2;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate244 @delegate = this.delegate244_2;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate244 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate244 @delegate = this.delegate244_3;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate244 @delegate = this.delegate244_3;
				Class498.Delegate244 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate244 value2 = (Class498.Delegate244)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate244>(ref this.delegate244_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class529 class529_0)
		{
			base.Rows.Add(class529_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class529 method_1(int int_0, int int_1, string string_0, int int_2, int int_3, bool bool_0, string string_1, string string_2, string string_3, bool bool_1, string string_4, DateTime dateTime_0, int int_4)
		{
			Class498.Class529 @class = (Class498.Class529)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				string_0,
				int_2,
				int_3,
				bool_0,
				string_1,
				string_2,
				string_3,
				bool_1,
				string_4,
				dateTime_0,
				int_4
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class529 method_2(int int_0)
		{
			return (Class498.Class529)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class510 @class = (Class498.Class510)base.Clone();
			@class.NluHwtocwDU();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class510();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void NluHwtocwDU()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["CodeAbonent"];
			this.dataColumn_2 = base.Columns["Name"];
			this.dataColumn_3 = base.Columns["TypeAbn"];
			this.dataColumn_4 = base.Columns["idWorker"];
			this.dataColumn_5 = base.Columns["Deleted"];
			this.dataColumn_6 = base.Columns["TypeName"];
			this.dataColumn_7 = base.Columns["TypeNameSocr"];
			this.dataColumn_8 = base.Columns["Worker"];
			this.dataColumn_9 = base.Columns["isActive"];
			this.dataColumn_10 = base.Columns["Reason"];
			this.dataColumn_11 = base.Columns["datechange"];
			this.dataColumn_12 = base.Columns["idReason"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
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
			this.dataColumn_6 = new DataColumn("TypeName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("TypeNameSocr", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Worker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("isActive", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("Reason", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("datechange", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("idReason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.MaxLength = 100;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_4.AllowDBNull = false;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_6.MaxLength = 100;
			this.dataColumn_7.MaxLength = 50;
			this.dataColumn_8.ReadOnly = true;
			this.dataColumn_8.MaxLength = 35;
			this.dataColumn_10.MaxLength = 100;
			this.dataColumn_11.ReadOnly = true;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class529 method_4()
		{
			return (Class498.Class529)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class529(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class529);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate244_1 != null)
			{
				this.delegate244_1(this, new Class498.EventArgs240((Class498.Class529)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate244_0 != null)
			{
				this.delegate244_0(this, new Class498.EventArgs240((Class498.Class529)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate244_3 != null)
			{
				this.delegate244_3(this, new Class498.EventArgs240((Class498.Class529)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate244_2 != null)
			{
				this.delegate244_2(this, new Class498.EventArgs240((Class498.Class529)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class498.Class529 class529_0)
		{
			base.Rows.Remove(class529_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "vAbnDataTable";
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

		[CompilerGenerated]
		private Class498.Delegate244 delegate244_0;

		[CompilerGenerated]
		private Class498.Delegate244 delegate244_1;

		[CompilerGenerated]
		private Class498.Delegate244 delegate244_2;

		[CompilerGenerated]
		private Class498.Delegate244 delegate244_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class511 : TypedTableBase<Class498.Class530>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class511()
		{
			
			
			base.TableName = "dtSource";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class511(DataTable dataTable_0)
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
		protected Class511(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class498.Class530 this[int int_0]
		{
			get
			{
				return (Class498.Class530)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate245 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate245 @delegate = this.delegate245_0;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate245 @delegate = this.delegate245_0;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate245 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate245 @delegate = this.delegate245_1;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate245 @delegate = this.delegate245_1;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate245 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate245 @delegate = this.delegate245_2;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate245 @delegate = this.delegate245_2;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate245 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate245 @delegate = this.delegate245_3;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate245 @delegate = this.delegate245_3;
				Class498.Delegate245 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate245 value2 = (Class498.Delegate245)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate245>(ref this.delegate245_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class530 class530_0)
		{
			base.Rows.Add(class530_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class530 method_1(string string_0, string string_1, string string_2)
		{
			Class498.Class530 @class = (Class498.Class530)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				string_1,
				string_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class511 @class = (Class498.Class511)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class511();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Desription"];
			this.dataColumn_1 = base.Columns["Dimension"];
			this.dataColumn_2 = base.Columns["Val"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Desription", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Dimension", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Val", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class530 method_4()
		{
			return (Class498.Class530)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class530(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class530);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate245_1 != null)
			{
				this.delegate245_1(this, new Class498.EventArgs241((Class498.Class530)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate245_0 != null)
			{
				this.delegate245_0(this, new Class498.EventArgs241((Class498.Class530)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate245_3 != null)
			{
				this.delegate245_3(this, new Class498.EventArgs241((Class498.Class530)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate245_2 != null)
			{
				this.delegate245_2(this, new Class498.EventArgs241((Class498.Class530)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class498.Class530 class530_0)
		{
			base.Rows.Remove(class530_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "dtSourceDataTable";
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
		private Class498.Delegate245 delegate245_0;

		[CompilerGenerated]
		private Class498.Delegate245 delegate245_1;

		[CompilerGenerated]
		private Class498.Delegate245 delegate245_2;

		[CompilerGenerated]
		private Class498.Delegate245 delegate245_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class512 : TypedTableBase<Class498.Class531>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class512()
		{
			
			
			base.TableName = "tJ_CalcLossFile";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class512(DataTable dataTable_0)
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
		protected Class512(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class531 this[int int_0]
		{
			get
			{
				return (Class498.Class531)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate246 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate246 @delegate = this.delegate246_0;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate246 @delegate = this.delegate246_0;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate246 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate246 @delegate = this.delegate246_1;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate246 @delegate = this.delegate246_1;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate246 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate246 @delegate = this.delegate246_2;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate246 @delegate = this.delegate246_2;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate246 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate246 @delegate = this.delegate246_3;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate246 @delegate = this.delegate246_3;
				Class498.Delegate246 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate246 value2 = (Class498.Delegate246)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate246>(ref this.delegate246_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class531 class531_0)
		{
			base.Rows.Add(class531_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class531 method_1(int int_0, string string_0, byte[] byte_0, DateTime dateTime_0)
		{
			Class498.Class531 @class = (Class498.Class531)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				string_0,
				byte_0,
				dateTime_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class531 method_2(int int_0)
		{
			return (Class498.Class531)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class512 @class = (Class498.Class512)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class512();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idCalc"];
			this.dataColumn_2 = base.Columns["FileName"];
			this.dataColumn_3 = base.Columns["File"];
			this.dataColumn_4 = base.Columns["DateIn"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idCalc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("FileName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("File", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("DateIn", typeof(DateTime), null, MappingType.Element);
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
			this.dataColumn_2.MaxLength = 1024;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class531 method_5()
		{
			return (Class498.Class531)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class531(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class531);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate246_1 != null)
			{
				this.delegate246_1(this, new Class498.EventArgs242((Class498.Class531)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate246_0 != null)
			{
				this.delegate246_0(this, new Class498.EventArgs242((Class498.Class531)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate246_3 != null)
			{
				this.delegate246_3(this, new Class498.EventArgs242((Class498.Class531)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate246_2 != null)
			{
				this.delegate246_2(this, new Class498.EventArgs242((Class498.Class531)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class498.Class531 class531_0)
		{
			base.Rows.Remove(class531_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tJ_CalcLossFileDataTable";
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
		private Class498.Delegate246 delegate246_0;

		[CompilerGenerated]
		private Class498.Delegate246 delegate246_1;

		[CompilerGenerated]
		private Class498.Delegate246 delegate246_2;

		[CompilerGenerated]
		private Class498.Delegate246 delegate246_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class513 : TypedTableBase<Class498.Class532>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class513()
		{
			
			
			base.TableName = "vL_SchmAbn";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class513(DataTable dataTable_0)
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
		protected Class513(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public DataColumn idSchmObjColumn
		{
			get
			{
				return this.dataColumn_1;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_0
		{
			get
			{
				return this.dataColumn_2;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_1
		{
			get
			{
				return this.dataColumn_3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_3
		{
			get
			{
				return this.dataColumn_5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_4
		{
			get
			{
				return this.dataColumn_6;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_5
		{
			get
			{
				return this.dataColumn_7;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_6
		{
			get
			{
				return this.dataColumn_8;
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
		public Class498.Class532 this[int int_0]
		{
			get
			{
				return (Class498.Class532)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate247 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate247 @delegate = this.delegate247_0;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate247 @delegate = this.delegate247_0;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate247 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate247 @delegate = this.delegate247_1;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate247 @delegate = this.delegate247_1;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate247 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate247 @delegate = this.delegate247_2;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate247 @delegate = this.delegate247_2;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate247 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate247 @delegate = this.delegate247_3;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate247 @delegate = this.delegate247_3;
				Class498.Delegate247 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate247 value2 = (Class498.Delegate247)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate247>(ref this.delegate247_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class532 class532_0)
		{
			base.Rows.Add(class532_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class532 method_1(int int_0, int int_1, string string_0, int int_2, int int_3, int int_4, int int_5, int int_6, string string_1)
		{
			Class498.Class532 @class = (Class498.Class532)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				string_0,
				int_2,
				int_3,
				int_4,
				int_5,
				int_6,
				string_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class532 method_2(int int_0)
		{
			return (Class498.Class532)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class498.Class513 @class = (Class498.Class513)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class513();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idSchmObj"];
			this.dataColumn_2 = base.Columns["SchmObjName"];
			this.dataColumn_3 = base.Columns["idAbn"];
			this.dataColumn_4 = base.Columns["idAbnObj"];
			this.dataColumn_5 = base.Columns["idPoint"];
			this.dataColumn_6 = base.Columns["idDoc"];
			this.dataColumn_7 = base.Columns["TypeDoc"];
			this.dataColumn_8 = base.Columns["typeDocName"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idSchmObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("SchmObjName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idPoint", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("idDoc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("TypeDoc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("typeDocName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_0
			}, true));
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.Unique = true;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.ReadOnly = true;
			this.dataColumn_2.MaxLength = 1000;
			this.dataColumn_8.MaxLength = 100;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class532 method_5()
		{
			return (Class498.Class532)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class532(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class532);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate247_1 != null)
			{
				this.delegate247_1(this, new Class498.EventArgs243((Class498.Class532)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate247_0 != null)
			{
				this.delegate247_0(this, new Class498.EventArgs243((Class498.Class532)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate247_3 != null)
			{
				this.delegate247_3(this, new Class498.EventArgs243((Class498.Class532)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate247_2 != null)
			{
				this.delegate247_2(this, new Class498.EventArgs243((Class498.Class532)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class498.Class532 class532_0)
		{
			base.Rows.Remove(class532_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "vL_SchmAbnDataTable";
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
		private Class498.Delegate247 delegate247_0;

		[CompilerGenerated]
		private Class498.Delegate247 delegate247_1;

		[CompilerGenerated]
		private Class498.Delegate247 delegate247_2;

		[CompilerGenerated]
		private Class498.Delegate247 delegate247_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class514 : TypedTableBase<Class498.Class533>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class514()
		{
			
			
			base.TableName = "vR_Transformer";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class514(DataTable dataTable_0)
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
		protected Class514(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public Class498.Class533 this[int int_0]
		{
			get
			{
				return (Class498.Class533)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate248 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate248 @delegate = this.delegate248_0;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate248 @delegate = this.delegate248_0;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate248 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate248 @delegate = this.delegate248_1;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate248 @delegate = this.delegate248_1;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate248 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate248 @delegate = this.delegate248_2;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate248 @delegate = this.delegate248_2;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate248 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate248 @delegate = this.delegate248_3;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate248 @delegate = this.delegate248_3;
				Class498.Delegate248 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate248 value2 = (Class498.Delegate248)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate248>(ref this.delegate248_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class498.Class533 class533_0)
		{
			base.Rows.Add(class533_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class533 method_1(string string_0, string string_1, string string_2, int int_0, decimal decimal_0, decimal decimal_1, decimal decimal_2, decimal decimal_3, string string_3, decimal decimal_4, float float_0, float float_1, bool bool_0)
		{
			Class498.Class533 @class = (Class498.Class533)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				string_0,
				string_1,
				string_2,
				int_0,
				decimal_0,
				decimal_1,
				decimal_2,
				decimal_3,
				string_3,
				decimal_4,
				float_0,
				float_1,
				bool_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class533 method_2(int int_0)
		{
			return (Class498.Class533)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class514 @class = (Class498.Class514)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class514();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["FullName"];
			this.dataColumn_2 = base.Columns["Name"];
			this.dataColumn_3 = base.Columns["Type"];
			this.dataColumn_4 = base.Columns["Power"];
			this.dataColumn_5 = base.Columns["HighVoltage"];
			this.dataColumn_6 = base.Columns["LowVoltage"];
			this.dataColumn_7 = base.Columns["RatedAmperHV"];
			this.dataColumn_8 = base.Columns["RatedAmperLV"];
			this.dataColumn_9 = base.Columns["GroupWindings"];
			this.dataColumn_10 = base.Columns["ShortCircuitVolt"];
			this.dataColumn_11 = base.Columns["ShortCircuitLoss"];
			this.dataColumn_12 = base.Columns["NoLoadLoss"];
			this.dataColumn_13 = base.Columns["Deleted"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("FullName", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Type", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Power", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("HighVoltage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("LowVoltage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("RatedAmperHV", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("RatedAmperLV", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("GroupWindings", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("ShortCircuitVolt", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("ShortCircuitLoss", typeof(float), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("NoLoadLoss", typeof(float), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
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
			this.dataColumn_1.ReadOnly = true;
			this.dataColumn_1.MaxLength = 123;
			this.dataColumn_2.AllowDBNull = false;
			this.dataColumn_2.MaxLength = 50;
			this.dataColumn_3.AllowDBNull = false;
			this.dataColumn_3.MaxLength = 50;
			this.dataColumn_4.AllowDBNull = false;
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_6.AllowDBNull = false;
			this.dataColumn_9.MaxLength = 50;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class533 method_5()
		{
			return (Class498.Class533)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class533(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class533);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate248_1 != null)
			{
				this.delegate248_1(this, new Class498.EventArgs244((Class498.Class533)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate248_0 != null)
			{
				this.delegate248_0(this, new Class498.EventArgs244((Class498.Class533)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate248_3 != null)
			{
				this.delegate248_3(this, new Class498.EventArgs244((Class498.Class533)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate248_2 != null)
			{
				this.delegate248_2(this, new Class498.EventArgs244((Class498.Class533)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class498.Class533 class533_0)
		{
			base.Rows.Remove(class533_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "vR_TransformerDataTable";
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

		[CompilerGenerated]
		private Class498.Delegate248 delegate248_0;

		[CompilerGenerated]
		private Class498.Delegate248 delegate248_1;

		[CompilerGenerated]
		private Class498.Delegate248 delegate248_2;

		[CompilerGenerated]
		private Class498.Delegate248 delegate248_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class515 : TypedTableBase<Class498.Class534>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class515()
		{
			
			
			base.TableName = "tJ_CalcLossTrans";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class515(DataTable dataTable_0)
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
		protected Class515(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public Class498.Class534 this[int int_0]
		{
			get
			{
				return (Class498.Class534)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate249 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate249 @delegate = this.delegate249_0;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate249 @delegate = this.delegate249_0;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate249 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate249 @delegate = this.delegate249_1;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate249 @delegate = this.delegate249_1;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate249 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate249 @delegate = this.delegate249_2;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate249 @delegate = this.delegate249_2;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate249 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate249 @delegate = this.delegate249_3;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate249 @delegate = this.delegate249_3;
				Class498.Delegate249 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate249 value2 = (Class498.Delegate249)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate249>(ref this.delegate249_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class498.Class534 class534_0)
		{
			base.Rows.Add(class534_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class534 method_1(int int_0, int int_1, int int_2, decimal decimal_0, decimal decimal_1, decimal decimal_2, int int_3, decimal decimal_3, int int_4, decimal decimal_4, decimal decimal_5, decimal decimal_6, decimal decimal_7, decimal decimal_8, decimal decimal_9, decimal decimal_10, decimal decimal_11, decimal decimal_12, decimal decimal_13)
		{
			Class498.Class534 @class = (Class498.Class534)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				int_2,
				decimal_0,
				decimal_1,
				decimal_2,
				int_3,
				decimal_3,
				int_4,
				decimal_4,
				decimal_5,
				decimal_6,
				decimal_7,
				decimal_8,
				decimal_9,
				decimal_10,
				decimal_11,
				decimal_12,
				decimal_13
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class534 method_2(int int_0)
		{
			return (Class498.Class534)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class515 @class = (Class498.Class515)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class515();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idCalc"];
			this.dataColumn_2 = base.Columns["numTrans"];
			this.dataColumn_3 = base.Columns["makeupTrans"];
			this.dataColumn_4 = base.Columns["RatedPower"];
			this.dataColumn_5 = base.Columns["NoLoadLoss"];
			this.dataColumn_6 = base.Columns["ShortCircuitLoss"];
			this.dataColumn_7 = base.Columns["Consumption"];
			this.dataColumn_8 = base.Columns["RatedVoltage"];
			this.dataColumn_9 = base.Columns["Period"];
			this.dataColumn_10 = base.Columns["MiddleVoltage"];
			this.dataColumn_11 = base.Columns["CoeffPowerReactive"];
			this.dataColumn_12 = base.Columns["SquareCoeffFromGraph"];
			this.dataColumn_13 = base.Columns["CoeffDifference"];
			this.dataColumn_14 = base.Columns["LossElectrHH"];
			this.dataColumn_15 = base.Columns["ActiveResistance"];
			this.dataColumn_16 = base.Columns["LoadPowerLoss"];
			this.dataColumn_17 = base.Columns["LoadAverage"];
			this.dataColumn_18 = base.Columns["LoadLosses"];
			this.dataColumn_19 = base.Columns["CoeffLosses"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idCalc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("numTrans", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("makeupTrans", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("RatedPower", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("NoLoadLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("ShortCircuitLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Consumption", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("RatedVoltage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Period", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("MiddleVoltage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("CoeffPowerReactive", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("SquareCoeffFromGraph", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("CoeffDifference", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("LossElectrHH", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("ActiveResistance", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("LoadPowerLoss", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("LoadAverage", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("LoadLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("CoeffLosses", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
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
			this.dataColumn_3.AllowDBNull = false;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class534 method_5()
		{
			return (Class498.Class534)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class534(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class534);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate249_1 != null)
			{
				this.delegate249_1(this, new Class498.EventArgs245((Class498.Class534)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate249_0 != null)
			{
				this.delegate249_0(this, new Class498.EventArgs245((Class498.Class534)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate249_3 != null)
			{
				this.delegate249_3(this, new Class498.EventArgs245((Class498.Class534)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate249_2 != null)
			{
				this.delegate249_2(this, new Class498.EventArgs245((Class498.Class534)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class498.Class534 class534_0)
		{
			base.Rows.Remove(class534_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tJ_CalcLossTransDataTable";
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
		private Class498.Delegate249 delegate249_0;

		[CompilerGenerated]
		private Class498.Delegate249 delegate249_1;

		[CompilerGenerated]
		private Class498.Delegate249 delegate249_2;

		[CompilerGenerated]
		private Class498.Delegate249 delegate249_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class516 : TypedTableBase<Class498.Class535>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class516()
		{
			
			
			base.TableName = "tJ_CalcLossTransHH";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class516(DataTable dataTable_0)
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
		protected Class516(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class498.Class535 this[int int_0]
		{
			get
			{
				return (Class498.Class535)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate250 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate250 @delegate = this.delegate250_0;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate250 @delegate = this.delegate250_0;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate250 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate250 @delegate = this.delegate250_1;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate250 @delegate = this.delegate250_1;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate250 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate250 @delegate = this.delegate250_2;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate250 @delegate = this.delegate250_2;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate250 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate250 @delegate = this.delegate250_3;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate250 @delegate = this.delegate250_3;
				Class498.Delegate250 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate250 value2 = (Class498.Delegate250)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate250>(ref this.delegate250_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class498.Class535 class535_0)
		{
			base.Rows.Add(class535_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class535 method_1(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, int int_12, int int_13)
		{
			Class498.Class535 @class = (Class498.Class535)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				int_0,
				int_1,
				int_2,
				int_3,
				int_4,
				int_5,
				int_6,
				int_7,
				int_8,
				int_9,
				int_10,
				int_11,
				int_12,
				int_13
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class535 method_2(int int_0)
		{
			return (Class498.Class535)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class516 @class = (Class498.Class516)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class516();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["idCalc"];
			this.dataColumn_2 = base.Columns["idTrans"];
			this.dataColumn_3 = base.Columns["month01"];
			this.dataColumn_4 = base.Columns["month02"];
			this.dataColumn_5 = base.Columns["month03"];
			this.dataColumn_6 = base.Columns["month04"];
			this.dataColumn_7 = base.Columns["month05"];
			this.dataColumn_8 = base.Columns["month06"];
			this.dataColumn_9 = base.Columns["month07"];
			this.dataColumn_10 = base.Columns["month08"];
			this.dataColumn_11 = base.Columns["month09"];
			this.dataColumn_12 = base.Columns["month10"];
			this.dataColumn_13 = base.Columns["month11"];
			this.dataColumn_14 = base.Columns["month12"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("idCalc", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("idTrans", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("month01", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("month02", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("month03", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("month04", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("month05", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("month06", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("month07", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("month08", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("month09", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("month10", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("month11", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("month12", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
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
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class535 method_5()
		{
			return (Class498.Class535)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class535(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class535);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate250_1 != null)
			{
				this.delegate250_1(this, new Class498.EventArgs246((Class498.Class535)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate250_0 != null)
			{
				this.delegate250_0(this, new Class498.EventArgs246((Class498.Class535)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate250_3 != null)
			{
				this.delegate250_3(this, new Class498.EventArgs246((Class498.Class535)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate250_2 != null)
			{
				this.delegate250_2(this, new Class498.EventArgs246((Class498.Class535)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class498.Class535 class535_0)
		{
			base.Rows.Remove(class535_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "tJ_CalcLossTransHHDataTable";
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

		[CompilerGenerated]
		private Class498.Delegate250 delegate250_0;

		[CompilerGenerated]
		private Class498.Delegate250 delegate250_1;

		[CompilerGenerated]
		private Class498.Delegate250 delegate250_2;

		[CompilerGenerated]
		private Class498.Delegate250 delegate250_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class517 : TypedTableBase<Class498.Class536>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class517()
		{
			
			
			base.TableName = "dtIsolationLoss";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class517(DataTable dataTable_0)
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
		protected Class517(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class498.Class536 this[int int_0]
		{
			get
			{
				return (Class498.Class536)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate251 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate251 @delegate = this.delegate251_0;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate251 @delegate = this.delegate251_0;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate251 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate251 @delegate = this.delegate251_1;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate251 @delegate = this.delegate251_1;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate251 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate251 @delegate = this.delegate251_2;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate251 @delegate = this.delegate251_2;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class498.Delegate251 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class498.Delegate251 @delegate = this.delegate251_3;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class498.Delegate251 @delegate = this.delegate251_3;
				Class498.Delegate251 delegate2;
				do
				{
					delegate2 = @delegate;
					Class498.Delegate251 value2 = (Class498.Delegate251)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class498.Delegate251>(ref this.delegate251_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class498.Class536 class536_0)
		{
			base.Rows.Add(class536_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class536 method_1(decimal decimal_0, decimal decimal_1, decimal decimal_2, decimal decimal_3, decimal decimal_4, decimal decimal_5, decimal decimal_6, decimal decimal_7, decimal decimal_8, decimal decimal_9, decimal decimal_10, decimal decimal_11)
		{
			Class498.Class536 @class = (Class498.Class536)base.NewRow();
			object[] itemArray = new object[]
			{
				decimal_0,
				decimal_1,
				decimal_2,
				decimal_3,
				decimal_4,
				decimal_5,
				decimal_6,
				decimal_7,
				decimal_8,
				decimal_9,
				decimal_10,
				decimal_11
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class498.Class517 @class = (Class498.Class517)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class498.Class517();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Month1"];
			this.dataColumn_1 = base.Columns["Month2"];
			this.dataColumn_2 = base.Columns["Month3"];
			this.dataColumn_3 = base.Columns["Month4"];
			this.dataColumn_4 = base.Columns["Month5"];
			this.dataColumn_5 = base.Columns["Month6"];
			this.dataColumn_6 = base.Columns["Month7"];
			this.dataColumn_7 = base.Columns["Month8"];
			this.dataColumn_8 = base.Columns["Month9"];
			this.dataColumn_9 = base.Columns["Month10"];
			this.dataColumn_10 = base.Columns["Month11"];
			this.dataColumn_11 = base.Columns["Month12"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Month1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Month2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Month3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Month4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Month5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Month6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Month7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Month8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Month9", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Month10", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("Month11", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("Month12", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class536 method_4()
		{
			return (Class498.Class536)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class498.Class536(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class498.Class536);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate251_1 != null)
			{
				this.delegate251_1(this, new Class498.EventArgs247((Class498.Class536)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate251_0 != null)
			{
				this.delegate251_0(this, new Class498.EventArgs247((Class498.Class536)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate251_3 != null)
			{
				this.delegate251_3(this, new Class498.EventArgs247((Class498.Class536)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate251_2 != null)
			{
				this.delegate251_2(this, new Class498.EventArgs247((Class498.Class536)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class498.Class536 class536_0)
		{
			base.Rows.Remove(class536_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class498 @class = new Class498();
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
			xmlSchemaAttribute2.FixedValue = "dtIsolationLossDataTable";
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
		private Class498.Delegate251 delegate251_0;

		[CompilerGenerated]
		private Class498.Delegate251 delegate251_1;

		[CompilerGenerated]
		private Class498.Delegate251 delegate251_2;

		[CompilerGenerated]
		private Class498.Delegate251 delegate251_3;
	}

	public class Class518 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class518(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class499_0 = (Class498.Class499)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class499_0.idColumn];
			}
			set
			{
				base[this.class499_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idDocType
		{
			get
			{
				return (int)base[this.class499_0.DataColumn_0];
			}
			set
			{
				base[this.class499_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int IdAbn
		{
			get
			{
				return (int)base[this.class499_0.DataColumn_1];
			}
			set
			{
				base[this.class499_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idMarkCable
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class499_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idMarkCable' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Representative
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class499_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Representative' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateIn
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class499_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateIn' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateAct
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class499_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateAct' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_5] = value;
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
					result = (int)base[this.class499_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IdOwner' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_6] = value;
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
					result = (string)base[this.class499_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal LineLength
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LineLength' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal ElectricalResistance
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ElectricalResistance' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal AverageVoltage
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AverageVoltage' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_10] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Consumption
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class499_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Consumption' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Period
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class499_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Period' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoefficientPowerReactive
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoefficientPowerReactive' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal SquareCoefficientFormGraphics
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SquareCoefficientFormGraphics' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_14] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal CoefficientDifferences
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoefficientDifferences' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_15] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal ActiveResistance
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ActiveResistance' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_16] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal LoadPowerLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadPowerLoss' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal LoadAverage
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadAverage' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_18] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal LoadLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadLosses' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_19] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoefficientLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class499_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoefficientLoss' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_20] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class499_0.DataColumn_21];
			}
			set
			{
				base[this.class499_0.DataColumn_21] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CountCepey
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class499_0.DataColumn_22];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CountCepey' in table 'tDocCalc' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class499_0.DataColumn_22] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class499_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class499_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class499_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class499_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class499_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class499_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class499_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class499_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class499_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class499_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class499_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class499_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class499_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class499_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class499_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class499_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class499_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class499_0.DataColumn_10] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class499_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_19()
		{
			base[this.class499_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_20()
		{
			return base.IsNull(this.class499_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class499_0.DataColumn_12] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class499_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class499_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class499_0.DataColumn_14);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_25()
		{
			base[this.class499_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class499_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_27()
		{
			base[this.class499_0.DataColumn_15] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class499_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_29()
		{
			base[this.class499_0.DataColumn_16] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class499_0.DataColumn_17);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_31()
		{
			base[this.class499_0.DataColumn_17] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_32()
		{
			return base.IsNull(this.class499_0.DataColumn_18);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_33()
		{
			base[this.class499_0.DataColumn_18] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_34()
		{
			return base.IsNull(this.class499_0.DataColumn_19);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_35()
		{
			base[this.class499_0.DataColumn_19] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_36()
		{
			return base.IsNull(this.class499_0.DataColumn_20);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_37()
		{
			base[this.class499_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_38()
		{
			return base.IsNull(this.class499_0.DataColumn_22);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_39()
		{
			base[this.class499_0.DataColumn_22] = Convert.DBNull;
		}

		private Class498.Class499 class499_0;
	}

	public class Class519 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class519(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class500_0 = (Class498.Class500)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int IDUser
		{
			get
			{
				return (int)base[this.class500_0.DataColumn_0];
			}
			set
			{
				base[this.class500_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int IdWorker
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class500_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IdWorker' in table 'tUser' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class500_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Login
		{
			get
			{
				return (string)base[this.class500_0.DataColumn_2];
			}
			set
			{
				base[this.class500_0.DataColumn_2] = value;
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
					result = (string)base[this.class500_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'tUser' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class500_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class500_0.DataColumn_4];
			}
			set
			{
				base[this.class500_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class500_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class500_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class500_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class500_0.DataColumn_3] = Convert.DBNull;
		}

		private Class498.Class500 class500_0;
	}

	public class Class520 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class520(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class501_0 = (Class498.Class501)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				return (int)base[this.class501_0.DataColumn_0];
			}
			set
			{
				base[this.class501_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Name
		{
			get
			{
				return (string)base[this.class501_0.DataColumn_1];
			}
			set
			{
				base[this.class501_0.DataColumn_1] = value;
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
					result = (string)base[this.class501_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SocrName' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class501_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Value
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class501_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Value' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class501_0.DataColumn_3] = value;
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
					result = (string)base[this.class501_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class501_0.DataColumn_4] = value;
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
					result = (int)base[this.class501_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentId' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class501_0.DataColumn_5] = value;
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
					result = (string)base[this.class501_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentKey' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class501_0.DataColumn_6] = value;
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
					result = (byte[])base[this.class501_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherId' in table 'tR_Classifier' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class501_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsGroup
		{
			get
			{
				return (bool)base[this.class501_0.DataColumn_8];
			}
			set
			{
				base[this.class501_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class501_0.DataColumn_9];
			}
			set
			{
				base[this.class501_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class501_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class501_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class501_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class501_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class501_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class501_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class501_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class501_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class501_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class501_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class501_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class501_0.DataColumn_7] = Convert.DBNull;
		}

		private Class498.Class501 class501_0;
	}

	public class Class521 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class521(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class502_0 = (Class498.Class502)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class502_0.idColumn];
			}
			set
			{
				base[this.class502_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class502_0.DataColumn_0];
			}
			set
			{
				base[this.class502_0.DataColumn_0] = value;
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
					result = (string)base[this.class502_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'tAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class502_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int TypeAbn
		{
			get
			{
				return (int)base[this.class502_0.DataColumn_2];
			}
			set
			{
				base[this.class502_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idWorker
		{
			get
			{
				return (int)base[this.class502_0.idWorkerColumn];
			}
			set
			{
				base[this.class502_0.idWorkerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class502_0.DataColumn_3];
			}
			set
			{
				base[this.class502_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class502_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class502_0.DataColumn_1] = Convert.DBNull;
		}

		private Class498.Class502 class502_0;
	}

	public class Class522 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class522(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class503_0 = (Class498.Class503)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class503_0.idColumn];
			}
			set
			{
				base[this.class503_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Name
		{
			get
			{
				return (string)base[this.class503_0.DataColumn_0];
			}
			set
			{
				base[this.class503_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class503_0.DataColumn_1];
			}
			set
			{
				base[this.class503_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int ParentID
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class503_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ParentID' in table 'tMaterial' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class503_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class503_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class503_0.DataColumn_2] = Convert.DBNull;
		}

		private Class498.Class503 class503_0;
	}

	public class Class523 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class523(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class504_0 = (Class498.Class504)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idLock
		{
			get
			{
				return (int)base[this.class504_0.DataColumn_0];
			}
			set
			{
				base[this.class504_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string String_0
		{
			get
			{
				return (string)base[this.class504_0.TableColumn];
			}
			set
			{
				base[this.class504_0.TableColumn] = value;
			}
		}

		private Class498.Class504 class504_0;
	}

	public class Class524 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class524(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class505_0 = (Class498.Class505)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class505_0.idColumn];
			}
			set
			{
				base[this.class505_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int num
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class505_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'num' in table 'tJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class505_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int typeCalc
		{
			get
			{
				return (int)base[this.class505_0.DataColumn_1];
			}
			set
			{
				base[this.class505_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string nameCalc
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class505_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameCalc' in table 'tJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class505_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class505_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbn' in table 'tJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class505_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbnObj
		{
			get
			{
				return (int)base[this.class505_0.DataColumn_4];
			}
			set
			{
				base[this.class505_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbnBalance
		{
			get
			{
				return (int)base[this.class505_0.DataColumn_5];
			}
			set
			{
				base[this.class505_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string tpName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class505_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'tpName' in table 'tJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class505_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateCalc
		{
			get
			{
				return (DateTime)base[this.class505_0.DataColumn_7];
			}
			set
			{
				base[this.class505_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idOwner
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class505_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idOwner' in table 'tJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class505_0.DataColumn_8] = value;
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
					result = (string)base[this.class505_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class505_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool isActive
		{
			get
			{
				return (bool)base[this.class505_0.DataColumn_10];
			}
			set
			{
				base[this.class505_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool deleted
		{
			get
			{
				return (bool)base[this.class505_0.DataColumn_11];
			}
			set
			{
				base[this.class505_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class505_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class505_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class505_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class505_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class505_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class505_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class505_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class505_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class505_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class505_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class505_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class505_0.DataColumn_9] = Convert.DBNull;
		}

		private Class498.Class505 class505_0;
	}

	public class Class525 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class525(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class506_0 = (Class498.Class506)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class506_0.idColumn];
			}
			set
			{
				base[this.class506_0.idColumn] = value;
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
					result = (int)base[this.class506_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'num' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idTypeCalc
		{
			get
			{
				return (int)base[this.class506_0.DataColumn_1];
			}
			set
			{
				base[this.class506_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string typeCalc
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class506_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeCalc' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string nameCalc
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class506_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameCalc' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class506_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbn' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string nameAbn
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class506_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameAbn' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idAbnObj
		{
			get
			{
				return (int)base[this.class506_0.DataColumn_6];
			}
			set
			{
				base[this.class506_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string nameObj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class506_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameObj' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbnBalance
		{
			get
			{
				return (int)base[this.class506_0.DataColumn_8];
			}
			set
			{
				base[this.class506_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string nameAbnBalance
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class506_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameAbnBalance' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string tpName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class506_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'tpName' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateCalc
		{
			get
			{
				return (DateTime)base[this.class506_0.DataColumn_11];
			}
			set
			{
				base[this.class506_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idOwner
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class506_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idOwner' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string nameOwner
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class506_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'nameOwner' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_13] = value;
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
					result = (string)base[this.class506_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_14] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool isActive
		{
			get
			{
				return (bool)base[this.class506_0.DataColumn_15];
			}
			set
			{
				base[this.class506_0.DataColumn_15] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool deleted
		{
			get
			{
				return (bool)base[this.class506_0.DataColumn_16];
			}
			set
			{
				base[this.class506_0.DataColumn_16] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoeffLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class506_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffLosses' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CodeAbonent
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class506_0.ArpHkLoHjCu];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CodeAbonent' in table 'vJ_CalcLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class506_0.ArpHkLoHjCu] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class506_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class506_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class506_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class506_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class506_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class506_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class506_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class506_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class506_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class506_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class506_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class506_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class506_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class506_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class506_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class506_0.DataColumn_10] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class506_0.DataColumn_12);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class506_0.DataColumn_12] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class506_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_19()
		{
			base[this.class506_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_20()
		{
			return base.IsNull(this.class506_0.DataColumn_14);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_21()
		{
			base[this.class506_0.DataColumn_14] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_22()
		{
			return base.IsNull(this.class506_0.DataColumn_17);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class506_0.DataColumn_17] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class506_0.ArpHkLoHjCu);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_25()
		{
			base[this.class506_0.ArpHkLoHjCu] = Convert.DBNull;
		}

		private Class498.Class506 class506_0;
	}

	public class Class526 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class526(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class507_0 = (Class498.Class507)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class507_0.idColumn];
			}
			set
			{
				base[this.class507_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbn' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_0] = value;
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
					result = (int)base[this.class507_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idMap' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_1] = value;
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
					result = (string)base[this.class507_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_2] = value;
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
					result = (string)base[this.class507_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idCity
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idCity' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string City
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class507_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'City' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idRaion
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idRaion' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Raion
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class507_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Raion' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_7] = value;
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
					result = (int)base[this.class507_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idStreet' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Street
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class507_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Street' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int House
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'House' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string HousePrefix
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class507_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HousePrefix' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_11] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string HouseAll
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class507_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HouseAll' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsHouse
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class507_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IsHouse' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_13] = value;
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
					result = (string)base[this.class507_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Index' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_14] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public double Latitude
		{
			get
			{
				double result;
				try
				{
					result = (double)base[this.class507_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Latitude' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_15] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public double Longitude
		{
			get
			{
				double result;
				try
				{
					result = (double)base[this.class507_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Longitude' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_16] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idObjParent
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idObjParent' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeObj
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeObj' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_18] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string TypeObjName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class507_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeObjName' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_19] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idObjReg
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idObjReg' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_20] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeObjNew
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class507_0.DataColumn_21];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeObjNew' in table 'vAbnObjAddress' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class507_0.DataColumn_21] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class507_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class507_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class507_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class507_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class507_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class507_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class507_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class507_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class507_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class507_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class507_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class507_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class507_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class507_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class507_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class507_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class507_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class507_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class507_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class507_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class507_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_21()
		{
			base[this.class507_0.DataColumn_10] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_22()
		{
			return base.IsNull(this.class507_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_23()
		{
			base[this.class507_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class507_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class507_0.DataColumn_12] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class507_0.DataColumn_13);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_27()
		{
			base[this.class507_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class507_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_29()
		{
			base[this.class507_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class507_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class507_0.DataColumn_15] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_32()
		{
			return base.IsNull(this.class507_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_33()
		{
			base[this.class507_0.DataColumn_16] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_34()
		{
			return base.IsNull(this.class507_0.DataColumn_17);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_35()
		{
			base[this.class507_0.DataColumn_17] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_36()
		{
			return base.IsNull(this.class507_0.DataColumn_18);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_37()
		{
			base[this.class507_0.DataColumn_18] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_38()
		{
			return base.IsNull(this.class507_0.DataColumn_19);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_39()
		{
			base[this.class507_0.DataColumn_19] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_40()
		{
			return base.IsNull(this.class507_0.DataColumn_20);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_41()
		{
			base[this.class507_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_42()
		{
			return base.IsNull(this.class507_0.DataColumn_21);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_43()
		{
			base[this.class507_0.DataColumn_21] = Convert.DBNull;
		}

		private Class498.Class507 class507_0;
	}

	public class Class527 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class527(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class508_0 = (Class498.Class508)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class508_0.idColumn];
			}
			set
			{
				base[this.class508_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FullName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class508_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FullName' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string CableMakeup
		{
			get
			{
				return (string)base[this.class508_0.DataColumn_1];
			}
			set
			{
				base[this.class508_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Wires
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class508_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Wires' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public float CrossSection
		{
			get
			{
				float result;
				try
				{
					result = (float)base[this.class508_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CrossSection' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public float Amperage
		{
			get
			{
				float result;
				try
				{
					result = (float)base[this.class508_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Amperage' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public float Resistance
		{
			get
			{
				float result;
				try
				{
					result = (float)base[this.class508_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Resistance' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string VoltageTypeName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class508_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VoltageTypeName' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public float VoltageValue
		{
			get
			{
				float result;
				try
				{
					result = (float)base[this.class508_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VoltageValue' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class508_0.DataColumn_8];
			}
			set
			{
				base[this.class508_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int WiresAddl
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class508_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WiresAddl' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public float CrossSectionAddl
		{
			get
			{
				float result;
				try
				{
					result = (float)base[this.class508_0.UqoHexywpga];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CrossSectionAddl' in table 'vR_Cable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class508_0.UqoHexywpga] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class508_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class508_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class508_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class508_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class508_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class508_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class508_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class508_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class508_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class508_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class508_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class508_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class508_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class508_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class508_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class508_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class508_0.UqoHexywpga);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class508_0.UqoHexywpga] = Convert.DBNull;
		}

		private Class498.Class508 class508_0;
	}

	public class Class528 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class528(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class509_0 = (Class498.Class509)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class509_0.idColumn];
			}
			set
			{
				base[this.class509_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idCalc
		{
			get
			{
				return (int)base[this.class509_0.DataColumn_0];
			}
			set
			{
				base[this.class509_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int makeupCable
		{
			get
			{
				return (int)base[this.class509_0.DataColumn_1];
			}
			set
			{
				base[this.class509_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal lenghtCable
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'lenghtCable' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal UdResistance
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UdResistance' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Voltage
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Voltage' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int consumption
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class509_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'consumption' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int period
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class509_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'period' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoeffPowerREactive
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffPowerREactive' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal SquareCoeffFromGraph
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SquareCoeffFromGraph' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoeffDifferences
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffDifferences' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int CountChain
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class509_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CountChain' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal ActiveResistance
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ActiveResistance' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal LoadPowerLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadPowerLoss' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal LoadAverage
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.NfyHbOvdTpT];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadAverage' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.NfyHbOvdTpT] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal LoadLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadLosses' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal UnitYearLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UnitYearLoss' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_14] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal YearLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'YearLoss' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_15] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal SumLoadLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SumLoadLosses' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_16] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoeffLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffLosses' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_17] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool isIsolation
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class509_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'isIsolation' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_18] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoeffIsolation
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffIsolation' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_19] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal IsolationLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class509_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IsolationLosses' in table 'tJ_CalcLossCable' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class509_0.DataColumn_20] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class509_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class509_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class509_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class509_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class509_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class509_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class509_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class509_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class509_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class509_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class509_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class509_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class509_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class509_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class509_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class509_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class509_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class509_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class509_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class509_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_20()
		{
			return base.IsNull(this.class509_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class509_0.DataColumn_12] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class509_0.NfyHbOvdTpT);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class509_0.NfyHbOvdTpT] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class509_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_25()
		{
			base[this.class509_0.DataColumn_13] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class509_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_27()
		{
			base[this.class509_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_28()
		{
			return base.IsNull(this.class509_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_29()
		{
			base[this.class509_0.DataColumn_15] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class509_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_31()
		{
			base[this.class509_0.DataColumn_16] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_32()
		{
			return base.IsNull(this.class509_0.DataColumn_17);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_33()
		{
			base[this.class509_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_34()
		{
			return base.IsNull(this.class509_0.DataColumn_18);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_35()
		{
			base[this.class509_0.DataColumn_18] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_36()
		{
			return base.IsNull(this.class509_0.DataColumn_19);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_37()
		{
			base[this.class509_0.DataColumn_19] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_38()
		{
			return base.IsNull(this.class509_0.DataColumn_20);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_39()
		{
			base[this.class509_0.DataColumn_20] = Convert.DBNull;
		}

		private Class498.Class509 class509_0;
	}

	public class Class529 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class529(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class510_0 = (Class498.Class510)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class510_0.idColumn];
			}
			set
			{
				base[this.class510_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CodeAbonent
		{
			get
			{
				return (int)base[this.class510_0.DataColumn_0];
			}
			set
			{
				base[this.class510_0.DataColumn_0] = value;
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
					result = (string)base[this.class510_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeAbn
		{
			get
			{
				return (int)base[this.class510_0.DataColumn_2];
			}
			set
			{
				base[this.class510_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idWorker
		{
			get
			{
				return (int)base[this.class510_0.idWorkerColumn];
			}
			set
			{
				base[this.class510_0.idWorkerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				return (bool)base[this.class510_0.DataColumn_3];
			}
			set
			{
				base[this.class510_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string TypeName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class510_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeName' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string TypeNameSocr
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class510_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeNameSocr' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Worker
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class510_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Worker' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool isActive
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class510_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'isActive' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Reason
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class510_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Reason' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime datechange
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class510_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'datechange' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_9] = value;
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
					result = (int)base[this.class510_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idReason' in table 'vAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class510_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class510_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class510_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class510_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class510_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class510_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class510_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class510_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class510_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class510_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class510_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class510_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class510_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class510_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class510_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class510_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class510_0.DataColumn_10] = Convert.DBNull;
		}

		private Class498.Class510 class510_0;
	}

	public class Class530 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class530(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class511_0 = (Class498.Class511)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Desription
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class511_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Desription' in table 'dtSource' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class511_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Dimension
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class511_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Dimension' in table 'dtSource' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class511_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Val
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class511_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Val' in table 'dtSource' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class511_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class511_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class511_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class511_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class511_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class511_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class511_0.DataColumn_2] = Convert.DBNull;
		}

		private Class498.Class511 class511_0;
	}

	public class Class531 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class531(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class512_0 = (Class498.Class512)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class512_0.idColumn];
			}
			set
			{
				base[this.class512_0.idColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idCalc
		{
			get
			{
				return (int)base[this.class512_0.DataColumn_0];
			}
			set
			{
				base[this.class512_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FileName
		{
			get
			{
				return (string)base[this.class512_0.DataColumn_1];
			}
			set
			{
				base[this.class512_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public byte[] File
		{
			get
			{
				byte[] result;
				try
				{
					result = (byte[])base[this.class512_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'File' in table 'tJ_CalcLossFile' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class512_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateIn
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class512_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateIn' in table 'tJ_CalcLossFile' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class512_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class512_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class512_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class512_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class512_0.DataColumn_3] = Convert.DBNull;
		}

		private Class498.Class512 class512_0;
	}

	public class Class532 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class532(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class513_0 = (Class498.Class513)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class513_0.idColumn];
			}
			set
			{
				base[this.class513_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idSchmObj
		{
			get
			{
				return (int)base[this.class513_0.idSchmObjColumn];
			}
			set
			{
				base[this.class513_0.idSchmObjColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string SchmObjName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class513_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SchmObjName' in table 'vL_SchmAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class513_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idAbn
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class513_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbn' in table 'vL_SchmAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class513_0.DataColumn_1] = value;
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
					result = (int)base[this.class513_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idAbnObj' in table 'vL_SchmAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class513_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idPoint
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class513_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idPoint' in table 'vL_SchmAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class513_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idDoc
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class513_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idDoc' in table 'vL_SchmAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class513_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int TypeDoc
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class513_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeDoc' in table 'vL_SchmAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class513_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string typeDocName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class513_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'typeDocName' in table 'vL_SchmAbn' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class513_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class513_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class513_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class513_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class513_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class513_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class513_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class513_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class513_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class513_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class513_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class513_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class513_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class513_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class513_0.DataColumn_6] = Convert.DBNull;
		}

		private Class498.Class513 class513_0;
	}

	public class Class533 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class533(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class514_0 = (Class498.Class514)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class514_0.idColumn];
			}
			set
			{
				base[this.class514_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FullName
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class514_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FullName' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Name
		{
			get
			{
				return (string)base[this.class514_0.DataColumn_1];
			}
			set
			{
				base[this.class514_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Type
		{
			get
			{
				return (string)base[this.class514_0.DataColumn_2];
			}
			set
			{
				base[this.class514_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Power
		{
			get
			{
				return (int)base[this.class514_0.DataColumn_3];
			}
			set
			{
				base[this.class514_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal HighVoltage
		{
			get
			{
				return (decimal)base[this.class514_0.DataColumn_4];
			}
			set
			{
				base[this.class514_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal LowVoltage
		{
			get
			{
				return (decimal)base[this.class514_0.DataColumn_5];
			}
			set
			{
				base[this.class514_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal RatedAmperHV
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class514_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RatedAmperHV' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal RatedAmperLV
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class514_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RatedAmperLV' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string GroupWindings
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class514_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GroupWindings' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal ShortCircuitVolt
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class514_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ShortCircuitVolt' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public float ShortCircuitLoss
		{
			get
			{
				float result;
				try
				{
					result = (float)base[this.class514_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ShortCircuitLoss' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public float NoLoadLoss
		{
			get
			{
				float result;
				try
				{
					result = (float)base[this.class514_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NoLoadLoss' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Deleted
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class514_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Deleted' in table 'vR_Transformer' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class514_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class514_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class514_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class514_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class514_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class514_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class514_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class514_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class514_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class514_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class514_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class514_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class514_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class514_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class514_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class514_0.DataColumn_12);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class514_0.DataColumn_12] = Convert.DBNull;
		}

		private Class498.Class514 class514_0;
	}

	public class Class534 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class534(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class515_0 = (Class498.Class515)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class515_0.idColumn];
			}
			set
			{
				base[this.class515_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idCalc
		{
			get
			{
				return (int)base[this.class515_0.DataColumn_0];
			}
			set
			{
				base[this.class515_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int numTrans
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class515_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'numTrans' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int makeupTrans
		{
			get
			{
				return (int)base[this.class515_0.DataColumn_2];
			}
			set
			{
				base[this.class515_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal RatedPower
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RatedPower' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal NoLoadLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NoLoadLoss' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal ShortCircuitLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ShortCircuitLoss' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Consumption
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class515_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Consumption' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal RatedVoltage
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RatedVoltage' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Period
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class515_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Period' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal MiddleVoltage
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MiddleVoltage' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoeffPowerReactive
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffPowerReactive' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal SquareCoeffFromGraph
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SquareCoeffFromGraph' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_11] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal CoeffDifference
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffDifference' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal LossElectrHH
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LossElectrHH' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal ActiveResistance
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ActiveResistance' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_14] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal LoadPowerLoss
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadPowerLoss' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_15] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal LoadAverage
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadAverage' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_16] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal LoadLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoadLosses' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_17] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal CoeffLosses
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class515_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CoeffLosses' in table 'tJ_CalcLossTrans' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class515_0.DataColumn_18] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class515_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class515_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class515_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class515_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class515_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class515_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class515_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class515_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class515_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class515_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class515_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class515_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class515_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class515_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class515_0.DataColumn_9);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class515_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class515_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class515_0.DataColumn_10] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class515_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class515_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_20()
		{
			return base.IsNull(this.class515_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class515_0.DataColumn_12] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_22()
		{
			return base.IsNull(this.class515_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class515_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class515_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class515_0.DataColumn_14] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_26()
		{
			return base.IsNull(this.class515_0.DataColumn_15);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_27()
		{
			base[this.class515_0.DataColumn_15] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_28()
		{
			return base.IsNull(this.class515_0.DataColumn_16);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_29()
		{
			base[this.class515_0.DataColumn_16] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_30()
		{
			return base.IsNull(this.class515_0.DataColumn_17);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class515_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_32()
		{
			return base.IsNull(this.class515_0.DataColumn_18);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_33()
		{
			base[this.class515_0.DataColumn_18] = Convert.DBNull;
		}

		private Class498.Class515 class515_0;
	}

	public class Class535 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class535(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class516_0 = (Class498.Class516)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class516_0.idColumn];
			}
			set
			{
				base[this.class516_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int idCalc
		{
			get
			{
				return (int)base[this.class516_0.DataColumn_0];
			}
			set
			{
				base[this.class516_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idTrans
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'idTrans' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int month01
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month01' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int month02
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month02' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int month03
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month03' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int month04
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month04' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int month05
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month05' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int month06
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month06' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int month07
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month07' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int month08
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month08' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int month09
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month09' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int month10
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month10' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int month11
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month11' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int month12
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class516_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'month12' in table 'tJ_CalcLossTransHH' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class516_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class516_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class516_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class516_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class516_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class516_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class516_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class516_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class516_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class516_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class516_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class516_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class516_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class516_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class516_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class516_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class516_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class516_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class516_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class516_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class516_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class516_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_21()
		{
			base[this.class516_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_22()
		{
			return base.IsNull(this.class516_0.DataColumn_12);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class516_0.DataColumn_12] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class516_0.DataColumn_13);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class516_0.DataColumn_13] = Convert.DBNull;
		}

		private Class498.Class516 class516_0;
	}

	public class Class536 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class536(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class517_0 = (Class498.Class517)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal Month1
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month1' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal Month2
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month2' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Month3
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month3' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Month4
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month4' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal Month5
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month5' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Month6
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month6' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Month7
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month7' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Month8
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month8' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Month9
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month9' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal Month10
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month10' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal Month11
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month11' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public decimal Month12
		{
			get
			{
				decimal result;
				try
				{
					result = (decimal)base[this.class517_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month12' in table 'dtIsolationLoss' is DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class517_0.DataColumn_11] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class517_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class517_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class517_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class517_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class517_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class517_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class517_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class517_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class517_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class517_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class517_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class517_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class517_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class517_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class517_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class517_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class517_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class517_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class517_0.DataColumn_9);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_19()
		{
			base[this.class517_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_20()
		{
			return base.IsNull(this.class517_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class517_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class517_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class517_0.DataColumn_11] = Convert.DBNull;
		}

		private Class498.Class517 class517_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs229 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs229(Class498.Class518 class518_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class518_0 = class518_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class518 Row
		{
			get
			{
				return this.class518_0;
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

		private Class498.Class518 class518_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs230 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs230(Class498.Class519 class519_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class519_0 = class519_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class519 Row
		{
			get
			{
				return this.class519_0;
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

		private Class498.Class519 class519_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs231 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs231(Class498.Class520 class520_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class520_0 = class520_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class520 Row
		{
			get
			{
				return this.class520_0;
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

		private Class498.Class520 class520_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs232 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs232(Class498.Class521 class521_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class521_0 = class521_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class521 Row
		{
			get
			{
				return this.class521_0;
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

		private Class498.Class521 class521_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs233 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs233(Class498.Class522 class522_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class522_0 = class522_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class522 Row
		{
			get
			{
				return this.class522_0;
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

		private Class498.Class522 class522_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs234 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs234(Class498.Class523 class523_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class523_0 = class523_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class523 Row
		{
			get
			{
				return this.class523_0;
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

		private Class498.Class523 class523_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs235 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs235(Class498.Class524 class524_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class524_0 = class524_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class524 Row
		{
			get
			{
				return this.class524_0;
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

		private Class498.Class524 class524_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs236 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs236(Class498.Class525 class525_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class525_0 = class525_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class525 Row
		{
			get
			{
				return this.class525_0;
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

		private Class498.Class525 class525_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs237 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs237(Class498.Class526 class526_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class526_0 = class526_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class526 Row
		{
			get
			{
				return this.class526_0;
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

		private Class498.Class526 class526_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs238 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs238(Class498.Class527 class527_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class527_0 = class527_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class527 Row
		{
			get
			{
				return this.class527_0;
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

		private Class498.Class527 class527_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs239 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs239(Class498.Class528 class528_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class528_0 = class528_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class528 Row
		{
			get
			{
				return this.class528_0;
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

		private Class498.Class528 class528_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs240 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs240(Class498.Class529 class529_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class529_0 = class529_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class529 Row
		{
			get
			{
				return this.class529_0;
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

		private Class498.Class529 class529_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs241 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs241(Class498.Class530 class530_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class530_0 = class530_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class530 Row
		{
			get
			{
				return this.class530_0;
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

		private Class498.Class530 class530_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs242 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs242(Class498.Class531 class531_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class531_0 = class531_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class531 Row
		{
			get
			{
				return this.class531_0;
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

		private Class498.Class531 class531_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs243 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs243(Class498.Class532 class532_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class532_0 = class532_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class498.Class532 Row
		{
			get
			{
				return this.class532_0;
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

		private Class498.Class532 class532_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs244 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs244(Class498.Class533 class533_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class533_0 = class533_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class533 Row
		{
			get
			{
				return this.class533_0;
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

		private Class498.Class533 class533_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs245 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs245(Class498.Class534 class534_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class534_0 = class534_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class534 Row
		{
			get
			{
				return this.class534_0;
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

		private Class498.Class534 class534_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs246 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs246(Class498.Class535 class535_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class535_0 = class535_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class535 Row
		{
			get
			{
				return this.class535_0;
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

		private Class498.Class535 class535_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs247 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs247(Class498.Class536 class536_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class536_0 = class536_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class498.Class536 Row
		{
			get
			{
				return this.class536_0;
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

		private Class498.Class536 class536_0;

		private DataRowAction dataRowAction_0;
	}
}
