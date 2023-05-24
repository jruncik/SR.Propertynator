using System.Diagnostics;

namespace SR.Propertynator.Model.Projects;

public sealed class Projects
{
    public IProject Default { get; } = new ProjectDefault();

    private IProject TryCreateProject(string projectName)
    {
        switch (projectName)
        {
            case ProjectAdministration.ProjectName:
                return new ProjectAdministration(Default);

            case ProjectAppengine.ProjectName:
                return new ProjectAppengine(Default);

            case ProjectAppstudio.ProjectName:
                return new ProjectAppstudio(Default);

            case ProjectConsolidation.ProjectName:
                return new ProjectConsolidation(Default);

            case ProjectContent.ProjectName:
                return new ProjectContent(Default);

            case ProjectDashboards.ProjectName:
                return new ProjectDashboards(Default);

            case ProjectDeployment.ProjectName:
                return new ProjectDeployment(Default);

            case ProjectDepmservice.ProjectName:
                return new ProjectDepmservice(Default);

            case ProjectDesigner.ProjectName:
                return new ProjectDesigner(Default);

            case ProjectFramework.ProjectName:
                return new ProjectFramework(Default);

            case ProjectModeling.ProjectName:
                return new ProjectModeling(Default);

            case ProjectOfficeinteg.ProjectName:
                return new ProjectOfficeinteg(Default);

            case ProjectOlap.ProjectName:
                return new ProjectOlap(Default);

            case ProjectRepository.ProjectName:
                return new ProjectRepository(Default);

            case ProjectTests.ProjectName:
                return new ProjectTests(Default);
        }

        Debug.Fail("Unsupported project!");
        return null;
    }
}