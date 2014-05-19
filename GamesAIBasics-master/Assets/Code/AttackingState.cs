using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

class AttackingState:State
{
    float timeShot = 0.25f;
    GameObject enemyGameObject;
	GameManager gm;


    public override string Description()
    {
        return "Attacking State";
    }

    public AttackingState(GameObject myGameObject, GameObject enemyGameObject):base(myGameObject)
    {
        this.enemyGameObject = enemyGameObject;
    }

    public override void Enter()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().OffsetPursuitEnabled = true;
        myGameObject.GetComponent<SteeringBehaviours>().offsetPursuitOffset = new Vector3(0, 0, 5);
        myGameObject.GetComponent<SteeringBehaviours>().offsetPursueTarget = enemyGameObject;
		gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {




        float range = 10.0f;
        timeShot += Time.deltaTime;
        float fov = Mathf.PI / 4.0f;
        // Can I see the enemy?

	    float angle;
	    Vector3 toEnemy = (enemyGameObject.transform.position - myGameObject.transform.position);
	    toEnemy.Normalize();
	    angle = (float) Math.Acos(Vector3.Dot(toEnemy, myGameObject.transform.forward));
	    if (angle < fov)
	    {
	        if (timeShot > 0.25f)
	        {
	            GameObject lazerGO = GameObject.Find ("Lazer");
				GameObject lazerSpawn = myGameObject.transform.GetChild(0).gameObject;
				GameObject lazer = MonoBehaviour.Instantiate(lazerGO, lazerSpawn.transform.position, lazerSpawn.transform.rotation) as GameObject;
				lazer.transform.forward = lazerSpawn.transform.forward;
				lazer.AddComponent<DestroyTimer>();
				lazer.name = "Laser";
	            timeShot = 0.0f;
				myGameObject.GetComponent<Inventory>().ammoAmt --;
	        }
	    }
		else
		{
			myGameObject.GetComponent<StateMachine>().SwitchState(new IdleState(myGameObject, enemyGameObject));
		}

    }
}
