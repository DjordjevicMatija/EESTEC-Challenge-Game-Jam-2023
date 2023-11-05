using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceOnClick : MonoBehaviour
{
    [SerializeField] private ChooseOneScript cos;
    public void ChoseIce()
    {
        if (cos.levelGenerator == 2) //led
            CollisionPlayer.weak = false;
        else                     //vatra
            CollisionPlayer.weak = true;
        SceneManager.LoadScene(cos.levelGenerator);
    }
}
