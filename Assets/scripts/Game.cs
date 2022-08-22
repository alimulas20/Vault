using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public SteeringWheel cover;
    public SteeringWheel outer;
    public Text ques;
    public Text value;
    public Text intervalText;
    public Timer slider;
    public Timer[] locks;

    bool levelup;
    bool start = true;
    bool stopGen = false;
    int level;
    int[] interval = { 6, 6, 5, 5, 4, 4, 3, 3, 2, 2, 1, 1, 0, 0, 0 };
    int[] max = { 20, 30, 40, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
    int result;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        StartCoroutine(NumberGen());
        levelup = false;
    }

    // Update is called once per frame
    void Update()
    {
        value.text = cover.GetValue(max[level]).ToString();
        if(!levelup)
        intervalText.text = "+/-" + interval[level];
    }

    public void pick()
    {
       
        if(int.Parse( value.text)==result)
        {
            level++;
            stopGen = false;
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
                levelup = false;
            }
            start = false;
            ques.text = createQues();
            stopGen = true;
            yield return new WaitWhile(() => stopGen);

            if (level % 3 == 0)
            {
                outer.init = true;
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
        }
        
    }
    public string createQues()
    {
        string question;
        question = "";
       switch (level)
        {
            case 0:
                int number= Random.Range(1, 10);
                int number2 = Random.Range(1, 10);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 1:
                number = Random.Range(11, 20);
                number2 = Random.Range(1, 10);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 2:
                number = Random.Range(11, 20);
                number2 = Random.Range(11, 20);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 3:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 4:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 5:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 6:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 7:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 8:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 9:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 10:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 11:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 12:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 13:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            case 14:
                number = Random.Range(21, 25);
                number2 = Random.Range(21, 25);
                question = number + "+" + number2;
                result = number + number2;
                return question;
            default:
                question = "";
                result = 0;
                return question;
        }
    }
}
