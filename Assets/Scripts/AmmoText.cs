using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    public Weapon weapon;
    public Text text;

    private void Start()
    {
        UpdateAmmoText();
    }


    private void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        text.text = $"{weapon.currentClip} | {weapon.currentAmmo}";
    }


}
