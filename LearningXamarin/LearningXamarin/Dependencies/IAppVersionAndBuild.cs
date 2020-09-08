namespace VersionAndBuildNumber.DependencyServices
{
    public interface IAppVersionAndBuild
    {
        string GetVersionNumber();
        string GetBuildNumber();
    }
}