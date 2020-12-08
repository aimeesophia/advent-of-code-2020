using System;
using System.Collections.Generic;
using Day8.Enums;

namespace Day8
{
    public static class BootLoader
    {
        public static int GetAccumulatorValueBeforeInfiniteLoop(string[] bootInstructions)
        {
            var normalisedBootInstructions = NormaliseBootInstructions(bootInstructions);

            return RunBootInstructions(normalisedBootInstructions);
        }

        private static int RunBootInstructions(List<KeyValuePair<BootInstruction, int>> bootInstructions)
        {
            var listOfBootInstructionsRanByIndex = new List<int>();
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
                    return accumulator;
                }
            }

            return 0;
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
