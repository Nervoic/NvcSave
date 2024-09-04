
using System;
using Newtonsoft.Json;
using UnityEngine;

namespace NvcUtils.NvcSave {
public static class PrefsSaveManager
{   
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
    /// Saves values of all types to a json string if value is not found
    /// </summary>
    /// <typeparam name="T">Generalized function parameter for obtaining generalized types</typeparam>
    /// <param name="saveName">Value saving name</param>
    /// <param name="value">Value to save</param>
        public static void Save<T>(string saveName, T value) {
        if(!PlayerPrefs.HasKey(saveName)) {
            SaveJson(saveName, value);
            OnSaved?.Invoke();
        } else {
            OnSavedError?.Invoke();
            AvailableLogError(saveName);
        }
    }

    /// <summary>
    /// Save values of all types to a json string and overwrite if value is found
    /// </summary>
    /// <typeparam name="T">Generalized function parameter for obtaining generalized types</typeparam>
    /// <param name="saveName">Value saving name</param>
    /// <param name="value">Value to save</param>
    /// <param name="overwrite">Boolean variable that determines whether the value will be overwritten if this save already exists</param>
    public static void Save<T>(string saveName, T value, bool overwrite) {
        if(!PlayerPrefs.HasKey(saveName)) {
            SaveJson(saveName, value);
            OnSaved?.Invoke();
        } else if (overwrite) {
            Overwrite(saveName, value);
            OnSaved?.Invoke();
        } else {
            AvailableLogError(saveName);
            OnSavedError?.Invoke();
        }
    }


    /// <summary>
    /// Overwrite values of all types to a json string if value is not found
    /// </summary>
    /// <typeparam name="T">Generalized function parameter for obtaining generalized types</typeparam>
    /// <param name="saveName">Value overwrite name</param>
    /// <param name="value">Value to overwrite</param>
    public static void Overwrite<T>(string saveName, T value) {
        if(PlayerPrefs.HasKey(saveName)) {
            SaveJson(saveName, value);
            OnSaved?.Invoke();
        } else {
            UpdateLogError(saveName);
            OnSavedError?.Invoke();
        }
    }

    public static T Get<T>(string saveName) {
        if(PlayerPrefs.HasKey(saveName)) {
            string value = PlayerPrefs.GetString(saveName);
            T deserializedValue = JsonConvert.DeserializeObject<T>(value);
            OnGetted?.Invoke();
            return deserializedValue;
        } else {
            NotFoundLog(saveName);
            OnGettedError?.Invoke();
            return default;
        }
    }

    /// <summary>
    /// Return value if this value is found
    /// </summary>
    /// <typeparam name="T">Generalized function parameter for obtaining generalized types</typeparam>
    /// <param name="saveName">Save name to get</param>
    /// <param name="keyNotFound">Value that will be returned if the save is not detected</param>
    /// <returns>Return value or keyNotFound if this value is not found</returns>
    public static T TryGet<T>(string saveName, T keyNotFound) {
        if(PlayerPrefs.HasKey(saveName)) {
            string value = PlayerPrefs.GetString(saveName);
            T deserializedValue = JsonConvert.DeserializeObject<T>(value);
            OnGetted?.Invoke();
            return deserializedValue;
        } else {
            NotFoundLog(saveName);
            OnGettedError?.Invoke();
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


    private static void SaveJson<T>(string saveName, T value) {
        string jsonString = JsonConvert.SerializeObject(value);
        PlayerPrefs.SetString(saveName, jsonString);
    }

    /// <summary>
    /// Deleteing ALL saves from PlayerPrefs. Use only, if you are really need to delete ALL saves. Is dont using to delete only one save from PlayerPrefs
    /// </summary>
    public static void DeleteAllSaves() {
        PlayerPrefs.DeleteAll();
    }



    private static void NotFoundLog(string saveName) {
        Debug.Log($"{saveName} is not available in PlayerPrefs");
    }
    private static void AvailableLogError(string saveName) {
        Debug.Log($"{saveName} is available in PlayerPrefs. If you need resaving value, use Update method");
    }
    private static void UpdateLogError(string saveName) {
        Debug.Log($"{saveName} is not available in PlayerPrefs for overwrite value. If you need save value, use Save method");
    }
    
 

}
}
