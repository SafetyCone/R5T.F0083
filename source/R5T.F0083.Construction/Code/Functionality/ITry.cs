using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.Z0021;


namespace R5T.F0083.Construction
{
	[FunctionalityMarker]
	public partial interface ITry : IFunctionalityMarker
	{
		public async Task CreateProgramFile()
		{
			/// Inputs.
			var namespaceName = NamespaceNames.Instance.N0001;

			var codeFilePath = CodeFilePaths.Instance.TempCSharp;


			/// Run.
			await CodeFileGenerationOperations.Instance.CreateProgram(
				codeFilePath,
				namespaceName);

			F0033.NotepadPlusPlusOperator.Instance.Open(
				codeFilePath);
		}
	}
}