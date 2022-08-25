using UnityEngine;

public class healthbox : MonoBehaviour
{
    public float hp = 100f;
    public ParticleSystem ps;
    public Texture[] textures = {};
    public GameObject objScore;
    void Update()
    {
        if (hp <= 0f)
        {
            //if gold is destroying
            if(gameObject.tag == "gold")
            {

                Destroy(gameObject);
                objScore.GetComponent<ScoreManager>().score++;  
            }
            //if any block is destroying
            else if (gameObject.tag == "core")
                    Destroy(gameObject);
        }
        else if (hp < 100f && hp > 50)
            gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textures[0]);
        else if (hp <= 50f && hp >40)
            gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textures[1]);
        else if (hp < 40f && hp > 0)
            gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textures[2]);
    }
 
}
