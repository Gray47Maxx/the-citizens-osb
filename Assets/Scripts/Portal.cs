using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	[Header("Portals:")]
	public GameObject red_portal;
	public GameObject blue_portal;
	[Header("Select Mode:")]
	public bool isRed;
	public bool isBlue;


	private bool canUse = true;




	void OnTriggerEnter(Collider col)
	{

		if (col.tag == "Player" || col.tag == "Props") 
		{
			if (canUse == true) 
			{
				if (isRed && !isBlue) 
				{
					if (col.tag == "Props") 
					{
						Player.player.Props ();
					}

					col.gameObject.transform.position = blue_portal.transform.position;
					blue_portal.GetComponent<Portal> ().canUse = false;

					canUse = false;
				}
				if (!isRed && isBlue)
				{
					if (col.tag == "Props")
					{
						Player.player.Props ();
					}

					col.gameObject.transform.position = red_portal.transform.position;
					red_portal.GetComponent<Portal> ().canUse = false;

					canUse = false;
				}
			}
		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player" || col.tag == "Props")
		{
			canUse = true;
		}

	}
}
