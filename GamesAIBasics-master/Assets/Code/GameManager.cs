using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	Object bot, ammo;
	int botCount = 5, ammoCount = 10;
	public List<GameObject> bots = new List<GameObject>();
	public List<GameObject> ammos = new List<GameObject>();
	Vector3 newPos;
	bool spawnBot, spawnAmmo;

	void Start () 
	{
		bot = Resources.Load ("Bot");
		ammo = Resources.Load ("Ammo");
		for(int i = 0; i < botCount; i++)
		{
			SpawnBot();
		}
		for(int a = 0; a < ammoCount; a++)
		{
			SpawnAmmo();
		}
	}

	void Update()
	{
		if(bots.Count < botCount)
		{
			if(!spawnBot)
			{
				Invoke("SpawnBot", 10f);
				spawnBot = true;
			}
		}
		if(ammos.Count < ammoCount)
		{
			if(!spawnAmmo)
			{
				Invoke("SpawnAmmo", 10f);
				spawnAmmo = true;
			}
		}
		Debug.Log (ammos.Count);
	}
	
	void SpawnBot()
	{
		newPos = new Vector3(Random.Range (-20f, 20f), 0f, Random.Range(-20f, 20f));
		GameObject botIns = Instantiate(bot, newPos, Quaternion.identity) as GameObject;
		botIns.name = "Bot";
		botIns.tag = "BotTag";
		bots.Add(botIns);
		botIns.GetComponent<StateMachine>().SwitchState(new IdleState(botIns, botIns));
		spawnBot = false;
	}

	void SpawnAmmo()
	{
		newPos = new Vector3(Random.Range (-20f, 20f), 0f, Random.Range(-20f, 20f));
		GameObject ammoIns = Instantiate(ammo, newPos, Quaternion.identity) as GameObject;
		ammoIns.name = "Ammo";
		ammoIns.tag = "AmmoTag";
		ammos.Add(ammoIns);
		spawnAmmo = false;
	}
}
