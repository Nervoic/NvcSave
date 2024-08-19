# NvcSave
Simple save system for unity with a safe preservation and support to save boolean-variables

Features:
1. Conveniently save and load data types
2. Safely saving and updating existing data will avoid overwriting data if you accidentally use the Save function instead of Update.
3. Support for saving Boolean variables

Installation:
1. Download the "NvcSave" package
2. Import the package to your unity-project


How to use:
Add the following line to your script to use SaveManager - using NvcUtils.Save;
There are 4 types of data saving - integer, float, string, Boolean
For each type, you can save data, overwrite, get.
To delete data, the DeleteSave function is used, which takes the name of the save that you need to delete.

Example:
I want to save and then get a boolean variable. I use

SaveManager.SaveBool(mySaveName, mySaveBool);
SaveManager.GetBool(mySaveName);

But you cannot change an already saved value using SaveBool for greater security. to do this, we use the UpdateBool function, which will overwrite our mySaveName

SaveManager.UpdateBool(mySaveName, mySaveBool);

To delete a value, use:

SaveManager.DeleteSave(mySaveName);

Future Plans
This library will be expanded in the future to include more features and improvements. Stay tuned for updates!
