using System;
namespace SExp.Semantics
{
    public class SExp
    {
        
    }
    public class Cons : SExp
    {
        public readonly SExp Car;
        public readonly SExp Cdr;
        public Cons(SExp Car, SExp Cdr)
        {
            this.Car = Car;
            this.Cdr = Cdr;
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Cons e = (Cons)obj;
                return (Car.Equals(e.Car)) && (Cdr.Equals(e.Cdr));
            }
        }
        public override int GetHashCode()
        {
            return (Car.GetHashCode() << 2) ^ Cdr.GetHashCode();
        }
        public override string ToString()
        {
            return String.Format("Cons({0}, {1})", Car, Cdr);
        }
    }
    public class Atom : SExp
    {
        public readonly object Value;
        public Atom(object Value)
        {
            this.Value = Value;
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Atom a = (Atom)obj;
                return (Value.Equals(a.Value));
            }
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return String.Format("Atom({0})", Value);
        }
    }
    public static class Semantics
    {
        // Your semantics implementations here
        public static SExp Cons(SExp a, SExp d) => new Cons(a, d);
        public static SExp Car(SExp e)
        {
            Cons c =  e as Cons;
            if (c == null)
            {
                return null;
            }
            return c.Car;
        }
        public static SExp Cdr(SExp e)
        {
            Cons c = e as Cons;
            if (c == null)
            {
                return null;
            }
            return c.Cdr;
        }
        public static SExp Symbol(string s) => new Atom(s);
        public static SExp Input(SExp x) => x;
        public static SExp Select(SExp x) => x;
    }
}
