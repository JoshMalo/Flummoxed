using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;



public class StackQueueExample : MonoBehaviour
{
    private Stack<int> stackOfNumbers = new();
    private Queue<int> queueOfNumbers = new();

    private void Start()
    {
        stackOfNumbers.Push(0);
        stackOfNumbers.Push(19);
        stackOfNumbers.Push(5);

        Debug.Log(stackOfNumbers.Peek()); // this will output 5.
        Debug.Log(stackOfNumbers.Pop()); // this will print 5 and remove it from the stack.
        Debug.Log(stackOfNumbers.Pop()); // this will print 19 and remove it from the stack.

        // queue

        queueOfNumbers.Enqueue(34);
        queueOfNumbers.Enqueue(100);
        queueOfNumbers.Enqueue(1);

        Debug.Log(queueOfNumbers.Peek()); // this will print 34.
        Debug.Log(queueOfNumbers.Dequeue()); // this will print 34 and remove it from the queue.
        Debug.Log(queueOfNumbers.Dequeue()); // this will print 100 and remove it from the queue.



    }
}

