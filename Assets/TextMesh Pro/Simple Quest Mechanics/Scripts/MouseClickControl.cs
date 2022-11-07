// ##########################################################################################################
//==============================================
// ==== MouseClickControl.cs ====
//==============================================
// By Paul Hedley. 03/02/2020
// Add this script to a game object that has a collider on it.
// Intended to be added to a Fungus Flowchart that is activated by a collider (or mouse click).
// Use the Fungus Flowchart to run the public methods in this script as required.
// ##########################################################################################################
using UnityEngine;

public class MouseClickControl : MonoBehaviour
{
    Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public void EnableClicking()
    {
        col.enabled = true;
    }
    
    public void DisableClicking()
    {
        col.enabled = false;
    }
}
