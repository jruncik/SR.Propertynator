namespace SR.Propertynator.Model.Projects
{
    public sealed class Projects
    {
        public IProject Default { get; } = new ProjectDefault();

        private IProject TryCreateProject(string projectName)
        {
            return Project.Create(projectName.ToLower(), Default);
        }
    }
}