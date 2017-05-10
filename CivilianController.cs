using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
		
	public int maxT = 10;

	public IEnumerator RunAway()
	{
		int direction = 0;
		int steps = 0;
	
		direction = Random.Range (0,3);
		steps = Random.Range (2, maxT);

		for(float t = 0f; t < steps; t++)
		{
			if (direction == 0) 
			{
				// run left
				gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - 1,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);
			}
			else
				if (direction == 1) 
				{
					// run right
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 1,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);
				}
				else
					if (direction == 2) 
					{
						// run up
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z + 1);
					}
					else
						if (direction == 3) 
						{
							// run down
							gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z - 1);
						}
			yield return new WaitForSeconds(0.05f);
		}
	}
}
