using System;


namespace R5T.F0083.O001
{
    public class CodeFileGenerationContextOperations : ICodeFileGenerationContextOperations
    {
        #region Infrastructure

        public static ICodeFileGenerationContextOperations Instance { get; } = new CodeFileGenerationContextOperations();


        private CodeFileGenerationContextOperations()
        {
        }

        #endregion
    }
}
