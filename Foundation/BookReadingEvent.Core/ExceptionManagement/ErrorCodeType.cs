using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BookReadingEvent.Core.ExceptionManagement
{
    [DataContract]
    public enum ErrorCodeType
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        DataStore = 1000,
        [EnumMember]
        ExternalService = 2000,
        [EnumMember]
        VersionMismatch = 3000,
        [EnumMember]
        UnknownException = 4000,
    }
}
