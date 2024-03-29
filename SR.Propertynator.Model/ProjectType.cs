﻿using SR.Propertynator.Model.Helpers;

namespace SR.Propertynator.Model
{
    public enum ProjectType
    {
        Unknown,

        Default,

        Framework,
        Repository,
        Olap,
        Modeling,
        Designer,
        Depmservice,
        Consolidation,
        Appengine,
        Dashboards,
        Appstudio,
        Officeinteg,
        Administration,
        Content,
        Deployment,
        Tests
    }

    public sealed class ProjectTypeEnumHelperLower : EnumHelperLower<ProjectType>
    {
    }
}