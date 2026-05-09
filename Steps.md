# Steps to create an Api work flow:
## Approach 1: Database first approach 
### Step1: create a database 

### Step2: create a web api project in visual studio with following steps: </br>
&nbsp;&nbsp; 1. Open visual studio and click on Create a new project.</br>
&nbsp;&nbsp; 2. Search for ASP.NET Core Web Api and select it. </br>
&nbsp;&nbsp; 3. Change you project name and location according to requirement and tick the checkbox of place the solution and and project in the same directory.</br>
&nbsp;&nbsp; 4. check the .net long term support version tick -the configure on the https  -enable openAi - use controller </br>

### Step3: delete weather forecasting controller all related to weather forecasting naming 
### Step4: install required packages:
&nbsp;&nbsp; 1. go to tools>>nuget package manager>>manage nuget package for solution.</br>
&nbsp;&nbsp; 2. download this according to your version of .net</br> 
&nbsp;&nbsp;&nbsp;&nbsp;• Microsoft.EntityFrameWorkCore</br>
&nbsp;&nbsp;&nbsp;&nbsp;• Microsoft.EntityFrameWorkCore.SqlServer</br>
&nbsp;&nbsp;&nbsp;&nbsp;• Microsoft.EntityFrameWorkCore.Tools</br>
### Step5: go to tools>>nuget package manager>>package manager console 
### Step6: run the command 
    Scaffold-DbContext "server=servername; database=databasename; 
    trusted_connection=true; TrustServerCertificate=True;" 
    Microsoft.EntityFrameworkCore.SqlServer-OutputDir Model
#### if not working 
    Scaffold-DbContext "server=Naimish; database=NRVDemo; 
    trusted_connection=true; TrustServerCertificate=True;" 
    Microsoft.EntityFrameworkCore.SqlServer-OutputDir Models -Force
