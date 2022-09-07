using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Game : MonoBehaviour
{
  
    public SteeringWheel cover;
    public SteeringWheel outer;
  
    public Text ques;
    public Text value;
    public Text intervalText;
  
    public Timer slider;
    public Timer[] locks;
    public Image openSafe;
    public Image openSafeBg;

    bool levelup;
    bool start = true;
    bool stopGen = false;
    int level;
    int[] interval = { 3, 3, 3, 3, 3, 3, 2, 2, 2, 2,2,2, 1, 1,1, 0, 0, 0 };
    int[] max = { 10, 10, 20, 20, 20, 20, 20, 50, 50, 50, 50, 75, 20, 100, 50, 100, 25, 50 };
    Color[,] safeColor = { {Color.red,Color.yellow } };/// Kasa renkleri düþünülecek
    int result;
    // Start is called before the first frame update
    void Start()
    {
        level = 16;/////////////////deðiþecek
        StartCoroutine(NumberGen());
        levelup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (level != 18)
        {
            value.text = cover.GetValue(max[level]).ToString();
            if (!levelup)
                intervalText.text = "+/-" + interval[level];
        }
        if (slider.stopTimer)
            StartCoroutine(finish());



    }

    public void pick()
    {
        if(int.Parse( value.text)==result)
        {
            level++;
            if(level!=18)
            stopGen = false;
            if (level % 3 == 0)
            {
                outer.init = true;
                outer.startTurn();
                locks[2].start = true;
                locks[5].start = true;

            }
            else if (level % 3 == 1)
            {
                locks[0].start = true;
                locks[3].start = true;
            }
            else
            {
                locks[1].start = true;
                locks[4].start = true;
            }
            if (level == 18)
            {
                StartCoroutine(finish());
            }
        }
    }
    IEnumerator NumberGen()
    {
        while (!slider.stopTimer)
        {
            if (level  % 3 == 0 && !start)
            {
                levelup = true;
                ques.text = "Open Safe";
                intervalText.text = "";
                yield return new WaitWhile(() => outer.GetAngle() != 90);

                ///kasa açýlma animasyonu
                SafeOpener();
                ///kasa animasyonu bitiþini beklet
                yield return new WaitForSeconds(1.5f);
                openSafe.gameObject.SetActive(false);
                openSafeBg.gameObject.SetActive(false);
                outer.stopTurn();
                for(int i = 0; i < locks.Length; i++)
                {
                    locks[i].resTime();
                }
                levelup = false;
            }
            start = false;
            ques.text = createQues();
            stopGen = true;
            yield return new WaitWhile(() => stopGen);

            
        }
        
        
    }
    public string createQues()
    {
        string question;
        question = "";
        int number;
        int number2;
       switch (level)//10,10,20,20,20,20,20,50,50,50,50,75,20,100,50,100,25,50
        {
           
            case 0:
                number= Random.Range(1, 5);
                number2 = Random.Range(1, 5);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 1:
                number = Random.Range(2, 5);
                number2 = Random.Range(1, number);
                question = number + "-" + number2;
                result = number - number2;
                return question;
            case 2:
                number = Random.Range(1, 5);
                number2 = Random.Range(1, 10);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 3:
                number = Random.Range(1, 10);
                number2 = Random.Range(1, 10);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 4:
                number = Random.Range(2, 10);
                number2 = Random.Range(1, number);
                question = number + "-" + number2;
                result = number - number2;
                return question;
            case 5:
                number = Random.Range(2, 5);
                number2 = Random.Range(2, 5);
                question = number + "x" + number2;
                result = number * number2;
                return question;
            case 6:
                number = Random.Range(8, 11);
                number2 = Random.Range(2, 5);
                number += number2 - (number % number2);
                question = number + "/" + number2;
                result = number / number2;
                return question;

            case 7:
                number = Random.Range(2, 10);
                number2 = Random.Range(10, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
           
            case 8:
                number = Random.Range(10, 25);
                number2 = Random.Range(10, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 9:
                number = Random.Range(2, 5);
                number2 = Random.Range(2, 10);
                question = number + "x" + number2;
                result = number * number2;
                return question;
            case 10:
                number = Random.Range(15, 20);
                number2 = Random.Range(2, number);
                question = number + "-" + number2;
                result = number - number2;
                return question;
            case 11:
                number = Random.Range(10, 25);
                number2 = Random.Range(25, 50);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 12:
                number = Random.Range(10, 21);
                number2 = Random.Range(2, 6);
                number += number2-( number % number2);
                question = number + "/" + number2;
                result = number / number2;
                return question;
            case 13:
                number = Random.Range(25, 50);
                number2 = Random.Range(25, 50);
                question = number + "+" + number2;
                result = number + number2;
                return question;
          
            case 14:
                number = Random.Range(25, 50);
                number2 = Random.Range(11, number);
                question = number + "-" + number2;
                result = number - number2;
                return question;
            case 15:
                number = Random.Range(2, 10);
                number2 = Random.Range(2, 10);
                question = number + "x" + number2;
                result = number * number2;
                return question;
            case 16:
                number = Random.Range(26, 51);
                number2 = Random.Range(2, 14);
                number += number2 - (number % number2);
                question = number + "/" + number2;
                result = number / number2;
                return question;
            case 17:
                number = Random.Range(25, 75);
                number2 = Random.Range(21, number);
                question = number + "-" + number2;
                result = number - number2;
                return question;
       
            default:
                question = "";
                result = 0;
                return question;
        }
       
    }
    void SafeOpener()
    {
        openSafe.gameObject.SetActive(true);
        openSafeBg.gameObject.SetActive(true);
        Sequence safeSeq = DOTween.Sequence();
        safeSeq.Append(openSafeBg.DOFade(1, .5f));
        safeSeq.Join(openSafe.DOFade(1, .5f));
        safeSeq.AppendInterval(.5f);
        safeSeq.Append(openSafeBg.DOFade(0, .5f));
        safeSeq.Join(openSafe.DOFade(0, .5f));

    }
    IEnumerator finish()
    {
        if (slider.stopTimer)
        {
            Debug.Log("Süre bitti");
        }
          
        else
        {
            yield return new WaitWhile(() => outer.GetAngle() != 90);
            Debug.Log("bitti");
        }
          


    }
}
