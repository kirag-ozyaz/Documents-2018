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
	[DebuggerStepThrough]
	[DataContract(Name = "Response", Namespace = "http://aisgorod.ru/")]
	[Serializable]
	public class Response : IExtensibleDataObject, INotifyPropertyChanged
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
		public int Code
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
					this.RaisePropertyChanged("Code");
				}
			}
		}

		[DataMember(EmitDefaultValue = false)]
		public string Message
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
					this.RaisePropertyChanged("Message");
				}
			}
		}

		[DataMember(IsRequired = true)]
		public long RequestId
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
					this.RaisePropertyChanged("RequestId");
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

		public Response()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		[NonSerialized]
		private ExtensionDataObject extensionDataObject_0;

		private int int_0;

		[OptionalField]
		private string string_0;

		private long long_0;

		[CompilerGenerated]
		private PropertyChangedEventHandler propertyChangedEventHandler_0;
	}
}
