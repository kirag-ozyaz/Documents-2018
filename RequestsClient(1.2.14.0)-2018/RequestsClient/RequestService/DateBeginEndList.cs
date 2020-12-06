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
	[DataContract(Name = "DateBeginEndList", Namespace = "http://aisgorod.ru/")]
	[Serializable]
	public class DateBeginEndList : IExtensibleDataObject, INotifyPropertyChanged
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

		[DataMember(IsRequired = true)]
		public DateTime DateEnd
		{
			get
			{
				return this.dateTime_1;
			}
			set
			{
				if (!this.dateTime_1.Equals(value))
				{
					this.dateTime_1 = value;
					this.RaisePropertyChanged("DateEnd");
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

		public DateBeginEndList()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		[NonSerialized]
		private ExtensionDataObject extensionDataObject_0;

		private DateTime dateTime_0;

		private DateTime dateTime_1;

		[CompilerGenerated]
		private PropertyChangedEventHandler propertyChangedEventHandler_0;
	}
}
