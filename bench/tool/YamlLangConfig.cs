using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchTool
{
    public class YamlBenchmarkConfig
    {
        public bool Udocker { get; set; }

        public List<YamlBenchmarkProblemConfig> Problems { get; set; }

        public List<YamlLangConfig> Langs { get; set; }
    }

    public class YamlBenchmarkProblemConfig
    {
        public string Name { get; set; }

        public YamlBenchmarkProblemUnittestConfig[] Unittests { get; set; }

        public YamlBenchmarkProblemTestConfig[] Tests { get; set; }
    }

    public class YamlBenchmarkProblemUnittestConfig
    {
        public string Input { get; set; }

        public string Output { get; set; }
    }

    public class YamlBenchmarkProblemTestConfig
    {
        public string Input { get; set; }

        public int Repeat { get; set; } = 2;

        public bool SkipOnPullRequest { get; set; } = false;

        public HashSet<string> ExcludeLangs { get; set; }
    }

    public abstract class LangConfigBase
    {
        public string CompilerVersionCommand { get; set; }

        public string CompilerVersionRegex { get; set; }

        public string RuntimeVersionParameter { get; set; }

        public string RuntimeVersionRegex { get; set; }

        public string SourceRenameTo { get; set; }
    }

    public class YamlLangConfig : LangConfigBase
    {
        public string Lang { get; set; }

        public YamlLangProblemConfig[] Problems { get; set; }

        public YamlLangEnvironmentConfig[] Environments { get; set; }
    }

    public class YamlLangProblemConfig
    {
        public string Name { get; set; }

        public string[] Source { get; set; }
    }

    public class YamlLangEnvironmentConfig : LangConfigBase
    {
        public string Os { get; set; }

        public string Compiler { get; set; }

        public string Version { get; set; }

        public string CompilerOptions { get; set; }

        public string CompilerOptionsText { get; set; } = "default";

        public string Docker { get; set; }

        public string[] DockerVolumns { get; set; }

        public string Include { get; set; }

        public string IncludeSubDir { get; set; }

        public string[] BeforeBuild { get; set; }

        public string Build { get; set; }

        public string[] AfterBuild { get; set; }

        public string OutDir { get; set; } = "out";

        public string[] BeforeRun { get; set; }

        public string RunCmd { get; set; }

        public bool RuntimeIncluded { get; set; } = true;

        public bool ForceCheckChildProcesses { get; set; } = false;
    }
}
