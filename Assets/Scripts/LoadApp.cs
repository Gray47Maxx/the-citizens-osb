using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;


public class LoadApp : MonoBehaviour {

	public float _time = 1f;

	// PRIVATE
	private bool startTimer = false;
	private CreateDirectory directory = new CreateDirectory ();


	void Start()
	{


		directory.Create ("/Saves");


		if (!PlayerPrefs.HasKey ("slot")) 
		{
			PlayerPrefs.SetInt ("slot", 1);
		}
	

		startTimer = true;

	}

	void Update()
	{
		if (_time > 0 && startTimer == true) 
		{
			_time -= Time.deltaTime;
		}

		if (_time <= 0 ) 
		{
			SceneManager.LoadScene(1);  // MENU
		}

		if (Input.anyKeyDown) 
		{
			_time = 0;
		}

	}






}
