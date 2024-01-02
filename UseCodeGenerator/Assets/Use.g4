grammar Use;

/* ================== Parser rules ================== */

startRule: 
	model
	(class 
	| enumeration 
	| association)*
	EOF;

/* ====== Model ====== */

model: MODEL modelName;

modelName: ID;

/* ====== Class ====== */

class:
	ABSTRACT? CLASS className inheritance?
		(ATTRIBUTES attribute*)? 
		(OPERATIONS operation*)? 
	END;

className: ID;

inheritance: LT className (',' className)*;

attribute:
	ID ':' type ('init' '=' typeLiteral SEMICOLON)?;

operation:
	ID '(' (parameter ','?)* ')' (':' type)?
	operationBody
	;

parameter:
	ID ':' type;

operationBody: BEGIN .*? END;

/* ====== Enumeration ====== */

enumeration: 
	ENUM enumerationName '{' enumerationLiteral (',' enumerationLiteral)* '}';

enumerationName: ID;

enumerationLiteral: ID;

/* ====== Other ====== */

type: simpleType | enumerationName;

typeLiteral: simpleTypeLiteral | enumerationLiteral;

simpleType: BOOLEAN | INTEGER | REAL | STRING;

simpleTypeLiteral
	: BOOLEAN_LITERAL
	| INTEGER_LITERAL
	| REAL_LITERAL
	| STRING_LITERAL;
	
	
/* ====== Association ====== */

association: 
    ASSOCIATION ID BETWEEN
    ID multiplicity ROLE ID
    END;

multiplicity:
    '[' (. | '*')+? ']';

/* ================= Lexer rules ================= */

// Keywords
ABSTRACT: 'abstract';
ASSOCIATION: 'association';
ATTRIBUTES: 'attributes';
BEGIN: 'begin';
BETWEEN: 'between';
CLASS: 'class';
END: 'end';
ENUM: 'enum';
LT: '<';
MODEL: 'model';
OPERATIONS: 'operations';
ROLE: 'role';
SEMICOLON: ';';

// Primitive types
BOOLEAN: 'Boolean';
INTEGER: 'Integer';
REAL: 'Real';
STRING: 'String';

BOOLEAN_LITERAL: ('true' | 'false');
INTEGER_LITERAL: Digits;
REAL_LITERAL: INTEGER_LITERAL | Digits '.' Digits;
STRING_LITERAL: StringDelimeter StringContent StringDelimeter;

fragment Digits: [0-9]+;
fragment StringDelimeter: ['];
fragment StringContent: (~['])*;

ID: [A-Za-z_][A-Za-z0-9_]*;


// Ignore
COMMENT: '#'~[\r\n]* -> skip;
WS: [ \t\r\n]+ -> skip;