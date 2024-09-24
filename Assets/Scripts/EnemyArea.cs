using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyArea : MonoBehaviour
{
    [Header("ENEMY MOVEMENT")]
    Vector2 direction = Vector2.right;
    [SerializeField] float speed = 1f;

    [SerializeField] Enemy[] enemies;
    [SerializeField] int rows = 4, columns = 11;

    [SerializeField] int amountDead;
    const int totalEnemies = 44;

    public GameObject missilePrefab;
    [SerializeField] float shootTimer = 3f;
    float shootTime = 3f;

    public List<GameObject> allEnemies = new List<GameObject>();

    public GameObject UfoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            allEnemies.Add(enemy);

        InvokeRepeating(nameof(SpawnUfo), 10, Random.Range(10, 20));
    }

    // Update is called once per frame
    void Update()
    {
        //Criando a movimentação dos invader
        transform.Translate(direction * speed * Time.deltaTime);

        Vector2 leftEdge = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 rightEdge = Camera.main.ViewportToWorldPoint(Vector2.right);

        foreach (Transform Enemy in transform)
        {
            if (direction == Vector2.right && Enemy.position.x >= rightEdge.x - 0.65)
                AdvanceAlien();
            else if (direction == Vector2.left && Enemy.position.x <= leftEdge.x + 0.65)
                AdvanceAlien();
        }

        // Tiro dos inimigos
        if (shootTimer <= 0)
            EnemyShoot();

        shootTimer -= Time.deltaTime;
    }

    void AdvanceAlien()
    {
        direction.x *= -1;

        Vector3 position = transform.position;
        position.y -= 0.45f;
        transform.position = position; 

    }

    public void EnemyKilled()
    {
        amountDead++;
        speed += 0.013f;
        shootTime -= 0.05f;
        if (shootTime <= 1.5f)
            shootTime = 1.5f;
        
        if (speed >= 5)
            speed = 5;

        if (amountDead >= totalEnemies)
        {
            SceneManager.LoadScene("VitoriaCena");
        }
            
        
    }

    private void Awake()
    {
        for (int row = 0; row < rows; row++) 
        {
            for(int col = 0; col < columns; col++)
            {
                Enemy enemy = Instantiate(enemies[row], transform);

                // Centralizar a grade de invaders' 
                Vector2 center = new Vector2(-9, -4);
                Vector2 rowPosition = new Vector2(center.x, center.y + (row * 0.75f));

                Vector2 position = rowPosition;
                position.x += col * 0.75f;
                enemy.transform.localPosition = position;
            }
            
        }
    }

    private void EnemyShoot()
    {
        Vector2 pos = allEnemies[Random.Range(0, allEnemies.Count)].transform.position;

        Instantiate(missilePrefab, pos, Quaternion.identity);

        shootTimer = shootTime;
    }

    private void SpawnUfo()
    {
        Instantiate(UfoPrefab, new Vector2(6, 4.6f), Quaternion.identity); 
    }
}
