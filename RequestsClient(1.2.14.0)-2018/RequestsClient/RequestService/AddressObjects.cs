using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
	[DataContract(Name = "AddressObjects", Namespace = "http://aisgorod.ru/")]
	[DebuggerStepThrough]
	[Serializable]
	public class AddressObjects : IExtensibleDataObject, INotifyPropertyChanged
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
		public string City
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
					this.RaisePropertyChanged("City");
				}
			}
		}

		[DataMember(EmitDefaultValue = false)]
		public string CityType
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
					this.RaisePropertyChanged("CityType");
				}
			}
		}

		[DataMember(EmitDefaultValue = false)]
		public string Street
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
					this.RaisePropertyChanged("Street");
				}
			}
		}

		[DataMember(EmitDefaultValue = false)]
		public string StreetType
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
					this.RaisePropertyChanged("StreetType");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 4)]
		public string House
		{
			get
			{
				return this.string_4;
			}
			set
			{
				if (this.string_4 != value)
				{
					this.string_4 = value;
					this.RaisePropertyChanged("House");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 5)]
		public string Object
		{
			get
			{
				return this.string_5;
			}
			set
			{
				if (this.string_5 != value)
				{
					this.string_5 = value;
					this.RaisePropertyChanged("Object");
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

		public AddressObjects()
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
		private string string_2;

		[OptionalField]
		private string string_3;

		[OptionalField]
		private string string_4;

		[OptionalField]
		private string string_5;

		[CompilerGenerated]
		private PropertyChangedEventHandler propertyChangedEventHandler_0;
	}
}
