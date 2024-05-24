using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicPhrases : MonoBehaviour
{
    [SerializeField] private List<string> _messages = new()
        { "Ну и вонь", "Пахнет как-будто кто-то умер", "Как-же тут воняет" };

    private void Start()
    {
        StartCoroutine(StartPhrases());
    }

    public void StopPhrases()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartPhrases()
    {
        yield return null;
        while (true)
        {
            Player.BubbleText.ShowMessage(_messages[Random.Range(0, _messages.Count-1)]);
            yield return new WaitForSeconds(Random.Range(10, 20));
        }
    }
}