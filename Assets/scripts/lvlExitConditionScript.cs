using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlExitConditionScript : MonoBehaviour
{   
    public int TotalEnemyCount;
    private int enemyCount;
    public float passPercentage;
    public BoxCollider lvlExit;

    void Start()
    {
      TotalEnemyCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = transform.childCount;
        if(enemyCount <= TotalEnemyCount*(passPercentage/100)){
            lvlExit.isTrigger = true;
        }
    }
}
