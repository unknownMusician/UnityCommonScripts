using System;
using System.Reflection;

namespace AreYouFruits.Common.InspectorValidation
{
    public sealed class BehaviourNotInitializedException : Exception
    {
        private const string DefaultMessage = "Behaviour is not completely initialized.";

        public BehaviourNotInitializedException(FieldInfo uninitializedField) :
            this(GenerateMessage(uninitializedField)) { }

        private static string GenerateMessage(FieldInfo uninitializedField)
        {
            return $"Member {uninitializedField.FieldType} {uninitializedField.Name}"
              + $" in {uninitializedField.DeclaringType} is not completely initialized.";
        }

        public BehaviourNotInitializedException() : base(DefaultMessage) { }

        public BehaviourNotInitializedException(string message) : base(message) { }

        public BehaviourNotInitializedException(string message, Exception innerException) : base(message,
            innerException) { }
    }
}
