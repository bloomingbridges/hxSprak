package;

import glue.TextReader;
import sprak.tokenizer.*;
import sprak.errors.*;

@:expose("Sprak")
class ProgrammingLanguageNr1
{
    public function new() {
        var tokenizer = new Tokenizer(new ErrorHandler(), false);
        var tr = new TextReader("Hallå, värld!");
        tokenizer.process(tr);
    }
    static public function test() {
        trace("This is only a test, of the emergency broadcast system..");
    }
    static function main() {
        return new ProgrammingLanguageNr1();
    }
}