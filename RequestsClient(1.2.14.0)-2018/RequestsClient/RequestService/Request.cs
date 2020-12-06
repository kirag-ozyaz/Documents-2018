using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace RequestsClient.RequestService
{
	[DebuggerStepThrough]
	[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
	[DataContract(Name = "Request", Namespace = "http://aisgorod.ru/")]
	[Serializable]
	public class Request : IExtensibleDataObject, INotifyPropertyChanged
	{
		[Browsable(false)]
		public ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataObject_0;
			}
			set
			{
				this.extensionDataObject_0 = value;
			}
		}

		[DataMember(EmitDefaultValue = false)]
		public string Number
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (this.string_0 != value)
				{
					this.string_0 = value;
					this.RaisePropertyChanged("Number");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 1)]
		public string AddressDisableText
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (this.string_1 != value)
				{
					this.string_1 = value;
					this.RaisePropertyChanged("AddressDisableText");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 2)]
		public AddressObjects[] AddressHousesDidable
		{
			get
			{
				return this.addressObjects_0;
			}
			set
			{
				if (this.addressObjects_0 != value)
				{
					this.addressObjects_0 = value;
					this.RaisePropertyChanged("AddressHousesDidable");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 3)]
		public long RefTypeDisable
		{
			get
			{
				return this.long_0;
			}
			set
			{
				if (!this.long_0.Equals(value))
				{
					this.long_0 = value;
					this.RaisePropertyChanged("RefTypeDisable");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 4)]
		public string Cause
		{
			get
			{
				return this.string_2;
			}
			set
			{
				if (this.string_2 != value)
				{
					this.string_2 = value;
					this.RaisePropertyChanged("Cause");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 5)]
		public DateTime DateBegin
		{
			get
			{
				return this.dateTime_0;
			}
			set
			{
				if (!this.dateTime_0.Equals(value))
				{
					this.dateTime_0 = value;
					this.RaisePropertyChanged("DateBegin");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 6)]
		public long RefRequestStatusId
		{
			get
			{
				return this.long_1;
			}
			set
			{
				if (!this.long_1.Equals(value))
				{
					this.long_1 = value;
					this.RaisePropertyChanged("RefRequestStatusId");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 7)]
		public DateTime? DatePlan
		{
			get
			{
				return this.nullable_0;
			}
			set
			{
				if (!this.nullable_0.Equals(value))
				{
					this.nullable_0 = value;
					this.RaisePropertyChanged("DatePlan");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 8)]
		public DateTime? DateEnd
		{
			get
			{
				return this.nullable_1;
			}
			set
			{
				if (!this.nullable_1.Equals(value))
				{
					this.nullable_1 = value;
					this.RaisePropertyChanged("DateEnd");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 9)]
		public int ToOrganizationId
		{
			get
			{
				return this.pAmmmmFtn;
			}
			set
			{
				if (!this.pAmmmmFtn.Equals(value))
				{
					this.pAmmmmFtn = value;
					this.RaisePropertyChanged("ToOrganizationId");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 10)]
		public int PerformerOrganizationId
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (!this.int_0.Equals(value))
				{
					this.int_0 = value;
					this.RaisePropertyChanged("PerformerOrganizationId");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 11)]
		public long RefGroupWorksId
		{
			get
			{
				return this.long_2;
			}
			set
			{
				if (!this.long_2.Equals(value))
				{
					this.long_2 = value;
					this.RaisePropertyChanged("RefGroupWorksId");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 12)]
		public string Comment
		{
			get
			{
				return this.string_3;
			}
			set
			{
				if (this.string_3 != value)
				{
					this.string_3 = value;
					this.RaisePropertyChanged("Comment");
				}
			}
		}

		[DataMember(IsRequired = true, Order = 13)]
		public long RefRegionId
		{
			get
			{
				return this.long_3;
			}
			set
			{
				if (!this.long_3.Equals(value))
				{
					this.long_3 = value;
					this.RaisePropertyChanged("RefRegionId");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 14)]
		public DateBeginEndList[] DateBeginEnd
		{
			get
			{
				return this.dateBeginEndList_0;
			}
			set
			{
				if (this.dateBeginEndList_0 != value)
				{
					this.dateBeginEndList_0 = value;
					this.RaisePropertyChanged("DateBeginEnd");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 15)]
		public Document[] Documents
		{
			get
			{
				return this.document_0;
			}
			set
			{
				if (this.document_0 != value)
				{
					this.document_0 = value;
					this.RaisePropertyChanged("Documents");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public Request()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		[NonSerialized]
		private ExtensionDataObject extensionDataObject_0;

		[OptionalField]
		private string string_0;

		[OptionalField]
		private string string_1;

		[OptionalField]
		private AddressObjects[] addressObjects_0;

		private long long_0;

		[OptionalField]
		private string string_2;

		private DateTime dateTime_0;

		private long long_1;

		private DateTime? nullable_0;

		private DateTime? nullable_1;

		private int pAmmmmFtn;

		private int int_0;

		private long long_2;

		[OptionalField]
		private string string_3;

		private long long_3;

		[OptionalField]
		private DateBeginEndList[] dateBeginEndList_0;

		[OptionalField]
		private Document[] document_0;

		[CompilerGenerated]
		private PropertyChangedEventHandler propertyChangedEventHandler_0;
	}
}
