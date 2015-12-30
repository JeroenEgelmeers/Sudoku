# Sudoku

# How to run
First check if you've got the Sudoku.dll and Sudoku.tld in the folder: Sa-Week4-Sudoku. It should be there but could go wrong because of a early commit. If you do not have it in your folder:
Get the Sudoku.dll and Sudoku.tlb from https://drive.google.com/folderview?id=0B1TMiRaT2NH6RDJpQ2JTUkh4bzg&usp=sharing
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

# What have we tried:
Over 4 programmers have been on this bug. We tried to get another DLL, debugged it step by step (put the line 232 in the method to debug faster). We're out that the dll is not the problem as we managed it to use it in other projects. It is our code. We tried to redevelop the methods (getHint()) but that didn't fix the solution.
