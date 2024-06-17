using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using R5T.D0083.R001;
using R5T.F0144;
using R5T.F0144.Extensions;
using R5T.T0132;

using R5T.F0083.R001;


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
                context =>
                {
                    context
                        .Set_Parameter(c => c.Name, formName)
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
                context =>
                {
                    context
                        .Set_Parameter(c => c.Name, formName)
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
                context =>
                {
                    context
                        .Set_Parameter(c => c.TargetProjectName, targetProjectName)
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
                context =>
                {
                    context
                        .Set_Parameter(c => c.ClassTypeName, classTypeName)
                        .Set_Parameter(c => c.InterfaceTypeName, interfaceTypeName)
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
            var markerAttributeName = Instances.TypeNameOperator.Get_AttributeNameFromAttributeTypeName(markerAttributeTypeName);

            await this.CreateNamespaceNamedComponent<InstanceInterface>(
                codeFilePath,
                namspaceName,
                context =>
                {
                    context
                        .Set_Parameter(c => c.InterfaceName, interfaceTypeName)
                        .Set_Parameter(c => c.MarkerAttributeName, markerAttributeName)
                        .Set_Parameter(c => c.MarkerInterfaceTypeName, markerInterfaceTypeName)
                        .Set_Parameter(c => c.UsedNamespaceNames, usedNamespacedNames)
                        ;
                });
        }

        public async Task Create_InstancesFile(
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
            Action<ComponentRenderingContext<TComponent>> setupAction = default)
            where TComponent : R001.Internal.NamespaceNamedBase
        {
            await this.GenerateFromComponent<TComponent>(
                filePath,
                componentRenderingContext =>
                {
                    componentRenderingContext
                        .Set_Parameter(c => c.NamespaceName, namespaceName)
                        ;

                    Instances.ActionOperator.Run_Action(
                        componentRenderingContext,
                        setupAction);
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
                componentRenderer => componentRenderer.Set_Parameter(c => c.ClassName, className));
        }

        public async Task CreateInterfaceCSharpFile(
            string classCSharpFilePath,
            string namespaceName,
            string interfaceName)
        {
            await this.CreateNamespaceNamedComponent<Interface>(
                classCSharpFilePath,
                namespaceName,
                componentRenderer => componentRenderer.Set_Parameter(c => c.InterfaceName, interfaceName));
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
                        .Set_Parameter(c => c.PageTitle, pageTitle)
                        ;
                });
        }

        public async Task CreateIndexHtmlFile_WebBlazorClient(
            string codeFilePath,
            string pageTitle)
        {
            await this.GenerateFromComponent<IndexHtmlFile_WebBlazorClient>(
                codeFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.PageTitle, pageTitle)
                        ;
                });
        }

        public async Task CreateIndexRazorFile_WebBlazorClient(
            string appRazorFilePath,
            string projectNamespaceName)
        {
            await this.GenerateFromComponent<Index_WebBlazorClient>(
                appRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.NamespaceName, projectNamespaceName)
                        ;
                });
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
                componentRenderer => componentRenderer.Set_Parameter(c => c.ComponentName, componentName));
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
                        .Set_Parameter(c => c.NamespaceName, namespaceName)
                        ;
                });
        }

        public async Task CreateMainLayoutRazorFile_WebBlazorClient(
            string layoutRazorFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<MainLayout_WebBlazorClient>(
                layoutRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.NamespaceName, namespaceName)
                        ;
                });
        }

        public async Task Create_ComponentsLayoutsLayoutRazorFile_WebBlazorClient(
            string layoutRazorFilePath)
        {
            await this.GenerateFromComponent<Layout_ComponentsLayouts_WebBlazorClient>(
                layoutRazorFilePath);
        }

        public async Task Create_ComponentsLayoutsLayoutCodeFile_WebBlazorClient(
            string layoutRazorFilePath,
            string namespaceName)
        {
            await this.GenerateFromComponent<LayoutCode_ComponentsLayouts_WebBlazorClient>(
                layoutRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.NamespaceName, namespaceName)
                        ;
                });
        }

        public async Task CreateImportsRazorFile_WebBlazorClient_Components(
            string appRazorFilePath,
            string projectNamespaceName)
        {
            await this.GenerateFromComponent<Imports_WebBlazorClient_Components>(
                appRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.ProjectNamespaceName, projectNamespaceName)
                        ;
                });
        }

        public async Task CreateImportsRazorFile_WebBlazorClient_ComponentsLayouts(
            string appRazorFilePath,
            string projectNamespaceName)
        {
            await this.GenerateFromComponent<Imports_WebBlazorClient_ComponentsLayouts>(
                appRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.ProjectNamespaceName, projectNamespaceName)
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
                        .Set_Parameter(c => c.ProjectNamespaceName, projectNamespaceName)
                        ;
                });
        }

        public async Task CreateImportsRazorFile_WebBlazorClient_Pages(
            string appRazorFilePath,
            string projectNamespaceName)
        {
            await this.GenerateFromComponent<Imports_WebBlazorClient_Pages>(
                appRazorFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.ProjectNamespaceName, projectNamespaceName)
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
                        .Set_Parameter(c => c.NamespaceName, namespaceName)
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
                ? Instances.StringOperator.Lower(projectName)
                : projectName
                ;

            await this.GenerateFromComponent<PackageJsonFile>(
                jsonFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.ProjectName, actualProjectName)
                        .Set_Parameter(c => c.ProjectDescription, projectDescription)
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
                        .Set_Parameter(c => c.ProjectName, projectName)
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
                        .Set_Parameter(c => c.ProjectName, projectName)
                        ;
                });
        }

        public async Task Create_DocumentationFile(
            string codeFilePath,
            string namespaceName,
            string projectDescription)
        {
            await this.GenerateFromComponent<DocumentationFile>(
                codeFilePath,
                componentRenderer =>
                {
                    componentRenderer
                        .Set_Parameter(c => c.NamespaceName, namespaceName)
                        .Set_Parameter(c => c.ProjectDescription, projectDescription)
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
                        .Set_Parameter(c => c.NamespaceName, namespaceName)
                        .Set_Parameter(c => c.TypeName, typeName)
                        .Set_Parameter(c => c.Description, description)
                        .Set_Parameter(c => c.IsDraft, isDraft)
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

        /// <inheritdoc cref="ProgramFile_Console"/>
        public async Task Create_ProgramFile_ForConsole(
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
			Action<ComponentRenderingContext<TComponent>> componentRenderingContextAction = default)
			where TComponent : IComponent
		{
            var code = await Instances.BlazorRenderingOperator.Render(
                componentRenderingContextAction);

            var trimmedCode = Instances.StringOperator.Trim(code) + Instances.Strings.NewLine_ForEnvironment;

            await Instances.FileOperator.Write_Text(
                codeFilePath,
                trimmedCode);
        }
	}
}