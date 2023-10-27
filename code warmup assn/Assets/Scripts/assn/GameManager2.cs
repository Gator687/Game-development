using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    private int score = 0;

    private Patrol patrolScript;

    void Start()
    {
        patrolScript = GameObject.FindObjectOfType<Patrol>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + score);
    }

    public void IncreaseScore()
    {
        score++;
    }
}
