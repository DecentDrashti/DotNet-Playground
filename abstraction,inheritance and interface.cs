// Reference Type = Staff
// Object Type = Doctor
Staff s = new Doctor();
// valid 
// The object created is Doctor because object creation always depends on:

// new Doctor()

// not on the reference type.
//Valid:

Staff s = new Doctor();

//Invalid:

Doctor d = new Staff();

// Difference Between Abstract Method and Virtual Method

// This is one of the most important interview questions.

// Virtual Method

// Parent gives a default implementation.

class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal Sound");
    }
}

// Child MAY override.

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Bark");
    }
}

// But child is not forced.

class Cat : Animal
{
}

// This is perfectly fine.

// Cat will inherit:

// Animal Sound

// Abstract:

abstract class Employee
{
    public abstract void Work();
}

// Child must override.

// Why virtual + override?

// Without virtual:

class Animal
{
    public void Sound()
    {
    }
}
class Dog : Animal
{
    public override void Sound()
    {
    }
}

// Compile Error.

// Because parent did not allow overriding.

interface INotification{
  class EmailNotification : INotification
{
    public void Send()
    {
        Console.WriteLine("Email Sent");
    }
}


"If abstract methods also have no body, then why do we use override there but not in interfaces?"

The answer lies in who owns the method.

Case 1: Abstract Class
abstract class Animal
{
    public abstract void Sound();
}

Look carefully.

Even though:

Sound()

has no body,

it still belongs to the class:

Animal

The parent class is saying:

"I already have a method called Sound(). I don't know how it works, but it exists."

Now child class:

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Bark");
    }
}

Why override?

Because Dog is replacing the incomplete version inherited from Animal.

Think:

Animal
└── Sound() ← exists but incomplete

Dog
└── Sound() ← replaces parent's version

So:

override = replace inherited method
Case 2: Interface
interface INotification
{
    void Send();
}

Interface is not a class.

It doesn't give inheritance of implementation.

It only gives a rule.

Think:

INotification says:

Every class must have Send()

That's all.

Now:

class EmailNotification : INotification
{
    public void Send()
    {
        Console.WriteLine("Email Sent");
    }
}

Here EmailNotification is not replacing anything.

It is simply fulfilling a contract.

Think:

College Rule:
Every student must submit assignment.

Rahul submits assignment.

Did Rahul override the rule?

No.

He followed it.
    void Send();
}

