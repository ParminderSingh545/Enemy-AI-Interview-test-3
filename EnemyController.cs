using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Player, IMoves
{
	public EnemyController()
	{
		
	}

	~EnemyController()
	{
		
	}

	public void OnUpdate()
	{
		
	}

	public void Move(List<Algos.Point> path,GameObject obj,GameObject obj2)
	{
		Singleton.GetInstance().mgr.StartCoroutine (Move(path,obj,obj2,0.05f));
	}

	public void Shoot()
	{
		GameManager ins = Singleton.GetInstance ().mgr;
		GameObject go = ins.Spawn (ins.bulletObj);
		try 
		{
			go.transform.SetParent(ins.enemyObj.transform,false);
			go.transform.localEulerAngles = new Vector3 (90,0,0);
			go.transform.localPosition = new Vector3(ins.enemyBltPnt.transform.localPosition.x,ins.enemyBltPnt.transform.localPosition.y,ins.enemyBltPnt.transform.localPosition.z);
			ins.ThreatCivilians ();
		} 
		catch (System.Exception ex) 
		{
			GameManager.print ("Game Is Already Over :p \n"+ex.StackTrace);
		}
	}

	public void Look(GameObject obj1,GameObject obj2)
	{
		obj1.transform.LookAt (obj2.transform);
	}

	public IEnumerator Move(List<Algos.Point> path,GameObject obj,GameObject obj2,float speed)
	{
		for(int i = 0; i < path.Count; i++)
		{
			try 
			{
				GameManager ins = Singleton.GetInstance().mgr;
				obj.transform.localPosition = new Vector3 (path[i].x,obj.transform.localPosition.y,path[i].y);
				Look (obj, obj2);
				ins.plrI.Look (obj2,obj);
			} 
			catch (System.Exception ex) 
			{
				GameManager.print ("Game Is Already Over :p \n"+ex.StackTrace);
				break;
			}
			yield return new WaitForSeconds(speed);
		}
		Singleton.GetInstance ().mgr.resartBtn.interactable = true;
	}
}
