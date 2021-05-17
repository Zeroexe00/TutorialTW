using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class EnemyData : ScriptableObject
{
    public string nameEnemy;
    public Sprite image;
    public float maxHealth;
    public float force;
    public int speed;

    public void ShowMessage()
    {
        Debug.Log("Mi nombre es: " + nameEnemy);

    }
}
