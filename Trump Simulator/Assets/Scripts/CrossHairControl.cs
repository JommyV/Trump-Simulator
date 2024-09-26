using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CrossHairControl : MonoBehaviour
{

    [SerializeField] AudioSource shotSource;
    [SerializeField] AudioClip shotSound;

    
    public float duration = 1.0f; // Duration of the tween
    public Vector3 targetScale = Vector3.zero/2; // Target scale

    // Start the tween when the game starts
    void Start()
    {
        StartCoroutine(ScaleOverTime(targetScale, duration));
        shotSource.PlayOneShot(shotSound);
    }

    IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = transform.localScale;
        float time = 0;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null; // Wait for next frame
        }

        // Ensure the final scale is set
        transform.localScale = targetScale;
    }



private async void OnTriggerEnter2D(Collider2D collision) 
    {
        TrumpMovement t = collision.GetComponent<Collider2D>().GetComponent<TrumpMovement>();
        FbiController fbi = collision.GetComponent<Collider2D>().GetComponent<FbiController>();
        if (t != null)
        {if (fbi == null)
            {
                t.TrumpDamage(1);
                t.donaldSprite.sprite = t.normalSprite;
                Debug.Log(collision);
            }
        } 
        if ( fbi != null )
        {
            fbi.FbiDamage();
            Destroy(gameObject);
            await Task.Delay(300);
        }
    }

}
