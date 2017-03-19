using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameHasEnded;
    public GameObject gameOverUI;

    void Start()
    {
        gameHasEnded = false;
        gameOverUI.SetActive(false);
    }

    void Update ()
    {
        if (gameHasEnded)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

		if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame ()
    {
        gameHasEnded = true;
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
    }
}
