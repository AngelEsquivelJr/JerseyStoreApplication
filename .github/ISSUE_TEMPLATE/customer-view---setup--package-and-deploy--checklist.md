---
name: Customer View - Setup (Package and Deploy) Checklist
about: Describe this issue template's puCustomer View - Setup (Package and Deploy)
  Checklistrpose here.
title: Customer View - Setup (Package and Deploy) Checklist
labels: Customer View
assignees: ''

---

## Before building your setup, for your project:
- [ ] Make sure your project and all forms have custom icons
- [ ] Make sure you have compiled your project to Release mode (Not Debug Mode)
- [ ] Make sure all of your projects Assembly Information has been filled-in/correctly set
- [ ] This Setup (Package and Deploy) and its contetns Release Mode Only
- [ ] The Executable in this setup is the Release mode/version of the Executable Program (.EXE) (Not the Debug version)
## General Setup Wizard settings:
- [ ] Setup 'Project Name' Meaningful for the project **(Typically the name of your program. IE: TSTC Game Store)**
- [ ] Setup project is part of the Project Solution
- [ ] Setup is a setup for a Windows application
- [ ] Includes the primary (.Exe) output from the project (Release version)
- [ ] Includes all additional Required files (Icon, Fonts, External files, etc.)
## File System on Target Machine:
- [ ] User's Desktop - Includes a shortcut to the Project .Exe
- [ ] User's Desktop - shortcut to the Project .Exe uses a custom Icon for your program
- [ ] User's Programs Menu (Start menu) contains a folder for your Program which contains a shortcut to your program with a custom Icon
- [ ] Fonts Folder - If your project used any special fonts be sure to install them
## Install Project Properties:
- [ ] AddRemoveProgramsIcon set to custom Project/Program Icon
- [ ] Author - Changed to your name
- [ ] Description - Describes your Program
- [ ] InstallAllUsers - set to True
- [ ] Manufacturer - changed to TSTC
- [ ] ManufacturerUrl - Set to www.TSTC.edu
- [ ] RemovePreviousVersions - set to True
- [ ] Version - Set to value 1.1.1000
## Final Steps:
- [ ] Build the Setup/Installer (Release mode)
## Test:
- [ ] Does your Setup work (Setup.exe)
- [ ] Does it create a desktop shortcut to your program with a custome Icon
- [ ] Does it create a Start Menu shortcut, located in a Sub menu/folder for your program, to your program with a custom Icon
- [ ] Does your program run successfully from the Desktop shortcut
- [ ] Does your program run successfully from the Start Menu shortcut
- [ ] Are all required support files and fonts correctly installed
- [ ] Test your installation for all of the above listed specifications/properties
## Programs and Features Test:
- [ ] Does the uninstall for your program list correctly and have a custom Icon
- [ ] Does your program correctly uninstall and remove all appropriate files
## GitHub:
- [ ] Save all your projects in this solution and the solution
- [ ] Do a final GitHub Push/Sync
