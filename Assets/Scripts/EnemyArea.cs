using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    [Header("ENEMY MOVEMENT")]
    Vector2 direction = Vector2.right;
    [SerializeField] float speed = 1f;

    [SerializeField] Enemy[] enemies;
    [SerializeField] int rows = 4, columns = 11;


    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void AdvanceAlien()
    {
        direction.x *= -1;

        Vector3 position = transform.position;
        position.y -= 0.7f;
        transform.position = position; 

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
}
