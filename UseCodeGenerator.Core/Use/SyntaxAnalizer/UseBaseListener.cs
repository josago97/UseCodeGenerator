//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Assets/Use.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace UseCodeGenerator.Core.Use.SyntaxAnalizer {

using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IUseListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class UseBaseListener : IUseListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.startRule"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStartRule([NotNull] UseParser.StartRuleContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.startRule"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStartRule([NotNull] UseParser.StartRuleContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.model"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterModel([NotNull] UseParser.ModelContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.model"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitModel([NotNull] UseParser.ModelContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.modelName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterModelName([NotNull] UseParser.ModelNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.modelName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitModelName([NotNull] UseParser.ModelNameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.class"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClass([NotNull] UseParser.ClassContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.class"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClass([NotNull] UseParser.ClassContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.className"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassName([NotNull] UseParser.ClassNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.className"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassName([NotNull] UseParser.ClassNameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.inheritance"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInheritance([NotNull] UseParser.InheritanceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.inheritance"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInheritance([NotNull] UseParser.InheritanceContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.attribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAttribute([NotNull] UseParser.AttributeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.attribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAttribute([NotNull] UseParser.AttributeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.operation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperation([NotNull] UseParser.OperationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.operation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperation([NotNull] UseParser.OperationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParameter([NotNull] UseParser.ParameterContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParameter([NotNull] UseParser.ParameterContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.operationBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperationBody([NotNull] UseParser.OperationBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.operationBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperationBody([NotNull] UseParser.OperationBodyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatements([NotNull] UseParser.StatementsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatements([NotNull] UseParser.StatementsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] UseParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] UseParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.conditional"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConditional([NotNull] UseParser.ConditionalContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.conditional"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConditional([NotNull] UseParser.ConditionalContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.pre"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPre([NotNull] UseParser.PreContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.pre"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPre([NotNull] UseParser.PreContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.post"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPost([NotNull] UseParser.PostContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.post"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPost([NotNull] UseParser.PostContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.enumeration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumeration([NotNull] UseParser.EnumerationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.enumeration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumeration([NotNull] UseParser.EnumerationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.enumerationName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumerationName([NotNull] UseParser.EnumerationNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.enumerationName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumerationName([NotNull] UseParser.EnumerationNameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.enumerationLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumerationLiteral([NotNull] UseParser.EnumerationLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.enumerationLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumerationLiteral([NotNull] UseParser.EnumerationLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] UseParser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] UseParser.TypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.typeLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypeLiteral([NotNull] UseParser.TypeLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.typeLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypeLiteral([NotNull] UseParser.TypeLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.simpleType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSimpleType([NotNull] UseParser.SimpleTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.simpleType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSimpleType([NotNull] UseParser.SimpleTypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.simpleTypeLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSimpleTypeLiteral([NotNull] UseParser.SimpleTypeLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.simpleTypeLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSimpleTypeLiteral([NotNull] UseParser.SimpleTypeLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.booleanLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanLiteral([NotNull] UseParser.BooleanLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.booleanLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanLiteral([NotNull] UseParser.BooleanLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.integerLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntegerLiteral([NotNull] UseParser.IntegerLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.integerLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntegerLiteral([NotNull] UseParser.IntegerLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.realLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRealLiteral([NotNull] UseParser.RealLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.realLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRealLiteral([NotNull] UseParser.RealLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.stringLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStringLiteral([NotNull] UseParser.StringLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.stringLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStringLiteral([NotNull] UseParser.StringLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.association"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssociation([NotNull] UseParser.AssociationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.association"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssociation([NotNull] UseParser.AssociationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.associationName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssociationName([NotNull] UseParser.AssociationNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.associationName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssociationName([NotNull] UseParser.AssociationNameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.associationItem"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssociationItem([NotNull] UseParser.AssociationItemContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.associationItem"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssociationItem([NotNull] UseParser.AssociationItemContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.roleName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRoleName([NotNull] UseParser.RoleNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.roleName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRoleName([NotNull] UseParser.RoleNameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.multiplicity"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplicity([NotNull] UseParser.MultiplicityContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.multiplicity"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplicity([NotNull] UseParser.MultiplicityContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.multiplicityValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplicityValue([NotNull] UseParser.MultiplicityValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.multiplicityValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplicityValue([NotNull] UseParser.MultiplicityValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="UseParser.constraints"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstraints([NotNull] UseParser.ConstraintsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="UseParser.constraints"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstraints([NotNull] UseParser.ConstraintsContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace UseCodeGenerator.Core.Use.SyntaxAnalizer
