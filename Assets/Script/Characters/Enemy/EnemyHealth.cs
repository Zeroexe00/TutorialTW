using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
  public int maxHealth;
  public int currentHealth;
  public Slider slider;
  // Start is called before the first frame update
  void Start()
  {
    currentHealth = maxHealth;
    slider.maxValue = maxHealth;
  }

  // Update is called once per frame
  public void TakeDamage(int damage)
  {
    anim.SetTrigger("Hit")
    currentHealth -= damage;
    slider.value = currentHealth;
    if(currentHealth <= 0)
    {
      Death();
    }
  }
  void Death()
  {
    Debug.Log("muerte");
    Destroy(gameObject, 2);
  }
  private void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("AttackPlayer"))
    {
      TakeDamage(other.GetComponent<PlayerAttack>().damage);
    }
  }
}
