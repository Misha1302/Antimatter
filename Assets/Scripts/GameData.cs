using System;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private string peopleCountTextString;
    [SerializeField] private TMP_Text peopleCountText;
    
    private BigInteger _peopleCount;
    public BigInteger PeopleCount
    {
        get => _peopleCount;
        set
        {
            _peopleCount = value;
            peopleCountText.text = string.Format(peopleCountTextString, value.ToString());
        }
    }

    private void Update()
    {
        PeopleCount++;
    }
}