using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour
{
	float m_TiltFactor;

	float m_TranslationFactor;

	Vector3 m_InitialPosition;

	Quaternion m_InitialRotation;

	float m_RecoveryRate;


	public void Tilt (float controlAmount)
	{
		transform.Rotate (0, 0, controlAmount * m_TiltFactor);

		transform.Translate (controlAmount * m_TranslationFactor, 0, 0);
	}

	void Start ()
	{
		m_InitialRotation = transform.rotation;

		m_InitialPosition = transform.position;


		m_TranslationFactor = GameSettings.Instance.CameraTranslationFactor;

		m_TiltFactor = GameSettings.Instance.CameraTiltFactor;

		m_RecoveryRate = GameSettings.Instance.CameraRecoveryRate;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.rotation = Quaternion.Lerp (transform.rotation, m_InitialRotation, m_RecoveryRate);

		transform.position = Vector3.Lerp (transform.position, m_InitialPosition, m_RecoveryRate);
	}
}
