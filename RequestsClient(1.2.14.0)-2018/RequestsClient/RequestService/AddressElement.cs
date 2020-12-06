using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace RequestsClient.RequestService
{
	[DataContract(Name = "AddressElement", Namespace = "http://aisgorod.ru/")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
	[Serializable]
	public class AddressElement : IExtensibleDataObject, INotifyPropertyChanged
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

		[DataMember(IsRequired = true)]
		public long Id
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
					this.RaisePropertyChanged("Id");
				}
			}
		}

		[DataMember(EmitDefaultValue = false)]
		public string Name
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
					this.RaisePropertyChanged("Name");
				}
			}
		}

		[DataMember(EmitDefaultValue = false, Order = 2)]
		public string Designation
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
					this.RaisePropertyChanged("Designation");
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

		public AddressElement()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		[NonSerialized]
		private ExtensionDataObject extensionDataObject_0;

		private long long_0;

		[OptionalField]
		private string string_0;

		[OptionalField]
		private string string_1;

		[CompilerGenerated]
		private PropertyChangedEventHandler propertyChangedEventHandler_0;
	}
}
