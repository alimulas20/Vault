using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Play : MonoBehaviour
{
    public GameObject GM;
    public Canvas Game;
    public Image Intro;
    public Image IntroButton;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Intro.color.a == 0)
        {
            Intro.gameObject.SetActive(false);
            IntroButton.gameObject.SetActive(false);
            Player.SetActive(false);
        }
    }
    public void PlayButton()
    {
        Intro.DOFade(0, 1f).SetAutoKill();
        IntroButton.DOFade(0, 1f).SetAutoKill();
        Game.gameObject.SetActive(true);
        GM.SetActive(true);
    }
}
