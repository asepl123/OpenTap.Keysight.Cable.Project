
namespace OpenTap.Keysight.Cable.Project.EnumClass
{
    public enum EDutType
    {
        Cable,
        Waveguide
    }

    public enum S_Parameters
    {
        S11,
        S12,
        S21,
        S22
    }

    public enum MyMeas
    {
        MyMeas1,
        MyMeas2,
        MyMeas3,
        MyMeas4
    }

    public enum ESweepType
    {
        [Display("Analog")] ANALog,
        [Display("Stepped")] STEPped
    }

    public enum EAveragingMode
    {
        SWEEP,
        POINT
    }
}
