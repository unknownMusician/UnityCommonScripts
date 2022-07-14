using System;
using System.Reflection;

namespace AreYouFruits.Common.InspectorValidation
{
    public sealed class BehaviourNotInitializedException : Exception
    {
        private const string DefaultMessage = "Behaviour is not completely initialized.";

        public BehaviourNotInitializedException(FieldInfo unitializedField) : this(
            GenerateMessage(unitializedField)
        ) { }

        private static string GenerateMessage(FieldInfo unitializedField)
        {
            return $"Member {unitializedField.FieldType} {unitializedField.Name}"
              + $" in {unitializedField.DeclaringType} is not completely initialized.";
        }

        public BehaviourNotInitializedException() : base(DefaultMessage) { }
        
        public BehaviourNotInitializedException(string message) : base(message) { }

        public BehaviourNotInitializedException(string message, Exception innerException) : base(
            message,
            innerException
        ) { }
    }
}
