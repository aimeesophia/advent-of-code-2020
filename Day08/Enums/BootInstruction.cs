using System.ComponentModel;

namespace Day08.Enums
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
