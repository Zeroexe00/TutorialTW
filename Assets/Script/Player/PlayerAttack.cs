using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  public int damage;
  Animator anim;
  Collider colliderAttack;

  private void Awake()
  {
    anim = transform.parent.GetComponent<Animator>();
    colliderAttack = GetComponent<Collider>();
  }

  public void Attack()
  {
    anim.SetTrigger("Attack");
  }
  public void AttackWithCollider()
  {
    colliderAttack.enabled = true;
    Invoke("DisableCollider", 0.1f);
  }
  void DisableCollider()
  {
    colliderAttack.enabled = false;
  }
}
