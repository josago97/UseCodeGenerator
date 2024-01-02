// Generated from d:/JOSE/Documents/Proyectos C#/OclCodeGenerator/UseCodeGenerator/Assets/Use.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link UseParser}.
 */
public interface UseListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link UseParser#startRule}.
	 * @param ctx the parse tree
	 */
	void enterStartRule(UseParser.StartRuleContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#startRule}.
	 * @param ctx the parse tree
	 */
	void exitStartRule(UseParser.StartRuleContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#model}.
	 * @param ctx the parse tree
	 */
	void enterModel(UseParser.ModelContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#model}.
	 * @param ctx the parse tree
	 */
	void exitModel(UseParser.ModelContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#modelName}.
	 * @param ctx the parse tree
	 */
	void enterModelName(UseParser.ModelNameContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#modelName}.
	 * @param ctx the parse tree
	 */
	void exitModelName(UseParser.ModelNameContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#class}.
	 * @param ctx the parse tree
	 */
	void enterClass(UseParser.ClassContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#class}.
	 * @param ctx the parse tree
	 */
	void exitClass(UseParser.ClassContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(UseParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(UseParser.AttributeContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#operation}.
	 * @param ctx the parse tree
	 */
	void enterOperation(UseParser.OperationContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#operation}.
	 * @param ctx the parse tree
	 */
	void exitOperation(UseParser.OperationContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#parameter}.
	 * @param ctx the parse tree
	 */
	void enterParameter(UseParser.ParameterContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#parameter}.
	 * @param ctx the parse tree
	 */
	void exitParameter(UseParser.ParameterContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#enumeration}.
	 * @param ctx the parse tree
	 */
	void enterEnumeration(UseParser.EnumerationContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#enumeration}.
	 * @param ctx the parse tree
	 */
	void exitEnumeration(UseParser.EnumerationContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#enumerationName}.
	 * @param ctx the parse tree
	 */
	void enterEnumerationName(UseParser.EnumerationNameContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#enumerationName}.
	 * @param ctx the parse tree
	 */
	void exitEnumerationName(UseParser.EnumerationNameContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#enumerationLiteral}.
	 * @param ctx the parse tree
	 */
	void enterEnumerationLiteral(UseParser.EnumerationLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#enumerationLiteral}.
	 * @param ctx the parse tree
	 */
	void exitEnumerationLiteral(UseParser.EnumerationLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#type}.
	 * @param ctx the parse tree
	 */
	void enterType(UseParser.TypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#type}.
	 * @param ctx the parse tree
	 */
	void exitType(UseParser.TypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#simpleType}.
	 * @param ctx the parse tree
	 */
	void enterSimpleType(UseParser.SimpleTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#simpleType}.
	 * @param ctx the parse tree
	 */
	void exitSimpleType(UseParser.SimpleTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link UseParser#simpleTypeLiteral}.
	 * @param ctx the parse tree
	 */
	void enterSimpleTypeLiteral(UseParser.SimpleTypeLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link UseParser#simpleTypeLiteral}.
	 * @param ctx the parse tree
	 */
	void exitSimpleTypeLiteral(UseParser.SimpleTypeLiteralContext ctx);
}