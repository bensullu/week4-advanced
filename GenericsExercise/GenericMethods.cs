using System;
using System.Collections.Generic;

namespace GenericsExercise
{
    public static class GenericMethods
    {
        // 1) Swap two values of the same type using ref
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // 2) Display type names and values, then assign default values
        public static void DisplayAndReset<T1, T2>(ref T1 param1, ref T2 param2)
        {
            Console.WriteLine("  Type of param1: " + param1.GetType().Name + ", Value: " + param1.ToString());
            Console.WriteLine("  Type of param2: " + param2.GetType().Name + ", Value: " + param2.ToString());

            param1 = default(T1);
            param2 = default(T2);

            Console.WriteLine("  After default -> param1: " + param1 + ", param2: " + param2);
        }

        // 3) Create and return a new object of the given type (needs parameterless constructor)
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        // 4) Return the larger of two values (type must implement IComparable<T>)
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) >= 0)
                return a;
            else
                return b;
        }

        // 5) Take any number of params, return a sorted list
        public static List<T> SortedList<T>(params T[] items) where T : IComparable<T>
        {
            List<T> list = new List<T>(items);
            list.Sort();
            return list;
        }

        // 6) Create a dictionary (key must be struct, value must be class), add one entry, return it
        public static Dictionary<TKey, TValue> CreateDictionary<TKey, TValue>(TKey key, TValue value)
            where TKey : struct
            where TValue : class
        {
            Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            dict.Add(key, value);
            return dict;
        }

        // 7) Display all keys and values of a dictionary
        public static void DisplayDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict) where TKey : notnull
        {
            foreach (KeyValuePair<TKey, TValue> entry in dict)
            {
                Console.WriteLine("  Key: " + entry.Key + ", Value: " + entry.Value);
            }
        }

        // 8) If less than 3 params -> return Queue, if 3 or more -> return Stack
        //    Return type is IEnumerable<T>
        public static IEnumerable<T> QueueOrStack<T>(params T[] items)
        {
            if (items.Length < 3)
            {
                Queue<T> queue = new Queue<T>();
                foreach (T item in items)
                {
                    queue.Enqueue(item);
                }
                Console.WriteLine("  (Returned a Queue)");
                return queue;
            }
            else
            {
                Stack<T> stack = new Stack<T>();
                foreach (T item in items)
                {
                    stack.Push(item);
                }
                Console.WriteLine("  (Returned a Stack)");
                return stack;
            }
        }
    }
}
