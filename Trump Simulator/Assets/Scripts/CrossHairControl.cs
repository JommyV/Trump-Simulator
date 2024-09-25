using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
      
    }

    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        TrumpMovement t = collision.GetComponent<Collider2D>().GetComponent<TrumpMovement>();
        if (t != null)
        {
            t.TrumpDamage();
            t.donaldSprite.sprite = t.normalSprite;
            Debug.Log(collision); 
        }
    }
}
