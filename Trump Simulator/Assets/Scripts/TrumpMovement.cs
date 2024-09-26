using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrumpMovement : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip theDogs;
    [SerializeField] AudioClip deathScream;
    [SerializeField] AudioClip shotScream;
    private float horizontalMovement;
    private float verticalMovement;
    private Rigidbody2D rb;
    Vector2 movement;
    //float speed = 10;
    [SerializeField] float moveDistance = 1f;
    [SerializeField] Sprite rightTrump;
    [SerializeField] Sprite leftTrump;
    [SerializeField] Sprite normalTrump;
    [SerializeField] Sprite rightTrumpOneEar;
    [SerializeField] Sprite leftTrumpOneEar;
    [SerializeField] Sprite normalTrumpOneEar;
    [SerializeField] Sprite rightTrumpNoEar;
    [SerializeField] Sprite leftTrumpNoEar;
    [SerializeField] Sprite normalTrumpNoEar;
    [SerializeField] Sprite deadTrump;
    public SpriteRenderer donaldSprite;
    private Sprite rightSprite;
    private Sprite leftSprite;
    public Sprite normalSprite;
    float health = 3f;
    bool dead = false;
    public bool killable = true;
    private Canvas canvas;
    [SerializeField] Scene scene;


    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
      //audioSource.Play();
       rb = GetComponent<Rigidbody2D>();
       donaldSprite = GetComponent<SpriteRenderer>();
       leftSprite = leftTrump;
       rightSprite = rightTrump;
       normalSprite = normalTrump;
       
       

    }

    // Update is called once per frame
    async void Update()
    {


        if (health != 0 && Input.GetKeyDown(KeyCode.A) || health != 0 && Input.GetKeyDown(KeyCode.LeftArrow))// Move left
        {
            donaldSprite.sprite = leftSprite;
            transform.position += Vector3.left * moveDistance;
            await Task.Delay(100);
            donaldSprite.sprite = normalSprite;
        }
        else if (health != 0 && Input.GetKeyDown(KeyCode.D) || health != 0 && Input.GetKeyDown(KeyCode.RightArrow)) // Move right
        {
            donaldSprite.sprite = rightSprite;
            transform.position += Vector3.right * moveDistance;
            await Task.Delay(100);
            donaldSprite.sprite = normalSprite;
        }
        if (Input.GetKeyDown(KeyCode.R) && dead == true)
        {
            SceneManager.LoadScene("PlayableScene");
        }
    }
    public void TrumpDamage(float damage)
    {
        //if (killable)
        //{
            health = Mathf.Clamp(health - damage, 0, 3);
        audioSource.PlayOneShot(shotScream);
            if (health == 2)
            {
                leftSprite = leftTrumpOneEar;
                rightSprite = rightTrumpOneEar;
                normalSprite = normalTrumpOneEar;
                donaldSprite.sprite = normalSprite;
                Debug.Log("I got shot");
            }
            else if (health == 1)
            {
                leftSprite = leftTrumpNoEar;
                rightSprite = rightTrumpNoEar;
                normalSprite = normalTrumpNoEar;
                donaldSprite.sprite = normalSprite;
                Debug.Log("I got shot again");
            }
            else if (health == 0 && !dead)
            {
                normalSprite = deadTrump;
                audioSource.PlayOneShot(deathScream);
                gameObject.GetComponent<Collider2D>().enabled = false;
                dead = true;
            }
            Debug.Log(health);
        //}
    }
  /* private void OnCollisionEnter2D(Collision2D collision)
    {
       FbiController fbi = collision.collider.GetComponent<Collider2D>().GetComponent<FbiController>();
        if (fbi != null)
        {
            killable = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        FbiController fbi = collision.collider.GetComponent<Collider2D>().GetComponent<FbiController>();
        if (fbi == null)
        {  killable = true; }
    }*/
}
