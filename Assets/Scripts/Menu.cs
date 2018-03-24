using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml.Linq;
using System.IO;
using System.Collections;

public class Menu : MonoBehaviour {

	[Header("Windows")]
	public GameObject menuWindow;
	public GameObject gameWindow;

	[Header("Buttons")]
	public GameObject continueButton;
	public GameObject newGameButton;
	public GameObject deleteButton;

	[Header("Slots")]
	public Text[] slotText;
	public GameObject[] outLine;

	[Header("Animators")]
	public Animator menuWindowAnimator;
	public Animator gameWindowAnimator;

	public Text text;

	// PRIVATE
	private CreateDirectory directory = new CreateDirectory ();
	private XML xml = new XML();
	private CreateFile file = new CreateFile();
	private int currentSlot;

	void Start()
	{
		text.text = Application.persistentDataPath;
		}

	void UpdateSaves()
	{
		
		for (byte i = 1; i <= 3; i++) 
		{
			bool checkSave;
			checkSave = directory.Check ("/Saves/Slot" + i);

			if (checkSave)
			{
				slotText [i - 1].text = "Save" + i;
			}
			else
			{
				slotText [i - 1].text = "Empty";
			}
		}


	}  // -----------------------  UpdateSaves ------------------------------------------------

	public void SelectSlot(int id)
	{
		PlayerPrefs.SetInt ("slot", id);
		currentSlot = id;
		bool checkSave;

		checkSave = directory.Check ("/Saves/Slot" + id);

		if (checkSave) 
		{
			continueButton.SetActive (true);
			newGameButton.SetActive (false);
			deleteButton.SetActive (true);
		} 
		else
		{
			continueButton.SetActive (false);
			newGameButton.SetActive (true);
			deleteButton.SetActive (false);
		}

		for (byte i = 0; i < 3; i++) 
		{
			if (i + 1 == id)
			{
				outLine [i].SetActive (true);
				continue;
			}

			outLine [i].SetActive (false);
		}

	} // -----------------------  SelectSlot ------------------------------------------------

	public void OpenGameWindow()
	{
		
		menuWindowAnimator.SetBool("close", true);
		gameWindowAnimator.SetBool("open", true);
		UpdateSaves ();
	}


	public void OpenMenuWindow()
	{
		menuWindowAnimator.SetBool("close", false);
		gameWindowAnimator.SetBool("open", false);

	}

	public void NewGame()
	{
		directory.Create ("/Saves/Slot" + currentSlot);
		xml.CreatePlayerSave ("/Saves/Slot" + currentSlot + "/player.xml");

		SceneManager.LoadScene (2); // Scene01
	}

	public void ContinueGame()
	{
		SceneManager.LoadScene (2);  // Scene01
	}

	public void DeleteGame()
	{
		directory.Delete ("/Saves/Slot" + currentSlot);
		deleteButton.SetActive (false);
		continueButton.SetActive (false);
		UpdateSaves ();
	}

	public void Exit()
	{
		PlayerPrefs.Save ();
		Application.Quit ();
	}


}
