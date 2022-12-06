using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using R5T.F0079;
using R5T.T0132;

using R5T.F0083.R001;
using R5T.D0083.R001;

namespace R5T.F0083
{
	[FunctionalityMarker]
	public partial interface ICodeFileGenerationOperations : IFunctionalityMarker
	{
        public async Task CreateTailwindCssContentPathsJsonFile(
            string tailwindCssContentPathsJsonFilePath)
        {
            await this.GenerateFromComponent<TailwindCssContentPaths>(
                tailwindCssContentPathsJsonFilePath);
        }

        public async Task CreateIndexRazorFile(
            string razorFilePath,
            string pageTitle)
        {
            await this.GenerateFromComponent<Index_RazorFile>(
                razorFilePath);
        }

        public async Task CreateNamespaceNamedComponent<TComponent>(
            string filePath,
            string namespaceName)
            where TComponent : R001.Internal.NamespaceNamedBase
        {
            await this.GenerateFromComponent<TComponent>(
                filePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.NamespaceName, namespaceName)
                        ;
                });
        }

        public async Task CreateExampleComponentRazorFile(
            string razorFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<ExampleComponent>(
                razorFilePath,
                namespaceName);
        }

        public async Task CreateIndexHtmlFile(
            string codeFilePath,
            string pageTitle)
        {
            await this.GenerateFromComponent<IndexHtmlFile>(
                codeFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.PageTitle, pageTitle)
                        ;
                });
        }

        public async Task CreateIndexRazorFile_WebBlazorClient(
            string appRazorFilePath)
        {
            await this.GenerateFromComponent<Index_WebBlazorClient>(
                appRazorFilePath);
        }

        public async Task CreateStaticRazorComponentsHost(
            string hostRazorFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<StaticRazorComponentsHost>(
                hostRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.NamespaceName, namespaceName)
                        ;
                });
        }

        public async Task CreateMainLayoutRazorFile_WebBlazorClient(
            string appRazorFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<MainLayout_WebBlazorClient>(
                appRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.NamespaceName, namespaceName)
                        ;
                });
        }

        public async Task CreateImportsRazorFile_WebBlazorClient_Main(
            string appRazorFilePath,
            string projectNamespaceName)
        {
            await this.GenerateFromComponent<Imports_WebBlazorClient_Main>(
                appRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.ProjectNamespaceName, projectNamespaceName)
                        ;
                });
        }

        public async Task CreateAppRazorFile_WebBlazorClient(
            string appRazorFilePath)
        {
            await this.GenerateFromComponent<App_WebBlazorClient>(
                appRazorFilePath);
        }

        public async Task CreateAppRazorFile_StaticRazorComponents(
            string appRazorFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<App_StaticRazorComponents>(
                appRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.NamespaceName, namespaceName)
                        ;
                });
        }

        public async Task CreateTailwindCssFile(
            string cssFilePath)
        {
            await this.GenerateFromComponent<TailwindCssFile>(
                cssFilePath);
        }

        public async Task CreateTailwindConfigJsFile(
            string jsFilePath)
        {
            await this.GenerateFromComponent<TailwindConfigJsFile>(
                jsFilePath);
        }

        public async Task CreatePackageJsonFile(
            string jsonFilePath,
            string projectName,
            string projectDescription,
            bool lowerProjectName = true)
        {
            var actualProjectName = lowerProjectName
                ? F0000.StringOperator.Instance.Lower(projectName)
                : projectName
                ;

            await this.GenerateFromComponent<PackageJsonFile>(
                jsonFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.ProjectName, actualProjectName)
                        .SetParameter(c => c.ProjectDescription, projectDescription)
                        ;
                });
        }

        public async Task CreateLaunchSettings_WebServer(
            string jsonFilePath,
            string projectName)
        {
            await this.GenerateFromComponent<LaunchSettings_WebServer>(
                jsonFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.ProjectName, projectName)
                        ;
                });
        }

        public async Task CreateLaunchSettings_WebServerForBlazorClient(
            string jsonFilePath,
            string projectName)
        {
            await this.GenerateFromComponent<LaunchSettings_WebServerForBlazorClient>(
                jsonFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.ProjectName, projectName)
                        ;
                });
        }

        public async Task CreateDocumentationFile(
            string codeFilePath,
            string namespaceName,
            string projectDescription)
        {
            await this.GenerateFromComponent<DocumentationFile>(
                codeFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.NamespaceName, namespaceName)
                        .SetParameter(c => c.ProjectDescription, projectDescription)
                        ;
                });
        }

        public async Task CreateStronglyTypedType<TStronglyTypedComponent>(
            string codeFilePath,
            string namespaceName,
            string typeName,
            string description,
            bool isDraft = false)
            where TStronglyTypedComponent : R001.Internal.StronglyTypedBase
        {
            await this.GenerateFromComponent<TStronglyTypedComponent>(
                codeFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.NamespaceName, namespaceName)
                        .SetParameter(c => c.TypeName, typeName)
                        .SetParameter(c => c.Description, description)
                        .SetParameter(c => c.IsDraft, isDraft)
                        ;
                });
        }

        public async Task CreateStronglyTypedDouble(
			string codeFilePath,
			string namespaceName,
			string typeName,
			string description,
            bool isDraft = false)
		{
            await this.CreateStronglyTypedType<StronglyTypedDouble>(
                codeFilePath,
                namespaceName,
                typeName,
                description,
                isDraft);
        }

        public async Task CreateStronglyTypedGuid(
            string codeFilePath,
            string namespaceName,
            string typeName,
            string description,
            bool isDraft = false)
        {
            await this.CreateStronglyTypedType<StronglyTypedGuid>(
                codeFilePath,
                namespaceName,
                typeName,
                description,
                isDraft);
        }

        public async Task CreateStronglyTypedInteger(
            string codeFilePath,
            string namespaceName,
            string typeName,
            string description,
            bool isDraft = false)
        {
            await this.CreateStronglyTypedType<StronglyTypedGuid>(
                codeFilePath,
                namespaceName,
                typeName,
                description,
                isDraft);
        }

        public async Task CreateStronglyTypedString(
            string codeFilePath,
            string namespaceName,
            string typeName,
            string description,
            bool isDraft = false)
        {
            await this.CreateStronglyTypedType<StronglyTypedGuid>(
                codeFilePath,
                namespaceName,
                typeName,
                description,
                isDraft);
        }

        public async Task CreateProgramFile_WebServerForBlazorClient(
            string programCodeFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<ProgramFile_WebServerForBlazorClient>(
                programCodeFilePath,
                componentRenderer =>
                {
                    componentRenderer.SetParameter(c => c.NamespaceName, namespaceName);
                });
        }

        public async Task CreateProgramFile_WebStaticRazorComponents(
            string programCodeFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<ProgramFile_WebStaticRazorComponents>(
                programCodeFilePath,
                componentRenderer =>
                {
                    componentRenderer.SetParameter(c => c.NamespaceName, namespaceName);
                });
        }

        public async Task CreateProgramFile_WebBlazorClient(
            string programCodeFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<ProgramFile_WebBlazorClient>(
                programCodeFilePath,
                componentRenderer =>
                {
                    componentRenderer.SetParameter(c => c.NamespaceName, namespaceName);
                });
        }

        public async Task CreateProgramFile_Console(
			string programCodeFilePath,
			string namespaceName)
		{
			await this.GenerateFromComponent<ProgramFile_Console>(
				programCodeFilePath,
				componentRenderer =>
				{
					componentRenderer.SetParameter(c => c.NamespaceName, namespaceName);
				});
		}

		public async Task GenerateFromComponent<TComponent>(
			string codeFilePath,
			Action<ComponentRenderer<TComponent>> componentRendererAction = default)
			where TComponent : IComponent
		{
            var code = await ComponentOperator.Instance.NewRenderer<TComponent>()
				.ModifyWith(componentRendererAction)
                .Render();

            var trimmedCode = F0000.StringOperator.Instance.Trim(code) + Z0000.Strings.Instance.NewLineForEnvironment;

            F0000.FileOperator.Instance.WriteText(
                codeFilePath,
                trimmedCode);
        }
	}
}