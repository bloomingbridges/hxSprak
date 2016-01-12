package glue;

class TextReader {

     public var contents:String = "";
    private var cursor:Int = 0;

    public function new(?source:String) {
        if (source != null) {
            contents = source;
            trace(contents);
        }
    }

    public function Read():Int {
        if (cursor < contents.length) {
            var char = contents.charAt(cursor);
            cursor++;
            return StringTools.fastCodeAt(char, 0);
        }
        else {
            return -1;
        }
    }

    public function Close() {}

    public function Dispose() {}

}