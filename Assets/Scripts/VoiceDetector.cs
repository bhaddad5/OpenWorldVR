using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceDetector : MonoBehaviour
{
	public enum SpellActions
	{
		Fireball,
		SpellShield
	}

	KeywordRecognizer keywordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// Use this for initialization
	void Start()
	{
		AddSpellKeyword(SpellActions.Fireball, new[] {"ignus"});
		AddSpellKeyword(SpellActions.SpellShield, new[] {"haedrus"});

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

	private void AddSpellKeyword(SpellActions action, string[] actionKeyWords)
	{
		foreach (string word in actionKeyWords)
		{
			keywords.Add(word, () => ExecuteSpellAction(action));
		}
	}

	private void ExecuteSpellAction(SpellActions action)
	{
		Singletons.SpellExecutor().ExecuteSpell(action);
	}
}
