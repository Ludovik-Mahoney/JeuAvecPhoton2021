using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistiqueComponent : MonoBehaviour
{
    //Pour Trajectoire
    [SerializeField] private float vitesseBalle = 25;
    private float prédictionStepPerFrame = 6;
    public Vector3 forceProjectile;

    //Pour collision
    //[SerializeField]
    //int coucheCollision;
    void Start()
    {
        forceProjectile = transform.forward * vitesseBalle;
    }

    // Update is called once per frame
    void Update()
    {
        CalculerTrajectoire();
    }
    private void CalculerTrajectoire()
    {
        Vector3 point1 = transform.position;
        float stepSize =  1.0f/ prédictionStepPerFrame;
        for (float step = 0; step < 1; step += stepSize)
        {
            forceProjectile += Physics.gravity * stepSize * Time.deltaTime;
            Vector3 point2 = point1 + forceProjectile * stepSize *  Time.deltaTime;
            point1 = point2;
        }
        transform.position = point1;
    }

    //Voir trajectoire balle

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Vector3 point1 = transform.position;
    //    float stepSize = 0.01f;
    //    Vector3 predictedBulletVelocity = forceProjectile;
    //    for(float step = 0; step < 1; step += stepSize)
    //    {
    //        predictedBulletVelocity += Physics.gravity * stepSize;
    //        Vector3 point2 = point1 + predictedBulletVelocity * stepSize;
    //        Gizmos.DrawLine(point1, point2);
    //        point1 = point2;
    //    }
    //}


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == coucheCollision)
    //        Destroy(gameObject);
    //}
}
