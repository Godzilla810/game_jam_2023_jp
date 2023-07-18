using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public int lives;
    public GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage()
    {
        lives -= 1;
        hearts[lives].SetActive(false);
        Debug.Log("-1");
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