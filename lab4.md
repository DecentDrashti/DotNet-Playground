# Lab No. 04 | Inheritance, Abstraction and Interface in C#

## Objective

To understand how Inheritance, Abstraction, and Interfaces help us build reusable, maintainable, and scalable applications in C#.

---

# Why Are We Doing This Lab?

### What?

In this lab, we will learn three important Object-Oriented Programming concepts:

- Inheritance
- Abstraction
- Interface

---

### Why?

Imagine building a College Management System.

Without OOP principles:

- Code gets repeated
- Maintenance becomes difficult
- Adding new features becomes harder

These concepts help us:

- Reuse existing code
- Hide unnecessary details
- Define common behavior for multiple classes

---

### When?

These concepts are used in almost every real-world application:

- Banking Systems
- E-Commerce Applications
- Hospital Management Systems
- College ERP Systems
- Mobile Applications

---

### How?

We will create:

```text
           Person
              │
      ┌───────┴───────┐
      │               │
      ▼               ▼
   Student         Faculty
```

to understand inheritance,

then use abstraction and interfaces to build cleaner designs.

---

# Concept Overview

## Key Concepts

- Inheritance
- Abstraction
- Interface
- Base Class
- Derived Class
- Abstract Class
- Method Overriding

---

# Quick Theory

## Inheritance

-Inheritance establishes an "IS-A" relationship between classes, allowing a child class to inherit common properties and behaviors from a parent class while adding its own specialized features.

-Instead of rewriting common properties and methods, a child class can inherit them from a parent class and focus only on its own unique functionality.

### Formula

```text
Person
   │
   ▼
Student
```

Example:

```text
Student IS-A Person
```

```text
            Person
               │
    ┌──────────┴──────────┐
    │                     │
 Student             Faculty
```

Both Student and Faculty inherit common properties from Person.

## Implementation of inheritance 

### Step 1: Create Base Class

```csharp
public class Person
{
    public string Name;
    public int Age;

    public void DisplayPerson()
    {
        Console.WriteLine("Name : " + Name);
        Console.WriteLine("Age  : " + Age);
    }
}
```

### Explanation

Person contains common information shared by all people.

---

### Step 2: Create Derived Class

```csharp
public class Student : Person
{
    public int RollNo;
}
```

### Explanation

Student automatically receives:

- Name
- Age
- DisplayPerson()

from Person.

This is code reusability.

---

### Inheritance Flow

```text
Person Created
      ↓
Student Inherits Person
      ↓
Student Gets Name
      ↓
Student Gets Age
      ↓
Student Gets DisplayPerson()
```


# Types of Inheritance

Inheritance can be categorized into different types based on how classes are related to each other.


![image of inhertance](image.png)

---

## 1. Single Inheritance

A single child class inherits from a single parent class.

### Diagram

```text
Person
   │
   ▼
Student
```

### Example

```csharp
public class Person
{
    public string Name { get; set; }
}

public class Student : Person
{
    public int RollNo { get; set; }
}
```

### Explanation

- `Student` inherits from `Person`.
- `Student` can access all public and protected members of `Person`.
- Promotes code reusability.

---

## 2. Multi-Level Inheritance

A child class inherits from another child class.

### Diagram

```text
Person
   │
   ▼
Student
   │
   ▼
Monitor
```

### Example

```csharp
public class Person
{
    public string Name { get; set; }
}

public class Student : Person
{
    public int RollNo { get; set; }
}

public class Monitor : Student
{
    public string Section { get; set; }
}
```

### Explanation

- `Student` inherits from `Person`.
- `Monitor` inherits from `Student`.
- `Monitor` gets features from both `Student` and `Person`.

---

## 3. Hierarchical Inheritance

Multiple child classes inherit from the same parent class.

### Diagram

```text
           Person
              │
      ┌───────┴───────┐
      │               │
      ▼               ▼
   Student         Faculty
```

### Example

```csharp
public class Person
{
    public string Name { get; set; }
}

public class Student : Person
{
    public int RollNo { get; set; }
}

public class Faculty : Person
{
    public int EmployeeId { get; set; }
}
```

### Explanation

- Both `Student` and `Faculty` inherit from `Person`.
- Common functionality is defined once inside the parent class.
- Reduces code duplication.

---

## 4. Multiple Inheritance

Multiple inheritance means a class inherits from more than one parent class.

### Diagram

```text
Class A      Class B
    \           /
     \         /
      \       /
       Class C
```

### Example

```csharp
class A
{
}

class B
{
}

class C : A, B
{
}
```

### Explanation

- Multiple inheritance through classes is **not supported in C#**.
- C# avoids ambiguity problems that can occur when multiple parent classes contain members with the same name.

---

## Multiple Inheritance Using Interfaces

Although C# does not support multiple inheritance with classes, it supports it through interfaces.
Interface: An Interface defines a set of rules that a class must follow

---

# 5. Hybrid Inheritance

Hybrid Inheritance is a combination of two or more inheritance types.

For example, a hierarchy may combine:

* Hierarchical Inheritance
* Multi-Level Inheritance

into a single structure.

---

## Diagram

```text
           Person
              │
      ┌───────┴───────┐
      │               │
      ▼               ▼
   Student         Faculty
      │
      ▼
   Monitor
```

---

## Explanation

In this example:

```text
Person → Student
Person → Faculty
```

represents **Hierarchical Inheritance**.

And:

```text
Person → Student → Monitor
```

represents **Multi-Level Inheritance**.

Since multiple inheritance structures are combined together, this is called **Hybrid Inheritance**.

---

## Why Hybrid Inheritance is Important

Hybrid Inheritance helps model complex real-world relationships where a single inheritance structure is not sufficient.

It allows classes to benefit from features of different inheritance hierarchies while maintaining code reusability and organization.

---

## Hybrid Inheritance in C#

C# does **not support Hybrid Inheritance through classes** because it does not support Multiple Inheritance between classes.

Consider the following structure:

```text
       A
      / \
     B   C
      \ /
       D
```

This can create ambiguity when both `B` and `C` contain methods with the same name.

This problem is known as the:

```text
Diamond Problem
```

Because of this, C# prevents Multiple and Hybrid Inheritance through classes.

---

## How C# Achieves Hybrid Inheritance

C# achieves Hybrid Inheritance using Interfaces(An Interface defines a set of rules that a class must follow).

---

## Summary

| Feature                            | Hybrid Inheritance                                      |
| ---------------------------------- | ------------------------------------------------------- |
| Definition                         | Combination of two or more inheritance types            |
| Example                            | Hierarchical + Multi-Level                              |
| Supported Through Classes in C#    | ❌ No                                                    |
| Supported Through Interfaces in C# | ✅ Yes                                                   |
| Main Benefit                       | Models complex relationships while promoting code reuse |


# Quick Summary

| Type | Description |
|--------|--------|
| Single Inheritance | One parent class and one child class |
| Multi-Level Inheritance | Parent → Child → Grandchild |
| Hierarchical Inheritance | One parent class inherited by multiple child classes |
| Multiple Inheritance | Multiple parent classes inherited by one child class (Not supported through classes in C#) |
| Hybrid Inheritance | Combination of two or more inheritance types (Not supported through classes in C#) |

> **Note:** C# supports Single, Multi-Level, and Hierarchical Inheritance through classes. Multiple and Hybrid Inheritance are achieved using Interfaces instead of classes.

---

# Memory Trick

```text
Single
One → One

Multi-Level
One → One → One

Hierarchical
One → Many

Multiple
Many → One
```

---

## Abstraction

-Abstraction allows users to focus on what an object can do rather than how it does it internally. It does not remove the details; it simply keeps unnecessary details away from users who do not need to interact with them.

-In other words, Abstraction allows us to focus on essential features while separating the internal implementation details.
It does not eliminate or remove the details. Instead, it exposes only what is relevant to the user and keeps unnecessary implementation details out of sight.

Example:

```text
ATM Machine

You know:
✔ Withdraw Money
✔ Check Balance

You do not know:
✖ Internal Banking Logic
✖ Database Queries
```

```text
Car

You know:
✔ Start()
✔ Stop()

You don't know:
✖ Engine Combustion Process
✖ Fuel Injection Logic
```


## implementation:

## Create Abstract Class

```csharp
public abstract class Employee
{
    public abstract void CalculateSalary();
}
```

---

## Derived Class

```csharp
public class Faculty : Employee
{
    public override void CalculateSalary()
    {
        Console.WriteLine("Faculty Salary Calculated");
    }
}
```

---

## Explanation

Employee says:

```text
Every Employee MUST calculate salary.
```

But Employee does not know how.

Faculty provides the implementation.

---

## Abstraction Flow

```text
Employee
(Abstract Class)
       ↓
Declares Method
       ↓
Faculty
       ↓
Provides Logic
```

---

## Interface

An Interface defines a set of rules that a class must follow.

It specifies what actions a class must perform, but it does not define how those actions should be implemented.

Any class that implements an interface must provide its own implementation for all the members defined by that interface.

This promotes:

- Loose Coupling
- Flexibility
- Consistency
- Scalability

An Interface focuses on:

WHAT should be done

not

HOW it should be done


```text
Payment Interface

      IPayment
           │
 ┌─────────┴─────────┐
 │                   │
UPI Payment    Card Payment
```

Every payment method must implement:

```text
Pay()
```
but implementation can differ.

## implementation

## Create Interface

```csharp
public interface ILogin
{
    void Login();
}
```

---

## Implement Interface

```csharp
public class Student : ILogin
{
    public void Login()
    {
        Console.WriteLine("Student Login Successful");
    }
}
```

---

## Explanation

Interface creates a contract.

It forces every class implementing it to define:

```csharp
Login()
```

---

## Interface Flow

```text
ILogin
   ↓
Defines Login()
   ↓
Student Implements Interface
   ↓
Student Provides Login Logic
```

# Program Output

```text
Name : Rahul
Age  : 20

Faculty Salary Calculated

Student Login Successful
```
---


## implementation of multiple inheritance using interface
### Example

```csharp
public interface ILogin
{
    void Login();
}

public interface IRegister
{
    void Register();
}

public class User : ILogin, IRegister
{
    public void Login()
    {
        Console.WriteLine("Login Successful");
    }

    public void Register()
    {
        Console.WriteLine("Registration Successful");
    }
}
```

### Explanation

- A class can implement multiple interfaces.
- This provides flexibility without the problems associated with multiple class inheritance.

---

## implementation of hierary inheritance using interface 
### Example

```csharp
public interface ILogin
{
    void Login();
}

public interface IReport
{
    void GenerateReport();
}

public class User : ILogin, IReport
{
    public void Login()
    {
        Console.WriteLine("Login Successful");
    }

    public void GenerateReport()
    {
        Console.WriteLine("Report Generated");
    }
}
```

In this example:

* `User` implements multiple interfaces.
* This provides flexibility similar to Hybrid Inheritance.
* Ambiguity issues are avoided.
---

# Class Hierarchy Diagram

```text
                     +----------------+
                     |    Person      |
                     +----------------+
                     | Name           |
                     | Age            |
                     +----------------+
                              ▲
                              |
          +-------------------+------------------+
          |                                      |
          ▼                                      ▼

    +-------------+                     +-------------+
    |  Student    |                     |   Faculty   |
    +-------------+                     +-------------+
    | RollNo      |                     | EmployeeID  |
    +-------------+                     +-------------+

```

# Full Concept Comparison

| Feature             | Inheritance| Abstraction         | Interface       |
|---------------------|------------|---------------------|-----------------|
| Purpose             | Reuse Code | Hide Implementation | Define Contract |
| Keyword             | :          | abstract            | interface       |
| Method Body Allowed | Yes        | Partial             | No              |
| Constructor Allowed | Yes        | Yes                 | No              |
| Multiple Support    | No         | No                  | Yes             |

---

# Lab Task

# Lab Questions

## Question 1 (Inheritance)

Create a base class `Staff` and a derived class `Doctor` to calculate total salary based on a basic pay and specialized doctor allowances.

---

## Question 2 (Abstraction)

Create an abstract class `Billing` with an abstract method `CalculateBill()`.

Implement this in:

- `InPatientBilling`
- `OutPatientBilling`

classes.

---

## Question 3 (Interface)

Create an interface `INotificationService` and implement it across:

- `EmailNotification`
- `SMSNotification`

modules.

---

## Question 4 (Inheritance)

Create a base class `MedicalEquipment` and a derived class `DiagnosticScanner` to calculate maintenance costs based on a baseline service fee and specialized calibration allowances.

---

## Question 5 (Abstraction)

Create an abstract class `PatientRecord` with an abstract method `CompileReport()`.

Implement this in:

- `InpatientMedicalRecord`
- `OutpatientMedicalRecord`

classes.

---

## Question 6 (Interface + Exception Handling)

Create an interface `IInventoryManager` and implement it across:

- `GroceryStock`
- `ElectronicStock`

modules.

Use exception handling to manage:

- Stock shortages
- Incorrect product details

---

# Common Errors

| Error                                | Cause                             | Solution                      |
|--------------------------------------|-----------------------------------|-------------------------------|
| Cannot instantiate abstract class    | Creating object of abstract class | Create derived class object   |
| Does not implement interface member  | Missing method implementation     | Implement all interface methods|
| Inheritance syntax error             | Missing ':'                       | Use ':' operator |
| No suitable method found to override | Method not marked correctly       | Use abstract/virtual keyword |

---

# Student Exercise

1. Create Vehicle → Car inheritance.
2. Create Animal → Dog inheritance.
3. Create abstract Shape class and implement Circle.
4. Create IBankAccount interface and implement SavingsAccount.
5. Create INotification interface and implement EmailNotification.

---
# One-Line Revision

```text
Inheritance → Reuse Code

Abstraction → Hide Complexity

Interface → Define Rules
```