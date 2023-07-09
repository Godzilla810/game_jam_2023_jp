using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyforui : MonoBehaviour
{

    static public int havekey = 0;
    public GameObject KeyUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void Keyget ()
    {
        havekey = 1;
    }

    public void KeyUIclose ()
    {
        KeyUI.SetActive(false);
    }
}
