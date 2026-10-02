# BakerFalahi - OOP Assignment 3

This repository contains the work for Simulation Academy's .NET Diploma assignment on refactoring, design patterns, collections, extension methods, generics, and public technical writing.

The assignment is split into independent folders so each part can be built, reviewed, and completed without mixing concerns.

## Repository Structure

```text
BakerFalahi-OOP-Assignment-3/
|-- Refactoring/
|   |-- part-01/
|   |-- part-02/
|   `-- part-03/
|-- Collections/
|   |-- Answers.md
|   `-- src/
|-- Generics/
|   |-- Answers.md
|   `-- src/
|-- LinkedIn/
|   `-- linked.md
|-- BakerFalahi-OOP-Assignment-3.slnx
`-- README.md
```

## Parts

### 1. Refactoring

The `Refactoring` folder is prepared for the three projects from the source repository:

`https://github.com/SimulationEG/Refactoring-OCP-DIP-Composition`

Each project should be copied into its matching folder and refactored there.

- `part-01`: Open/Closed Principle, Dependency Inversion, and composition over inheritance.
- `part-02`: Template Method for report exporting and Facade for enrollment.
- `part-03`: faster blocked-user lookup and lazy student generation.

### 2. Collections and Extension Methods

The `Collections/src` project contains two string extension methods:

- `IsValidEgyptianPhone()`
- `IsValidEgyptianNationalId()`

The program runs the full validation table from the assignment and prints whether each case passed.

### 3. Generics

The `Generics/src` project contains a reusable generic `Store<T>` constrained by `IHasId`.

It demonstrates:

- adding and retrieving students and courses;
- duplicate id protection;
- returning read-only data from the store;
- generic extension methods for paging, lookup by id, and dictionary conversion.

### 4. LinkedIn Posts

`LinkedIn/linked.md` is prepared for the four public LinkedIn post links required by the assignment.

## Build and Run

Build the full solution from the repository root:

```bash
dotnet build
```

Run the collections project:

```bash
dotnet run --project Collections/src/CollectionsApp.csproj
```

Run the generics project:

```bash
dotnet run --project Generics/src/GenericsApp.csproj
```

## Notes

- Build outputs such as `bin/` and `obj/` are ignored.
- IDE files, local environment files, PDFs, archives, and local scratch folders are ignored.
- The LinkedIn links and refactoring answers are left as placeholders so they can be completed after the external work is done.
