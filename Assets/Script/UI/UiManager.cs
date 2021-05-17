using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject panelAlly;

    bool panelState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            panelState = !panelState;
            panelAlly.GetComponent<Animator>().SetBool("OnScreen",panelState);
        }
    }
}
