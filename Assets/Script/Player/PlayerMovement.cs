using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  public int speed;
  public int turnSpeed;
  public Vector3 posToGo;
  public UiManager uiManager;
  public bool attackingEnemy;

  PlayerAttack playerAttack;
  Animator anim;
  Quaternion rotation;

  private void Awake()
  {
    anim = GetComponent<Animator>();
    playerAttack = GetComponentInChildren<PlayerAttack>();
  }
  // Start is called before the first frame update
  void Start()
  {
    posToGo = transform.position;
    rotation = transform.rotation;
  }

  // Update is called once per frame
  void Update()
  {
    if(transform.position == posToGo)
    {
      anim.SetBool("isRunning", false);
      if(attackingEnemy)
      {
        playerAttack.Attack();
      }
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

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Hero") || other.CompareTag("Lich"))
    {
      uiManager.SelectCharacter(other.tag);
      Destroy(other.gameObject);
    }
  }
}
