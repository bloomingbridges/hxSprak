package;

typedef Token = sprak.tokenizer.Token;

@:expose("Sprak")
class ProgrammingLanguageNr1
{
    public function new() {
        trace("Hallå, värld!");
        var token = new Token(EOF, "");
        trace(token.toString());
    }
    static public function test() {
        trace("This is only a test, of the emergency broadcast system..");
    }
    static function main() {
        return new ProgrammingLanguageNr1();
    }
}