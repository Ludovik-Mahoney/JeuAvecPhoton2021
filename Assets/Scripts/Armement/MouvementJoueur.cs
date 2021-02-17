using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{

    [SerializeField] private float vitesseMarche = 2;
    [SerializeField] private KeyCode toucheSprint;
    [SerializeField] private KeyCode toucheSaut;
    [SerializeField] private float vitesseSprint = 6;
    [SerializeField] private float hauteurSaut = 5;

    private Rigidbody rb;
    private CharacterController controleJoueur;
    private float vitesseDéplacement;
    private float GRAVITER = -1.5f;

    private void Start()
    {
        controleJoueur = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float déplacementX = Input.GetAxis("Horizontal");
        float déplacementZ = Input.GetAxis("Vertical");
        vitesseDéplacement = vitesseMarche;
        Vector3 mouvement = new Vector3(déplacementX, 0, déplacementZ);
        // fait en sorte de ce déplacer vers ce qu'on regarde
        mouvement = transform.TransformDirection(mouvement);

        //Sprinter
        if (Input.GetKey(toucheSprint))
        {
            vitesseDéplacement = vitesseSprint;
        }

        //Sauter
        if(Input.GetKeyDown(toucheSaut)&& controleJoueur.isGrounded)
        {
            //rendre ça plus smooth
            controleJoueur.Move(Vector3.up * hauteurSaut);
        }
         mouvement.y += GRAVITER;

         mouvement *= vitesseDéplacement;
         controleJoueur.Move(mouvement*Time.deltaTime);
    }
}
