using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// Convert objects to binary to save
public class PlayerPrefSerialization 
{
	public static BinaryFormatter binary_formater = new BinaryFormatter();


	public static void Save(string key, object obj)
	{
		MemoryStream memory_stream = new MemoryStream();
		binary_formater.Serialize(memory_stream, obj);
		string binary_obj = System.Convert.ToBase64String(memory_stream.ToArray());
		PlayerPrefs.SetString(key, binary_obj);
	}

	public static object Load(string key)
	{
		string binary_obj = PlayerPrefs.GetString(key);
		if(binary_obj == string.Empty)
		{
			return null;
		}
		MemoryStream memory_stream = new MemoryStream(System.Convert.FromBase64String(binary_obj));
		return binary_formater.Deserialize(memory_stream);
	}
}
