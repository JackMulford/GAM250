using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController playerControllerComponent))
        {
            playerControllerComponent.TakeDamage(1);
        }

        Destroy(gameObject);


    }
}
