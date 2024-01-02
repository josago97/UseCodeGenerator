// Generated from d:/JOSE/Documents/Proyectos C#/OclCodeGenerator/UseCodeGenerator/Assets/Use.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class UseParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, ABSTRACT=14, END=15, BOOLEAN=16, 
		INTEGER=17, REAL=18, STRING=19, BOOLEAN_LITERAL=20, INTEGER_LITERAL=21, 
		REAL_LITERAL=22, STRING_LITERAL=23, WS=24, IDENTIFIER=25;
	public static final int
		RULE_startRule = 0, RULE_model = 1, RULE_modelName = 2, RULE_class = 3, 
		RULE_attribute = 4, RULE_operation = 5, RULE_parameter = 6, RULE_enumeration = 7, 
		RULE_enumerationName = 8, RULE_enumerationLiteral = 9, RULE_type = 10, 
		RULE_simpleType = 11, RULE_simpleTypeLiteral = 12;
	private static String[] makeRuleNames() {
		return new String[] {
			"startRule", "model", "modelName", "class", "attribute", "operation", 
			"parameter", "enumeration", "enumerationName", "enumerationLiteral", 
			"type", "simpleType", "simpleTypeLiteral"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'model'", "'class'", "'attributes'", "'operations'", "':'", "'init'", 
			"'='", "'('", "')'", "'enum'", "'{'", "','", "'}'", "'abstract'", "'end'", 
			"'Boolean'", "'Integer'", "'Real'", "'String'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, "ABSTRACT", "END", "BOOLEAN", "INTEGER", "REAL", "STRING", 
			"BOOLEAN_LITERAL", "INTEGER_LITERAL", "REAL_LITERAL", "STRING_LITERAL", 
			"WS", "IDENTIFIER"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Use.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public UseParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StartRuleContext extends ParserRuleContext {
		public ModelContext model() {
			return getRuleContext(ModelContext.class,0);
		}
		public TerminalNode EOF() { return getToken(UseParser.EOF, 0); }
		public List<ClassContext> class_() {
			return getRuleContexts(ClassContext.class);
		}
		public ClassContext class_(int i) {
			return getRuleContext(ClassContext.class,i);
		}
		public List<EnumerationContext> enumeration() {
			return getRuleContexts(EnumerationContext.class);
		}
		public EnumerationContext enumeration(int i) {
			return getRuleContext(EnumerationContext.class,i);
		}
		public StartRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_startRule; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterStartRule(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitStartRule(this);
		}
	}

	public final StartRuleContext startRule() throws RecognitionException {
		StartRuleContext _localctx = new StartRuleContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_startRule);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(26);
			model();
			setState(31);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 17412L) != 0)) {
				{
				setState(29);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__1:
				case ABSTRACT:
					{
					setState(27);
					class_();
					}
					break;
				case T__9:
					{
					setState(28);
					enumeration();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(33);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(34);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ModelContext extends ParserRuleContext {
		public ModelNameContext modelName() {
			return getRuleContext(ModelNameContext.class,0);
		}
		public ModelContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_model; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterModel(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitModel(this);
		}
	}

	public final ModelContext model() throws RecognitionException {
		ModelContext _localctx = new ModelContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_model);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(36);
			match(T__0);
			setState(37);
			modelName();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ModelNameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public ModelNameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_modelName; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterModelName(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitModelName(this);
		}
	}

	public final ModelNameContext modelName() throws RecognitionException {
		ModelNameContext _localctx = new ModelNameContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_modelName);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(39);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ClassContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public TerminalNode END() { return getToken(UseParser.END, 0); }
		public TerminalNode ABSTRACT() { return getToken(UseParser.ABSTRACT, 0); }
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public List<OperationContext> operation() {
			return getRuleContexts(OperationContext.class);
		}
		public OperationContext operation(int i) {
			return getRuleContext(OperationContext.class,i);
		}
		public ClassContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_class; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterClass(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitClass(this);
		}
	}

	public final ClassContext class_() throws RecognitionException {
		ClassContext _localctx = new ClassContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_class);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(42);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ABSTRACT) {
				{
				setState(41);
				match(ABSTRACT);
				}
			}

			setState(44);
			match(T__1);
			setState(45);
			match(IDENTIFIER);
			setState(53);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__2) {
				{
				setState(46);
				match(T__2);
				setState(50);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==IDENTIFIER) {
					{
					{
					setState(47);
					attribute();
					}
					}
					setState(52);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(62);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(55);
				match(T__3);
				setState(59);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==IDENTIFIER) {
					{
					{
					setState(56);
					operation();
					}
					}
					setState(61);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(64);
			match(END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AttributeContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public SimpleTypeLiteralContext simpleTypeLiteral() {
			return getRuleContext(SimpleTypeLiteralContext.class,0);
		}
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitAttribute(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_attribute);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(66);
			match(IDENTIFIER);
			setState(67);
			match(T__4);
			setState(68);
			type();
			setState(72);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__5) {
				{
				setState(69);
				match(T__5);
				setState(70);
				match(T__6);
				setState(71);
				simpleTypeLiteral();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class OperationContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public List<ParameterContext> parameter() {
			return getRuleContexts(ParameterContext.class);
		}
		public ParameterContext parameter(int i) {
			return getRuleContext(ParameterContext.class,i);
		}
		public OperationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operation; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterOperation(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitOperation(this);
		}
	}

	public final OperationContext operation() throws RecognitionException {
		OperationContext _localctx = new OperationContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_operation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(74);
			match(IDENTIFIER);
			setState(75);
			match(T__7);
			setState(79);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==IDENTIFIER) {
				{
				{
				setState(76);
				parameter();
				}
				}
				setState(81);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(82);
			match(T__8);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ParameterContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public ParameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameter; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterParameter(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitParameter(this);
		}
	}

	public final ParameterContext parameter() throws RecognitionException {
		ParameterContext _localctx = new ParameterContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_parameter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(84);
			match(IDENTIFIER);
			setState(85);
			match(T__4);
			setState(86);
			type();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class EnumerationContext extends ParserRuleContext {
		public EnumerationNameContext enumerationName() {
			return getRuleContext(EnumerationNameContext.class,0);
		}
		public List<EnumerationLiteralContext> enumerationLiteral() {
			return getRuleContexts(EnumerationLiteralContext.class);
		}
		public EnumerationLiteralContext enumerationLiteral(int i) {
			return getRuleContext(EnumerationLiteralContext.class,i);
		}
		public EnumerationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_enumeration; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterEnumeration(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitEnumeration(this);
		}
	}

	public final EnumerationContext enumeration() throws RecognitionException {
		EnumerationContext _localctx = new EnumerationContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_enumeration);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(88);
			match(T__9);
			setState(89);
			enumerationName();
			setState(90);
			match(T__10);
			setState(91);
			enumerationLiteral();
			setState(96);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__11) {
				{
				{
				setState(92);
				match(T__11);
				setState(93);
				enumerationLiteral();
				}
				}
				setState(98);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(99);
			match(T__12);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class EnumerationNameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public EnumerationNameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_enumerationName; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterEnumerationName(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitEnumerationName(this);
		}
	}

	public final EnumerationNameContext enumerationName() throws RecognitionException {
		EnumerationNameContext _localctx = new EnumerationNameContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_enumerationName);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(101);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class EnumerationLiteralContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public EnumerationLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_enumerationLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterEnumerationLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitEnumerationLiteral(this);
		}
	}

	public final EnumerationLiteralContext enumerationLiteral() throws RecognitionException {
		EnumerationLiteralContext _localctx = new EnumerationLiteralContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_enumerationLiteral);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(103);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypeContext extends ParserRuleContext {
		public SimpleTypeContext simpleType() {
			return getRuleContext(SimpleTypeContext.class,0);
		}
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitType(this);
		}
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_type);
		try {
			setState(107);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BOOLEAN:
			case INTEGER:
			case REAL:
			case STRING:
				enterOuterAlt(_localctx, 1);
				{
				setState(105);
				simpleType();
				}
				break;
			case IDENTIFIER:
				enterOuterAlt(_localctx, 2);
				{
				setState(106);
				match(IDENTIFIER);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SimpleTypeContext extends ParserRuleContext {
		public TerminalNode BOOLEAN() { return getToken(UseParser.BOOLEAN, 0); }
		public TerminalNode INTEGER() { return getToken(UseParser.INTEGER, 0); }
		public TerminalNode REAL() { return getToken(UseParser.REAL, 0); }
		public TerminalNode STRING() { return getToken(UseParser.STRING, 0); }
		public SimpleTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterSimpleType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitSimpleType(this);
		}
	}

	public final SimpleTypeContext simpleType() throws RecognitionException {
		SimpleTypeContext _localctx = new SimpleTypeContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_simpleType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 983040L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SimpleTypeLiteralContext extends ParserRuleContext {
		public TerminalNode BOOLEAN_LITERAL() { return getToken(UseParser.BOOLEAN_LITERAL, 0); }
		public TerminalNode INTEGER_LITERAL() { return getToken(UseParser.INTEGER_LITERAL, 0); }
		public TerminalNode REAL_LITERAL() { return getToken(UseParser.REAL_LITERAL, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(UseParser.STRING_LITERAL, 0); }
		public SimpleTypeLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleTypeLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).enterSimpleTypeLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof UseListener ) ((UseListener)listener).exitSimpleTypeLiteral(this);
		}
	}

	public final SimpleTypeLiteralContext simpleTypeLiteral() throws RecognitionException {
		SimpleTypeLiteralContext _localctx = new SimpleTypeLiteralContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_simpleTypeLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(111);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 15728640L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\u0004\u0001\u0019r\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0001\u0000\u0001\u0000\u0001\u0000\u0005\u0000\u001e\b\u0000"+
		"\n\u0000\f\u0000!\t\u0000\u0001\u0000\u0001\u0000\u0001\u0001\u0001\u0001"+
		"\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0003\u0003\u0003+\b\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0005\u00031\b\u0003"+
		"\n\u0003\f\u00034\t\u0003\u0003\u00036\b\u0003\u0001\u0003\u0001\u0003"+
		"\u0005\u0003:\b\u0003\n\u0003\f\u0003=\t\u0003\u0003\u0003?\b\u0003\u0001"+
		"\u0003\u0001\u0003\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004\u0001"+
		"\u0004\u0001\u0004\u0003\u0004I\b\u0004\u0001\u0005\u0001\u0005\u0001"+
		"\u0005\u0005\u0005N\b\u0005\n\u0005\f\u0005Q\t\u0005\u0001\u0005\u0001"+
		"\u0005\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0007\u0001"+
		"\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0005\u0007_\b"+
		"\u0007\n\u0007\f\u0007b\t\u0007\u0001\u0007\u0001\u0007\u0001\b\u0001"+
		"\b\u0001\t\u0001\t\u0001\n\u0001\n\u0003\nl\b\n\u0001\u000b\u0001\u000b"+
		"\u0001\f\u0001\f\u0001\f\u0000\u0000\r\u0000\u0002\u0004\u0006\b\n\f\u000e"+
		"\u0010\u0012\u0014\u0016\u0018\u0000\u0002\u0001\u0000\u0010\u0013\u0001"+
		"\u0000\u0014\u0017o\u0000\u001a\u0001\u0000\u0000\u0000\u0002$\u0001\u0000"+
		"\u0000\u0000\u0004\'\u0001\u0000\u0000\u0000\u0006*\u0001\u0000\u0000"+
		"\u0000\bB\u0001\u0000\u0000\u0000\nJ\u0001\u0000\u0000\u0000\fT\u0001"+
		"\u0000\u0000\u0000\u000eX\u0001\u0000\u0000\u0000\u0010e\u0001\u0000\u0000"+
		"\u0000\u0012g\u0001\u0000\u0000\u0000\u0014k\u0001\u0000\u0000\u0000\u0016"+
		"m\u0001\u0000\u0000\u0000\u0018o\u0001\u0000\u0000\u0000\u001a\u001f\u0003"+
		"\u0002\u0001\u0000\u001b\u001e\u0003\u0006\u0003\u0000\u001c\u001e\u0003"+
		"\u000e\u0007\u0000\u001d\u001b\u0001\u0000\u0000\u0000\u001d\u001c\u0001"+
		"\u0000\u0000\u0000\u001e!\u0001\u0000\u0000\u0000\u001f\u001d\u0001\u0000"+
		"\u0000\u0000\u001f \u0001\u0000\u0000\u0000 \"\u0001\u0000\u0000\u0000"+
		"!\u001f\u0001\u0000\u0000\u0000\"#\u0005\u0000\u0000\u0001#\u0001\u0001"+
		"\u0000\u0000\u0000$%\u0005\u0001\u0000\u0000%&\u0003\u0004\u0002\u0000"+
		"&\u0003\u0001\u0000\u0000\u0000\'(\u0005\u0019\u0000\u0000(\u0005\u0001"+
		"\u0000\u0000\u0000)+\u0005\u000e\u0000\u0000*)\u0001\u0000\u0000\u0000"+
		"*+\u0001\u0000\u0000\u0000+,\u0001\u0000\u0000\u0000,-\u0005\u0002\u0000"+
		"\u0000-5\u0005\u0019\u0000\u0000.2\u0005\u0003\u0000\u0000/1\u0003\b\u0004"+
		"\u00000/\u0001\u0000\u0000\u000014\u0001\u0000\u0000\u000020\u0001\u0000"+
		"\u0000\u000023\u0001\u0000\u0000\u000036\u0001\u0000\u0000\u000042\u0001"+
		"\u0000\u0000\u00005.\u0001\u0000\u0000\u000056\u0001\u0000\u0000\u0000"+
		"6>\u0001\u0000\u0000\u00007;\u0005\u0004\u0000\u00008:\u0003\n\u0005\u0000"+
		"98\u0001\u0000\u0000\u0000:=\u0001\u0000\u0000\u0000;9\u0001\u0000\u0000"+
		"\u0000;<\u0001\u0000\u0000\u0000<?\u0001\u0000\u0000\u0000=;\u0001\u0000"+
		"\u0000\u0000>7\u0001\u0000\u0000\u0000>?\u0001\u0000\u0000\u0000?@\u0001"+
		"\u0000\u0000\u0000@A\u0005\u000f\u0000\u0000A\u0007\u0001\u0000\u0000"+
		"\u0000BC\u0005\u0019\u0000\u0000CD\u0005\u0005\u0000\u0000DH\u0003\u0014"+
		"\n\u0000EF\u0005\u0006\u0000\u0000FG\u0005\u0007\u0000\u0000GI\u0003\u0018"+
		"\f\u0000HE\u0001\u0000\u0000\u0000HI\u0001\u0000\u0000\u0000I\t\u0001"+
		"\u0000\u0000\u0000JK\u0005\u0019\u0000\u0000KO\u0005\b\u0000\u0000LN\u0003"+
		"\f\u0006\u0000ML\u0001\u0000\u0000\u0000NQ\u0001\u0000\u0000\u0000OM\u0001"+
		"\u0000\u0000\u0000OP\u0001\u0000\u0000\u0000PR\u0001\u0000\u0000\u0000"+
		"QO\u0001\u0000\u0000\u0000RS\u0005\t\u0000\u0000S\u000b\u0001\u0000\u0000"+
		"\u0000TU\u0005\u0019\u0000\u0000UV\u0005\u0005\u0000\u0000VW\u0003\u0014"+
		"\n\u0000W\r\u0001\u0000\u0000\u0000XY\u0005\n\u0000\u0000YZ\u0003\u0010"+
		"\b\u0000Z[\u0005\u000b\u0000\u0000[`\u0003\u0012\t\u0000\\]\u0005\f\u0000"+
		"\u0000]_\u0003\u0012\t\u0000^\\\u0001\u0000\u0000\u0000_b\u0001\u0000"+
		"\u0000\u0000`^\u0001\u0000\u0000\u0000`a\u0001\u0000\u0000\u0000ac\u0001"+
		"\u0000\u0000\u0000b`\u0001\u0000\u0000\u0000cd\u0005\r\u0000\u0000d\u000f"+
		"\u0001\u0000\u0000\u0000ef\u0005\u0019\u0000\u0000f\u0011\u0001\u0000"+
		"\u0000\u0000gh\u0005\u0019\u0000\u0000h\u0013\u0001\u0000\u0000\u0000"+
		"il\u0003\u0016\u000b\u0000jl\u0005\u0019\u0000\u0000ki\u0001\u0000\u0000"+
		"\u0000kj\u0001\u0000\u0000\u0000l\u0015\u0001\u0000\u0000\u0000mn\u0007"+
		"\u0000\u0000\u0000n\u0017\u0001\u0000\u0000\u0000op\u0007\u0001\u0000"+
		"\u0000p\u0019\u0001\u0000\u0000\u0000\u000b\u001d\u001f*25;>HO`k";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}