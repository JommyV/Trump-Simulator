using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] GameObject canvas;
    private bool movable = false;
    private bool turnable = false;
    
    [SerializeField] Sprite walking;
    [SerializeField] Sprite stopped;
    public SpriteRenderer donaldSprite;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    private float talkingTime = 15f;

    void Start()
    {
        //Time.timeScale = 0.0000000001f;
        donaldSprite = GetComponent<SpriteRenderer>();
        
    }

    
    public void BeginGame()
    {
        //Time.timeScale = 1;
        canvas.SetActive(false);
        movable = true;
       audioSource.PlayOneShot(clip);
        

    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (movable)
        {
            transform.position += Vector3.left * 0.005f;
            donaldSprite.sprite = walking;
            if (transform.position.x < 0)
            {
                movable = false;
                donaldSprite.sprite = stopped;
                turnable = true;
            }
        }

        talkingTime -= Time.deltaTime;
        if (talkingTime < 0)
        {
            if(donaldSprite.flipX == false)
            {
                donaldSprite.flipX = true;
                talkingTime = 4f;
            }else 
            { 
                donaldSprite.flipX = false;
                talkingTime = 4f;
            }
            
            
            
        }
    }
}

