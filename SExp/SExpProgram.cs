using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Microsoft.ProgramSynthesis.Compiler;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Learning.Logging;
using Microsoft.ProgramSynthesis.Learning.Strategies;
using Microsoft.ProgramSynthesis.Specifications;
using SExp.Learning;
using SExp.Semantics;

namespace SExp
{
    class SExpProgram
    {
        static Grammar getGrammar()
        {
            var g = DSLCompiler.Compile(new CompilerOptions
            {
                InputGrammarText = File.ReadAllText("SExp.grammar"),
                References = CompilerReference.FromAssemblyFiles(
                    typeof(SExpProgram).GetTypeInfo().Assembly,
                    typeof(Semantics.SExp).GetTypeInfo().Assembly,
                    typeof(Semantics.Semantics).GetTypeInfo().Assembly,
                    typeof(Learning.RankingScore).GetTypeInfo().Assembly)
            });
            return g.Value;
        }
        static SynthesisEngine getEngine(Grammar grammar)
        {
            var learners = new Learners(grammar);
            return new SynthesisEngine(grammar, new SynthesisEngine.Config
            {
                Strategies = new ISynthesisStrategy[]
                {
                    new DeductiveSynthesis(learners),
                }
            });
        }
        static string padding(int n)
        {
            var r = "";
            for (int i = 0; i<n; i++)
            {
                r += " ";
            }
            return r;
        }
        static ExampleSpec toSpec(Grammar grammar, Dictionary<string,string> exs)
        {
            var d = new Dictionary<State, object>();
            foreach (var ex in exs)
            {
                var k = SExpParser.parseFull(ex.Key);
                var v = SExpParser.parseFull(ex.Value);
                System.Diagnostics.Debug.Assert(k != null);
                System.Diagnostics.Debug.Assert(v != null);
                Console.WriteLine("input:  "+ex.Key+padding(ex.Value.Length - ex.Key.Length)+" -- "+k);
                Console.WriteLine("output: "+ex.Value+padding(ex.Key.Length - ex.Value.Length)+" -- " +v);
                d.Add(State.CreateForLearning(grammar.InputSymbol, k), v);
            }
            return new ExampleSpec(d);
        }
        static ProgramNode learnFromExamples(Grammar grammar, SynthesisEngine engine, RankingScore rankingScores, Dictionary<string,string> exs)
        {
            var spec = toSpec(grammar, exs);
            var ps = engine.LearnGrammar(spec);
            Console.WriteLine("all programs: "+ps);
            var best = ps.TopK(rankingScores).First();
            Console.WriteLine("best program: "+best);
            foreach(var ex in spec.Examples)
            {
                System.Diagnostics.Debug.Assert(best.Invoke(ex.Key).Equals(ex.Value));
            }
            return best;
        }
        public static void Main(string[] args)
        {
            var grammar = getGrammar();
            var engine = getEngine(grammar);
            var rankingScores = new RankingScore(grammar);
            Console.WriteLine("1");
            learnFromExamples(grammar, engine, rankingScores, new Dictionary<string,string> {
                ["c"] = "(a b)"
            });      
            Console.WriteLine("2");
            learnFromExamples(grammar, engine, rankingScores, new Dictionary<string, string>
            {
                ["(a b)"] = "a"
            });
            Console.WriteLine("3");
            learnFromExamples(grammar, engine, rankingScores, new Dictionary<string, string>
            {
                ["(a b)"] = "a",
                ["(a1 b1)"] = "a1"
            });
            Console.WriteLine("4");
            learnFromExamples(grammar, engine, rankingScores, new Dictionary<string, string>
            {
                ["(a b)"] = "b"
            });
            Console.WriteLine("5");
            learnFromExamples(grammar, engine, rankingScores, new Dictionary<string, string>
            {
                ["a"] = "(a a)"
            });
            Console.WriteLine("6");
            learnFromExamples(grammar, engine, rankingScores, new Dictionary<string, string>
            {
                ["(a b)"] = "((a b) (b a))",
                ["(a1 b1)"] = "((a1 b1) (b1 a1))"
            });
        }
    }
}
