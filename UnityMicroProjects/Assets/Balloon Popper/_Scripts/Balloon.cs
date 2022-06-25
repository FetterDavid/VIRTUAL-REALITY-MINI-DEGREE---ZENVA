using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int scoreToGet = 1;
    public int clickToPopp = 3;
    public float growPerClick = 0.2f;

    public ScoreManager scoreManager;

    void OnMouseDown()
    {
        clickToPopp--;
        transform.localScale += Vector3.one * growPerClick;

        if (clickToPopp == 0)
        {
            scoreManager.GetScore(scoreToGet);
            Destroy(gameObject);
        }
    }
}
