using System.ComponentModel;

namespace BrainStormHackathon.Application.Enums
{
    public enum Priority
    {
        [Description("low")]
        Low,
        [Description("medium")]
        Medium,
        [Description("high")]
        High,
        [Description("critical")]
        Critical
    }
}