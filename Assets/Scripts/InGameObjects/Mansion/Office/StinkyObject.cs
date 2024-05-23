using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StinkyObject : MonoBehaviour
{
    private string[] _messages = { "Ну и вонь", "Пахнет как-будто кто-то умер", "Как-же тут воняет"};

    private void Start()
    {
        StartCoroutine(StartStink());
    }

    public void StopStink()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartStink()
    {
        yield return null;
        while (true)
        {
            Player.BubbleText.ShowMessage(_messages[Random.Range(0, 2)]);
            yield return new WaitForSeconds(Random.Range(10, 20));
        }
    }
}
