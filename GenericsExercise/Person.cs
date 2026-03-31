using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsExercise
{
    public class Person : IEnumerable<Car>, IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Car> Cars { get; set; }

        // Default constructor
        public Person()
        {
            FirstName = "";
            LastName = "";
            Age = 0;
            Cars = new List<Car>();
        }

        // Constructor with parameters
        public Person(string firstName, string lastName, int age, List<Car> cars)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Cars = cars;
        }

        // ToString - returns name, age, and list of cars
        public override string ToString()
        {
            string carList = "";

            if (Cars.Count > 0)
            {
                for (int i = 0; i < Cars.Count; i++)
                {
                    carList += Cars[i].ToString();
                    if (i < Cars.Count - 1)
                        carList += ", ";
                }
            }
            else
            {
                carList = "no cars";
            }

            return FirstName + " " + LastName + ", Age: " + Age + ", Cars: [" + carList + "]";
        }

        // Helper method to calculate total car value
        public decimal GetTotalCarValue()
        {
            decimal total = 0;
            foreach (Car car in Cars)
            {
                total += car.Price;
            }
            return total;
        }

        // IEnumerable<Car> implementation - lets us use foreach on a Person to loop through their cars
        public IEnumerator<Car> GetEnumerator()
        {
            return Cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // IComparable<Person> - compare people by total car value
        public int CompareTo(Person other)
        {
            if (other == null)
                return 1;

            decimal myTotal = GetTotalCarValue();
            decimal otherTotal = other.GetTotalCarValue();

            return myTotal.CompareTo(otherTotal);
        }
    }
}
