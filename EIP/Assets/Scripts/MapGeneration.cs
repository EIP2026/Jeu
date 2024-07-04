using UnityEngine;
using System;
using System.Collections.Generic;

public class MapGeneration : MonoBehaviour
{
    int[,] mapArray;
    public ObjectPool objectPool;

    int activeButton = 1;

    void Start()
    {
        if (objectPool == null)
        {
            Debug.LogError("ObjectPool is not assigned in the MapGeneration script.");
            return;
        }
        StartGeneration();
        GenerateMap();
    }

    public void StartGeneration()
    {
        mapArray = InitializeArray(15, 7);
        SetRandomElementsInFirstCollum(mapArray, GenerateRandomNumbers());
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

    void GenerateMap()
    {
        Debug.Log("Generating map");
        int width = mapArray.GetLength(0);
        int height = mapArray.GetLength(1);
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float spacing = 180f;
        float cellWidth = (screenWidth - (width + 1)) / 20;
        float cellHeight = (screenHeight - (height + 1)) / 12;

        Debug.Log("Cell width: " + cellWidth + " Cell height: " + cellHeight);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (mapArray[x, y] == 1)
                {
                    GameObject spriteObj = objectPool.GetObject();
                    RectTransform rectTransform = spriteObj.GetComponent<RectTransform>();
                    float posX = (100 * (y + 1));
                    float posY = (100 * (x + 1));
                    Debug.Log("x: " + x + " y: " + y + " posX: " + posX + " posY: " + posY);
                    rectTransform.anchoredPosition = new Vector2(posX, posY);
                }
            }
        }
    }
}
