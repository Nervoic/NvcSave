# NvcSave
__NvcSave__ is a simple and reliable saving system for Unity that allows you to save data both locally on the player's computer and in memory during runtime. This system is designed for ease of use and safety, making it ideal for storing settings, game data, and more.

# Features
1. In-Memory Data Saving:
-Store data temporarily in memory during the execution of your program. This is particularly useful for creating a settings reset system or other temporary data storage needs.

2.__Local Data Saving__:
-Save data directly to the player's computer with an easy-to-use API that ensures safe and reliable storage.

3.__Comprehensive XML Documentation__:
-The included XML documentation within the codebase provides clear guidance and explanations, making it easy to understand and integrate the library into your project.

# Installation

1.__Download the Repository__:
-Click the "Code" button on this GitHub page and select "Download ZIP" to download the repository.

2.__Unzip the Archive__:
-Extract the downloaded ZIP file. Inside, locate the NvcSave folder.

3.__Move to Unity Project__:
-Copy the NvcSave folder into the Assets directory of your Unity project.

4.__Start Using NvcSave__:
-To begin using the library, add the following line to your scripts:
using NvcUtils.Save;

# How to use:
After you have added the string using NvcUtils.Save, you can use all the functions from this library. The library contains 2 classes - SaveManager and SaveDefaultManager.

1. __SaveManager__:
-It is used to save data locally on the player's computer. Supports saving int, float, string and boolean variables, overwriting saves, getting and deleting. it contains all the necessary checks to ensure that the program works correctly.

2. __SaveDefaultManager__:
-It is used to store data in memory for the duration of the project. It can be useful for simple saves and system resets.

For more information, see the xml documentation inside the code.


