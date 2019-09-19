using System;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Rules;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Specifications;
using System.Collections.Generic;
using SExp.Semantics;


namespace SExp.Learning
{
    public class Learners : DomainLearningLogic
    {
        public Learners(Grammar grammar) : base(grammar) { }

        // Your custom learning logic here (for example, witness functions)
        delegate Semantics.SExp Selector(Semantics.SExp e);
        IEnumerable<Semantics.SExp> findAll(Semantics.SExp r, Semantics.SExp input, Semantics.SExp output, Selector selector)
        {
            var l = new List<Semantics.SExp>();
            var selected = selector(input);
            if (output.Equals(selected))
            {
                l.Add((r==null)?input:r);
                return l;
            }

            var c = input as Cons;
            if (c != null)
            {
                l.AddRange(findAll((r == null)?c.Car:r, c.Car, output, selector));
                l.AddRange(findAll((r == null)?c.Cdr:r, c.Cdr, output, selector));
            }
            return l;
        }
        [WitnessFunction("Car", 0)]
        DisjunctiveExamplesSpec WitnessCar(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                Cons input = inputState[rule.Grammar.Symbol("x")] as Cons;
                if (input == null)
                {
                    return null;
                }
                var l = new List<object>();
                foreach (Semantics.SExp output in example.Value)
                {
                    l.AddRange(findAll(null, input, output, Semantics.Semantics.Car));
                }
                if (l.Count == 0) return null;
                result[inputState] = l;
            }
            return new DisjunctiveExamplesSpec(result);
        }
        [WitnessFunction("Cdr", 0)]
        DisjunctiveExamplesSpec WitnessCdr(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                Cons input = inputState[rule.Grammar.Symbol("x")] as Cons;
                if (input == null)
                {
                    return null;
                }
                var l = new List<object>();
                foreach (Semantics.SExp output in example.Value)
                {
                    l.AddRange(findAll(null, input, output, Semantics.Semantics.Cdr));
                }
                if (l.Count == 0) return null;
                result[inputState] = l;
            }
            return new DisjunctiveExamplesSpec(result);
        }
        [WitnessFunction("Cons", 0)]
        DisjunctiveExamplesSpec WitnessCons0(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var l = new List<object>();
                foreach (Semantics.SExp output in example.Value)
                {
                    var c = output as Cons;
                    if (c == null)
                    {
                        return null;
                    }
                    l.Add(c.Car);
                }
                result[inputState] = l;
            }
            return new DisjunctiveExamplesSpec(result);
        }
        [WitnessFunction("Cons", 1)]
        DisjunctiveExamplesSpec WitnessCons1(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var l = new List<object>();
                foreach (Semantics.SExp output in example.Value)
                {
                    var c = output as Cons;
                    if (c == null)
                    {
                        return null;
                    }
                    l.Add(c.Cdr);
                }
                result[inputState] = l;
            }
            return new DisjunctiveExamplesSpec(result);
        }
        [WitnessFunction("Symbol", 0)]
        DisjunctiveExamplesSpec WitnessSymbol(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var l = new List<object>();
                foreach (Semantics.SExp output in example.Value)
                {
                    var c = output as Atom;
                    if (c == null)
                    {
                        return null;
                    }
                    l.Add(c.Value);
                }
                result[inputState] = l;
            }
            return new DisjunctiveExamplesSpec(result);
        }
        [WitnessFunction("Select", 0)]
        DisjunctiveExamplesSpec WitnessSelect(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var l = new List<object>();
                foreach (Semantics.SExp output in example.Value)
                {
                    l.Add(output);
                }
                result[inputState] = l;
            }
            return new DisjunctiveExamplesSpec(result);
        }
    }
}
