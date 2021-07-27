using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50); //Скорость движения
    private Vector2 movement; // Напрвления движения

    void Start()
    {
        HealthScript.Win += EnamySpawn_Win;
    }

    void EnamySpawn_Win()
    {
       //GetComponent<PlayerScript>().enabled = false;
       // GetComponent<HealthScript>().enabled = false;
       // var position = gameObject.transform.position;
       // GetComponent<BoxCollider2D>().enabled = false;
       // transform.position = position;

    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;

    }
}
