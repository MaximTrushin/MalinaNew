parser grammar MalinaParser;

options { tokenVocab=MalinaLexer; }

//_inline - inline expression
//_stmt - declaration statement (always ends with NEWLINE).

module			:	namespace_decl_stmt* (document_stmt | alias_def_stmt)*;

namespace_decl_stmt : NAMESPACE_ID;

document_stmt	:	DOCUMENT_ID ((block_inline NEWLINE) | block);// document_body;

alias_def_stmt	:	ALIAS_DEF_ID ((block_inline NEWLINE) | block);

block	:	COLON INDENT (block_line_stmt | inline_stmt)+ DEDENT;

block_inline	:	COLON (inline_expression)+;

//Represent inline expression
inline_expression	:	attr_inline;

inline_stmt	:	inline_expression (inline_expression)+ NEWLINE;

attr_inline	:	ATTRIBUTE_ID (DQS | open_value);

//Represents one line of block. Always ends with NEWLINE
block_line_stmt	:	attr_stmt;

attr_stmt	:	ATTRIBUTE_ID (DQS | open_value) NEWLINE;

open_value	: (OPEN_VALUE | OPEN_VALUE_INDENT)+;







