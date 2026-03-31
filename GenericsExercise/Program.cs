using System;
using System.Collections.Generic;
using GenericsExercise;

// ========================================
//  PART I - Testing Generic Methods
// ========================================
Console.WriteLine("========================================");
Console.WriteLine("  PART I - Generic Methods");
Console.WriteLine("========================================");
Console.WriteLine();

// --- Method 1: Swap ---
Console.WriteLine("1) Swap:");
int x = 10;
int y = 20;
Console.WriteLine("   Before: x = " + x + ", y = " + y);
GenericMethods.Swap(ref x, ref y);
Console.WriteLine("   After:  x = " + x + ", y = " + y);

string s1 = "Hello";
string s2 = "World";
Console.WriteLine("   Before: s1 = " + s1 + ", s2 = " + s2);
GenericMethods.Swap(ref s1, ref s2);
Console.WriteLine("   After:  s1 = " + s1 + ", s2 = " + s2);
Console.WriteLine();

// --- Method 2: DisplayAndReset ---
Console.WriteLine("2) DisplayAndReset:");
int num = 42;
string text = "Sample";
Console.WriteLine("   Before: num = " + num + ", text = " + text);
GenericMethods.DisplayAndReset(ref num, ref text);
Console.WriteLine("   After:  num = " + num + ", text = " + text);
Console.WriteLine();

// --- Method 3: CreateInstance ---
Console.WriteLine("3) CreateInstance:");
Person newPerson = GenericMethods.CreateInstance<Person>();
Console.WriteLine("   Created Person: " + newPerson);
Console.WriteLine();

// --- Method 4: Max ---
Console.WriteLine("4) Max:");
int bigger = GenericMethods.Max(10, 25);
Console.WriteLine("   Max(10, 25) = " + bigger);
double biggerDouble = GenericMethods.Max(3.7, 1.2);
Console.WriteLine("   Max(3.7, 1.2) = " + biggerDouble);
string biggerString = GenericMethods.Max("apple", "banana");
Console.WriteLine("   Max(apple, banana) = " + biggerString);
Console.WriteLine();

// --- Method 5: SortedList ---
Console.WriteLine("5) SortedList:");
List<int> sortedInts = GenericMethods.SortedList(5, 3, 8, 1, 4);
Console.Write("   Sorted ints: ");
foreach (int i in sortedInts)
    Console.Write(i + " ");
Console.WriteLine();

List<string> sortedStrings = GenericMethods.SortedList("banana", "apple", "cherry", "date");
Console.Write("   Sorted strings: ");
foreach (string s in sortedStrings)
    Console.Write(s + " ");
Console.WriteLine();
Console.WriteLine();

// --- Method 6: CreateDictionary ---
Console.WriteLine("6) CreateDictionary (key=struct, value=class):");
Dictionary<int, string> dict1 = GenericMethods.CreateDictionary(1, "One");
Console.WriteLine("   Created dictionary with entry: [1] = One");

Dictionary<int, Person> dict2 = GenericMethods.CreateDictionary(100, new Person("Alice", "Smith", 25, new List<Car>()));
Console.WriteLine("   Created dictionary with entry: [100] = " + dict2[100]);
Console.WriteLine();

// --- Method 7: DisplayDictionary ---
Console.WriteLine("7) DisplayDictionary:");
dict1.Add(2, "Two");
dict1.Add(3, "Three");
GenericMethods.DisplayDictionary(dict1);
Console.WriteLine();

// --- Method 8: QueueOrStack ---
Console.WriteLine("8) QueueOrStack:");
Console.WriteLine("   With 2 elements:");
IEnumerable<int> result1 = GenericMethods.QueueOrStack(10, 20);
Console.Write("   Elements: ");
foreach (int item in result1)
    Console.Write(item + " ");
Console.WriteLine();

Console.WriteLine("   With 4 elements:");
IEnumerable<int> result2 = GenericMethods.QueueOrStack(10, 20, 30, 40);
Console.Write("   Elements: ");
foreach (int item in result2)
    Console.Write(item + " ");
Console.WriteLine();
Console.WriteLine();

// ========================================
//  PART II - Car & Person Classes
// ========================================
Console.WriteLine("========================================");
Console.WriteLine("  PART II - Car & Person Classes");
Console.WriteLine("========================================");
Console.WriteLine();

// Create some cars
Car car1 = new Car("Toyota", 25000);
Car car2 = new Car("BMW", 55000);
Car car3 = new Car("Honda", 22000);
Car car4 = new Car("Mercedes", 70000);
Car car5 = new Car("Fiat", 15000);

// Create some people
List<Car> carsForAnna = new List<Car>();
carsForAnna.Add(car1);
carsForAnna.Add(car3);

List<Car> carsForJan = new List<Car>();
carsForJan.Add(car2);
carsForJan.Add(car4);

List<Car> carsForMaria = new List<Car>();
carsForMaria.Add(car5);

List<Car> carsForPiotr = new List<Car>();
carsForPiotr.Add(car1);
carsForPiotr.Add(car2);
carsForPiotr.Add(car5);

Person person1 = new Person("Anna", "Kowalska", 30, carsForAnna);
Person person2 = new Person("Jan", "Nowak", 45, carsForJan);
Person person3 = new Person("Maria", "Wisniewska", 28, carsForMaria);
Person person4 = new Person("Piotr", "Zielinski", 35, carsForPiotr);

// Use foreach on one person to show their cars (IEnumerable<Car>)
Console.WriteLine("Cars of " + person2.FirstName + " " + person2.LastName + " (using foreach on Person):");
foreach (Car car in person2)
{
    Console.WriteLine("  - " + car);
}
Console.WriteLine();

// Add all people to a list, sort it, and show results
List<Person> people = new List<Person>();
people.Add(person1);
people.Add(person2);
people.Add(person3);
people.Add(person4);

Console.WriteLine("People before sorting:");
foreach (Person p in people)
    Console.WriteLine("  " + p);

Console.WriteLine();

people.Sort();

Console.WriteLine("People after sorting (by total car value):");
foreach (Person p in people)
    Console.WriteLine("  " + p + " -> Total: " + p.GetTotalCarValue());

Console.WriteLine();

// ========================================
//  PART III - Quadruple Generic Class
// ========================================
Console.WriteLine("========================================");
Console.WriteLine("  PART III - Quadruple Generic Class");
Console.WriteLine("========================================");
Console.WriteLine();

// Create a list of Quadruples
List<Quadruple<int, string, double, bool>> quadruples = new List<Quadruple<int, string, double, bool>>();
quadruples.Add(new Quadruple<int, string, double, bool>(3, "Charlie", 7.5, true));
quadruples.Add(new Quadruple<int, string, double, bool>(1, "Alice", 9.2, false));
quadruples.Add(new Quadruple<int, string, double, bool>(4, "David", 5.1, true));
quadruples.Add(new Quadruple<int, string, double, bool>(2, "Bob", 8.0, false));

Console.WriteLine("Quadruples before sorting:");
foreach (Quadruple<int, string, double, bool> q in quadruples)
    Console.WriteLine("  " + q);

Console.WriteLine();

// Sort and display
quadruples.Sort();

Console.WriteLine("Quadruples after sorting (by first field - ID):");
foreach (Quadruple<int, string, double, bool> q in quadruples)
    Console.WriteLine("  " + q);

Console.WriteLine();

// Test Equals and GetHashCode
Quadruple<int, string, double, bool> q1 = new Quadruple<int, string, double, bool>(1, "Test", 3.14, true);
Quadruple<int, string, double, bool> q2 = new Quadruple<int, string, double, bool>(1, "Test", 3.14, true);
Quadruple<int, string, double, bool> q3 = new Quadruple<int, string, double, bool>(2, "Other", 2.71, false);

Console.WriteLine("Equals and GetHashCode tests:");
Console.WriteLine("  q1 = " + q1);
Console.WriteLine("  q2 = " + q2);
Console.WriteLine("  q3 = " + q3);
Console.WriteLine("  q1.Equals(q2) = " + q1.Equals(q2));
Console.WriteLine("  q1.Equals(q3) = " + q1.Equals(q3));
Console.WriteLine("  q1.GetHashCode() == q2.GetHashCode(): " + (q1.GetHashCode() == q2.GetHashCode()));

Console.WriteLine();
Console.WriteLine("Press Enter to exit...");
Console.ReadLine();
