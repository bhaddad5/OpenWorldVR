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
	void Start ()
	{
		AddInventoryKeyword(InventoryController.SummonableItems.staff, new[] {"staff"});
		AddInventoryKeyword(InventoryController.SummonableItems.sword, new []{"sword", "blade"});

		AddSpellKeyword(SpellActions.Fireball, new[] {"ignus"});
		AddSpellKeyword(SpellActions.SpellShield, new []{"haedrus"});

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
			Debug.Log(args.text);
			keywordAction.Invoke();
		}
	}

	private void AddSpellKeyword(SpellActions action, string[] actionKeyWords)
	{
		foreach (string word in actionKeyWords)
		{
			keywords.Add(word, ()=>ExecuteSpellAction(action));
		}
	}

	private void ExecuteSpellAction(SpellActions action)
	{
		Debug.Log(action.ToString());
		Singletons.SpellExecutor().ExecuteSpell(action);
	}

	private void AddInventoryKeyword(InventoryController.SummonableItems item, string[] actionKeyWords)
	{
		foreach (string word in actionKeyWords)
		{
			keywords.Add(word, () => ExecuteInventoryAction(item));
		}
	}

	private void ExecuteInventoryAction(InventoryController.SummonableItems item)
	{
		Debug.Log("Summoning: " + item);
		Singletons.InventoryController().SummonItemType(item);
	}
}
