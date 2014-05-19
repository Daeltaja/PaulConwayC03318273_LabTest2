using System;
using System.Collections.Generic;
using UnityEngine;

public class IdleState: State
{
    static Vector3 initialPos = Vector3.zero;
    GameObject enemyGameObject;
	GameManager gm;

    public override string Description()
    {
        return "Idle State";
    }

    public IdleState(GameObject myGameObject, GameObject enemyGameObject)
        : base(myGameObject)
    {
        this.enemyGameObject = enemyGameObject;
    }

    public override void Enter()
    {
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-30f, 30f), 0, UnityEngine.Random.Range(-30f, 30f)));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-30f, 30f), 0, UnityEngine.Random.Range(-30f, 30f)));
        myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
        myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
		gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
    }
    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Clear();
    }

    public override void Update()
    {
		
		for(int i = 0; i < gm.bots.Count; i++)
		{
			if(gm.bots[i].name == "Bot")
			{
				float range = 10f;    
				float fov = Mathf.PI / 4.0f;
				float angle;
				//enemyGameObject = GameObject.Find ("Bot");
				Vector3 toEnemy = (gm.bots[i].transform.position - myGameObject.transform.position);
				toEnemy.Normalize();
				angle = (float) Math.Acos(Vector3.Dot(toEnemy, myGameObject.transform.forward));
				
				if (angle < fov) //is the enemy in my field of view?
				{
					if ((gm.bots[i].transform.position - myGameObject.transform.position).magnitude < range)
					{
						myGameObject.GetComponent<StateMachine>().SwitchState(new AttackingState(myGameObject, gm.bots[i].gameObject));
					}
				}
			}
		}
    }
}
