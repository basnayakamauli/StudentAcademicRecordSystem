# Student Academic Record Management System

A C# Windows Forms application developed to manage, calculate, display, and export student academic records.

## Features

- Add student academic records
- Store Student ID, Student Name, Course, Unit, and Marks
- Calculate unit GPA
- Calculate overall GPA
- Calculate current WAM (Weighted Average Mark)
- Display student academic status
- Search for students by Student ID
- Display multiple unit records in a DataGridView
- Validate marks and required information
- Prevent duplicate unit records
- Display Satisfactory and At Risk student status
- Export student academic records to a CSV file
- Save exported records in a format compatible with Microsoft Excel

## Technologies

- C#
- .NET
- Windows Forms
- Visual Studio
- System.IO for CSV file export

## Application

The system provides a desktop GUI for entering, calculating, searching, and displaying student academic information. Academic records are stored in memory during the current application session.

The application also allows academic staff to export student records to a CSV file using a Save File dialog. The exported file contains student details, unit marks, and GPA values and can be opened in Microsoft Excel.

**Note:** Records are not automatically saved between application sessions. CSV export allows users to save a copy of the records for future reference.