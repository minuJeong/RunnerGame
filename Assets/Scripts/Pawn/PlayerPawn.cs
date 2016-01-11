using UnityEngine;
using System.Collections;

public class PlayerPawn : MonoBehaviour
{
	float m_Recovery;

	float m_RotationFactor;

	Quaternion m_InitialRotation;

	public void Tilt (float controlAmount)
	{
		transform.Rotate (0, 0, - controlAmount * m_RotationFactor);
	}

	void Start ()
	{

		m_RotationFactor = GameSettings.Instance.PawnRotationFactor;

		m_Recovery = GameSettings.Instance.PawnRotationRecoveryRate;


		m_InitialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.rotation = Quaternion.Lerp (transform.rotation, m_InitialRotation, m_Recovery);
	}
}
