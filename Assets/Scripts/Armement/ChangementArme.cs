using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementArme : MonoBehaviour
{
    public int armeChoisie = 0;
    // Start is called before the first frame update
    void Start()
    {
        ChoisirArme();
    }

    // Update is called once per frame
    void Update()
    {
        int ArmeChoisieAvant = armeChoisie;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (armeChoisie >= transform.childCount - 1)
                armeChoisie = 0;
            else
                armeChoisie++;
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (armeChoisie <= 0)
                armeChoisie = transform.childCount - 1;
            else
                armeChoisie--;

        }
        if(ArmeChoisieAvant != armeChoisie)
        {
            ChoisirArme();
        }
    }
    private void ChoisirArme()
    {
        int i = 0;
        foreach(Transform arme in transform)
        {
            if (i == armeChoisie)
                arme.gameObject.SetActive(true);
            else
                arme.gameObject.SetActive(false);
            i++;
        }
    }
}
