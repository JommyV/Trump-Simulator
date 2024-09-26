using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
    [SerializeField] GameObject crossHairPrefab;
    [SerializeField] GameObject[] shotPositions;
    private int i;
    [SerializeField] AudioSource shotSource;
    [SerializeField] AudioClip shotSound;
    [SerializeField] GameObject canvas;

    private float shotTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0)
        {
            i = Random.Range(0, shotPositions.Length);
            shoot(shotPositions[i]);
            shotTimer = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            shoot(shotPositions[0]);
        }
    }

    async void shoot(GameObject shot)
    {
        GameObject crosshairObject = Instantiate(crossHairPrefab, shot.transform.position, Quaternion.identity);

        crosshairObject.GetComponent<SpriteRenderer>().enabled = false;
        await Task.Delay(400);
        crosshairObject.GetComponent<SpriteRenderer>().enabled = true;
        await Task.Delay(400);
        crosshairObject.GetComponent<SpriteRenderer>().enabled = false;
        await Task.Delay(400);
        crosshairObject.GetComponent<SpriteRenderer>().enabled = true;
        shotSource.PlayOneShot(shotSound);
        crosshairObject.GetComponent<BoxCollider2D>().enabled = true;
        await Task.Delay(200);
        Destroy(crosshairObject);
    }
}
