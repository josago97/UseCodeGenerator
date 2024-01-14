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

operationBody: 
BEGIN 
(~('end') | '.')*
END;

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
	: booleanLiteral
	| integerLiteral
	| realLiteral
	| stringLiteral;
	
booleanLiteral: TRUE | FALSE;
integerLiteral: NUMBER;
realLiteral: NUMBER ('.' NUMBER)?;
stringLiteral: STRING_LITERAL;
	
/* ====== Association ====== */

association: 
    ASSOCIATION associationName BETWEEN
    associationItem
	associationItem
    END;

associationName: ID;

associationItem: className multiplicity ROLE roleName;

roleName: ID;

multiplicity: '[' multiplicityValue ('..' multiplicityValue)? ']';
multiplicityValue: NUMBER | '*';

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
TRUE: 'true';
FALSE: 'false';
INTEGER: 'Integer';
REAL: 'Real';
STRING: 'String';

STRING_LITERAL: StringDelimeter StringContent StringDelimeter;
fragment StringDelimeter: ['];
fragment StringContent: (~['])*;

NUMBER: [0-9]+;
ID: [A-Za-z_][A-Za-z0-9_]*;

// Ignore
COMMENT: '#'~[\r\n]* -> skip;
WS: [ \t\r\n]+ -> skip;