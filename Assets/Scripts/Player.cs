using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("MOVER PLAYER")]
    [SerializeField] float speed; // Serialize não permite acessar a variável a outros Scripts
    [SerializeField] float hMove;

    [Header("PLAYER BULLETS")]
    [SerializeField] GameObject bulletPrefab;

    [Header("LIMITS")]
    const float minX = -4.576696f;
    const float maxX = 4.576696f;

   [SerializeField] float fireRate = 0.5f, nextFire;

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
        if (collision.CompareTag("Enemy"))
        {
            
        }
    }

}
