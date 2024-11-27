```csharp
Given the following:
 class A
 {
     public int a { get; set; }
     public int b { get; set; }
}

class B
{
    public const A a;  
    public B()  { a.a = 10; }
}

int main()
{
    B b = new B();
    Console.WriteLine("%d %d\n", b.a.a, b.a.b);
    return 0;
}

```

Question: Outline any issues/concerns with the implemented code.

1. Single character names are hard to read, provide no information and lead to bugs
2. Property names should be upper cased following common naming conventions
3. You can't have a const of A because it's a class
4. a is never initialized so creating an intance of class B will throw an exception. 
5. There's no reason to use \n because writeline appends it anwyways
6. %d is not how you format in C# it would be $"{b.a.a} {b.a.b}" if you wanted to use string interpolation. 
