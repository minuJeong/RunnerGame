﻿using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
	int m_ResolutionCount = 25;

	int m_ZOffsetCount = -2;

	float m_Unit;

	public MapPart BasePrefab;

	void Start ()
	{
		// Confirmation
		Debug.Assert (null != BasePrefab, "BasePrefab is null");
	}

	void OnEnable ()
	{
		m_Unit = GameSettings.Instance.MapUnit;

		m_ZOffsetCount = GameSettings.Instance.MapZOffsetbackCount;

		m_ResolutionCount = GameSettings.Instance.MapResolutionCount;


		Generate ();
	}

	public void Generate ()
	{
		for (int i = 0; i < m_ResolutionCount; i++)
		{
			MapPart part = Instantiate<MapPart> (BasePrefab);

			float initZ = (m_ZOffsetCount + i) * m_Unit;

			part.transform.localPosition = new Vector3 (0, 0, initZ);

			part.transform.SetParent (transform);

			part.Initialize ();
		}
	}
}