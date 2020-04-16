using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnAwakeLevelFour : MonoBehaviour
{
    public Animator letterbox;
    public Animator hud;
    public Animator boulder;
    // Start is called before the first frame update
    void Start()
    {
        letterbox.Play("FadeIn");
        hud.Play("HUDSlideInIdleForVoiceOver");
        boulder.Play("BoulderLevel4");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
