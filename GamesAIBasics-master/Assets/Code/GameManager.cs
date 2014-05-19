using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	Object bot, ammo;
	int botCount = 5, ammoCount = 10;
	public List<GameObject> bots = new List<GameObject>();
	public List<GameObject> ammos = new List<GameObject>();
	Vector3 newPos;

	void Start () 
	{
       	//leader.GetComponent<StateMachine>().SwitchState(new IdleState(leader, teaser));
		bot = Resources.Load ("Bot");
		ammo = Resources.Load ("Ammo");
		SpawnBots();
		SpawnAmmo(5);
	}

	void SpawnBots()
	{
		for(int i = 0; i < botCount; i++)
		{
			newPos = new Vector3(Random.Range (-20f, 20f), 0f, Random.Range(-20f, 20f));
			GameObject botIns = Instantiate(bot, newPos, Quaternion.identity) as GameObject;
			botIns.name = "Bot";
			botIns.tag = "BotTag";
			bots.Add(botIns);
			botIns.GetComponent<StateMachine>().SwitchState(new IdleState(botIns, botIns));
		}
	}

	void SpawnAmmo(int quantity)
	{
		for(int i = 0; i < ammoCount; i++)
		{
			newPos = new Vector3(Random.Range (-20f, 20f), 0f, Random.Range(-20f, 20f));
			GameObject ammoIns = Instantiate(ammo, newPos, Quaternion.identity) as GameObject;
			ammoIns.name = "Ammo";
			ammoIns.tag = "AmmoTag";
			//add ammo quantity
			bots.Add(ammoIns);
		}
	}
}
