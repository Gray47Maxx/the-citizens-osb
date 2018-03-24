using UnityEngine;
using System.Collections;

public class GroundButton : MonoBehaviour {


	public GameObject door;

	private Player player;

	void Start()
	{

		player = GameObject.Find ("Player").gameObject.GetComponent<Player> ();
	}

	void OnTriggerEnter(Collider col) 
	{

		if (col.tag == "Props") 
		{


			if (player.GetProps == col.gameObject) // Если входящий предмет переносит игрок в руках
			{

				player.Props ();
				col.gameObject.transform.position = transform.position;

				if (door != null) 
				{
					door.GetComponent<Door> ().Open ();
				}
			}
			if (player.GetProps != col.gameObject) // Если входящий предмет не переносит игрок в руках
			{
				
				col.gameObject.transform.position = transform.position;

				if (door != null) 
				{
					door.GetComponent<Door> ().Open ();
				}
			}

		}

	}



}
