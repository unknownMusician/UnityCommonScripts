namespace AreYouFruits.Math
{
    public static class ProbabilityExtensions
    {
        public static bool EvaluateProbability(float randomValue, float probability) => randomValue < probability;
    }
}

