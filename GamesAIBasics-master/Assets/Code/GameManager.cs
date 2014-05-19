using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	Object bot, ammo, health;
	int botCount = 5, ammoCount = 10, healthCount = 3;
	public List<GameObject> bots = new List<GameObject>();
	public List<GameObject> ammos = new List<GameObject>();
	public List<GameObject> healths = new List<GameObject>();
	Vector3 newPos;
	bool spawnBot, spawnAmmo, spawnHealth;

	void Start () 
	{
		bot = Resources.Load ("Bot");
		ammo = Resources.Load ("Ammo");
		health = Resources.Load ("Health");
		for(int i = 0; i < botCount; i++)
		{
			SpawnBot();
		}
		for(int a = 0; a < ammoCount; a++)
		{
			SpawnAmmo();
		}
		for(int h = 0; h < healthCount; h++)
		{
			SpawnHealth();
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
		if(healths.Count < healthCount)
		{
			if(!spawnHealth)
			{
				Invoke("SpawnHealth", 10f);
				spawnHealth = true;
			}
		}
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

	void SpawnHealth()
	{
		newPos = new Vector3(Random.Range (-20f, 20f), 0f, Random.Range(-20f, 20f));
		GameObject healthIns = Instantiate(health, newPos, Quaternion.identity) as GameObject;
		healthIns.name = "Health";
		healthIns.tag = "HealthTag";
		healths.Add(healthIns);
		spawnHealth = false;
	}
}
