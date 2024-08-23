
using System.Collections.Generic;


namespace NvcUtils.NvcSave {
public static class MemorySaveManager
{
    /// <summary>
    /// Dictionary with all default-saves values in key-value format
    /// </summary>
    private static Dictionary<string, object> defaultValues = new Dictionary<string, object>();


    /// <summary>
    /// Set and add default values in dictionary if value is not found in dictionary
    /// </summary>
    /// <typeparam name="T">Gets a variable to save</typeparam>
    /// <param name="keyName">Key name to saving value</param>
    /// <param name="value">Saving value</param>
    public static void SetDefaultValue<T>(string keyName, T value) {
        if(!defaultValues.ContainsKey(keyName)) {
        defaultValues.Add(keyName, value);
        } else {
            UnityEngine.Debug.Log($"{keyName} is found in dictionary. If you are need to resave value, use OverwriteDefaultValue function");
        }
    }

    /// <summary>
    /// Set and add default values in dictionary, and if value is found in dictionary, overwrite value
    /// </summary>
    /// <typeparam name="T">Gets a variable to save</typeparam>
    /// <param name="keyName">Key name to saving value</param>
    /// <param name="value">Saving value</param>
    /// <param name="overwriteIfFound">Boolean variably, if true - value is overwrite if this value is found in Dictionary</param>

    public static void SetDefaultValue<T>(string keyName, T value, bool overwriteIfFound) {
        if(!defaultValues.ContainsKey(keyName)) {
            defaultValues.Add(keyName, value);
        } else if(overwriteIfFound) {
            OverwriteDefaultValue(keyName, value);
        } else {
            UnityEngine.Debug.Log($"{keyName} is fount in dictionary. If you are need to resave value, use OverwriteDefault value function");
        }
    }

    /// <summary>
    /// Overwrite value if this value is found in dictionary
    /// </summary>
    /// <typeparam name="T">Gets a variable to overwrite</typeparam>
    /// <param name="keyName">Key name to overwrite</param>
    /// <param name="value">Value to overwrite</param>
    public static void OverwriteDefaultValue<T>(string keyName, T value) {
        if(defaultValues.ContainsKey(keyName)) {
            defaultValues[keyName] = value;
        } else {
            UnityEngine.Debug.Log($"{keyName} if not found in dicrionary. If you are need to save value, use SetDefaultValue function");
        }
    }

    /// <summary>
    /// Load default values if value is found in dictionary
    /// </summary>
    /// <typeparam name="T">Return a variable to get</typeparam>
    /// <param name="keyName">Key name to load value</param>
    /// <param name="keyNotFoundValue">Value returned if recived keyName is not detected in dictionary</param>
    /// <returns></returns>
    public static T GetDefaultValue<T>(string keyName, T keyNotFoundValue) {
        if(defaultValues.ContainsKey(keyName)) {
        return (T)defaultValues[keyName];
        } else { 
            LogNotFound(keyName);
            return keyNotFoundValue;
        }
    }


    /// <summary>
    /// Remove value if value is found in dictionary
    /// </summary>
    /// <param name="keyName">Key name to remove</param>
    public static void RemoveValue(string keyName) {
        if(defaultValues.ContainsKey(keyName)) {
            defaultValues.Remove(keyName);
        } else {
            LogNotFound(keyName);
        }
    }


    /// <summary>
    /// Remove ALL values from dictionary. Dont use if you are need remove one value. Use only, if you are really need clear dictionary
    /// </summary>
    public static void ClearDefaultValues() {
        defaultValues.Clear();
    }


    private static void LogNotFound(string keyName) {
        UnityEngine.Debug.Log($"{keyName} is not found in saved default values");
    }
}
}
