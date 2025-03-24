# GitUp

## Overview

GitUp is a simple C# program designed to automate common git commands. This program is intended to be used in a Windows environment and leverages the `Process` class to run git commands through PowerShell.

## Description

GitUp automates the following git commands:
- `fetch`
- `pull`
- `add`
- `commit`
- `push`

The program is written in C# and uses the `Process` class to execute these commands. It is designed to streamline the process of updating a remote GitHub repository by running these commands in sequence.

## Usage

1. Ensure you have PowerShell installed on your Windows machine.
2. Compile the `Program.cs` file using a C# compiler.
3. Run the compiled executable with the appropriate arguments.

### Command Line Arguments

- `gitup.exe [arg:<commit>] [opt:<files>]`

#### Examples

- To commit with a message:
    ```sh
    gitup.exe "Initial commit"
    ```

- To display help:
    ```sh
    gitup.exe -h
    ```

## Installation

1. Clone this repository to your local machine.
2. Open the project in your preferred C# development environment.
3. Build the project to generate the executable.

## Features

- Automates common git commands.
- Runs git commands through PowerShell.
- Displays output and errors from git commands.
- Provides usage instructions and help.

## Future Improvements

- Implement file management for the `add` command.
- Improve error handling and output formatting.
- Add support for additional git commands.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

For any questions or inquiries, please contact Juan Jose Solorzano at [juanjose.solorzano.c@gmail.com](mailto:juanjose.solorzano.c@gmail.com).