using System;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0241;


namespace R5T.F0083.O001
{
    [ContextOperationsMarker]
    public partial interface ICodeFileGenerationContextOperations : IContextOperationsMarker 
    {
        public Func<TContext, Task> Create_DocumentationFile<TContext>(
            string projectDescription,
            out IChecked<IFileExists> documentationFileExists)
            where TContext : IHasFilePath, IHasNamespaceName
        {
            documentationFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.CodeFileGenerationOperations.Create_DocumentationFile(
                    context.FilePath,
                    context.NamespaceName,
                    projectDescription);
            };
        }

        public Func<TContext, Task> Create_InstancesFile<TContext>(
            out IChecked<IFileExists> instancesFileExists)
            where TContext : IHasFilePath, IHasNamespaceName
        {
            instancesFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.CodeFileGenerationOperations.Create_InstancesFile(
                    context.FilePath,
                    context.NamespaceName);
            };
        }

        public Func<TContext, Task> Create_ProgramFile_ForConsole<TContext>(
            out IChecked<IFileExists> programFileExists)
            where TContext : IHasFilePath, IHasNamespaceName
        {
            programFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.CodeFileGenerationOperations.Create_ProgramFile_ForConsole(
                    context.FilePath,
                    context.NamespaceName);
            };
        }
    }
}
