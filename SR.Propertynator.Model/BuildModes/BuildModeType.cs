using SR.Propertynator.Model.Helpers;

namespace SR.Propertynator.Model.BuildModes
{
    public enum BuildModeType
    {
        Binary,
        Source,
        Ignore
    }

    public sealed class BuildModeTypeEnumHelperLower : EnumHelperLower<BuildModeType>
    {
    }
}