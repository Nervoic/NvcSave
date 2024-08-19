
using UnityEngine;

namespace NvcUtils.Save {
public static class SaveManager
{

    /// <summary>
    /// Return, if key is not available in PlayerPrefs
    /// </summary>
    private const int keyNotFound = -1;

    /// <summary>
    /// Save integer value in PlayerPrefs if this value is not available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">Integer saving value</param>
    public static void SaveInt(string saveName, int value) {
        if(!PlayerPrefs.HasKey(saveName)) {
        PlayerPrefs.SetInt(saveName, value);
        } else {
            AvailableLogError(saveName);
        }
    }

    /// <summary>
    /// Save integer value in PlayerPrefs else, if this value is available in PlayerPrefs, and you sent true as the value of forceProtect
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">Integer saving value</param>
    /// <param name="forceProtect">Boolean-variably, using for update value else, if this value is available in PlayerPrefs and you are sent true</param>

    public static void SaveInt(string saveName, int value, bool forceUpdate) {
        if(!PlayerPrefs.HasKey(saveName)) {
        PlayerPrefs.SetInt(saveName, value);
        } else if(forceUpdate) {
            UpdateInt(saveName, value);
        } else {
            AvailableLogError(saveName);
        }
    }
    /// <summary>
    /// Overwrite integer value in PlayerPrefs if this value is available in PlayerPrefs, but you are need overwrite this value
    /// </summary>
    /// <param name="saveName">Key name for resaving value</param>
    /// <param name="value">Integer resaving value</param>
    public static void UpdateInt(string saveName, int value) {
        if(PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.SetInt(saveName, value);
        } else {
            UpdateLogError(saveName);
        }
    }
    /// <summary>
    /// Load integer value from PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for getting value</param>
    /// <returns>Return integer value if value is available in PlayerPrefs, else return -1</returns>
    public static int GetInt(string saveName) {
        if(PlayerPrefs.HasKey(saveName)) {
        return PlayerPrefs.GetInt(saveName);
        } else {
            ReturnValueLog(saveName);
            return keyNotFound;
        }
    }

    /// <summary>
    /// Load integer value from PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for getting value</param>
    /// <param name="keyNotFound">Value that return, if this saveName is not available in PlayerPrefs</param>
    /// <returns>Return integer value if value is available in PlayerPrefs, else return keyNotFound</returns>

    public static int GetInt(string saveName, int keyNotFound) {
        if(PlayerPrefs.HasKey(saveName)) {
        return PlayerPrefs.GetInt(saveName);
        } else {
            ReturnValueLog(saveName);
            return keyNotFound;
        }
    }


    /// <summary>
    /// Save float value in PlayerPrefs if this value is not available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">Float saving value</param>
    public static void SaveFloat(string saveName, float value) {
        if(!PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.SetFloat(saveName, value);
        } else {
            AvailableLogError(saveName);
        }
    }
    
    /// <summary>
    /// Save float value in PlayerPrefs else, if this value is available in PlayerPrefs, and you sent true as the value of forceProtect
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">Float saving value</param>
    /// <param name="forceProtect">Boolean-variably, using for update value else, if this value is available in PlayerPrefs and you are sent true</param>

    public static void SaveFloat(string saveName, float value, bool forceUpdate) {
        if(!PlayerPrefs.HasKey(saveName)) {
        PlayerPrefs.SetFloat(saveName, value);
        } else if(forceUpdate) {
            UpdateFloat(saveName, value);
        } else {
            AvailableLogError(saveName);
        }
    }

    /// <summary>
    /// Overwrite float value in PlayerPrefs if this value is available in PlayerPrefs, but you are need overwrite this value
    /// </summary>
    /// <param name="saveName">Key name for resaving value</param>
    /// <param name="value">Float resaving value</param>
    public static void UpdateFloat(string saveName, float value) {
        if(PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.SetFloat(saveName, value);
        } else {
            UpdateLogError(saveName);
        }
    }

    /// <summary>
    /// Load float value from PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for getting value</param>
    /// <returns>Return integer value if value is available in PlayerPrefs, else return -1</returns>
    public static float GetFloat(string saveName) {
        if(PlayerPrefs.HasKey(saveName)) {
            return PlayerPrefs.GetFloat(saveName);
        } else {
            ReturnValueLog(saveName);
            return keyNotFound;
        }
    }


    /// <summary>
    /// Load float value from PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for getting value</param>
    /// <param name="keyNotFound">Value that return, if this saveName is not available in PlayerPrefs</param>
    /// <returns>Return float value if value is available in PlayerPrefs, else return keyNotFound</returns>

    public static float GetFloat(string saveName, int keyNotFound) {
        if(PlayerPrefs.HasKey(saveName)) {
        return PlayerPrefs.GetFloat(saveName);
        } else {
            ReturnValueLog(saveName);
            return keyNotFound;
        }
    }


    /// <summary>
    /// Save string value in PlayerPrefs if this value is not available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">String saving value</param>
    public static void SaveString(string saveName, string value) {
        if(!PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.SetString(saveName, value);
        } else {
            AvailableLogError(saveName);
        }
    }

    /// <summary>
    /// Save string value in PlayerPrefs else, if this value is available in PlayerPrefs, and you sent true as the value of forceProtect
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">String saving value</param>
    /// <param name="forceProtect">Boolean-variably, using for update value else, if this value is available in PlayerPrefs and you are sent true</param>
    public static void SaveString(string saveName, string value, bool forceUpdate) {
        if(!PlayerPrefs.HasKey(saveName)) {
        PlayerPrefs.SetString(saveName, value);
        } else if(forceUpdate) {
            UpdateString(saveName, value);
        } else {
            AvailableLogError(saveName);
        }
    }
    
    

    /// <summary>
    /// Overwrite string value in PlayerPrefs if this value is available in PlayerPrefs, but you are need overwrite this value
    /// </summary>
    /// <param name="saveName">Key name for resaving value</param>
    /// <param name="value">String resaving value</param>
    public static void UpdateString(string saveName, string value) {
        if(PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.SetString(saveName, value);
        } else {
            UpdateLogError(saveName);
        }
    }

    /// <summary>
    /// Load string value in PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for getting value</param>
    /// <returns>Return string value if value is available in PlayerPrefs, else return null</returns>
    public static string GetString(string saveName) {
        if(PlayerPrefs.HasKey(saveName)) {
            return PlayerPrefs.GetString(saveName);
        } else {
            ReturnValueLog(saveName);
            return null;
        }
    }

    /// <summary>
    /// Load string value from PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for getting value</param>
    /// <param name="keyNotFound">Value that return, if this saveName is not available in PlayerPrefs</param>
    /// <returns>Return string value if value is available in PlayerPrefs, else return keyNotFound</returns>

    public static string GetString(string saveName, string keyNotFound) {
        if(PlayerPrefs.HasKey(saveName)) {
        return PlayerPrefs.GetString(saveName);
        } else {
            ReturnValueLog(saveName);
            return keyNotFound;
        }
    }


    /// <summary>
    /// Save boolean value in PlayerPrefs if this value is not available in PlayerPrefs. Using integer value to save boolean-variable
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">Boolean saving value</param>
    public static void SaveBool(string saveName, bool value) {
        if(!PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.SetInt(saveName, value ? 1 : 0);
        } else {
            AvailableLogError(saveName);
        }
    }
    /// <summary>
    /// Save boolean value in PlayerPrefs else, if this value is available in PlayerPrefs, and you sent true as the value of forceProtect. Using integer value to save boolean-variable
    /// </summary>
    /// <param name="saveName">Key name for saving value</param>
    /// <param name="value">Boolean saving value</param>
    /// <param name="forceProtect">Boolean-variably, using for update value else, if this value is available in PlayerPrefs and you are sent true</param>
    public static void SaveBool(string saveName, bool value, bool forceUpdate) {
        if(!PlayerPrefs.HasKey(saveName)) {
        PlayerPrefs.SetInt(saveName, value ? 1 : 0);
        } else if(forceUpdate) {
            UpdateBool(saveName, value);
        } else {
            AvailableLogError(saveName);
        }
    }


    /// <summary>
    /// Overwrite boolean value in PlayerPrefs if this value is available in PlayerPrefs, but you are need overwrite this value
    /// </summary>
    /// <param name="saveName">Key name for resaving value</param>
    /// <param name="value">Boolean resaving value</param>
    public static void UpdateBool(string saveName, bool value) {
        if(PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.SetInt(saveName, value ? 1 : 0);
        } else {
            UpdateLogError(saveName);
        }
    }


    /// <summary>
    /// Load boolean value in PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for loading value</param>
    /// <returns>Return boolean value if value is available in PlayerPrefs, else return false</returns>

    public static bool GetBool(string saveName) {
        if(PlayerPrefs.HasKey(saveName)) {
            bool value = PlayerPrefs.GetInt(saveName) == 1;
            return value;
        } else {
            ReturnValueLog(saveName);
            return false;
        }
    }

    /// <summary>
    /// Load boolean value from PlayerPrefs if this value is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for getting value</param>
    /// <param name="keyNotFound">Value that return, if this saveName is not available in PlayerPrefs</param>
    /// <returns>Return boolean value if value is available in PlayerPrefs, else return keyNotFound</returns>

    public static bool GetBool(string saveName, bool keyNotFound) {
        if(PlayerPrefs.HasKey(saveName)) {
        return PlayerPrefs.GetInt(saveName) == 1;
        } else {
            ReturnValueLog(saveName);
            return keyNotFound;
        }
    }



    /// <summary>
    /// Delete save if this save is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for deleting save</param>
    public static void DeleteSave(string saveName) {
        if(PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.DeleteKey(saveName);
        } else {
            Debug.Log($"{saveName} is not available in PlayerPrefs, and cannot be deleted");
        }
    }


    /// <summary>
    /// Deleteing ALL saves from PlayerPrefs. Use only, if you are really need to delete ALL saves. Is dont using to delete only one save from PlayerPrefs
    /// </summary>
    public static void DeleteAllSaves() {
        PlayerPrefs.DeleteAll();
    }
    private static void ReturnValueLog(string saveName) {
        Debug.Log($"{saveName} is not available in PlayerPrefs");
    }
    private static void AvailableLogError(string saveName) {
        Debug.Log($"{saveName} is available in PlayerPrefs. If you need resaving value, use Update function")
    }
    private static void UpdateLogError(string saveName) {
        Debug.Log($"{saveName} is not available in PlayerPrefs for overwrite value. If you need save value, use Save function")
    }
 

}
}
