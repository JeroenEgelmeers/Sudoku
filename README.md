# Sudoku

# How to run
First get the Sudoku.dll and Sudoku.tlb from https://drive.google.com/folderview?id=0B1TMiRaT2NH6RDJpQ2JTUkh4bzg&usp=sharing
Put them in the folder: Sa-Week4-Sudoku

Then:
- Edit the register.bat (notepad)
- Define the path to the folder on your computer
- Run as admin
- Go to Visual Studio
- - Right click on "Sa-Week4-Sudoku"
- - Add -> reference
- - Com -> Search "Sudoku"
- - Make sure "Sudoku Game" is on
- - Save.

You're now ready to run the application.

# Problem
If you run the project it works like a charm :) How ever, when you click on the "new Game"-button it doesn't what I want. It should fill in every square with it's right value except two of them (so you can check if the game works).

If you do so, it's starting filling the squares but will fail on a bug on square 42. (On line 232 of SudokuBoardUtil.cs I made something for debugging to get in that part of the code when putting on the next line a breakpoint). I have no clue why but it fills in the squares mirrored (run it, click on "New Game" and then check the green squares. There is a pattern in it).
