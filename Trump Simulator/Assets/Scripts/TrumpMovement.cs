using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TrumpMovement : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip theDogs;
    private float horizontalMovement;
    private float verticalMovement;
    private Rigidbody2D rb;
    Vector2 movement;
    float speed = 10;
    [SerializeField] float moveDistance = 1f;
    [SerializeField] Sprite rightTrump;
    [SerializeField] Sprite leftTrump;
    [SerializeField] Sprite normalTrump;
    SpriteRenderer donaldSprite;




    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
       audioSource.Play();
       rb = GetComponent<Rigidbody2D>();
       donaldSprite = GetComponent<SpriteRenderer>();
       

    }

    // Update is called once per frame
    async void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // Move left
        {
            donaldSprite.sprite = leftTrump;
            transform.position += Vector3.left * moveDistance;
            await Task.Delay(100);
            donaldSprite.sprite = normalTrump;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // Move right
        {
            donaldSprite.sprite = rightTrump;
            transform.position += Vector3.right * moveDistance;
            await Task.Delay(100);
            donaldSprite.sprite = normalTrump;
        }
        
    }
    private void FixedUpdate()
    {
       
    }
}
