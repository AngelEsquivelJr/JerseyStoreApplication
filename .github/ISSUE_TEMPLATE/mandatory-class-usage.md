---
name: Mandatory Class Usage
about: Mandatory Class Usage
title: ''
labels: ''
assignees: ''

---

# Mandatory Classes    
Separate code from data in a way that code resides in functions whose behavior does not depend on data that is somehow encapsulated in the function’s context. 

When we separate code and data, it is straightforward to reuse code in different contexts.  

**The three required/Mandatory classes are:**

**clsLogon.cs** - Handles all validation of the user before reaching the server (form level validation)      

- [ ]  Uses the validation class to Validates user ID according  to the User/Logon ID requirements stated earlier    
- [ ]  Uses the validation class to Validates password according to the User/Logon ID requirements stated earlier    
  
**clsValidation.cs** - Handles input validation for controls or user input before reaching the server   

- [ ]  Validate TextBox input of required fields    

> - [ ]  Phone number    
> - [ ]  Date
> - [ ]  Zip Code
> - [ ]  ...etc 

- [ ]  Handles all other general validations
  
**clsSQL.cs** - Handles connections, INSERT/UPDATE/DELETE, and SELECT    

- [ ]  Efficient code that uses a minimal amount of methods/functions for connecting to the 
database.  
- [ ]  Efficient code that uses a minimal amount of methods/functions for handling data 
manipulation.  
- [ ]  Efficient code that uses a minimal amount of methods/functions for querying the 
database.  
- [ ]  Efficient code that uses a minimal amount of methods/functions for handling SQL 
Exceptions. 
- [ ]  Handles all other SQL Interactions
