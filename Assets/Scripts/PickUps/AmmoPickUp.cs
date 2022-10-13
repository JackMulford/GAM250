using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] [Range(0, 1)] float pickUpSoundVolume = 0.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon weapon = collision.gameObject.GetComponentInChildren<Weapon>();
        if (weapon)
        {
            AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position, pickUpSoundVolume);
            weapon.AddAmmo(weapon.maxAmmoSize);
            Destroy(gameObject);
        }
    }



}
