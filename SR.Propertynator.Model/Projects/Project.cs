using SR.Propertynator.Model.Branches;
using SR.Propertynator.Model.BuildModes;

namespace SR.Propertynator.Model.Projects
{
    public abstract class Project : IProject, IWritable
    {
        private readonly IProject _defaultProject;

        private BuildSource? _buildSource;

        private BuildMode? _modeBuild;

        private BuildMode? _modeDeveloper;

        private TestsConfig? _testsConfig;

        protected Project(ProjectType type, IProject defaultProject)
        {
            _defaultProject = defaultProject;
            Type = type;
        }

        public ProjectType Type { get; }

        public string Name => ProjectTypeEnumHelperLower.ToString(Type);

        public BuildMode BuildModeBuild
        {
            get => _modeBuild ?? _defaultProject.BuildModeBuild;
            set => _modeBuild = value;
        }

        public BuildMode BuildModeDeveloper
        {
            get => _modeDeveloper ?? _defaultProject.BuildModeDeveloper;
            set => _modeDeveloper = value;
        }

        public BuildSource BuildSource
        {
            get => _buildSource ?? _defaultProject.BuildSource;
            set => _buildSource = value;
        }

        public TestsConfig TestsConfig
        {
            get => _testsConfig ?? _defaultProject.TestsConfig;
            set => _testsConfig = value;
        }

        public void Write(TextWriter stream)
        {
            BuildModeBuild.Write(stream, Name);
            BuildModeDeveloper.Write(stream, Name);
            BuildSource.Write(stream, Name);
            TestsConfig.Write(stream, Name);
        }

        public static IProject Create(string projectName, IProject defaultProject)
        {
            return Create(ProjectTypeEnumHelperLower.FromString(projectName), defaultProject);
        }

        public static IProject Create(ProjectType type, IProject defaultProject)
        {
            switch (type)
            {
                case ProjectType.Framework: return new Framework(defaultProject);
                case ProjectType.Repository: return new Repository(defaultProject);
                case ProjectType.Olap: return new Olap(defaultProject);
                case ProjectType.Modeling: return new Modeling(defaultProject);
                case ProjectType.Designer: return new Designer(defaultProject);
                case ProjectType.Depmservice: return new Epmservice(defaultProject);
                case ProjectType.Consolidation: return new Consolidation(defaultProject);
                case ProjectType.Appengine: return new Appengine(defaultProject);
                case ProjectType.Dashboards: return new Dashboards(defaultProject);
                case ProjectType.Appstudio: return new Appstudio(defaultProject);
                case ProjectType.Officeinteg: return new Officeinteg(defaultProject);
                case ProjectType.Administration: return new Administration(defaultProject);
                case ProjectType.Content: return new Content(defaultProject);
                case ProjectType.Deployment: return new Deployment(defaultProject);
                case ProjectType.Tests: return new Tests(defaultProject);

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private sealed class Administration : Project
        {
            public Administration(IProject defaultProject)
                : base(ProjectType.Administration, defaultProject)
            {
            }
        }

        private sealed class Appengine : Project
        {
            public Appengine(IProject defaultProject)
                : base(ProjectType.Appengine, defaultProject)
            {
            }
        }

        private sealed class Appstudio : Project
        {
            public Appstudio(IProject defaultProject)
                : base(ProjectType.Appstudio, defaultProject)
            {
            }
        }

        private class Consolidation : Project
        {
            public Consolidation(IProject defaultProject)
                : base(ProjectType.Consolidation, defaultProject)
            {
            }
        }

        private sealed class Content : Project
        {
            public Content(IProject defaultProject)
                : base(ProjectType.Content, defaultProject)
            {
            }
        }

        private sealed class Dashboards : Project
        {
            public Dashboards(IProject defaultProject)
                : base(ProjectType.Dashboards, defaultProject)
            {
            }
        }

        private sealed class Deployment : Project
        {
            public Deployment(IProject defaultProject)
                : base(ProjectType.Deployment, defaultProject)
            {
            }
        }

        private sealed class Epmservice : Project
        {
            public Epmservice(IProject defaultProject)
                : base(ProjectType.Depmservice, defaultProject)
            {
            }
        }

        private sealed class Designer : Project
        {
            public Designer(IProject defaultProject)
                : base(ProjectType.Designer, defaultProject)
            {
            }
        }

        private sealed class Framework : Project
        {
            public Framework(IProject defaultProject)
                : base(ProjectType.Framework, defaultProject)
            {
            }
        }

        private sealed class Modeling : Project
        {
            public Modeling(IProject defaultProject)
                : base(ProjectType.Modeling, defaultProject)
            {
            }
        }

        private sealed class Officeinteg : Project
        {
            public Officeinteg(IProject defaultProject)
                : base(ProjectType.Officeinteg, defaultProject)
            {
            }
        }

        private sealed class Olap : Project
        {
            public Olap(IProject defaultProject)
                : base(ProjectType.Olap, defaultProject)
            {
            }
        }

        private sealed class Repository : Project
        {
            public Repository(IProject defaultProject)
                : base(ProjectType.Repository, defaultProject)
            {
            }
        }

        private sealed class Tests : Project
        {
            public Tests(IProject defaultProject)
                : base(ProjectType.Tests, defaultProject)
            {
            }
        }
    }
}