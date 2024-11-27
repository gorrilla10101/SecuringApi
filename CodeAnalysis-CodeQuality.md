Given the following:

```csharp
 class Animal
 {
    public virtual string speak(int x) { return "silence"; }
 }

 class Cat : Animal
 {
      public string speak(int x) { return "meow"; }
 }

 class Dog : Animal
 {
      public string speak(short x) { return "bow-wow"; }
 }
```

Question: Explain why the block below does not emit “bow-wow”:
          Animal  d = new Dog(); 
          Console.Write(d.speak(0)); 

This is an example of method hiding. Method hides the base class method if using a derived class. However, if you are treating it as a base type like this it will use the base class implementation. If you want d.speak(0) to say bow-wow you would override the method instead. 

```csharp
 class Dog : Animal
 {
      public string speak(short x) { return "bow-wow"; }
 }
```