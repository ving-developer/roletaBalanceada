using System.Collections;
using System.Collections.Generic;
using controller;
using UnityEngine;

public class BlastConfetti : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private Color[] colorArray;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0,0);
        explodeBlast();
    }

    public void explodeBlast()
    {
        for (int i = 0; i < 40; i++)
        {
            instantiateConfetti();
        }
    }

    private void instantiateConfetti()
    {
        int increment = 1;
        if (GetComponent<SpriteRenderer>().flipX)
            increment = -1;
        
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(this.GetComponent<RectTransform>(),false);
        instance.GetComponent<RectTransform>().anchoredPosition =
            new Vector3(Random.Range(1.25f, 3.5f)*increment, Random.Range(1.25f, 3.25f), 0);
        instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(250, 1000)*increment,Random.Range(500, 1000)));
        instance.GetComponent<SpriteRenderer>().color = colorArray[Random.Range(0,colorArray.Length)];
        instance.GetComponent<RectTransform>().localScale = new Vector3(0.2f,0.2f,0);
    }
}
