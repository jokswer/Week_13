using System;
using System.Collections.Generic;
using System.Linq;
using Effects;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    private const int MAX_LEVEL = 10;
    private const int MAX_APPLIED_EFFECTS = 4;
    private const int MAX_CARD_TO_SHOW = 3;
    
    [SerializeField] private List<ContinuousEffect> _continuousEffectsApplied = new List<ContinuousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffectsApplied = new List<OneTimeEffect>();

    [SerializeField] private List<ContinuousEffect> _continuousEffects = new List<ContinuousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffects = new List<OneTimeEffect>();

    private void Awake()
    {
        for (int i = 0; i < _continuousEffects.Count; i++)
        {
            _continuousEffects[i] = Instantiate(_continuousEffects[i]);
        }
        
        for (int i = 0; i < _oneTimeEffects.Count; i++)
        {
            _oneTimeEffects[i] = Instantiate(_oneTimeEffects[i]);
        }
    }

    public void ShowCards()
    {
        var effectsToShow = new List<Effect>();

        for (int i = 0; i < _continuousEffectsApplied.Count; i++)
        {
            if (_continuousEffectsApplied[i].Level < MAX_LEVEL)
                effectsToShow.Add(_continuousEffectsApplied[i]);
        }
        
        for (int i = 0; i < _oneTimeEffectsApplied.Count; i++)
        {
            if (_oneTimeEffectsApplied[i].Level < MAX_LEVEL)
                effectsToShow.Add(_oneTimeEffectsApplied[i]);
        }

        if (_continuousEffectsApplied.Count < MAX_APPLIED_EFFECTS)
            effectsToShow.AddRange(_continuousEffects);
        
        if (_oneTimeEffectsApplied.Count < MAX_APPLIED_EFFECTS)
            effectsToShow.AddRange(_oneTimeEffects);

        var numberOfCardsToShow = Mathf.Min(effectsToShow.Count, MAX_CARD_TO_SHOW);

        var randomIndexes = RandomSort(effectsToShow.Count, numberOfCardsToShow);
        var effectForCards = new List<Effect>();

        for (int i = 0; i < randomIndexes.Length; i++)
        {
            var index = randomIndexes[i];
            effectForCards.Add(effectsToShow[index]);
        }

    }
    
    private int[] RandomSort(int length, int number)
    {
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
        for (int i = 0; i < array.Length; i++)
        {
            int oldValue = array[i];
            int newIndex = UnityEngine.Random.Range(0, array.Length);
            array[i] = array[newIndex];
            array[newIndex] = oldValue;
        }
        int[] result = new int[number];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }
        return result;
    }
}