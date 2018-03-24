using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PropsMenu : MonoBehaviour {

	public GameObject button_prefab;
	public GameObject props_list;
	public GameObject camera;


	
	public void SetPropsMenu()
	{
		if (props_list.activeSelf == false) 
		{
			props_list.SetActive (true);
			return;
		}
		if (props_list.activeSelf == true) 
		{
			props_list.SetActive (false);
			return;
		}
	}

	public void CreateProps(string name)
	{
		
		GameObject ga = Instantiate (Resources.Load("Props/" + name, typeof(GameObject))) as GameObject;
		ga.transform.position = camera.transform.position;
		ga.transform.rotation = camera.transform.rotation;
		ga.transform.Translate(new Vector3(0,0,1));

	}


}
