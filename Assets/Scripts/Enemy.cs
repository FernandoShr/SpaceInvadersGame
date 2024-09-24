using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject explosionPrefab;

    EnemyArea enemyArea;
    UIManager uiManager;

    public int scoreValue;

    public void DestroyEnemy()
    {
        FindObjectOfType<UIManager>().UpdateScore(scoreValue);
        enemyArea.allEnemies.Remove(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        enemyArea.EnemyKilled();
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyArea = FindObjectOfType<EnemyArea>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            //if (uiManager.score > uiManager.hScore)
            //{
            //    PlayerPrefs.SetInt("HScore", uiManager.score);
            //    uiManager.hScoreText.text = uiManager.score.ToString();
            //}

            SceneManager.LoadScene("DerrotaCena");
        }
    }
}
