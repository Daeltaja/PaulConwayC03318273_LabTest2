using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int healthAmt = 15;
	public int ammoAmt = 10;

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
