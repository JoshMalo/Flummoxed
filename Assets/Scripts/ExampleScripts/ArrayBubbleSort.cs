using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ArrayBubbleSort : MonoBehaviour
{
    [SerializeField] private int[] arrayOfNumbers;
    [SerializeField] private List<int> listOfNumbers = new List<int>(5);

    void Start()
    {
        //array initialization
        arrayOfNumbers = new int[5];

        //arrays cannot be increased, it needs to be re-created
        arrayOfNumbers[0] = Random.Range(0, 100);
        arrayOfNumbers[1] = Random.Range(0, 100);
        arrayOfNumbers[2] = Random.Range(0, 100);

        listOfNumbers.Add(1);
        listOfNumbers.Add(2);
        listOfNumbers.Add(3);

        //List works exactly like an array, even in memory
        listOfNumbers[2] = 100;
        listOfNumbers[1] = 20;

        //Differentiate methods from List
        listOfNumbers.Remove(2);
        listOfNumbers.RemoveAt(0);

        //Demonstrate Bubble Sort with numbers
        BubbleSort(ref arrayOfNumbers);
    }



    void BubbleSort(ref int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

    }
}