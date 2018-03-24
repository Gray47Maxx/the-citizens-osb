using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;

public class ObjectsSaver : MonoBehaviour {

	// PRIVATE
	private GameObject[] objects;
	private int currentSlot;
	private XML xml = new XML ();

	void Start()
	{
		int x = transform.childCount;
		Debug.Log ("Сохранено " + x + " объектов!");
		objects = new GameObject[x];
		currentSlot = PlayerPrefs.GetInt ("slot");

		for(int i = 0; i < x; i++ )  // ПОЛУЧЕНИЕ ДОЧЕРНИХ ОБЪЕКТОВ
		{
			objects[i] = (transform.GetChild(i).gameObject);
		}

		Load ();

		if (!File.Exists (Application.persistentDataPath + "/Saves/Slot" + currentSlot + "/objects.xml")) 
		{
			Save ();
		}

	

	}  // -----------------------  Start ------------------------------------------------


	void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/Saves/Slot" + currentSlot + "/objects.xml"))  
		{
			for (int i = 0; i < objects.Length; i++)
			{
				objects[i].transform.position = xml.GetObjectPosition (currentSlot, i);
				objects[i].transform.eulerAngles = xml.GetObjectRotation (currentSlot, i);
			}
		}
	}


	public void Save()
	{
		xml.SetObjects (currentSlot, objects);
	}


	void OnApplicationQuit()
	{
		Save ();
	}

	void OnApplicationPause()
	{
		if (Application.isMobilePlatform) 
		{
			Save ();
		}
	}


}
