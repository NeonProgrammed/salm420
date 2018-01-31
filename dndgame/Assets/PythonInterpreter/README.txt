Python Interpreter for Unity
by Noam Gat (Forum username : [Noman] )


--- Changelog ---
V1.2 (15/5/2011) : In-game scripting now also supported (.Net 2.0 API support option required)
V1.1 (7/5/2011) : Packaging changes
V1.0 (4/5/2011) : Initial Version


1. Introduction

This plugin adds an interactive python interpreter to Unity. It allows you to
run commands outside of the normal MonoBehavior context. Whether you want to 
try out a mathematical formula, create a bunch of GameObjects methodologically
or just execute code that needs to be ran once, this is the plugin for you.

It also allows you to enable modding for your game by dynamically executing
python code during runtime. You will be able to load textual python files 
and run them during runtime!

The plugin is based on IronPython and not Boo, so the language available is 
pure Python (without the additions that the Boo/Unity team made to it). All
of the Unity API (including editor) is available from the commands.

To learn more about python, go to www.python.org or www.learnpython.org .

2. Installation

There are two ways to install the package :

--- Full installation ---
This includes both editor support and runtime support. This is the way the package
is supplied defaultly. It requires that you use the '.Net 2.0' API compatibility level
(as opposed to the subset). You can set this in 
Edit->Project Settings->Player->Other Settings

--- Editor-only installation ---
If you do not want to run python code from inside the game, delete the PythonBehaviour.cs class
from the Examples directory, and move the PythonEnvironment.cs class to the Editor directory.

3. Basic Usage

After the package is imported, just go to Window -> Python Interpreter and
the window will open up. You can start executing code immediately. Multi-line
code is possible - just finish it off with an empty line so the interpreter
knows you are done. Since tab input is not supported, use spaces for indentation.
See the Example Scripts subdirectory for a few very basic examples of what can be done.

4. Editing / Executing code with MonoDevelop

You can also use MonoDevelop to write and execute python code. Place the file
'MonoDevelop.UnityInterpreter.dll' from the MonoDevelop Addin subdirectory to :
Windows : Unity installation dir\MonoDevelop\Addins
OSX : .config/MonoDevelop/addins (not tested yet)
Linux : /usr/lib/MonoDevelop/AddIns

You will then be able to execute code by selecting 

Run->Execute In Unity (Shortcut : F3)

in MonoDevelop. If a specific portion of code is selected, only it will be executed.

5. Executing dynamic python code inside the game

If you opted for the full installation, you can execute Python code from inside the game!
Just create a PythonEnvironment class, and use the RunCommand method.
See Examples/PythonBehaviour.cs and the accompanying scene (PyExampleScene) for a demonstration.

6. Bugs / Limitations

- The GUI is very basic. No command history, copy/paste support or tab input. I recommend
	using MonoDevelop for more advanced scripts.
- The in-game code executing (PythonBehaviour etc) is only supported when the .Net support is
	".Net 2.0" (rather than subsets etc). This is due to PythonEnvironment.cs's compilation.

7. Support

For bug reports and suggestions, contact me at the unity forums (username : [Noman] ).