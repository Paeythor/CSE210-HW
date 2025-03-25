using System;

public class Verse
{
    private Dictionary<string, string> verseDictionary;

    public Verse()
    {
        verseDictionary = new Dictionary<string, string>
        {
            { "Moses 1:39", "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man." },
            { "Matthew 5:14–16", "Ye are the light of the world. A city that is set on a hill cannot be hid. Neither do men light a candle, and put it under a bushel, but on a candlestick, and it giveth light unto all that are in the house. Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven." },
            { "1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandment unto the children of men save he shall prepare a way for them that they may accomplish the thing which he commandeth them." }
        };
    }

    public string GetFullVerse(string reference)
    {
        return verseDictionary.ContainsKey(reference) ? verseDictionary[reference] : "Scripture not found.";
    }
}
