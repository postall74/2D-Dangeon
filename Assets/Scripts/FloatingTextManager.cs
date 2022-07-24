using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.message.text = message;
        floatingText.message.fontSize = fontSize;
        floatingText.message.color = color;

        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();

    }

    private void Update()
    {
        foreach (FloatingText floatingText in floatingTexts)
            floatingText.UpdateFlotingText();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText text = floatingTexts.Find(t => !t.active);

        if (text == null)
        {
            text = new FloatingText();
            text.go = Instantiate(textPrefab);
            text.go.transform.SetParent(textContainer.transform);
            text.message = text.go.GetComponent<TMP_Text>();

            floatingTexts.Add(text);

        }

        return text;
    }
}
