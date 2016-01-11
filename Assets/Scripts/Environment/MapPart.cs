using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MapPart : MonoBehaviour
{
	// cached game setting for map flowings

	public Obstacle m_Obstacle;

	public List<Obstacle> m_InstantiatedObstacles;

	Stack<Obstacle> m_ObstaclePool;

	float m_MapLength;

	float m_ToZ;

	Vector3 m_Speed;

	float m_Acceleration;

	float m_ObstacleY;


	public void Initialize ()
	{
		Debug.Assert (m_Obstacle != null, "Obstacle not set");

		m_ObstacleY = GameSettings.Instance.MapYHeight;

		m_InstantiatedObstacles = new List<Obstacle> ();
		m_ObstaclePool = new Stack<Obstacle> ();

		StartCoroutine ("Run");
	}

	void CacheGameSettings ()
	{
		m_MapLength = GameSettings.Instance.MapUnit * GameSettings.Instance.MapResolutionCount;

		m_ToZ = GameSettings.Instance.MapUnit * (GameSettings.Instance.MapZOffsetbackCount * GameSettings.Instance.MapUnit);

		m_Speed = new Vector3 (0, 0, GameSettings.Instance.MapFlowSpeed);

		m_Acceleration = GameSettings.Instance.MapFlowAcceleration;
	}

	IEnumerator Run ()
	{
		CacheGameSettings ();

		while (true)
		{
			yield return null;

			Vector3 NextLocalPos = transform.localPosition;

			NextLocalPos -= m_Speed * Time.deltaTime;

			m_Speed += new Vector3 (0, 0, m_Acceleration);

			if (NextLocalPos.z <= m_ToZ)
			{
				NextLocalPos += new Vector3 (0, 0, m_MapLength);

				OnEventNewMap ();
			}

			transform.localPosition = NextLocalPos;
		}
	}

	// called when map part pushed ahead.
	void OnEventNewMap ()
	{
		ClearObstacles ();
		GenerateObstacles ();
	}

	void ClearObstacles ()
	{
		int len = m_InstantiatedObstacles.Count;

		for (int i = 0; i < len; i++)
		{
			Obstacle ob = m_InstantiatedObstacles [i];
			ob.gameObject.SetActive (false);
			m_ObstaclePool.Push (ob);
		}

		m_InstantiatedObstacles.Clear ();
	}

	void GenerateObstacles ()
	{
		const int len = 1;
		for (int i = 0; i < len; i++)
		{
			if (UnityEngine.Random.value < 0.2F)
			{
				//GenerateObstacle ();
			}
		}
	}


	Obstacle GenerateObstacle ()
	{
		Obstacle newObstacle;
		if (m_ObstaclePool.Count <= 0)
		{
			newObstacle = Instantiate<Obstacle> (m_Obstacle);
			newObstacle.transform.SetParent (transform);
		}
		else
		{
			newObstacle = m_ObstaclePool.Pop ();
		}

		float angle = UnityEngine.Random.Range (-180.0F * Mathf.Deg2Rad, 180.0F * Mathf.Deg2Rad);
		const float RADIUS = 2.0F;

		float x = Mathf.Cos (angle) * RADIUS;
		float y = Mathf.Sin (angle) * RADIUS + m_ObstacleY;

		newObstacle.transform.position = new Vector3 (x, y, transform.position.z);

		newObstacle.transform.rotation = Quaternion.Euler (0, 0, angle * Mathf.Rad2Deg + 90.0F);

		newObstacle.gameObject.SetActive (true);

		m_InstantiatedObstacles.Add (newObstacle);

		return newObstacle;
	}
}
