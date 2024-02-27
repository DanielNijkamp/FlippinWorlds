
using System;
using Randomization;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Randomization
{
    [Serializable]
    public class VariableFloat
    {
        public VariableType VariableType;
        public float FixedValue;
        public float MinValue;
        public float MaxValue;
        private float? _generatedValue;

        public float Value
        {
            get
            {
                switch (VariableType)
                {
                    case VariableType.Fixed:
                        return FixedValue;
                    case VariableType.ConstRandom:
                        _generatedValue ??= Random.Range(MinValue, MaxValue);
                        return (float)_generatedValue;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}


