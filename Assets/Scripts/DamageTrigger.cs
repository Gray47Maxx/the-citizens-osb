using UnityEngine;
using System.Collections;

public class DamageTrigger : MonoBehaviour {


	public int damage = 1;
	public float time = 0.2f;

	private Player player;
	private float _time;


	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			_time = time;

			if (player == null)
			{
				if (col.gameObject.GetComponent<Player> ()) 
				{
					player = col.gameObject.GetComponent<Player> ();
				}
			}
			player.Hit (1);
		}
	}


	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player") 
		{
			if (_time > 0) 
			{
				_time -= Time.deltaTime;
			}
			if (_time <= 0) 
			{
				player.Hit (1);
				_time = time;
			}
		}

	}



}
