using UnityEngine;
using System.IO;
using System.Collections;

public class CreateFile 
{

	private const string format = ".xnb";


	public void Create(string path)  // СОЗДАНИЕ ФАЙЛА
	{
		if (!File.Exists (Application.dataPath + path + format)) 
		{
			FileStream fs = new FileStream (Application.persistentDataPath + path + format, FileMode.Create);
			fs.Close ();
		}
	}




}
