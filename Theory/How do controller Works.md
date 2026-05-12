# How Controller Works — Dependency Injection (DI)

## Dependency Injection (DI)

This single concept exists EVERYWHERE in .NET.
Dependency Injection (DI) is a design pattern that helps achieve loose coupling between classes by injecting dependencies from external sources rather than creating them within the class. This makes the code more modular, testable, and maintainable.

---

## Typical Controller Setup

```csharp
#region Configuration Fields 
private readonly EmployeeManagementDbContext _context;

public UserApiController(EmployeeManagementDbContext context)
{
    _context = context;
}
#endregion
```

---

# Why Is This Needed?

Your controller needs database access.

Question is:

> "How does controller get access to database?"

Answer:

Through `DbContext` object.

That object is:

```csharp
_context
```

---

# What Is `DatabaseNameDbContext`?
(EmployementManagementDbContext in our reference)

It is the bridge between:

```text
ASP.NET Core
AND
SQL Server
```

---

# Understanding This Line

```csharp
private readonly EmployeeManagementDbContext _context;
```

This creates a variable inside controller.

Meaning:

> "This controller has database connection object called `_context`"

---

## Why `private`?

```csharp
private readonly EmployeeManagementDbContext _context;
```

Only this controller should use it.

---

## Why `readonly`?

Means:

> "Once assigned, value cannot change."

Good practice.

---

## Why `_context` Name?

Convention in C#:

private fields often start with `_`

Examples:

```csharp
_context
_service
_repository
_logger
```

---

## Constructor Injection

```csharp
public UserApiController(EmployeeManagementDbContext context)
{
    _context = context;
}
```

This is:

### Constructor Injection

---

# WHAT IS HAPPENING HERE?

ASP.NET Core automatically creates:

```text
EmployeeManagementDbContext
```

and gives it to controller.

This is called:

# Dependency Injection

---

# Simple Analogy

Imagine:

Teacher needs marker.

Instead of teacher buying marker manually every lecture,
college provides marker automatically.

That is Dependency Injection 😄

---

# Real Backend Meaning

Instead of controller creating database object itself:

## BAD

```csharp
var context = new EmployeeManagementDbContext();
```

## GOOD

```text
Framework manages object creation
```

ASP.NET Core provides it automatically.

---

# WHY THIS IS IMPORTANT

Because manually creating objects everywhere causes:

- messy code
- memory issues
- tight coupling
- difficult testing

DI solves this.

---

# IMPORTANT UNDERSTANDING

Many beginners think:

> "This runs before every method."

Actually:

It is NOT before every method.

It is:

```text
once inside controller
```

Then ALL methods can use `_context`.

---

# THIS IS VERY IMPORTANT CONCEPTUALLY

Controller methods need:

- database access
- services
- logger
- authentication helpers

Instead of creating them manually,
ASP.NET injects them automatically.

---

# .NET Framework Handles Many Things Automatically

```text
object creation
lifecycle
memory handling
```

---

# Why Does This Work?

Because somewhere in:

```text
Program.cs
```

you registered `DbContext`.

Probably like:

```csharp
builder.Services.AddDbContext<EmployeeManagementDbContext>(options =>
    options.UseSqlServer(connectionString));
```

---

# What Does This Line Mean?

This line tells ASP.NET:

> "Whenever someone asks for `EmployeeManagementDbContext`, provide it automatically."

VERY important.

This is:

# Dependency Management

---

# FULL FLOW TO UNDERSTAND DI

## Step 1

`Program.cs` registers service.

```csharp
AddDbContext()
```

---

## Step 2

Controller asks for it in constructor.

```csharp
UserApiController(EmployeeManagementDbContext context)
```

---

## Step 3

ASP.NET injects object automatically.

---

## Step 4

Controller stores it.

```csharp
_context = context;
```

---

## Step 5

Methods use `_context`.

---

# THIS IS CALLED

# Constructor Dependency Injection

Most common DI style in .NET.

---

# Real-Life Analogy

Restaurant waiter needs order machine.

Restaurant management provides machine automatically.

Waiter does not manufacture machine every time 😭

---

# VERY IMPORTANT QUESTION

## Question

> "Why Dependency Injection?"

---

## Best Beginner Answer

> "Dependency Injection helps manage objects efficiently and reduces tight coupling by providing required dependencies automatically."
