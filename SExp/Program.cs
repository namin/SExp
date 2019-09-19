using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Microsoft.ProgramSynthesis.Compiler;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Learning.Logging;
using Microsoft.ProgramSynthesis.Learning.Strategies;
using Microsoft.ProgramSynthesis.Specifications;
using SExp.Learning;

namespace SExp
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            var grammar = Language.Grammar;
            var nodeBuilders = Language.Build.Node;
            
            Console.WriteLine(grammar.Name);
            Console.WriteLine(ProgramNode.Parse("x", grammar, ASTSerializationFormat.HumanReadable));
            
            Console.WriteLine(nodeBuilders.Variable.x.Node);
            
        }
    }
}
