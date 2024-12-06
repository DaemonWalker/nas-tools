
using System.Security.Cryptography;

var fileName = "";
if (string.IsNullOrEmpty(fileName))
{
    fileName = args.First();
}
Console.WriteLine(ReadTorrent(fileName));


static string ReadTorrent(string fileName)
{
    using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
    {
        var torrent = new Honoo.Text.BEncode.TorrentAnalysis(stream, true);
        Console.WriteLine("created by    :" + torrent.GetCreatedBy());
        Console.WriteLine("creation date :" + torrent.GetCreationDate());
        Console.WriteLine("announce      :" + torrent.GetAnnounce());
        Console.WriteLine("comment       :" + torrent.GetComment());
        Console.WriteLine("hash          :" + torrent.GetHash());
        Console.WriteLine("nodes         :" + torrent.GetNodes());
        Console.WriteLine("name          :" + torrent.GetName());
        Console.WriteLine("piece length  :" + torrent.GetPieceLength());

        var magnet = torrent.GetMagnet(true, true, true, false);
        return magnet;
    }
}