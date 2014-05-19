using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int healthAmt = 10;
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
		if(healthAmt <= 5)
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
		GetComponent<StateMachine>().SwitchState(new GetHealthState(gameObject));
	}
}
