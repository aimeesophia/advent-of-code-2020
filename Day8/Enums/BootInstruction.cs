using System.ComponentModel;

namespace Day8.Enums
{
    public enum BootInstruction
    {
        [Description("Accumulator")]
        acc,
        [Description("Jump")]
        jmp,
        [Description("No operation")]
        nop
    }
}
