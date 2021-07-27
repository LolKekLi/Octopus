using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCont1 : MonoBehaviour
{
    public void LoadLevl(int lelvlIndex)
    {
        SceneManager.LoadScene(lelvlIndex);
    }
}
