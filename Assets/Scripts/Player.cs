using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Xml.Linq;
using System.Collections;

public class Player : MonoBehaviour {


	public static int hp = 100;
	public Text hp_bar;
	public GameObject take_button;
	public GameObject drop_button;
	public static Player player;
	public GameObject dieWindow;

	// PRIVATE
	private int currentSlot;
	private XML xml = new XML();
	private GameObject camera;
	private GameObject props;

	public void Awake()
	{
		currentSlot = PlayerPrefs.GetInt ("slot");
		camera = transform.Find("Camera").gameObject;
		Load();
		player = this;
	
	}

	public void Update()
	{

		if (props != null)
		{
			props.transform.rotation = Quaternion.identity;

			if (Input.GetAxis ("Mouse ScrollWheel") > 0 && props.transform.localPosition.z < 2f) 
			{
				props.transform.localPosition = props.transform.localPosition + new Vector3(0,0,0.2f) ;
			}

			if (Input.GetAxis ("Mouse ScrollWheel") < 0 && props.transform.localPosition.z > 0.8f)
			{
				props.transform.localPosition = props.transform.localPosition - new Vector3(0,0,0.2f) ;
			}
		}

		if (props == null) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay( new Vector3(Screen.width/2, Screen.height/2, 0));

			if (Physics.Raycast (ray, out hit, 3))   // Проверка предмета перед нами
				if (hit.collider.gameObject.tag == "Props") 
			{
					take_button.SetActive (true);
					drop_button.SetActive (false);
			}

			else 
			{
					take_button.SetActive (false);
			}
		} 


		if (Input.GetKeyDown (KeyCode.E) )
		{
			Props ();
		}

	
}
			
	public GameObject GetProps
	{
		get
		{
		return props;
		}
	}

	public void Props()
	{
		if (props != null) // Выбрасывание предмета
		{

			props.transform.SetParent (null);
			props.GetComponent<MeshCollider> ().convex = true;
			props.GetComponent<Rigidbody> ().isKinematic = false;
			props.GetComponent<Rigidbody> ().useGravity = true;
			props.layer = 0;
			drop_button.SetActive (false);
			props = null;
			return;
		}

		if (props == null)  // Подбирание предмета
	      {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay( new Vector3(Screen.width/2, Screen.height/2, 0));
			if (Physics.Raycast (ray, out hit, 3))
			{
				if(hit.collider.gameObject.tag == "Props")
				{
					
					props = hit.collider.gameObject;
					props.GetComponent<Rigidbody> ().useGravity = false;
					props.GetComponent<Rigidbody> ().isKinematic = true;
					props.GetComponent<MeshCollider> ().convex = false;
					props.layer = 2;
					props.gameObject.transform.SetParent (camera.transform);
					props.transform.rotation = Quaternion.identity;  

					props.transform.localPosition = new Vector3(0,0,1.2f) ;
					take_button.SetActive (false);
					drop_button.SetActive (true);

				}

			}
			return;
		}
	}     //  --------------------    Props     -----------------------------------

	public void Hit(int damage)
	{
		if (hp > 0)
		{
			hp -= damage;
			hp_bar.text = hp.ToString();
		}
		if (hp <= 0) 
		{
			dieWindow.SetActive (true);
			Time.timeScale = 0;
			GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

	}

	public void Restart()
	{
		Time.timeScale = 1;
		GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = true;
		hp = 100;
		Save ();

		SceneManager.LoadScene (2);
	}


	void Load()
	{
		transform.position = xml.GetPlayerPosition (currentSlot);   
		transform.eulerAngles = xml.GetPlayerRotation (currentSlot);
		hp = xml.GetPlayerHp(currentSlot);
		hp_bar.text = hp.ToString();
	}

	public void Save()
	{
		xml.SetPlayer (currentSlot, hp, this.transform);
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
