using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoves 
{
	void OnUpdate();
	void Shoot();
	void Look (GameObject obj1, GameObject obj2);
}
