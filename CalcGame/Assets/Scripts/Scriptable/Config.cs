using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CalcGame Config",fileName = "Config")]
public class Config : ScriptableObject
{
    // Answer range => Given wrong answer as far as the range is set
    [SerializeField]
    private int wrongAnswerRange1;
    [SerializeField]
    private int wrongAnswerRange2;
    [SerializeField]
    private int wrongAnswerRange3;

    [SerializeField]
    /// <summary>
    /// The numbers the player should calculate. 
    /// E.G. zeroCount = 2, means 0 - 100
    /// </summary>
    private uint zeroCount = 1;

    public int NumRange
    {
        get
        {
            if(zeroCount > 0)
            {
                uint count = zeroCount;
                int num = 1;
                while(count > 0)
                {
                    num *= 10;
                    count--;
                }
                return num;
            }
            else
            {
                return 10;
            }
        }
    }
    public int WrongAnswerRange1
    {
        get
        {
            return wrongAnswerRange1;
        }
    }
    public int WrongAnswerRange2
    {
        get
        {
            return wrongAnswerRange2;
        }
    }
    public int WrongAnswerRange3
    {
        get
        {
            return wrongAnswerRange3;
        }
    }

}
