using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scripts : MonoBehaviour
{

    public int numDddeCorazones;
    public TextMeshProUGUI textoMision;
    public TextMeshProUGUI textoCorazones;

    void Start()
    {
        numDddeCorazones = GameObject.FindGameObjectsWithTag("Objetivo").Length;
        textoCorazones.text =numDddeCorazones.ToString();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag  == "Objetivo")
        {
            Destroy(col.gameObject);
            numDddeCorazones--;
            textoCorazones.text =numDddeCorazones.ToString();

            if (numDddeCorazones <= 0)
            {
                textoMision.text = "Completaste la mision";
            }

        }
        
    }







}
