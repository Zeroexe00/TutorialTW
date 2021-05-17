using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed;
    public int turnSpeed;
    public Vector3 posToGo;

    Animator anim;
    Quaternion rotation;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        posToGo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == posToGo)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        transform.position = Vector3.MoveTowards(transform.position, posToGo, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    public void Turning(Vector3 target)
    {
       Vector3 direction = target - transform.position;
       rotation = Quaternion.LookRotation(direction);
    }
}
