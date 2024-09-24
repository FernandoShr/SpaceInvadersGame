using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("MOVER PLAYER")]
    [SerializeField] float speed; // Serialize não permite acessar a variável a outros Scripts
    [SerializeField] float hMove;

    [Header("PLAYER BULLETS")]
    [SerializeField] GameObject bulletPrefab;

    [Header("LIMITS")]
    const float minX = -8.4f;
    const float maxX = 8.4f;

    [SerializeField] float fireRate = 0.5f, nextFire;

    [SerializeField] int hp = 3;

    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Translate(speed * Time.deltaTime * Vector2.right);

        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(speed * Time.deltaTime * Vector2.left);


        //limitar player:
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);

        // DEV MODE HEHE
        if (Input.GetKey(KeyCode.T)) 
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
                Shoot();
        }
        else
        {
            // Tiro do player Limitado
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time >= nextFire)
                Shoot();
        }
    }


    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet"))
        {
            //if(uiManager.score > uiManager.hScore)
            //{
            //    PlayerPrefs.SetInt("HScore", uiManager.score);
            //    uiManager.hScoreText.text = uiManager.score.ToString();
            //}

            hp--;
            FindObjectOfType<UIManager>().UpdateHP(hp);
            if (hp <= 0)
                SceneManager.LoadScene("DerrotaCena");
        }

    }

}
