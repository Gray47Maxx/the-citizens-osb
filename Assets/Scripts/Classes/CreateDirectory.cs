using UnityEngine;
using System.IO;
using System.Collections;

public  class CreateDirectory
{



	public void Create(string path)   // СОЗДАНИЕ ДИРЕКТОРИИ 
	{
		if (!Directory.Exists (Application.persistentDataPath + path))
		{
			Directory.CreateDirectory (Application.persistentDataPath + path);
		}

	}

	public void Delete(string path)   // УДАЛЕНИЕ ДИРЕКТОРИИ
	{
		if (Directory.Exists (Application.persistentDataPath + path))
		{
			Directory.Delete (Application.persistentDataPath + path, true);
		}

	}

	public bool Check(string path)   // ПРОВЕРКА НАЛИЧИЯ ДИРЕКТОРИИ
	{
		if (Directory.Exists (Application.persistentDataPath + path)) 
		{
			return true;
		} 
		else 
		{
			return false;
		}

	}




}
