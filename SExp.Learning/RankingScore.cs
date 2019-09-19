using System;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;

namespace SExp.Learning
{
    public class RankingScore : Feature<double>
    {
        public RankingScore(Grammar grammar) : base(grammar, "Score") {}

        protected override double GetFeatureValueForVariable(VariableNode variable) => 0;

        // Your ranking functions here
    }
}
