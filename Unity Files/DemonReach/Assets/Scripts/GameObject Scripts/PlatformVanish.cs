using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVanish : MonoBehaviour
{
    private new BoxCollider2D collider;
    private SpriteRenderer render;
    private PlatformEffector2D effect;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
        effect = GetComponent<PlatformEffector2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.tag == "Player")
        {
            StartCoroutine(Hide());
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1);
        render.color = new Color(0.3490196f,0.1888523f,0.1560876f,0.5f);
        yield return new WaitForSeconds(1);
        render.enabled = false;
        collider.enabled = false;
        effect.enabled = false;
        yield return new WaitForSeconds(3);
        render.color = new Color(0.3490196f,0.1888523f,0.1560876f);
        render.enabled = true;
        collider.enabled = true;
        effect.enabled = true;
    }
}
