# NvcSave
__NvcSave__ is a simple and reliable saving system for Unity that allows you to save data both locally on the player's computer and in memory during runtime. This system is designed for ease of use and safety, making it ideal for storing settings, game data, and more.

# Features
1.__In-Memory Data Saving__:
-Store data temporarily in memory during the execution of your program. This is particularly useful for creating a settings reset system or other temporary data storage needs.

2.__Local Data Saving__:
-Save data directly to the player's computer with an easy-to-use API that ensures safe and reliable storage. And the ability to try to return a value allows you to set the value you need if it was not found when trying to get it, which can be used to safely load settings.

3.__Comprehensive XML Documentation__:
-The included XML documentation within the codebase provides clear guidance and explanations, making it easy to understand and integrate the library into your project.

4.__Generic type support__:
-NvcSave is designed with flexibility in mind, supporting generic types to accommodate a wide range of data types. This ensures that you can save and load any data type, from simple primitives to complex custom objects, with ease.

5.__Json save support__:
-Support for saving data in JSON format and built-in encryption using AES algorithms

6.__Encrypt and decrypt support__:
-Ability to encrypt and decrypt data during serialization and deserialization
# Installation

1.__Download the Repository__:
-Click the "Code" button on this GitHub page and select "Download ZIP" to download the repository.

2.__Unzip the Archive__:
-Extract the downloaded ZIP file. Inside, locate the NvcSave folder.

3.__Move to Unity Project__:
-Copy the NvcSave folder into the Assets directory of your Unity project.

4.__Add dependency__:
-Find the manifest file in the packages folder of your unity manifest.json, open it and add a dependency - "com.unity.nuget.newtonsoft-json": "3.0.2"

5.__Start Using NvcSave__:
-To begin using the library, add the following line to your scripts:
using NvcUtils.Save;

# How to use:
After you have added the string using NvcUtils.Save, you can use all the functions from this library. The library contains 2 classes - SaveManager and SaveDefaultManager.

1. __PrefsSaveManager__:
-It is used to save data locally on the player's computer. Supports saving int, float, string and boolean variables, and generalized types, overwriting saves, getting and deleting. it contains all the necessary checks to ensure that the program works correctly.

2. __MemorySaveManager__:
-It is used to store data in memory for the duration of the project. It can be useful for simple saves and system resets.

3. __JsonSaveManager__:
-It is used to save and encrypt data in json format. Before using this class, make sure that you have entered the key and iv in CryptoManager class for encryption, or implemented a cloud-based key generation system.

4. __CryptoManager__:
-It is used to encrypt and decrypt data. By default, it is used by the JsonSaveManager class. Before using, do not forget to enter your key and iv in the key and iv field

For more information, see the xml documentation inside the code.


