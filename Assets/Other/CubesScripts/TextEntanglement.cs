using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextEntanglement : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _textScramble;

    private void Start()
    {
        _text.DOText("Ќовый текст пожаловал", _textScramble).OnStepComplete(TextAdd);
    }

    private void TextAdd()
    {
        _text.DOText(" и был дополнен", _textScramble).SetRelative().OnStepComplete(TextHakked);
    }

    private void TextHakked()
    {
        _text.DOText(_text.text, _textScramble, true, ScrambleMode.All);
    }
}
