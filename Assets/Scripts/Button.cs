using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[Header("Objects:")]
	public GameObject door;
	public GameObject trigger;


	[Header("Select Mode:")]
	public bool isDoorMode;
	public bool isTriggerMode;



	void OnMouseEnter()
	{
		if(Application.isMobilePlatform)
		{
		TabButton ();   // Нажатие кнопки с телефона
		}
	}

	void OnMouseOver(){


		if (Input.GetKeyDown (KeyCode.E)) 
		{

			TabButton ();   // Нажатие кнопки с компьютера
		}

	}



	public void TabButton()
	{

		if (isDoorMode && !isTriggerMode)  // Открытие двери
		{
			if (door != null) 
			{
				door.GetComponent<Door> ().Open ();
			}
		}

		if (!isDoorMode && isTriggerMode)   // Включение триггера
		{
			trigger.SetActive (true);
		}

	}


}
