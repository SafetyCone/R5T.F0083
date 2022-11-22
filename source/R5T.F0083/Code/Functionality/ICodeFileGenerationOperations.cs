using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using R5T.F0079;
using R5T.T0132;

using R5T.F0083.R001;


namespace R5T.F0083
{
	[FunctionalityMarker]
	public partial interface ICodeFileGenerationOperations : IFunctionalityMarker
	{
        public async Task CreateLaunchSettings_WebServerForBlazorClient(
            string codeFilePath,
            string projectName)
        {
            await this.GenerateFromComponent<LaunchSettings_WebServerForBlazorClient>(
                codeFilePath,
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
            where TStronglyTypedComponent : StronglyTypedBase
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