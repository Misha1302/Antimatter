using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

public class News : MonoBehaviour
{
    [SerializeField] private TMP_Text newsText;
    [SerializeField] private Transform newsTextTransform;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 speed;
    [SerializeField] private float timeOffset;

    [SerializeField] [Tooltip("In seconds")]
    private float letterReadingTime;

    private string[] _newsLines;
    private float _newsWaitTime;

    private void Start()
    {
        _newsLines = File.ReadAllText(@"src\News.txt").Split('\n');
        StartCoroutine(NewsUpdate());
    }

    private IEnumerator NewsUpdate()
    {
        // ReSharper disable IteratorNeverReturns
        while (true)
        {
            var randomNews = GetRandomNews(); // "Как выйти из Vim?\r";
            _newsWaitTime = randomNews.Length * letterReadingTime + timeOffset;

            newsText.text = randomNews;
            newsTextTransform.localPosition = startPosition;

            yield return new WaitForSeconds(_newsWaitTime);
        }
    }

    private string GetRandomNews()
    {
        return _newsLines[Random.Range(0, _newsLines.Length)];
    }

    private void FixedUpdate()
    {
        newsTextTransform.Translate(speed);
    }
}