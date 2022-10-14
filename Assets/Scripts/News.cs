using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

public class News : MonoBehaviour
{
    [SerializeField] private TMP_Text newsText;
    [SerializeField] private Transform newsTextTransform;
    [SerializeField] private float newsWaitTime;

    private string[] _newsLines;

    private void Start()
    {
        _newsLines = File.ReadAllText(@"src\News.txt").Split('\n');
        StartCoroutine(NewsUpdate());
    } // ReSharper disable IteratorNeverReturns
    private IEnumerator NewsUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(newsWaitTime);
            newsText.text = _newsLines[Random.Range(0, _newsLines.Length)];
        }
    }
}