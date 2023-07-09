using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01GM : MonoBehaviour
{
    public GameObject trueendUI;

    // Start is called before the first frame update
    void Start()
    {
        if (Keyforui.havekey == 1)
        {
            trueendUI.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
