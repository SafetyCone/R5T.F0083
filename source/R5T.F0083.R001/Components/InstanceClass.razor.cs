using System;


namespace R5T.F0083.R001
{
    /// <remarks>
    /// <list type="bullet">
    /// <item>
    /// Use "= new ClassTypeName()" instead of the "target-typed object creation" feature.
    ///     That feature is only available as-of C# language version 9.0, and to have a broader reach, .NET Standard 2.1 is used for libraries.
    ///     Because .NET Standard 2.1 is only C# language version 8.0, to allow .NET Standard 2.1, we have to limit ourselves and refrain from using the "target-typed object creation" feature.
    /// </item>
    /// <item>
    /// Make the Instance static property type the interface type.
    ///     The "default interface methods" used for functionality have a C# language rule that they are not available from instances of the implementation class type, only instances of the interface type.
    ///     By typing the static instance as the interface, all the functionality methods are available from the instance (Namespace.ClassTypeName.Functionality() is possible).
    /// </item>
    /// </list>
    /// </remarks>
    public partial class InstanceClass
    {
    }
}
