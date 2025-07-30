using UnityEngine;

public static class Calculator
{
    public static int number1;
    public static int number2;

    public static float answer;
    public static string MyName = "Rafael";

    public static float SumTwoNumbers(float firstNumber, float secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public static float GetRandomNumber()
    {
        return Random.Range(0, 100);
    }

    public static int SubtractTwoNumbers()
    {
        return number1 - number2;
    }
}
