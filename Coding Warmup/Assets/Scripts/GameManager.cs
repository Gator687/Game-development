using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string msg;
    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        msg = "Game Started";
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(100, Screen.height / 2 - 200, 302, 160), GUI.skin.GetStyle("box"));

        GUILayout.BeginVertical();
        GUILayout.Label(msg);
        GUILayout.Label(counter.ToString());
        GUILayout.EndVertical();

        //GUILayout.Label(new Rect(20, 40, 200, 65), "I'm overlapping", GUI.skin.GetStyle("Window"));

        GUILayout.EndArea();
    }
}
