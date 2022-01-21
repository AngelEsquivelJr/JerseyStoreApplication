---
name: Logon View - Testing - Password
about: Logon View - Testing - Password
title: Logon View - Testing - Password
labels: Testing
assignees: ''

---

- [ ] I have tested my passwords thoroughly using both Valid and Invalid passwords to ensure my program meets the validation requirements:

Below is a partial list of just some of the password combinations suggested for use with testing. Make up your own valid and invalid ones to test with also.

Invalid Login id, over twenty characters: Abacedfghijklmnopqrstuvwxyz
Invalid Password, over twenty characters: Abacedfghijklmnopqrstuvwxyz@1
(See MaxLength property for TextBoxes, etc.)

## Requirements
- [ ] Lower case letters
- [ ] Upper Case letters
- [ ] Numbers
- [ ] Select Special Characters Only:
          ()!@#$%^&*

- [ ] Length >= 8
- [ ] Length <= 20

### Valid:
- [ ] A@123456
- [ ] a@123456
- [ ]  @123456A
- [ ] @123456a
- [ ] 123@456A
- [ ] 123(456A
- [ ] 123)456A
- [ ] 123!456A
- [ ] A#123456
- [ ] A^123456
- [ ] A$123456
- [ ] A123%456
- [ ] A123456&
- [ ] a123456*
- [ ] A#123456
- [ ] (A123)456

### Invalid
- [ ] 1 space @
- [ ] 1space @
- [ ] =+badSymbol1
- [ ] 1bad+SpecialChar
- [ ] Password
- [ ] Pass word1
- [ ] =+@123456
- [ ] 123456@
- [ ] @123456
- [ ] A12345678
- [ ] A@123456
- [ ] A2abcdefghijklmnopqrstuvwxyz
- [ ]  LeadingSpace@
- [ ] Tr@ilingspace 
- [ ] T0short
- [ ] Me3&
- [ ] A.123456
