using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	public float time = 5f;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(Move(time));
	}
	
	public IEnumerator Move(float _time)
	{
		for(float t = 0f; t < _time; t = t + Time.deltaTime)
		{
			gameObject.transform.localPosition = new Vector3 (gameObject.transform.localPosition.x,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z+t);
			yield return null;
		}
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		GameManager ins = Singleton.GetInstance ().mgr;
		if (col.gameObject.name == "Enemy")
		{
			ins.enmy.health = ins.enmy.health - 2.5f;
			ins.enmyTxt.text = ins.enmy.health.ToString ();
			CheckDamage (ins.enmy.health,col.gameObject);
		}
		else
		if (col.gameObject.name == "Player")
		{
			ins.plr.health = ins.plr.health - 2.5f;
			ins.plrTxt.text = ins.plr.health.ToString ();
			CheckDamage (ins.plr.health,col.gameObject);
		}
		else
		if (col.gameObject.tag == "people")
		{
			CheckDamage (0, col.gameObject);
		}
	}

	public void CheckDamage(float stats,GameObject obj)
	{
		if (stats <= 0) 
		{
			Destroy (obj);
			Singleton.GetInstance ().mgr.resartBtn.interactable = true;
		}
	}
}
