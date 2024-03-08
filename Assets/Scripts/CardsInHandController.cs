using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsInHandController : MonoBehaviour
{
    public GameObject[] positions = new GameObject[10];

    public Transform GetPosition(int index) => positions[index].transform;
}
