using AreYouFruits.Events;

namespace GeneratorsUseCases;

public struct SomeEvent : IEvent { }

public partial class SampleEventHandler
{
    [EventHandler]
    public static void Execute(SomeEvent d, int ss4212)
    {
        
    }
}