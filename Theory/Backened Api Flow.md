## What Happens When API Is Called?

#### This mental flow is EVERYTHING.

```text
Client sends HTTP request
           ↓
Controller receives request
           ↓
Method executes
           ↓
Database operation happens
           ↓
Response returned
           ↓
Swagger/Postman displays response
```

---

### Now let's understand how the code works:

#### 1. First thing we probably have something like this in controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

}
```

---

## `[ApiController]`

This tells ASP.NET:

> "This class behaves like a Web API controller."

Without it:

- API features don't work properly
- Validation support becomes weaker
- Automatic behaviors are missing

---

## `[Route("api/[controller]")]`

This defines the URL pattern.

Example:

```text
UsersController
```

becomes:

```text
api/users
```

Because:

```text
[controller]
```

automatically replaces:

```text
Users
```

---

## `ControllerBase`

This gives API-related helper features like:

- `Ok()`
- `BadRequest()`
- `NotFound()`

Without inheriting from `ControllerBase`:

these helper methods become unavailable.

## Now Real API Method

Suppose:

```csharp
[HttpGet]
public IActionResult GetUsers()
{
    return Ok("Users fetched successfully");
}
```

---

## `[HttpGet]`

This means:

> "This method handles GET requests."

---

## `IActionResult`

VERY IMPORTANT.

This means:

> "This method returns HTTP response."

---

## Why Not Return String Directly?

BAD:

```csharp
return "Hello";
```

GOOD:

```csharp
return Ok("Hello");
```

Because APIs should return:

- proper HTTP responses
- proper status codes

---

## `return Ok()`

This returns:

```text
200 OK
```

Meaning:

```text
request successful.
```

---

## API Execution Flow

```text
Swagger sends GET request
          ↓
Controller receives request
          ↓
GetUsers() executes
          ↓
Ok() response returned
          ↓
Swagger shows result
```
