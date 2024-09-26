using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FbiController : MonoBehaviour
{
    [SerializeField] Sprite alive;
    [SerializeField] Sprite dead;
    private bool killable = false;
    [SerializeField] GameObject trump;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async public void FbiDamage()
    {
        
            gameObject.GetComponent<SpriteRenderer>().sprite = dead;
            await Task.Delay(1200);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
        
    }

    /*private void OnTriggerEnter(Collider collision)
    {
        TrumpMovement t = collision.GetComponent<Collider2D>().GetComponent<TrumpMovement>();
        if (t != null) 
        {
            t.killable = false;
            killable = true;
        }
    }

    private void OnTriggerExit(Collider collision) 
    {
        TrumpMovement t = collision.GetComponent<Collider2D>().GetComponent<TrumpMovement>();
        if (t != null) 
        { 
            t.killable = true;
            killable = false;

        }
    }*/
}
