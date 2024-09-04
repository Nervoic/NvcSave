
using System;
using System.Collections.Generic;


namespace NvcUtils.NvcSave {
public static class MemorySaveManager
{
    /// <summary>
    /// Dictionary with all memory-saves values in key-value format
    /// </summary>
    private static Dictionary<string, object> memoryValues = new Dictionary<string, object>();


    /// <summary>
    /// Triggered when data saved is sucessfully
    /// </summary>
    public static event Action OnSaved;

    /// <summary>
    /// Triggered when data saved is unscessfully
    /// </summary>
    public static event Action OnSavedError;

    /// <summary>
    /// Triggered when data getted is sucessfully
    /// </summary>
    public static event Action OnGetted;

    /// <summary>
    /// Triggered when data getted is unsucessfully
    /// </summary>
    public static event Action OnGettedError;


    /// <summary>
    /// Set and add memory values in dictionary if value is not found in dictionary
    /// </summary>
    /// <typeparam name="T">Gets a variable to save</typeparam>
    /// <param name="keyName">Key name to saving value</param>
    /// <param name="value">Saving value</param>
    public static void SaveMemoryValue<T>(string keyName, T value) {
        if(!memoryValues.ContainsKey(keyName)) {
        memoryValues.Add(keyName, value);
        OnSaved?.Invoke();
        } else {
            UnityEngine.Debug.Log($"{keyName} is found in dictionary. If you are need to resave value, use OverwriteMemoryValue method");
            OnSavedError?.Invoke();
        }
    }

    /// <summary>
    /// Set and add memory values in dictionary, and if value is found in dictionary, overwrite value
    /// </summary>
    /// <typeparam name="T">Gets a variable to save</typeparam>
    /// <param name="keyName">Key name to saving value</param>
    /// <param name="value">Saving value</param>
    /// <param name="overwriteIfFound">Boolean variably, if true - value is overwrite if this value is found in Dictionary</param>

    public static void SaveMemoryValue<T>(string keyName, T value, bool overwriteIfFound) {
        if(!memoryValues.ContainsKey(keyName)) {
            memoryValues.Add(keyName, value);
            OnSaved?.Invoke();
        } else if(overwriteIfFound) {
            OverwriteMemoryValue(keyName, value);
            OnSaved?.Invoke();
        } else {
            UnityEngine.Debug.Log($"{keyName} is fount in dictionary. If you are need to resave value, use OverwriteMemoryValue method");
            OnSavedError?.Invoke();
        }
    }

    /// <summary>
    /// Overwrite value if this value is found in dictionary
    /// </summary>
    /// <typeparam name="T">Gets a variable to overwrite</typeparam>
    /// <param name="keyName">Key name to overwrite</param>
    /// <param name="value">Value to overwrite</param>
    public static void OverwriteMemoryValue<T>(string keyName, T value) {
        if(memoryValues.ContainsKey(keyName)) {
            memoryValues[keyName] = value;
            OnSaved?.Invoke();
        } else {
            UnityEngine.Debug.Log($"{keyName} if not found in dicrionary. If you are need to save value, use SetMemoryValue method");
            OnSavedError?.Invoke();
        }
    }

    /// <summary>
    /// Load memory values if value is found in dictionary
    /// </summary>
    /// <typeparam name="T">Return a variable to get</typeparam>
    /// <param name="keyName">Key name to load value</param>
    /// <returns></returns>
    public static T GetMemoryValue<T>(string keyName) {
        if(memoryValues.ContainsKey(keyName)) {
            OnGetted?.Invoke();
            return (T)memoryValues[keyName];
        } else { 
            LogNotFound(keyName);
            OnGettedError?.Invoke();
            return default;
        }
    }

    /// <summary>
    /// Trying load memory values if value is found in dictionary
    /// </summary>
    /// <typeparam name="T">Return a variable to get</typeparam>
    /// <param name="keyName">Key name to load value</param>
    /// <param name="keyNotFoundValue">Value returned if recived keyName is not detected in dictionary</param>
    /// <returns></returns>

    public static T TryGetMemoryValue<T>(string keyName, T keyNotFoundValue) {
        if(memoryValues.ContainsKey(keyName)) {
            OnGetted?.Invoke();
            return (T)memoryValues[keyName];
        } else {
            LogNotFound(keyName);
            OnGettedError?.Invoke();
            return keyNotFoundValue;
        }
    }


    /// <summary>
    /// Remove value if value is found in dictionary
    /// </summary>
    /// <param name="keyName">Key name to remove</param>
    public static void RemoveValue(string keyName) {
        if(memoryValues.ContainsKey(keyName)) {
            memoryValues.Remove(keyName);
        } else {
            LogNotFound(keyName);
        }
    }


    /// <summary>
    /// Remove ALL values from dictionary. Dont use if you are need remove one value. Use only, if you are really need clear dictionary
    /// </summary>
    public static void ClearMemoryValues() {
        memoryValues.Clear();
    }


    private static void LogNotFound(string keyName) {
        UnityEngine.Debug.Log($"{keyName} is not found in saved default values");
    }
}
}
