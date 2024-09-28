
using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;


namespace NvcUtils.NvcSave {
public static class JsonSave
{
   public static event Action onSaved;
   public static event Action onSavedError;
   public static event Action onLoad;
   public static event Action onLoadError;
   public static event Action onNewJsonFileCreation;
   public static event Action onNewJsonFileCreationError;
    /// <summary>
    /// Added new empty json-file
    /// </summary>
    /// <param name="fileName">New json-file name</param>
    /// <param name="filePath">Path to save new json-file</param>
    public static void AddJsonFile(string fileName, string filePath) {
        try {
        string jsonPath = CombinePath(filePath, fileName);
        if(!CheckFileToPath(jsonPath)) NewJsonFile(jsonPath);
        else AvailableLog(jsonPath);
        } catch(Exception ex) { Debug.Log(ex.Message); }
    }

    /// <summary>
    /// Saves new data in a json file.
    /// </summary>
    /// <typeparam name="T">Get generalized type for saving</typeparam>
    /// <param name="fileName">Json-file name for saving</param>
    /// <param name="value">Value to saving</param>
    /// <param name="filePath">Path to json-file to saving. If you don't want to save the data in any way, use Application.persistentDataPath</param>
    public static void Save<T>(string fileName, string filePath, T value) {
        SaveData(fileName, filePath, value, false);
    }

    /// <summary>
    /// Saves new data in a json file, and encrypt if true.
    /// </summary>
    /// <typeparam name="T">Get generalized type for saving</typeparam>
    /// <param name="fileName">Json-file name for saving</param>
    /// <param name="value">Value to saving</param>
    /// <param name="filePath">Path to json-file to saving. If you don't want to save the data in any way, use Application.persistentDataPath</param>
    public static void Save<T>(string fileName, string filePath, T value, bool encrypt) {
        SaveData(fileName, filePath, value, encrypt);
    }


    /// <summary>
    /// Deserialized and return data from json-file. If this file is not found, or file is null, return default.
    /// </summary>
    /// <typeparam name="T">Return generalized type. Before assigning a value to any field or variable, type conversion must be performed</typeparam>
    /// <param name="fileName">Json-file name for deserialized</param>
    /// <param name="filePath">Path to json-file with saves. If you dont want to load data in any way, use Application.persistentDataPath</param>
    /// <returns>Return value if file is found, and return default if file is not found</returns>
    public static T Load<T>(string fileName, string filePath, T keyNotFound) {
        return LoadData(fileName, filePath, keyNotFound, false);
    }

    /// <summary>
    /// Deserialized and return data from json-file. If this file is not found, or file is null, return default. If you are encrypt file before, use decrypt true.
    /// </summary>
    /// <typeparam name="T">Return generalized type. Before assigning a value to any field or variable, type conversion must be performed</typeparam>
    /// <param name="fileName">Json-file name for deserialized</param>
    /// <param name="filePath">Path to json-file with saves. If you dont want to load data in any way, use Application.persistentDataPath</param>
    /// <returns>Return value if file is found, and return default if file is not found</returns>
    public static T Load<T>(string fileName, string filePath, T keyNotFound, bool decrypt) {
        return LoadData(fileName, filePath, keyNotFound, decrypt);
    }

    private static void NewJsonFile(string filePath) {
        try {
        using(FileStream fileStream = File.Create(filePath)) { onNewJsonFileCreation?.Invoke(); }
        } catch(Exception ex) {
            Debug.Log(ex.Message);
            onNewJsonFileCreationError?.Invoke();
        }
    }
    
    private static bool CheckFileToPath(string filePath) {
        return File.Exists(filePath);
    }
    
    private static string CombinePath(string filePath, string fileName) {
        return Path.Combine(filePath, fileName + ".json");
    }

    private static void WriteFile(string jsonPath, string jsonString) {
        using (StreamWriter streamWriter = new StreamWriter(jsonPath, false)) {
            streamWriter.Write(jsonString);
        }
    }

    private static void SaveData<T>(string fileName, string filePath, T value, bool encrypt) {
        try {
        string jsonPath = CombinePath(filePath, fileName);
        if(!CheckFileToPath(jsonPath)) {
            NewJsonFile(jsonPath);
        }
        string jsonString = JsonConvert.SerializeObject(value, Formatting.Indented);
        if(encrypt) { jsonString = CryptoManager.Encrypt(jsonString); }
        WriteFile(jsonPath, jsonString);
        onSaved?.Invoke();
        } catch(Exception ex) {
            Debug.Log(ex.Message);
            onSavedError?.Invoke();
        }
    }

    private static T LoadData<T>(string fileName, string filePath, T keyNotFound, bool decrypt) {
        try {
        string jsonPath = CombinePath(filePath, fileName);
        if(CheckFileToPath(jsonPath)) {
            string deserializedString = File.ReadAllText(jsonPath);
            if(decrypt) { deserializedString = CryptoManager.Decrypt(deserializedString); }
            if(!string.IsNullOrWhiteSpace(deserializedString)) {
                T deserializedValue = JsonConvert.DeserializeObject<T>(deserializedString);
                onLoad?.Invoke();
                return deserializedValue;
            }
            else {
                StringIsNullLog(jsonPath);
                onLoadError?.Invoke();
                return keyNotFound;
            }
        } else {
            FoundLog(jsonPath);
            onLoadError?.Invoke();
            return keyNotFound;
        }
        } catch(Exception ex) {
            Debug.Log(ex.Message);
            return keyNotFound;
        }
    }

    private static void AvailableLog(string filePath) {
        Debug.Log($"You are try create new json-file, by the path where this file is already available on the way {filePath}");
    }
    private static void StringIsNullLog(string filePath) {
        Debug.Log($"{filePath} is null. You cannot be deserialized empty object");
    }
    private static void FoundLog(string filePath) {
        Debug.Log($"{filePath} is null");
    }
    
}
}
