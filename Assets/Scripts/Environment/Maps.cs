using UnityEngine;
using System.Collections;



public class Maps : MonoBehaviour
{
	float m_MapRotationFactor;

	public void Start ()
	{
		m_MapRotationFactor = GameSettings.Instance.MapRotationFactor;
	}

	public void Rotate (float controlAmount)
	{
		transform.Rotate (0, 0, - controlAmount * m_MapRotationFactor);
	}
}
