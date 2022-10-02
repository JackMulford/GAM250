using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float StartingHealth = 100;

    public float Healthpoints
    {
        get { return _Healthpoints; }
        set
        {
            _Healthpoints = Mathf.Clamp(value, 0f, 100f);

            if(_Healthpoints <= 0f)
            {
                Die();
            }
        }
    }

    [SerializeField] 
    private float _Healthpoints = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        Healthpoints = StartingHealth;
    }

    void Die()
    {
        Destroy(gameObject);
    }
   
}
