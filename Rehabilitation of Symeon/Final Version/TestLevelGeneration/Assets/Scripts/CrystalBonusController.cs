using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBonusController : MonoBehaviour
{
    public float DistanceCrystal = 1f;
    private GameObject MainCharacter;

    void Start()
    {
        MainCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate ()
    {
        if (Vector2.Distance(transform.position, MainCharacter.transform.position) < DistanceCrystal)
        {
            ++MainCharacter.GetComponent<Player2D>().Crystals;
            gameObject.SetActive(false);
        }
	}
}
