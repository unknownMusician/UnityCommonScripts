using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class ProbabilityExtensions
    {
        public static bool EvaluateProbability(float randomValue, float probability) => randomValue < probability;
        public static bool EvaluateProbability(float probability) => EvaluateProbability(Random.value, probability);
    }
}
