package sprak.tokenizer;

import glue.TextReader;
import sprak.errors.*;

class Tokenizer {

    static var s_letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_@!?";
    static var s_digits = "1234567890";

    private var m_tokens:List<Token>;
    private var m_textReader:TextReader;

    private var m_currentChar:String;
    private var m_currentLine:Int;
    private var m_currentPosition:Int;
    private var m_currentTokenStartPosition:Int;
    private var m_stripOutComments:Bool;
    private var m_endOfFile:Bool;
    
    private var m_errorHandler:ErrorHandler;

    public function new(errorHandler:ErrorHandler, stripOutComments:Bool) {
        m_errorHandler = errorHandler;
        m_stripOutComments = stripOutComments;
    }

    public function process(textReader:TextReader):List<Token> {

        m_tokens = new List<Token>();
        m_textReader = textReader;
        m_endOfFile = false;

        m_currentLine = 1;
        m_currentPosition = 0;
        m_currentTokenStartPosition = 0;
        m_currentChar = "";
        readNextChar();

        var t:Token;

        do {
            t = readNextToken();
            t.LineNr = m_currentLine;
            t.LinePosition = m_currentTokenStartPosition;
            m_currentTokenStartPosition = m_currentPosition;

            m_tokens.add(t);

        } while (t.getTokenType() != Token.TokenType.EOF);

        m_textReader.Close();
        m_textReader.Dispose();

        return m_tokens;
    }

    private function readNextToken():Token {

        while (!m_endOfFile) {
            readNextChar();
            return NAME();
        }

        return new Token(Token.TokenType.EOF, "<EOF>");
    }

    private function NAME():Token {
        return new Token(Token.TokenType.NAME, m_currentChar);
    }

    private function readNextChar():Void {

        var c:Int = m_textReader.Read();
        if (c > 0) {
            m_currentChar = String.fromCharCode(c);
            // trace(m_currentPosition + ": " + m_currentChar);
            m_currentPosition++;
        }
        else {
            // m_currentChar = "\0";
            m_endOfFile = true;
        }

    }

}

