using UnityEngine;
using System;
using System.Collections.Generic;

public class MapGeneration : MonoBehaviour
{
    int[,] mapArray;

    void Start()
    {
        StartGeneration();
    }

    public void StartGeneration()
    {
        mapArray = InitializeArray(15, 7);
        SetRandomElementsInFirstCollum(mapArray, GenerateRandomNumbers());
        Debug.Log("Random numbers generated" + mapArray.GetLength(0));
        for (int i = 0; i < mapArray.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < mapArray.GetLength(1); j++)
            {
                SetDirection(mapArray, i, j);
            }
        }
        DisplayArray(mapArray);
    }

    static int[,] InitializeArray(int x, int y)
    {
        int[,] array = new int[x, y];
        return array;
    }

    static int[] GenerateRandomNumbers()
    {
        System.Random random = new System.Random();
        HashSet<int> uniqueNumbers = new HashSet<int>();
        int[] numbers = new int[4];

        for (int i = 0; i < numbers.Length;)
        {
            int randomNumber = random.Next(0, 7);

            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
                numbers[i] = randomNumber;
                i++;
            }
        }
        Debug.Log(numbers[0] + " " + numbers[1] + " " + numbers[2] + " " + numbers[3]);
        return numbers;
    }

    static void SetRandomElementsInFirstCollum(int[,] array, int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            array[0, numbers[i]] = 1;
        }
    }

    static void SetDirection(int[,] array, int x, int y)
    {
        System.Random random = new System.Random();
        print("x: " + x + " y: " + y + " array: " + array[x, y]);
        if (array[x, y] == 1)
        {
            int randomNumber = random.Next(0, 3);
            if (randomNumber == 0)
                try
                {
                    array[x + 1, y + 1] = 1;
                }
                catch (IndexOutOfRangeException e)
                {
                    Debug.Log("Index out of range");
                    array[x + 1, y] = 1;
                }
            else if (randomNumber == 1)
                array[x + 1, y] = 1;
            else if (randomNumber == 2)
                try
                {
                    array[x + 1, y - 1] = 1;
                }
                catch (IndexOutOfRangeException e)
                {
                    Debug.Log("Index out of range");
                    array[x + 1, y] = 1;
                }
        }
    }

    static void DisplayArray(int[,] array)
    {
        string arrayString = "";

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                arrayString += array[i, j] + " ";
            }
            arrayString += "\n";
        }
        Debug.Log(arrayString);
    }
}
