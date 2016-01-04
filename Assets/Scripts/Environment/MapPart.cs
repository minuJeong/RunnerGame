using UnityEngine;
using System.Collections;


public class MapPart : MonoBehaviour
{
	float m_MapLength;

	float m_ToZ;

	Vector3 m_Speed;

	public void Initialize ()
	{
		StartCoroutine ("Run");
	}

	IEnumerator Run ()
	{
		m_MapLength = GameSettings.Instance.MapUnit * GameSettings.Instance.MapResolutionCount;

		m_ToZ = GameSettings.Instance.MapUnit * (GameSettings.Instance.MapZOffsetbackCount);

		m_Speed = new Vector3 (0, 0, GameSettings.Instance.MapFlowSpeed);

		while (true)
		{

			yield return null;


			Vector3 NextLocalPos = transform.localPosition;

			NextLocalPos -= m_Speed * Time.deltaTime;

			if (NextLocalPos.z <= m_ToZ)
			{
				NextLocalPos += new Vector3 (0, 0, m_MapLength);
			}

			transform.localPosition = NextLocalPos;

		}
	}
}
