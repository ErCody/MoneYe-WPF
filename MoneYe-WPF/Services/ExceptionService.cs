using System;
using System.Runtime.Serialization;

namespace MoneYe_WPF.Services
{
    [Serializable]
    public class RegistrationException : Exception, IRegistrationException
    {
        public RegistrationException() { }

        public RegistrationException(string message) : base(message) { }

        public RegistrationException(string message, Exception inner) : base(message, inner) { }

        protected RegistrationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}