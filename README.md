# Minesweeper Game Project by Sandeep Thomas

## Overview

This Minesweeper game is a console application built using .NET 7. The application is designed to be simple yet expandable, focusing on clean architecture principles to ensure separation of concerns and maintainability.

## Features

- Classic Minesweeper gameplay.
- Configurable game settings through `appsettings.json`.
- Chessboard-like coordinate system for intuitive user experience.
- Safe start with no mines on the first cell.
- Replayability through the console interface.

## Architecture

This project is structured into two main components:

- Minesweeper.Core - Contains all the business logic and models. It is designed to be agnostic of the user interface, allowing for potential future expansions into other forms of applications, such as web or mobile.
- Minesweeper.ConsoleApp - Handles user interaction and inputs/outputs via the console. It uses the core project for all game logic.

# Advantages of Clean Architecture

- Decoupling: Core logic is decoupled from the UI, making the system easier to maintain and extend.
- Testability: With a clear separation, it becomes easier to implement unit tests, especially with interfaces and dependency injection.
- Flexibility: Changes in the technology stack of the UI can be made with minimal impact on the core logic.

## Testing

xUnit testing is implemented

Note : Core project csproj file has entry for test project can access internal types of Minesweeper.Core
