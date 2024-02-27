using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Randomization
{
    [Serializable]
    public class VariableInt
    {
        public VariableType VariableType;
        public int FixedValue;
        public int MinValue;
        public int MaxValue;
        private int? _generatedValue;

        public int Value
        {
            get
            {
                switch (VariableType)
                {
                    case VariableType.Fixed:
                        return FixedValue;
                    case VariableType.ConstRandom:
                        _generatedValue ??= Random.Range(MinValue, MaxValue);
                        return (int)_generatedValue;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
