// ##########################################################################################################
//==============================================
/// PlayerRangeTrigger.cs
//==============================================
/// Simple trigger to enable and disable a game object when something enters or exits 
/// the attached collider.
/// For this to work properly, there is a PlayerTrigger layer in the project that 
/// only collides with objects on another custom layer called "Player".
/// If the player's controllable object is on the "Player" layer, and the object this 
/// script is on is on the "PlayerTrigger" layer; only the player object will set off the 
/// "OnTriggerEnter" and "OnTriggerExit" methods.
/// 
/// EDIT: 04/02/2020 - Updated to work purely with a single collider so it works better with Fungus:
// ##########################################################################################################
using UnityEngine;

public class PlayerRangeTrigger : MonoBehaviour
{

    public Collider col; // Collider that this trigger needs to switch on and off (the collider attached to the flowchart.

    private void OnTriggerEnter(Collider other)
    {
        col.enabled = true;
        Debug.Log(other.name + " entered trigger for " + gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        col.enabled = false;
        Debug.Log(other.name + " left trigger for " + gameObject.name);
    }

}
