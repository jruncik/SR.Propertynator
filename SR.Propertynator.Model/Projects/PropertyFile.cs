namespace SR.Propertynator.Model.Projects
{
    public sealed class PropertyFile
    {
        public IProject Default { get; } = new ProjectDefault();

        private IProject TryCreateProject(string projectName)
        {
            return Project.Create(projectName.ToLower(), Default);
        }
    }
}