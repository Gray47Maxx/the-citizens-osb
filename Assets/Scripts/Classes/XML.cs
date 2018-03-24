using UnityEngine;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class XML : MonoBehaviour {



	public void CreatePlayerSave(string path)   // СОЗДАНИЕ НАЧАЛЬНОГО ФАЙЛА ПРИ НОВОЙ ИГРЕ
	{
		XAttribute x = new XAttribute ("x", 5);
		XAttribute y = new XAttribute ("y", 1);
		XAttribute z = new XAttribute ("z", 6);

		XAttribute x2 = new XAttribute ("x", 0);
		XAttribute y2 = new XAttribute ("y", 180);
		XAttribute z2 = new XAttribute ("z", 0);

		XElement pos = new XElement ("Position",  x, y, z , "");
		XElement rot = new XElement ("Rotation",  x2, y2, z2 , "");
		XElement data = new XElement ("data");

		data.Add (new XElement ("hp",100), pos, rot);
		XDocument doc = new XDocument (data);
		File.WriteAllText (Application.persistentDataPath +  path , doc.ToString());

	}



	public int GetPlayerHp(int slot)          // ПОЛУЧЕНИЕ ХП ИГРОКА ИЗ ФАЙЛА
	{
		XElement data ;

		data = XDocument.Parse (File.ReadAllText (Application.persistentDataPath + "/Saves/Slot" + slot + "/player.xml")).Element("data");

		return int.Parse(data.Element("hp").Value);

	}


	public Vector3 GetPlayerPosition(int slot)   //ПОЛУЧЕНИЕ ПОЗИЦИИ ИГРОКА ИЗ ФАЙЛА
	{
		XElement data ;

		data = XDocument.Parse (File.ReadAllText (Application.persistentDataPath + "/Saves/Slot" + slot + "/player.xml")).Element("data");

		float x = float.Parse(data.Element ("Position").Attribute ("x").Value);
		float y = float.Parse(data.Element ("Position").Attribute ("y").Value);
		float z = float.Parse(data.Element ("Position").Attribute ("z").Value);

		Vector3 position = new Vector3 (x,y,z);

		return position;

	}

	public Vector3 GetPlayerRotation(int slot)   // ПОЛУЧЕНИЕ ВРАЩЕНИЯ ИГРОКА ИЗ ФАЙЛА
	{
		XElement data ;

		data = XDocument.Parse (File.ReadAllText (Application.persistentDataPath + "/Saves/Slot" + slot + "/player.xml")).Element("data");

		float x = float.Parse(data.Element ("Rotation").Attribute ("x").Value);
		float y = float.Parse(data.Element ("Rotation").Attribute ("y").Value);
		float z = float.Parse(data.Element ("Rotation").Attribute ("z").Value);

		Vector3 rotation = new Vector3 (x,y,z);

		return rotation;

	}
	 
	public void SetPlayer(int slot, int hp, Transform transform)  // СОХРАНЕНИЕ ХП И ПОЗИЦИИ ИГРОКА В ФАЙЛ
	{
		
		XAttribute x = new XAttribute ("x", transform.position.x);
		XAttribute y = new XAttribute ("y", transform.position.y);
		XAttribute z = new XAttribute ("z", transform.position.z);

		XAttribute x2 = new XAttribute ("x", transform.eulerAngles.x);
		XAttribute y2 = new XAttribute ("y", transform.eulerAngles.y);
		XAttribute z2 = new XAttribute ("z", transform.eulerAngles.z);

		XElement pos = new XElement ("Position",  x, y, z , "");
		XElement rot = new XElement ("Rotation",  x2, y2, z2 , "");
		XElement data = new XElement ("data");

		data.Add (new XElement ("hp", hp), pos, rot);
		XDocument doc = new XDocument (data);

		File.WriteAllText (Application.persistentDataPath + "/Saves/Slot" + slot + "/player.xml" , doc.ToString());
	}


	public void SetObjects(int slot, GameObject[] objects)    // СОХРАНЕНИЕ ДАННЫХ ВСЕХ ОБЪЕКТОВ В ФАЙЛ
	{
		XElement data = new XElement ("data");

		for (int i = 0; i < objects.Length; i++) 
		{
			XAttribute x = new XAttribute ("x", objects[i].transform.position.x);
			XAttribute y = new XAttribute ("y", objects[i].transform.position.y);
			XAttribute z = new XAttribute ("z", objects[i].transform.position.z);

			XAttribute x2 = new XAttribute ("x", objects[i].transform.eulerAngles.x);
			XAttribute y2 = new XAttribute ("y", objects[i].transform.eulerAngles.y);
			XAttribute z2 = new XAttribute ("z", objects[i].transform.eulerAngles.z);


			XElement obj = new XElement ("Object" + i);
			XElement pos = new XElement ("position" ,  x, y, z , "");
			XElement rot = new XElement ("rotation",  x2, y2, z2 , "");

			obj.Add (pos, rot);
			data.Add (obj);
		}

		XDocument doc = new XDocument (data);

		File.WriteAllText (Application.persistentDataPath + "/Saves/Slot" + slot + "/objects.xml" , doc.ToString());

	}

	public Vector3 GetObjectPosition(int slot, int id)  // ПОЛУЧЕНИЕ ПОЗИЦИИ ДАННОГО ОБЪЕКТА
	{
		XElement data ;
		Vector3 position;

		data = XDocument.Parse (File.ReadAllText (Application.persistentDataPath + "/Saves/Slot" + slot + "/objects.xml")).Element("data");


		position.x = float.Parse(data.Element ("Object" + id).Element("position").Attribute ("x").Value);
		position.y = float.Parse(data.Element ("Object" + id).Element("position").Attribute ("y").Value);
		position.z = float.Parse(data.Element ("Object" + id).Element("position").Attribute ("z").Value);

		return position;

	}

	public Vector3 GetObjectRotation(int slot, int id)  // ПОЛУЧЕНИЕ ВРАЩЕНИЯ ДАННОГО ОБЪЕКТА
	{
		XElement data ;
		Vector3 rotation;

		data = XDocument.Parse (File.ReadAllText (Application.persistentDataPath + "/Saves/Slot" + slot + "/objects.xml")).Element("data");

		rotation.x = float.Parse(data.Element ("Object" + id).Element("rotation").Attribute ("x").Value);
		rotation.y = float.Parse(data.Element ("Object" + id).Element("rotation").Attribute ("y").Value);
		rotation.z = float.Parse(data.Element ("Object" + id).Element("rotation").Attribute ("z").Value);

		return rotation;

	}


}
