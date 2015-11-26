using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProgrammingLanguageNr1.tests
{
	[TestFixture()]
	public class Tokenizer_TEST
	{
		static ErrorHandler s_errorHandler = new ErrorHandler();
		
		[Test()]
		public void TokenizeCode1 ()
		{
			TextReader reader = File.OpenText("code1.txt");
			Tokenizer t = new Tokenizer(s_errorHandler, true);
            List<Token> tokens = t.process(reader);
			Assert.AreEqual(12, tokens.Count);
			Assert.AreEqual(tokens[0].getTokenType(), Token.TokenType.NAME);
			Assert.AreEqual(tokens[1].getTokenType(), Token.TokenType.ASSIGNMENT);
			Assert.AreEqual(tokens[2].getTokenType(), Token.TokenType.NAME);
			Assert.AreEqual(tokens[3].getTokenType(), Token.TokenType.OPERATOR);
			Assert.AreEqual(tokens[4].getTokenType(), Token.TokenType.NUMBER);
			Assert.AreEqual(tokens[5].getTokenType(), Token.TokenType.NEW_LINE);
			Assert.AreEqual(tokens[6].getTokenType(), Token.TokenType.NAME);
			Assert.AreEqual(tokens[7].getTokenType(), Token.TokenType.PARANTHESIS_LEFT);
			Assert.AreEqual(tokens[8].getTokenType(), Token.TokenType.NAME);
			Assert.AreEqual(tokens[9].getTokenType(), Token.TokenType.PARANTHESIS_RIGHT);
			Assert.AreEqual(tokens[10].getTokenType(), Token.TokenType.NEW_LINE);
			Assert.AreEqual(tokens[11].getTokenType(), Token.TokenType.EOF);
		}
		
		[Test()]
		public void TokenizeCode2 ()
		{
			TextReader reader = File.OpenText("code2.txt");
			Assert.IsNotNull(reader);
            Tokenizer t = new Tokenizer(s_errorHandler, true);
            List<Token> tokens = t.process(reader);
			
			Assert.AreEqual(tokens[0].getTokenType(), Token.TokenType.IF);
			Assert.AreEqual(tokens[1].getTokenType(), Token.TokenType.PARANTHESIS_LEFT);
			Assert.AreEqual(tokens[2].getTokenType(), Token.TokenType.NAME);
			Assert.AreEqual(tokens[3].getTokenType(), Token.TokenType.OPERATOR);
			Assert.AreEqual(tokens[4].getTokenType(), Token.TokenType.NUMBER);
			Assert.AreEqual(tokens[5].getTokenType(), Token.TokenType.PARANTHESIS_RIGHT);
			Assert.AreEqual(tokens[6].getTokenType(), Token.TokenType.NEW_LINE);
			Assert.AreEqual(tokens[7].getTokenType(), Token.TokenType.NAME);
			Assert.AreEqual(tokens[8].getTokenType(), Token.TokenType.PARANTHESIS_LEFT);
			Assert.AreEqual(tokens[9].getTokenType(), Token.TokenType.QUOTED_STRING);
			Assert.AreEqual(tokens[10].getTokenType(), Token.TokenType.PARANTHESIS_RIGHT);
			Assert.AreEqual(tokens[11].getTokenType(), Token.TokenType.NEW_LINE);
			Assert.AreEqual(tokens[12].getTokenType(), Token.TokenType.BLOCK_END);
			Assert.AreEqual(tokens[13].getTokenType(), Token.TokenType.EOF);
		}

        [Test()]
        public void TokenizeCode3()
        {
            TextReader reader = File.OpenText("code41.txt");
            Assert.IsNotNull(reader);
            Tokenizer t = new Tokenizer(s_errorHandler, true);
            List<Token> tokens = t.process(reader);

            Assert.AreEqual(tokens[0].getTokenType(), Token.TokenType.BUILT_IN_TYPE_NAME);
            Assert.AreEqual(tokens[1].getTokenType(), Token.TokenType.NAME);
            Assert.AreEqual(tokens[2].getTokenType(), Token.TokenType.ASSIGNMENT);
            Assert.AreEqual(tokens[3].getTokenType(), Token.TokenType.NUMBER);
            Assert.AreEqual(tokens[4].getTokenType(), Token.TokenType.NEW_LINE);
            Assert.AreEqual(tokens[5].getTokenType(), Token.TokenType.BUILT_IN_TYPE_NAME);
            Assert.AreEqual(tokens[6].getTokenType(), Token.TokenType.NAME);
            Assert.AreEqual(tokens[7].getTokenType(), Token.TokenType.ASSIGNMENT);
            Assert.AreEqual(tokens[8].getTokenType(), Token.TokenType.QUOTED_STRING);
            Assert.AreEqual(tokens[9].getTokenType(), Token.TokenType.NEW_LINE);
            Assert.AreEqual(tokens[10].getTokenType(), Token.TokenType.BUILT_IN_TYPE_NAME);
            Assert.AreEqual(tokens[11].getTokenType(), Token.TokenType.NAME);
            Assert.AreEqual(tokens[12].getTokenType(), Token.TokenType.PARANTHESIS_LEFT);
            Assert.AreEqual(tokens[13].getTokenType(), Token.TokenType.PARANTHESIS_RIGHT);
            Assert.AreEqual(tokens[14].getTokenType(), Token.TokenType.NEW_LINE);
			Assert.AreEqual(tokens[15].getTokenType(), Token.TokenType.NAME);
            Assert.AreEqual(tokens[16].getTokenType(), Token.TokenType.ASSIGNMENT);
            Assert.AreEqual(tokens[17].getTokenType(), Token.TokenType.NUMBER);
            Assert.AreEqual(tokens[18].getTokenType(), Token.TokenType.EOF);
        }

		[Test()]
		public void TokenizeSingleQuotedCode ()
		{
			StringReader programString = new StringReader(
				@"'hej'"
			);

			Tokenizer tokenizer = new Tokenizer(s_errorHandler, true);
			List<Token> tokens = tokenizer.process(programString);

			tokens.ForEach (t => Console.WriteLine(t.getTokenType().ToString() + ", " + t.getTokenString()));

			Assert.AreEqual(2, tokens.Count);
			Assert.AreEqual(Token.TokenType.QUOTED_STRING, tokens[0].getTokenType());
			Assert.AreEqual(Token.TokenType.EOF, tokens[1].getTokenType());
			Assert.AreEqual("hej", tokens[0].getTokenString());
		}

		[Test()]
		public void TokenizeDoubleQuotedCodeWithSingleQuoteInText ()
		{
			StringReader programString = new StringReader(
				"\"can't\""
			);

			Tokenizer tokenizer = new Tokenizer(s_errorHandler, true);
			List<Token> tokens = tokenizer.process(programString);

			tokens.ForEach (t => Console.WriteLine(t.getTokenType().ToString() + ", " + t.getTokenString()));

			Assert.AreEqual(2, tokens.Count);
			Assert.AreEqual(Token.TokenType.QUOTED_STRING, tokens[0].getTokenType());
			Assert.AreEqual(Token.TokenType.EOF, tokens[1].getTokenType());
			Assert.AreEqual("can't", tokens[0].getTokenString());
		}


	}
}
