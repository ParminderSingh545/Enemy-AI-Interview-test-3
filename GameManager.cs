using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public Algos alg;
	public PlayerController plr;
	public EnemyController enmy;
	public IMoves plrI;
	public IMoves enmI;
	public bool IsInitialized = false;

	public GameObject arrivalPlace;
	public GameObject destPlace;

	public int maxSteps = 20;

	public GameObject mainObj;

	public GameObject path;
	public GameObject pathParent;

	public GameObject bulletObj;
	public GameObject bullets;

	public bool drawPath = false;

	public GameObject plrObj;
	public GameObject plrBltPnt;
	public Text plrTxt;

	public GameObject enemyObj;
	public GameObject enemyBltPnt;
	public Text enmyTxt;

	public GameObject civiliansParent;
	public GameObject civilianObj;
	private GameObject[] civilians;

	public Button resartBtn;

	// Use this for initialization
	void Start ()
	{
		Singleton.GetInstance ().mgr = this;;
		alg = new Algos ();
		plr = new PlayerController ();
		enmy = new EnemyController ();
		plrI = plr;
		enmI = enmy;

		GenrateCivilians (10,80,80);	//	genrates non-repetable cordinates for civilians
		GenratePath ();					//	genrates random path

		IsInitialized = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (IsInitialized) 
		{
			plrI.OnUpdate ();
			enmI.OnUpdate ();
		}
	}

	public GameObject Spawn(GameObject obj)
	{
		return Instantiate (obj,obj.transform.localPosition,Quaternion.identity) as GameObject;
	}

	public void GenrateCivilians(int num, int xLim, int yLim)
	{
		int[,] cordsArr = new int[yLim,xLim];

		int[,] cordsList = alg.GetCords (num,cordsArr,xLim,yLim);
		civilians = new GameObject[num];

		for (int i = 0; i < num; i++) 
		{	
			if (cordsList [i, 0] > xLim / 2) 
			{
				cordsList [i, 0] = (xLim / 2) - cordsList[i , 0];
			}
			if (cordsList[i , 1] > yLim / 2) 
			{
				cordsList[i , 1] = (yLim / 2) - cordsList[i , 1];
			}
			civilians [i] = Spawn (civilianObj);	
			civilians [i].transform.localPosition = new Vector3(cordsList[i,0],civilians[i].transform.localPosition.y,cordsList[i,1]);
			civilians [i].transform.SetParent (civiliansParent.transform,false);
		}
	}

	public void GenratePath()
	{
		int[] apos = new int[2];
		int[] dpos = new int[2];

		apos [0] = (int)enemyObj.transform.localPosition.x;
		apos [1] = (int)enemyObj.transform.localPosition.z;
		dpos [0] = (int)destPlace.transform.localPosition.x;
		dpos [1] = (int)destPlace.transform.localPosition.z;

		List<Algos.Point> paths = alg.CreatePath (apos,dpos,maxSteps);

		if (drawPath) 
		{
			for(int i = 0; i < paths.Count; i++)
			{
				GameObject go = Spawn (path);
				go.transform.localPosition = new Vector3 (paths[i].x,go.transform.localPosition.y,paths[i].y);
				go.transform.SetParent (pathParent.transform,false);
			}
		}

		enmy.Move (paths,enemyObj,plrObj);
	}

	public void ThreatCivilians()
	{
		for (int i = 0; i < civilians.Length; i++) 
		{
			StartCoroutine (civilians [i].GetComponent<CivilianController> ().RunAway ());
		}
	}

	public void OnRestartLevel()
	{
		resartBtn.interactable = false;
		Application.LoadLevel ("Main");
	}

}
