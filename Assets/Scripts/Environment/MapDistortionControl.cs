using UnityEngine;
using System;
using System.Collections;

public class MapDistortionControl : MonoBehaviour
{

	const float CURVED = 3.0F;

	const float SPD = 0.004F;


	public Material[] m_SetMaterial;

	public float m_Angle;

	public float m_Curved;

	float _targetCuved;

	float _targetAngle;

	public float m_Delay = 0;


	void Start ()
	{
		Debug.Assert (m_SetMaterial != null, "Material is not set");
	}


	// Update is called once per frame
	void Update ()
	{
		if (m_Delay <= 0)
		{
			m_Delay += UnityEngine.Random.Range (2.5F, 3.5F);

			_targetAngle = UnityEngine.Random.Range (0.0F, 360.0F);

			_targetCuved = UnityEngine.Random.Range (-CURVED, CURVED);
		}
		else
		{
			m_Delay -= Time.deltaTime;
		}

		m_Angle += (_targetAngle - m_Angle) * SPD;
		m_Curved += (_targetCuved - m_Curved) * SPD;

		float X_Distort = Mathf.Cos (m_Angle * Mathf.Deg2Rad) * m_Curved;
		float Y_Distort = Mathf.Sin (m_Angle * Mathf.Deg2Rad) * m_Curved;

		int len = m_SetMaterial.Length;
		for (int i = 0; i < len; i++)
		{
			Material mat = m_SetMaterial [i];

			mat.SetFloat ("_Xtransfer", X_Distort);
			mat.SetFloat ("_Ytransfer", Y_Distort);
		}
	}
}
