using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player , IMoves
{
	public PlayerController()
	{
		
	}

	~PlayerController()
	{

	}

	public new void OnUpdate()
	{
		if (Input.GetMouseButtonDown (0))
		{	
			Shoot();
		}
	}

	public void Shoot()
	{
		GameManager ins = Singleton.GetInstance ().mgr;
		GameObject go = ins.Spawn (ins.bulletObj);
		go.transform.SetParent (ins.plrObj.transform,false);
		go.transform.localEulerAngles = new Vector3 (90,0,0);
		go.transform.localPosition = ins.plrBltPnt.transform.localPosition;
		ins.enmI.Shoot ();
	}

	public void Look(GameObject obj1,GameObject obj2)
	{
		obj1.transform.LookAt (obj2.transform);
	}
}
