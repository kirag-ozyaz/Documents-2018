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
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("OrgDataSet")]
[Serializable]
internal class Class548 : DataSet
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class548()
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		
		base.BeginInit();
		this.method_2();
		CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_21);
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		base.EndInit();
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected Class548(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
	{
		
		this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
		base..ctor(serializationInfo_0, streamingContext_0, false);
		if (base.IsBinarySerialized(serializationInfo_0, streamingContext_0))
		{
			this.method_1(false);
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_21);
			this.DataTableCollection_0.CollectionChanged += value;
			this.DataRelationCollection_0.CollectionChanged += value;
			return;
		}
		string s = (string)serializationInfo_0.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(serializationInfo_0, streamingContext_0) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["tblAbnAplForDiscon"] != null)
			{
				base.Tables.Add(new Class548.Class549(dataSet.Tables["tblAbnAplForDiscon"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconObjects"] != null)
			{
				base.Tables.Add(new Class548.Class550(dataSet.Tables["tblAbnAplForDisconObjects"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconReason"] != null)
			{
				base.Tables.Add(new Class548.Class551(dataSet.Tables["tblAbnAplForDisconReason"]));
			}
			if (dataSet.Tables["tblAbnObj"] != null)
			{
				base.Tables.Add(new Class548.Class552(dataSet.Tables["tblAbnObj"]));
			}
			if (dataSet.Tables["tblAbn"] != null)
			{
				base.Tables.Add(new Class548.Class553(dataSet.Tables["tblAbn"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconIndividualUsers"] != null)
			{
				base.Tables.Add(new Class548.Class554(dataSet.Tables["tblAbnAplForDisconIndividualUsers"]));
			}
			if (dataSet.Tables["tAbonent"] != null)
			{
				base.Tables.Add(new Class548.Class555(dataSet.Tables["tAbonent"]));
			}
			if (dataSet.Tables["tblAbnObj1"] != null)
			{
				base.Tables.Add(new Class548.Class556(dataSet.Tables["tblAbnObj1"]));
			}
			if (dataSet.Tables["tAbonentNC"] != null)
			{
				base.Tables.Add(new Class548.Class557(dataSet.Tables["tAbonentNC"]));
			}
			if (dataSet.Tables["tblAbnAplConnectPointForIndividualUsers"] != null)
			{
				base.Tables.Add(new Class548.Class558(dataSet.Tables["tblAbnAplConnectPointForIndividualUsers"]));
			}
			if (dataSet.Tables["tblAbnObj2"] != null)
			{
				base.Tables.Add(new Class548.Class559(dataSet.Tables["tblAbnObj2"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconIndividualUsersForCancel"] != null)
			{
				base.Tables.Add(new Class548.Class560(dataSet.Tables["tblAbnAplForDisconIndividualUsersForCancel"]));
			}
			if (dataSet.Tables["NetArea"] != null)
			{
				base.Tables.Add(new Class548.Class561(dataSet.Tables["NetArea"]));
			}
			if (dataSet.Tables["tR_Worker"] != null)
			{
				base.Tables.Add(new Class548.Class562(dataSet.Tables["tR_Worker"]));
			}
			if (dataSet.Tables["Report1DataTable"] != null)
			{
				base.Tables.Add(new Class548.Class563(dataSet.Tables["Report1DataTable"]));
			}
			if (dataSet.Tables["ODSReportDataTable"] != null)
			{
				base.Tables.Add(new Class548.Class564(dataSet.Tables["ODSReportDataTable"]));
			}
			if (dataSet.Tables["ReportODS"] != null)
			{
				base.Tables.Add(new Class548.Class565(dataSet.Tables["ReportODS"]));
			}
			if (dataSet.Tables["CancelReport1DataTable"] != null)
			{
				base.Tables.Add(new Class548.Class566(dataSet.Tables["CancelReport1DataTable"]));
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
		CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_21);
		base.Tables.CollectionChanged += value2;
		this.DataRelationCollection_0.CollectionChanged += value2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class548.Class549 tblAbnAplForDiscon
	{
		get
		{
			return this.class549_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class548.Class550 tblAbnAplForDisconObjects
	{
		get
		{
			return this.class550_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class548.Class551 tblAbnAplForDisconReason
	{
		get
		{
			return this.class551_0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class548.Class552 tblAbnObj
	{
		get
		{
			return this.class552_0;
		}
	}

	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class548.Class553 tblAbn
	{
		get
		{
			return this.class553_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class548.Class554 tblAbnAplForDisconIndividualUsers
	{
		get
		{
			return this.class554_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class548.Class555 tAbonent
	{
		get
		{
			return this.class555_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class548.Class556 tblAbnObj1
	{
		get
		{
			return this.class556_0;
		}
	}

	[DebuggerNonUserCode]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class548.Class557 Class557_0
	{
		get
		{
			return this.class557_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class548.Class558 tblAbnAplConnectPointForIndividualUsers
	{
		get
		{
			return this.class558_0;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public Class548.Class559 tblAbnObj2
	{
		get
		{
			return this.class559_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class548.Class560 tblAbnAplForDisconIndividualUsersForCancel
	{
		get
		{
			return this.class560_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class548.Class561 NetArea
	{
		get
		{
			return this.class561_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public Class548.Class562 tR_Worker
	{
		get
		{
			return this.class562_0;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	public Class548.Class563 Report1DataTable
	{
		get
		{
			return this.class563_0;
		}
	}

	[Browsable(false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Class548.Class564 ODSReportDataTable
	{
		get
		{
			return this.class564_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class548.Class565 Class565_0
	{
		get
		{
			return this.class565_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Class548.Class566 CancelReport1DataTable
	{
		get
		{
			return this.class566_0;
		}
	}

	[Browsable(true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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
		Class548 @class = (Class548)base.Clone();
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override void ReadXmlSerializable(XmlReader reader)
	{
		if (base.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
		{
			this.Reset();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(reader);
			if (dataSet.Tables["tblAbnAplForDiscon"] != null)
			{
				base.Tables.Add(new Class548.Class549(dataSet.Tables["tblAbnAplForDiscon"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconObjects"] != null)
			{
				base.Tables.Add(new Class548.Class550(dataSet.Tables["tblAbnAplForDisconObjects"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconReason"] != null)
			{
				base.Tables.Add(new Class548.Class551(dataSet.Tables["tblAbnAplForDisconReason"]));
			}
			if (dataSet.Tables["tblAbnObj"] != null)
			{
				base.Tables.Add(new Class548.Class552(dataSet.Tables["tblAbnObj"]));
			}
			if (dataSet.Tables["tblAbn"] != null)
			{
				base.Tables.Add(new Class548.Class553(dataSet.Tables["tblAbn"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconIndividualUsers"] != null)
			{
				base.Tables.Add(new Class548.Class554(dataSet.Tables["tblAbnAplForDisconIndividualUsers"]));
			}
			if (dataSet.Tables["tAbonent"] != null)
			{
				base.Tables.Add(new Class548.Class555(dataSet.Tables["tAbonent"]));
			}
			if (dataSet.Tables["tblAbnObj1"] != null)
			{
				base.Tables.Add(new Class548.Class556(dataSet.Tables["tblAbnObj1"]));
			}
			if (dataSet.Tables["tAbonentNC"] != null)
			{
				base.Tables.Add(new Class548.Class557(dataSet.Tables["tAbonentNC"]));
			}
			if (dataSet.Tables["tblAbnAplConnectPointForIndividualUsers"] != null)
			{
				base.Tables.Add(new Class548.Class558(dataSet.Tables["tblAbnAplConnectPointForIndividualUsers"]));
			}
			if (dataSet.Tables["tblAbnObj2"] != null)
			{
				base.Tables.Add(new Class548.Class559(dataSet.Tables["tblAbnObj2"]));
			}
			if (dataSet.Tables["tblAbnAplForDisconIndividualUsersForCancel"] != null)
			{
				base.Tables.Add(new Class548.Class560(dataSet.Tables["tblAbnAplForDisconIndividualUsersForCancel"]));
			}
			if (dataSet.Tables["NetArea"] != null)
			{
				base.Tables.Add(new Class548.Class561(dataSet.Tables["NetArea"]));
			}
			if (dataSet.Tables["tR_Worker"] != null)
			{
				base.Tables.Add(new Class548.Class562(dataSet.Tables["tR_Worker"]));
			}
			if (dataSet.Tables["Report1DataTable"] != null)
			{
				base.Tables.Add(new Class548.Class563(dataSet.Tables["Report1DataTable"]));
			}
			if (dataSet.Tables["ODSReportDataTable"] != null)
			{
				base.Tables.Add(new Class548.Class564(dataSet.Tables["ODSReportDataTable"]));
			}
			if (dataSet.Tables["ReportODS"] != null)
			{
				base.Tables.Add(new Class548.Class565(dataSet.Tables["ReportODS"]));
			}
			if (dataSet.Tables["CancelReport1DataTable"] != null)
			{
				base.Tables.Add(new Class548.Class566(dataSet.Tables["CancelReport1DataTable"]));
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal void method_0()
	{
		this.method_1(true);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal void method_1(bool bool_0)
	{
		this.class549_0 = (Class548.Class549)base.Tables["tblAbnAplForDiscon"];
		if (bool_0 && this.class549_0 != null)
		{
			this.class549_0.method_2();
		}
		this.class550_0 = (Class548.Class550)base.Tables["tblAbnAplForDisconObjects"];
		if (bool_0 && this.class550_0 != null)
		{
			this.class550_0.method_2();
		}
		this.class551_0 = (Class548.Class551)base.Tables["tblAbnAplForDisconReason"];
		if (bool_0 && this.class551_0 != null)
		{
			this.class551_0.method_2();
		}
		this.class552_0 = (Class548.Class552)base.Tables["tblAbnObj"];
		if (bool_0 && this.class552_0 != null)
		{
			this.class552_0.method_2();
		}
		this.class553_0 = (Class548.Class553)base.Tables["tblAbn"];
		if (bool_0 && this.class553_0 != null)
		{
			this.class553_0.method_2();
		}
		this.class554_0 = (Class548.Class554)base.Tables["tblAbnAplForDisconIndividualUsers"];
		if (bool_0 && this.class554_0 != null)
		{
			this.class554_0.method_2();
		}
		this.class555_0 = (Class548.Class555)base.Tables["tAbonent"];
		if (bool_0 && this.class555_0 != null)
		{
			this.class555_0.method_2();
		}
		this.class556_0 = (Class548.Class556)base.Tables["tblAbnObj1"];
		if (bool_0 && this.class556_0 != null)
		{
			this.class556_0.method_2();
		}
		this.class557_0 = (Class548.Class557)base.Tables["tAbonentNC"];
		if (bool_0 && this.class557_0 != null)
		{
			this.class557_0.method_2();
		}
		this.class558_0 = (Class548.Class558)base.Tables["tblAbnAplConnectPointForIndividualUsers"];
		if (bool_0 && this.class558_0 != null)
		{
			this.class558_0.method_2();
		}
		this.class559_0 = (Class548.Class559)base.Tables["tblAbnObj2"];
		if (bool_0 && this.class559_0 != null)
		{
			this.class559_0.method_2();
		}
		this.class560_0 = (Class548.Class560)base.Tables["tblAbnAplForDisconIndividualUsersForCancel"];
		if (bool_0 && this.class560_0 != null)
		{
			this.class560_0.method_3();
		}
		this.class561_0 = (Class548.Class561)base.Tables["NetArea"];
		if (bool_0 && this.class561_0 != null)
		{
			this.class561_0.method_3();
		}
		this.class562_0 = (Class548.Class562)base.Tables["tR_Worker"];
		if (bool_0 && this.class562_0 != null)
		{
			this.class562_0.method_3();
		}
		this.class563_0 = (Class548.Class563)base.Tables["Report1DataTable"];
		if (bool_0 && this.class563_0 != null)
		{
			this.class563_0.method_2();
		}
		this.class564_0 = (Class548.Class564)base.Tables["ODSReportDataTable"];
		if (bool_0 && this.class564_0 != null)
		{
			this.class564_0.method_2();
		}
		this.class565_0 = (Class548.Class565)base.Tables["ReportODS"];
		if (bool_0 && this.class565_0 != null)
		{
			this.class565_0.method_2();
		}
		this.class566_0 = (Class548.Class566)base.Tables["CancelReport1DataTable"];
		if (bool_0 && this.class566_0 != null)
		{
			this.class566_0.method_1();
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_2()
	{
		base.DataSetName = "OrgDataSet";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/OrgDataSet.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class549_0 = new Class548.Class549();
		base.Tables.Add(this.class549_0);
		this.class550_0 = new Class548.Class550();
		base.Tables.Add(this.class550_0);
		this.class551_0 = new Class548.Class551();
		base.Tables.Add(this.class551_0);
		this.class552_0 = new Class548.Class552();
		base.Tables.Add(this.class552_0);
		this.class553_0 = new Class548.Class553();
		base.Tables.Add(this.class553_0);
		this.class554_0 = new Class548.Class554();
		base.Tables.Add(this.class554_0);
		this.class555_0 = new Class548.Class555();
		base.Tables.Add(this.class555_0);
		this.class556_0 = new Class548.Class556();
		base.Tables.Add(this.class556_0);
		this.class557_0 = new Class548.Class557();
		base.Tables.Add(this.class557_0);
		this.class558_0 = new Class548.Class558();
		base.Tables.Add(this.class558_0);
		this.class559_0 = new Class548.Class559();
		base.Tables.Add(this.class559_0);
		this.class560_0 = new Class548.Class560();
		base.Tables.Add(this.class560_0);
		this.class561_0 = new Class548.Class561();
		base.Tables.Add(this.class561_0);
		this.class562_0 = new Class548.Class562();
		base.Tables.Add(this.class562_0);
		this.class563_0 = new Class548.Class563();
		base.Tables.Add(this.class563_0);
		this.class564_0 = new Class548.Class564();
		base.Tables.Add(this.class564_0);
		this.class565_0 = new Class548.Class565();
		base.Tables.Add(this.class565_0);
		this.class566_0 = new Class548.Class566();
		base.Tables.Add(this.class566_0);
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_14()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool method_20()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_21(object sender, CollectionChangeEventArgs e)
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
		Class548 @class = new Class548();
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

	private Class548.Class549 class549_0;

	private Class548.Class550 class550_0;

	private Class548.Class551 class551_0;

	private Class548.Class552 class552_0;

	private Class548.Class553 class553_0;

	private Class548.Class554 class554_0;

	private Class548.Class555 class555_0;

	private Class548.Class556 class556_0;

	private Class548.Class557 class557_0;

	private Class548.Class558 class558_0;

	private Class548.Class559 class559_0;

	private Class548.Class560 class560_0;

	private Class548.Class561 class561_0;

	private Class548.Class562 class562_0;

	private Class548.Class563 class563_0;

	private Class548.Class564 class564_0;

	private Class548.Class565 class565_0;

	private Class548.Class566 class566_0;

	private SchemaSerializationMode schemaSerializationMode_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate257(object sender, Class548.EventArgs253 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate258(object sender, Class548.EventArgs254 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate259(object sender, Class548.EventArgs255 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate260(object sender, Class548.EventArgs256 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate261(object sender, Class548.EventArgs257 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate262(object sender, Class548.EventArgs258 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate263(object sender, Class548.EventArgs259 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate264(object sender, Class548.EventArgs260 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate265(object sender, Class548.EventArgs261 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate266(object sender, Class548.EventArgs262 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate267(object sender, Class548.EventArgs263 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate268(object sender, Class548.EventArgs264 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate269(object sender, Class548.EventArgs265 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate270(object sender, Class548.EventArgs266 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate271(object sender, Class548.EventArgs267 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate272(object sender, Class548.EventArgs268 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate273(object sender, Class548.EventArgs269 e);

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void Delegate274(object sender, Class548.EventArgs270 e);

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class549 : TypedTableBase<Class548.Class567>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class549()
		{
			
			
			base.TableName = "tblAbnAplForDiscon";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class549(DataTable dataTable_0)
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
		protected Class549(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class567 this[int int_0]
		{
			get
			{
				return (Class548.Class567)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate257 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate257 @delegate = this.delegate257_0;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.delegate257_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate257 @delegate = this.delegate257_0;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.delegate257_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate257 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate257 @delegate = this.delegate257_1;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.delegate257_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate257 @delegate = this.delegate257_1;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.delegate257_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate257 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate257 @delegate = this.WtkWnopRiQW;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.WtkWnopRiQW, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate257 @delegate = this.WtkWnopRiQW;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.WtkWnopRiQW, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate257 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate257 @delegate = this.delegate257_2;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.delegate257_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate257 @delegate = this.delegate257_2;
				Class548.Delegate257 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate257 value2 = (Class548.Delegate257)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate257>(ref this.delegate257_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class567 class567_0)
		{
			base.Rows.Add(class567_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class567 method_1(string string_0, int int_0, int int_1, DateTime dateTime_0, DateTime dateTime_1, string string_1, string string_2, int int_2, bool bool_0, DateTime dateTime_2)
		{
			Class548.Class567 @class = (Class548.Class567)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				int_0,
				int_1,
				dateTime_0,
				dateTime_1,
				string_1,
				string_2,
				int_2,
				bool_0,
				dateTime_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class549 @class = (Class548.Class549)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class549();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["NumDoc"];
			this.dataColumn_1 = base.Columns["NetArea"];
			this.dataColumn_2 = base.Columns["TypeAction"];
			this.dataColumn_3 = base.Columns["DateAppl"];
			this.dataColumn_4 = base.Columns["DateAction"];
			this.dataColumn_5 = base.Columns["NetAreaCaption"];
			this.dataColumn_6 = base.Columns["TypeActionCaption"];
			this.dataColumn_7 = base.Columns["Id"];
			this.dataColumn_8 = base.Columns["LegalAbns"];
			this.dataColumn_9 = base.Columns["Sent"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("NumDoc", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("NetArea", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("TypeAction", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("DateAppl", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("DateAction", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("NetAreaCaption", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("TypeActionCaption", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("LegalAbns", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Sent", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_0.MaxLength = 10;
			this.dataColumn_7.AutoIncrementSeed = -1L;
			this.dataColumn_7.AutoIncrementStep = -1L;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class567 method_4()
		{
			return (Class548.Class567)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class567(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class567);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate257_1 != null)
			{
				this.delegate257_1(this, new Class548.EventArgs253((Class548.Class567)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate257_0 != null)
			{
				this.delegate257_0(this, new Class548.EventArgs253((Class548.Class567)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate257_2 != null)
			{
				this.delegate257_2(this, new Class548.EventArgs253((Class548.Class567)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.WtkWnopRiQW != null)
			{
				this.WtkWnopRiQW(this, new Class548.EventArgs253((Class548.Class567)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class548.Class567 class567_0)
		{
			base.Rows.Remove(class567_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnAplForDisconDataTable";
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
		private Class548.Delegate257 delegate257_0;

		[CompilerGenerated]
		private Class548.Delegate257 delegate257_1;

		[CompilerGenerated]
		private Class548.Delegate257 WtkWnopRiQW;

		[CompilerGenerated]
		private Class548.Delegate257 delegate257_2;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class550 : TypedTableBase<Class548.Class568>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class550()
		{
			
			
			base.TableName = "tblAbnAplForDisconObjects";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class550(DataTable dataTable_0)
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
		protected Class550(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_19
		{
			get
			{
				return this.dataColumn_19;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_22
		{
			get
			{
				return this.dataColumn_22;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_23
		{
			get
			{
				return this.dataColumn_23;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_27
		{
			get
			{
				return this.dataColumn_27;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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
		public Class548.Class568 this[int int_0]
		{
			get
			{
				return (Class548.Class568)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate258 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate258 @delegate = this.delegate258_0;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate258 @delegate = this.delegate258_0;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate258 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate258 @delegate = this.delegate258_1;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate258 @delegate = this.delegate258_1;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate258 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate258 @delegate = this.delegate258_2;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate258 @delegate = this.delegate258_2;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate258 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate258 @delegate = this.delegate258_3;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate258 @delegate = this.delegate258_3;
				Class548.Delegate258 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate258 value2 = (Class548.Delegate258)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate258>(ref this.delegate258_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class568 class568_0)
		{
			base.Rows.Add(class568_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class568 method_1(int int_0, int int_1, int int_2, int int_3, string string_0, int int_4, string string_1, DateTime dateTime_0, int int_5, string string_2, string string_3, int int_6, DateTime dateTime_1, int int_7, string string_4, int int_8, string string_5, string string_6, string string_7, string string_8, string string_9, string string_10, string string_11, bool bool_0, DateTime dateTime_2, int int_9, int int_10, DateTime dateTime_3, DateTime dateTime_4, bool bool_1)
		{
			Class548.Class568 @class = (Class548.Class568)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				int_3,
				string_0,
				int_4,
				string_1,
				dateTime_0,
				int_5,
				string_2,
				string_3,
				int_6,
				dateTime_1,
				int_7,
				string_4,
				int_8,
				string_5,
				string_6,
				string_7,
				string_8,
				string_9,
				string_10,
				string_11,
				bool_0,
				dateTime_2,
				int_9,
				int_10,
				dateTime_3,
				dateTime_4,
				bool_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class550 @class = (Class548.Class550)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class550();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["IdAplForDiscon"];
			this.dataColumn_2 = base.Columns["AbnId"];
			this.dataColumn_3 = base.Columns["AbnObjId"];
			this.dataColumn_4 = base.Columns["PlaceId"];
			this.dataColumn_5 = base.Columns["Reason"];
			this.dataColumn_6 = base.Columns["Comments"];
			this.dataColumn_7 = base.Columns["DateDog"];
			this.dataColumn_8 = base.Columns["Code"];
			this.dataColumn_9 = base.Columns["NameShort"];
			this.dataColumn_10 = base.Columns["AbnObj"];
			this.dataColumn_11 = base.Columns["IdCancelApl"];
			this.dataColumn_12 = base.Columns["DateExec"];
			this.dataColumn_13 = base.Columns["FIOExec"];
			this.dataColumn_14 = base.Columns["ReasonFailure"];
			this.dataColumn_15 = base.Columns["NetAreaExec"];
			this.dataColumn_16 = base.Columns["Officer"];
			this.dataColumn_17 = base.Columns["ReasonCaption"];
			this.dataColumn_18 = base.Columns["CancelAplNumDoc"];
			this.dataColumn_19 = base.Columns["NetAreaExecDescription"];
			this.dataColumn_20 = base.Columns["FIOWorker"];
			this.dataColumn_21 = base.Columns["NoDogAbn"];
			this.dataColumn_22 = base.Columns["NoDogObj"];
			this.dataColumn_23 = base.Columns["Matrix"];
			this.dataColumn_24 = base.Columns["DateAppl"];
			this.dataColumn_25 = base.Columns["TypeAction"];
			this.dataColumn_26 = base.Columns["NetArea"];
			this.dataColumn_27 = base.Columns["DateAction"];
			this.dataColumn_28 = base.Columns["Sent"];
			this.dataColumn_29 = base.Columns["IsFullRestriction"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("IdAplForDiscon", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("AbnId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("AbnObjId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("PlaceId", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Reason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("DateDog", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Code", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("NameShort", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("AbnObj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("IdCancelApl", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("DateExec", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("FIOExec", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("ReasonFailure", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("NetAreaExec", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("Officer", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("ReasonCaption", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("CancelAplNumDoc", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("NetAreaExecDescription", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("FIOWorker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("NoDogAbn", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("NoDogObj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_23 = new DataColumn("Matrix", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_23);
			this.dataColumn_24 = new DataColumn("DateAppl", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_24);
			this.dataColumn_25 = new DataColumn("TypeAction", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_25);
			this.dataColumn_26 = new DataColumn("NetArea", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_26);
			this.dataColumn_27 = new DataColumn("DateAction", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_27);
			this.dataColumn_28 = new DataColumn("Sent", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_28);
			this.dataColumn_29 = new DataColumn("IsFullRestriction", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_29);
			this.dataColumn_6.MaxLength = 255;
			this.dataColumn_9.MaxLength = 255;
			this.dataColumn_10.MaxLength = 255;
			this.dataColumn_14.MaxLength = 500;
			this.dataColumn_16.MaxLength = 100;
			this.dataColumn_17.MaxLength = 100;
			this.dataColumn_18.MaxLength = 10;
			this.dataColumn_19.MaxLength = 100;
			this.dataColumn_20.ReadOnly = true;
			this.dataColumn_20.MaxLength = 70;
			this.dataColumn_29.DefaultValue = true;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class568 method_4()
		{
			return (Class548.Class568)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class568(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class568);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate258_1 != null)
			{
				this.delegate258_1(this, new Class548.EventArgs254((Class548.Class568)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate258_0 != null)
			{
				this.delegate258_0(this, new Class548.EventArgs254((Class548.Class568)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate258_3 != null)
			{
				this.delegate258_3(this, new Class548.EventArgs254((Class548.Class568)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate258_2 != null)
			{
				this.delegate258_2(this, new Class548.EventArgs254((Class548.Class568)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class568 class568_0)
		{
			base.Rows.Remove(class568_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnAplForDisconObjectsDataTable";
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

		[CompilerGenerated]
		private Class548.Delegate258 delegate258_0;

		[CompilerGenerated]
		private Class548.Delegate258 delegate258_1;

		[CompilerGenerated]
		private Class548.Delegate258 delegate258_2;

		[CompilerGenerated]
		private Class548.Delegate258 delegate258_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class551 : TypedTableBase<Class548.Class569>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class551()
		{
			
			
			base.TableName = "tblAbnAplForDisconReason";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class551(DataTable dataTable_0)
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
		protected Class551(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_2
		{
			get
			{
				return this.dataColumn_2;
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
		public Class548.Class569 this[int int_0]
		{
			get
			{
				return (Class548.Class569)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate259 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate259 @delegate = this.delegate259_0;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate259 @delegate = this.delegate259_0;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate259 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate259 @delegate = this.delegate259_1;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate259 @delegate = this.delegate259_1;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate259 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate259 @delegate = this.delegate259_2;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate259 @delegate = this.delegate259_2;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate259 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate259 @delegate = this.delegate259_3;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate259 @delegate = this.delegate259_3;
				Class548.Delegate259 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate259 value2 = (Class548.Delegate259)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate259>(ref this.delegate259_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class569 class569_0)
		{
			base.Rows.Add(class569_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class569 method_1(int int_0, string string_0, int int_1)
		{
			Class548.Class569 @class = (Class548.Class569)base.NewRow();
			object[] itemArray = new object[]
			{
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
		public override DataTable Clone()
		{
			Class548.Class551 @class = (Class548.Class551)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class551();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["Reason"];
			this.dataColumn_2 = base.Columns["IdTypeApl"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Reason", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("IdTypeApl", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_1.MaxLength = 255;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class569 method_4()
		{
			return (Class548.Class569)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class569(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class569);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate259_1 != null)
			{
				this.delegate259_1(this, new Class548.EventArgs255((Class548.Class569)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate259_0 != null)
			{
				this.delegate259_0(this, new Class548.EventArgs255((Class548.Class569)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate259_3 != null)
			{
				this.delegate259_3(this, new Class548.EventArgs255((Class548.Class569)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate259_2 != null)
			{
				this.delegate259_2(this, new Class548.EventArgs255((Class548.Class569)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class569 class569_0)
		{
			base.Rows.Remove(class569_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnAplForDisconReasonDataTable";
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
		private Class548.Delegate259 delegate259_0;

		[CompilerGenerated]
		private Class548.Delegate259 delegate259_1;

		[CompilerGenerated]
		private Class548.Delegate259 delegate259_2;

		[CompilerGenerated]
		private Class548.Delegate259 delegate259_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class552 : TypedTableBase<Class548.Class570>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class552()
		{
			
			
			base.TableName = "tblAbnObj";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class552(DataTable dataTable_0)
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
		protected Class552(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public DataColumn DataColumn_7
		{
			get
			{
				return this.dataColumn_7;
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
		public Class548.Class570 this[int int_0]
		{
			get
			{
				return (Class548.Class570)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate260 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate260 @delegate = this.delegate260_0;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate260 @delegate = this.delegate260_0;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate260 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate260 @delegate = this.delegate260_1;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate260 @delegate = this.delegate260_1;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate260 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate260 @delegate = this.delegate260_2;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate260 @delegate = this.delegate260_2;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate260 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate260 @delegate = this.delegate260_3;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate260 @delegate = this.delegate260_3;
				Class548.Delegate260 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate260 value2 = (Class548.Delegate260)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate260>(ref this.delegate260_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class570 class570_0)
		{
			base.Rows.Add(class570_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class570 method_1(string string_0, int int_0, string string_1, int int_1, bool bool_0, int int_2, string string_2, bool bool_1)
		{
			Class548.Class570 @class = (Class548.Class570)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				int_0,
				string_1,
				int_1,
				bool_0,
				int_2,
				string_2,
				bool_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class552 @class = (Class548.Class552)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class552();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Title"];
			this.dataColumn_1 = base.Columns["ObjId"];
			this.dataColumn_2 = base.Columns["Point"];
			this.dataColumn_3 = base.Columns["AbnID"];
			this.dataColumn_4 = base.Columns["Label"];
			this.dataColumn_5 = base.Columns["Reason"];
			this.dataColumn_6 = base.Columns["Comments"];
			this.dataColumn_7 = base.Columns["IsFullRestriction"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Title", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("ObjId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Point", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("AbnID", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Label", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Reason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("IsFullRestriction", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_0.MaxLength = 255;
			this.dataColumn_1.AutoIncrementSeed = -1L;
			this.dataColumn_1.AutoIncrementStep = -1L;
			this.dataColumn_1.ReadOnly = true;
			this.dataColumn_2.MaxLength = 255;
			this.dataColumn_4.DefaultValue = false;
			this.dataColumn_6.DefaultValue = " ";
			this.dataColumn_6.MaxLength = 255;
			this.dataColumn_7.DefaultValue = true;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class570 method_4()
		{
			return (Class548.Class570)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class570(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class570);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate260_1 != null)
			{
				this.delegate260_1(this, new Class548.EventArgs256((Class548.Class570)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate260_0 != null)
			{
				this.delegate260_0(this, new Class548.EventArgs256((Class548.Class570)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate260_3 != null)
			{
				this.delegate260_3(this, new Class548.EventArgs256((Class548.Class570)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate260_2 != null)
			{
				this.delegate260_2(this, new Class548.EventArgs256((Class548.Class570)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class570 class570_0)
		{
			base.Rows.Remove(class570_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnObjDataTable";
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
		private Class548.Delegate260 delegate260_0;

		[CompilerGenerated]
		private Class548.Delegate260 delegate260_1;

		[CompilerGenerated]
		private Class548.Delegate260 delegate260_2;

		[CompilerGenerated]
		private Class548.Delegate260 delegate260_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class553 : TypedTableBase<Class548.Class571>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class553()
		{
			
			
			base.TableName = "tblAbn";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class553(DataTable dataTable_0)
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
		protected Class553(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class571 this[int int_0]
		{
			get
			{
				return (Class548.Class571)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate261 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate261 @delegate = this.delegate261_0;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate261 @delegate = this.delegate261_0;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate261 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate261 @delegate = this.delegate261_1;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate261 @delegate = this.delegate261_1;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate261 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate261 @delegate = this.delegate261_2;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate261 @delegate = this.delegate261_2;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate261 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate261 @delegate = this.delegate261_3;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate261 @delegate = this.delegate261_3;
				Class548.Delegate261 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate261 value2 = (Class548.Delegate261)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate261>(ref this.delegate261_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class571 class571_0)
		{
			base.Rows.Add(class571_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class571 method_1(string string_0, DateTime dateTime_0, int int_0)
		{
			Class548.Class571 @class = (Class548.Class571)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				string_0,
				dateTime_0,
				int_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class548.Class553 @class = (Class548.Class553)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class553();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["AbnID"];
			this.dataColumn_1 = base.Columns["NameShort"];
			this.dataColumn_2 = base.Columns["DateDog"];
			this.dataColumn_3 = base.Columns["Code"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("AbnID", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("NameShort", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("DateDog", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Code", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_0.AutoIncrement = true;
			this.dataColumn_0.AutoIncrementSeed = -1L;
			this.dataColumn_0.AutoIncrementStep = -1L;
			this.dataColumn_0.ReadOnly = true;
			this.dataColumn_1.MaxLength = 255;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class571 method_4()
		{
			return (Class548.Class571)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class571(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class571);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate261_1 != null)
			{
				this.delegate261_1(this, new Class548.EventArgs257((Class548.Class571)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate261_0 != null)
			{
				this.delegate261_0(this, new Class548.EventArgs257((Class548.Class571)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate261_3 != null)
			{
				this.delegate261_3(this, new Class548.EventArgs257((Class548.Class571)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate261_2 != null)
			{
				this.delegate261_2(this, new Class548.EventArgs257((Class548.Class571)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class548.Class571 class571_0)
		{
			base.Rows.Remove(class571_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnDataTable";
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
		private Class548.Delegate261 delegate261_0;

		[CompilerGenerated]
		private Class548.Delegate261 delegate261_1;

		[CompilerGenerated]
		private Class548.Delegate261 delegate261_2;

		[CompilerGenerated]
		private Class548.Delegate261 delegate261_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class554 : TypedTableBase<Class548.Class572>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class554()
		{
			
			
			base.TableName = "tblAbnAplForDisconIndividualUsers";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class554(DataTable dataTable_0)
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
		protected Class554(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_20
		{
			get
			{
				return this.dataColumn_20;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_23
		{
			get
			{
				return this.dataColumn_23;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_24
		{
			get
			{
				return this.dataColumn_24;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_27
		{
			get
			{
				return this.dataColumn_27;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_28
		{
			get
			{
				return this.dataColumn_28;
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
		public Class548.Class572 this[int int_0]
		{
			get
			{
				return (Class548.Class572)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate262 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate262 @delegate = this.delegate262_0;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate262 @delegate = this.delegate262_0;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate262 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate262 @delegate = this.delegate262_1;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate262 @delegate = this.delegate262_1;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate262 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate262 @delegate = this.delegate262_2;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate262 @delegate = this.delegate262_2;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate262 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate262 @delegate = this.delegate262_3;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate262 @delegate = this.delegate262_3;
				Class548.Delegate262 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate262 value2 = (Class548.Delegate262)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate262>(ref this.delegate262_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class572 class572_0)
		{
			base.Rows.Add(class572_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class572 method_1(int int_0, string string_0, string string_1, int int_1, int int_2, int int_3, string string_2, bool bool_0, int int_4, int int_5, DateTime dateTime_0, int int_6, string string_3, string string_4, DateTime dateTime_1, int int_7, int int_8, string string_5, string string_6, string string_7, string string_8, string string_9, bool bool_1, DateTime dateTime_2, DateTime dateTime_3, int int_9, int int_10, DateTime dateTime_4, bool bool_2)
		{
			Class548.Class572 @class = (Class548.Class572)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				string_1,
				int_1,
				int_2,
				int_3,
				string_2,
				bool_0,
				int_4,
				int_5,
				dateTime_0,
				int_6,
				string_3,
				string_4,
				dateTime_1,
				int_7,
				int_8,
				string_5,
				string_6,
				string_7,
				string_8,
				string_9,
				bool_1,
				dateTime_2,
				dateTime_3,
				int_9,
				int_10,
				dateTime_4,
				bool_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class548.Class554 @class = (Class548.Class554)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class554();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["FIO"];
			this.dataColumn_2 = base.Columns["Address"];
			this.dataColumn_3 = base.Columns["PlaceId"];
			this.dataColumn_4 = base.Columns["Reason"];
			this.dataColumn_5 = base.Columns["IdAplForDiscon"];
			this.dataColumn_6 = base.Columns["Comments"];
			this.dataColumn_7 = base.Columns["IsNC"];
			this.dataColumn_8 = base.Columns["IdAbn"];
			this.dataColumn_9 = base.Columns["Code"];
			this.dataColumn_10 = base.Columns["DateDog"];
			this.dataColumn_11 = base.Columns["IdCancelApl"];
			this.dataColumn_12 = base.Columns["Point"];
			this.dataColumn_13 = base.Columns["Officer"];
			this.dataColumn_14 = base.Columns["DateExec"];
			this.dataColumn_15 = base.Columns["FioExec"];
			this.dataColumn_16 = base.Columns["NetAreaExec"];
			this.dataColumn_17 = base.Columns["ReasonFailure"];
			this.dataColumn_18 = base.Columns["ReasonCaption"];
			this.dataColumn_19 = base.Columns["CancelAplNum"];
			this.dataColumn_20 = base.Columns["NetAreaExecDescription"];
			this.dataColumn_21 = base.Columns["FIOWorker"];
			this.dataColumn_22 = base.Columns["Matrix"];
			this.dataColumn_23 = base.Columns["Sent"];
			this.dataColumn_24 = base.Columns["DateAction"];
			this.dataColumn_25 = base.Columns["TypeAction"];
			this.dataColumn_26 = base.Columns["NetArea"];
			this.dataColumn_27 = base.Columns["DateAppl"];
			this.dataColumn_28 = base.Columns["IsFullRestriction"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("FIO", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("PlaceId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Reason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("IdAplForDiscon", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("IsNC", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("IdAbn", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Code", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("DateDog", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("IdCancelApl", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("Point", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("Officer", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("DateExec", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("FioExec", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("NetAreaExec", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("ReasonFailure", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("ReasonCaption", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("CancelAplNum", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("NetAreaExecDescription", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("FIOWorker", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("Matrix", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_23 = new DataColumn("Sent", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_23);
			this.dataColumn_24 = new DataColumn("DateAction", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_24);
			this.dataColumn_25 = new DataColumn("TypeAction", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_25);
			this.dataColumn_26 = new DataColumn("NetArea", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_26);
			this.dataColumn_27 = new DataColumn("DateAppl", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_27);
			this.dataColumn_28 = new DataColumn("IsFullRestriction", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_28);
			this.dataColumn_0.AutoIncrementSeed = -1L;
			this.dataColumn_0.AutoIncrementStep = -1L;
			this.dataColumn_1.MaxLength = 100;
			this.dataColumn_2.MaxLength = 200;
			this.dataColumn_6.MaxLength = 255;
			this.dataColumn_12.MaxLength = 255;
			this.dataColumn_13.MaxLength = 100;
			this.dataColumn_17.MaxLength = 500;
			this.dataColumn_18.MaxLength = 100;
			this.dataColumn_19.MaxLength = 10;
			this.dataColumn_20.MaxLength = 100;
			this.dataColumn_21.ReadOnly = true;
			this.dataColumn_21.MaxLength = 70;
			this.dataColumn_28.DefaultValue = true;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class572 method_4()
		{
			return (Class548.Class572)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class572(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class572);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate262_1 != null)
			{
				this.delegate262_1(this, new Class548.EventArgs258((Class548.Class572)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate262_0 != null)
			{
				this.delegate262_0(this, new Class548.EventArgs258((Class548.Class572)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate262_3 != null)
			{
				this.delegate262_3(this, new Class548.EventArgs258((Class548.Class572)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate262_2 != null)
			{
				this.delegate262_2(this, new Class548.EventArgs258((Class548.Class572)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class572 class572_0)
		{
			base.Rows.Remove(class572_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnAplForDisconIndividualUsersDataTable";
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
		private Class548.Delegate262 delegate262_0;

		[CompilerGenerated]
		private Class548.Delegate262 delegate262_1;

		[CompilerGenerated]
		private Class548.Delegate262 delegate262_2;

		[CompilerGenerated]
		private Class548.Delegate262 delegate262_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class555 : TypedTableBase<Class548.Class573>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class555()
		{
			
			
			base.TableName = "tAbonent";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class555(DataTable dataTable_0)
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
		protected Class555(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class573 this[int int_0]
		{
			get
			{
				return (Class548.Class573)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate263 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate263 @delegate = this.delegate263_0;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate263 @delegate = this.delegate263_0;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate263 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate263 @delegate = this.delegate263_1;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate263 @delegate = this.delegate263_1;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate263 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate263 @delegate = this.delegate263_2;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate263 @delegate = this.delegate263_2;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate263 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate263 @delegate = this.delegate263_3;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate263 @delegate = this.delegate263_3;
				Class548.Delegate263 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate263 value2 = (Class548.Delegate263)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate263>(ref this.delegate263_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class573 class573_0)
		{
			base.Rows.Add(class573_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class573 method_1(int int_0, DateTime dateTime_0, string string_0, string string_1)
		{
			Class548.Class573 @class = (Class548.Class573)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				dateTime_0,
				string_0,
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
			Class548.Class555 @class = (Class548.Class555)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class555();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["CodeAbonent"];
			this.dataColumn_1 = base.Columns["StartDate"];
			this.dataColumn_2 = base.Columns["FIO"];
			this.dataColumn_3 = base.Columns["Address"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("StartDate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("FIO", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_2.MaxLength = 50;
			this.dataColumn_3.ReadOnly = true;
			this.dataColumn_3.MaxLength = 431;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class573 method_4()
		{
			return (Class548.Class573)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class573(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class573);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate263_1 != null)
			{
				this.delegate263_1(this, new Class548.EventArgs259((Class548.Class573)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate263_0 != null)
			{
				this.delegate263_0(this, new Class548.EventArgs259((Class548.Class573)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate263_3 != null)
			{
				this.delegate263_3(this, new Class548.EventArgs259((Class548.Class573)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate263_2 != null)
			{
				this.delegate263_2(this, new Class548.EventArgs259((Class548.Class573)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class573 class573_0)
		{
			base.Rows.Remove(class573_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tAbonentDataTable";
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
		private Class548.Delegate263 delegate263_0;

		[CompilerGenerated]
		private Class548.Delegate263 delegate263_1;

		[CompilerGenerated]
		private Class548.Delegate263 delegate263_2;

		[CompilerGenerated]
		private Class548.Delegate263 delegate263_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class556 : TypedTableBase<Class548.Class574>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class556()
		{
			
			
			base.TableName = "tblAbnObj1";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class556(DataTable dataTable_0)
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
		protected Class556(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class574 this[int int_0]
		{
			get
			{
				return (Class548.Class574)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate264 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate264 @delegate = this.delegate264_0;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate264 @delegate = this.delegate264_0;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate264 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate264 @delegate = this.delegate264_1;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate264 @delegate = this.delegate264_1;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate264 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate264 @delegate = this.delegate264_2;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate264 @delegate = this.delegate264_2;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate264 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate264 @delegate = this.delegate264_3;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate264 @delegate = this.delegate264_3;
				Class548.Delegate264 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate264 value2 = (Class548.Delegate264)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate264>(ref this.delegate264_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void FsaWdsHejru(Class548.Class574 class574_0)
		{
			base.Rows.Add(class574_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class574 method_0(string string_0, string string_1, bool bool_0, int int_0, int int_1, string string_2)
		{
			Class548.Class574 @class = (Class548.Class574)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				null,
				string_1,
				bool_0,
				int_0,
				int_1,
				string_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class574 method_1(int int_0)
		{
			return (Class548.Class574)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class556 @class = (Class548.Class556)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class556();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Title"];
			this.dataColumn_1 = base.Columns["ObjId"];
			this.dataColumn_2 = base.Columns["Point"];
			this.dataColumn_3 = base.Columns["Label"];
			this.dataColumn_4 = base.Columns["Reason"];
			this.dataColumn_5 = base.Columns["idPoint"];
			this.dataColumn_6 = base.Columns["Comments"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Title", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("ObjId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Point", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Label", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Reason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("idPoint", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_1
			}, true));
			this.dataColumn_0.MaxLength = 255;
			this.dataColumn_1.AutoIncrement = true;
			this.dataColumn_1.AutoIncrementSeed = -1L;
			this.dataColumn_1.AutoIncrementStep = -1L;
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_1.ReadOnly = true;
			this.dataColumn_1.Unique = true;
			this.dataColumn_2.MaxLength = 255;
			this.dataColumn_3.DefaultValue = false;
			this.dataColumn_6.MaxLength = 255;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class574 method_4()
		{
			return (Class548.Class574)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class574(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class574);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate264_1 != null)
			{
				this.delegate264_1(this, new Class548.EventArgs260((Class548.Class574)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate264_0 != null)
			{
				this.delegate264_0(this, new Class548.EventArgs260((Class548.Class574)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate264_3 != null)
			{
				this.delegate264_3(this, new Class548.EventArgs260((Class548.Class574)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate264_2 != null)
			{
				this.delegate264_2(this, new Class548.EventArgs260((Class548.Class574)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class548.Class574 class574_0)
		{
			base.Rows.Remove(class574_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnObj1DataTable";
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
		private Class548.Delegate264 delegate264_0;

		[CompilerGenerated]
		private Class548.Delegate264 delegate264_1;

		[CompilerGenerated]
		private Class548.Delegate264 delegate264_2;

		[CompilerGenerated]
		private Class548.Delegate264 delegate264_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class557 : TypedTableBase<Class548.Class575>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class557()
		{
			
			
			base.TableName = "tAbonentNC";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class557(DataTable dataTable_0)
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
		protected Class557(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class575 this[int int_0]
		{
			get
			{
				return (Class548.Class575)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate265 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate265 @delegate = this.delegate265_0;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate265 @delegate = this.delegate265_0;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate265 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate265 @delegate = this.delegate265_1;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate265 @delegate = this.delegate265_1;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate265 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate265 @delegate = this.delegate265_2;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate265 @delegate = this.delegate265_2;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate265 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate265 @delegate = this.delegate265_3;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate265 @delegate = this.delegate265_3;
				Class548.Delegate265 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate265 value2 = (Class548.Delegate265)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate265>(ref this.delegate265_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class575 class575_0)
		{
			base.Rows.Add(class575_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class575 method_1(int int_0, DateTime dateTime_0, string string_0)
		{
			Class548.Class575 @class = (Class548.Class575)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				dateTime_0,
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
			Class548.Class557 @class = (Class548.Class557)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class557();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["CodeAbonent"];
			this.dataColumn_1 = base.Columns["StartDate"];
			this.dataColumn_2 = base.Columns["FIO"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("StartDate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("FIO", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_2.MaxLength = 50;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class575 method_4()
		{
			return (Class548.Class575)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class575(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class575);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate265_1 != null)
			{
				this.delegate265_1(this, new Class548.EventArgs261((Class548.Class575)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate265_0 != null)
			{
				this.delegate265_0(this, new Class548.EventArgs261((Class548.Class575)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate265_3 != null)
			{
				this.delegate265_3(this, new Class548.EventArgs261((Class548.Class575)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate265_2 != null)
			{
				this.delegate265_2(this, new Class548.EventArgs261((Class548.Class575)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class548.Class575 class575_0)
		{
			base.Rows.Remove(class575_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tAbonentNCDataTable";
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
		private Class548.Delegate265 delegate265_0;

		[CompilerGenerated]
		private Class548.Delegate265 delegate265_1;

		[CompilerGenerated]
		private Class548.Delegate265 delegate265_2;

		[CompilerGenerated]
		private Class548.Delegate265 delegate265_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class558 : TypedTableBase<Class548.Class576>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class558()
		{
			
			
			base.TableName = "tblAbnAplConnectPointForIndividualUsers";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class558(DataTable dataTable_0)
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
		protected Class558(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class576 this[int int_0]
		{
			get
			{
				return (Class548.Class576)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate266 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate266 @delegate = this.delegate266_0;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate266 @delegate = this.delegate266_0;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate266 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate266 @delegate = this.delegate266_1;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate266 @delegate = this.delegate266_1;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate266 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate266 @delegate = this.delegate266_2;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate266 @delegate = this.delegate266_2;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate266 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate266 @delegate = this.delegate266_3;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate266 @delegate = this.delegate266_3;
				Class548.Delegate266 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate266 value2 = (Class548.Delegate266)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate266>(ref this.delegate266_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class548.Class576 class576_0)
		{
			base.Rows.Add(class576_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class576 method_1(int int_0, string string_0)
		{
			Class548.Class576 @class = (Class548.Class576)base.NewRow();
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
		public override DataTable Clone()
		{
			Class548.Class558 @class = (Class548.Class558)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class558();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Id"];
			this.dataColumn_1 = base.Columns["Point"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Point", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_0.AutoIncrementSeed = -1L;
			this.dataColumn_0.AutoIncrementStep = -1L;
			this.dataColumn_1.MaxLength = 255;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class576 method_4()
		{
			return (Class548.Class576)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class576(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class576);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate266_1 != null)
			{
				this.delegate266_1(this, new Class548.EventArgs262((Class548.Class576)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate266_0 != null)
			{
				this.delegate266_0(this, new Class548.EventArgs262((Class548.Class576)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate266_3 != null)
			{
				this.delegate266_3(this, new Class548.EventArgs262((Class548.Class576)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate266_2 != null)
			{
				this.delegate266_2(this, new Class548.EventArgs262((Class548.Class576)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class548.Class576 class576_0)
		{
			base.Rows.Remove(class576_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnAplConnectPointForIndividualUsersDataTable";
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
		private Class548.Delegate266 delegate266_0;

		[CompilerGenerated]
		private Class548.Delegate266 delegate266_1;

		[CompilerGenerated]
		private Class548.Delegate266 delegate266_2;

		[CompilerGenerated]
		private Class548.Delegate266 delegate266_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class559 : TypedTableBase<Class548.Class577>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class559()
		{
			
			
			base.TableName = "tblAbnObj2";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class559(DataTable dataTable_0)
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
		protected Class559(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public DataColumn DataColumn_13
		{
			get
			{
				return this.dataColumn_13;
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
		public Class548.Class577 this[int int_0]
		{
			get
			{
				return (Class548.Class577)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate267 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate267 @delegate = this.delegate267_0;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate267 @delegate = this.delegate267_0;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate267 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate267 @delegate = this.delegate267_1;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate267 @delegate = this.delegate267_1;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate267 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate267 @delegate = this.delegate267_2;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate267 @delegate = this.delegate267_2;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate267 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate267 @delegate = this.delegate267_3;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate267 @delegate = this.delegate267_3;
				Class548.Delegate267 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate267 value2 = (Class548.Delegate267)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate267>(ref this.delegate267_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class548.Class577 class577_0)
		{
			base.Rows.Add(class577_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class577 method_1(int int_0, string string_0, int int_1, DateTime dateTime_0, int int_2, string string_1, int int_3, bool bool_0, int int_4, string string_2, string string_3, string string_4, string string_5, DateTime dateTime_1)
		{
			Class548.Class577 @class = (Class548.Class577)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				string_0,
				int_1,
				dateTime_0,
				int_2,
				string_1,
				int_3,
				bool_0,
				int_4,
				string_2,
				string_3,
				string_4,
				string_5,
				dateTime_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class548.Class559 @class = (Class548.Class559)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class559();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["AbnID"];
			this.dataColumn_1 = base.Columns["Title"];
			this.dataColumn_2 = base.Columns["ObjId"];
			this.dataColumn_3 = base.Columns["DateDog"];
			this.dataColumn_4 = base.Columns["Code"];
			this.dataColumn_5 = base.Columns["NameShort"];
			this.dataColumn_6 = base.Columns["CanceledAplId"];
			this.dataColumn_7 = base.Columns["Label"];
			this.dataColumn_8 = base.Columns["Reason"];
			this.dataColumn_9 = base.Columns["Comments"];
			this.dataColumn_10 = base.Columns["idPoint"];
			this.dataColumn_11 = base.Columns["NoDogAbn"];
			this.dataColumn_12 = base.Columns["NoDogObj"];
			this.dataColumn_13 = base.Columns["DateAction"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("AbnID", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Title", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("ObjId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("DateDog", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Code", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("NameShort", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("CanceledAplId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Label", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Reason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("idPoint", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("NoDogAbn", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("NoDogObj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("DateAction", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_1.MaxLength = 255;
			this.dataColumn_2.AutoIncrementSeed = -1L;
			this.dataColumn_2.AutoIncrementStep = -1L;
			this.dataColumn_2.ReadOnly = true;
			this.dataColumn_5.MaxLength = 255;
			this.dataColumn_6.AutoIncrementSeed = -1L;
			this.dataColumn_6.AutoIncrementStep = -1L;
			this.dataColumn_6.AllowDBNull = false;
			this.dataColumn_6.ReadOnly = true;
			this.dataColumn_7.DefaultValue = false;
			this.dataColumn_9.DefaultValue = " ";
			this.dataColumn_10.MaxLength = int.MaxValue;
			this.dataColumn_11.MaxLength = 100;
			this.dataColumn_12.MaxLength = 255;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class577 method_4()
		{
			return (Class548.Class577)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class577(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class577);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate267_1 != null)
			{
				this.delegate267_1(this, new Class548.EventArgs263((Class548.Class577)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate267_0 != null)
			{
				this.delegate267_0(this, new Class548.EventArgs263((Class548.Class577)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate267_3 != null)
			{
				this.delegate267_3(this, new Class548.EventArgs263((Class548.Class577)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate267_2 != null)
			{
				this.delegate267_2(this, new Class548.EventArgs263((Class548.Class577)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class577 class577_0)
		{
			base.Rows.Remove(class577_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnObj2DataTable";
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
		private Class548.Delegate267 delegate267_0;

		[CompilerGenerated]
		private Class548.Delegate267 delegate267_1;

		[CompilerGenerated]
		private Class548.Delegate267 delegate267_2;

		[CompilerGenerated]
		private Class548.Delegate267 delegate267_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class560 : TypedTableBase<Class548.Class578>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class560()
		{
			
			
			base.TableName = "tblAbnAplForDisconIndividualUsersForCancel";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class560(DataTable dataTable_0)
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
		protected Class560(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_10
		{
			get
			{
				return this.dataColumn_10;
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
		public Class548.Class578 this[int int_0]
		{
			get
			{
				return (Class548.Class578)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate268 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate268 @delegate = this.delegate268_0;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate268 @delegate = this.delegate268_0;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate268 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate268 @delegate = this.delegate268_1;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate268 @delegate = this.delegate268_1;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate268 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate268 @delegate = this.delegate268_2;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate268 @delegate = this.delegate268_2;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate268 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate268 @delegate = this.delegate268_3;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate268 @delegate = this.delegate268_3;
				Class548.Delegate268 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate268 value2 = (Class548.Delegate268)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate268>(ref this.delegate268_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class548.Class578 class578_0)
		{
			base.Rows.Add(class578_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class578 method_1(string string_0, string string_1, int int_0, bool bool_0, int int_1, DateTime dateTime_0, int int_2, bool bool_1, string string_2)
		{
			Class548.Class578 @class = (Class548.Class578)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				string_1,
				int_0,
				bool_0,
				int_1,
				dateTime_0,
				int_2,
				bool_1,
				null,
				null,
				string_2
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class578 method_2(int int_0)
		{
			return (Class548.Class578)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class560 @class = (Class548.Class560)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class560();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["FIO"];
			this.dataColumn_1 = base.Columns["Address"];
			this.dataColumn_2 = base.Columns["PlaceId"];
			this.dataColumn_3 = base.Columns["IsNC"];
			this.dataColumn_4 = base.Columns["Code"];
			this.dataColumn_5 = base.Columns["DateDog"];
			this.dataColumn_6 = base.Columns["Reason"];
			this.dataColumn_7 = base.Columns["Label"];
			this.dataColumn_8 = base.Columns["Id"];
			this.dataColumn_9 = base.Columns["CanceledAplId"];
			this.dataColumn_10 = base.Columns["Place"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("FIO", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("PlaceId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("IsNC", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Code", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("DateDog", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Reason", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("Label", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("CanceledAplId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("Place", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
			{
				this.dataColumn_8
			}, true));
			this.dataColumn_0.MaxLength = 100;
			this.dataColumn_1.MaxLength = 200;
			this.dataColumn_7.DefaultValue = false;
			this.dataColumn_8.AutoIncrement = true;
			this.dataColumn_8.AutoIncrementSeed = -1L;
			this.dataColumn_8.AutoIncrementStep = -1L;
			this.dataColumn_8.AllowDBNull = false;
			this.dataColumn_8.ReadOnly = true;
			this.dataColumn_8.Unique = true;
			this.dataColumn_9.AutoIncrement = true;
			this.dataColumn_9.AutoIncrementSeed = -1L;
			this.dataColumn_9.AutoIncrementStep = -1L;
			this.dataColumn_9.AllowDBNull = false;
			this.dataColumn_9.ReadOnly = true;
			this.dataColumn_10.MaxLength = 255;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class578 method_5()
		{
			return (Class548.Class578)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class578(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class578);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate268_1 != null)
			{
				this.delegate268_1(this, new Class548.EventArgs264((Class548.Class578)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate268_0 != null)
			{
				this.delegate268_0(this, new Class548.EventArgs264((Class548.Class578)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate268_3 != null)
			{
				this.delegate268_3(this, new Class548.EventArgs264((Class548.Class578)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate268_2 != null)
			{
				this.delegate268_2(this, new Class548.EventArgs264((Class548.Class578)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class548.Class578 class578_0)
		{
			base.Rows.Remove(class578_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tblAbnAplForDisconIndividualUsersForCancelDataTable";
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

		[CompilerGenerated]
		private Class548.Delegate268 delegate268_0;

		[CompilerGenerated]
		private Class548.Delegate268 delegate268_1;

		[CompilerGenerated]
		private Class548.Delegate268 delegate268_2;

		[CompilerGenerated]
		private Class548.Delegate268 delegate268_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class561 : TypedTableBase<Class548.Class579>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class561()
		{
			
			
			base.TableName = "NetArea";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class561(DataTable dataTable_0)
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
		protected Class561(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class579 this[int int_0]
		{
			get
			{
				return (Class548.Class579)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate269 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate269 @delegate = this.delegate269_0;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate269 @delegate = this.delegate269_0;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate269 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate269 @delegate = this.delegate269_1;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate269 @delegate = this.delegate269_1;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate269 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate269 @delegate = this.delegate269_2;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate269 @delegate = this.delegate269_2;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate269 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate269 @delegate = this.delegate269_3;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate269 @delegate = this.delegate269_3;
				Class548.Delegate269 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate269 value2 = (Class548.Delegate269)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate269>(ref this.delegate269_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_0(Class548.Class579 class579_0)
		{
			base.Rows.Add(class579_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class579 method_1(string string_0)
		{
			Class548.Class579 @class = (Class548.Class579)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				string_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class579 method_2(int int_0)
		{
			return (Class548.Class579)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class561 @class = (Class548.Class561)base.Clone();
			@class.method_3();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class561();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["Description"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Description", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
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
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class579 method_5()
		{
			return (Class548.Class579)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class579(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class579);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate269_1 != null)
			{
				this.delegate269_1(this, new Class548.EventArgs265((Class548.Class579)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate269_0 != null)
			{
				this.delegate269_0(this, new Class548.EventArgs265((Class548.Class579)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate269_3 != null)
			{
				this.delegate269_3(this, new Class548.EventArgs265((Class548.Class579)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate269_2 != null)
			{
				this.delegate269_2(this, new Class548.EventArgs265((Class548.Class579)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_6(Class548.Class579 class579_0)
		{
			base.Rows.Remove(class579_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "NetAreaDataTable";
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
		private Class548.Delegate269 delegate269_0;

		[CompilerGenerated]
		private Class548.Delegate269 delegate269_1;

		[CompilerGenerated]
		private Class548.Delegate269 delegate269_2;

		[CompilerGenerated]
		private Class548.Delegate269 delegate269_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class562 : TypedTableBase<Class548.Class580>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class562()
		{
			
			
			base.TableName = "tR_Worker";
			this.BeginInit();
			this.method_4();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class562(DataTable dataTable_0)
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
		protected Class562(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class580 this[int int_0]
		{
			get
			{
				return (Class548.Class580)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate270 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate270 @delegate = this.delegate270_0;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate270 @delegate = this.delegate270_0;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate270 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate270 @delegate = this.delegate270_1;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate270 @delegate = this.delegate270_1;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate270 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate270 @delegate = this.delegate270_2;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate270 @delegate = this.delegate270_2;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate270 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate270 @delegate = this.delegate270_3;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate270 @delegate = this.delegate270_3;
				Class548.Delegate270 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate270 value2 = (Class548.Delegate270)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate270>(ref this.delegate270_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class580 class580_0)
		{
			base.Rows.Add(class580_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class580 method_1(string string_0)
		{
			Class548.Class580 @class = (Class548.Class580)base.NewRow();
			object[] itemArray = new object[]
			{
				null,
				string_0
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class580 method_2(int int_0)
		{
			return (Class548.Class580)base.Rows.Find(new object[]
			{
				int_0
			});
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class562 @class = (Class548.Class562)base.Clone();
			@class.method_3();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class562();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_3()
		{
			this.dataColumn_0 = base.Columns["id"];
			this.dataColumn_1 = base.Columns["FIO"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_4()
		{
			this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("FIO", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
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
			this.dataColumn_1.MaxLength = 72;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class580 method_5()
		{
			return (Class548.Class580)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class580(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class580);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate270_1 != null)
			{
				this.delegate270_1(this, new Class548.EventArgs266((Class548.Class580)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate270_0 != null)
			{
				this.delegate270_0(this, new Class548.EventArgs266((Class548.Class580)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate270_3 != null)
			{
				this.delegate270_3(this, new Class548.EventArgs266((Class548.Class580)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate270_2 != null)
			{
				this.delegate270_2(this, new Class548.EventArgs266((Class548.Class580)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_6(Class548.Class580 class580_0)
		{
			base.Rows.Remove(class580_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "tR_WorkerDataTable";
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
		private Class548.Delegate270 delegate270_0;

		[CompilerGenerated]
		private Class548.Delegate270 delegate270_1;

		[CompilerGenerated]
		private Class548.Delegate270 delegate270_2;

		[CompilerGenerated]
		private Class548.Delegate270 delegate270_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class563 : TypedTableBase<Class548.Class581>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class563()
		{
			
			
			base.TableName = "Report1DataTable";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class563(DataTable dataTable_0)
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
		protected Class563(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
				return this.dataColumn_2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn ehiWuuHmesM
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
		public Class548.Class581 this[int int_0]
		{
			get
			{
				return (Class548.Class581)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate271 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate271 @delegate = this.delegate271_0;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate271 @delegate = this.delegate271_0;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate271 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate271 @delegate = this.delegate271_1;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate271 @delegate = this.delegate271_1;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate271 nxqWuwVelsy
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate271 @delegate = this.delegate271_2;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate271 @delegate = this.delegate271_2;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate271 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate271 @delegate = this.delegate271_3;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate271 @delegate = this.delegate271_3;
				Class548.Delegate271 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate271 value2 = (Class548.Delegate271)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate271>(ref this.delegate271_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class581 class581_0)
		{
			base.Rows.Add(class581_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class581 method_1(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7)
		{
			Class548.Class581 @class = (Class548.Class581)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5,
				string_6,
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
			Class548.Class563 @class = (Class548.Class563)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class563();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["NumDateDog"];
			this.dataColumn_1 = base.Columns["Abn"];
			this.dataColumn_2 = base.Columns["Obj"];
			this.dataColumn_3 = base.Columns["Point"];
			this.dataColumn_4 = base.Columns["DateTimeExecution"];
			this.dataColumn_5 = base.Columns["Reason"];
			this.dataColumn_6 = base.Columns["Comments"];
			this.dataColumn_7 = base.Columns["KindRestriction"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("NumDateDog", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Abn", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Obj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Point", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("DateTimeExecution", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("Reason", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("KindRestriction", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class581 method_4()
		{
			return (Class548.Class581)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class581(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class581);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate271_1 != null)
			{
				this.delegate271_1(this, new Class548.EventArgs267((Class548.Class581)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate271_0 != null)
			{
				this.delegate271_0(this, new Class548.EventArgs267((Class548.Class581)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate271_3 != null)
			{
				this.delegate271_3(this, new Class548.EventArgs267((Class548.Class581)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate271_2 != null)
			{
				this.delegate271_2(this, new Class548.EventArgs267((Class548.Class581)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5(Class548.Class581 class581_0)
		{
			base.Rows.Remove(class581_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "Report1DataTableDataTable";
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
		private Class548.Delegate271 delegate271_0;

		[CompilerGenerated]
		private Class548.Delegate271 delegate271_1;

		[CompilerGenerated]
		private Class548.Delegate271 delegate271_2;

		[CompilerGenerated]
		private Class548.Delegate271 delegate271_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class564 : TypedTableBase<Class548.Class582>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class564()
		{
			
			
			base.TableName = "ODSReportDataTable";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class564(DataTable dataTable_0)
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
		protected Class564(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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
		public Class548.Class582 this[int int_0]
		{
			get
			{
				return (Class548.Class582)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate272 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate272 @delegate = this.delegate272_0;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate272 @delegate = this.delegate272_0;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate272 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate272 @delegate = this.delegate272_1;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate272 @delegate = this.delegate272_1;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate272 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate272 @delegate = this.delegate272_2;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate272 @delegate = this.delegate272_2;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate272 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate272 @delegate = this.delegate272_3;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate272 @delegate = this.delegate272_3;
				Class548.Delegate272 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate272 value2 = (Class548.Delegate272)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate272>(ref this.delegate272_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class582 class582_0)
		{
			base.Rows.Add(class582_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class582 method_1(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8, string string_9, string string_10)
		{
			Class548.Class582 @class = (Class548.Class582)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5,
				string_6,
				string_7,
				string_8,
				string_9,
				string_10
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class548.Class564 @class = (Class548.Class564)base.Clone();
			@class.method_2();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class564();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["Place"];
			this.dataColumn_1 = base.Columns["NumAplReasone"];
			this.dataColumn_2 = base.Columns["NumDog"];
			this.dataColumn_3 = base.Columns["Obj"];
			this.dataColumn_4 = base.Columns["Point"];
			this.dataColumn_5 = base.Columns["TypeApl"];
			this.dataColumn_6 = base.Columns["PlanDate"];
			this.dataColumn_7 = base.Columns["FaktDate"];
			this.dataColumn_8 = base.Columns["FIOExec"];
			this.dataColumn_9 = base.Columns["NumCancelApl"];
			this.dataColumn_10 = base.Columns["Comments"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("Place", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("NumAplReasone", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("NumDog", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Obj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Point", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("TypeApl", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("PlanDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("FaktDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("FIOExec", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("NumCancelApl", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class582 method_4()
		{
			return (Class548.Class582)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class582(builder);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class582);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate272_1 != null)
			{
				this.delegate272_1(this, new Class548.EventArgs268((Class548.Class582)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate272_0 != null)
			{
				this.delegate272_0(this, new Class548.EventArgs268((Class548.Class582)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate272_3 != null)
			{
				this.delegate272_3(this, new Class548.EventArgs268((Class548.Class582)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate272_2 != null)
			{
				this.delegate272_2(this, new Class548.EventArgs268((Class548.Class582)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class582 class582_0)
		{
			base.Rows.Remove(class582_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "ODSReportDataTableDataTable";
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

		[CompilerGenerated]
		private Class548.Delegate272 delegate272_0;

		[CompilerGenerated]
		private Class548.Delegate272 delegate272_1;

		[CompilerGenerated]
		private Class548.Delegate272 delegate272_2;

		[CompilerGenerated]
		private Class548.Delegate272 delegate272_3;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class565 : TypedTableBase<Class548.Class583>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class565()
		{
			
			
			base.TableName = "ReportODS";
			this.BeginInit();
			this.method_3();
			this.EndInit();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class565(DataTable dataTable_0)
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
		protected Class565(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DataColumn_20
		{
			get
			{
				return this.dataColumn_20;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_23
		{
			get
			{
				return this.dataColumn_23;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DataColumn DataColumn_24
		{
			get
			{
				return this.dataColumn_24;
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
		public Class548.Class583 this[int int_0]
		{
			get
			{
				return (Class548.Class583)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate273 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate273 @delegate = this.delegate273_0;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.delegate273_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate273 @delegate = this.delegate273_0;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.delegate273_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate273 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate273 @delegate = this.fegWfxBrao9;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.fegWfxBrao9, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate273 @delegate = this.fegWfxBrao9;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.fegWfxBrao9, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate273 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate273 @delegate = this.delegate273_1;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.delegate273_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate273 @delegate = this.delegate273_1;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.delegate273_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate273 yrtWpKywfQf
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate273 @delegate = this.delegate273_2;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.delegate273_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate273 @delegate = this.delegate273_2;
				Class548.Delegate273 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate273 value2 = (Class548.Delegate273)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate273>(ref this.delegate273_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class583 class583_0)
		{
			base.Rows.Add(class583_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class583 method_1(int int_0, int int_1, int int_2, string string_0, string string_1, DateTime dateTime_0, string string_2, string string_3, int int_3, string string_4, DateTime dateTime_1, string string_5, string string_6, string string_7, string string_8, string string_9, string string_10, string string_11, string string_12, string string_13, string string_14, bool bool_0, int int_4, string string_15, bool bool_1)
		{
			Class548.Class583 @class = (Class548.Class583)base.NewRow();
			object[] itemArray = new object[]
			{
				int_0,
				int_1,
				int_2,
				string_0,
				string_1,
				dateTime_0,
				string_2,
				string_3,
				int_3,
				string_4,
				dateTime_1,
				string_5,
				string_6,
				string_7,
				string_8,
				string_9,
				string_10,
				string_11,
				string_12,
				string_13,
				string_14,
				bool_0,
				int_4,
				string_15,
				bool_1
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			Class548.Class565 @class = (Class548.Class565)base.Clone();
			@class.method_2();
			return @class;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class565();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_2()
		{
			this.dataColumn_0 = base.Columns["AbnId"];
			this.dataColumn_1 = base.Columns["AbnObjId"];
			this.dataColumn_2 = base.Columns["PlaceId"];
			this.dataColumn_3 = base.Columns["Comments"];
			this.dataColumn_4 = base.Columns["FIOExec"];
			this.dataColumn_5 = base.Columns["DateExec"];
			this.dataColumn_6 = base.Columns["NetArea"];
			this.dataColumn_7 = base.Columns["NumDoc"];
			this.dataColumn_8 = base.Columns["TypeAction"];
			this.dataColumn_9 = base.Columns["IsFullRestriction"];
			this.dataColumn_10 = base.Columns["DateAction"];
			this.dataColumn_11 = base.Columns["Code"];
			this.dataColumn_12 = base.Columns["Title"];
			this.dataColumn_13 = base.Columns["Address"];
			this.dataColumn_14 = base.Columns["NumCancelApl"];
			this.dataColumn_15 = base.Columns["Point"];
			this.dataColumn_16 = base.Columns["Reason"];
			this.dataColumn_17 = base.Columns["TypeActionCaption"];
			this.dataColumn_18 = base.Columns["Officer"];
			this.dataColumn_19 = base.Columns["ReasonFailure"];
			this.dataColumn_20 = base.Columns["NetAreaExec"];
			this.dataColumn_21 = base.Columns["legal"];
			this.dataColumn_22 = base.Columns["IdCancelApl"];
			this.dataColumn_23 = base.Columns["Sent"];
			this.dataColumn_24 = base.Columns["Matrix"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_3()
		{
			this.dataColumn_0 = new DataColumn("AbnId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("AbnObjId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("PlaceId", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("Comments", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("FIOExec", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("DateExec", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
			this.dataColumn_6 = new DataColumn("NetArea", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_6);
			this.dataColumn_7 = new DataColumn("NumDoc", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_7);
			this.dataColumn_8 = new DataColumn("TypeAction", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_8);
			this.dataColumn_9 = new DataColumn("IsFullRestriction", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_9);
			this.dataColumn_10 = new DataColumn("DateAction", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_10);
			this.dataColumn_11 = new DataColumn("Code", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_11);
			this.dataColumn_12 = new DataColumn("Title", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_12);
			this.dataColumn_13 = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_13);
			this.dataColumn_14 = new DataColumn("NumCancelApl", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_14);
			this.dataColumn_15 = new DataColumn("Point", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_15);
			this.dataColumn_16 = new DataColumn("Reason", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_16);
			this.dataColumn_17 = new DataColumn("TypeActionCaption", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_17);
			this.dataColumn_18 = new DataColumn("Officer", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_18);
			this.dataColumn_19 = new DataColumn("ReasonFailure", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_19);
			this.dataColumn_20 = new DataColumn("NetAreaExec", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_20);
			this.dataColumn_21 = new DataColumn("legal", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_21);
			this.dataColumn_22 = new DataColumn("IdCancelApl", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_22);
			this.dataColumn_23 = new DataColumn("Sent", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_23);
			this.dataColumn_24 = new DataColumn("Matrix", typeof(bool), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_24);
			this.dataColumn_3.MaxLength = 255;
			this.dataColumn_4.MaxLength = 100;
			this.dataColumn_6.DefaultValue = "";
			this.dataColumn_12.MaxLength = 255;
			this.dataColumn_13.MaxLength = 255;
			this.dataColumn_14.MaxLength = 10;
			this.dataColumn_15.MaxLength = 256;
			this.dataColumn_16.MaxLength = 100;
			this.dataColumn_21.DefaultValue = true;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class583 method_4()
		{
			return (Class548.Class583)base.NewRow();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class583(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class583);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.fegWfxBrao9 != null)
			{
				this.fegWfxBrao9(this, new Class548.EventArgs269((Class548.Class583)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate273_0 != null)
			{
				this.delegate273_0(this, new Class548.EventArgs269((Class548.Class583)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate273_2 != null)
			{
				this.delegate273_2(this, new Class548.EventArgs269((Class548.Class583)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate273_1 != null)
			{
				this.delegate273_1(this, new Class548.EventArgs269((Class548.Class583)e.Row, e.Action));
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5(Class548.Class583 class583_0)
		{
			base.Rows.Remove(class583_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "ReportODSDataTable";
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

		[CompilerGenerated]
		private Class548.Delegate273 delegate273_0;

		[CompilerGenerated]
		private Class548.Delegate273 fegWfxBrao9;

		[CompilerGenerated]
		private Class548.Delegate273 delegate273_1;

		[CompilerGenerated]
		private Class548.Delegate273 delegate273_2;
	}

	[XmlSchemaProvider("GetTypedTableSchema")]
	[Serializable]
	public class Class566 : TypedTableBase<Class548.Class584>
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class566()
		{
			
			
			base.TableName = "CancelReport1DataTable";
			this.BeginInit();
			this.method_2();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class566(DataTable dataTable_0)
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
		protected Class566(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			
			base..ctor(serializationInfo_0, streamingContext_0);
			this.method_1();
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
		public Class548.Class584 this[int int_0]
		{
			get
			{
				return (Class548.Class584)base.Rows[int_0];
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate274 Event_0
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate274 @delegate = this.delegate274_0;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate274 @delegate = this.delegate274_0;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate274 Event_1
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate274 @delegate = this.delegate274_1;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate274 @delegate = this.delegate274_1;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate274 Event_2
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate274 @delegate = this.delegate274_2;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate274 @delegate = this.delegate274_2;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Class548.Delegate274 Event_3
		{
			[CompilerGenerated]
			add
			{
				Class548.Delegate274 @delegate = this.delegate274_3;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Class548.Delegate274 @delegate = this.delegate274_3;
				Class548.Delegate274 delegate2;
				do
				{
					delegate2 = @delegate;
					Class548.Delegate274 value2 = (Class548.Delegate274)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class548.Delegate274>(ref this.delegate274_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_0(Class548.Class584 class584_0)
		{
			base.Rows.Add(class584_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class584 mdoWftdsuQx(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5)
		{
			Class548.Class584 @class = (Class548.Class584)base.NewRow();
			object[] itemArray = new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5
			};
			@class.ItemArray = itemArray;
			base.Rows.Add(@class);
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Class548.Class566 @class = (Class548.Class566)base.Clone();
			@class.method_1();
			return @class;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Class548.Class566();
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal void method_1()
		{
			this.dataColumn_0 = base.Columns["NumDateDog"];
			this.dataColumn_1 = base.Columns["Abn"];
			this.dataColumn_2 = base.Columns["Obj"];
			this.dataColumn_3 = base.Columns["DateTimeExecution"];
			this.dataColumn_4 = base.Columns["Reason"];
			this.dataColumn_5 = base.Columns["OldAppl"];
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_2()
		{
			this.dataColumn_0 = new DataColumn("NumDateDog", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_0);
			this.dataColumn_1 = new DataColumn("Abn", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_1);
			this.dataColumn_2 = new DataColumn("Obj", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_2);
			this.dataColumn_3 = new DataColumn("DateTimeExecution", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_3);
			this.dataColumn_4 = new DataColumn("Reason", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_4);
			this.dataColumn_5 = new DataColumn("OldAppl", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.dataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class584 method_3()
		{
			return (Class548.Class584)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Class548.Class584(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Class548.Class584);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.delegate274_1 != null)
			{
				this.delegate274_1(this, new Class548.EventArgs270((Class548.Class584)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.delegate274_0 != null)
			{
				this.delegate274_0(this, new Class548.EventArgs270((Class548.Class584)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.delegate274_3 != null)
			{
				this.delegate274_3(this, new Class548.EventArgs270((Class548.Class584)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.delegate274_2 != null)
			{
				this.delegate274_2(this, new Class548.EventArgs270((Class548.Class584)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_4(Class548.Class584 class584_0)
		{
			base.Rows.Remove(class584_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType smethod_0(XmlSchemaSet xmlSchemaSet_0)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Class548 @class = new Class548();
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
			xmlSchemaAttribute2.FixedValue = "CancelReport1DataTableDataTable";
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
		private Class548.Delegate274 delegate274_0;

		[CompilerGenerated]
		private Class548.Delegate274 delegate274_1;

		[CompilerGenerated]
		private Class548.Delegate274 delegate274_2;

		[CompilerGenerated]
		private Class548.Delegate274 delegate274_3;
	}

	public class Class567 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class567(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class549_0 = (Class548.Class549)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NumDoc
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class549_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumDoc' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int NetArea
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class549_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetArea' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeAction
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class549_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'TypeAction' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateAppl
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class549_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAppl' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateAction
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class549_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAction' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NetAreaCaption
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class549_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetAreaCaption' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string TypeActionCaption
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class549_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'TypeActionCaption' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Id
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class549_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Id' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool LegalAbns
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class549_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'LegalAbns' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime Sent
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class549_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Sent' в таблице 'tblAbnAplForDiscon' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class549_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class549_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class549_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class549_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class549_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class549_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class549_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class549_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class549_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class549_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class549_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class549_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class549_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class549_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class549_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class549_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class549_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class549_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class549_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class549_0.DataColumn_9);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_19()
		{
			base[this.class549_0.DataColumn_9] = Convert.DBNull;
		}

		private Class548.Class549 class549_0;
	}

	public class Class568 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class568(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class550_0 = (Class548.Class550)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Id' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int IdAplForDiscon
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IdAplForDiscon' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int AbnId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnId' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int AbnObjId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnObjId' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string PlaceId
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'PlaceId' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Reason
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateDog
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class550_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateDog' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Code
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Code' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NameShort
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NameShort' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string AbnObj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnObj' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int IdCancelApl
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IdCancelApl' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateExec
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class550_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateExec' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_12] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int FIOExec
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIOExec' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string ReasonFailure
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'ReasonFailure' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_14] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int NetAreaExec
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetAreaExec' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_15] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Officer
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Officer' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_16] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ReasonCaption
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'ReasonCaption' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_17] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string CancelAplNumDoc
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'CancelAplNumDoc' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_18] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NetAreaExecDescription
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetAreaExecDescription' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_19] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string String_0
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIOWorker' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_20] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NoDogAbn
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_21];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NoDogAbn' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_21] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NoDogObj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class550_0.DataColumn_22];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NoDogObj' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_22] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Matrix
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class550_0.DataColumn_23];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Matrix' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_23] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateAppl
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class550_0.DataColumn_24];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAppl' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_24] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int TypeAction
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_25];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'TypeAction' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_25] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int NetArea
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class550_0.DataColumn_26];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetArea' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_26] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateAction
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class550_0.DataColumn_27];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAction' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_27] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime Sent
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class550_0.DataColumn_28];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Sent' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_28] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsFullRestriction
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class550_0.DataColumn_29];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IsFullRestriction' в таблице 'tblAbnAplForDisconObjects' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class550_0.DataColumn_29] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class550_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class550_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class550_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class550_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class550_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class550_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class550_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class550_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class550_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class550_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class550_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class550_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class550_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class550_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class550_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class550_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class550_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class550_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class550_0.DataColumn_9);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_19()
		{
			base[this.class550_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class550_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_21()
		{
			base[this.class550_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class550_0.DataColumn_11);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_23()
		{
			base[this.class550_0.DataColumn_11] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_24()
		{
			return base.IsNull(this.class550_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class550_0.DataColumn_12] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_26()
		{
			return base.IsNull(this.class550_0.DataColumn_13);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_27()
		{
			base[this.class550_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class550_0.DataColumn_14);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_29()
		{
			base[this.class550_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class550_0.DataColumn_15);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_31()
		{
			base[this.class550_0.DataColumn_15] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_32()
		{
			return base.IsNull(this.class550_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_33()
		{
			base[this.class550_0.DataColumn_16] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_34()
		{
			return base.IsNull(this.class550_0.DataColumn_17);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_35()
		{
			base[this.class550_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_36()
		{
			return base.IsNull(this.class550_0.DataColumn_18);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_37()
		{
			base[this.class550_0.DataColumn_18] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_38()
		{
			return base.IsNull(this.class550_0.DataColumn_19);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_39()
		{
			base[this.class550_0.DataColumn_19] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_40()
		{
			return base.IsNull(this.class550_0.DataColumn_20);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_41()
		{
			base[this.class550_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_42()
		{
			return base.IsNull(this.class550_0.DataColumn_21);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_43()
		{
			base[this.class550_0.DataColumn_21] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_44()
		{
			return base.IsNull(this.class550_0.DataColumn_22);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_45()
		{
			base[this.class550_0.DataColumn_22] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_46()
		{
			return base.IsNull(this.class550_0.DataColumn_23);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_47()
		{
			base[this.class550_0.DataColumn_23] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_48()
		{
			return base.IsNull(this.class550_0.DataColumn_24);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_49()
		{
			base[this.class550_0.DataColumn_24] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_50()
		{
			return base.IsNull(this.class550_0.DataColumn_25);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_51()
		{
			base[this.class550_0.DataColumn_25] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_52()
		{
			return base.IsNull(this.class550_0.DataColumn_26);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_53()
		{
			base[this.class550_0.DataColumn_26] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_54()
		{
			return base.IsNull(this.class550_0.DataColumn_27);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_55()
		{
			base[this.class550_0.DataColumn_27] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_56()
		{
			return base.IsNull(this.class550_0.DataColumn_28);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_57()
		{
			base[this.class550_0.DataColumn_28] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_58()
		{
			return base.IsNull(this.class550_0.DataColumn_29);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_59()
		{
			base[this.class550_0.DataColumn_29] = Convert.DBNull;
		}

		private Class548.Class550 class550_0;
	}

	public class Class569 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class569(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class551_0 = (Class548.Class551)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class551_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Id' в таблице 'tblAbnAplForDisconReason' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class551_0.DataColumn_0] = value;
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
					result = (string)base[this.class551_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'tblAbnAplForDisconReason' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class551_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int IdTypeApl
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class551_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IdTypeApl' в таблице 'tblAbnAplForDisconReason' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class551_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class551_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class551_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class551_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class551_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class551_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class551_0.DataColumn_2] = Convert.DBNull;
		}

		private Class548.Class551 class551_0;
	}

	public class Class570 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class570(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class552_0 = (Class548.Class552)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Title
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class552_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Title' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int ObjId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class552_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'ObjId' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Point
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class552_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Point' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int AbnID
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class552_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnID' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Label
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class552_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Label' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Reason
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class552_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class552_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsFullRestriction
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class552_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IsFullRestriction' в таблице 'tblAbnObj' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class552_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class552_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class552_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class552_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class552_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class552_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class552_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class552_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class552_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class552_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class552_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class552_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class552_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class552_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class552_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class552_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class552_0.DataColumn_7] = Convert.DBNull;
		}

		private Class548.Class552 class552_0;
	}

	public class Class571 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class571(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class553_0 = (Class548.Class553)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int AbnID
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class553_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnID' в таблице 'tblAbn' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class553_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NameShort
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class553_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NameShort' в таблице 'tblAbn' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class553_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateDog
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class553_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateDog' в таблице 'tblAbn' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class553_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Code
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class553_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Code' в таблице 'tblAbn' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class553_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class553_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class553_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class553_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class553_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class553_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class553_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class553_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class553_0.DataColumn_3] = Convert.DBNull;
		}

		private Class548.Class553 class553_0;
	}

	public class Class572 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class572(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class554_0 = (Class548.Class554)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Id' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FIO
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIO' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Address
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Address' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int PlaceId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'PlaceId' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Reason
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int IdAplForDiscon
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IdAplForDiscon' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool IsNC
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class554_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IsNC' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int IdAbn
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IdAbn' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Code
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Code' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateDog
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class554_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateDog' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_10] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int IdCancelApl
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IdCancelApl' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Point
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Point' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Officer
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Officer' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_13] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateExec
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class554_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateExec' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_14] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int FioExec
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FioExec' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_15] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int NetAreaExec
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetAreaExec' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_16] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ReasonFailure
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'ReasonFailure' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string ReasonCaption
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'ReasonCaption' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_18] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string CancelAplNum
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'CancelAplNum' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_19] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NetAreaExecDescription
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class554_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetAreaExecDescription' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_20] = value;
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
					result = (string)base[this.class554_0.DataColumn_21];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIOWorker' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_21] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Matrix
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class554_0.DataColumn_22];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Matrix' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_22] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime Sent
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class554_0.DataColumn_23];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Sent' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_23] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateAction
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class554_0.DataColumn_24];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAction' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_24] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int TypeAction
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_25];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'TypeAction' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_25] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int NetArea
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class554_0.DataColumn_26];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetArea' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_26] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateAppl
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class554_0.DataColumn_27];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAppl' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_27] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsFullRestriction
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class554_0.DataColumn_28];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IsFullRestriction' в таблице 'tblAbnAplForDisconIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class554_0.DataColumn_28] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class554_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class554_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class554_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class554_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class554_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class554_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class554_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class554_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class554_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class554_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class554_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class554_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class554_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class554_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class554_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class554_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class554_0.DataColumn_8);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class554_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class554_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class554_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class554_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class554_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class554_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_23()
		{
			base[this.class554_0.DataColumn_11] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_24()
		{
			return base.IsNull(this.class554_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_25()
		{
			base[this.class554_0.DataColumn_12] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_26()
		{
			return base.IsNull(this.class554_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_27()
		{
			base[this.class554_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_28()
		{
			return base.IsNull(this.class554_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_29()
		{
			base[this.class554_0.DataColumn_14] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_30()
		{
			return base.IsNull(this.class554_0.DataColumn_15);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void XbjWtsSwil5()
		{
			base[this.class554_0.DataColumn_15] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_31()
		{
			return base.IsNull(this.class554_0.DataColumn_16);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_32()
		{
			base[this.class554_0.DataColumn_16] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_33()
		{
			return base.IsNull(this.class554_0.DataColumn_17);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_34()
		{
			base[this.class554_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_35()
		{
			return base.IsNull(this.class554_0.DataColumn_18);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_36()
		{
			base[this.class554_0.DataColumn_18] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_37()
		{
			return base.IsNull(this.class554_0.DataColumn_19);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_38()
		{
			base[this.class554_0.DataColumn_19] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_39()
		{
			return base.IsNull(this.class554_0.DataColumn_20);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_40()
		{
			base[this.class554_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_41()
		{
			return base.IsNull(this.class554_0.DataColumn_21);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_42()
		{
			base[this.class554_0.DataColumn_21] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_43()
		{
			return base.IsNull(this.class554_0.DataColumn_22);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void jypWtvmXlm9()
		{
			base[this.class554_0.DataColumn_22] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_44()
		{
			return base.IsNull(this.class554_0.DataColumn_23);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_45()
		{
			base[this.class554_0.DataColumn_23] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_46()
		{
			return base.IsNull(this.class554_0.DataColumn_24);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_47()
		{
			base[this.class554_0.DataColumn_24] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_48()
		{
			return base.IsNull(this.class554_0.DataColumn_25);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_49()
		{
			base[this.class554_0.DataColumn_25] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_50()
		{
			return base.IsNull(this.class554_0.DataColumn_26);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_51()
		{
			base[this.class554_0.DataColumn_26] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_52()
		{
			return base.IsNull(this.class554_0.DataColumn_27);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_53()
		{
			base[this.class554_0.DataColumn_27] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_54()
		{
			return base.IsNull(this.class554_0.DataColumn_28);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_55()
		{
			base[this.class554_0.DataColumn_28] = Convert.DBNull;
		}

		private Class548.Class554 class554_0;
	}

	public class Class573 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class573(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class555_0 = (Class548.Class555)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int CodeAbonent
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class555_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'CodeAbonent' в таблице 'tAbonent' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class555_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime StartDate
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class555_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'StartDate' в таблице 'tAbonent' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class555_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FIO
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class555_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIO' в таблице 'tAbonent' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class555_0.DataColumn_2] = value;
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
					result = (string)base[this.class555_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Address' в таблице 'tAbonent' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class555_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class555_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class555_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class555_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class555_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class555_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class555_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class555_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class555_0.DataColumn_3] = Convert.DBNull;
		}

		private Class548.Class555 class555_0;
	}

	public class Class574 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class574(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class556_0 = (Class548.Class556)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Title
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class556_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Title' в таблице 'tblAbnObj1' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class556_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int ObjId
		{
			get
			{
				return (int)base[this.class556_0.DataColumn_1];
			}
			set
			{
				base[this.class556_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Point
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class556_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Point' в таблице 'tblAbnObj1' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class556_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Label
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class556_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Label' в таблице 'tblAbnObj1' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class556_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Reason
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class556_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'tblAbnObj1' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class556_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int idPoint
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class556_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'idPoint' в таблице 'tblAbnObj1' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class556_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class556_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'tblAbnObj1' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class556_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class556_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class556_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class556_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class556_0.DataColumn_2] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class556_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class556_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_6()
		{
			return base.IsNull(this.class556_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class556_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class556_0.DataColumn_5);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class556_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class556_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class556_0.DataColumn_6] = Convert.DBNull;
		}

		private Class548.Class556 class556_0;
	}

	public class Class575 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class575(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class557_0 = (Class548.Class557)base.Table;
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
					result = (int)base[this.class557_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'CodeAbonent' в таблице 'tAbonentNC' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class557_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime StartDate
		{
			get
			{
				return (DateTime)base[this.class557_0.DataColumn_1];
			}
			set
			{
				base[this.class557_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FIO
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class557_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIO' в таблице 'tAbonentNC' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class557_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class557_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class557_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class557_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void efmWvJkphuv()
		{
			base[this.class557_0.DataColumn_2] = Convert.DBNull;
		}

		private Class548.Class557 class557_0;
	}

	public class Class576 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class576(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class558_0 = (Class548.Class558)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class558_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Id' в таблице 'tblAbnAplConnectPointForIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class558_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Point
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class558_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Point' в таблице 'tblAbnAplConnectPointForIndividualUsers' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class558_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class558_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class558_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class558_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class558_0.DataColumn_1] = Convert.DBNull;
		}

		private Class548.Class558 class558_0;
	}

	public class Class577 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class577(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class559_0 = (Class548.Class559)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int AbnID
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class559_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnID' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Title
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class559_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Title' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int ObjId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class559_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'ObjId' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public DateTime DateDog
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class559_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateDog' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Code
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class559_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Code' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NameShort
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class559_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NameShort' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int CanceledAplId
		{
			get
			{
				return (int)base[this.class559_0.DataColumn_6];
			}
			set
			{
				base[this.class559_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Label
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class559_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Label' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Reason
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class559_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class559_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string idPoint
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class559_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'idPoint' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NoDogAbn
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class559_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NoDogAbn' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NoDogObj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class559_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NoDogObj' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_12] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateAction
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class559_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAction' в таблице 'tblAbnObj2' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class559_0.DataColumn_13] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class559_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class559_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class559_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class559_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class559_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class559_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class559_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class559_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class559_0.DataColumn_4);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_9()
		{
			base[this.class559_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class559_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class559_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class559_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class559_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class559_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class559_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class559_0.DataColumn_9);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class559_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class559_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class559_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class559_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class559_0.DataColumn_11] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class559_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_23()
		{
			base[this.class559_0.DataColumn_12] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_24()
		{
			return base.IsNull(this.class559_0.DataColumn_13);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_25()
		{
			base[this.class559_0.DataColumn_13] = Convert.DBNull;
		}

		private Class548.Class559 class559_0;
	}

	public class Class578 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class578(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class560_0 = (Class548.Class560)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string FIO
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class560_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIO' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Address
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class560_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Address' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int PlaceId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class560_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'PlaceId' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsNC
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class560_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IsNC' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Code
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class560_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Code' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateDog
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class560_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateDog' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Reason
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class560_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_6] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Label
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class560_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Label' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Id
		{
			get
			{
				return (int)base[this.class560_0.DataColumn_8];
			}
			set
			{
				base[this.class560_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int CanceledAplId
		{
			get
			{
				return (int)base[this.class560_0.DataColumn_9];
			}
			set
			{
				base[this.class560_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Place
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class560_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Place' в таблице 'tblAbnAplForDisconIndividualUsersForCancel' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class560_0.DataColumn_10] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class560_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class560_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class560_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class560_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class560_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class560_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class560_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class560_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class560_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class560_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class560_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class560_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class560_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class560_0.DataColumn_6] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_14()
		{
			return base.IsNull(this.class560_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class560_0.DataColumn_7] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_16()
		{
			return base.IsNull(this.class560_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_17()
		{
			base[this.class560_0.DataColumn_10] = Convert.DBNull;
		}

		private Class548.Class560 class560_0;
	}

	public class Class579 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class579(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class561_0 = (Class548.Class561)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int id
		{
			get
			{
				return (int)base[this.class561_0.idColumn];
			}
			set
			{
				base[this.class561_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Description
		{
			get
			{
				return (string)base[this.class561_0.DataColumn_0];
			}
			set
			{
				base[this.class561_0.DataColumn_0] = value;
			}
		}

		private Class548.Class561 class561_0;
	}

	public class Class580 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class580(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class562_0 = (Class548.Class562)base.Table;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int id
		{
			get
			{
				return (int)base[this.class562_0.idColumn];
			}
			set
			{
				base[this.class562_0.idColumn] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FIO
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class562_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIO' в таблице 'tR_Worker' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class562_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class562_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class562_0.DataColumn_0] = Convert.DBNull;
		}

		private Class548.Class562 class562_0;
	}

	public class Class581 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class581(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class563_0 = (Class548.Class563)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NumDateDog
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumDateDog' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Abn
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Abn' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Obj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Obj' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Point
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.ehiWuuHmesM];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Point' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.ehiWuuHmesM] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string DateTimeExecution
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateTimeExecution' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Reason
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string KindRestriction
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class563_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'KindRestriction' в таблице 'Report1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class563_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class563_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class563_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class563_0.DataColumn_1);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_3()
		{
			base[this.class563_0.DataColumn_1] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_4()
		{
			return base.IsNull(this.class563_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class563_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class563_0.ehiWuuHmesM);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class563_0.ehiWuuHmesM] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class563_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class563_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class563_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_11()
		{
			base[this.class563_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class563_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_13()
		{
			base[this.class563_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class563_0.DataColumn_6);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class563_0.DataColumn_6] = Convert.DBNull;
		}

		private Class548.Class563 class563_0;
	}

	public class Class582 : DataRow
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Class582(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class564_0 = (Class548.Class564)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Place
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Place' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_0] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NumAplReasone
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumAplReasone' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NumDog
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumDog' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Obj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Obj' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Point
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Point' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string TypeApl
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'TypeApl' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string PlanDate
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'PlanDate' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FaktDate
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FaktDate' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_7] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string FIOExec
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIOExec' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_8] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NumCancelApl
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumCancelApl' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_9] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class564_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'ODSReportDataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class564_0.DataColumn_10] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_0()
		{
			return base.IsNull(this.class564_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class564_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class564_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class564_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class564_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class564_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class564_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class564_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class564_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class564_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class564_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class564_0.DataColumn_5] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_12()
		{
			return base.IsNull(this.class564_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class564_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class564_0.DataColumn_7);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_15()
		{
			base[this.class564_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class564_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class564_0.DataColumn_8] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_18()
		{
			return base.IsNull(this.class564_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void YosWasOypgj()
		{
			base[this.class564_0.DataColumn_9] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_19()
		{
			return base.IsNull(this.class564_0.DataColumn_10);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_20()
		{
			base[this.class564_0.DataColumn_10] = Convert.DBNull;
		}

		private Class548.Class564 class564_0;
	}

	public class Class583 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class583(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class565_0 = (Class548.Class565)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int AbnId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class565_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnId' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int AbnObjId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class565_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'AbnObjId' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_1] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int PlaceId
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class565_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'PlaceId' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_2] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Comments
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Comments' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_3] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string FIOExec
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'FIOExec' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_4] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateExec
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class565_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateExec' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_5] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NetArea
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_6];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetArea' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_6] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string NumDoc
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_7];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumDoc' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_7] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int TypeAction
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class565_0.DataColumn_8];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'TypeAction' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_8] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string IsFullRestriction
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_9];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IsFullRestriction' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_9] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime DateAction
		{
			get
			{
				DateTime result;
				try
				{
					result = (DateTime)base[this.class565_0.DataColumn_10];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateAction' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_10] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Code
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_11];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Code' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_11] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Title
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_12];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Title' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_12] = value;
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
					result = (string)base[this.class565_0.DataColumn_13];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Address' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_13] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NumCancelApl
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_14];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumCancelApl' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_14] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Point
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_15];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Point' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_15] = value;
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
					result = (string)base[this.class565_0.DataColumn_16];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_16] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string TypeActionCaption
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_17];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'TypeActionCaption' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_17] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Officer
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_18];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Officer' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_18] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ReasonFailure
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_19];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'ReasonFailure' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_19] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NetAreaExec
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_20];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NetAreaExec' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_20] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool legal
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class565_0.DataColumn_21];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'legal' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_21] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int IdCancelApl
		{
			get
			{
				int result;
				try
				{
					result = (int)base[this.class565_0.DataColumn_22];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'IdCancelApl' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_22] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Sent
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class565_0.DataColumn_23];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Sent' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_23] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool Matrix
		{
			get
			{
				bool result;
				try
				{
					result = (bool)base[this.class565_0.DataColumn_24];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Matrix' в таблице 'ReportODS' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class565_0.DataColumn_24] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class565_0.DataColumn_0);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_1()
		{
			base[this.class565_0.DataColumn_0] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_2()
		{
			return base.IsNull(this.class565_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class565_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class565_0.DataColumn_2);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_5()
		{
			base[this.class565_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class565_0.DataColumn_3);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_7()
		{
			base[this.class565_0.DataColumn_3] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_8()
		{
			return base.IsNull(this.class565_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class565_0.DataColumn_4] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_10()
		{
			return base.IsNull(this.class565_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class565_0.DataColumn_5] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_12()
		{
			return base.IsNull(this.class565_0.DataColumn_6);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_13()
		{
			base[this.class565_0.DataColumn_6] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_14()
		{
			return base.IsNull(this.class565_0.DataColumn_7);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_15()
		{
			base[this.class565_0.DataColumn_7] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_16()
		{
			return base.IsNull(this.class565_0.DataColumn_8);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_17()
		{
			base[this.class565_0.DataColumn_8] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_18()
		{
			return base.IsNull(this.class565_0.DataColumn_9);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_19()
		{
			base[this.class565_0.DataColumn_9] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_20()
		{
			return base.IsNull(this.class565_0.DataColumn_10);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_21()
		{
			base[this.class565_0.DataColumn_10] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_22()
		{
			return base.IsNull(this.class565_0.DataColumn_11);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_23()
		{
			base[this.class565_0.DataColumn_11] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_24()
		{
			return base.IsNull(this.class565_0.DataColumn_12);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void GvsWkyLoGwy()
		{
			base[this.class565_0.DataColumn_12] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_25()
		{
			return base.IsNull(this.class565_0.DataColumn_13);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_26()
		{
			base[this.class565_0.DataColumn_13] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_27()
		{
			return base.IsNull(this.class565_0.DataColumn_14);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_28()
		{
			base[this.class565_0.DataColumn_14] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_29()
		{
			return base.IsNull(this.class565_0.DataColumn_15);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_30()
		{
			base[this.class565_0.DataColumn_15] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_31()
		{
			return base.IsNull(this.class565_0.DataColumn_16);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_32()
		{
			base[this.class565_0.DataColumn_16] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_33()
		{
			return base.IsNull(this.class565_0.DataColumn_17);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_34()
		{
			base[this.class565_0.DataColumn_17] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_35()
		{
			return base.IsNull(this.class565_0.DataColumn_18);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_36()
		{
			base[this.class565_0.DataColumn_18] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_37()
		{
			return base.IsNull(this.class565_0.DataColumn_19);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_38()
		{
			base[this.class565_0.DataColumn_19] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_39()
		{
			return base.IsNull(this.class565_0.DataColumn_20);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_40()
		{
			base[this.class565_0.DataColumn_20] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_41()
		{
			return base.IsNull(this.class565_0.DataColumn_21);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_42()
		{
			base[this.class565_0.DataColumn_21] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_43()
		{
			return base.IsNull(this.class565_0.DataColumn_22);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void iEcWkJlnAea()
		{
			base[this.class565_0.DataColumn_22] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_44()
		{
			return base.IsNull(this.class565_0.DataColumn_23);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_45()
		{
			base[this.class565_0.DataColumn_23] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_46()
		{
			return base.IsNull(this.class565_0.DataColumn_24);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_47()
		{
			base[this.class565_0.DataColumn_24] = Convert.DBNull;
		}

		private Class548.Class565 class565_0;
	}

	public class Class584 : DataRow
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class584(DataRowBuilder dataRowBuilder_0)
		{
			
			base..ctor(dataRowBuilder_0);
			this.class566_0 = (Class548.Class566)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string NumDateDog
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class566_0.DataColumn_0];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'NumDateDog' в таблице 'CancelReport1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class566_0.DataColumn_0] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Abn
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class566_0.DataColumn_1];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Abn' в таблице 'CancelReport1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class566_0.DataColumn_1] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Obj
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class566_0.DataColumn_2];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Obj' в таблице 'CancelReport1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class566_0.DataColumn_2] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string DateTimeExecution
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class566_0.DataColumn_3];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'DateTimeExecution' в таблице 'CancelReport1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class566_0.DataColumn_3] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string Reason
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class566_0.DataColumn_4];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'Reason' в таблице 'CancelReport1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class566_0.DataColumn_4] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public string OldAppl
		{
			get
			{
				string result;
				try
				{
					result = (string)base[this.class566_0.DataColumn_5];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("Значение для столбца 'OldAppl' в таблице 'CancelReport1DataTable' равно DBNull.", innerException);
				}
				return result;
			}
			set
			{
				base[this.class566_0.DataColumn_5] = value;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_0()
		{
			return base.IsNull(this.class566_0.DataColumn_0);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_1()
		{
			base[this.class566_0.DataColumn_0] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_2()
		{
			return base.IsNull(this.class566_0.DataColumn_1);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_3()
		{
			base[this.class566_0.DataColumn_1] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_4()
		{
			return base.IsNull(this.class566_0.DataColumn_2);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_5()
		{
			base[this.class566_0.DataColumn_2] = Convert.DBNull;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public bool method_6()
		{
			return base.IsNull(this.class566_0.DataColumn_3);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_7()
		{
			base[this.class566_0.DataColumn_3] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_8()
		{
			return base.IsNull(this.class566_0.DataColumn_4);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void method_9()
		{
			base[this.class566_0.DataColumn_4] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool method_10()
		{
			return base.IsNull(this.class566_0.DataColumn_5);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void method_11()
		{
			base[this.class566_0.DataColumn_5] = Convert.DBNull;
		}

		private Class548.Class566 class566_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs253 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs253(Class548.Class567 class567_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class567_0 = class567_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class567 Row
		{
			get
			{
				return this.class567_0;
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

		private Class548.Class567 class567_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs254 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs254(Class548.Class568 class568_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class568_0 = class568_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class568 Row
		{
			get
			{
				return this.class568_0;
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

		private Class548.Class568 class568_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs255 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs255(Class548.Class569 class569_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class569_0 = class569_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class569 Row
		{
			get
			{
				return this.class569_0;
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

		private Class548.Class569 class569_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs256 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs256(Class548.Class570 class570_1, DataRowAction dataRowAction_0)
		{
			
			
			this.class570_0 = class570_1;
			this.kDyWhlAtYk6 = dataRowAction_0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class570 Row
		{
			get
			{
				return this.class570_0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataRowAction DataRowAction_0
		{
			get
			{
				return this.kDyWhlAtYk6;
			}
		}

		private Class548.Class570 class570_0;

		private DataRowAction kDyWhlAtYk6;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs257 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs257(Class548.Class571 class571_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class571_0 = class571_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class571 Row
		{
			get
			{
				return this.class571_0;
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

		private Class548.Class571 class571_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs258 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs258(Class548.Class572 class572_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class572_0 = class572_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class572 Row
		{
			get
			{
				return this.class572_0;
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

		private Class548.Class572 class572_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs259 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs259(Class548.Class573 class573_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class573_0 = class573_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class573 Row
		{
			get
			{
				return this.class573_0;
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

		private Class548.Class573 class573_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs260 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs260(Class548.Class574 class574_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class574_0 = class574_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class574 Row
		{
			get
			{
				return this.class574_0;
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

		private Class548.Class574 class574_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs261 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs261(Class548.Class575 class575_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class575_0 = class575_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class575 Row
		{
			get
			{
				return this.class575_0;
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

		private Class548.Class575 class575_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs262 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs262(Class548.Class576 class576_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class576_0 = class576_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class576 Row
		{
			get
			{
				return this.class576_0;
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

		private Class548.Class576 class576_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs263 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs263(Class548.Class577 class577_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class577_0 = class577_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class577 Row
		{
			get
			{
				return this.class577_0;
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

		private Class548.Class577 class577_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs264 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs264(Class548.Class578 class578_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class578_0 = class578_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class578 Row
		{
			get
			{
				return this.class578_0;
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

		private Class548.Class578 class578_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs265 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs265(Class548.Class579 class579_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class579_0 = class579_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class579 Row
		{
			get
			{
				return this.class579_0;
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

		private Class548.Class579 class579_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs266 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs266(Class548.Class580 class580_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class580_0 = class580_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class580 Row
		{
			get
			{
				return this.class580_0;
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

		private Class548.Class580 class580_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs267 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs267(Class548.Class581 class581_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class581_0 = class581_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class581 Row
		{
			get
			{
				return this.class581_0;
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

		private Class548.Class581 class581_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs268 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs268(Class548.Class582 class582_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class582_0 = class582_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public Class548.Class582 Row
		{
			get
			{
				return this.class582_0;
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

		private Class548.Class582 class582_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs269 : EventArgs
	{
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public EventArgs269(Class548.Class583 class583_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class583_0 = class583_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class583 Row
		{
			get
			{
				return this.class583_0;
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

		private Class548.Class583 class583_0;

		private DataRowAction dataRowAction_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class EventArgs270 : EventArgs
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public EventArgs270(Class548.Class584 class584_1, DataRowAction dataRowAction_1)
		{
			
			
			this.class584_0 = class584_1;
			this.dataRowAction_0 = dataRowAction_1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Class548.Class584 Row
		{
			get
			{
				return this.class584_0;
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

		private Class548.Class584 class584_0;

		private DataRowAction dataRowAction_0;
	}
}
