//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

// Scriptable object to hold number of cans fallen over
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CanFallenData", order = 1)]
public class CanFallenAmount : ScriptableObject
{
    public int numberOfCansFallenOver;
}
