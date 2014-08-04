using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace RedPillService
{
    [ServiceContract(Namespace = "http://KnockKnock.readify.net")]
    public interface IRedPill
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);

        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(String s);

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);

        [OperationContract]
        ContactDetails WhoAreYou();

    }

    [DataContract(Namespace = "http://KnockKnock.readify.net")]
    public enum TriangleType
    {
        [EnumMember]
        Error = 0,
        [EnumMember]
        Equilateral = 1,
        [EnumMember]
        Isosceles = 2,
        [EnumMember]
        Scalene = 3
    }

    [DataContract(Namespace = "http://KnockKnock.readify.net")]
    public class ContactDetails : INotifyPropertyChanged, IExtensibleDataObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ExtensionDataObject extensionData;

        [Browsable(false)]
        public ExtensionDataObject ExtensionData
        {
            get { return extensionData; }
            set { extensionData = value; }
        }

        private string EmailAddressField;

        [DataMember]
        public string EmailAddress
        {
            get { return EmailAddressField; }
            set
            {
                if ((object.ReferenceEquals(this.EmailAddressField, value) != true))
                {
                    this.EmailAddressField = value;
                    this.RaisePropertyChanged("EmailAddress");
                }
            }
        }

        private String FamilyNameField;

        [DataMember]
        public String FamilyName
        {
            get { return FamilyNameField; }
            set
            {
                if ((object.ReferenceEquals(this.FamilyNameField, value) != true))
                {
                    this.FamilyNameField = value;
                    this.RaisePropertyChanged("FamilyName");
                }
            }
        }

        private string GivenNameField;
        [DataMember]
        public string GivenName
        {
            get { return GivenNameField; }
            set
            {
                if ((object.ReferenceEquals(this.GivenNameField, value) != true))
                {
                    this.GivenNameField = value;
                    this.RaisePropertyChanged("GivenName");
                }
            }
        }

        private String PhoneNumberField;
        [DataMember]
        public String PhoneNumber
        {
            get { return PhoneNumberField; }
            set
            {
                if ((object.ReferenceEquals(this.PhoneNumberField, value) != true))
                {
                    this.PhoneNumberField = value;
                    this.RaisePropertyChanged("PhoneNumber");
                }
            }
        }



    }
}