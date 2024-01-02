// Generated from d:\JOSE\Documents\Proyectos C#\OclCodeGenerator\OclCodeGenerator\Simple.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SimpleLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, END=6, BOOLEAN=7, INTEGER=8, REAL=9, 
		STRING=10, BOOLEAN_LITERAL=11, INTEGER_LITERAL=12, REAL_LITERAL=13, STRING_LITERAL=14, 
		IDENTIFIER=15, WHITESPACE=16, IGNORE=17;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "END", "BOOLEAN", "INTEGER", 
			"REAL", "STRING", "BOOLEAN_LITERAL", "INTEGER_LITERAL", "REAL_LITERAL", 
			"STRING_LITERAL", "IDENTIFIER", "WHITESPACE", "IGNORE"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'model'", "'class'", "':'", "';'", "'attributes'", "'end'", "'Boolean'", 
			"'Integer'", "'Real'", "'String'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, "END", "BOOLEAN", "INTEGER", "REAL", 
			"STRING", "BOOLEAN_LITERAL", "INTEGER_LITERAL", "REAL_LITERAL", "STRING_LITERAL", 
			"IDENTIFIER", "WHITESPACE", "IGNORE"
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


	public SimpleLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Simple.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\23\u0090\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\3\2\3\2\3\2\3\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\5\3\5"+
		"\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\b\3\b\3"+
		"\b\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n"+
		"\3\n\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3"+
		"\f\3\f\5\fj\n\f\3\r\6\rm\n\r\r\r\16\rn\3\16\3\16\3\16\3\16\3\17\3\17\7"+
		"\17w\n\17\f\17\16\17z\13\17\3\17\3\17\3\20\3\20\7\20\u0080\n\20\f\20\16"+
		"\20\u0083\13\20\3\21\6\21\u0086\n\21\r\21\16\21\u0087\3\22\6\22\u008b"+
		"\n\22\r\22\16\22\u008c\3\22\3\22\2\2\23\3\3\5\4\7\5\t\6\13\7\r\b\17\t"+
		"\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21!\22#\23\3\2\7\3\2\62;\4"+
		"\2))``\5\2C\\aac|\6\2\62;C\\aac|\4\2\13\f\17\17\2\u0095\2\3\3\2\2\2\2"+
		"\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2"+
		"\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2"+
		"\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\3%\3\2\2\2"+
		"\5+\3\2\2\2\7\61\3\2\2\2\t\63\3\2\2\2\13\65\3\2\2\2\r@\3\2\2\2\17D\3\2"+
		"\2\2\21L\3\2\2\2\23T\3\2\2\2\25Y\3\2\2\2\27i\3\2\2\2\31l\3\2\2\2\33p\3"+
		"\2\2\2\35t\3\2\2\2\37}\3\2\2\2!\u0085\3\2\2\2#\u008a\3\2\2\2%&\7o\2\2"+
		"&\'\7q\2\2\'(\7f\2\2()\7g\2\2)*\7n\2\2*\4\3\2\2\2+,\7e\2\2,-\7n\2\2-."+
		"\7c\2\2./\7u\2\2/\60\7u\2\2\60\6\3\2\2\2\61\62\7<\2\2\62\b\3\2\2\2\63"+
		"\64\7=\2\2\64\n\3\2\2\2\65\66\7c\2\2\66\67\7v\2\2\678\7v\2\289\7t\2\2"+
		"9:\7k\2\2:;\7d\2\2;<\7w\2\2<=\7v\2\2=>\7g\2\2>?\7u\2\2?\f\3\2\2\2@A\7"+
		"g\2\2AB\7p\2\2BC\7f\2\2C\16\3\2\2\2DE\7D\2\2EF\7q\2\2FG\7q\2\2GH\7n\2"+
		"\2HI\7g\2\2IJ\7c\2\2JK\7p\2\2K\20\3\2\2\2LM\7K\2\2MN\7p\2\2NO\7v\2\2O"+
		"P\7g\2\2PQ\7i\2\2QR\7g\2\2RS\7t\2\2S\22\3\2\2\2TU\7T\2\2UV\7g\2\2VW\7"+
		"c\2\2WX\7n\2\2X\24\3\2\2\2YZ\7U\2\2Z[\7v\2\2[\\\7t\2\2\\]\7k\2\2]^\7p"+
		"\2\2^_\7i\2\2_\26\3\2\2\2`a\7v\2\2ab\7t\2\2bc\7w\2\2cj\7g\2\2de\7h\2\2"+
		"ef\7c\2\2fg\7n\2\2gh\7u\2\2hj\7g\2\2i`\3\2\2\2id\3\2\2\2j\30\3\2\2\2k"+
		"m\t\2\2\2lk\3\2\2\2mn\3\2\2\2nl\3\2\2\2no\3\2\2\2o\32\3\2\2\2pq\5\31\r"+
		"\2qr\7\60\2\2rs\5\31\r\2s\34\3\2\2\2tx\7)\2\2uw\t\3\2\2vu\3\2\2\2wz\3"+
		"\2\2\2xv\3\2\2\2xy\3\2\2\2y{\3\2\2\2zx\3\2\2\2{|\7)\2\2|\36\3\2\2\2}\u0081"+
		"\t\4\2\2~\u0080\t\5\2\2\177~\3\2\2\2\u0080\u0083\3\2\2\2\u0081\177\3\2"+
		"\2\2\u0081\u0082\3\2\2\2\u0082 \3\2\2\2\u0083\u0081\3\2\2\2\u0084\u0086"+
		"\7\"\2\2\u0085\u0084\3\2\2\2\u0086\u0087\3\2\2\2\u0087\u0085\3\2\2\2\u0087"+
		"\u0088\3\2\2\2\u0088\"\3\2\2\2\u0089\u008b\t\6\2\2\u008a\u0089\3\2\2\2"+
		"\u008b\u008c\3\2\2\2\u008c\u008a\3\2\2\2\u008c\u008d\3\2\2\2\u008d\u008e"+
		"\3\2\2\2\u008e\u008f\b\22\2\2\u008f$\3\2\2\2\t\2inx\u0081\u0087\u008c"+
		"\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}