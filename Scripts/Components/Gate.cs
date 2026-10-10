using Godot;
using System;
using System.Collections.Generic;

public partial class Gate : CircuitComponent
{
    private readonly Dictionary<uint, bool[]> _truthTable = new();

    public Gate(int inputCount, int outputCount, Func<bool[], bool[]> logic)
    {
        if (inputCount < 1 || inputCount > 20)
            throw new ArgumentOutOfRangeException(nameof(inputCount));

        if (outputCount < 1)
            throw new ArgumentOutOfRangeException(nameof(outputCount));

        for (int i = 0; i < inputCount; i++)
            AddInput();

        for (int i = 0; i < outputCount; i++)
            AddOutput();

        BuildTruthTable(logic);
    }

    private void BuildTruthTable(Func<bool[], bool[]> logic)
    {
        uint combinationCount = 1u << Inputs.Count;

        for (uint key = 0; key < combinationCount; key++)
        {
            bool[] inputValues = new bool[Inputs.Count];

            for (int i = 0; i < Inputs.Count; i++)
                inputValues[i] = (key & (1u << i)) != 0;

            bool[] outputValues = logic(inputValues);

            if (outputValues.Length != Outputs.Count)
                throw new InvalidOperationException("logic function returned the wrong number of outputs.");

            _truthTable[key] = (bool[])outputValues.Clone();
        }
    }

    public override void Evaluate()
    {
        uint key = 0;

        for (int i = 0; i < Inputs.Count; i++)
        {
            if (Inputs[i].Value)
                key |= 1u << i;
        }

        bool[] outputValues = _truthTable[key];

        for (int i = 0; i < Outputs.Count; i++)
            Outputs[i].Value = outputValues[i];
    }
}