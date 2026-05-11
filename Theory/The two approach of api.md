## The Two Ways in Which API Has Been Created

### 1. Database First Approach

```text
Create database first
          ↓
Tables already exist
          ↓
Generate models from database through scaffold command 
```

#### When to Use

- Company already has a database
- Working with old/legacy systems
- DBA team manages the database

---

### 2. Code First Approach

```text
Create C# models first
          ↓
EF Core creates database automatically through the add migration command
```

#### When to Use

- New projects
- Rapid development
- Startup projects
- Cleaner developer workflow
  
