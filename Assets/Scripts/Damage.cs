using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public float DamagePoints = 10f;

    private void OnTriggerStay(Collider other)
    {
        Health H = other.GetComponent<Health>();

        if (H == null) return;

        H.Healthpoints -= DamagePoints * Time.deltaTime;
    }



}
