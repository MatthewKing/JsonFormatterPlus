var target = Argument("target", "Finalize");
var configuration = Argument("configuration", "Release");
var workingDir = Directory("./temp").Path.MakeAbsolute(Context.Environment);
var outputDir = Directory("./output").Path.MakeAbsolute(Context.Environment);

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(workingDir);
        CleanDirectory(outputDir);
    });
    
Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        var solutionFile = GetFiles("../*.sln").Single();
        MSBuild(solutionFile, settings => 
        {
            settings.SetConfiguration(configuration);
            settings.WithProperty("OutputPath", workingDir.FullPath);
        });
    });

Task("NuGetPack")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var assemblyInfoFile = File("../src/JsonFormatterPlus/Properties/AssemblyInfo.cs");
        var assemblyInfo = ParseAssemblyInfo(assemblyInfoFile);

        var nuspec = File("./JsonFormatterPlus.nuspec");

        var settings = new NuGetPackSettings();
        settings.OutputDirectory = outputDir.FullPath;
        settings.Version = assemblyInfo.AssemblyInformationalVersion;
        settings.Files = new[]
        {
            new NuSpecContent() { Source = workingDir.CombineWithFilePath("JsonFormatterPlus.dll").FullPath, Target = "lib/net20" },
            new NuSpecContent() { Source = workingDir.CombineWithFilePath("JsonFormatterPlus.xml").FullPath, Target = "lib/net20" },
        };

        NuGetPack(nuspec, settings);
    });

Task("Finalize")
    .IsDependentOn("NuGetPack")
    .Does(() =>
    {
        CleanDirectory(workingDir);
    });

RunTarget(target);