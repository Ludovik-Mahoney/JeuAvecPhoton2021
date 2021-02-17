using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerComponent : MonoBehaviour
{
    [SerializeField] private float sensibilité;
    [SerializeField] private GameObject joueur;
    void Start()
    {
        //figé le curseur quand le jeux commence
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();
    }
    private void RotateCamera()
    {
        float sourisX = Input.GetAxisRaw("Mouse X");
        float sourisY = Input.GetAxisRaw("Mouse Y");
        
        float mouvementX = sourisX * sensibilité;
        float mouvementY = sourisY* sensibilité;

        Vector3 rotCam = transform.rotation.eulerAngles;
        Vector3 rotJoueur = joueur.transform.rotation.eulerAngles;
         // marche pas , trouver comment clamp dans les y (rotation x)
        rotCam.x -= mouvementY;
        rotCam.z = 0;
        rotJoueur.y += mouvementX;
        Mathf.Clamp(transform.rotation.y, -90, 90);
        transform.rotation = Quaternion.Euler(rotCam);
        joueur.transform.rotation = Quaternion.Euler(rotJoueur);

    }
}
