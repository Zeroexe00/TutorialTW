using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyMovement : MonoBehaviour
{
  NavMeshAgent agent;
  GameObject player;
  Animator anim;

  // Start is called before the first frame update
  private void Awake()
  {
    anim = GetComponent<Animator>();
    agent = GetComponent<NavMeshAgent>();
    player = GameObject.FindGameObjectWithTag("Player");
  }
  void Start()
  {

  } 

  // Update is called once per frame
  void Update()
  {
    agent.SetDestination(player.transform.position);

    Animating();
  }
  void Animating()
  {
    if(agent.velocity.magnitude <= 0.01)
    {
      anim.SetBool("isRunning", false);
    }
    else
    {
      anim.SetBool("isRunning", true);
    }
  }
}
