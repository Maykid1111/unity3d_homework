using UnityEngine;
using System.Collections;

public class my : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnGUI()
    {
        // Fixed Layout
        GUI.Button(new Rect(25, 25, 100, 30), "I am a Fixed Layout Button");
        
        // Automatic Layout
        GUILayout.Button("I am an Automatic Layout Button");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
