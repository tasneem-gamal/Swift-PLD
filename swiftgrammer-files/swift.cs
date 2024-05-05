
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUS               =  3, // '-'
        SYMBOL_MINUSMINUS          =  4, // '--'
        SYMBOL_EXCLAMEQ            =  5, // '!='
        SYMBOL_LPAREN              =  6, // '('
        SYMBOL_RPAREN              =  7, // ')'
        SYMBOL_TIMES               =  8, // '*'
        SYMBOL_DIV                 =  9, // '/'
        SYMBOL_COLON               = 10, // ':'
        SYMBOL_LBRACE              = 11, // '{'
        SYMBOL_RBRACE              = 12, // '}'
        SYMBOL_PLUS                = 13, // '+'
        SYMBOL_PLUSPLUS            = 14, // '++'
        SYMBOL_LT                  = 15, // '<'
        SYMBOL_LTEQ                = 16, // '<='
        SYMBOL_EQ                  = 17, // '='
        SYMBOL_EQEQ                = 18, // '=='
        SYMBOL_GT                  = 19, // '>'
        SYMBOL_GTEQ                = 20, // '>='
        SYMBOL_BOOL                = 21, // bool
        SYMBOL_CASE                = 22, // case
        SYMBOL_CHARACTER           = 23, // Character
        SYMBOL_DEFAULT             = 24, // default
        SYMBOL_DOUBLE              = 25, // Double
        SYMBOL_ELSE                = 26, // else
        SYMBOL_ELSEIF              = 27, // 'else if'
        SYMBOL_FLOAT               = 28, // float
        SYMBOL_FOR                 = 29, // for
        SYMBOL_IDENTIFIER          = 30, // Identifier
        SYMBOL_IF                  = 31, // if
        SYMBOL_IN                  = 32, // in
        SYMBOL_INT                 = 33, // int
        SYMBOL_INTEGER             = 34, // Integer
        SYMBOL_LET                 = 35, // let
        SYMBOL_REPEAT              = 36, // repeat
        SYMBOL_STRING              = 37, // string
        SYMBOL_STRINGLITERAL       = 38, // StringLiteral
        SYMBOL_SWITCH              = 39, // switch
        SYMBOL_VAR                 = 40, // var
        SYMBOL_WHILE               = 41, // while
        SYMBOL_ADDEXP              = 42, // <Add Exp>
        SYMBOL_ASSIGNMENT          = 43, // <Assignment>
        SYMBOL_CASELIST            = 44, // <CaseList>
        SYMBOL_DEFAULT2            = 45, // <Default>
        SYMBOL_EXPRESSION          = 46, // <Expression>
        SYMBOL_FORINLOOP           = 47, // <forInLoop>
        SYMBOL_IFSTATEMENT         = 48, // <IfStatement>
        SYMBOL_INCDEC              = 49, // <IncDec>
        SYMBOL_KEYWORD             = 50, // <KeyWord>
        SYMBOL_MULTEXP             = 51, // <Mult Exp>
        SYMBOL_NEGATEEXP           = 52, // <Negate Exp>
        SYMBOL_PROGRAM             = 53, // <Program>
        SYMBOL_REPEATWHILELOOP     = 54, // <RepeatWhileLoop>
        SYMBOL_STATEMENT           = 55, // <Statement>
        SYMBOL_STATEMENTLIST       = 56, // <StatementList>
        SYMBOL_SWITCHSTATEMENT     = 57, // <SwitchStatement>
        SYMBOL_TYPE                = 58, // <Type>
        SYMBOL_VALUE               = 59, // <Value>
        SYMBOL_VARIABLEDECLARATION = 60, // <VariableDeclaration>
        SYMBOL_WHILELOOP           = 61  // <WhileLoop>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                                                          =  0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST                                                                                    =  1, // <StatementList> ::= 
        RULE_STATEMENTLIST2                                                                                   =  2, // <StatementList> ::= <StatementList> <Statement>
        RULE_STATEMENTLIST3                                                                                   =  3, // <StatementList> ::= <Statement>
        RULE_STATEMENT                                                                                        =  4, // <Statement> ::= <VariableDeclaration>
        RULE_STATEMENT2                                                                                       =  5, // <Statement> ::= <Assignment>
        RULE_STATEMENT3                                                                                       =  6, // <Statement> ::= <IfStatement>
        RULE_STATEMENT4                                                                                       =  7, // <Statement> ::= <SwitchStatement>
        RULE_STATEMENT5                                                                                       =  8, // <Statement> ::= <forInLoop>
        RULE_STATEMENT6                                                                                       =  9, // <Statement> ::= <WhileLoop>
        RULE_STATEMENT7                                                                                       = 10, // <Statement> ::= <RepeatWhileLoop>
        RULE_VARIABLEDECLARATION_IDENTIFIER_COLON_EQ                                                          = 11, // <VariableDeclaration> ::= <KeyWord> Identifier ':' <Type> '=' <Expression>
        RULE_KEYWORD_LET                                                                                      = 12, // <KeyWord> ::= let
        RULE_KEYWORD_VAR                                                                                      = 13, // <KeyWord> ::= var
        RULE_TYPE_INT                                                                                         = 14, // <Type> ::= int
        RULE_TYPE_STRING                                                                                      = 15, // <Type> ::= string
        RULE_TYPE_BOOL                                                                                        = 16, // <Type> ::= bool
        RULE_TYPE_FLOAT                                                                                       = 17, // <Type> ::= float
        RULE_TYPE_DOUBLE                                                                                      = 18, // <Type> ::= Double
        RULE_TYPE_CHARACTER                                                                                   = 19, // <Type> ::= Character
        RULE_ASSIGNMENT_IDENTIFIER_EQ                                                                         = 20, // <Assignment> ::= <KeyWord> Identifier '=' <Expression>
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE                                                       = 21, // <IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}'
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE                                    = 22, // <IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSEIF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 23, // <IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' 'else if' '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
        RULE_SWITCHSTATEMENT_SWITCH_LBRACE_RBRACE                                                             = 24, // <SwitchStatement> ::= switch <Expression> '{' <CaseList> <Default> '}'
        RULE_CASELIST                                                                                         = 25, // <CaseList> ::= 
        RULE_CASELIST_CASE_COLON                                                                              = 26, // <CaseList> ::= <CaseList> case <Expression> ':' <StatementList>
        RULE_CASELIST_CASE_COLON2                                                                             = 27, // <CaseList> ::= case <Expression> ':' <StatementList>
        RULE_DEFAULT_DEFAULT_COLON                                                                            = 28, // <Default> ::= default ':' <StatementList>
        RULE_FORINLOOP_FOR_IN_LBRACE_RBRACE                                                                   = 29, // <forInLoop> ::= for <Expression> in <Expression> '{' <StatementList> '}'
        RULE_WHILELOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE                                                      = 30, // <WhileLoop> ::= while '(' <Expression> ')' '{' <StatementList> <IncDec> '}'
        RULE_INCDEC_IDENTIFIER_PLUSPLUS                                                                       = 31, // <IncDec> ::= Identifier '++'
        RULE_INCDEC_IDENTIFIER_MINUSMINUS                                                                     = 32, // <IncDec> ::= Identifier '--'
        RULE_REPEATWHILELOOP_REPEAT_LBRACE_RBRACE_WHILE_LPAREN_RPAREN                                         = 33, // <RepeatWhileLoop> ::= repeat '{' <Expression> '}' while '(' <Expression> ')'
        RULE_EXPRESSION_GT                                                                                    = 34, // <Expression> ::= <Expression> '>' <Add Exp>
        RULE_EXPRESSION_LT                                                                                    = 35, // <Expression> ::= <Expression> '<' <Add Exp>
        RULE_EXPRESSION_LTEQ                                                                                  = 36, // <Expression> ::= <Expression> '<=' <Add Exp>
        RULE_EXPRESSION_GTEQ                                                                                  = 37, // <Expression> ::= <Expression> '>=' <Add Exp>
        RULE_EXPRESSION_EQEQ                                                                                  = 38, // <Expression> ::= <Expression> '==' <Add Exp>
        RULE_EXPRESSION_EXCLAMEQ                                                                              = 39, // <Expression> ::= <Expression> '!=' <Add Exp>
        RULE_EXPRESSION                                                                                       = 40, // <Expression> ::= <Add Exp>
        RULE_ADDEXP_PLUS                                                                                      = 41, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                                                                                     = 42, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                                                                           = 43, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                                                                    = 44, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
        RULE_MULTEXP_DIV                                                                                      = 45, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
        RULE_MULTEXP                                                                                          = 46, // <Mult Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS                                                                                  = 47, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP                                                                                        = 48, // <Negate Exp> ::= <Value>
        RULE_VALUE_IDENTIFIER                                                                                 = 49, // <Value> ::= Identifier
        RULE_VALUE_INTEGER                                                                                    = 50, // <Value> ::= Integer
        RULE_VALUE_STRINGLITERAL                                                                              = 51, // <Value> ::= StringLiteral
        RULE_VALUE_LPAREN_RPAREN                                                                              = 52  // <Value> ::= '(' <Expression> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHARACTER :
                //Character
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //Double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSEIF :
                //'else if'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LET :
                //let
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REPEAT :
                //repeat
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASELIST :
                //<CaseList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT2 :
                //<Default>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORINLOOP :
                //<forInLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCDEC :
                //<IncDec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEYWORD :
                //<KeyWord>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REPEATWHILELOOP :
                //<RepeatWhileLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSTATEMENT :
                //<SwitchStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION :
                //<VariableDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILELOOP :
                //<WhileLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2 :
                //<StatementList> ::= <StatementList> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST3 :
                //<StatementList> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <VariableDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <IfStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <SwitchStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <forInLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <WhileLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<Statement> ::= <RepeatWhileLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER_COLON_EQ :
                //<VariableDeclaration> ::= <KeyWord> Identifier ':' <Type> '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEYWORD_LET :
                //<KeyWord> ::= let
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEYWORD_VAR :
                //<KeyWord> ::= var
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<Type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRING :
                //<Type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOL :
                //<Type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_FLOAT :
                //<Type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_DOUBLE :
                //<Type> ::= Double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_CHARACTER :
                //<Type> ::= Character
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ :
                //<Assignment> ::= <KeyWord> Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSEIF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' 'else if' '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTATEMENT_SWITCH_LBRACE_RBRACE :
                //<SwitchStatement> ::= switch <Expression> '{' <CaseList> <Default> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST :
                //<CaseList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_COLON :
                //<CaseList> ::= <CaseList> case <Expression> ':' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_COLON2 :
                //<CaseList> ::= case <Expression> ':' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULT_DEFAULT_COLON :
                //<Default> ::= default ':' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORINLOOP_FOR_IN_LBRACE_RBRACE :
                //<forInLoop> ::= for <Expression> in <Expression> '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILELOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<WhileLoop> ::= while '(' <Expression> ')' '{' <StatementList> <IncDec> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_IDENTIFIER_PLUSPLUS :
                //<IncDec> ::= Identifier '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_IDENTIFIER_MINUSMINUS :
                //<IncDec> ::= Identifier '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REPEATWHILELOOP_REPEAT_LBRACE_RBRACE_WHILE_LPAREN_RPAREN :
                //<RepeatWhileLoop> ::= repeat '{' <Expression> '}' while '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ :
                //<Expression> ::= <Expression> '==' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EXCLAMEQ :
                //<Expression> ::= <Expression> '!=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_STRINGLITERAL :
                //<Value> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
