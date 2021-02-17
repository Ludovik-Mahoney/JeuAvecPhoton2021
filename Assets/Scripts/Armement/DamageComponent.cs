using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField]
    private int minDégats = 10;
    [SerializeField]
    private int maxDégats = 25;
    private int quantitéDégats;

    private float quantitéDégatsCrit; 
    [SerializeField]
    private float pourcentageCrit = 20;
    public void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
        quantitéDégats = Random.Range(minDégats, maxDégats);
        quantitéDégatsCrit = quantitéDégats * (pourcentageCrit/100.0f) + quantitéDégats;
        if (col.gameObject.tag == "Enemy")
        {

            Debug.Log("touché!");
            HealthComponent health = col.gameObject.GetComponentInParent<HealthComponent>();
            Collider partieTouchée = col.contacts[0].otherCollider;
            if (partieTouchée.transform.name == "Tête")
            {
                Debug.Log("coup critique!" + partieTouchée.gameObject.name);
                health.TakeDamage(quantitéDégatsCrit);
            }
            else
            {
                Debug.Log(partieTouchée.gameObject.name);
                health.TakeDamage(quantitéDégats);
            }
        }
    }
}
