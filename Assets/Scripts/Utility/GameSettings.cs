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

	public float MapFlowSpeed = 0.1F;

	public float MapFlowAcceleration = 0;

	public float MapUnit = 0;

	public int MapResolutionCount = 25;

	public int MapZOffsetbackCount = -2;

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