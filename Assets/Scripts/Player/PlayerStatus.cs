using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public int lives;
    public GameObject[] hearts;

    public void Damage()
    {
        lives -= 1;
        hearts[lives].SetActive(false);
        if (lives <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        Destroy(gameObject);
        Restart();
    }
    
    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(05);
    }
}