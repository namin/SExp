using System;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Microsoft.ProgramSynthesis.Features;

namespace SExp.Learning
{
    public class RankingScore : Feature<double>
    {
        public RankingScore(Grammar grammar) : base(grammar, "Score") {}

        protected override double GetFeatureValueForVariable(VariableNode variable) => 0;

        // Your ranking functions here
        [FeatureCalculator("Symbol", Method = CalculationMethod.FromChildrenFeatureValues)]
        [FeatureCalculator("Select", Method = CalculationMethod.FromChildrenFeatureValues)]
        [FeatureCalculator("Car", Method = CalculationMethod.FromChildrenFeatureValues)]
        [FeatureCalculator("Cdr", Method = CalculationMethod.FromChildrenFeatureValues)]
        double Score1(double score) => score;
        [FeatureCalculator("Cons", Method = CalculationMethod.FromChildrenFeatureValues)]
        double Score2(double score1, double score2) => score1*score2;
        [FeatureCalculator("s", Method = CalculationMethod.FromLiteral)]
        double ScoreS(string s) => 0.5;
        [FeatureCalculator("Input", Method = CalculationMethod.FromChildrenFeatureValues)]
        double ScoreInput(double score) => 1.0;
    }
}
