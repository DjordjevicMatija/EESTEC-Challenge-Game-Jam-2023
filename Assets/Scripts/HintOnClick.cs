using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintOnClick : MonoBehaviour
{
    [SerializeField] private ChooseOneScript cos;
    private int rnd;
    [SerializeField] private GameObject oblacic;

    public void Hint()
    {
        cos.levelGenerator = Random.Range(2, 4);
        rnd = Random.Range(1, 11);
        oblacic.gameObject.SetActive(true);
        if (rnd > 5)
        {
            //dobar carobnjak
            if (cos.levelGenerator == 2)
            {
                //led
                oblacic.GetComponentInChildren<TextMeshProUGUI>().text = "Obucite se slojevito.";
            }
            else
            {
                //vatra
                oblacic.GetComponentInChildren<TextMeshProUGUI>().text = "Spremite se za prženje.";
            }
        }
        else
        {
            //los carobnjak
            oblacic.GetComponentInChildren<TextMeshProUGUI>().text = "To se ne pita!";
        }
    }
}
