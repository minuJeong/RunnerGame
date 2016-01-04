using UnityEngine;
using UnityEditor;
using System.Collections;


[System.Serializable]
public class GameSettings : ScriptableObject
{
	const string ASSETS = "Assets/";
	const string DIRNAME = "Setup/";
	const string FILENAME = "Setup.asset";


	#region SETTINGS

	// Base Map Flowing

	public float MapFlowSpeed = 0.1F;

	public float MapFlowAcceleration = 0;

	public float MapUnit = 0;

	public int MapResolutionCount = 25;

	public int MapZOffsetbackCount = -2;

	public float MapRotationFactor = 3.0F;

	public float MapYHeight = 2.75F;


	// Obstacle Generation


	// Camera tilt

	public float CameraTiltFactor;

	public float CameraTranslationFactor;

	public float CameraRecoveryRate = 0.66F;


	// Player Pawn

	public float PawnRotationFactor;

	public float PawnRotationRecoveryRate = 0.66F;


	#endregion


	static GameSettings s_Instance;

	public static GameSettings Instance
	{
		get
		{
			if (null == s_Instance)
			{
				s_Instance = Initialize ();

			}

			return s_Instance;
		}
	}

	[MenuItem ("Tools/GameSetting %t")]
	public static GameSettings Initialize ()
	{
		// try cached
		if (null != s_Instance)
		{
			Debug.Log ("Setting file exists");

			Selection.activeObject = s_Instance;

			return s_Instance;
		}


		// try load
		s_Instance = AssetDatabase.LoadAssetAtPath<GameSettings> (ASSETS + DIRNAME + FILENAME);

		if (null != s_Instance)
		{
			return s_Instance;
		}


		// try create
		s_Instance = CreateInstance<GameSettings> ();

		if (!AssetDatabase.IsValidFolder (ASSETS + DIRNAME))
		{
			Debug.Log ("Created game settings directory");

			AssetDatabase.CreateFolder (ASSETS, DIRNAME);
		}

		AssetDatabase.CreateAsset (s_Instance, ASSETS + DIRNAME + FILENAME);

		AssetDatabase.SaveAssets ();


		Debug.Log ("Created new setting file.");

		Selection.activeObject = s_Instance;

		return s_Instance;
	}
}


[CustomEditor (typeof(GameSettings))]
public class GameSettingsEditor : Editor
{
	
}