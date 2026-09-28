//register
public class RegisterDto
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}

//controller
[HttpPost("register")]
public async Task<IActionResult> Register(RegisterDto dto)
{
    var user = new User
    {
        Name = dto.Name,
        Email = dto.Email,
        Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
        Role = "Employee"
    };

    _context.Users.Add(user);

    await _context.SaveChangesAsync();

    return Ok(new
    {
        message = "User registered successfully"
    });
}
//login
var user = await _context.Users
    .FirstOrDefaultAsync(u => u.Email == dto.Email);

if (user == null)
{
    return Unauthorized("Invalid email or password");
}

bool validPassword =
    BCrypt.Net.BCrypt.Verify(
        dto.Password,//api
        user.PasswordHash//database
    );
if (!validPassword)
{
    return Unauthorized("Invalid email or password");
}

private string GenerateToken(User user)
{
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),//This part connects JWT with authorization.
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
    );

    var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256
    );

    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}
//So a conceptual JWT payload could contain:

// {
//   "name": "Rahul",
//   "email": "rahul@gmail.com",
//   "role": "Admin"
// }

//appsetting.json
{
  "Jwt": {
    "Key": "THIS_IS_A_LONG_RANDOM_SECRET_KEY_FOR_DEMO_ONLY",
    "Issuer": "EmployeeManagementAPI",
    "Audience": "EmployeeManagementClient"
  }
}

//program.cs

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, _, _) =>
    {
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();

        document.Components.SecuritySchemes["BearerAuth"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,//The authentication mechanism is based on HTTP authentication.
            Scheme = "bearer",
            In = ParameterLocation.Header,
            BearerFormat = "JWT",
            Name = "Authorization",
            Description = "Enter JWT token"
        };

        var bearerReference = new OpenApiSecuritySchemeReference("BearerAuth", document);
        document.Security =//This tells OpenAPI:This API requires the Bearer authentication scheme.
        [
            new OpenApiSecurityRequirement
            {
                [bearerReference] = []  //This means that the BearerAuth scheme is required, but no specific scopes are needed.
            }
        ];

        return System.Threading.Tasks.Task.CompletedTask;
    });

    options.AddScalarTransformers();//This configures Scalar transformers/integration for the generated OpenAPI document.
});

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]!
                )
            )
        };
});

//dont forget middleware 
app.UseAuthentication();
app.UseAuthorization();

And order matters:


//Protect an API

Now take an existing endpoint:

[HttpGet]
[Authorize]
public async Task<IActionResult> GetEmployees()
{
    var employees = await _context.Employees.ToListAsync();

    return Ok(employees);
}

[Authorize(Roles = "Admin")]
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteUser(int id)
{
    // delete user
}



//password migration
public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

   //public string Password { get; set; }

    public string PasswordHash { get; set; }//for storing hashed password

    public string Role { get; set; }
}
//AuthController
[HttpPost("migrate-passwords")]
public async Task<IActionResult> MigratePasswords()
{
    var users = await _context.Users.ToListAsync();

    foreach (var user in users)
    {
        user.PasswordHash =
            BCrypt.Net.BCrypt.HashPassword(user.Password);
    }

    await _context.SaveChangesAsync();

    return Ok("Passwords migrated successfully.");
}
//POST /api/Auth/migrate-passwords
//remove password column from database after migration and update the User model to remove the Password property.