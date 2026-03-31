using System;
using System.Collections.Generic;

namespace GenericsExercise
{
    // Generic class with 4 different type parameters
    // First field is the identifier, used for sorting
    public class Quadruple<T1, T2, T3, T4> : IComparable<Quadruple<T1, T2, T3, T4>>
        where T1 : IComparable<T1>
    {
        // Four private fields
        private T1 _first;
        private T2 _second;
        private T3 _third;
        private T4 _fourth;

        // Properties
        public T1 First
        {
            get { return _first; }
            set { _first = value; }
        }

        public T2 Second
        {
            get { return _second; }
            set { _second = value; }
        }

        public T3 Third
        {
            get { return _third; }
            set { _third = value; }
        }

        public T4 Fourth
        {
            get { return _fourth; }
            set { _fourth = value; }
        }

        // Parameterless constructor
        public Quadruple()
        {
            _first = default(T1);
            _second = default(T2);
            _third = default(T3);
            _fourth = default(T4);
        }

        // Constructor with four parameters
        public Quadruple(T1 first, T2 second, T3 third, T4 fourth)
        {
            _first = first;
            _second = second;
            _third = third;
            _fourth = fourth;
        }

        public override string ToString()
        {
            return "(" + _first + ", " + _second + ", " + _third + ", " + _fourth + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Quadruple<T1, T2, T3, T4> other)
            {
                bool firstEqual = (_first == null && other._first == null) ||
                                  (_first != null && _first.Equals(other._first));
                bool secondEqual = (_second == null && other._second == null) ||
                                   (_second != null && _second.Equals(other._second));
                bool thirdEqual = (_third == null && other._third == null) ||
                                  (_third != null && _third.Equals(other._third));
                bool fourthEqual = (_fourth == null && other._fourth == null) ||
                                   (_fourth != null && _fourth.Equals(other._fourth));

                return firstEqual && secondEqual && thirdEqual && fourthEqual;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            if (_first != null) hash = hash * 31 + _first.GetHashCode();
            if (_second != null) hash = hash * 31 + _second.GetHashCode();
            if (_third != null) hash = hash * 31 + _third.GetHashCode();
            if (_fourth != null) hash = hash * 31 + _fourth.GetHashCode();
            return hash;
        }

        // Compare by first field (the identifier)
        public int CompareTo(Quadruple<T1, T2, T3, T4> other)
        {
            if (other == null)
                return 1;

            return _first.CompareTo(other._first);
        }
    }
}
