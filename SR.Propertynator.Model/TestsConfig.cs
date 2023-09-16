using SR.Propertynator.Model.Projects;

namespace SR.Propertynator.Model
{
    public sealed class TestsConfig
    {
        public bool RunUnitTests { get; set; } = true;

        public bool RunIntegrationTests { get; set; } = false;

        public static void Write(TextWriter stream, IProject project)
        {
            throw new NotImplementedException();
        }
    }
}