using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    private void OnPause()
    {
        Time.timeScale = 0f;
    }

}
