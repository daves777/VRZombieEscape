using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject TheEnemy;

    void Start()
    {
        setRigidBodyState(true);
        setColliderState(false);

    }

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            this.GetComponent<ZombieFollow>().enabled = false;
            StartCoroutine(EndZombie());
            TheEnemy.GetComponent<Animation>().Play("Dying");
        }
    }
    
    IEnumerator EndZombie()
    {
        yield return new WaitForSeconds(3.2f);
        Destroy(gameObject);
    }

    public void die()
    {
        setRigidBodyState(false);
        setColliderState(true);
    }

    void setRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }

}
