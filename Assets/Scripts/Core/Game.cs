using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public CamControl m_CachedMainCameraControl;

	public PlayerPawn m_CachedPlayerPawn;

	public Maps m_CachedMaps;


	void Start ()
	{
		Debug.Assert (m_CachedPlayerPawn != null, "Player Pawn not set");
		Debug.Assert (m_CachedMainCameraControl != null, "Main camera control is not set");
		Debug.Assert (m_CachedMaps != null, "Maps not set");
	}

	// Update is called once per frame
	void Update ()
	{
		float xControl = Input.GetAxis ("Horizontal") * Time.deltaTime;

		m_CachedMainCameraControl.Tilt (xControl);

		m_CachedMaps.Rotate (xControl);

		m_CachedPlayerPawn.Tilt (xControl);
	}
}
