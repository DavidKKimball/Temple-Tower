using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnAwakeLevel5 : MonoBehaviour
{
    public Animator letterbox;
    public Animator hud;
    // Start is called before the first frame update
    void Start()
    {
        letterbox.Play("FadeIn");
        hud.Play("HUDSlideInForVoiceOver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
