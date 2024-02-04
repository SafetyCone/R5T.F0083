using System;


namespace R5T.F0083.Construction
{
    public static class Instances
    {
        public static ICodeFileGenerationOperations CodeFileGenerationOperations => F0083.CodeFileGenerationOperations.Instance;
        public static Z0021.ICodeFilePaths CodeFilePaths => Z0021.CodeFilePaths.Instance;
        public static Z0021.INamespaceNames NamespaceNames => Z0021.NamespaceNames.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
    }
}