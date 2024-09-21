using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtensionsScript
{
    /// <summary>
    /// Call this method to return a random element from the array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_array"></param>
    /// <returns>The randomly selected element.</returns>
    public static T GetRandomElement<T>(this T[] _array)
    {
        if (_array == null) {
            Debug.LogError("Array is null.");
            return default;
        }
        if(_array.Length == 0)
        {
            Debug.LogError("Array is empty.");
            return default;
        }

        int randomIndex = Random.Range(0, _array.Length);
        return _array[randomIndex];
    }


    /// <summary>
    /// Call this method to get a new shuffled version of the array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_array"></param>
    /// <returns>A new shuffled array.</returns>
    public static T[] GetShuffled<T>(this T[] _array)
    {
        if (_array == null)
        {
            Debug.LogError("Array is null.");
            return default;
        }
        if (_array.Length == 0)
        {
            Debug.LogError("Array is empty.");
            return default;
        }

        T[] newArray = _array;

        for (int i = newArray.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = newArray[i];
            newArray[i] = newArray[randomIndex];
            newArray[randomIndex] = temp;
        }

        return newArray;
    }


    /// <summary>
    /// Call this method to shuffle the elements of the array. This changes the order of the original array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_array"></param>
    public static void Shuffle<T>(this T[] _array)
    {
        if (_array == null)
        {
            Debug.LogError("Array is null.");
            return;
        }
        if (_array.Length == 0)
        {
            Debug.LogError("Array is empty.");
            return;
        }

        for (int i = _array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = _array[i];
            _array[i] = _array[randomIndex];
            _array[randomIndex] = temp;
        }
    }


    /// <summary>
    /// Call this method to return an index in the range of the length taking taking the current index and adding 1;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_array"></param>
    /// <param name="_currentIndex"></param>
    /// <returns>The new index.</returns>
    public static int ShiftIterator<T>(this T[] _array, int _currentIndex)
    {
        int newIndex = _currentIndex + 1;
        newIndex = newIndex % _array.Length;

        if (newIndex < 0)
        {
            newIndex += _array.Length;
        }

        return newIndex;
    }


    /// <summary>
    /// Call this method to return an index in the range of the length taking as parameters the current index to iterate from and the distance that index should be shifted.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_array"></param>
    /// <param name="_currentIndex"></param>
    /// <param name="_shiftDistance"></param>
    /// <returns>The new index.</returns>
    public static int ShiftIterator<T>(this T[] _array, int _currentIndex, int _shiftDistance)
    {
        int newIndex = _currentIndex + _shiftDistance;
        newIndex = newIndex % _array.Length;

        if(newIndex < 0)
        {
            newIndex += _array.Length;
        }

        return newIndex;
    }
}

//the following is code to paste into the body of another script (attached to a object in your scene) to show the usage the extensions:

/*
int[] testInts = { 0, 1, 2, 3, 4, 5, 6 };


    // Start is called before the first frame update
    void Start()
    {
        print("Original array:");
        string tmpString = "";
        foreach (int i in testInts)
        {
            tmpString += i.ToString() + " ";
        }
        print(tmpString);
        print("-----------------");
        

        print("Three random elements:");
        print(testInts.GetRandomElement().ToString());
        print(testInts.GetRandomElement().ToString());
        print(testInts.GetRandomElement().ToString());
        print("-----------------");


        print("New array from shuffled elements:");
        int[] newArray = testInts.GetShuffled();
        tmpString = "";
        foreach (int i in newArray)
        {
            tmpString += i.ToString() + " ";
        }
        print(tmpString);
        print("-----------------");


        print("Shuffled Array:");
        testInts.Shuffle();
        tmpString = "";
        foreach (int i in testInts)
        {
            tmpString += i.ToString() + " ";
        }
        print(tmpString);
        print("-----------------");


        print("Iterate (default shift distance of +1:) 15 times");
        int index = 0;
        print("Index = " + index.ToString() + " : value = " + testInts[index]);
        for (int i = 0; i < 15; i++)
        {
            index = testInts.ShiftIterator(index);
            print("Index = " + index.ToString() + " : value = " + testInts[index]);
        }
        print("-----------------");


        print("Iterate with shift distance of +3:) 15 times");
        index = 0;
        print("Index = " + index.ToString() + " : value = " + testInts[index]);
        for (int i = 0; i < 15; i++)
        {
            index = testInts.ShiftIterator(index, 3);
            print("Index = " + index.ToString() + " : value = " + testInts[index]);
        }
        print("-----------------");


        print("Iterate with shift distance of -4:) 15 times");
        index = 0;
        print("Index = " + index.ToString() + " : value = " + testInts[index]);
        for (int i = 0; i < 15; i++)
        {
            index = testInts.ShiftIterator(index, -4);
            print("Index = " + index.ToString() + " : value = " + testInts[index]);
        }        
    }
*/
