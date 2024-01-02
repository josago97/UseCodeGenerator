// Generated from d:\JOSE\Documents\Proyectos C#\OclCodeGenerator\OclCodeGenerator\Use.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class UseParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		IDENTIFIER=10, ABSTRACT=11, END=12, BOOLEAN=13, INTEGER=14, REAL=15, STRING=16, 
		BOOLEAN_LITERAL=17, ENUMERATION_LITERAL=18, INTEGER_LITERAL=19, REAL_LITERAL=20, 
		STRING_LITERAL=21, WS=22;
	public static final int
		RULE_file = 0, RULE_model = 1, RULE_class = 2, RULE_attribute = 3, RULE_enumeration = 4, 
		RULE_type = 5, RULE_simpleType = 6, RULE_simpleTypeLiteral = 7;
	private static String[] makeRuleNames() {
		return new String[] {
			"file", "model", "class", "attribute", "enumeration", "type", "simpleType", 
			"simpleTypeLiteral"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'model'", "'class'", "'attributes'", "'operations'", "':'", "'init'", 
			"'='", "';'", "'enumeration'", null, "'abstract'", "'end'", "'Boolean'", 
			"'Integer'", "'Real'", "'String'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, "IDENTIFIER", 
			"ABSTRACT", "END", "BOOLEAN", "INTEGER", "REAL", "STRING", "BOOLEAN_LITERAL", 
			"ENUMERATION_LITERAL", "INTEGER_LITERAL", "REAL_LITERAL", "STRING_LITERAL", 
			"WS"
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

	public static class FileContext extends ParserRuleContext {
		public ModelContext model() {
			return getRuleContext(ModelContext.class,0);
		}
		public TerminalNode EOF() { return getToken(UseParser.EOF, 0); }
		public List<ClassContext> class() {
			return getRuleContexts(ClassContext.class);
		}
		public ClassContext class(int i) {
			return getRuleContext(ClassContext.class,i);
		}
		public FileContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_file; }
	}

	public final FileContext file() throws RecognitionException {
		FileContext _localctx = new FileContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_file);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(16);
			model();
			setState(20);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__1) {
				{
				{
				setState(17);
				class();
				}
				}
				setState(22);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(23);
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

	public static class ModelContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public ModelContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_model; }
	}

	public final ModelContext model() throws RecognitionException {
		ModelContext _localctx = new ModelContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_model);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(25);
			match(T__0);
			setState(26);
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

	public static class ClassContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public List<TerminalNode> END() { return getTokens(UseParser.END); }
		public TerminalNode END(int i) {
			return getToken(UseParser.END, i);
		}
		public TerminalNode ABSTRACT() { return getToken(UseParser.ABSTRACT, 0); }
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public ClassContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_class; }
	}

	public final ClassContext class() throws RecognitionException {
		ClassContext _localctx = new ClassContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_class);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(28);
			match(T__1);
			setState(30);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ABSTRACT) {
				{
				setState(29);
				match(ABSTRACT);
				}
			}

			setState(32);
			match(IDENTIFIER);
			setState(43);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__2) {
				{
				setState(33);
				match(T__2);
				setState(37);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==IDENTIFIER) {
					{
					{
					setState(34);
					attribute();
					}
					}
					setState(39);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(41);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
				case 1:
					{
					setState(40);
					match(END);
					}
					break;
				}
				}
			}

			setState(49);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(45);
				match(T__3);
				setState(47);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
				case 1:
					{
					setState(46);
					match(END);
					}
					break;
				}
				}
			}

			setState(51);
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
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_attribute);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(53);
			match(IDENTIFIER);
			setState(54);
			match(T__4);
			setState(55);
			type();
			setState(59);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__5) {
				{
				setState(56);
				match(T__5);
				setState(57);
				match(T__6);
				setState(58);
				simpleTypeLiteral();
				}
			}

			setState(61);
			match(T__7);
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

	public static class EnumerationContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public TerminalNode END() { return getToken(UseParser.END, 0); }
		public List<TerminalNode> ENUMERATION_LITERAL() { return getTokens(UseParser.ENUMERATION_LITERAL); }
		public TerminalNode ENUMERATION_LITERAL(int i) {
			return getToken(UseParser.ENUMERATION_LITERAL, i);
		}
		public EnumerationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_enumeration; }
	}

	public final EnumerationContext enumeration() throws RecognitionException {
		EnumerationContext _localctx = new EnumerationContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_enumeration);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(63);
			match(T__8);
			setState(64);
			match(IDENTIFIER);
			setState(68);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==ENUMERATION_LITERAL) {
				{
				{
				setState(65);
				match(ENUMERATION_LITERAL);
				}
				}
				setState(70);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(71);
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

	public static class TypeContext extends ParserRuleContext {
		public SimpleTypeContext simpleType() {
			return getRuleContext(SimpleTypeContext.class,0);
		}
		public TerminalNode IDENTIFIER() { return getToken(UseParser.IDENTIFIER, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_type);
		try {
			setState(75);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BOOLEAN:
			case INTEGER:
			case REAL:
			case STRING:
				enterOuterAlt(_localctx, 1);
				{
				setState(73);
				simpleType();
				}
				break;
			case IDENTIFIER:
				enterOuterAlt(_localctx, 2);
				{
				setState(74);
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

	public static class SimpleTypeContext extends ParserRuleContext {
		public TerminalNode BOOLEAN() { return getToken(UseParser.BOOLEAN, 0); }
		public TerminalNode INTEGER() { return getToken(UseParser.INTEGER, 0); }
		public TerminalNode REAL() { return getToken(UseParser.REAL, 0); }
		public TerminalNode STRING() { return getToken(UseParser.STRING, 0); }
		public SimpleTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleType; }
	}

	public final SimpleTypeContext simpleType() throws RecognitionException {
		SimpleTypeContext _localctx = new SimpleTypeContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_simpleType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(77);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOLEAN) | (1L << INTEGER) | (1L << REAL) | (1L << STRING))) != 0)) ) {
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

	public static class SimpleTypeLiteralContext extends ParserRuleContext {
		public TerminalNode BOOLEAN_LITERAL() { return getToken(UseParser.BOOLEAN_LITERAL, 0); }
		public TerminalNode INTEGER_LITERAL() { return getToken(UseParser.INTEGER_LITERAL, 0); }
		public TerminalNode REAL_LITERAL() { return getToken(UseParser.REAL_LITERAL, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(UseParser.STRING_LITERAL, 0); }
		public SimpleTypeLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleTypeLiteral; }
	}

	public final SimpleTypeLiteralContext simpleTypeLiteral() throws RecognitionException {
		SimpleTypeLiteralContext _localctx = new SimpleTypeLiteralContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_simpleTypeLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(79);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOLEAN_LITERAL) | (1L << INTEGER_LITERAL) | (1L << REAL_LITERAL) | (1L << STRING_LITERAL))) != 0)) ) {
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\30T\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\3\2\3\2\7\2\25\n\2"+
		"\f\2\16\2\30\13\2\3\2\3\2\3\3\3\3\3\3\3\4\3\4\5\4!\n\4\3\4\3\4\3\4\7\4"+
		"&\n\4\f\4\16\4)\13\4\3\4\5\4,\n\4\5\4.\n\4\3\4\3\4\5\4\62\n\4\5\4\64\n"+
		"\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\5\5>\n\5\3\5\3\5\3\6\3\6\3\6\7\6E\n"+
		"\6\f\6\16\6H\13\6\3\6\3\6\3\7\3\7\5\7N\n\7\3\b\3\b\3\t\3\t\3\t\2\2\n\2"+
		"\4\6\b\n\f\16\20\2\4\3\2\17\22\4\2\23\23\25\27\2U\2\22\3\2\2\2\4\33\3"+
		"\2\2\2\6\36\3\2\2\2\b\67\3\2\2\2\nA\3\2\2\2\fM\3\2\2\2\16O\3\2\2\2\20"+
		"Q\3\2\2\2\22\26\5\4\3\2\23\25\5\6\4\2\24\23\3\2\2\2\25\30\3\2\2\2\26\24"+
		"\3\2\2\2\26\27\3\2\2\2\27\31\3\2\2\2\30\26\3\2\2\2\31\32\7\2\2\3\32\3"+
		"\3\2\2\2\33\34\7\3\2\2\34\35\7\f\2\2\35\5\3\2\2\2\36 \7\4\2\2\37!\7\r"+
		"\2\2 \37\3\2\2\2 !\3\2\2\2!\"\3\2\2\2\"-\7\f\2\2#\'\7\5\2\2$&\5\b\5\2"+
		"%$\3\2\2\2&)\3\2\2\2\'%\3\2\2\2\'(\3\2\2\2(+\3\2\2\2)\'\3\2\2\2*,\7\16"+
		"\2\2+*\3\2\2\2+,\3\2\2\2,.\3\2\2\2-#\3\2\2\2-.\3\2\2\2.\63\3\2\2\2/\61"+
		"\7\6\2\2\60\62\7\16\2\2\61\60\3\2\2\2\61\62\3\2\2\2\62\64\3\2\2\2\63/"+
		"\3\2\2\2\63\64\3\2\2\2\64\65\3\2\2\2\65\66\7\16\2\2\66\7\3\2\2\2\678\7"+
		"\f\2\289\7\7\2\29=\5\f\7\2:;\7\b\2\2;<\7\t\2\2<>\5\20\t\2=:\3\2\2\2=>"+
		"\3\2\2\2>?\3\2\2\2?@\7\n\2\2@\t\3\2\2\2AB\7\13\2\2BF\7\f\2\2CE\7\24\2"+
		"\2DC\3\2\2\2EH\3\2\2\2FD\3\2\2\2FG\3\2\2\2GI\3\2\2\2HF\3\2\2\2IJ\7\16"+
		"\2\2J\13\3\2\2\2KN\5\16\b\2LN\7\f\2\2MK\3\2\2\2ML\3\2\2\2N\r\3\2\2\2O"+
		"P\t\2\2\2P\17\3\2\2\2QR\t\3\2\2R\21\3\2\2\2\f\26 \'+-\61\63=FM";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}