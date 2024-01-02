namespace UseCodeGenerator.Core.Use.Entities;

internal class UOperation : UElement
{
    public UType ReturnType { get; set; }

    public UOperation() { }

    public UOperation(string name, UType returnType) : base(name)
    {
        ReturnType = returnType;
    }

    /** A list of parameters /
    private VarDeclList fVarDeclList;

    /** The declared result type (optional) /
    private Type fResultType;

    /** The operation's body (optional) /
    private Expression fExpr;

    /** The statement, might be <code>null</code>./
    private MStatement fStatement;*/
}
