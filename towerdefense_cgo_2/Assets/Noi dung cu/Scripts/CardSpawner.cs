using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private CardMaster cardPrefab;
    [SerializeField] private List<CardSO> database;

    [SerializeField] private Transform parent;

    private void Start()
    {
        SpawnCards();
    }

    private void SpawnCards()
    {
        foreach (var card in database)
        {
            var cardIns = Instantiate(cardPrefab, parent);
            cardIns.SetInfor(card);
        }
    }
}