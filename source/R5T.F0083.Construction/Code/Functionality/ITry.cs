using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0083.Construction
{
	[FunctionalityMarker]
	public partial interface ITry : IFunctionalityMarker
	{
		public async Task CreateProgramFile()
		{
			/// Inputs.
			var namespaceName = Instances.NamespaceNames.N0001;

			var codeFilePath = Instances.CodeFilePaths.TempCSharp;


			/// Run.
			await Instances.CodeFileGenerationOperations.Create_ProgramFile_ForConsole(
				codeFilePath,
				namespaceName);

            Instances.NotepadPlusPlusOperator.Open(
				codeFilePath);
		}
	}
}