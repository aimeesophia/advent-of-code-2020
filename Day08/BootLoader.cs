using System;
using System.Collections.Generic;
using System.Linq;
using Day08.Enums;

namespace Day08
{
    public static class BootLoader
    {
        public static Dictionary<EvaluatedInstructions, int> EvaluateInstructions(string[] bootInstructions)
        {
            var normalisedBootInstructions = NormaliseBootInstructions(bootInstructions);
            var evaluatedInstructions = new Dictionary<EvaluatedInstructions, int>();

            var unsuccessfulRunAccumulator = RunBootInstructions(normalisedBootInstructions);
            evaluatedInstructions.Add(EvaluatedInstructions.UnsuccessfulRunAccumulator, unsuccessfulRunAccumulator.Value);

            var successfulRunAccumulator = BruteForceBootInstructions(normalisedBootInstructions);
            evaluatedInstructions.Add(EvaluatedInstructions.SuccessfulRunAccumulator, successfulRunAccumulator);

            return evaluatedInstructions;
        }

        private static int BruteForceBootInstructions(List<KeyValuePair<BootInstruction, int>> bootInstructions)
        {
            var indicesOfJmpInstruction = GetIndicesOfBootInstructionType(bootInstructions, BootInstruction.jmp);

            foreach (var i in indicesOfJmpInstruction)
            {
                var newBootInstructions = AmendBootInstructions(bootInstructions, i, BootInstruction.nop);

                var runResult = RunBootInstructions(newBootInstructions);

                if (runResult.Key == bootInstructions.Count)
                {
                    return runResult.Value;
                }
            }

            return 0;
        }

        private static List<KeyValuePair<BootInstruction, int>> AmendBootInstructions(List<KeyValuePair<BootInstruction, int>> bootInstructions, int indexOfInstructionToAmend, BootInstruction newInstruction)
        {
            var currentBootInstruction = bootInstructions[indexOfInstructionToAmend];
            var newBootInstruction = new KeyValuePair<BootInstruction, int>(newInstruction, currentBootInstruction.Value);

            var newBootInstructions = bootInstructions.Select(x => x).ToList();
            newBootInstructions[indexOfInstructionToAmend] = newBootInstruction;

            return newBootInstructions;
        }

        private static List<int> GetIndicesOfBootInstructionType(List<KeyValuePair<BootInstruction, int>> bootInstructions, BootInstruction bootInstruction)
        {
            return bootInstructions
                .Select((bi, index) => bi.Key == bootInstruction ? index : -1)
                .Where(i => i >= 0)
                .ToList();
        }

        private static KeyValuePair<int, int> RunBootInstructions(List<KeyValuePair<BootInstruction, int>> bootInstructions)
        {
            var listOfBootInstructionsRanByIndex = new List<int>();
            KeyValuePair<int, int> runResult;
            var accumulator = 0;

            for (int i = 0; i < bootInstructions.Count;)
            {
                if (!listOfBootInstructionsRanByIndex.Contains(i))
                {
                    var bootInstruction = bootInstructions[i];
                    listOfBootInstructionsRanByIndex.Add(i);

                    switch (bootInstruction.Key)
                    {
                        case BootInstruction.acc:
                            accumulator += bootInstruction.Value;
                            i++;
                            break;
                        case BootInstruction.jmp:
                            i += bootInstruction.Value;
                            break;
                        case BootInstruction.nop:
                            i++;
                            break;
                    }
                }
                else
                {
                    runResult = new KeyValuePair<int, int>(listOfBootInstructionsRanByIndex.Count, accumulator);
                    return runResult;
                }
            }

            runResult = new KeyValuePair<int, int>(bootInstructions.Count, accumulator);
            return runResult;
        }

        private static List<KeyValuePair<BootInstruction, int>> NormaliseBootInstructions(string[] bootInstructions)
        {
            var normalisedBootInstructions = new List<KeyValuePair<BootInstruction, int>>();

            foreach (var bootInstruction in bootInstructions)
            {
                var splitBootInstruction = bootInstruction.Split(" ");
                var bootInstructionEnum = Enum.Parse<BootInstruction>(splitBootInstruction[0]);
                var bootInstructionInt = int.Parse(splitBootInstruction[1]);

                var normalisedBootInstruction = new KeyValuePair<BootInstruction, int>(bootInstructionEnum, bootInstructionInt);

                normalisedBootInstructions.Add(normalisedBootInstruction);
            }

            return normalisedBootInstructions;
        }
    }
}
