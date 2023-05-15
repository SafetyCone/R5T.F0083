using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using R5T.F0000;
using R5T.F0079;
using R5T.T0132;

using R5T.F0083.R001;
using R5T.D0083.R001;


namespace R5T.F0083
{
	[FunctionalityMarker]
	public partial interface ICodeFileGenerationOperations : IFunctionalityMarker
	{
        /// <summary>
        /// Creates the initial Windows Form designer code file, containing the partial class definition used by the Windows Form designer functionality.
        /// </summary>
        public async Task CreateFormDesignerCodeFile(
            string codeFilePath,
            string namespaceName,
            string formName)
        {
            await this.CreateNamespaceNamedComponent<FormDesigner>(
                codeFilePath,
                namespaceName,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.Name, formName)
                        ;
                });
        }

        public async Task CreateFormClassCodeFile(
            string codeFilePath,
            string namespaceName,
            string formName)
        {
            await this.CreateNamespaceNamedComponent<FormClass>(
                codeFilePath,
                namespaceName,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.Name, formName)
                        ;
                });
        }

        public async Task CreateInstance_DeployScripts(
           string codeFilePath,
           string namespaceName,
           string targetProjectName)
        {
            await this.CreateNamespaceNamedComponent<Instance_DeployScripts>(
                codeFilePath,
                namespaceName,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.TargetProjectName, targetProjectName)
                        ;
                });
        }

        public async Task CreateInstanceClassCodeFile(
            string codeFilePath,
            string namespaceName,
            string classTypeName,
            string interfaceTypeName)
        {
            await this.CreateNamespaceNamedComponent<InstanceClass>(
                codeFilePath,
                namespaceName,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.ClassTypeName, classTypeName)
                        .SetParameter(c => c.InterfaceTypeName, interfaceTypeName)
                        ;
                });
        }

        public async Task CreateInstanceInterfaceCodeFile(
            string codeFilePath,
            string namspaceName,
            string interfaceTypeName,
            string markerAttributeTypeName,
            string markerInterfaceTypeName,
            string[] usedNamespacedNames)
        {
            var markerAttributeName = TypeNameOperator.Instance.GetAttributeNameFromAttributeTypeName(markerAttributeTypeName);

            await this.CreateNamespaceNamedComponent<InstanceInterface>(
                codeFilePath,
                namspaceName,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.InterfaceName, interfaceTypeName)
                        .SetParameter(c => c.MarkerAttributeName, markerAttributeName)
                        .SetParameter(c => c.MarkerInterfaceTypeName, markerInterfaceTypeName)
                        .SetParameter(c => c.UsedNamespaceNames, usedNamespacedNames)
                        ;
                });
        }

        public async Task CreateInstancesClass(
            string instancesCSharpCodeFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<InstancesClass>(
                instancesCSharpCodeFilePath,
                namespaceName);
        }

        public async Task CreateInstancesClass_Deploy(
            string instancesCSharpCodeFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<InstancesClass_Deploy>(
                instancesCSharpCodeFilePath,
                namespaceName);
        }

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
            string namespaceName,
            Action<ComponentRenderer<TComponent>> setupAction = default)
            where TComponent : R001.Internal.NamespaceNamedBase
        {
            await this.GenerateFromComponent<TComponent>(
                filePath,
                componentRenderer =>
                {
                    componentRenderer
                        .SetParameter(c => c.NamespaceName, namespaceName)
                        ;

                    F0000.ActionOperator.Instance.Run(
                        setupAction,
                        componentRenderer);
                });
        }

        public async Task CreateClassCSharpFile(
            string classCSharpFilePath,
            string namespaceName,
            string className)
        {
            await this.CreateNamespaceNamedComponent<Class>(
                classCSharpFilePath,
                namespaceName,
                componentRenderer => componentRenderer.SetParameter(c => c.ClassName, className));
        }

        public async Task CreateInterfaceCSharpFile(
            string classCSharpFilePath,
            string namespaceName,
            string interfaceName)
        {
            await this.CreateNamespaceNamedComponent<Interface>(
                classCSharpFilePath,
                namespaceName,
                componentRenderer => componentRenderer.SetParameter(c => c.InterfaceName, interfaceName));
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

        public async Task CreateRazorComponentMarkupFile(
            string markupFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<RazorComponentMarkup>(
                markupFilePath,
                namespaceName);
        }

        public async Task CreateRazorComponentCodeBehindFile(
            string markupFilePath,
            string namespaceName,
            string componentName)
        {
            await this.CreateNamespaceNamedComponent<RazorComponentCodeBehind>(
                markupFilePath,
                namespaceName,
                componentRenderer => componentRenderer.SetParameter(c => c.ComponentName, componentName));
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

        public async Task CreateTailwindConfigJsWithTypographyFile(
            string jsFilePath)
        {
            await this.GenerateFromComponent<TailwindConfigJsFile_Typography>(
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
            await this.CreateStronglyTypedType<StronglyTypedInteger>(
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
            await this.CreateStronglyTypedType<StronglyTypedString>(
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
            await this.CreateNamespaceNamedComponent<ProgramFile_WebServerForBlazorClient>(
                programCodeFilePath,
                namespaceName);
        }

        public async Task CreateProgramFile_WebStaticRazorComponents(
            string programCodeFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<ProgramFile_WebStaticRazorComponents>(
                programCodeFilePath,
                namespaceName);
        }

        public async Task CreateProgramFile_WindowsForms(
            string programCodeFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<ProgramFile_WindowsForms>(
                programCodeFilePath,
                namespaceName);
        }

        public async Task CreateProgramFile_WebBlazorClient(
            string programCodeFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<ProgramFile_WebBlazorClient>(
                programCodeFilePath,
                namespaceName);
        }

        public async Task CreateProgramFile_Console(
			string programCodeFilePath,
			string namespaceName)
		{
			await this.CreateNamespaceNamedComponent<ProgramFile_Console>(
				programCodeFilePath,
				namespaceName);
		}

        public async Task CreateProgramFile_DeployScripts(
            string programCodeFilePath,
            string namespaceName)
        {
            await this.CreateNamespaceNamedComponent<ProgramFile_DeployScripts>(
                programCodeFilePath,
                namespaceName);
        }

        public async Task GenerateFromComponent<TComponent>(
			string codeFilePath,
			Action<ComponentRenderer<TComponent>> componentRendererAction = default)
			where TComponent : IComponent
		{
            var code = await ComponentOperator.Instance.NewRenderer<TComponent>()
				.ModifyWith(componentRendererAction)
                .Render();

            var trimmedCode = StringOperator.Instance.Trim(code) + Z0000.Strings.Instance.NewLine_ForEnvironment;

            FileOperator.Instance.WriteText_Synchronous(
                codeFilePath,
                trimmedCode);
        }
	}
}