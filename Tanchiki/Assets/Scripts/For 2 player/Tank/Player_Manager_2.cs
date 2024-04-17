using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Manager_1 : MonoBehaviour
{
    public static int playerHealth;
    public static bool gameOver;
    public TextMeshProUGUI playerHealthText;

    void Start()
    {
        playerHealth = 5;
        gameOver = false;
    }

    void Update()
    {
        playerHealthText.text = "" + playerHealth;

        if (gameOver)
        {
            SceneManager.LoadScene("level1");
        }
    }

    public static void Damage (int damageCount) 
    {
        playerHealth -= damageCount;

        if (playerHealth <= 0)
            gameOver = true;
    }
}
