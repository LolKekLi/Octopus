using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnamySpawn : MonoBehaviour
{
    //Y 3.5\-3.9    
    public int EnamySize = 4;
    public Text shetchic;        
    private Vector3 startpos = new Vector3(10, 0, 0);

    [SerializeField] 
    private GameObject WinScene;
    [SerializeField]
    private GameObject enamy;

    private bool loose = false;

    public GameObject boos;

    public GameObject UIBos;
    public GameObject oTherUI;

    private bool castil = false;



    void Start()
    {
        shetchic.text = EnamySize.ToString() + "X";
        StartCoroutine(Spawn());
        HealthScript.Shot += HealthScript_Shot;
        HealthScript.loose += HealthScript_Loose;
        HealthScript.Win += HealthScript_Win;
    }

    private void HealthScript_Win()
    {
        
        WinScene.SetActive(true);
    }

    private void HealthScript_Loose()
    {

        loose = true;
    }

    void HealthScript_Shot()
    {
        EnamySize--;
       
    }

    void Update()
    {
        shetchic.text = EnamySize.ToString() + "X";
        if (EnamySize <= 0)
        {
            if (!loose)
            {
                if (!castil)
                {
                    oTherUI.gameObject.SetActive(false);
                    UIBos.gameObject.SetActive(true);
                    Instantiate(boos);
                    castil = true;
                }
               
            }
            
           
            EnamySize = 0;
        }
    }


    IEnumerator Spawn()
    {
        var position = startpos;
        while (EnamySize >= 1)
        {
            Instantiate(enamy);
            enamy.transform.position = position;
            position.y = Random.Range(-3.8f, 3.4f);
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
