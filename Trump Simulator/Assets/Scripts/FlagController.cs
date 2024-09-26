using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    public SpriteRenderer flagSprite;
    [SerializeField] Sprite flag1;
    [SerializeField] Sprite flag2;
    [SerializeField] Sprite flag3;



    // Start is called before the first frame update
    void Start()
    {
        flagSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }
}
