using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour
{
    public EnemyData enemyData;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = enemyData.image;
        GetComponent<Image>().preserveAspect = true;
        enemyData.ShowMessage();
    }

}
