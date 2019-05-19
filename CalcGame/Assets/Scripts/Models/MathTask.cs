using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTask
{
    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public MathOperationEnum MathOperation { get; set; }

    public int Answer
    {
        get
        {
            switch (MathOperation)
            {
                case MathOperationEnum.Add:
                    {
                        return Number1 + Number2;
                    }
                case MathOperationEnum.Subtract:
                    {
                        return Number1 - Number2;
                    }
                case MathOperationEnum.Multiply:
                    {
                        return Number1 * Number2;
                    }
                case MathOperationEnum.Divide:
                    {
                        return Number1 / Number2;
                    }
            }
            return default;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} {2}", Number1, MathOperation.MathOperationSymbol(), Number2);
    }
}
