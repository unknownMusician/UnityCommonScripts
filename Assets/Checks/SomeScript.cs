using AreYouFruits.InterfaceSerialization.Unity;
using AreYouFruits.Nullability;
using UnityEngine;

public sealed class SomeScript : MonoBehaviour
{
    public Optional<int> someNumber;
    public SerializedInterface<ISomeInterface> someInterface;
}
