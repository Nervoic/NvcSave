
using System;
using Newtonsoft.Json;
using UnityEngine;

namespace NvcUtils.NvcSave {
public static class PrefsSave
{   
    /// <summary>
    /// Triggered when data saved is sucessfully
    /// </summary>
    public static event Action onSaved;

    /// <summary>
    /// Triggered when data saved is unscessfully
    /// </summary>
    public static event Action onSavedError;

    /// <summary>
    /// Triggered when data load is sucessfully
    /// </summary>
    public static event Action onLoad;

    /// <summary>
    /// Triggered when data load is unsucessfully
    /// </summary>
    public static event Action onLoadError;

    /// <summary>
    /// Saves values of all types to a json string if value is not found
    /// </summary>
    /// <typeparam name="T">Generalized function parameter for obtaining generalized types</typeparam>
    /// <param name="saveName">Value saving name</param>
    /// <param name="value">Value to save</param>
        public static void Save<T>(string saveName, T value) {
            try {
            SaveJson(saveName, value);
            onSaved?.Invoke();
            } catch(Exception ex) {
                Debug.Log(ex.Message);
                onSavedError?.Invoke();
            }
    }

    public static T Load<T>(string saveName, T keyNotFound) {
        try {
        if(PlayerPrefs.HasKey(saveName)) {
            string value = PlayerPrefs.GetString(saveName);
            T deserializedValue = JsonConvert.DeserializeObject<T>(value);
            onLoad?.Invoke();
            return deserializedValue;
        } else {
            NotFoundLog(saveName);
            onLoadError?.Invoke();
            return keyNotFound;
        }
        } catch(Exception ex) {
            Debug.Log(ex.Message);
            onLoadError?.Invoke();
            return keyNotFound;
        }
    }

    /// <summary>
    /// Delete save if this save is available in PlayerPrefs
    /// </summary>
    /// <param name="saveName">Key name for deleting save</param>
    public static void DeleteSave(string saveName) {
        try {
        if(PlayerPrefs.HasKey(saveName)) {
            PlayerPrefs.DeleteKey(saveName);
        } else {
            Debug.Log($"{saveName} is not available in PlayerPrefs, and cannot be deleted");
        }
        } catch(Exception ex) {
            Debug.Log(ex.Message);
        }
    }


    private static void SaveJson<T>(string saveName, T value) {
        try {
        string jsonString = JsonConvert.SerializeObject(value);
        PlayerPrefs.SetString(saveName, jsonString);
        } catch(Exception ex) {
            Debug.Log(ex.Message);
        }
    }

    /// <summary>
    /// Deleteing ALL saves from PlayerPrefs. Use only, if you are really need to delete ALL saves. Is dont using to delete only one save from PlayerPrefs
    /// </summary>
    public static void DeleteAllSaves() {
        try {
        PlayerPrefs.DeleteAll();
        } catch(Exception ex) {
            Debug.Log(ex.Message);
        }
    }



    private static void NotFoundLog(string saveName) {
        Debug.Log($"{saveName} is not available in PlayerPrefs");
    }
    
 

}
}
