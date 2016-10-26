using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceDetector : MonoBehaviour
{
	public SpellExecutor spellExecutor;

	public enum VoiceActions
	{
		Fireball,
		SpellShield
	}

	KeywordRecognizer keywordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// Use this for initialization
	void Start () {
		AddVoiceKeyword(VoiceActions.Fireball, new[] {"ignis", "ignus" });
		AddVoiceKeyword(VoiceActions.SpellShield, new []{"hadrus", "haedrus"});

		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		// if the keyword recognized is in our dictionary, call that Action.
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}

	private void AddVoiceKeyword(VoiceActions action, string[] actionKeyWords)
	{
		foreach (string word in actionKeyWords)
		{
			keywords.Add(word, ()=>ExecuteVoiceAction(action));
		}
	}

	private void ExecuteVoiceAction(VoiceActions action)
	{
		Debug.Log(action.ToString());
		spellExecutor.ExecuteSpell(action);
	}
}
