---
name: Logon View - Testing - Logon ID (User Name)
about: Logon View - Testing - Logon ID (User Name)
title: ''
labels: Logon View, Testing
assignees: ''

---

## Username: Logon ID
### To be Valid:
- [ ] Length >= 8
- [ ] Length <= 20
- [ ] Must be unique in Database/Table
- [ ] Not case sensitive
- [ ] No special characters
- [ ] No spaces

### Invalid Data Checks:
- [ ] Invalid: length > 20
- [ ] Invalid: lenght < 8
- [ ] Invalid: Spaces (start, end, or contains)
- [ ] Invalid: special characters
- [ ] Invalid: A@123456
- [ ] Invalid: Bob bob
- [ ] Invalid: Bob-bob
- [ ] Invalid: _BobBobb
- [ ] Invalid: BobBobb_
- [ ] Invalid: 1 space 1
- [ ] Invalid:  LeadingSpace
- [ ] Invalid: trailingspace 
- [ ] Invalid: abcdefghijklmnopqrstuvwxyz
- [ ] Invalid: toshort
- [ ] Invalid: Me
