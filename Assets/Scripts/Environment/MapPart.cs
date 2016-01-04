using UnityEngine;
using System.Collections;


public class MapPart : MonoBehaviour
{
	// cached game setting for map flowings

	float m_MapLength;

	float m_ToZ;

	Vector3 m_Speed;

	float m_Acceleration;

	public void Initialize ()
	{
		StartCoroutine ("Run");
	}

	void CacheGameSettings ()
	{
		m_MapLength = GameSettings.Instance.MapUnit * GameSettings.Instance.MapResolutionCount;

		m_ToZ = GameSettings.Instance.MapUnit * (GameSettings.Instance.MapZOffsetbackCount);

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
		GenerateObstacle ();
	}


	void GenerateObstacle ()
	{
		
	}
}
