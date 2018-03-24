using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pause : MonoBehaviour {

	[Header("Windows")]
	public GameObject PauseWindow;
	public GameObject SettingsWindow;

	[Header("Sensitivity")]
	public TouchPad pad;
	public Slider sliderX;
	public Slider sliderY;

	// PRIVATE
	private XML xml = new XML();
	private Player player;
	private ObjectsSaver objectsSaver;

	void Awake()
	{
		
		sliderX.value = pad.Xsensitivity;
		sliderY.value = pad.Ysensitivity;

		objectsSaver = transform.GetComponent<ObjectsSaver> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}

	public void OpenPause()
	{
		if (PauseWindow.activeInHierarchy == false) 
		{
			Time.timeScale = 0;
			PauseWindow.SetActive (true);
			SettingsWindow.SetActive (false);
			return;
		}
		if (PauseWindow.activeInHierarchy == true) 
		{
			Time.timeScale = 1;
			PauseWindow.SetActive (false);
			SettingsWindow.SetActive (false);
			return;
		}
	}

	public void OpenSettings()
	{
		if (SettingsWindow.activeInHierarchy == false) 
		{
			SettingsWindow.SetActive (true);
			PauseWindow.SetActive (false);
			return;
		}
		if (SettingsWindow.activeInHierarchy == true) 
		{
			SettingsWindow.SetActive (false);
			PauseWindow.SetActive (true);
			return;
		}

	}

	public void ExitToMenu()
	{
		Time.timeScale = 1;
		player.Save ();
		objectsSaver.Save ();
		SceneManager.LoadScene (1);

	}

	public void SliderX (float i)
	{
		pad.Xsensitivity = i;
	}

	public void SliderY (float i)
	{
		pad.Ysensitivity = i;
	}


}
