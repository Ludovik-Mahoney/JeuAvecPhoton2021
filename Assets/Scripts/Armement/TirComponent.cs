using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirComponent : MonoBehaviour
{
    //spawner le projectile
    public GameObject objectToClone;
    [SerializeField]
    private KeyCode toucheTir;
    [SerializeField]
    private Transform spawnPoint;

    //vitesse de tire de l'arme
    private float prochainTir = 0f;
    [SerializeField]
    private float tempsEntreTir = 0.5f;

    //recharge de l'arme
    [SerializeField]
    private float chargeur = 5;
    private float munitionRestante;
    [SerializeField]
    private float tempsRecharge = 3;
    private bool enRechargement = false;

    //Bruit/visuelle
    [SerializeField]GameObject modèleFlash;
    private AudioSource bruitTir;

    //Recul
    [SerializeField]
    private Vector3 recul;

    [SerializeField] Camera cam;
    [SerializeField] GameObject corps;



    private void Start()
    {
        munitionRestante = chargeur;
        bruitTir = GetComponent<AudioSource>();
    }

    void Update()
    {
        //éviter de retourner dans le rechargement sans arrêt
        if (enRechargement)
           return;

        //recharger quand chargeur vide
        if (munitionRestante <= 0)
        {

            StartCoroutine(Recharger());
            return;
        }

        //tirer
        if (Input.GetKey(toucheTir) && Time.time > prochainTir)
        {
            prochainTir = Time.time + tempsEntreTir;
            Tirer();
        }
    }
    private void Tirer()
    {
        //créer la balle
        Instantiate(objectToClone, spawnPoint.position, transform.rotation);

        //faire jouer le bruit
        bruitTir.Play();

        //recul de l'arme
        AppliquerRecul();

        //faire apparaître le flash
        var flashTir = modèleFlash.GetComponent<ParticleSystem>();
        flashTir.Play();

        //gérer les munitions
        munitionRestante--;

        //Afficher à l'écran au lieu du debug
        Debug.Log(munitionRestante);
        //AppliquerRecul();
    }
    private void AppliquerRecul()
    {
        // x positif car on veut pas allé vers le bas , y + et - pour droite/gauche, on veut pas tournée sur l'axe des z donc 0 
        recul = new Vector3(Random.Range(2, 5), Random.Range(-5, 5), 0 );
        Debug.Log(recul);
        cam.transform.eulerAngles -= recul;

        //Mettre la rotation sur le corps aussi mais juste la rotation y
        corps.transform.eulerAngles = new Vector3(corps.transform.rotation.x , cam.transform.rotation.y, corps.transform.rotation.z) ;
    }


    IEnumerator Recharger()
    {
        enRechargement = true;
        // faire apparaître un message à l'écran au lieu de debug
        Debug.Log("Rechargement en cours...");
        yield return new WaitForSeconds(tempsRecharge);
        munitionRestante = chargeur;
        enRechargement = false;
    }
}
