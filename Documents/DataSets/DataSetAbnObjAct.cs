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

namespace Documents.DataSets
{
	[XmlRoot("DataSetAbnObjAct")]
	[XmlSchemaProvider("GetTypedDataSetSchema")]
	[ToolboxItem(true)]
	[HelpKeyword("vs.data.DataSet")]
	[DesignerCategory("code")]
	[Serializable]
	public class DataSetAbnObjAct : DataSet
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSetAbnObjAct()
		{
			
			this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
			
			base.BeginInit();
			this.method_2();
			CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_6);
			base.Tables.CollectionChanged += value;
			base.Relations.CollectionChanged += value;
			base.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected DataSetAbnObjAct(SerializationInfo info, StreamingContext context)
		{
			
			this.schemaSerializationMode_0 = SchemaSerializationMode.IncludeSchema;
			base..ctor(info, context, false);
			if (base.IsBinarySerialized(info, context))
			{
				this.method_1(false);
				CollectionChangeEventHandler value = new CollectionChangeEventHandler(this.method_6);
				this.Tables.CollectionChanged += value;
				this.Relations.CollectionChanged += value;
				return;
			}
			string s = (string)info.GetValue("XmlSchema", typeof(string));
			if (base.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
				if (dataSet.Tables["vActBalance"] != null)
				{
					base.Tables.Add(new DataSetAbnObjAct.vActBalanceDataTable(dataSet.Tables["vActBalance"]));
				}
				if (dataSet.Tables["tAbnObjDoc_File"] != null)
				{
					base.Tables.Add(new DataSetAbnObjAct.tAbnObjDoc_FileDataTable(dataSet.Tables["tAbnObjDoc_File"]));
				}
				if (dataSet.Tables["tAbnObjDoc_List"] != null)
				{
					base.Tables.Add(new DataSetAbnObjAct.tAbnObjDoc_ListDataTable(dataSet.Tables["tAbnObjDoc_List"]));
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
			base.GetSerializationData(info, context);
			CollectionChangeEventHandler value2 = new CollectionChangeEventHandler(this.method_6);
			base.Tables.CollectionChanged += value2;
			this.Relations.CollectionChanged += value2;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(false)]
		public DataSetAbnObjAct.vActBalanceDataTable vActBalance
		{
			get
			{
				return this.vActBalanceDataTable_0;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[Browsable(false)]
		public DataSetAbnObjAct.tAbnObjDoc_FileDataTable tAbnObjDoc_File
		{
			get
			{
				return this.tAbnObjDoc_FileDataTable_0;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[Browsable(false)]
		[DebuggerNonUserCode]
		public DataSetAbnObjAct.tAbnObjDoc_ListDataTable tAbnObjDoc_List
		{
			get
			{
				return this.tAbnObjDoc_ListDataTable_0;
			}
		}

		[Browsable(true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		public new DataTableCollection Tables
		{
			get
			{
				return base.Tables;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataRelationCollection Relations
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
			DataSetAbnObjAct dataSetAbnObjAct = (DataSetAbnObjAct)base.Clone();
			dataSetAbnObjAct.method_0();
			dataSetAbnObjAct.SchemaSerializationMode = this.SchemaSerializationMode;
			return dataSetAbnObjAct;
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
				if (dataSet.Tables["vActBalance"] != null)
				{
					base.Tables.Add(new DataSetAbnObjAct.vActBalanceDataTable(dataSet.Tables["vActBalance"]));
				}
				if (dataSet.Tables["tAbnObjDoc_File"] != null)
				{
					base.Tables.Add(new DataSetAbnObjAct.tAbnObjDoc_FileDataTable(dataSet.Tables["tAbnObjDoc_File"]));
				}
				if (dataSet.Tables["tAbnObjDoc_List"] != null)
				{
					base.Tables.Add(new DataSetAbnObjAct.tAbnObjDoc_ListDataTable(dataSet.Tables["tAbnObjDoc_List"]));
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

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void method_1(bool bool_0)
		{
			this.vActBalanceDataTable_0 = (DataSetAbnObjAct.vActBalanceDataTable)base.Tables["vActBalance"];
			if (bool_0 && this.vActBalanceDataTable_0 != null)
			{
				this.vActBalanceDataTable_0.method_0();
			}
			this.tAbnObjDoc_FileDataTable_0 = (DataSetAbnObjAct.tAbnObjDoc_FileDataTable)base.Tables["tAbnObjDoc_File"];
			if (bool_0 && this.tAbnObjDoc_FileDataTable_0 != null)
			{
				this.tAbnObjDoc_FileDataTable_0.method_0();
			}
			this.tAbnObjDoc_ListDataTable_0 = (DataSetAbnObjAct.tAbnObjDoc_ListDataTable)base.Tables["tAbnObjDoc_List"];
			if (bool_0 && this.tAbnObjDoc_ListDataTable_0 != null)
			{
				this.tAbnObjDoc_ListDataTable_0.method_0();
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_2()
		{
			base.DataSetName = "DataSetAbnObjAct";
			base.Prefix = "";
			base.Namespace = "http://tempuri.org/DataSetAbnObjAct.xsd";
			base.EnforceConstraints = true;
			this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.vActBalanceDataTable_0 = new DataSetAbnObjAct.vActBalanceDataTable();
			base.Tables.Add(this.vActBalanceDataTable_0);
			this.tAbnObjDoc_FileDataTable_0 = new DataSetAbnObjAct.tAbnObjDoc_FileDataTable();
			base.Tables.Add(this.tAbnObjDoc_FileDataTable_0);
			this.tAbnObjDoc_ListDataTable_0 = new DataSetAbnObjAct.tAbnObjDoc_ListDataTable();
			base.Tables.Add(this.tAbnObjDoc_ListDataTable_0);
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

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		private void method_6(object sender, CollectionChangeEventArgs e)
		{
			if (e.Action == CollectionChangeAction.Remove)
			{
				this.method_0();
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
		{
			DataSetAbnObjAct dataSetAbnObjAct = new DataSetAbnObjAct();
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = dataSetAbnObjAct.Namespace;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = dataSetAbnObjAct.GetSchemaSerializable();
			if (xs.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					schemaSerializable.Write(memoryStream);
					foreach (object obj in xs.Schemas(schemaSerializable.TargetNamespace))
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
			xs.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}

		private DataSetAbnObjAct.vActBalanceDataTable vActBalanceDataTable_0;

		private DataSetAbnObjAct.tAbnObjDoc_FileDataTable tAbnObjDoc_FileDataTable_0;

		private DataSetAbnObjAct.tAbnObjDoc_ListDataTable tAbnObjDoc_ListDataTable_0;

		private SchemaSerializationMode schemaSerializationMode_0;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void vActBalanceRowChangeEventHandler(object sender, DataSetAbnObjAct.vActBalanceRowChangeEvent e);

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void tAbnObjDoc_FileRowChangeEventHandler(object sender, DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEvent e);

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void tAbnObjDoc_ListRowChangeEventHandler(object sender, DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEvent e);

		[XmlSchemaProvider("GetTypedTableSchema")]
		[Serializable]
		public class vActBalanceDataTable : TypedTableBase<DataSetAbnObjAct.vActBalanceRow>
		{
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public vActBalanceDataTable()
			{
				
				
				base.TableName = "vActBalance";
				this.BeginInit();
				this.method_1();
				this.EndInit();
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			internal vActBalanceDataTable(DataTable table)
			{
				
				
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected vActBalanceDataTable(SerializationInfo info, StreamingContext context)
			{
				
				base..ctor(info, context);
				this.method_0();
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
			public DataColumn TypeDocColumn
			{
				get
				{
					return this.dataColumn_1;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn CodeAbonentColumn
			{
				get
				{
					return this.dataColumn_2;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn NameColumn
			{
				get
				{
					return this.dataColumn_3;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn ObjNameColumn
			{
				get
				{
					return this.dataColumn_4;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn DataColumn
			{
				get
				{
					return this.dataColumn_5;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn idListColumn
			{
				get
				{
					return this.dataColumn_6;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn idAbnColumn
			{
				get
				{
					return this.dataColumn_7;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn idAbnObjColumn
			{
				get
				{
					return this.dataColumn_8;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn StationListColumn
			{
				get
				{
					return this.dataColumn_9;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn ActNumberColumn
			{
				get
				{
					return this.dataColumn_10;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn ActDateColumn
			{
				get
				{
					return this.dataColumn_11;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn ActRegionColumn
			{
				get
				{
					return this.dataColumn_12;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn isActiveColumn
			{
				get
				{
					return this.dataColumn_13;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn deletedColumn
			{
				get
				{
					return this.dataColumn_14;
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
			public DataSetAbnObjAct.vActBalanceRow this[int index]
			{
				get
				{
					return (DataSetAbnObjAct.vActBalanceRow)base.Rows[index];
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChanging
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_0;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Combine(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_0, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_0;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Remove(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_0, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChanged
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_1;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Combine(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_1, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_1;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Remove(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_1, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowDeleting
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_2;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Combine(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_2, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_2;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Remove(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_2, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowDeleted
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_3;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Combine(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_3, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler = this.vActBalanceRowChangeEventHandler_3;
					DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler2;
					do
					{
						vActBalanceRowChangeEventHandler2 = vActBalanceRowChangeEventHandler;
						DataSetAbnObjAct.vActBalanceRowChangeEventHandler value2 = (DataSetAbnObjAct.vActBalanceRowChangeEventHandler)Delegate.Remove(vActBalanceRowChangeEventHandler2, value);
						vActBalanceRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.vActBalanceRowChangeEventHandler>(ref this.vActBalanceRowChangeEventHandler_3, value2, vActBalanceRowChangeEventHandler2);
					}
					while (vActBalanceRowChangeEventHandler != vActBalanceRowChangeEventHandler2);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AddvActBalanceRow(DataSetAbnObjAct.vActBalanceRow row)
			{
				base.Rows.Add(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataSetAbnObjAct.vActBalanceRow AddvActBalanceRow(int id, string TypeDoc, int CodeAbonent, string Name, string ObjName, string Data, int idList, int idAbn, int idAbnObj, string StationList, string ActNumber, DateTime ActDate, string ActRegion, int isActive, int deleted)
			{
				DataSetAbnObjAct.vActBalanceRow vActBalanceRow = (DataSetAbnObjAct.vActBalanceRow)base.NewRow();
				object[] itemArray = new object[]
				{
					id,
					TypeDoc,
					CodeAbonent,
					Name,
					ObjName,
					Data,
					idList,
					idAbn,
					idAbnObj,
					StationList,
					ActNumber,
					ActDate,
					ActRegion,
					isActive,
					deleted
				};
				vActBalanceRow.ItemArray = itemArray;
				base.Rows.Add(vActBalanceRow);
				return vActBalanceRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				DataSetAbnObjAct.vActBalanceDataTable vActBalanceDataTable = (DataSetAbnObjAct.vActBalanceDataTable)base.Clone();
				vActBalanceDataTable.method_0();
				return vActBalanceDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new DataSetAbnObjAct.vActBalanceDataTable();
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			internal void method_0()
			{
				this.dataColumn_0 = base.Columns["id"];
				this.dataColumn_1 = base.Columns["TypeDoc"];
				this.dataColumn_2 = base.Columns["CodeAbonent"];
				this.dataColumn_3 = base.Columns["Name"];
				this.dataColumn_4 = base.Columns["ObjName"];
				this.dataColumn_5 = base.Columns["Data"];
				this.dataColumn_6 = base.Columns["idList"];
				this.dataColumn_7 = base.Columns["idAbn"];
				this.dataColumn_8 = base.Columns["idAbnObj"];
				this.dataColumn_9 = base.Columns["StationList"];
				this.dataColumn_10 = base.Columns["ActNumber"];
				this.dataColumn_11 = base.Columns["ActDate"];
				this.dataColumn_12 = base.Columns["ActRegion"];
				this.dataColumn_13 = base.Columns["isActive"];
				this.dataColumn_14 = base.Columns["deleted"];
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			private void method_1()
			{
				this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_0);
				this.dataColumn_1 = new DataColumn("TypeDoc", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_1);
				this.dataColumn_2 = new DataColumn("CodeAbonent", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_2);
				this.dataColumn_3 = new DataColumn("Name", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_3);
				this.dataColumn_4 = new DataColumn("ObjName", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_4);
				this.dataColumn_5 = new DataColumn("Data", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_5);
				this.dataColumn_6 = new DataColumn("idList", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_6);
				this.dataColumn_7 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_7);
				this.dataColumn_8 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_8);
				this.dataColumn_9 = new DataColumn("StationList", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_9);
				this.dataColumn_10 = new DataColumn("ActNumber", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_10);
				this.dataColumn_11 = new DataColumn("ActDate", typeof(DateTime), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_11);
				this.dataColumn_12 = new DataColumn("ActRegion", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_12);
				this.dataColumn_13 = new DataColumn("isActive", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_13);
				this.dataColumn_14 = new DataColumn("deleted", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_14);
				this.dataColumn_1.AllowDBNull = false;
				this.dataColumn_1.MaxLength = 100;
				this.dataColumn_3.MaxLength = 100;
				this.dataColumn_4.MaxLength = 255;
				this.dataColumn_9.ReadOnly = true;
				this.dataColumn_9.MaxLength = 500;
				this.dataColumn_10.AllowDBNull = false;
				this.dataColumn_10.MaxLength = 20;
				this.dataColumn_11.ReadOnly = true;
				this.dataColumn_12.MaxLength = 100;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataSetAbnObjAct.vActBalanceRow NewvActBalanceRow()
			{
				return (DataSetAbnObjAct.vActBalanceRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new DataSetAbnObjAct.vActBalanceRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(DataSetAbnObjAct.vActBalanceRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.vActBalanceRowChangeEventHandler_1 != null)
				{
					this.vActBalanceRowChangeEventHandler_1(this, new DataSetAbnObjAct.vActBalanceRowChangeEvent((DataSetAbnObjAct.vActBalanceRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.vActBalanceRowChangeEventHandler_0 != null)
				{
					this.vActBalanceRowChangeEventHandler_0(this, new DataSetAbnObjAct.vActBalanceRowChangeEvent((DataSetAbnObjAct.vActBalanceRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.vActBalanceRowChangeEventHandler_3 != null)
				{
					this.vActBalanceRowChangeEventHandler_3(this, new DataSetAbnObjAct.vActBalanceRowChangeEvent((DataSetAbnObjAct.vActBalanceRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.vActBalanceRowChangeEventHandler_2 != null)
				{
					this.vActBalanceRowChangeEventHandler_2(this, new DataSetAbnObjAct.vActBalanceRowChangeEvent((DataSetAbnObjAct.vActBalanceRow)e.Row, e.Action));
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void RemovevActBalanceRow(DataSetAbnObjAct.vActBalanceRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				DataSetAbnObjAct dataSetAbnObjAct = new DataSetAbnObjAct();
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
				xmlSchemaAttribute.FixedValue = dataSetAbnObjAct.Namespace;
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
				xmlSchemaAttribute2.Name = "tableTypeName";
				xmlSchemaAttribute2.FixedValue = "vActBalanceDataTable";
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
				xmlSchemaComplexType.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSetAbnObjAct.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream2 = new MemoryStream();
					try
					{
						schemaSerializable.Write(memoryStream);
						foreach (object obj in xs.Schemas(schemaSerializable.TargetNamespace))
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
				xs.Add(schemaSerializable);
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
			private DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler_0;

			[CompilerGenerated]
			private DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler_1;

			[CompilerGenerated]
			private DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler_2;

			[CompilerGenerated]
			private DataSetAbnObjAct.vActBalanceRowChangeEventHandler vActBalanceRowChangeEventHandler_3;
		}

		[XmlSchemaProvider("GetTypedTableSchema")]
		[Serializable]
		public class tAbnObjDoc_FileDataTable : TypedTableBase<DataSetAbnObjAct.tAbnObjDoc_FileRow>
		{
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public tAbnObjDoc_FileDataTable()
			{
				
				
				base.TableName = "tAbnObjDoc_File";
				this.BeginInit();
				this.method_1();
				this.EndInit();
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			internal tAbnObjDoc_FileDataTable(DataTable table)
			{
				
				
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected tAbnObjDoc_FileDataTable(SerializationInfo info, StreamingContext context)
			{
				
				base..ctor(info, context);
				this.method_0();
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
			public DataColumn idListColumn
			{
				get
				{
					return this.dataColumn_1;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn FileNameColumn
			{
				get
				{
					return this.dataColumn_2;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn FileColumn
			{
				get
				{
					return this.dataColumn_3;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn dateChangeColumn
			{
				get
				{
					return this.dataColumn_4;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn idTemplateColumn
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
			public DataSetAbnObjAct.tAbnObjDoc_FileRow this[int index]
			{
				get
				{
					return (DataSetAbnObjAct.tAbnObjDoc_FileRow)base.Rows[index];
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChanging
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_0;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_0, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_0;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_0, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChanged
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_1;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_1, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_1;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_1, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowDeleting
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_2;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_2, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_2;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_2, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowDeleted
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_3;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_3, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler = this.tAbnObjDoc_FileRowChangeEventHandler_3;
					DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_FileRowChangeEventHandler2 = tAbnObjDoc_FileRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_FileRowChangeEventHandler2, value);
						tAbnObjDoc_FileRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler>(ref this.tAbnObjDoc_FileRowChangeEventHandler_3, value2, tAbnObjDoc_FileRowChangeEventHandler2);
					}
					while (tAbnObjDoc_FileRowChangeEventHandler != tAbnObjDoc_FileRowChangeEventHandler2);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AddtAbnObjDoc_FileRow(DataSetAbnObjAct.tAbnObjDoc_FileRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataSetAbnObjAct.tAbnObjDoc_FileRow AddtAbnObjDoc_FileRow(int idList, string FileName, byte[] File, DateTime dateChange, int idTemplate)
			{
				DataSetAbnObjAct.tAbnObjDoc_FileRow tAbnObjDoc_FileRow = (DataSetAbnObjAct.tAbnObjDoc_FileRow)base.NewRow();
				object[] itemArray = new object[]
				{
					null,
					idList,
					FileName,
					File,
					dateChange,
					idTemplate
				};
				tAbnObjDoc_FileRow.ItemArray = itemArray;
				base.Rows.Add(tAbnObjDoc_FileRow);
				return tAbnObjDoc_FileRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataSetAbnObjAct.tAbnObjDoc_FileRow FindByid(int id)
			{
				return (DataSetAbnObjAct.tAbnObjDoc_FileRow)base.Rows.Find(new object[]
				{
					id
				});
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				DataSetAbnObjAct.tAbnObjDoc_FileDataTable tAbnObjDoc_FileDataTable = (DataSetAbnObjAct.tAbnObjDoc_FileDataTable)base.Clone();
				tAbnObjDoc_FileDataTable.method_0();
				return tAbnObjDoc_FileDataTable;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected override DataTable CreateInstance()
			{
				return new DataSetAbnObjAct.tAbnObjDoc_FileDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void method_0()
			{
				this.dataColumn_0 = base.Columns["id"];
				this.dataColumn_1 = base.Columns["idList"];
				this.dataColumn_2 = base.Columns["FileName"];
				this.dataColumn_3 = base.Columns["File"];
				this.dataColumn_4 = base.Columns["dateChange"];
				this.dataColumn_5 = base.Columns["idTemplate"];
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private void method_1()
			{
				this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_0);
				this.dataColumn_1 = new DataColumn("idList", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_1);
				this.dataColumn_2 = new DataColumn("FileName", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_2);
				this.dataColumn_3 = new DataColumn("File", typeof(byte[]), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_3);
				this.dataColumn_4 = new DataColumn("dateChange", typeof(DateTime), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_4);
				this.dataColumn_5 = new DataColumn("idTemplate", typeof(int), null, MappingType.Element);
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
				this.dataColumn_2.AllowDBNull = false;
				this.dataColumn_2.MaxLength = 1024;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataSetAbnObjAct.tAbnObjDoc_FileRow NewtAbnObjDoc_FileRow()
			{
				return (DataSetAbnObjAct.tAbnObjDoc_FileRow)base.NewRow();
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new DataSetAbnObjAct.tAbnObjDoc_FileRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(DataSetAbnObjAct.tAbnObjDoc_FileRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.tAbnObjDoc_FileRowChangeEventHandler_1 != null)
				{
					this.tAbnObjDoc_FileRowChangeEventHandler_1(this, new DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_FileRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.tAbnObjDoc_FileRowChangeEventHandler_0 != null)
				{
					this.tAbnObjDoc_FileRowChangeEventHandler_0(this, new DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_FileRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.tAbnObjDoc_FileRowChangeEventHandler_3 != null)
				{
					this.tAbnObjDoc_FileRowChangeEventHandler_3(this, new DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_FileRow)e.Row, e.Action));
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.tAbnObjDoc_FileRowChangeEventHandler_2 != null)
				{
					this.tAbnObjDoc_FileRowChangeEventHandler_2(this, new DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_FileRow)e.Row, e.Action));
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void RemovetAbnObjDoc_FileRow(DataSetAbnObjAct.tAbnObjDoc_FileRow row)
			{
				base.Rows.Remove(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				DataSetAbnObjAct dataSetAbnObjAct = new DataSetAbnObjAct();
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
				xmlSchemaAttribute.FixedValue = dataSetAbnObjAct.Namespace;
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
				xmlSchemaAttribute2.Name = "tableTypeName";
				xmlSchemaAttribute2.FixedValue = "tAbnObjDoc_FileDataTable";
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
				xmlSchemaComplexType.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSetAbnObjAct.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream2 = new MemoryStream();
					try
					{
						schemaSerializable.Write(memoryStream);
						foreach (object obj in xs.Schemas(schemaSerializable.TargetNamespace))
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
				xs.Add(schemaSerializable);
				return xmlSchemaComplexType;
			}

			private DataColumn dataColumn_0;

			private DataColumn dataColumn_1;

			private DataColumn dataColumn_2;

			private DataColumn dataColumn_3;

			private DataColumn dataColumn_4;

			private DataColumn dataColumn_5;

			[CompilerGenerated]
			private DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler_0;

			[CompilerGenerated]
			private DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler_1;

			[CompilerGenerated]
			private DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler_2;

			[CompilerGenerated]
			private DataSetAbnObjAct.tAbnObjDoc_FileRowChangeEventHandler tAbnObjDoc_FileRowChangeEventHandler_3;
		}

		[XmlSchemaProvider("GetTypedTableSchema")]
		[Serializable]
		public class tAbnObjDoc_ListDataTable : TypedTableBase<DataSetAbnObjAct.tAbnObjDoc_ListRow>
		{
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public tAbnObjDoc_ListDataTable()
			{
				
				
				base.TableName = "tAbnObjDoc_List";
				this.BeginInit();
				this.method_1();
				this.EndInit();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal tAbnObjDoc_ListDataTable(DataTable table)
			{
				
				
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected tAbnObjDoc_ListDataTable(SerializationInfo info, StreamingContext context)
			{
				
				base..ctor(info, context);
				this.method_0();
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
			public DataColumn idAbnObjColumn
			{
				get
				{
					return this.dataColumn_1;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn DocNumberColumn
			{
				get
				{
					return this.dataColumn_2;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn DocDateColumn
			{
				get
				{
					return this.dataColumn_3;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn idDocTypeColumn
			{
				get
				{
					return this.dataColumn_4;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn isActiveColumn
			{
				get
				{
					return this.dataColumn_5;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DeletedColumn
			{
				get
				{
					return this.dataColumn_6;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataColumn idAbnColumn
			{
				get
				{
					return this.dataColumn_7;
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
			public DataSetAbnObjAct.tAbnObjDoc_ListRow this[int index]
			{
				get
				{
					return (DataSetAbnObjAct.tAbnObjDoc_ListRow)base.Rows[index];
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChanging
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_0;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_0, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_0;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_0, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChanged
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_1;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_1, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_1;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_1, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowDeleting
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_2;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_2, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_2;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_2, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowDeleted
			{
				[CompilerGenerated]
				add
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_3;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Combine(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_3, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler = this.tAbnObjDoc_ListRowChangeEventHandler_3;
					DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler2;
					do
					{
						tAbnObjDoc_ListRowChangeEventHandler2 = tAbnObjDoc_ListRowChangeEventHandler;
						DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler value2 = (DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler)Delegate.Remove(tAbnObjDoc_ListRowChangeEventHandler2, value);
						tAbnObjDoc_ListRowChangeEventHandler = Interlocked.CompareExchange<DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler>(ref this.tAbnObjDoc_ListRowChangeEventHandler_3, value2, tAbnObjDoc_ListRowChangeEventHandler2);
					}
					while (tAbnObjDoc_ListRowChangeEventHandler != tAbnObjDoc_ListRowChangeEventHandler2);
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void AddtAbnObjDoc_ListRow(DataSetAbnObjAct.tAbnObjDoc_ListRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataSetAbnObjAct.tAbnObjDoc_ListRow AddtAbnObjDoc_ListRow(int idAbnObj, string DocNumber, DateTime DocDate, int idDocType, bool isActive, bool Deleted, int idAbn)
			{
				DataSetAbnObjAct.tAbnObjDoc_ListRow tAbnObjDoc_ListRow = (DataSetAbnObjAct.tAbnObjDoc_ListRow)base.NewRow();
				object[] itemArray = new object[]
				{
					null,
					idAbnObj,
					DocNumber,
					DocDate,
					idDocType,
					isActive,
					Deleted,
					idAbn
				};
				tAbnObjDoc_ListRow.ItemArray = itemArray;
				base.Rows.Add(tAbnObjDoc_ListRow);
				return tAbnObjDoc_ListRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataSetAbnObjAct.tAbnObjDoc_ListRow FindByid(int id)
			{
				return (DataSetAbnObjAct.tAbnObjDoc_ListRow)base.Rows.Find(new object[]
				{
					id
				});
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public override DataTable Clone()
			{
				DataSetAbnObjAct.tAbnObjDoc_ListDataTable tAbnObjDoc_ListDataTable = (DataSetAbnObjAct.tAbnObjDoc_ListDataTable)base.Clone();
				tAbnObjDoc_ListDataTable.method_0();
				return tAbnObjDoc_ListDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new DataSetAbnObjAct.tAbnObjDoc_ListDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void method_0()
			{
				this.dataColumn_0 = base.Columns["id"];
				this.dataColumn_1 = base.Columns["idAbnObj"];
				this.dataColumn_2 = base.Columns["DocNumber"];
				this.dataColumn_3 = base.Columns["DocDate"];
				this.dataColumn_4 = base.Columns["idDocType"];
				this.dataColumn_5 = base.Columns["isActive"];
				this.dataColumn_6 = base.Columns["Deleted"];
				this.dataColumn_7 = base.Columns["idAbn"];
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			private void method_1()
			{
				this.dataColumn_0 = new DataColumn("id", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_0);
				this.dataColumn_1 = new DataColumn("idAbnObj", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_1);
				this.dataColumn_2 = new DataColumn("DocNumber", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_2);
				this.dataColumn_3 = new DataColumn("DocDate", typeof(DateTime), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_3);
				this.dataColumn_4 = new DataColumn("idDocType", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_4);
				this.dataColumn_5 = new DataColumn("isActive", typeof(bool), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_5);
				this.dataColumn_6 = new DataColumn("Deleted", typeof(bool), null, MappingType.Element);
				base.Columns.Add(this.dataColumn_6);
				this.dataColumn_7 = new DataColumn("idAbn", typeof(int), null, MappingType.Element);
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
				this.dataColumn_2.AllowDBNull = false;
				this.dataColumn_2.MaxLength = 20;
				this.dataColumn_3.AllowDBNull = false;
				this.dataColumn_4.AllowDBNull = false;
				this.dataColumn_5.AllowDBNull = false;
				this.dataColumn_6.AllowDBNull = false;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataSetAbnObjAct.tAbnObjDoc_ListRow NewtAbnObjDoc_ListRow()
			{
				return (DataSetAbnObjAct.tAbnObjDoc_ListRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new DataSetAbnObjAct.tAbnObjDoc_ListRow(builder);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected override Type GetRowType()
			{
				return typeof(DataSetAbnObjAct.tAbnObjDoc_ListRow);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.tAbnObjDoc_ListRowChangeEventHandler_1 != null)
				{
					this.tAbnObjDoc_ListRowChangeEventHandler_1(this, new DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_ListRow)e.Row, e.Action));
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.tAbnObjDoc_ListRowChangeEventHandler_0 != null)
				{
					this.tAbnObjDoc_ListRowChangeEventHandler_0(this, new DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_ListRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.tAbnObjDoc_ListRowChangeEventHandler_3 != null)
				{
					this.tAbnObjDoc_ListRowChangeEventHandler_3(this, new DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_ListRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.tAbnObjDoc_ListRowChangeEventHandler_2 != null)
				{
					this.tAbnObjDoc_ListRowChangeEventHandler_2(this, new DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEvent((DataSetAbnObjAct.tAbnObjDoc_ListRow)e.Row, e.Action));
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void RemovetAbnObjDoc_ListRow(DataSetAbnObjAct.tAbnObjDoc_ListRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				DataSetAbnObjAct dataSetAbnObjAct = new DataSetAbnObjAct();
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
				xmlSchemaAttribute.FixedValue = dataSetAbnObjAct.Namespace;
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
				xmlSchemaAttribute2.Name = "tableTypeName";
				xmlSchemaAttribute2.FixedValue = "tAbnObjDoc_ListDataTable";
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
				xmlSchemaComplexType.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSetAbnObjAct.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream2 = new MemoryStream();
					try
					{
						schemaSerializable.Write(memoryStream);
						foreach (object obj in xs.Schemas(schemaSerializable.TargetNamespace))
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
				xs.Add(schemaSerializable);
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
			private DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler_0;

			[CompilerGenerated]
			private DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler_1;

			[CompilerGenerated]
			private DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler_2;

			[CompilerGenerated]
			private DataSetAbnObjAct.tAbnObjDoc_ListRowChangeEventHandler tAbnObjDoc_ListRowChangeEventHandler_3;
		}

		public class vActBalanceRow : DataRow
		{
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal vActBalanceRow(DataRowBuilder rb)
			{
				
				base..ctor(rb);
				this.vActBalanceDataTable_0 = (DataSetAbnObjAct.vActBalanceDataTable)base.Table;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int id
			{
				get
				{
					int result;
					try
					{
						result = (int)base[this.vActBalanceDataTable_0.idColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'id' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.idColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string TypeDoc
			{
				get
				{
					return (string)base[this.vActBalanceDataTable_0.TypeDocColumn];
				}
				set
				{
					base[this.vActBalanceDataTable_0.TypeDocColumn] = value;
				}
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
						result = (int)base[this.vActBalanceDataTable_0.CodeAbonentColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'CodeAbonent' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.CodeAbonentColumn] = value;
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
						result = (string)base[this.vActBalanceDataTable_0.NameColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'Name' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.NameColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string ObjName
			{
				get
				{
					string result;
					try
					{
						result = (string)base[this.vActBalanceDataTable_0.ObjNameColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'ObjName' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.ObjNameColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string Data
			{
				get
				{
					string result;
					try
					{
						result = (string)base[this.vActBalanceDataTable_0.DataColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'Data' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.DataColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int idList
			{
				get
				{
					int result;
					try
					{
						result = (int)base[this.vActBalanceDataTable_0.idListColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'idList' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.idListColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int idAbn
			{
				get
				{
					int result;
					try
					{
						result = (int)base[this.vActBalanceDataTable_0.idAbnColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'idAbn' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.idAbnColumn] = value;
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
						result = (int)base[this.vActBalanceDataTable_0.idAbnObjColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'idAbnObj' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.idAbnObjColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string StationList
			{
				get
				{
					string result;
					try
					{
						result = (string)base[this.vActBalanceDataTable_0.StationListColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'StationList' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.StationListColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string ActNumber
			{
				get
				{
					return (string)base[this.vActBalanceDataTable_0.ActNumberColumn];
				}
				set
				{
					base[this.vActBalanceDataTable_0.ActNumberColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DateTime ActDate
			{
				get
				{
					DateTime result;
					try
					{
						result = (DateTime)base[this.vActBalanceDataTable_0.ActDateColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'ActDate' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.ActDateColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string ActRegion
			{
				get
				{
					string result;
					try
					{
						result = (string)base[this.vActBalanceDataTable_0.ActRegionColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'ActRegion' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.ActRegionColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int isActive
			{
				get
				{
					int result;
					try
					{
						result = (int)base[this.vActBalanceDataTable_0.isActiveColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'isActive' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.isActiveColumn] = value;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public int deleted
			{
				get
				{
					int result;
					try
					{
						result = (int)base[this.vActBalanceDataTable_0.deletedColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'deleted' in table 'vActBalance' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.vActBalanceDataTable_0.deletedColumn] = value;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsidNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.idColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetidNull()
			{
				base[this.vActBalanceDataTable_0.idColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsCodeAbonentNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.CodeAbonentColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetCodeAbonentNull()
			{
				base[this.vActBalanceDataTable_0.CodeAbonentColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsNameNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.NameColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetNameNull()
			{
				base[this.vActBalanceDataTable_0.NameColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsObjNameNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.ObjNameColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetObjNameNull()
			{
				base[this.vActBalanceDataTable_0.ObjNameColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsDataNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.DataColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetDataNull()
			{
				base[this.vActBalanceDataTable_0.DataColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsidListNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.idListColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetidListNull()
			{
				base[this.vActBalanceDataTable_0.idListColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsidAbnNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.idAbnColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetidAbnNull()
			{
				base[this.vActBalanceDataTable_0.idAbnColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsidAbnObjNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.idAbnObjColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetidAbnObjNull()
			{
				base[this.vActBalanceDataTable_0.idAbnObjColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsStationListNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.StationListColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetStationListNull()
			{
				base[this.vActBalanceDataTable_0.StationListColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsActDateNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.ActDateColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetActDateNull()
			{
				base[this.vActBalanceDataTable_0.ActDateColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsActRegionNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.ActRegionColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetActRegionNull()
			{
				base[this.vActBalanceDataTable_0.ActRegionColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsisActiveNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.isActiveColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetisActiveNull()
			{
				base[this.vActBalanceDataTable_0.isActiveColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsdeletedNull()
			{
				return base.IsNull(this.vActBalanceDataTable_0.deletedColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetdeletedNull()
			{
				base[this.vActBalanceDataTable_0.deletedColumn] = Convert.DBNull;
			}

			private DataSetAbnObjAct.vActBalanceDataTable vActBalanceDataTable_0;
		}

		public class tAbnObjDoc_FileRow : DataRow
		{
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal tAbnObjDoc_FileRow(DataRowBuilder rb)
			{
				
				base..ctor(rb);
				this.tAbnObjDoc_FileDataTable_0 = (DataSetAbnObjAct.tAbnObjDoc_FileDataTable)base.Table;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public int id
			{
				get
				{
					return (int)base[this.tAbnObjDoc_FileDataTable_0.idColumn];
				}
				set
				{
					base[this.tAbnObjDoc_FileDataTable_0.idColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int idList
			{
				get
				{
					return (int)base[this.tAbnObjDoc_FileDataTable_0.idListColumn];
				}
				set
				{
					base[this.tAbnObjDoc_FileDataTable_0.idListColumn] = value;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public string FileName
			{
				get
				{
					return (string)base[this.tAbnObjDoc_FileDataTable_0.FileNameColumn];
				}
				set
				{
					base[this.tAbnObjDoc_FileDataTable_0.FileNameColumn] = value;
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
						result = (byte[])base[this.tAbnObjDoc_FileDataTable_0.FileColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'File' in table 'tAbnObjDoc_File' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.tAbnObjDoc_FileDataTable_0.FileColumn] = value;
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
						result = (DateTime)base[this.tAbnObjDoc_FileDataTable_0.dateChangeColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'dateChange' in table 'tAbnObjDoc_File' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.tAbnObjDoc_FileDataTable_0.dateChangeColumn] = value;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public int idTemplate
			{
				get
				{
					int result;
					try
					{
						result = (int)base[this.tAbnObjDoc_FileDataTable_0.idTemplateColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'idTemplate' in table 'tAbnObjDoc_File' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.tAbnObjDoc_FileDataTable_0.idTemplateColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsFileNull()
			{
				return base.IsNull(this.tAbnObjDoc_FileDataTable_0.FileColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetFileNull()
			{
				base[this.tAbnObjDoc_FileDataTable_0.FileColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsdateChangeNull()
			{
				return base.IsNull(this.tAbnObjDoc_FileDataTable_0.dateChangeColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetdateChangeNull()
			{
				base[this.tAbnObjDoc_FileDataTable_0.dateChangeColumn] = Convert.DBNull;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool IsidTemplateNull()
			{
				return base.IsNull(this.tAbnObjDoc_FileDataTable_0.idTemplateColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetidTemplateNull()
			{
				base[this.tAbnObjDoc_FileDataTable_0.idTemplateColumn] = Convert.DBNull;
			}

			private DataSetAbnObjAct.tAbnObjDoc_FileDataTable tAbnObjDoc_FileDataTable_0;
		}

		public class tAbnObjDoc_ListRow : DataRow
		{
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal tAbnObjDoc_ListRow(DataRowBuilder rb)
			{
				
				base..ctor(rb);
				this.tAbnObjDoc_ListDataTable_0 = (DataSetAbnObjAct.tAbnObjDoc_ListDataTable)base.Table;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public int id
			{
				get
				{
					return (int)base[this.tAbnObjDoc_ListDataTable_0.idColumn];
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.idColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int idAbnObj
			{
				get
				{
					return (int)base[this.tAbnObjDoc_ListDataTable_0.idAbnObjColumn];
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.idAbnObjColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string DocNumber
			{
				get
				{
					return (string)base[this.tAbnObjDoc_ListDataTable_0.DocNumberColumn];
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.DocNumberColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DateTime DocDate
			{
				get
				{
					return (DateTime)base[this.tAbnObjDoc_ListDataTable_0.DocDateColumn];
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.DocDateColumn] = value;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public int idDocType
			{
				get
				{
					return (int)base[this.tAbnObjDoc_ListDataTable_0.idDocTypeColumn];
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.idDocTypeColumn] = value;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool isActive
			{
				get
				{
					return (bool)base[this.tAbnObjDoc_ListDataTable_0.isActiveColumn];
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.isActiveColumn] = value;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public bool Deleted
			{
				get
				{
					return (bool)base[this.tAbnObjDoc_ListDataTable_0.DeletedColumn];
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.DeletedColumn] = value;
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
						result = (int)base[this.tAbnObjDoc_ListDataTable_0.idAbnColumn];
					}
					catch (InvalidCastException innerException)
					{
						throw new StrongTypingException("The value for column 'idAbn' in table 'tAbnObjDoc_List' is DBNull.", innerException);
					}
					return result;
				}
				set
				{
					base[this.tAbnObjDoc_ListDataTable_0.idAbnColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsidAbnNull()
			{
				return base.IsNull(this.tAbnObjDoc_ListDataTable_0.idAbnColumn);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public void SetidAbnNull()
			{
				base[this.tAbnObjDoc_ListDataTable_0.idAbnColumn] = Convert.DBNull;
			}

			private DataSetAbnObjAct.tAbnObjDoc_ListDataTable tAbnObjDoc_ListDataTable_0;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class vActBalanceRowChangeEvent : EventArgs
		{
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public vActBalanceRowChangeEvent(DataSetAbnObjAct.vActBalanceRow row, DataRowAction action)
			{
				
				
				this.vActBalanceRow_0 = row;
				this.dataRowAction_0 = action;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataSetAbnObjAct.vActBalanceRow Row
			{
				get
				{
					return this.vActBalanceRow_0;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataRowAction Action
			{
				get
				{
					return this.dataRowAction_0;
				}
			}

			private DataSetAbnObjAct.vActBalanceRow vActBalanceRow_0;

			private DataRowAction dataRowAction_0;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class tAbnObjDoc_FileRowChangeEvent : EventArgs
		{
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public tAbnObjDoc_FileRowChangeEvent(DataSetAbnObjAct.tAbnObjDoc_FileRow row, DataRowAction action)
			{
				
				
				this.tAbnObjDoc_FileRow_0 = row;
				this.dataRowAction_0 = action;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataSetAbnObjAct.tAbnObjDoc_FileRow Row
			{
				get
				{
					return this.tAbnObjDoc_FileRow_0;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataRowAction Action
			{
				get
				{
					return this.dataRowAction_0;
				}
			}

			private DataSetAbnObjAct.tAbnObjDoc_FileRow tAbnObjDoc_FileRow_0;

			private DataRowAction dataRowAction_0;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class tAbnObjDoc_ListRowChangeEvent : EventArgs
		{
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public tAbnObjDoc_ListRowChangeEvent(DataSetAbnObjAct.tAbnObjDoc_ListRow row, DataRowAction action)
			{
				
				
				this.tAbnObjDoc_ListRow_0 = row;
				this.dataRowAction_0 = action;
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataSetAbnObjAct.tAbnObjDoc_ListRow Row
			{
				get
				{
					return this.tAbnObjDoc_ListRow_0;
				}
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			[DebuggerNonUserCode]
			public DataRowAction Action
			{
				get
				{
					return this.dataRowAction_0;
				}
			}

			private DataSetAbnObjAct.tAbnObjDoc_ListRow tAbnObjDoc_ListRow_0;

			private DataRowAction dataRowAction_0;
		}
	}
}
