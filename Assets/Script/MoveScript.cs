using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector2 speed; //Скорость объекта
    public Vector2 direction; //Напрвления движения
    private Vector2 movement;

    [SerializeField] 
    private bool isEnamy = false;
   void Update()
   {
       movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
   }

   void FixedUpdate()
   {
       GetComponent<Rigidbody2D>().velocity = movement;
   }

   void OnTriggerEnter2D(Collider2D other)
   {
       if (isEnamy && !other.gameObject.GetComponent<ShotScript>())
       {
           
           Destroy(gameObject);
       }
   }
}
