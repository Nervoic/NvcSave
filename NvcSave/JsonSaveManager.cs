
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;


namespace NvcUtils.NvcSave {
public static class JsonSaveManager
{
    private static readonly string key = "your-128-196-256-bit-key";
    private static readonly string iv = "your-128-bit-iv";

    /// <summary>
    /// Added new empty json-file
    /// </summary>
    /// <param name="fileName">New json-file name</param>
    /// <param name="filePath">Path to save new json-file</param>
    public static void AddJsonFile(string fileName, string filePath) {
        string jsonPath = Path.Combine(filePath, fileName + ".json");
        if(!CheckFileToPath(jsonPath)) {
        NewJsonFile(jsonPath);
        } else {
            AvailableLog(jsonPath);
        }
    }

    /// <summary>
    /// Saves new data in a json file, if it does not exist yet. If this file is not found, creates a new file and saves the data there.
    /// </summary>
    /// <typeparam name="T">Get generalized type for saving</typeparam>
    /// <param name="fileName">Json-file name for saving</param>
    /// <param name="value">Value to saving</param>
    /// <param name="filePath">Path to json-file to saving. If you don't want to save the data in any way, use Application.persistentDataPath</param>
    public static void Save<T>(string fileName, string filePath, T value) {
        string jsonPath = Path.Combine(filePath, fileName + ".json");
        if(!CheckFileToPath(jsonPath)) {
            NewJsonFile(jsonPath);
        }
        string deserializedString = File.ReadAllText(jsonPath);
        if(string.IsNullOrWhiteSpace(deserializedString)) {
            string jsonString = JsonConvert.SerializeObject(value, Formatting.Indented);
            jsonString = Encrypt(jsonString);
            File.WriteAllText(jsonPath, jsonString);
        } else {
            OverwriteLog(jsonPath);
        }
    }

    /// <summary>
    /// Saves new data in a json-file, and overwrite if isOverwrite. If this file is not found, creates a new file and saves data there.
    /// </summary>
    /// <typeparam name="T">Get generalized type for saving</typeparam>
    /// <param name="fileName">Json-file name for saving</param>
    /// <param name="filePath">Path to json-file to saving. If you dont want to save the data in any way, use Application.persistentDataPath</param>
    /// <param name="value">Value to saving</param>
    /// <param name="isOverwrite">Boolean variable that determines whether to overwrite the value if it already exists in the json-file</param>
    public static void Save<T>(string fileName, string filePath, T value, bool isOverwrite) {
        string jsonPath = Path.Combine(filePath, fileName + ".json");
        if(!CheckFileToPath(jsonPath)) {
            NewJsonFile(jsonPath);
        }
        string deserializedString = File.ReadAllText(jsonPath);
        if(string.IsNullOrWhiteSpace(deserializedString) || isOverwrite) {
            string jsonString = JsonConvert.SerializeObject(value, Formatting.Indented);
            jsonString = Encrypt(jsonString);
            File.WriteAllText(jsonPath, jsonString);
        } else {
            OverwriteLog(jsonPath);
        }
    }

    /// <summary>
    /// Overwrite all data in a json-file. If this file is not found, creates a new file and saves data there.
    /// </summary>
    /// <typeparam name="T">Get generalized type for saving</typeparam>
    /// <param name="fileName">Json-file name for overwrite</param>
    /// <param name="value">Value to overwrite</param>
    /// <param name="filePath">Path to json-file to overwrite. If you dont want to save the data in any way, use Application.persistentDataPath</param>
    public static void OverwriteAll<T>(string fileName, T value, string filePath) {
        string jsonPath = Path.Combine(filePath, fileName + ".json");
        if(!CheckFileToPath(jsonPath)) {
            NewJsonFile(jsonPath);
        }
        string jsonString = JsonConvert.SerializeObject(value, Formatting.Indented);
        jsonString = Encrypt(jsonString);
        File.WriteAllText(jsonPath, jsonString);
    }


    /// <summary>
    /// Deserialized and return data from json-file. If this file is not found, return default.
    /// </summary>
    /// <typeparam name="T">Return generalized type. Before assigning a value to any field or variable, type conversion must be performed</typeparam>
    /// <param name="fileName">Json-file name for deserialized</param>
    /// <param name="filePath">Path to json-file with saves. If you dont want to load data in any way, use Application.persistentDataPath</param>
    /// <returns>Return value if file is found, and return default if file is not found</returns>
    public static T Load<T>(string fileName, string filePath) {
        string jsonPath = Path.Combine(filePath, fileName + ".json");
        if(CheckFileToPath(jsonPath)) {
            string deserializedString = File.ReadAllText(jsonPath);
            deserializedString = Decrypt(deserializedString);
            if(!string.IsNullOrWhiteSpace(deserializedString)) {
                T deserializedValue = JsonConvert.DeserializeObject<T>(deserializedString);
                return deserializedValue;
            }
            else {
                StringIsNullLog(jsonPath);
                return default;
            }
        } else {
            FoundLog(jsonPath);
            return default;
        }
    }

    /// <summary>
    /// Deserialized and return data from json-file. If this file is not found, return keyNotFound
    /// </summary>
    /// <typeparam name="T">Return generalized type. Before assigning a value to any field or variable, type conversion must be performed</typeparam>
    /// <param name="fileName">Json-file name for deserialized</param>
    /// <param name="filePath">Path to json-file with saves. If you dont want to load data in any way, use Application.persistentDataPath</param>
    /// <param name="keyNotFound">Return, if file is not found to filePath, or if file is null</param>
    /// <returns>Return value if file is found, and return keyNotFound if file is not found</returns>
    public static T TryLoad<T>(string fileName, string filePath, T keyNotFound) {
        string jsonPath = Path.Combine(filePath, fileName + ".json");
        if(CheckFileToPath(jsonPath)) {
            string deserializedString = File.ReadAllText(jsonPath);
            deserializedString = Decrypt(deserializedString);
            if(!string.IsNullOrWhiteSpace(deserializedString)) {
                T deserializedValue = JsonConvert.DeserializeObject<T>(deserializedString);
                return deserializedValue;
            } else {
                StringIsNullLog(jsonPath);
                return keyNotFound;
            }
        } else {
            FoundLog(jsonPath);
            return keyNotFound;
        }
    }



    private static void NewJsonFile(string filePath) {
        using(FileStream fileStream = File.Create(filePath)) {}
    }
    
    private static bool CheckFileToPath(string filePath) {
        if(File.Exists(filePath)) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Encrypt string
    /// </summary>
    /// <param name="stringToEncrypt">String to encrypt</param>
    /// <returns>Return encrypted and converted to string string</returns>
    private static string Encrypt(string stringToEncrypt) {
        using(Aes aes = Aes.Create()) {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform cryptoTransform = aes.CreateEncryptor();

            using(MemoryStream memoryStream = new MemoryStream()) {
                using(CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write)) {
                    using(StreamWriter streamWriter = new StreamWriter(cryptoStream)) {
                        streamWriter.Write(stringToEncrypt);
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
    }
    /// <summary>
    /// Decrypt string
    /// </summary>
    /// <param name="stringToDecrypt">String to decrypt</param>
    /// <returns>Return decrypted string</returns>
    private static string Decrypt(string stringToDecrypt) {
        using(Aes aes = Aes.Create()) {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform cryptoTransform = aes.CreateDecryptor();
            byte[] bytes = Convert.FromBase64String(stringToDecrypt);

            using(MemoryStream memoryStream = new MemoryStream(bytes)) {
                using(CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read)) {
                    using(StreamReader streamReader = new StreamReader(cryptoStream)) {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

    private static void AvailableLog(string filePath) {
        Debug.Log($"You are try create new json-file, by the path where this file is already available on the way {filePath}");
    }
    private static void OverwriteLog(string filePath) {
        Debug.Log($"You are try saving data in json-file, which already contains the data to {filePath}. If you are need overwrite json-file, use OverwriteAll function");
    }
    private static void StringIsNullLog(string filePath) {
        Debug.Log($"{filePath} is null. You cannot be deserialized empty object");
    }
    private static void FoundLog(string filePath) {
        Debug.Log($"{filePath} is null");
    }
    
}
}
