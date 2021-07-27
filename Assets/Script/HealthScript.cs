using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int hp = 1;
    public bool isEnamy;
    public bool boos;
    public static Action Shot = delegate { };
    public Image[] HP;
    public GameObject LooseScene;

    public static Action loose = delegate { };

    private bool win = false;

    public static Action Win = delegate { };


    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            if (boos)
            {
                win = true;
                Win();
            }
            Destroy(gameObject);
            if (!isEnamy && !win)
            {
                LooseScene.SetActive(true);
                loose();
            }
           
        }
        if (!isEnamy)
        {
            HP[hp].gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            
            if (shot.isEnamyShot != isEnamy)
            {
              
                Shot();
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }

        }
    }

}
