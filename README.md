# SExp

a [prose](https://microsoft.github.io/prose/) experiment in learning S-expression manipulations

Organization:

- [SExp/SExp.grammar](SExp/SExp.grammar) the prose grammar for S-Expression manipulations
- [SExp.Semantics/Semantics.cs](SExp.Semantics/Semantics.cs) the prose semantics of the grammar, and the definition of the SExp class and subclasses Cons and Atom
- [SExp.Learning/RankingScore.cs](SExp.Learning/RankingScore.cs) the prose feature for ranking the learned program set
- [SExp.Learning/Learners.cs](SExp.Learning/Learners.cs) the prose witness functions for the inverse semantics
- [SExp/SExpParser.cs](SExp/SExpParser.cs) a parser from string to SExp

This is the current output of the [program](SExp/SExpProgram.cs):
```
1
input:  c     -- Atom(c)
output: (a b) -- Cons(Atom(a), Cons(Atom(b), Atom(nil)))
all programs: {Cons(Symbol("a"), Cons(Symbol("b"), Symbol("nil")))}
best program: Cons(Symbol("a"), Cons(Symbol("b"), Symbol("nil")))
2
input:  (a b) -- Cons(Atom(a), Cons(Atom(b), Atom(nil)))
output: a     -- Atom(a)
all programs: {Select(Car(Input(x))), Symbol("a")}
best program: Select(Car(Input(x)))
3
input:  (a b) -- Cons(Atom(a), Cons(Atom(b), Atom(nil)))
output: a     -- Atom(a)
input:  (a1 b1) -- Cons(Atom(a1), Cons(Atom(b1), Atom(nil)))
output: a1      -- Atom(a1)
all programs: {Select(Car(Input(x)))}
best program: Select(Car(Input(x)))
4
input:  (a b) -- Cons(Atom(a), Cons(Atom(b), Atom(nil)))
output: b     -- Atom(b)
all programs: {Select(Car(Cdr(Input(x)))), Symbol("b")}
best program: Select(Car(Cdr(Input(x))))
5
input:  a     -- Atom(a)
output: (a a) -- Cons(Atom(a), Cons(Atom(a), Atom(nil)))
all programs: {Cons(Select(Input(x)), Cons(Select(Input(x)), Symbol("nil"))), Cons(Select(Input(x)), Cons(Symbol("a"), Symbol("nil"))), Cons(Symbol("a"), Cons(Select(Input(x)), Symbol("nil"))), Cons(Symbol("a"), Cons(Symbol("a"), Symbol("nil")))}
best program: Cons(Select(Input(x)), Cons(Select(Input(x)), Symbol("nil")))
6
input:  (a b)         -- Cons(Atom(a), Cons(Atom(b), Atom(nil)))
output: ((a b) (b a)) -- Cons(Cons(Atom(a), Cons(Atom(b), Atom(nil))), Cons(Cons(Atom(b), Cons(Atom(a), Atom(nil))), Atom(nil)))
input:  (a1 b1)           -- Cons(Atom(a1), Cons(Atom(b1), Atom(nil)))
output: ((a1 b1) (b1 a1)) -- Cons(Cons(Atom(a1), Cons(Atom(b1), Atom(nil))), Cons(Cons(Atom(b1), Cons(Atom(a1), Atom(nil))), Atom(nil)))
all programs: {Cons(Select(Input(x)), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Select(Cdr(Cdr(Input(x)))))), Cons(Select(Input(x)), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Symbol("nil"))), Cons(Select(Input(x)), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Select(Cdr(Cdr(Input(x)))))), Cons(Select(Input(x)), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Symbol("nil"))), Cons(Cons(Select(Car(Input(x))), Select(Cdr(Input(x)))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Input(x))), Select(Cdr(Input(x)))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Symbol("nil"))), Cons(Cons(Select(Car(Input(x))), Select(Cdr(Input(x)))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Input(x))), Select(Cdr(Input(x)))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Symbol("nil"))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Symbol("nil"))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Symbol("nil"))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Symbol("nil"))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Symbol("nil"))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Symbol("nil"))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Symbol("nil"))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Select(Cdr(Cdr(Input(x)))))), Cons(Cons(Select(Car(Input(x))), Cons(Select(Car(Cdr(Input(x)))), Symbol("nil"))), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Symbol("nil"))), Symbol("nil")))}
best program: Cons(Select(Input(x)), Cons(Cons(Select(Car(Cdr(Input(x)))), Cons(Select(Car(Input(x))), Select(Cdr(Cdr(Input(x)))))), Select(Cdr(Cdr(Input(x))))))
```
