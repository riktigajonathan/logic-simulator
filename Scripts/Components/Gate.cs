using Godot;
using System;
using System.Collections.Generic;

public partial class Gate : CircuitComponent
{
	private int[] _truthTable;

    public Gate(int[] table, int inputCount = 2, int outputCount = 1) : base()
    {
        for (int i = 0; i < inputCount; i++)
            AddInput();

        for (int i = 0; i < outputCount; i++)
            AddOutput();

        BuildTruthTable(table);
    }

    private void BuildTruthTable(int[] truthTable)
	{
		_truthTable = truthTable;
    }

	public override void Evaluate()
	{
        uint inputValue = 0;

        for (int i = 0; i < Inputs.Count; i++)
        {
            if (Inputs[i].Value)
                inputValue |= 1u << i;
        }

        if (inputValue >= (uint)_truthTable.Length)
            return;

        for (int i = 0; i < Outputs.Count; i++)
        {
            Outputs[i].Value = (_truthTable[inputValue] & (1 << i)) != 0;
        }
    }
}
