using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    public int MaxItems = 4;

    public TMP_Text HealthText;     
    public TMP_Text ItemText;
    public TMP_Text ProgressText;

    public Button WinButton;
    public Button LossButton;
    // Start is called before the first frame update
    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

    public int Items
    {
        // 2
        get { return _itemsCollected; }
        // 3
        set
        {
            _itemsCollected = value;
            ItemText.text = "Items: " + Items;
            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";
                WinButton.gameObject.SetActive(true);
                UpdateScene("You've found all the items!");
                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more!";
            }
            Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }
    // 4
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if (_playerHP <= 0)
            {
                ProgressText.text = "You want another life with that?";
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
                Time.timeScale = 0;
            }
            else
            {
                ProgressText.text = "Ouch... that's got hurt.";
            }
        }
    }

    public void RestartScene()
    {
        // 3
        SceneManager.LoadScene(0);
        // 4
        Time.timeScale = 1f;
    }
}
