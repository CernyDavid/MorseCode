// See https://aka.ms/new-console-template for more information
using morsecode;

Translator morsecode = new Translator();
Console.WriteLine(morsecode.Encode("Mám dvacet indických dětí v mém sklepě"));
Console.WriteLine(morsecode.Decode(".... . .-.. .-.. --- / .-- --- .-. .-.. -.."));
Console.WriteLine(morsecode.Decode(morsecode.Encode("vochechule")));
Console.WriteLine(morsecode.Decode(morsecode.Encode("Lorem ipsum dolor sit amet consectetur adipisici elit sed eiusmod tempor incidunt ut labore et dolore magna aliqua")));