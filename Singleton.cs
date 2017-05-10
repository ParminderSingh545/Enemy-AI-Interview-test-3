using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton 
{
	private Singleton()
	{
		
	}

	~Singleton()
	{

	}

	private static Singleton ins = null;

	public static Singleton GetInstance()
	{
		Singleton lclins = ins;

		if (lclins == null) 
		{
			lclins = new Singleton ();
			ins = lclins;
		} 
		else 
		{
			lclins = ins;
		}

		return lclins;
	}

	public GameManager mgr;
}
