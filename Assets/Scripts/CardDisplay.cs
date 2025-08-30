using UnityEngine.Splines;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class CardDisplay : MonoBehaviour {
    [SerializeField] SplineContainer playerHandLocation;
    [SerializeField] Transform cardSpawnPoint;
    [SerializeField] GameObject cardPrefab;

    List<GameObject> playerHandCards = new();

    int maxHandSize = 11;

    public void DrawPlayerCard() {
        GameObject go = Instantiate(cardPrefab,
            cardSpawnPoint.position, cardSpawnPoint.rotation);
        playerHandCards.Add(go);
        PlacePlayerCard();
    }
    void PlacePlayerCard() {
        if (playerHandCards.Count == 0) return;

        float cardSpacing = 1f / maxHandSize;
        float cardPosition = 0.5f - (playerHandCards.Count - 1) * cardSpacing / 2;

        Spline spline = playerHandLocation.Spline;
        for (int i = 0; i < playerHandCards.Count; i++) {
            float p = cardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);

            playerHandCards[i].transform.DOMove(splinePosition, 0.25f);
            playerHandCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }
    }
}