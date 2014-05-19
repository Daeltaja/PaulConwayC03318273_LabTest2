using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int healthAmt = 15;
	public int ammoAmt = 10;
	GameManager gm;

	void Start()
	{
		gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void Update()
	{
		if(ammoAmt == 0)
		{
			FindAmmo();
		}
		if(healthAmt <= 10)
		{
			FindHealth();
		}
		if(healthAmt <= 0)
		{
			gm.bots.Remove(gameObject);
			Destroy(gameObject);
		}
	}



	void FindAmmo()
	{
		GetComponent<StateMachine>().SwitchState(new GetAmmoState(gameObject));
	}

	void FindHealth()
	{
		//GET HEALTH STATE GetComponent<StateMachine>().SwitchState(new GetAmmoState(gameObject));
	}
}
