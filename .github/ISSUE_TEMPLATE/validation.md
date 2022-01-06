---
name: Validation
about: Validation
title: Validation
labels: ''
assignees: ''

---

## Apparent, Possible or Probably Validation Issues

Validation should be used for all user input to ensure data integrity and validity **before** attempting to use the user provided data in your application. 

## {DataType}.TryParse()
All **{DataType}.TryParse()** must be contained within an **IF** or **IF/ELSE** statement. **IF** or **IF/ELSE** statements cannot have empty blocks.

See examples below:
```
string strValue = "a" ; 
//Initialized to something that will fail on purpose int intValue = 0 ; 
if (!int.TryParse(strValue, out intValue))
{ 
     MessageBox.Show( "You did not enter a value I can convert to an Integer" , "Conversion Issue" , MessageBoxButtons.OK, MessageBoxIcon.Error); //Or other handling as appropriate 
}
```

```
String strValue = "a" ; //Initialized   to   something   that   will   fail   on   purpose   
int intValue = 0 ;     
if (int.TryParse(strValue, out intValue))   
{        
     MessageBox.Show( "Your conversion successful!" , "Conversion Success", MessageBoxButtons.OK, MessageBoxIcon.Information); //Or other handling as appropriate
}
else
{
     MessageBox.Show( "You did not enter a value I can convert to an Integer", "Conversion Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);   
}
```
