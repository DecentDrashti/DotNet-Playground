# 🧩 Abstraction, Inheritance, Interface & Method Overriding

---

# 1️⃣ Reference Type vs Object Type

In C#, the **reference type** and the **object type** are not always the same.

```csharp
// Reference Type = Staff
// Object Type = Doctor

Staff s = new Doctor();
```

✅ This is valid.

The object that gets created depends on the **`new` keyword**, not on the reference type.

```text
Reference Type  → Staff
Object Type     → Doctor
```

The actual object created is:

```csharp
new Doctor();
```

---

## Valid Example

```csharp
Staff s = new Doctor();
```

---

## Invalid Example

```csharp
Doctor d = new Staff();
```

❌ Compile-time Error

A parent object **cannot** be assigned to a child reference because a `Staff` is not necessarily a `Doctor`.

---

# 2️⃣ Virtual Method vs Abstract Method

This is one of the most commonly asked interview questions.

---

## Virtual Method

A virtual method provides a **default implementation**.

The child class **may** override it, but it is **not mandatory**.

```csharp
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal Sound");
    }
}
```

Child class overriding the method:

```csharp
class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Bark");
    }
}
```

Another child class without overriding:

```csharp
class Cat : Animal
{
}
```

This is perfectly valid.

Calling:

```csharp
Cat cat = new Cat();
cat.Sound();
```

Output:

```
Animal Sound
```

Because `Cat` simply uses the default implementation from `Animal`.

---

## Abstract Method

An abstract method **does not have a body**.

It only declares what must be implemented.

```csharp
abstract class Employee
{
    public abstract void Work();
}
```

Every child class **must** implement it.

```csharp
class Developer : Employee
{
    public override void Work()
    {
        Console.WriteLine("Writing Code");
    }
}
```

If the child class does not override it, a compile-time error occurs.

---

# 3️⃣ Why do we need `virtual`?

Without `virtual`, overriding is not allowed.

Example:

```csharp
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
```

❌ Compile-time Error

Reason:

The parent method was not marked as `virtual`, so C# does not allow overriding.

---

# 4️⃣ Why use `override` for Abstract Methods but not for Interfaces?

This confuses many beginners.

Let's understand it step by step.

---

## Case 1 — Abstract Class

```csharp
abstract class Animal
{
    public abstract void Sound();
}
```

Although `Sound()` has no implementation, it **belongs to the parent class**.

The parent is saying:

> "I already have a method named `Sound()`. I don't know how it works yet, but every child must replace it."

Child class:

```csharp
class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Bark");
    }
}
```

Here,

`override` means:

> Replace the inherited method.

Visualization:

```text
Animal
│
└── Sound()  (declared but incomplete)

        ↓ override

Dog
│
└── Sound()  (complete implementation)
```

---

## Case 2 — Interface

```csharp
interface INotification
{
    void Send();
}
```

An interface is **not a class**.

It only defines a contract.

It simply says:

> "Every class implementing me must have a `Send()` method."

Implementation:

```csharp
class EmailNotification : INotification
{
    public void Send()
    {
        Console.WriteLine("Email Sent");
    }
}
```

Notice that we **do not use `override`**.

Why?

Because there is nothing to replace.

The interface never provided an implementation.

The class is simply fulfilling the contract.

---

### Real-Life Analogy

Imagine your college has a rule:

> Every student must submit an assignment.

Rahul submits his assignment.

Did Rahul **override** the rule?

❌ No.

He simply **followed** it.

An interface works exactly the same way.

---

# 📌 Summary

| Feature | Virtual Method | Abstract Method | Interface |
|----------|---------------|----------------|-----------|
| Has Implementation | ✅ Yes | ❌ No | ❌ No |
| Can be Used Directly | ✅ Yes | ❌ No | ❌ No |
| Child Must Implement | ❌ No | ✅ Yes | ✅ Yes |
| Uses `override` | ✅ Optional | ✅ Required | ❌ No |
| Purpose | Provide default behavior | Force child classes to provide behavior | Define a contract |

---

# 🎯 Key Takeaways

- `Staff s = new Doctor();` is valid because object creation depends on `new Doctor()`.
- A child reference cannot point to a parent object.
- `virtual` provides a default implementation.
- `abstract` forces child classes to implement the method.
- `override` replaces an inherited method.
- Interfaces define contracts, so classes implement them instead of overriding them.
