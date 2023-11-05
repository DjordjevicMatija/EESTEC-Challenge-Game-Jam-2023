using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseOneScript : MonoBehaviour
{
    public int levelGenerator { get; set; }

    private void Start()
    {
        levelGenerator = Random.Range(2, 4);
    }
}
