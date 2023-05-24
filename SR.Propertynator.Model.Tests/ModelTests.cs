using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SR.Propertynator.Model.BuildModes;

namespace SR.Propertynator.Model.Tests;

[TestClass]
public class ModelTests
{
    [TestMethod]
    public void CreateModelBinary()
    {
        BuildMode model = BuildMode.Binary;

        model.Should().BeSameAs(BuildMode.Binary);
    }

    [TestMethod]
    public void CreateModelSource()
    {
        BuildMode model = BuildMode.Source;

        model.Should().BeSameAs(BuildMode.Source);
    }

    [TestMethod]
    public void CreateModelIgnore()
    {
        BuildMode model = BuildMode.Ignore;

        model.Should().BeSameAs(BuildMode.Ignore);
    }

    [TestMethod]
    public void WriteModelBinary()
    {
        BuildMode model                = BuildMode.Binary;
        string    propertyFileTestLine = WriteToString(model, "Test");
        propertyFileTestLine.Trim().Should().Be("Test.mode=binary");
    }

    [TestMethod]
    public void WriteModelSource()
    {
        BuildMode model                = BuildMode.Source;
        string    propertyFileTestLine = WriteToString(model, "Test");
        propertyFileTestLine.Trim().Should().Be("Test.mode=source");
    }

    [TestMethod]
    public void WriteModelIgnore()
    {
        BuildMode model                = BuildMode.Ignore;
        string    propertyFileTestLine = WriteToString(model, "Test");
        propertyFileTestLine.Trim().Should().Be("Test.mode=ignore");
    }

    private string WriteToString(BuildMode buildMode, string projectName)
    {
        using StringWriter target = new StringWriter();

        buildMode.Write(target, projectName);

        return target.ToString();
    }
}