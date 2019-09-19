using System;
using System.Collections.Generic;

namespace SExp
{
    public class SExpParser
    {
        public static Semantics.SExp parseFull(String s)
        {
            var r = parse(s);
            if (r != null && r.Item2.Trim() == "")
            {
                return r.Item1;
            }
            return null;
        }
        public static Tuple<Semantics.SExp, String> parse(String s)
        {
            var r = parseSExp(s);
            if (r == null)
            {
                r = parseAtom(s);
            }
            return r;
        }
        public static Tuple<Semantics.SExp, String> parseSExp(String s)
        {
            var t = s.Trim();
            if (t.Length > 0 && t[0] == '(' && t[t.Length - 1] == ')')
            {
                var l = new List<Semantics.SExp>();
                var m = s.Substring(1, t.Length - 2).Trim();
                var r = parse(m);
                while (r != null)
                {
                    l.Add(r.Item1);
                    m = r.Item2.Trim();
                    r = parse(r.Item2);
                }
                Semantics.SExp acc = new Semantics.Atom("nil");
                for (int i = l.Count - 1; i >= 0; i--)
                {
                    acc = new Semantics.Cons(l[i], acc);
                }
                return Tuple.Create(acc, m);
            }
            else
            {
                return null;
            }
        }
        public static Tuple<Semantics.SExp, String> parseAtom(String s)
        {
            var t = s.Trim();
            var i = 0;
            if (t.Length > 0 && (t[0] == '(' || t[0] == ')'))
            {
                return null;
            }
            while (t.Length > i && t[i]!=' ' && t[i] != '(' && t[i] != ')')
            {
                i++;
            }
            if (i==0)
            {
                return null;
            }
            Semantics.SExp r = new Semantics.Atom(t.Substring(0, i));
            var m = t.Substring(i);
            return Tuple.Create(r, m);
        }
    }
}
