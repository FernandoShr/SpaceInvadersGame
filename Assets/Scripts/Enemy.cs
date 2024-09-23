using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{



    public void DestroyEnemy()
    {
        //FindObjectOfType<UIManager>().UpdateScore(scoreValue);
        //enemyArea.allEnemies.Remove(gameObject);
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //enemyArea.EnemyKilled();
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
