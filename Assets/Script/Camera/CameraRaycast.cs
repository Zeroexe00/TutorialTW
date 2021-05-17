using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public LayerMask groundLayer;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100, groundLayer))
            {
                playerMovement.posToGo = hit.point;
                playerMovement.Turning(hit.point);
            }
        }
    }
}
