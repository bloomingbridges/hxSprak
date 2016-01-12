package sprak.tokenizer;

// using System;

enum TokenType {
    NO_TOKEN_TYPE;
    EOF;
    NEW_LINE;
    COMMA;
    
    NAME;
    ARRAY_LOOKUP;
    OPERATOR;
    NUMBER;
    QUOTED_STRING;
    BOOLEAN_VALUE;
    ARRAY;
    DOT;
    
    ARRAY_END_SIGNAL;
    BUILT_IN_TYPE_NAME;
    ELSE;
    PARANTHESIS_LEFT;
    PARANTHESIS_RIGHT;
    BRACKET_LEFT;
    BRACKET_RIGHT;
    //BLOCK_BEGIN;
    BLOCK_END;         
    STATEMENT_LIST;
    VAR_DECLARATION;
    FUNC_DECLARATION;
    NODE_GROUP;
    PARAMETER;
    FUNCTION_CALL;
    ASSIGNMENT;
    ASSIGNMENT_TO_ARRAY;
    IF;
    LOOP;
    IN;
    LOOP_BLOCK;
    LOOP_INCREMENT;
    GOTO_BEGINNING_OF_LOOP;
    BREAK;
    RETURN;
    PROGRAM_ROOT;
    COMMENT;
    FROM;
    TO;

    AND;
    OR;
}

class Token {

    private var m_tokenType:TokenType;
    private var m_tokenString:String;
    private var m_lineNr:Int = -1;
    private var m_linePosition:Int = -1;

    public function new(tokenType:TokenType, tokenString:String, ?lineNr:Int, ?linePosition:Int) {
        m_tokenType = tokenType;
        m_tokenString = tokenString;
        m_lineNr = lineNr;
        m_linePosition = linePosition;
    }

    public function getTokenType():TokenType {
        return m_tokenType;
    }

    public function getTokenString():String {
        return m_tokenString;
    }

    public function toString():String {
        return getTokenType() + " " + getTokenString();
    }

    public function equals(obj:Dynamic):Bool {
        if (Std.is(obj, Token)) {
            var other:Token = cast(obj, Token); 
            if (this.getTokenString() == "")
                return m_tokenType == other.getTokenType();
            else
                return m_tokenString == other.getTokenString();
        }
        return false;
    }

    public var LineNr(never, set):Int;
    function set_LineNr(value) {
        return m_lineNr = value;
    }
    
    public var LinePosition(never, set):Int;
    function set_LinePosition(value) {
        return m_linePosition = value;
    }

}

class TokenWithValue extends Token {

    private var m_value:Dynamic;

    public function new(tokenType:TokenType, tokenString:String, ?lineNr:Int, ?linePosition:Int, pValue:Dynamic) {
        super(tokenType, tokenString, lineNr, linePosition);
        m_value = pValue;
    }

    public function getValue():Dynamic {
        return m_value;
    }

}

