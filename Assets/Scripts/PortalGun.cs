using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour {


	public float distance = 10f;

	[Header("Portals:")]
	public GameObject red_portal;
	public GameObject blue_portal;

		

	void Update () 
	{
	
		if (!Application.isMobilePlatform)
		{
			if (Input.GetKeyDown (KeyCode.Mouse0))
			{
			
				CreateRedPortal ();  
			}
		

			if (Input.GetKeyDown (KeyCode.Mouse1))
			{
			
				CreateBluePortal ();
			}
		}

	}
		
	public void CreateRedPortal()
	{

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay( new Vector3(Screen.width/2, Screen.height/2, 0));

		if (Physics.Raycast (ray, out hit, distance)) 
		{

			if (hit.collider.gameObject.tag == "PortalArea") 
			{
				red_portal.transform.position = hit.point + new Vector3(0,0.2f,0);
			}

		}
	}

	public void CreateBluePortal()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay( new Vector3(Screen.width/2, Screen.height/2, 0));

		if (Physics.Raycast (ray, out hit, distance)) 
		{
			if (hit.collider.gameObject.tag == "PortalArea")
			{
				blue_portal.transform.position = hit.point;
			}
		}
	}





}
