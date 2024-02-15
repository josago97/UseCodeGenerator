grammar Use;

/* ================== Parser rules ================== */

startRule: 
	model
	(class 
	| enumeration 
	| association)*
	constraints?
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
	ID ':' type ('init' '=' typeLiteral ';')?;

operation:
	ID '(' (parameter ','?)* ')' (':' type)?
	operationBody
	;

parameter:
	ID ':' type;

operationBody: 
	BEGIN 
		statements
	END
	pre*
	post*;

statements: 
	statement? (';' statement*)?;

statement
	: conditional
	| (~(END))+
	;
	
conditional:
	'if' '('? statement ')'? 'then' statement* ('else' statement*)?  END;

pre:
	'pre:' statement;

post:
	'post:' statement;

/* ====== Enumeration ====== */

enumeration: 
	ENUM enumerationName '{' enumerationLiteral (',' enumerationLiteral)* '}';

enumerationName: ID;

enumerationLiteral: ID;

/* ====== Types ====== */

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
    (ASSOCIATION | COMPOSITION) associationName BETWEEN
    associationItem
	associationItem
    END;

associationName: ID;

associationItem: className multiplicity ROLE roleName ORDERED?;

roleName: ID;

multiplicity: '[' multiplicityValue ('..' multiplicityValue)? ']';
multiplicityValue: NUMBER | '*';

constraints: CONSTRAINTS .*? EOF;

/* ================= Lexer rules ================= */

// Keywords
ABSTRACT: 'abstract';
ASSOCIATION: 'association';
ATTRIBUTES: 'attributes';
BEGIN: 'begin';
BETWEEN: 'between';
CLASS: 'class';
COMPOSITION: 'composition';
CONSTRAINTS: 'constraints';
END: 'end';
ENUM: 'enum';
LT: '<';
MODEL: 'model';
OPERATIONS: 'operations';
ORDERED: 'ordered';
ROLE: 'role';

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
COMMENT: 
	('#' .*? END_LINE
    | '//' .*? END_LINE
    | '/*' .*? '*/'
	| '--' .*? END_LINE
    ) -> skip;
END_LINE: [\n\r]+ -> skip;
WS: [ \t]+ -> skip;
OTHER: . -> skip;





