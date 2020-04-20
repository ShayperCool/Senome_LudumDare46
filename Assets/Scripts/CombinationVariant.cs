using System;
using UnityEngine;


    [CreateAssetMenu(fileName ="NewRateVariant", menuName ="Create New Rate Variant", order =0)]
    [Serializable]
    public class CombinationVariant : ScriptableObject
    {
        public int numberOfCardsSimple;
        public int numberMovesSimple;
        public float rateTheEarthSimple;
        public float rateTheWindSimple;
        public float rateTheDeathSimple;
        public float rateTheSunSimple;
        public float rateTheRainSimple;
    }


