using UnityEngine;
using System.Collections;

public class SetupVerification : MonoBehaviour
{
	public string message = "";
	
	
	private bool badSetup = false;
	

    void OnEnable()
    {
        Application.logMessageReceived += OnLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= OnLog;
    }
	

	void OnLog (string message, string stacktrace, LogType type)
	{
		if (message.IndexOf ("UnityException: Input Axis") == 0 ||
			message.IndexOf ("UnityException: Input Button") == 0
		)
		{
			((ThirdPersonControllerNET)FindObjectOfType (typeof (ThirdPersonControllerNET))).enabled = false;
			badSetup = true;
		}
	}
	
	
	void OnGUI ()
	{
		if (!badSetup)
		{
			return;
		}

		GUILayout.BeginArea (new Rect (0.0f, 0.0f, Screen.width, Screen.height));
			GUILayout.FlexibleSpace ();
			GUILayout.BeginHorizontal ();
				GUILayout.FlexibleSpace ();
				GUILayout.Box (message);
				GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
	}
}
