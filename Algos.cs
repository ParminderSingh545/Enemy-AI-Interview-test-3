using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algos 
{
	public Algos()
	{
		
	}

	~Algos()
	{
		
	}

	public int[,] GetCords(int num,int[,] cordsArr,int xLim,int yLim)
	{
		int[,] ans = new int[num,2];

		for(int i = 0; i < num; i++)
		{
			int x = 0;
			int y = 0;
			int selx = Random.Range (0,xLim);
			int sely = Random.Range (0,yLim);
			if (cordsArr [sely, selx] == 0) 
			{
				cordsArr [sely, selx] = 1;
				x = selx;
				y = sely;
				ans [i, 0] = x;
				ans [i, 1] = y;
			} 
			else 
			{
				i = i - 1;
			}
		}

		return ans;
	}

	public List<Point> CreatePath(int[] arrivalPos,int[] destPos,int maxSteps)
	{
		List<Point> pointsList = new List<Point> ();

		Point des = new Point (destPos[0],destPos[1]);
		Point arr = new Point (arrivalPos[0],arrivalPos[1]);
	
		while(arr.x > des.x || arr.y > des.y)
		{
			int steps = 0;
			int turnState = -1;

			steps = Random.Range (0,maxSteps);
			turnState = Random.Range (0,2);

			if (arr.x <= des.x)
				turnState = 1;
			else 
			if (arr.y <= des.y)
				turnState = 0;

			for(int i = 0; i < steps; i++)
			{
				if (turnState == 0) 
				{
					arr.x = arr.x - 1;	
				} 
				else
				if(turnState == 1)
				{
					arr.y = arr.y - 1;
				}
				pointsList.Add (new Point(arr.x,arr.y));
			}
		}
			
		return pointsList;
	}

	public class Point
	{
		public Point()
		{
			
		}

		public Point(int _x,int _y)
		{
			x = _x;
			y = _y;
		}

		~ Point()
		{
			x = 0;
			y = 0;
		}

		public int x;
		public int y;
	}
}
