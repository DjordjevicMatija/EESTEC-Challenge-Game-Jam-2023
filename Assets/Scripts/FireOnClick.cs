using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireOnClick : MonoBehaviour
{
    [SerializeField] private ChooseOneScript cos;

    public void ChoseFire()
    {
        if (cos.levelGenerator == 3) //vatra
            CollisionPlayer.weak = false;
        else                     //led
            CollisionPlayer.weak = true;
        SceneManager.LoadScene(cos.levelGenerator);

    }
}
